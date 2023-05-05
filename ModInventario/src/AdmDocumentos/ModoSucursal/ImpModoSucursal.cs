using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.AdmDocumentos.ModoSucursal
{

    public class ImpModoSucursal: baseAdmDoc, ISucursal
    {
        public LibUtilitis.CtrlCB.ICtrl Sucursal { get { return _admFiltroDoc.Sucursal; } }
        

        public ImpModoSucursal(
            Utils.FiltrosPara.AdmDocumentos.IAdmDoc filtroAdmDoc,
            IListaAdmDoc listaAdmDoc,
            Auditoria.Visualizar.IVisualizar auditoria, 
            ModInventario.src.AnularDoc.IAnular anularDoc)
        {
            _admFiltroDoc = filtroAdmDoc;
            _listaDoc = listaAdmDoc;
            _auditoria = auditoria;
            _anularDoc = anularDoc;
        }


        public override void Inicializa()
        {
            base.Inicializa();
        }
        AdministradorFrm frm;
        public override void Inicia()
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
        public override void Buscar()
        {
            _filtrosBusq = "";
            RealizarCargarBusqueda();
        }
        public override void AnularItem()
        {
            if (ItemActual != null)
            {
                if (!ItemActual.IsAnulado)
                    Anular();
                else
                    Helpers.Msg.Error("DOCUMENTO YA SE ENCUENTRA ANULADO" + Environment.NewLine + "Verifique Por Favor");
            }
        }
        public override void Imprimir()
        {
            ImprimirLIstaDoc(_filtrosBusq);
        }
        public override void Visualizar()
        {
            if (ItemActual != null)
            {
                try
                {
                    var r00 = Sistema.MyData.Permiso_AdmVisualizarMovimientoInventario(Sistema.UsuarioP.autoGru);
                    if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                    {
                        if (ItemActual.IsAnulado)
                            VerAnulacion();
                        else
                            CargarVisualizarDocumento(ItemActual.Id);
                    }
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public override void VisualizarDocumento()
        {
            if (ItemActual != null)
            {
                try
                {
                    var r00 = Sistema.MyData.Permiso_AdmVisualizarMovimientoInventario(Sistema.UsuarioP.autoGru);
                    if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                    {
                        CargarVisualizarDocumento(ItemActual.Id);
                    }
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }


        private void RealizarCargarBusqueda()
        {
            _listaDoc.setLista(RealizarBusqueda());
        }
        private string _filtrosBusq;
        private List<OOB.LibInventario.Movimiento.Lista.Ficha> RealizarBusqueda()
        {
            var lst = new List<OOB.LibInventario.Movimiento.Lista.Ficha>();
            if (_admFiltroDoc.DataExportar.IsOk)
            {
                var _dataFiltrar = _admFiltroDoc.DataExportar;
                _filtrosBusq = _dataFiltrar.FiltrosDescripcion;
                var filtro = new OOB.LibInventario.Movimiento.Lista.Filtro()
                {
                    Desde = _dataFiltrar.Desde,
                    Hasta = _dataFiltrar.Hasta,
                    IdConcepto = _dataFiltrar.Concepto == null ? "" : _dataFiltrar.Concepto.id,
                    IdDepDestino = _dataFiltrar.DepDestino == null ? "" : _dataFiltrar.DepDestino.id,
                    IdDepOrigen = _dataFiltrar.DepOrigen == null ? "" : _dataFiltrar.DepOrigen.id,
                    IdProducto = _dataFiltrar.Producto == null ? "" : _dataFiltrar.Producto.id,
                    CodigoSucursal = _dataFiltrar.Sucursal == null ? "" : _dataFiltrar.Sucursal.codigo,
                };
                if (_dataFiltrar.TipoDoc != null) 
                {
                    switch (_dataFiltrar.TipoDoc.desc.Trim().ToUpper())
                    {
                        case "CARGO":
                            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo;
                            break;
                        case "DESCARGO":
                            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo;
                            break;
                        case "TRASLADO":
                            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado;
                            break;
                        case "AJUSTE":
                            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste;
                            break;
                    }
                }
                if (_dataFiltrar.Estatus != null)
                {
                    switch (_dataFiltrar.Estatus.desc.Trim().ToUpper())
                    {
                        case "ACTIVO":
                            filtro.Estatus = OOB.LibInventario.Movimiento.enumerados.EnumEstatus.Activo;
                            break;
                        case "ANULADO":
                            filtro.Estatus = OOB.LibInventario.Movimiento.enumerados.EnumEstatus.Anulado;
                            break;
                    }
                }
                lst = aplicarBusqueda(filtro);
            }
            return lst;
        }

        private void Anular()
        {
            try
            {
                var r00 = Sistema.MyData.Permiso_AdmAnularMovimientoInventario(Sistema.UsuarioP.autoGru);
                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    _anularDoc.Inicializa();
                    _anularDoc.Inicia();
                    if (_anularDoc.AnularIsOK)
                    {
                        switch (ItemActual.TipoDocumento)
                        {
                            case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo:
                                AnularCargo(ItemActual.Id, _anularDoc.GetMotivo_Desc);
                                break;
                            case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo:
                                AnularDescargo(ItemActual.Id, _anularDoc.GetMotivo_Desc);
                                break;
                            case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado:
                                AnularTraslado(ItemActual.Id, _anularDoc.GetMotivo_Desc);
                                break;
                            case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste:
                                AnularAjuste(ItemActual.Id, _anularDoc.GetMotivo_Desc);
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void ImprimirLIstaDoc(string xfiltros)
        {
            try
            {
                var r00 = Sistema.MyData.Permiso_AdmReporteMovimientoInventario(Sistema.UsuarioP.autoGru);
                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    var _lst = (List<data>)_listaDoc.GetListaItems;
                    if (_lst.Count > 0)
                    {
                        var data = new List<Reportes.Movimientos.data>();
                        foreach (var rg in _lst)
                        {
                            var nr = new Reportes.Movimientos.data()
                            {
                                documentoNro = rg.DocumentoNro,
                                concepto = rg.Concepto,
                                fechaHora = rg.FechaHora,
                                importe = rg.MontoDoc,
                                isAnulado = rg.IsAnulado,
                                nombreDocumento = rg.STipoDoc,
                                renglones = rg.SRenglones,
                                situacion = rg.Situacion,
                                sucursal = rg.Sucursal,
                                usuarioEstacion = rg.UsuarioEstacion,
                            };
                            data.Add(nr);
                        }
                        var rp = new Reportes.Movimientos.gestionRep(data, xfiltros);
                        rp.Generar();
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        virtual protected List<OOB.LibInventario.Movimiento.Lista.Ficha> 
            aplicarBusqueda(OOB.LibInventario.Movimiento.Lista.Filtro filtro)
        {
            var lst = new List<OOB.LibInventario.Movimiento.Lista.Ficha>();
            try
            {
                var rt0 = Sistema.MyData.Configuracion_CantDocVisualizar();
                var rt1 = Sistema.MyData.Producto_Movimiento_GetLista(filtro);
                lst = rt1.Lista.OrderByDescending(o => o.fecha).ThenByDescending(o => o.docNro).Take(rt0.Entidad).ToList();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            return lst;
        }
    }
}