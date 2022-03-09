using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.FiltrosGen.AdmDoc
{
    
    public class Gestion:IAdmDoc
    {


        private data _data;
        private IOpcion _gConcepto;
        private IOpcion _gEstatus;
        private IOpcion _gDepOrigen;
        private IOpcion _gDepDestino;
        private IOpcion _gSucursal;
        private IOpcion _gTipoDoc;
        private IBuscar _gProducto;
        private IFecha _gDesde;
        private IFecha _gHasta;
        private bool _procesarIsOk;


        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public BindingSource SourceConcepto { get { return _gConcepto.Source; } }
        public BindingSource SourceEstatus { get { return _gEstatus.Source; } }
        public BindingSource SourceDepOrigen { get { return _gDepOrigen.Source; } }
        public BindingSource SourceDepDestino { get { return _gDepDestino.Source; } }
        public BindingSource SourceSucursal { get { return _gSucursal.Source; } }
        public BindingSource SourceTipoDoc { get { return _gTipoDoc.Source; } }
        public string DepOrigenID { get { return _gDepOrigen.GetId; } }
        public string DepDestinoID { get { return _gDepDestino.GetId; } }
        public string ConceptoID { get { return _gConcepto.GetId; } }
        public string EstatusID { get { return _gEstatus.GetId; } }
        public string SucursalID { get { return _gSucursal.GetId; } }
        public string TipoDocID { get { return _gTipoDoc.GetId; } }
        public bool ProductoSeleccioandoIsOk { get { return _gProducto.ItemIsOk; } }
        public string DescProductoAFiltrar { get { return _gProducto.DescItemSeleccionado; } }
        public data DataFiltrar { get { return _data; } }
        //
        public IOpcion Sucursal { get { return _gSucursal; } }
        public IOpcion TipoDoc { get { return _gTipoDoc; } }
        public IFecha FechaDesde { get { return _gDesde; } }
        public IFecha FechaHasta { get { return _gHasta; } }


        public Gestion(IOpcion concepto, IOpcion estatus, IOpcion depOrigen, IOpcion depDestino, IBuscar buscarPrd,
            IOpcion sucursal, IOpcion tipoDoc, IFecha desde, IFecha hasta)
        {
            _data = new data();
            _procesarIsOk = false;
            _gConcepto = concepto;
            _gEstatus = estatus;
            _gDepOrigen = depOrigen;
            _gDepDestino = depDestino;
            _gProducto = buscarPrd;
            _gSucursal= sucursal;
            _gTipoDoc= tipoDoc;
            _gDesde = desde;
            _gHasta = hasta;
        }


        public void Inicializa()
        {
            _gConcepto.Inicializa();
            _gEstatus.Inicializa();
            _gDepOrigen.Inicializa();
            _gDepDestino.Inicializa();
            _gSucursal.Inicializa();
            _gTipoDoc.Inicializa();
            _gDesde.Inicializa();
            _gHasta.Inicializa();
            _gProducto.Inicializa();
            _data.Inicializa();
            _procesarIsOk = false;
        }

        FiltroFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new FiltroFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var xr1 = Sistema.MyData.Concepto_GetLista();
            if (xr1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return false;
            }
            var lst = new List<ficha>();
            foreach (var rg in xr1.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gConcepto.setData(lst);

            var lst2 = new List<ficha>();
            lst2.Add(new ficha("1", "", "ACTIVO"));
            lst2.Add(new ficha("2", "", "ANULADO"));
            _gEstatus.setData(lst2);

            var xr3 = Sistema.MyData.Deposito_GetLista();
            if (xr3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr3.Mensaje);
                return false;
            }
            var lst3 = new List<ficha>();
            foreach (var rg in xr3.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst3.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gDepOrigen.setData(lst3);
            _gDepDestino.setData(lst3);

            return true;
        }

        public void LimpiarFiltros()
        {
            _gConcepto.Limpiar();
            _gDepDestino.Limpiar();
            _gDepOrigen.Limpiar();
            _gEstatus.Limpiar();
            _gProducto.LimpiarItem();
            _gSucursal.Limpiar();
            _gTipoDoc.Limpiar();
            _gDesde.Limpiar();
            _gHasta.Limpiar();
            _data.Inicializa();
            _procesarIsOk = false;
        }

        public bool DataFiltrarIsOk()
        {
            _data.Producto = _gProducto.ItemSeleccionado;
            _data.Concepto = _gConcepto.Item;
            _data.Estatus = _gEstatus.Item;
            _data.DepDestino = _gDepDestino.Item;
            _data.DepOrigen = _gDepOrigen.Item;
            _data.Sucursal = _gSucursal.Item;
            _data.TipoDoc = _gTipoDoc.Item;
            _data.Desde = _gDesde.FechaFiltro;
            _data.Hasta= _gHasta.FechaFiltro;
            return _data.FiltrarIsOk();
        }

        public void setConcepto(string id)
        {
            _gConcepto.setFicha(id);
        }
        public void setEstatus(string id)
        {
            _gEstatus.setFicha(id);
        }
        public void setDepOrigen(string id)
        {
            _gDepOrigen.setFicha(id);
        }
        public void setDepDestino(string id)
        {
            _gDepDestino.setFicha(id);
        }
        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
        }
        public void setTipoDoc(string id)
        {
            _gTipoDoc.setFicha(id);
        }
        public void setProducto(string cadena)
        {
            _gProducto.setCadenaBuscar(cadena);
        }

        public void BuscarProducto()
        {
            _gProducto.Buscar();
        }
        public void LimpiarProducto()
        {
            _gProducto.LimpiarItem();
        }

        public void Procesar()
        {
            _procesarIsOk = true;
        }

    }

}