using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroAdmDoc.ModoBasico
{

    public partial class FiltroFrm : Form
    {


        private IAdmDoc _controlador;


        public FiltroFrm()
        {
            InitializeComponent();
            InicializaControles();
        }

        private void InicializaControles()
        {
            CB_DEP_ORIGEN.DisplayMember = "desc";
            CB_DEP_ORIGEN.ValueMember = "id";
            CB_DEP_DESTINO.DisplayMember = "desc";
            CB_DEP_DESTINO.ValueMember = "id";
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
        }

        private bool _modoInicializa; 
        private void FiltroFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            CB_DEP_ORIGEN.DataSource=_controlador.GetDepOrigen_Source;
            CB_DEP_DESTINO.DataSource = _controlador.GetDepDestino_Source;
            CB_ESTATUS.DataSource = _controlador.GetEstatus_Source;
            CB_CONCEPTO.DataSource = _controlador.GetConcepto_Source;

            CB_DEP_ORIGEN.SelectedValue = _controlador.GetDepOrigen_Id;
            CB_DEP_DESTINO.SelectedValue = _controlador.GetDepDestino_Id;
            CB_CONCEPTO.SelectedValue = _controlador.GetConcepto_Id;
            CB_ESTATUS.SelectedValue = _controlador.GetEstatus_Id;
            _modoInicializa = false;
        }

        public void setControlador(IAdmDoc ctr)
        {
            _controlador = ctr;
        }


        private void CB_DEP_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }

            _controlador.setDepOrigen("");
            if (CB_DEP_ORIGEN.SelectedIndex != -1)
            {
                _controlador.setDepOrigen(CB_DEP_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_DEP_DESTINO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.setDepDestino("");
            if (CB_DEP_DESTINO.SelectedIndex != -1)
            {
                _controlador.setDepDestino(CB_DEP_DESTINO.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.setConcepto("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.setConcepto(CB_CONCEPTO.SelectedValue.ToString());
            }
        }

        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            LimpiarConcepto();
        }
        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            LimpiarEstatus();
        }
        private void L_DEP_ORIGEN_Click(object sender, EventArgs e)
        {
            LimpiarDepOrigen();
        }
        private void L_DEP_DESTINO_Click(object sender, EventArgs e)
        {
            LimpiarDepDestino();
        }


        private void LimpiarEstatus()
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void LimpiarConcepto()
        {
            CB_CONCEPTO.SelectedIndex = -1;
        }
        private void LimpiarDepDestino()
        {
            CB_DEP_DESTINO.SelectedIndex = -1;
        }
        private void LimpiarDepOrigen()
        {
            CB_DEP_ORIGEN.SelectedIndex = -1;
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
        private void FiltroFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }
        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void LimpiarFiltros()
        {
            LimpiarDepOrigen();
            LimpiarDepDestino();
            LimpiarEstatus();
            LimpiarConcepto();
        }

    }

}