using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.AdmMovPend
{
    
    public class AdmMovPend: IAdmMovPend 
    {

        private IListaAdm _gLista;
        private bool _eliminarIsOk;
        private bool _limpiarFiltrosIsOk;
        private ModInventario.MovimientoInvTipo.ITipo _gTraslxNivel;
        private ModInventario.MovimientoInvTipo.ITipoxDev _gTrasl;
        private ModInventario.MovimientoInvTipo.IGestionTipo _gMov;
        private ISeguridadAccesoSistema _seguridad;
        private ModInventario.MovimientoInvTipo.ITipo _gAjuste;
        private IOpcion _gTipoDoc;


        public string GetTitulo { get { return "Administrador Movimientos Pendientes"; } }
        public BindingSource GetSource { get { return _gLista.Source; } }
        public int GetCntItems { get { return _gLista.CntItems; } }
        public dataItem ItemActual { get { return (dataItem)_gLista.ItemActual; } }
        public bool AnularIsOk { get { return _eliminarIsOk; } }
        public bool LimpiarFiltrosIsOk { get { return _limpiarFiltrosIsOk; } }
        public BindingSource TipoDocSource { get { return _gTipoDoc.Source; } }
        public string TipoDocID { get { return _gTipoDoc.GetId; } }


        public AdmMovPend(
            IListaAdm lista, 
            ModInventario.MovimientoInvTipo.IGestionTipo tipoMov,
            ISeguridadAccesoSistema accesoSist 
            )
        {
            _eliminarIsOk = false;
            _limpiarFiltrosIsOk = false;
            _gLista = lista;
            _gMov = tipoMov;
            _seguridad= accesoSist;
            _gTipoDoc = new ModInventario.FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _eliminarIsOk = false;
            _limpiarFiltrosIsOk = false;
            _gLista.Inicializa();
            _gTipoDoc.Inicializa();

        }
        private AdmMovPendFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AdmMovPendFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void ActAnular()
        {
            AnularItem();
        }
        public void ActLimpiar()
        {
            LimpiarItems();
        }
        public void ActVisualizar()
        {
        }
        public void ActImprimir()
        {
            Reporte();
        }
        public void ActFiltrar()
        {
        }
        public void ActBuscar()
        {
            Buscar();
        }


        public void GenerarMov()
        {
            GenerarMovimiento();
        }

        public void setMovTrasladoxNivel(MovimientoInvTipo.ITipo mTraslxNivel)
        {
            _gTraslxNivel = mTraslxNivel;
        }
        public void setMovTraslado(MovimientoInvTipo.ITipoxDev mTraslado)
        {
            _gTrasl = mTraslado;
        }
        public void setMovAjuste(MovimientoInvTipo.ITipo mAjuste)
        {
            _gAjuste = mAjuste;
        }
        public void LimpiarFiltros()
        {
            _gTipoDoc.Limpiar();
            _limpiarFiltrosIsOk = true;
        }
        public void setTipoDoc(string id)
        {
            _gTipoDoc.setFicha(id);
        }


        private bool CargarData()
        {
            var lst = new List<ficha>();
            lst.Add(new ficha("03", "", "TRASLADO"));
            lst.Add(new ficha("04", "", "AJUSTE"));
            _gTipoDoc.setData(lst);
            return true;
        }
        private void Buscar()
        {
            var filtros = new OOB.LibInventario.MovPend.Lista.Filtro();
            filtros.codMovimiento  = _gTipoDoc.GetId;
            var r01 = Sistema.MyData.MovPendiente_GetLista(filtros);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var _lst = r01.Lista.Select(s =>
            {
                var nr = new dataItem()
                {
                    cntRenglones = s.cntRenglones,
                    fecha = s.fecha,
                    id = s.id,
                    monto = s.monto,
                    montoDivisa = s.montoDivisa,
                    origen = s.sucOrigen.Trim() == "" ? s.depOrigen : s.sucOrigen.Trim(),
                    destino = s.sucDestino.Trim() == "" ? s.depDestino : s.sucDestino.Trim(),
                    tipoDoc = s.MovimientoDesc,
                    usuarioEstacion = s.usuario,
                    codigoMov = s.codigoMov,
                    tipoMov = s.tipoMov,
                };
                return nr;
            }).ToList();
            _gLista.ActAgregarListaItem(_lst);
        }
        private void LimpiarItems()
        {
            _gLista.ActLimpiarLista();
        }
        private void AnularItem()
        {
            _eliminarIsOk = false;
            if (ItemActual != null) 
            {
                var xmsg="Deseas Anular Movimiento En Pendiente ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var r01 = Sistema.MyData.MovPendiente_Anular(ItemActual.id);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _eliminarIsOk = true;
                    _gLista.ActEliminarItem(ItemActual.id);
                }
            }
        }
        private void Reporte()
        {
            if (_gLista.CntItems > 0)
            {
                var rp = new Reportes.MovPend.gestionRep(_gLista.Items, "");
                rp.Generar();
            }
        }
        private void GenerarMovimiento()
        {
            if (ItemActual != null)
            {
                switch (ItemActual.codigoMov)
                { 
                    case "03":
                        switch (ItemActual.tipoMov) 
                        {
                            case "1":
                                CargarTralasdo(ItemActual);
                                break;
                            case "2":
                                CargarTralasdoxDevolucion(ItemActual);
                                break;
                            case "3":
                                CargarTralasdoxNivelMinimo(ItemActual);
                                break;
                        }
                        break;
                    case "04":
                        CargarAjuste(ItemActual);
                        break;
                }
                Buscar();
            }
        }
        private void CargarAjuste(dataItem ItemActual)
        {
            var r00 = Sistema.MyData.Permiso_MovimientoAjusteInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gAjuste.Inicializa();
                CargarMov(_gAjuste, ItemActual.id);
            }
        }
        private void CargarTralasdoxNivelMinimo(dataItem ItemActual)
        {
            var r00 = Sistema.MyData.Permiso_MovimientoTrasladoEntreSucursales_PorExistenciaDebajoDelMinimo(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gTraslxNivel.Inicializa();
                CargarMov(_gTraslxNivel, ItemActual.id);
            }
        }
        private void CargarTralasdoxDevolucion(dataItem ItemActual)
        {
            var r00 = Sistema.MyData.Permiso_MovimientoTrasladoPorDevolucion(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gTrasl.Inicializa();
                _gTrasl.setActivarPorDevolucion(true);
                CargarMov(_gTrasl, ItemActual.id);
            }
        }
        private void CargarTralasdo(dataItem ItemActual)
        {
            var r00 = Sistema.MyData.Permiso_MovimientoTrasladoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gTrasl.Inicializa();
                _gTrasl.setActivarPorDevolucion(false);
                CargarMov(_gTrasl, ItemActual.id);
            }
        }
        private void CargarMov(MovimientoInvTipo.ITipo mov, int idMov)
        {
            _gMov.Inicializa();
            _gMov.setTipoMov(mov);
            _gMov.IniciaConPendiente(idMov);
            _gMov.Finaliza();
        }

    }

}