using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroAdmDoc
{
    
    abstract public class baseAdmDoc: IAdmDoc
    {

        protected dataExportar _dataExportar;


        protected ModInventario.FiltrosGen.IOpcion _depOrigen;
        protected ModInventario.FiltrosGen.IOpcion _depDestino;
        protected ModInventario.FiltrosGen.IOpcion _concepto;
        protected ModInventario.FiltrosGen.IOpcion _estatus;
        protected ModInventario.FiltrosGen.IOpcion _tipoDoc;
        protected ModInventario.FiltrosGen.IFecha _desde;
        protected ModInventario.FiltrosGen.IFecha _hasta;
        protected FiltrosGen.IBuscar _filtroBusPrd;


        public BindingSource GetDepOrigen_Source { get { return _depOrigen.Source; } }
        public BindingSource GetDepDestino_Source { get { return _depDestino.Source; } }
        public BindingSource GetEstatus_Source { get { return _estatus.Source; } }
        public BindingSource GetConcepto_Source { get { return _concepto.Source; } }
        public BindingSource GetTipoDoc_Source { get { return _tipoDoc.Source; } }


        public string GetDepOrigen_Id { get { return _depOrigen.GetId; } }
        public string GetDepDestino_Id { get { return _depDestino.GetId; } }
        public string GetConcepto_Id { get { return _concepto.GetId; } }
        public string GetEstatus_Id { get { return _estatus.GetId; } }
        public string GetTipoDoc_Id { get { return _tipoDoc.GetId; } }
        public DateTime GetFechaDesde { get { return _desde.GetFecha; } }
        public DateTime GetFechaHasta { get { return _hasta.GetFecha; } }


        public void setDepOrigen(string id)
        {
            _depOrigen.setFicha(id);
            _dataExportar.DepOrigen = _depOrigen.Item;
        }
        public void setDepDestino(string id)
        {
            _depDestino.setFicha(id);
            _dataExportar.DepDestino = _depDestino.Item;
        }
        public void setEstatus(string id)
        {
            _estatus.setFicha(id);
            _dataExportar.Estatus = _estatus.Item;
        }
        public void setConcepto(string id)
        {
            _concepto.setFicha(id);
            _dataExportar.Concepto = _concepto.Item;
        }
        public void setTipoDoc(string id)
        {
            _tipoDoc.setFicha(id);
            _dataExportar.TipoDoc = _tipoDoc.Item;
        }
        public void setFechaDesde(DateTime fecha)
        {
            _desde.setFecha(fecha);
            _dataExportar.Desde = fecha;
        }
        public void setFechaHasta(DateTime fecha)
        {
            _hasta.setFecha(fecha);
            _dataExportar.Hasta = fecha;
        }
        public void setFechaDesdeEstatusOff()
        {
            _desde.setEstatusOff();
            _dataExportar.Desde= null;
        }
        public void setFechaHastaEstatusOff()
        {
            _hasta.setEstatusOff();
            _dataExportar.Hasta = null;
        }


        abstract public void Inicia();


        virtual public void Inicializa()
        {
            _dataExportar.Inicializa();
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _depOrigen.Inicializa();
            _depDestino.Inicializa();
            _estatus.Inicializa();
            _concepto.Inicializa();
            _tipoDoc.Inicializa();
            _sucursal.Inicializa();
            _desde.Inicializa();
            _hasta.Inicializa();
            _filtroBusPrd.Inicializa();
        }


        public virtual bool CargarData() 
        {
            try
            {
                var _lst_1 = new List<ficha>();
                var xr1 = Sistema.MyData.Concepto_GetLista();
                foreach (var rg in xr1.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lst_1.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _concepto.setData(_lst_1);

                var _lst_2 = new List<ficha>();
                var xr2 = Sistema.MyData.Deposito_GetLista();
                foreach (var rg in xr2.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lst_2.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _depOrigen.setData(_lst_2);
                _depDestino.setData(_lst_2);

                var _lst_3 = new List<ficha>();
                _lst_3.Add(new ficha("1", "", "ACTIVO"));
                _lst_3.Add(new ficha("2", "", "ANULADO"));
                _estatus.setData(_lst_3);

                var _lst_4 = new List<ficha>();
                _lst_4.Add(new ficha("1", "01", "CARGO"));
                _lst_4.Add(new ficha("2", "02", "DESCARGO"));
                _lst_4.Add(new ficha("3", "03", "TRASLADO"));
                _lst_4.Add(new ficha("4", "04", "AJUSTE"));
                _tipoDoc.setData(_lst_4);

                var _lst_5 = new List<ficha>();
                var xr3 = Sistema.MyData.Sucursal_GetLista(new OOB.LibInventario.Sucursal.Filtro());
                foreach (var rg in xr3.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lst_5.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _sucursal.setData(_lst_5);

                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }

        private bool _procesarIsOk;
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = true;
        }

        
        public dataExportar ExportarData() 
        {
            return _dataExportar;
        }


        protected ModInventario.FiltrosGen.IOpcion _sucursal;
        public BindingSource GetSucursal_Source { get { return _sucursal.Source; } }
        public string GetSucursal_Id { get { return _sucursal.GetId; } }
        public void setSucursal(string id)
        {
            _sucursal.setFicha(id);
            _dataExportar.Sucursal = _sucursal.Item;
        }


        public string GetProducto_Desc { get { return _filtroBusPrd.DescItemSeleccionado;} }
        public bool GetHabilitarProducto { get { return _filtroBusPrd.ItemIsOk; } }
        public void setProductoBuscar(string busc)
        {
            _filtroBusPrd.setCadenaBuscar(busc);
        }
        public void BuscarProducto()
        {
            _filtroBusPrd.Buscar();
            if (_filtroBusPrd.ItemIsOk)
            {
                _dataExportar.Producto = _filtroBusPrd.ItemSeleccionado;
            }
        }
        public void LimpiarProducto()
        {
            _filtroBusPrd.LimpiarItem();
            _dataExportar.Producto = _filtroBusPrd.ItemSeleccionado;
        }

    }

}