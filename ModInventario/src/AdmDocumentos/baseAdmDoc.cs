using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.AdmDocumentos
{
    abstract public class baseAdmDoc : IAdmDoc
    {
        protected Utils.FiltrosPara.AdmDocumentos.IAdmDoc _admFiltroDoc;
        protected IListaAdmDoc _listaDoc;
        protected Auditoria.Visualizar.IVisualizar _auditoria;
        protected AnularDoc.IAnular _anularDoc;


        public data ItemActual { get { return (data)_listaDoc.ItemActual; } }
        public string GetTitulo { get { return "Administrador De Documentos de Inventario"; } }
        public BindingSource GetData_Source { get { return _listaDoc.GetSource; } }
        public int GetCntItems { get { return _listaDoc.GetCtnItems; } }
        public LibUtilitis.CtrlCB.ICtrl TipoDoc { get { return _admFiltroDoc.TipoDoc; } }
        public Utils.Filtros.DesdeHasta.IFiltro DesdeHasta { get { return _admFiltroDoc.DesdeHasta; } }


        abstract public void Inicia();
        abstract public void Buscar();
        abstract public void Visualizar();
        abstract public void VisualizarDocumento();
        abstract public void Imprimir();
        abstract public void AnularItem();


        virtual public void Inicializa()
        {
            _listaDoc.Inicializa();
            _admFiltroDoc.Inicializa();
            _auditoria.Inicializa();
            _anularDoc.Inicializa();
        }
        virtual protected bool CargarData()
        {
            return _admFiltroDoc.CargarData();
        }


        public void LimpiarFiltros()
        {
            _admFiltroDoc.LimpiarFiltros();
        }
        public void LimpiarData()
        {
            _listaDoc.Limpiar();
        }
        public void Filtros()
        {
            _admFiltroDoc.Inicia();
        }
        public void VerAnulacion()
        {
            _auditoria.Inicializa();
            _auditoria.setData(ItemActual);
            _auditoria.Inicia();
        }


        public void CargarVisualizarDocumento(string idMov)
        {
            var doc = CargarDocumento(idMov);
            if (doc != null)
            {
                switch (doc.docTipo)
                {
                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo:
                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo:
                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado:
                        Visualizar(doc);
                        break;
                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste:
                        VisualizarAjuste(doc);
                        break;
                }
            }
        }
        private OOB.LibInventario.Movimiento.Ver.Ficha CargarDocumento(string idMov)
        {
            try
            {
                var rt1 = Sistema.MyData.Producto_Movimiento_GetFicha(idMov);
                return rt1.Entidad;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return null;
            }
        }
        private void Visualizar(OOB.LibInventario.Movimiento.Ver.Ficha xficha)
        {
            var ficha = new Reportes.Documentos.data();
            ficha.documentoNro = xficha.documentoNro;
            ficha.fecha = xficha.fecha;
            ficha.notas = xficha.notas;
            ficha.autorizadoPor = xficha.autorizadoPor;
            ficha.depositoOrigen = xficha.depositoOrigen;
            ficha.codigoDepositoOrigen = xficha.codigoDepositoOrigen;
            ficha.depositoDestino = xficha.depositoDestino;
            ficha.codigoDepositoDestino = xficha.codigoDepositoDestino;
            ficha.tipoDocumento = xficha.tipoDocumento;
            ficha.nombreDocumento = xficha.nombreDocumento;
            ficha.codigoConcepto = xficha.codigoConcepto;
            ficha.concepto = xficha.concepto;
            ficha.estacion = xficha.estacion;
            ficha.usuario = xficha.usuario;
            ficha.usuarioCodigo = xficha.usuarioCodigo;
            ficha.estatusActivo = xficha.estatusActivo;

            var det = new List<Reportes.Documentos.dataDetalle>();
            foreach (var it in xficha.detalles)
            {
                var nr = new Reportes.Documentos.dataDetalle()
                {
                    cantidad = it.cantidad,
                    codigo = it.codigo,
                    costoUnd = it.costoUnd,
                    descripcion = it.descripcion,
                    importe = it.importe,
                    signo = 1,
                    cantidadUnd = it.cantidadUnd,
                    contenido = it.contenido,
                    empaque = it.empaque,
                    esUnidad = it.esUnidad,
                };
                det.Add(nr);
            };
            ficha.detalles = det;

            var rp1 = new Reportes.Documentos.Movimiento(ficha);
            rp1.Generar();
        }
        private void VisualizarAjuste(OOB.LibInventario.Movimiento.Ver.Ficha xficha)
        {
            var ficha = new Reportes.Documentos.data();
            ficha.documentoNro = xficha.documentoNro;
            ficha.fecha = xficha.fecha;
            ficha.notas = xficha.notas;
            ficha.autorizadoPor = xficha.autorizadoPor;
            ficha.depositoOrigen = xficha.depositoOrigen;
            ficha.codigoDepositoOrigen = xficha.codigoDepositoOrigen;
            ficha.depositoDestino = xficha.depositoDestino;
            ficha.codigoDepositoDestino = xficha.codigoDepositoDestino;
            ficha.tipoDocumento = xficha.tipoDocumento;
            ficha.nombreDocumento = xficha.nombreDocumento;
            ficha.codigoConcepto = xficha.codigoConcepto;
            ficha.concepto = xficha.concepto;
            ficha.estacion = xficha.estacion;
            ficha.usuario = xficha.usuario;
            ficha.usuarioCodigo = xficha.usuarioCodigo;
            ficha.estatusActivo = xficha.estatusActivo;

            var det = new List<Reportes.Documentos.dataDetalle>();
            foreach (var it in xficha.detalles)
            {
                var nr = new Reportes.Documentos.dataDetalle()
                {
                    cantidad = it.cantidad,
                    codigo = it.codigo,
                    costoUnd = it.costoUnd,
                    descripcion = it.descripcion,
                    importe = it.importe,
                    signo = it.signo,
                    cantidadUnd = it.cantidadUnd,
                    contenido = it.contenido,
                    empaque = it.empaque,
                    esUnidad = it.esUnidad,
                    decimales = it.decimales,
                };
                det.Add(nr);
            };
            ficha.detalles = det;

            var rp1 = new Reportes.Documentos.Movimiento(ficha);
            rp1.Generar();
        }
        public void AnularCargo(string idDoc, string motivo)
        {
            try
            {
                var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.CARGO);
                var ficha = new OOB.LibInventario.Movimiento.Anular.Cargo.Ficha()
                {
                    autoDocumento = idDoc,
                    autoSistemaDocumento = r00.Entidad.autoId,
                    autoUsuario = Sistema.UsuarioP.autoUsu,
                    codigoUsuario = Sistema.UsuarioP.codigoUsu,
                    estacion = Environment.MachineName,
                    motivo = motivo,
                    nombreUsuario = Sistema.UsuarioP.nombreUsu,
                };
                var r01 = Sistema.MyData.Producto_Movimiento_Cargo_Anular(ficha);
                _listaDoc.setEstatusAnulado(idDoc);
                Helpers.Msg.EliminarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void AnularDescargo(string idDoc, string motivo)
        {
            try
            {
                var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.DESCARGO);
                var ficha = new OOB.LibInventario.Movimiento.Anular.Descargo.Ficha()
                {
                    autoDocumento = idDoc,
                    autoSistemaDocumento = r00.Entidad.autoId,
                    autoUsuario = Sistema.UsuarioP.autoUsu,
                    codigoUsuario = Sistema.UsuarioP.codigoUsu,
                    estacion = Environment.MachineName,
                    motivo = motivo,
                    nombreUsuario = Sistema.UsuarioP.nombreUsu,
                };
                var r01 = Sistema.MyData.Producto_Movimiento_Descargo_Anular(ficha);
                _listaDoc.setEstatusAnulado(idDoc);
                Helpers.Msg.EliminarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void AnularTraslado(string idDoc, string motivo)
        {
            try
            {
                var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO);
                var ficha = new OOB.LibInventario.Movimiento.Anular.Traslado.Ficha()
                {
                    autoDocumento = idDoc,
                    autoSistemaDocumento = r00.Entidad.autoId,
                    autoUsuario = Sistema.UsuarioP.autoUsu,
                    codigoUsuario = Sistema.UsuarioP.codigoUsu,
                    estacion = Environment.MachineName,
                    motivo = motivo,
                    nombreUsuario = Sistema.UsuarioP.nombreUsu,
                };
                var r01 = Sistema.MyData.Producto_Movimiento_Traslado_Anular(ficha);
                _listaDoc.setEstatusAnulado(idDoc);
                Helpers.Msg.EliminarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void AnularAjuste(string idDoc, string motivo)
        {
            try
            {
                var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.AJUSTE);
                var ficha = new OOB.LibInventario.Movimiento.Anular.Ajuste.Ficha()
                {
                    autoDocumento = idDoc,
                    autoSistemaDocumento = r00.Entidad.autoId,
                    autoUsuario = Sistema.UsuarioP.autoUsu,
                    codigoUsuario = Sistema.UsuarioP.codigoUsu,
                    estacion = Environment.MachineName,
                    motivo = motivo,
                    nombreUsuario = Sistema.UsuarioP.nombreUsu,
                };
                var r01 = Sistema.MyData.Producto_Movimiento_Ajuste_Anular(ficha);
                _listaDoc.setEstatusAnulado(idDoc);
                Helpers.Msg.EliminarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}