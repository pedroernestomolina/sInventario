using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.ModoAdm
{
    public class ImpMasiva : IMasiva
    {
        private bool _abandonarIsOk;
        private bool _procesarIsOK;
        private Items.IItems _items;
        private Precio.IPrecio _precio;
        private DateTime _desde;
        private DateTime _hasta;
        private decimal _porct;
        private Utils.FiltrosPara.BusqProducto.Busqueda.IComp _compBusqProducto;


        public Items.IItems Items { get { return _items; } }
        public Precio.IPrecio Precio { get { return _precio; } }
        public DateTime GetDesde { get { return _desde; } }
        public DateTime GetHasta { get { return _hasta; } }
        public string GetPorctDesc { get { return _porct.ToString("n2", CultureInfo.CurrentCulture); } }
        public Utils.FiltrosPara.BusqProducto.Busqueda.IComp CompBusqProducto { get { return _compBusqProducto; } }


        public ImpMasiva()
        {
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _abandonarIsOk = false;
            _procesarIsOK = false;
            _precio = new Precio.ImpPrecio();
            _items = new Items.ImpItems();
            _compBusqProducto = new Utils.FiltrosPara.BusqProducto.Busqueda.ImpComp();
        }


        public void Inicializa()
        {
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _abandonarIsOk = false;
            _procesarIsOK = false;
            _precio.Inicializa();
            _items.Inicializa();
            _compBusqProducto.Inicializa();
        }

        private Frm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void Buscar()
        {
            if (!_compBusqProducto.HayParametrosBusqueda)
            {
                Helpers.Msg.Alerta("NO HAY PARAMETROS SELECCIONADOS PARA REALIZAR LA BUSQUEDA");
                return;
            }
            try
            {
                var r01 = Sistema.MyData.Producto_GetLista(_compBusqProducto.DataExportar());
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var _lst = new List<Items.data>();
                foreach (var rg in r01.Lista.OrderBy(o => o.DescripcionPrd).ToList())
                {
                    var it = new Items.data()
                    {
                        codPrd = rg.CodigoPrd,
                        descPrd = rg.DescripcionPrd,
                        idPrd = rg.AutoId,
                    };
                    _lst.Add(it);
                }
                _items.setData(_lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }

            //_busqueda.Buscar();
            //if (_busqueda.BuscarIsOk) 
            //{
            //    //_items.setData((src.FiltroBusqAdm.dataFiltro)_busqueda.FiltrosExportar);
            //}
        }
        public void LimpiarTodo()
        {
            _items.LimpiarTodo();
            _compBusqProducto.Limpiar();
        }


        public void setDesde(DateTime fecha)
        {
            _desde = fecha;
        }
        public void setHasta(DateTime fecha)
        {
            _hasta = fecha;
        }
        public void setPorct(decimal monto)
        {
            _porct = monto;
        }


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOk { get { return _procesarIsOK; } }
        public void ProcesarFicha()
        {
            _procesarIsOK = false;
            if (ValidarIsOk())
            {
                var _rt = Helpers.Msg.ProcesarGuardar();
                if (_rt)
                {
                    Procesar();
                }
            }
        }


        private bool CargarData()
        {
            try
            {
                _compBusqProducto.CargarData();
                _precio.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private bool ValidarIsOk()
        {
            if (_items.GetCnt == 0)
            {
                Helpers.Msg.Alerta("NO HAY ITEMS QUE ASIGNAR OFERTAS");
                return false;
            }
            if (_precio.GetId == "")
            {
                Helpers.Msg.Alerta("DEBES INDICAR UN PRECIO PARA LA OFERTA");
                return false;
            }
            if (_desde > _hasta)
            {
                Helpers.Msg.Alerta("PROBLEMA DE FECHAS INCORRECTAS");
                return false;
            }
            if (_porct == 0m)
            {
                Helpers.Msg.Alerta("DEBES INDICAR UN PORCENTANJE PARA LA OFERTA");
                return false;
            }
            return true;
        }
        private void Procesar()
        {
            try
            {
                var _tipoEmp = "";
                switch (_precio.GetId)
                {
                    case "01":
                        _tipoEmp = "1";
                        break;
                    case "02":
                        _tipoEmp = "2";
                        break;
                    case "03":
                        _tipoEmp = "3";
                        break;
                }
                var _lst = new List<string>();
                foreach (var rg in _items.GetLista)
                {
                    _lst.Add(rg.idPrd);
                }
                var filtroOOB = new OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Capturar.Filtro()
                {
                    tipoEmpaque = _tipoEmp,
                    tipoPrecio = "1",
                    listadPrd = _lst,
                };
                var r01 = Sistema.MyData.Producto_ModoAdm_OfertaMasiva_Capturar(filtroOOB);
                var ldata = new List<data>();
                foreach (var rg in r01.Lista)
                {
                    var nr = new data(rg, _porct);
                    ldata.Add(nr);
                }

                var ofertasOOB = new List<OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Actualizar.Oferta>();
                foreach (var rg in ldata.Where(f => f.IsOk()))
                {
                    var ni = new OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Actualizar.Oferta()
                    {
                        autoPrd = rg.AutoPrd,
                        desde = _desde,
                        estatus = "1",
                        estatusOferta = "1",
                        hasta = _hasta,
                        idPrecioVta = rg.IdPrecioVta,
                        portc = _porct,
                    };
                    ofertasOOB.Add(ni);
                }
                var fichaOOB = new OOB.LibInventario.Producto.ActualizarOfertaMasiva.ModoAdm.Actualizar.Ficha()
                {
                    ofertas = ofertasOOB,
                };
                var r02 = Sistema.MyData.Producto_ModoAdm_OfertaMasiva_Actualizar(fichaOOB);
                Helpers.Msg.EditarOk();
                _procesarIsOK = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}