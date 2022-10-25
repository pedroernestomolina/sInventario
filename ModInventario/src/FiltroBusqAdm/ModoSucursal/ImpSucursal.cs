using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.ModoSucursal
{

    public class ImpSucursal : BaseImpFiltroPrd, ISucursal
    {

        private IBuscar _buscarProv;
        private IOpcion _gDeposito;
        private IOpcion _gCategoria;
        private IOpcion _gOferta;
        private IOpcion _gCatalogo;
        private IOpcion _gExistencia;


        public ImpSucursal(IBuscar buscarProv)
        {
            _data = new dataFiltro();
            _buscarProv = buscarProv;
            _gMarca = new FiltrosGen.Opcion.Gestion();
            _gOrigen = new FiltrosGen.Opcion.Gestion();
            _gTasaIva = new FiltrosGen.Opcion.Gestion();
            _gEstatus = new FiltrosGen.Opcion.Gestion();
            _gDivisa = new FiltrosGen.Opcion.Gestion();
            _gPesado = new FiltrosGen.Opcion.Gestion();
            _gDepartamento = new FiltrosGen.Opcion.Gestion();
            _gGrupo = new FiltrosGen.Opcion.Gestion();
            _gDeposito = new FiltrosGen.Opcion.Gestion();
            _gCategoria = new FiltrosGen.Opcion.Gestion();
            _gOferta = new FiltrosGen.Opcion.Gestion();
            _gCatalogo = new FiltrosGen.Opcion.Gestion();
            _gExistencia = new FiltrosGen.Opcion.Gestion();
            reset();
        }


        FiltrosFrm frm;
        override public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new FiltrosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public BindingSource GetDepositoSource { get { return _gDeposito.Source; } }
        public BindingSource GetCategoriaSource { get { return _gCategoria.Source; } }
        public BindingSource GetOfertaSource { get { return _gOferta.Source; } }
        public BindingSource GetCatalogoSource { get { return _gCatalogo.Source; } }
        public BindingSource GetExistenciaSource { get { return _gExistencia.Source; } }


        public string GetDepositoId { get { return _gDeposito.GetId; } }
        public string GetCategoriaId { get { return _gCategoria.GetId; } }
        public string GetOfertaId { get { return _gOferta.GetId; } }
        public string GetExistenciaId { get { return _gExistencia.GetId; } }
        public string GetCatalogoId { get { return _gCatalogo.GetId; } }


        public void setDeposito(string id)
        {
            _gDeposito.setFicha(id);
        }
        public void setCategoria(string id)
        {
            _gCategoria.setFicha(id);
        }
        public void setCatalogo(string id)
        {
            _gCatalogo.setFicha(id);
        }
        public void setOferta(string id)
        {
            _gOferta.setFicha(id);
        }
        public void setExistencia(string id)
        {
            _gExistencia.setFicha(id);
        }


        public string GetProveedorNombreFiltrar { get { return _buscarProv.DescItemSeleccionado; } }
        public bool ProveedorIsOk { get { return _buscarProv.ItemIsOk; } }
        public void setProveedorCadenaBuscar(string cad)
        {
            _buscarProv.setCadenaBuscar(cad);
        }
        public void ProveedorBuscar()
        {
            _buscarProv.Buscar();
        }
        public void ProveedorLimpiar()
        {
            _buscarProv.LimpiarItem();
        }


        public override bool DataFiltrarIsOk()
        {
            base.DataFiltrarIsOk();
            _data.Deposito = _gDeposito.Item;
            _data.Catalogo = _gCatalogo.Item;
            _data.Categoria = _gCategoria.Item;
            _data.Oferta= _gOferta.Item;
            _data.Existencia = _gExistencia.Item;
            _data.Proveedor = _buscarProv.ItemSeleccionado;
            return _data.FiltrarIsOk();
        }


        override protected void limpiarEntradas()
        {
            base.limpiarEntradas();
            _gDeposito.Inicializa();
            _gCategoria.Inicializa();
            _gOferta.Inicializa();
            _gCatalogo.Inicializa();
            _gExistencia.Inicializa();
            _buscarProv.Inicializa();
        }
        override protected bool CargarData() 
        {
            if (base.CargarData())
            {
                try
                {
                    var lstCategoria = new List<ficha>();
                    var r01 = Sistema.MyData.Producto_Categoria_Lista();
                    foreach (var rg in r01.Lista.OrderBy(o => o.Descripcion).ToList())
                    {
                        lstCategoria.Add(new ficha(rg.Id, "", rg.Descripcion));
                    }
                    _gCategoria.setData(lstCategoria);

                    var lstDeposito = new List<ficha>();
                    var r02 = Sistema.MyData.Deposito_GetLista();
                    foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
                    {
                        lstDeposito.Add(new ficha(rg.auto, "", rg.nombre));
                    }
                    _gDeposito.setData(lstDeposito);

                    var r03 = Sistema.MyData.Configuracion_VisualizarProductosInactivos();
                    if (r03.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r03.Mensaje);
                        return false;
                    }
                    var lstEstatus = new List<ficha>();
                    lstEstatus.Add(new ficha("01", "", "ACTIVO"));
                    lstEstatus.Add(new ficha("02", "", "SUSPENDIDO"));
                    if (r03.Entidad)
                    {
                        lstEstatus.Add(new ficha("03", "", "INACTIVO"));
                    }
                    _gEstatus.setData(lstEstatus);

                    var r04 = Sistema.MyData.Producto_Oferta_Lista();
                    if (r04.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r04.Mensaje);
                        return false;
                    }
                    var lstOferta = new List<ficha>();
                    foreach (var rg in r04.Lista.OrderBy(o => o.Descripcion).ToList())
                    {
                        lstOferta.Add(new ficha(rg.Id.ToString().Trim(), "", rg.Descripcion));
                    }
                    _gOferta.setData(lstOferta);

                    var lstExistencia = new List<ficha>();
                    lstExistencia.Add(new ficha("1", "", "Mayor A Cero"));
                    lstExistencia.Add(new ficha("2", "", "Igual Cero"));
                    lstExistencia.Add(new ficha("3", "", "Menor A Cero"));
                    _gExistencia.setData(lstExistencia);

                    var lstCatalogo = new List<ficha>();
                    lstCatalogo.Add(new ficha("1", "", "NO"));
                    lstCatalogo.Add(new ficha("2", "", "SI"));
                    _gCatalogo.setData(lstCatalogo);

                    return true;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message );
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }

    }

}