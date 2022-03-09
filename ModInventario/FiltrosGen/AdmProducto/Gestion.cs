using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.FiltrosGen.AdmProducto
{

    public class Gestion: IAdmProducto
    {

        private data _data;
        private bool _limpiarIsOk;
        private bool _procesarIsOk;
        //
        private IBuscar _gProveedor;
        private IOpcion _gDepartamento;
        private IOpcion _gGrupo;
        private IOpcion _gMarca;
        private IOpcion _gDeposito;
        private IOpcion _gCategoria;
        private IOpcion _gOrigen;
        private IOpcion _gTasaIva;
        private IOpcion _gEstatus;
        private IOpcion _gDivisa;
        private IOpcion _gPesado;
        private IOpcion _gOferta;
        private IOpcion _gExistencia;
        private IOpcion _gCatalogo;
        private IOpcion _gPrecioMay;


        public BindingSource SourceDepart { get { return _gDepartamento.Source; } }
        public BindingSource SourceGrupo { get { return _gGrupo.Source; } }
        public BindingSource SourceMarca{ get { return _gMarca.Source; } }
        public BindingSource SourceDeposito { get { return _gDeposito.Source; } }
        public BindingSource SourceCategoria { get { return _gCategoria.Source; } }
        public BindingSource SourceOrigen { get { return _gOrigen.Source; } }
        public BindingSource SourceTasa { get { return _gTasaIva.Source; } }
        public BindingSource SourceEstatus{ get { return _gEstatus.Source; } }
        public BindingSource SourceAdmDivisa { get { return _gDivisa.Source; } }
        public BindingSource SourcePesado { get { return _gPesado.Source; } }
        public BindingSource SourceOferta { get { return _gOferta.Source; } }
        public BindingSource SourceExistencia { get { return _gExistencia.Source; } }
        public BindingSource SourceCatalogo { get { return _gCatalogo.Source; } }
        public BindingSource SourcePrecioMayor { get { return _gPrecioMay.Source; } }
        public string IdDepartamento { get { return _gDepartamento.GetId; } }
        public string IdGrupo { get { return _gGrupo.GetId; } }
        public string IdMarca { get { return _gMarca.GetId; } }
        public string IdDeposito { get { return _gDeposito.GetId; } }
        public string IdTasaIva { get { return _gTasaIva.GetId; } }
        public string IdCategoria { get { return _gCategoria.GetId; } }
        public string IdOrigen { get { return _gOrigen.GetId; } }
        public string IdEstatus { get { return _gEstatus.GetId; } }
        public string IdAdmDivisa { get { return _gDivisa.GetId; } }
        public string IdPesado { get { return _gPesado.GetId; } }
        public string IdOferta { get { return _gOferta.GetId; } }
        public string IdExistencia { get { return _gExistencia.GetId; } }
        public string IdCatalogo { get { return _gCatalogo.GetId; } }
        public string IdPrecioMayor { get { return _gPrecioMay.GetId; } }
        public bool LimpiarIsOk { get { return _limpiarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool ProveedorSeleccionadoIsOk { get { return _gProveedor.ItemIsOk; } }
        public string NombreProvAFiltrar { get { return _gProveedor.DescItemSeleccionado; } }
        public int MetBusqueda { get { return (int)_data.MetBusqueda; } }
        public string CadenaBusq { get { return _data.CadenaBusq; } }
        public data dataFiltrar { get { return _data; } }


        public Gestion(IOpcion marca, IBuscar prov, IOpcion deposito, IOpcion categoria, 
            IOpcion origen, IOpcion tasaIva, IOpcion estatus, IOpcion divisa, IOpcion pesado,
            IOpcion oferta, IOpcion existencia, IOpcion catalogo, IOpcion precioMay, 
            IOpcion departamento, IOpcion grupo)
        {
            _limpiarIsOk = false;
            _procesarIsOk = false;
            _data = new data();
            _gMarca = marca;
            _gProveedor = prov;
            _gDeposito = deposito;
            _gCategoria = categoria;
            _gOrigen = origen;
            _gTasaIva = tasaIva;
            _gEstatus = estatus;
            _gDivisa = divisa;
            _gPesado = pesado;
            _gOferta= oferta;
            _gExistencia= existencia;
            _gCatalogo= catalogo;
            _gPrecioMay= precioMay;
            _gDepartamento= departamento;
            _gGrupo = grupo;
        }


        public void Inicializa() 
        {
            _limpiarIsOk = false;
            _procesarIsOk = false;
            limpiarEntradas();
        }

        FiltrosFrm frm;
        public void Inicia()
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

        private bool CargarData()
        {
            var rt = true;

            var r00 = Sistema.MyData.Configuracion_VisualizarProductosInactivos();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return false;
            }
            var _activarProductosInactivos = r00.Entidad;

            var r01 = Sistema.MyData.Departamento_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var lstDepart= new List<ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                lstDepart.Add(new ficha(rg.auto, "", rg.nombre));
            }
            _gDepartamento.setData(lstDepart);

            var r03 = Sistema.MyData.Producto_Categoria_Lista();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            var lstCategoria= new List<ficha>();
            foreach (var rg in r03.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                lstCategoria.Add(new ficha(rg.Id, "", rg.Descripcion));
            }
            _gCategoria.setData(lstCategoria);

            var r04 = Sistema.MyData.Producto_Origen_Lista();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            var lstOrigen = new List<ficha>();
            foreach (var rg in r04.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                lstOrigen.Add(new ficha(rg.Id, "", rg.Descripcion));
            }
            _gOrigen.setData(lstOrigen);

            var r05 = Sistema.MyData.TasaImpuesto_GetLista();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            var lstTasa = new List<ficha>();
            foreach (var rg in r05.Lista.OrderBy(o => o.tasa).ToList())
            {
                lstTasa.Add(new ficha(rg.auto, "", rg.ToString()));
            }
            _gTasaIva.setData(lstTasa);

            var r06 = Sistema.MyData.Marca_GetLista ();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            var lstMarca = new List<ficha>();
            foreach (var rg in r06.Lista.OrderBy(o => o.nombre).ToList())
            {
                lstMarca.Add(new ficha(rg.auto, "", rg.nombre));
            }
            _gMarca.setData(lstMarca);

            var r07 = Sistema.MyData.Deposito_GetLista();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return false;
            }
            var lstDeposito= new List<ficha>();
            foreach (var rg in r07.Lista.OrderBy(o => o.nombre).ToList())
            {
                lstDeposito.Add(new ficha(rg.auto, "", rg.nombre));
            }
            _gDeposito.setData(lstDeposito);

            var lstEstatus = new List<ficha>();
            lstEstatus.Add(new ficha("01", "", "ACTIVO"));
            lstEstatus.Add(new ficha("02", "", "SUSPENDIDO"));
            if (_activarProductosInactivos)
            {
                lstEstatus.Add(new ficha("03", "", "INACTIVO"));
            }
            _gEstatus.setData(lstEstatus);

            var r09 = Sistema.MyData.Producto_AdmDivisa_Lista();
            if (r09.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return false;
            }
            var lstDivisa= new List<ficha>();
            foreach (var rg in r09.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                lstDivisa.Add(new ficha(rg.Id, "", rg.Descripcion));
            }
            _gDivisa.setData(lstDivisa);

            var r0A = Sistema.MyData.Producto_Pesado_Lista ();
            if (r0A.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0A.Mensaje);
                return false;
            }
            var lstPesado= new List<ficha>();
            foreach (var rg in r0A.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                lstPesado.Add(new ficha(rg.Id.ToString().Trim(), "", rg.Descripcion));
            }
            _gPesado.setData(lstPesado);

            var r0B = Sistema.MyData.Producto_Oferta_Lista ();
            if (r0B.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0B.Mensaje);
                return false;
            }
            var lstOferta= new List<ficha>();
            foreach (var rg in r0B.Lista.OrderBy(o => o.Descripcion).ToList())
            {
                lstOferta.Add(new ficha(rg.Id.ToString().Trim(), "", rg.Descripcion));
            }
            _gOferta.setData(lstOferta);

            var lstExistencia= new List<ficha>();
            lstExistencia.Add(new ficha("1", "", "Mayor A Cero"));
            lstExistencia.Add(new ficha("2", "", "Igual Cero"));
            lstExistencia.Add(new ficha("3", "", "Menor A Cero"));
            _gExistencia.setData(lstExistencia);

            var lstCatalogo = new List<ficha>();
            lstCatalogo.Add(new ficha("1", "", "NO"));
            lstCatalogo.Add(new ficha("2", "", "SI"));
            _gCatalogo.setData(lstCatalogo);

            var lstPrecioMayor= new List<ficha>();
            lstPrecioMayor.Add(new ficha("1", "", "SI"));
            _gPrecioMay.setData(lstPrecioMayor);

            return rt;
        }

        public void LimpiarSelecciones()
        {
            _limpiarIsOk= false;
            var msg = MessageBox.Show("Limpiar Selecciones ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                _limpiarIsOk= true;
                limpiarEntradas();
            }
        }

        public void BuscarProveedor()
        {
            _gProveedor.Buscar();
        }

        public void setDepartamento(string id)
        {
            _gDepartamento.setFicha(id);
            _gGrupo.setFicha("");
            if (id != "")
            {
                var r01 = Sistema.MyData.Grupo_GetListaByIdDepartamento(id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return ;
                }
                var lst = new List<ficha>();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gGrupo.setData(lst);
            }
        }
        public void setGrupo(string id)
        {
            _gGrupo.setFicha(id);
        }
        public void setEstatus(string id)
        {
            _gEstatus.setFicha(id);
        }
        public void setMarca(string id)
        {
            _gMarca.setFicha(id);
        }
        public void setDeposito(string id)
        {
            _gDeposito.setFicha(id);
        }
        public void setCategoria(string id)
        {
            _gCategoria.setFicha(id);
        }
        public void setOrigen(string id)
        {
            _gOrigen.setFicha(id);
        }
        public void setTasaIva(string id)
        {
            _gTasaIva.setFicha(id);
        }
        public void setAdmDivisa(string id)
        {
            _gDivisa.setFicha(id);
        }
        public void setPesado(string id)
        {
            _gPesado.setFicha(id);
        }
        public void setOferta(string id)
        {
            _gOferta.setFicha(id);
        }
        public void setExistencia(string id)
        {
            _gExistencia.setFicha(id);
        }
        public void setCatalogo(string id)
        {
            _gCatalogo.setFicha(id);
        }
        public void setPrecioMayor(string id)
        {
            _gPrecioMay.setFicha(id);
        }
        public void LimpiarProveedor()
        {
            _gProveedor.LimpiarItem();
        }
        public void setProveedorBuscar(string cadena)
        {
            _gProveedor.setCadenaBuscar(cadena);
        }
        public void setCadenaBusc(string cadena)
        {
            _data.setCadenaBusq(cadena);
        }
        public void setMetBusqByCodigo()
        {
            _data.setMetBusqByCodigo();
        }
        public void setMetBusqByNombre()
        {
            _data.setMetBusqByNombre();
        }
        public void setMetBusqByReferencia()
        {
            _data.setMetBusqByReferencia();
        }


        public void LimpiarFiltros()
        {
            _limpiarIsOk = true;
            limpiarEntradas();
        }

        public void ProcesarFiltros()
        {
            _procesarIsOk = true; 
        }

        public bool DataFiltrarIsOk()
        {
            _data.Proveedor = _gProveedor.ItemSeleccionado;
            _data.Departamento = _gDepartamento.Item;
            _data.Grupo = _gGrupo.Item;
            _data.Marca = _gMarca.Item;
            _data.Deposito = _gDeposito.Item;
            _data.Categoria= _gCategoria.Item;
            _data.Origen = _gOrigen.Item;
            _data.TasaIva = _gTasaIva.Item;
            _data.Estatus = _gEstatus.Item;
            _data.AdmDivisa = _gDivisa.Item;
            _data.Pesado = _gPesado.Item;
            _data.Oferta= _gOferta.Item;
            _data.Existencia= _gExistencia.Item;
            _data.Catalogo= _gCatalogo.Item;
            _data.PrecioMayor= _gPrecioMay.Item;
            return _data.FiltrarIsOk();
        }

        private void limpiarEntradas()
        {
            _data.Limpiar();
            _gDeposito.Inicializa();
            _gMarca.Inicializa();
            _gCategoria.Inicializa();
            _gOrigen.Inicializa();
            _gProveedor.Inicializa();
            _gTasaIva.Inicializa();
            _gEstatus.Inicializa();
            _gDivisa.Inicializa();
            _gPesado.Inicializa();
            _gOferta.Inicializa();
            _gExistencia.Inicializa();
            _gCatalogo.Inicializa();
            _gPrecioMay.Inicializa();
            _gDepartamento.Inicializa();
            _gGrupo.Inicializa();
        }

    }

}