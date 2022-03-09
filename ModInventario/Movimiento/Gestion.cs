using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento
{

    public class Gestion
    {


        public enum enumMetBusq { SinDefinir = -1, PorCodgo = 1, PorNombre, PorReferencia };


        private IGestion miGestion;
        private FiltrosGen.IAdmSelecciona _gAdmSelPrd;
        private Helpers.Maestros.ICallMaestros _callMaestros;


        public enumerados.enumTipoMovimiento EnumTipoMovimiento { get { return miGestion.EnumTipoMovimiento; } }
        public bool IsCerrarOk { get { return miGestion.IsCerrarOk; } }
        public string TipoMovimiento { get { return miGestion.TipoMovimiento; } }
        public decimal MontoMovimiento { get { return miGestion.MontoMovimiento; } }
        public string ItemsMovimiento { get { return miGestion.ItemsMovimiento; } }
        public bool Habilitar_DepDestino { get { return miGestion.Habilitar_DepDestino; } }
        public bool VisualizarColumnaTipoMovimiento { get { return miGestion.VisualizarColumnaTipoMovimiento; } }
        public BindingSource ConceptoSource { get { return miGestion.ConceptoSource; } }
        public BindingSource SucursalSource { get { return miGestion.SucursalSource; } }
        public BindingSource DepOrigenSource { get { return miGestion.DepOrigenSource; } }
        public BindingSource DepDestinoSource { get { return miGestion.DepDestinoSource; } }
        public BindingSource DetalleSource { get { return miGestion.DetalleSouce; } }
        public string IdSucursal { get { return miGestion.IdSucursal; } set { miGestion.IdSucursal = value; } }
        public string IdConcepto { get { return miGestion.IdConcepto; } set { miGestion.IdConcepto = value; } }
        public string IdDepOrigen { get { return miGestion.IdDepOrigen; } set { miGestion.IdDepOrigen = value; } }
        public string IdDepDestino { get { return miGestion.IdDepDestino; } set { miGestion.IdDepDestino = value; } }
        public string AutorizadoPor { get { return miGestion.AutorizadoPor; } set { miGestion.AutorizadoPor = value; }  }
        public string Motivo { get { return miGestion.Motivo ; } set { miGestion.Motivo = value; } }
        public DateTime FechaMov { get { return miGestion.FechaMov; } set { miGestion.FechaMov = value; } }
        public bool HabilitarConcepto { get { return miGestion.HabilitarConcepto; } }
        public bool HabilitarCambioSucursal { get { return miGestion.HabilitarCambioSucursal; } }
        public string GetIdSucursal { get { return miGestion.GetIdSucursal; } }
        public bool HabilitarCambioDepositoOrigen { get { return miGestion.HabilitarCambioDepositoOrigen; } }
        public string GetIdDepositoOrigen { get { return miGestion.GetIdDepositoOrigen; } }
        public bool HabilitarCambioDepositoDestino { get { return miGestion.HabilitarCambioDepositoDestino; } }
        public string GetIdDepositoDestino { get { return miGestion.GetIdDepositoDestino; } }
        public enumMetBusq MetodoBusqueda { get { return (enumMetBusq)_gAdmSelPrd.MetBusqueda; } }
        public string CadenaBusqueda { get { return _gAdmSelPrd.CadenaBusqueda; } }


        public Gestion(
            FiltrosGen.IAdmSelecciona admSelPrd,
            Helpers.Maestros.ICallMaestros ctrMaestros)
        {
            _gAdmSelPrd = admSelPrd;
            _callMaestros = ctrMaestros;
        }


        public void setGestion(IGestion gestion) 
        {
            miGestion = gestion;
        }

        MvFrm frm;
        public void Inicia() 
        {
            miGestion.Inicia();
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new MvFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void Inicia2()
        {
            miGestion.Inicia();
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            switch (r01.Entidad)
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorCodigo:
                    setMetBusqByCodigo();
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorNombre:
                    setMetBusqByNombre();
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorReferencia:
                    setMetBusqByReferencia();
                    break;
            }

            return miGestion.CargarData();
        }

        public void Limpiar()
        {
            miGestion.Limpiar();
        }

        public bool LimpiarVistaIsOk()
        {
            return miGestion.LimpiarVistaIsOk();
        }

        public void BuscarProducto()
        {
            _gAdmSelPrd.NotificarSeleccion +=_gAdmSelPrd_NotificarSeleccion;
            _gAdmSelPrd.BuscarSeleccionar();
            _gAdmSelPrd.NotificarSeleccion -= _gAdmSelPrd_NotificarSeleccion;
        }

        private void _gAdmSelPrd_NotificarSeleccion(object sender, EventArgs e)
        {
            if (_gAdmSelPrd.ItemSeleccionadoIsOk)
            {
                miGestion.BuscarProducto(_gAdmSelPrd.ItemSeleccionado.id);
            }
        }

        public void EliminarItem()
        {
            miGestion.EliminarItem();
        }

        public void EditarItem()
        {
            miGestion.EditarItem();
        }

        public void Procesar()
        {
            miGestion.Procesar();
            if (miGestion.ProcesarDocIsOk) 
            {
                _gAdmSelPrd.Inicializa();
                miGestion.Inicializa();
            }
        }

        public bool AbandonarDocumento()
        {
            return miGestion.AbandonarDocumento();
        }

        public void Filtrar()
        {
            _gAdmSelPrd.Inicia();
        }

        public void MaestroConcepto()
        {
            _callMaestros.MtConcepto();
            miGestion.ActualizarConceptos();
        }

        public void setHabilitarConcepto(bool p)
        {
            miGestion.setHabilitarConcepto(p);
        }

        public void Inicializa()
        {
            _gAdmSelPrd.Inicializa();
        }

        public void setSucursal(string id)
        {
            miGestion.setSucursal(id);
        }
        public void setDepositoOrigen(string id)
        {
            miGestion.setDepositoOrigen(id);
        }
        public void setConcepto(string id)
        {
            miGestion.setConcepto(id);
        }
        public void setDepositoDestino(string id)
        {
            miGestion.setDepositoDestino(id);
        }


        public void Finaliza()
        {
            miGestion.Finaliza();
        }


        public void setMetBusqByCodigo()
        {
            _gAdmSelPrd.setMetBusqByCodigo();
        }
        public void setMetBusqByNombre()
        {
            _gAdmSelPrd.setMetBusqByNombre();
        }
        public void setMetBusqByReferencia()
        {
            _gAdmSelPrd.setMetBusqByReferencia();
        }
        public void setCadenaBuscar(string cadena)
        {
            _gAdmSelPrd.setCadenaBusq(cadena);
        }

    }

}
