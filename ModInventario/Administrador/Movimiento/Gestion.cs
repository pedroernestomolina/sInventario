using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Administrador.Movimiento
{
    
    public class Gestion: IGestion
    {

        private IGestionListaDetalle _gestionListaDetalle;
        private Anular.Gestion _gestionAnular;
        private FiltrosGen.IAdmDoc _gFiltro;
        private bool _limpiarFiltrosIsOk;


        public enumerados.EnumTipoAdministrador TipoAdministrador { get { return enumerados.EnumTipoAdministrador.AdmDocumentos; } }
        public string Titulo { get { return "Administrador De Documentos de Inventario"; } }
        public BindingSource Source { get { return _gestionListaDetalle.Source; } }
        public string Items { get { return _gestionListaDetalle.Items; }}
        public BindingSource SucursalSource { get { return _gFiltro.Sucursal.Source; } }
        public BindingSource TipoDocSource { get { return _gFiltro.TipoDoc.Source; } }
        public string SucursalID { get { return _gFiltro.Sucursal.GetId; } }
        public string TipoDocID{ get { return _gFiltro.TipoDoc.GetId; } }
        public DateTime FechaDesde { get { return _gFiltro.FechaDesde.GetFecha; } }
        public DateTime FechaHasta { get { return _gFiltro.FechaHasta.GetFecha; } }
        public bool LimpiarFiltrosIsOk { get { return _limpiarFiltrosIsOk; } }


        public Gestion(FiltrosGen.IAdmDoc ctrFiltro)
        {
            _limpiarFiltrosIsOk = false;

            _gFiltro = ctrFiltro;
            _gestionAnular = new Anular.Gestion();
            _gestionListaDetalle = new GestionListaDetalle();
            _gestionListaDetalle.setGestionAnular(_gestionAnular);
            LimpiarFiltros();
        }


        public void Inicializa() 
        {
            _gFiltro.Inicializa();
            _gestionListaDetalle.Inicializa();
            _limpiarFiltrosIsOk = false;
        }

        AdministradorFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new AdministradorFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            var lst = new List<ficha>();
            foreach (var rg in rt1.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gFiltro.Sucursal.setData(lst);

            var lst2 = new List<ficha>();
            lst2.Add(new ficha("1", "01", "CARGO"));
            lst2.Add(new ficha("2", "02", "DESCARGO"));
            lst2.Add(new ficha("3", "03", "TRASLADO"));
            lst2.Add(new ficha("4", "04", "AJUSTE"));
            _gFiltro.TipoDoc.setData(lst2);

            return rt;
        }

        public void Buscar()
        {
            GenerarBusqueda();
        }

        private string xfiltros;
        private void GenerarBusqueda()
        {
            if (_gFiltro.DataFiltrarIsOk())
            {
                var data = _gFiltro.DataFiltrar;
                xfiltros = "";
                var filtro = new OOB.LibInventario.Movimiento.Lista.Filtro();
                if (data.Desde.HasValue)
                {
                    filtro.Desde = data.Desde.Value.Date;
                    xfiltros += "Desde: " + data.Desde.Value.ToShortDateString();
                }
                if (data.Hasta.HasValue)
                {
                    filtro.Hasta = data.Hasta.Value.Date;
                    xfiltros += ", Hasta: " + data.Hasta.Value.ToShortDateString();
                }
                if (data.TipoDoc != null)
                {
                    switch (data.TipoDoc.codigo)
                    {
                        case "01":
                            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo;
                            xfiltros += ", Doc/Tipo: CARGO";
                            break;
                        case "02":
                            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo;
                            xfiltros += ", Doc/Tipo: DESCARGO";
                            break;
                        case "03":
                            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado;
                            xfiltros += ", Doc/Tipo: TRASLADO";
                            break;
                        case "04":
                            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste;
                            xfiltros += ", Doc/Tipo: AJUSTE";
                            break;
                    }
                }
                if (data.Sucursal != null)
                {
                    filtro.IdSucursal = data.Sucursal.codigo;
                    xfiltros += ", Sucursal: " + data.Sucursal.desc;
                }
                if (data.Producto != null)
                {
                    filtro.IdProducto = data.Producto.id;
                    xfiltros += ", Producto: " + data.Producto.desc;
                }
                if (data.DepOrigen != null)
                {
                    filtro.IdDepOrigen = data.DepOrigen.id;
                    xfiltros += ", Dep/Origen: " +data.DepOrigen.desc ;
                }
                if (data.DepDestino != null)
                {
                    filtro.IdDepDestino = data.DepDestino.id ;
                    xfiltros += ", Dep/Destino: " + data.DepDestino.desc;
                }
                if (data.Concepto!= null)
                {
                    filtro.IdConcepto = data.Concepto.id ;
                    xfiltros += ", Concepto: " + data.Concepto.desc;
                }
                if (data.Estatus != null)
                {
                    var xestatus = ", Estatus: ACTIVO";
                    filtro.Estatus = OOB.LibInventario.Movimiento.enumerados.EnumEstatus.Activo;
                    if (data.Estatus.id != "1")
                    {
                        filtro.Estatus = OOB.LibInventario.Movimiento.enumerados.EnumEstatus.Anulado;
                        xestatus = ", Estatus: ANULADO";
                    }
                    xfiltros += xestatus ;
                }
                var rt0 = Sistema.MyData.Configuracion_CantDocVisualizar();
                if (rt0.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt0.Mensaje);
                    return;
                }
                var rt1 = Sistema.MyData.Producto_Movimiento_GetLista(filtro);
                if (rt1.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt1.Mensaje);
                    return;
                }
                var lst = rt1.Lista.OrderByDescending(o => o.fecha).ThenByDescending(o => o.docNro).Take(rt0.Entidad).ToList();
                _gestionListaDetalle.setLista(lst);
            }
        }

        public void AnularItem()
        {
            _gestionListaDetalle.AnularItem();
        }

        public void LimpiarFiltros()
        {
            _gFiltro.LimpiarFiltros();
            _limpiarFiltrosIsOk = true;
        }

        public void LimpiarData()
        {
            _gestionListaDetalle.LimpiarData();
        }

        public void VisualizarDocumento()
        {
            _gestionListaDetalle.VisualizarDocumento();
        }

        public void Imprimir()
        {
            _gestionListaDetalle.Imprimir(xfiltros);
        }

        public void Filtros()
        {
            _gFiltro.Inicia();
        }

        public void VerAnulacion()
        {
            _gestionListaDetalle.VerAnulacion();
        }

        public void setGestionAuditoria(Auditoria.Visualizar.Gestion _gestionAuditoria)
        {
            _gestionListaDetalle.setGestionAuditoria(_gestionAuditoria);
        }


        public void setSucursal(string id)
        {
            _gFiltro.Sucursal.setFicha(id);
        }
        public void setTipoDoc(string id)
        {
            _gFiltro.TipoDoc.setFicha(id);
        }
        public void setFechaDesde(DateTime fecha)
        {
            _gFiltro.FechaDesde.setFecha(fecha);
        }
        public void setFechaDesdeEstatusOff()
        {
            _gFiltro.FechaDesde.setEstatusOff();
        }
        public void setFechaHasta(DateTime fecha)
        {
            _gFiltro.FechaHasta.setFecha(fecha);
        }
        public void setFechaHastaEstatusOff()
        {
            _gFiltro.FechaHasta.setEstatusOff();
        }

    }

}