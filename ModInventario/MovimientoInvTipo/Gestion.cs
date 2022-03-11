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
        private ITipo _gTipo;
        private ILista _gLista;
        private ModInventario.FiltrosGen.IAdmSelecciona _gBusqPrd;


        public string TipoMovimiento { get { return _gTipo.TipoMovimiento; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource ConceptoSource { get { return _gTipo.ConceptoSource; } }
        public BindingSource SucursalSource { get { return _gTipo.SucursalSource; } }
        public BindingSource DepOrigenSource{ get { return _gTipo.DepOrigenSource; } }
        public BindingSource DepDestinoSource { get { return null; } }
        public string Motivo { get { return _gTipo.Motivo; } }
        public string AutorizadoPor { get { return _gTipo.AutorizadoPor; } }
        public DateTime FechaSistema { get { return _fechaSistema; } }
        public string ConceptoGetId { get { return _gTipo.ConceptoGetId; } }
        public string SucursalGetId { get { return _gTipo.SucursalGetId; } }
        public string DepOrigenGetID { get { return _gTipo.DepOrigenGetID; } }
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
                _gTipo.BuscarIdPrd(_gBusqPrd.ItemSeleccionado.id);
                if (_gTipo.IsOk)
                {
                    _busquedaIsOk = true;
                    dataItem item = _gTipo.ItemAgregar;
                    _gLista.setItemAgregar(item);
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
                    _gLista.setItemEliminar(idItemEditar);
                    dataItem item = _gTipo.ItemAgregar;
                    _gLista.setItemAgregar(item);
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

    }

}