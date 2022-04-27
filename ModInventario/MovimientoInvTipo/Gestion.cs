using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo
{

    public class Gestion: IGestionTipo
    {

        private bool _abandonarIsOk;
        private DateTime _fechaSistema;
        private bool _busquedaIsOk;
        private bool _limpiarIsOk;
        private bool _eliminarIsOk;
        private bool _editarIsOk;
        private bool _eliminarExistenciaNoDisponibleIsOk;
        private ITipo _gTipo;
        private ILista _gLista;
        private ModInventario.FiltrosGen.IAdmSelecciona _gBusqPrd;


        public string TipoMovimiento { get { return _gTipo.TipoMovimiento; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource ConceptoSource { get { return _gTipo.ConceptoSource; } }
        public BindingSource SucursalSource { get { return _gTipo.SucursalSource; } }
        public BindingSource DepOrigenSource{ get { return _gTipo.DepOrigenSource; } }
        public BindingSource DepDestinoSource { get { return _gTipo.DepDestinoSource; } }
        public BindingSource DepartamentoSource { get { return _gTipo.DepatamentoSource; } }
        public string Motivo { get { return _gTipo.Motivo; } }
        public string AutorizadoPor { get { return _gTipo.AutorizadoPor; } }
        public DateTime FechaSistema { get { return _fechaSistema; } }
        public string ConceptoGetId { get { return _gTipo.ConceptoGetId; } }
        public string SucursalGetId { get { return _gTipo.SucursalGetId; } }
        public string DepOrigenGetID { get { return _gTipo.DepOrigenGetID; } }
        public string DepDestinoGetID { get { return _gTipo.DepDestinoGetID; } }
        public string DepartamentoGetId { get { return _gTipo.DepartamentoGetId; } }
        public bool HabilitarCambio { get { return _gLista.CntItem==0; } }
        public enumerados.enumMetBusquedaPrd MetBusqPrd { get { return (enumerados.enumMetBusquedaPrd)_gBusqPrd.MetBusqueda; } }
        public bool BusquedaIsOk { get { return _busquedaIsOk; } }


        public dataItem ItemActual { get { return _gLista.ItemActual; } }
        public BindingSource ItemSource { get { return _gLista.Source; } }
        public decimal TotalImporte { get { return _gLista.TotalImporte; } }
        public int CntItems { get { return _gLista.CntItem; } }
        public bool EliminarIsOk { get { return _eliminarIsOk; } }
        public bool EditarIsOk { get { return _editarIsOk; } }
        public bool ProcesarDocIsOk { get { return _gTipo.ProcesarDocIsOk; } }


        public Gestion(
            ILista ctrLista,
            ModInventario.FiltrosGen.IAdmSelecciona ctrBusPrd)
        {
            _gLista = ctrLista;
            _gBusqPrd = ctrBusPrd;
            _abandonarIsOk = false;
            _busquedaIsOk = false;
            _limpiarIsOk = false;
            _eliminarIsOk = false;
            _editarIsOk = false;
            _eliminarExistenciaNoDisponibleIsOk = false;
        }


        public void Inicializa()
        {
            _gLista.Inicializa();
            _gBusqPrd.Inicializa();
            _abandonarIsOk = false;
            _busquedaIsOk = false;
            _limpiarIsOk = false;
            _eliminarIsOk = false;
            _editarIsOk = false;
            _eliminarExistenciaNoDisponibleIsOk=false;
        }

        public void Inicia()
        {
            if (CargarData()) 
            {
                _gTipo.Inicia(this);
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.FechaServidor();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _fechaSistema = r01.Entidad.Date;

            var r02 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            switch (r02.Entidad) 
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorCodigo:
                    _gBusqPrd.setMetBusqByCodigo();
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorNombre:
                    _gBusqPrd.setMetBusqByNombre();
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorReferencia:
                    _gBusqPrd.setMetBusqByReferencia();
                    break;
            }
            if (_gTipo.CargarData()) 
            {
                return true;
            }

            return false;
        }

        public void setTipoMov(ITipo ctrTipo)
        {
            _gTipo = ctrTipo;
        }

        public void Finaliza()
        {
        }

        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
                _abandonarIsOk = true;
        }


        public void setAutorizadoPor(string p)
        {
            _gTipo.setAutorizadoPor(p);
        }
        public void setMotivo(string p)
        {
            _gTipo.setMotivo(p);
        }
        public void setSucursal(string id)
        {
            _gTipo.setSucursal(id);
        }
        public void setConcepto(string id)
        {
            _gTipo.setConcepto(id);
        }
        public void setDepOrigen(string id)
        {
            _gTipo.setDepOrigen(id);
        }
        public void setDepDestino(string id)
        {
            _gTipo.setDepDestino(id);
        }
        public void setDepartamento(string id)
        {
            _gTipo.setDepartamento(id);
        }


        public void setCadenaBusqueda(string p)
        {
            _gBusqPrd.setCadenaBusq(p);
        }
        public void setMetBusqRef()
        {
            _gBusqPrd.setMetBusqByReferencia();
        }
        public void setMetBusqNombre()
        {
            _gBusqPrd.setMetBusqByNombre();
        }
        public void setMetBusqCodigo()
        {
            _gBusqPrd.setMetBusqByCodigo();
        }
        public void FiltrarBusqPrd()
        {
            _gBusqPrd.Inicia();
        }
        public void BuscarProducto()
        {
            _gBusqPrd.NotificarSeleccion += _gBusqPrd_NotificarSeleccion;
            _gBusqPrd.BuscarSeleccionar();
            _gBusqPrd.NotificarSeleccion -= _gBusqPrd_NotificarSeleccion;
        }

        private void _gBusqPrd_NotificarSeleccion(object sender, EventArgs e)
        {
            _busquedaIsOk = false;
            if (_gBusqPrd.ItemSeleccionadoIsOk)
            {
                var _agregar = true;
                if (_gLista.EncuentraItemPrd(_gBusqPrd.ItemSeleccionado.id))
                {
                    var xmsg = "Producto Ya Aparece Registrado En La Lista, "+ Environment.NewLine +"Deseas Agregar Uno Nuevo ?";
                    var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.No)
                    {
                        _agregar = false;
                    }
                }
                if (_agregar)
                {
                    _gTipo.BuscarIdPrd(_gBusqPrd.ItemSeleccionado.id);
                    if (_gTipo.IsOk)
                    {
                        _busquedaIsOk = true;
                        _gLista.setItemAgregar(_gTipo.ItemAgregar);
                    }
                }
            }
        }

        public void EliminarItem()
        {
            _eliminarIsOk = false;
            if (ItemActual != null) 
            {
                var xmsg = "Eliminar Item ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    _eliminarIsOk = true;
                    _gLista.setItemEliminar(ItemActual.Id);
                }
            }
        }

        public bool LimpiarIsOk { get { return _limpiarIsOk; } }
        public void Limpiar()
        {
            _limpiarIsOk = false;
            var xmsg = "Desechar Cambios Al Documento Actual ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _limpiarIsOk = true;
                _gTipo.Limpiar();
                _gLista.Limpiar();
                NuevoDocumento();
            }
        }

        public void EditarItem()
        {
            _editarIsOk = false;
            if (ItemActual != null)
            {
                var idItemEditar = ItemActual.Id;
                _gTipo.EditarItem(ItemActual);
                if (_gTipo.IsOk)
                {
                    _gLista.setActualizarItem(idItemEditar, _gTipo.ItemAgregar);
                    _editarIsOk = true;
                }
            }
        }


        public void ConceptoMaestro()
        {
            _gTipo.ConceptoMaestro();
        }


        public void Procesar()
        {
            if (_gLista.CntItem == 0) 
            {
                Helpers.Msg.Alerta("NO HAY ITEMS QUE PROCESAR");
                return;
            }

            _gTipo.ProcesarDoc(_gLista.Items, TotalImporte);
            if (_gTipo.ProcesarDocIsOk)
            {
                var IdDocGenerado = _gTipo.IdDocumentoGenerado;
                _gTipo.Limpiar();
                _gLista.Limpiar();
                Helpers.VisualizarDocumento.CargarVisualizarDocumento(IdDocGenerado);
            }
        }


        public void CapturarDataAplicarAjusteInvCero()
        {
            _gTipo.CapturarDataAplicarAjusteInvCero();
            if (_gTipo.CapturarDataAplicarAjusteInvCeroIsOk)
            {
               _gLista.setListaAgregar(_gTipo.ListaItemAplicarAjusteInvCero);
            }
        }
        public bool CapturarDataAplicarAjusteInvCeroIsOk
        {
            get { return _gTipo.CapturarDataAplicarAjusteInvCeroIsOk; }
        }


        public void CapturarProductosConNivelMinimo()
        {
            if (!HabilitarCambio)
            {
                Helpers.Msg.Alerta("EXISTEN ITEMS YA DESPLEGADOS");
                return;
            }

            _gTipo.CapturarProductosConNivelMinimo();
            if (_gTipo.CapturarProductosConNivelMinimoIsOk)
            {
                _gLista.setListaAgregar(_gTipo.ListaItemNivelMinimo);
            }
        }
        public bool CapturarProductosConNivelMinimoIsOk
        {
            get { return _gTipo.CapturarProductosConNivelMinimoIsOk; }
        }
        public void EliminarExistenciaNoDisponible()
        {
            _eliminarExistenciaNoDisponibleIsOk = false;
            _gLista.setEliminarExistenciaNoDisponible();
            _eliminarExistenciaNoDisponibleIsOk=true;
        }
        public bool EliminarExistenciaNoDisponibleIsOk
        {
            get { return _eliminarExistenciaNoDisponibleIsOk; }
        }


        public void NuevoDocumento()
        {
            _gTipo.NuevoDocumento();
        }


        public bool DejarEnPendienteIsOk { get { return _gTipo.DejarEnPendienteIsOk; } }
        public int DocPendientes { get { return _gTipo.DocPendientes; } }
        public bool ListaDocPendientesIsOk { get { return _gTipo.ItemTransitoIsOk; } }
        public void DejarEnPendiente()
        {
            if (_gLista.CntItem == 0)
            {
                Helpers.Msg.Alerta("NO HAY ITEMS QUE PROCESAR");
                return;
            }
            _gTipo.DejarEnPendiente(_gLista.Items, TotalImporte);
            if (_gTipo.DejarEnPendienteIsOk)
            {
                _gTipo.Limpiar();
                _gLista.Limpiar();
            }
        }
        public void ListaDocPendientes()
        {
            _gTipo.ListaDocPendientes();
            if (_gTipo.ItemTransitoIsOk) 
            {
                if (_gLista.CntItem > 0)
                {
                    Helpers.Msg.Alerta("HAY ITEMS CARGADOS EN EL MOVIMIENTO ACTUAL");
                    return;
                }
                _gLista.setListaAgregar(_gTipo.LoadTransito());
                _gTipo.AnularTransito();
            };
        }

        public void CargarDocumentoPend(int idMovPend)
        {
            _gTipo.CargarDocPendiente(idMovPend);
            if (_gTipo.ItemTransitoIsOk)
            {
                if (_gLista.CntItem > 0)
                {
                    Helpers.Msg.Alerta("HAY ITEMS CARGADOS EN EL MOVIMIENTO ACTUAL");
                    return;
                }
                _gLista.setListaAgregar(_gTipo.LoadTransito());
                _gTipo.AnularTransito();
            };
        }

        public void IniciaConPendiente(int idMov)
        {
            if (CargarData())
            {
                var lst = _gTipo.LoadTransito(idMov);
                if (lst != null) 
                {
                    _gLista.setListaAgregar(lst);
                    _gTipo.AnularTransito(idMov);
                    _gTipo.Inicia(this);
                }
            }
        }

        public string GetIdDepOrigen { get { return _gTipo.GetIdDepOrigen; } }
        public string GetIdDepDestino { get { return _gTipo.GetIdDepDestino; } }
        public void setActivarBusquedaParaTraslado()
        {
            _gBusqPrd.setActivarBusquedaParaTraslado();
        }
        public void setActivarDepOrigen(string id)
        {
            _gBusqPrd.setActivarDepOrigen(id);
        }
        public void setActivarDepDestino(string id)
        {
            _gBusqPrd.setActivarDepDestino(id);
        }

    }

}