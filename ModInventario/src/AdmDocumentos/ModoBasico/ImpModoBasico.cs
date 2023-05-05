using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.AdmDocumentos.ModoBasico
{

    public class ImpModoBasico : baseAdmDoc, IBasico
    {

        public ImpModoBasico(
            IListaAdmDoc listaAdmDoc,
            Auditoria.Visualizar.IVisualizar auditoria, 
            ModInventario.src.AnularDoc.IAnular anularDoc)
        {
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
            // NO SE IMPLEMENTA
        }
        public override void Visualizar()
        {
            if (ItemActual != null)
            {
                if (ItemActual.IsAnulado)
                    VerAnulacion();
                else
                    CargarVisualizarDocumento(ItemActual.Id);
            }
        }
        public override void VisualizarDocumento()
        {
            if (ItemActual != null)
            {
                CargarVisualizarDocumento(ItemActual.Id);
            }
        }


        private void RealizarCargarBusqueda()
        {
            _listaDoc.setLista(RealizarBusqueda());
        }
        private List<OOB.LibInventario.Movimiento.Lista.Ficha> RealizarBusqueda()
        {
            if (_admFiltroDoc.DataExportar.IsOk)
            {
            }
            var lst = new List<OOB.LibInventario.Movimiento.Lista.Ficha>();
            //var _dataFiltrar = _admFiltroDoc.ExportarData();
            //if (_dataFiltrar.IsOk())
            //{
            //    var _estatus = _dataFiltrar.GetEstatus_Desc;
            //    var _tipoDocumento = _dataFiltrar.GetTipoDoc_Desc;
            //    var filtro = new OOB.LibInventario.Movimiento.Lista.Filtro()
            //    {
            //        Desde = _dataFiltrar.Desde,
            //        Hasta = _dataFiltrar.Hasta,
            //        IdConcepto = _dataFiltrar.GetConcepto_Id,
            //        IdDepDestino = _dataFiltrar.GetDepDestino_Id,
            //        IdDepOrigen = _dataFiltrar.GetDepOrigen_Id,
            //        IdProducto = _dataFiltrar.GetProducto_Id,
            //        CodigoSucursal= _dataFiltrar.GetSucursal_Codigo,
            //    };
            //    switch (_dataFiltrar.GetTipoDoc_Desc)
            //    {
            //        case "CARGO":
            //            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo;
            //            break;
            //        case "DESCARGO":
            //            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo;
            //            break;
            //        case "TRASLADO":
            //            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado;
            //            break;
            //        case "AJUSTE":
            //            filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste;
            //            break;
            //    }
            //    switch (_dataFiltrar.GetEstatus_Desc)
            //    {
            //        case "ACTIVO":
            //            filtro.Estatus = OOB.LibInventario.Movimiento.enumerados.EnumEstatus.Activo;
            //            break;
            //        case "ANULADO":
            //            filtro.Estatus = OOB.LibInventario.Movimiento.enumerados.EnumEstatus.Anulado;
            //            break;
            //    }
            //    try
            //    {
            //        var rt0 = Sistema.MyData.Configuracion_CantDocVisualizar();
            //        var rt1 = Sistema.MyData.Producto_Movimiento_GetLista(filtro);
            //        lst = rt1.Lista.OrderByDescending(o => o.fecha).ThenByDescending(o => o.docNro).Take(rt0.Entidad).ToList();
            //    }
            //    catch (Exception e)
            //    {
            //        Helpers.Msg.Error(e.Message);
            //    }
            //}
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
    }
}