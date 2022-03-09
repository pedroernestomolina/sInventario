using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInv
{

    public class GestionMov : IGestionMov
    {

        private IMov _gestion;
        private bool _abandonarIsOk;
        private bool _limpiarIsOk;


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool ProcesarIsOk { get { return _gestion.ProcesarIsOk; } }
        public bool HabilitarCambio { get { return _gestion.HablitarCambio; } }
        public BindingSource SucursalSource { get { return _gestion.SucursalSource; } }
        public string SucursalGetID { get { return _gestion.SucursalGetID; } }
        public BindingSource ConceptoSource { get { return _gestion.ConceptoSource; } }
        public string ConceptoGetID { get { return _gestion.ConceptoGetID; } }
        public BindingSource DepOrigenSource { get { return _gestion.DepOrigenSource; } }
        public string DepOrigenGetID { get { return _gestion.DepOrigenGetID; } }
        public string AutorizadoPor { get { return _gestion.AutoriazadoPor; } }
        public string Motivo { get { return _gestion.Motivo; } }
        public DateTime FechaSistema { get { return _gestion.FechaSistema; } }
        public int CntItem { get { return _gestion.CntItem; } }
        public decimal Monto { get { return _gestion.Monto; } }
        public bool LimpiarIsOk { get { return _limpiarIsOk; } }
        public BindingSource ItemsSource { get { return _gestion.ItemsSource; } }


        public GestionMov()
        {
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }

        public void setGestion(IMov ctr)
        {
            _gestion = ctr;
        }

        public void Inicia()
        {
            _gestion.Inicia(this);
        }

        public void Finaliza()
        {
        }

        public void AbandonarFicha()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

        public void setSucursal(string id)
        {
            _gestion.setSucursal(id);
        }
        public void setConcepto(string id)
        {
            _gestion.setConcepto(id);
        }
        public void setDepOrigen(string id)
        {
            _gestion.setDepOrigen(id);
        }
        public void setAutorizado(string p)
        {
            _gestion.setAutorizado(p);
        }
        public void setMotivo(string p)
        {
            _gestion.setMotivo(p);
        }

        public void Limpiar()
        {
            _limpiarIsOk = false;
            var xmsg = "Limpiar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _gestion.Limpiar();
                _limpiarIsOk = true;
            }
        }

        public void CapturarAplicarAjuste()
        {
            _gestion.CapturarAplicarAjuste();
        }


        private void limpiar()
        {
            _limpiarIsOk = false;
            _abandonarIsOk = false;
        }

        public void Procesar()
        {
            _gestion.Procesar();
        }

    }

}