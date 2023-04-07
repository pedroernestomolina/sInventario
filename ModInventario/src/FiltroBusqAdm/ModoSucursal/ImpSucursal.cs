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
        private IOpcion _gCatalogo;
        private IOpcion _gExistencia;
        private IOpcion _gTCS;
        private Tools.Filtros.Oferta.IOferta _oferta;


        public Tools.Filtros.Oferta.IOferta Oferta { get { return _oferta; } }


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
            _gCatalogo = new FiltrosGen.Opcion.Gestion();
            _gExistencia = new FiltrosGen.Opcion.Gestion();
            _gTCS = new FiltrosGen.Opcion.Gestion();
            _oferta = new Tools.Filtros.Oferta.ImpOferta();
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


        public override bool DataFiltrarIsOk()
        {
            base.DataFiltrarIsOk();
            _data.Deposito = _gDeposito.Item;
            _data.Catalogo = _gCatalogo.Item;
            _data.Categoria = _gCategoria.Item;
            _data.Existencia = _gExistencia.Item;
            _data.Proveedor = _buscarProv.ItemSeleccionado;
            _data.TCS = _gTCS.Item;
            _data.Oferta= _oferta.GetItem;
            return _data.FiltrarIsOk();
        }


        override protected void limpiarEntradas()
        {
            base.limpiarEntradas();
            _gDeposito.Inicializa();
            _gCategoria.Inicializa();
            _gCatalogo.Inicializa();
            _gExistencia.Inicializa();
            _buscarProv.Inicializa();
            _gTCS.Inicializa();
            _oferta.Inicializa();
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

                    var lstEstatus = new List<ficha>();
                    lstEstatus.Add(new ficha("01", "", "ACTIVO"));
                    lstEstatus.Add(new ficha("02", "", "SUSPENDIDO"));
                    if (r03.Entidad)
                    {
                        lstEstatus.Add(new ficha("03", "", "INACTIVO"));
                    }
                    _gEstatus.setData(lstEstatus);

                    var lstExistencia = new List<ficha>();
                    lstExistencia.Add(new ficha("1", "", "Mayor A Cero"));
                    lstExistencia.Add(new ficha("2", "", "Igual Cero"));
                    lstExistencia.Add(new ficha("3", "", "Menor A Cero"));
                    _gExistencia.setData(lstExistencia);

                    var lstCatalogo = new List<ficha>();
                    lstCatalogo.Add(new ficha("1", "", "NO"));
                    lstCatalogo.Add(new ficha("2", "", "SI"));
                    _gCatalogo.setData(lstCatalogo);

                    var lstTCS= new List<ficha>();
                    lstTCS.Add(new ficha("1", "", "SI"));
                    lstTCS.Add(new ficha("2", "", "NO"));
                    _gTCS.setData(lstTCS);

                    _oferta.CargarData();
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


        //TALLA/COLOR/SABOR
        public BindingSource SourceTCS { get { return _gTCS.Source; } }
        public string GetIdTCS { get { return _gTCS.GetId; } }
        public void setIdTCS(string id)
        {
            _gTCS.setFicha(id);
        }
        //DEPOSITO
        public BindingSource SourceDeposito { get { return _gDeposito.Source; } }
        public string GetIdDeposito { get { return _gDeposito.GetId; } }
        public void setIdDeposito(string id)
        {
            _gDeposito.setFicha(id);
        }
        //CATALOGO
        public BindingSource SourceCatalogo { get { return _gCatalogo.Source; } }
        public string GetIdCatalogo { get { return _gCatalogo.GetId; } }
        public void setIdCatalogo(string id)
        {
            _gCatalogo.setFicha(id);
        }
        //Categoria
        public BindingSource SourceCategoria { get { return _gCategoria.Source; } }
        public string GetIdCategoria { get { return _gCategoria.GetId; } }
        public void setIdCategoria(string id)
        {
            _gCategoria.setFicha(id);
        }
        //EXISTENCIA
        public BindingSource SourceExistencia { get { return _gExistencia.Source; } }
        public string GetIdExistencia { get { return _gExistencia.GetId; } }
        public void setIdExistencia(string id)
        {
            _gExistencia.setFicha(id);
        }
        //PROVEEDOR
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
    }
}