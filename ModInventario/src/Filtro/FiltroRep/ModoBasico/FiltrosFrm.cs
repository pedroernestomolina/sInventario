using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroRep.ModoBasico
{

    public partial class FiltrosFrm : Form
    {

        private IModoBasico _controlador;


        public FiltrosFrm()
        {
            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            CB_DEPARTAMENTO.DisplayMember = "desc";
            CB_DEPARTAMENTO.ValueMember = "id";
            CB_DEPOSITO.DisplayMember = "desc";
            CB_DEPOSITO.ValueMember = "id";
            CB_GRUPO.DisplayMember = "desc";
            CB_GRUPO.ValueMember = "id";
            CB_MARCA.DisplayMember = "desc";
            CB_MARCA.ValueMember = "id";
            CB_ADMDIVISA.DisplayMember = "desc";
            CB_ADMDIVISA.ValueMember = "id";
            CB_IMPUESTO.DisplayMember = "desc";
            CB_IMPUESTO.ValueMember = "id";
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
            CB_PESADO.DisplayMember = "desc";
            CB_PESADO.ValueMember = "id";
        }

        bool _modoInicializar;
        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_DEPOSITO.DataSource = _controlador.GetDeposito_Source;
            CB_DEPARTAMENTO.DataSource = _controlador.GetDepartamento_Source;
            CB_GRUPO.DataSource = _controlador.GetGrupo_Source;
            CB_MARCA.DataSource = _controlador.GetMarca_Source;
            CB_ADMDIVISA.DataSource = _controlador.GetAdmDivisa_Source;
            CB_IMPUESTO.DataSource = _controlador.GetImpuesto_Source;
            CB_ESTATUS.DataSource = _controlador.GetEstatus_Source;
            CB_PESADO.DataSource = _controlador.GetPesado_Source;

            CB_DEPOSITO.SelectedValue = _controlador.GetDeposito_Id;
            CB_DEPARTAMENTO.SelectedValue = _controlador.GetDepartamento_Id;
            CB_GRUPO.SelectedValue = _controlador.GetGrupo_Id;
            CB_MARCA.SelectedValue = _controlador.GetMarca_Id;
            CB_ADMDIVISA.SelectedValue = _controlador.GetAdmDivisa_Id;
            CB_IMPUESTO.SelectedValue = _controlador.GetImpuesto_Id;
            CB_ESTATUS.SelectedValue = _controlador.GetEstatus_Id;
            CB_PESADO.SelectedValue = _controlador.GetPesado_Id;
            DTP_DESDE.Value = _controlador.GetDesde;
            DTP_HASTA.Value = _controlador.GetHasta;

            CB_DEPARTAMENTO.Enabled = _controlador.GetHabilitarDepartamento;
            CB_DEPOSITO.Enabled = _controlador.GetHabilitarDeposito;
            CB_GRUPO.Enabled = false;
            CB_MARCA.Enabled = _controlador.GetHabilitarMarca;
            CB_ADMDIVISA.Enabled = _controlador.GetHabilitarAdmDivisa;
            CB_IMPUESTO.Enabled = _controlador.GetHabilitarImpuesto;
            CB_ESTATUS.Enabled = _controlador.GetHabilitarEstatus;
            CB_PESADO.Enabled = _controlador.GetHabilitarPesado;
            DTP_DESDE.Enabled = _controlador.GetHabilitarFechaDesde;
            DTP_HASTA.Enabled = _controlador.GetHabilitarFechaHasta;
            _modoInicializar = false;
        }


        public void setControlador(IModoBasico ctr)
        {
            _controlador = ctr;
        }


        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setDeposito("");
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.setDeposito(CB_DEPOSITO.SelectedValue.ToString());
            }
        }
        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setDepartamento("");
            CB_GRUPO.Enabled = false;
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.setDepartamento(CB_DEPARTAMENTO.SelectedValue.ToString());
                CB_GRUPO.Enabled = true;
                CB_GRUPO.SelectedIndex = -1;
            }
        }
        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setMarca("");
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.setMarca(CB_MARCA.SelectedValue.ToString());
            }
        }
        private void CB_ADMDIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setAdmDivisa("");
            if (CB_ADMDIVISA.SelectedIndex != -1)
            {
                _controlador.setAdmDivisa(CB_ADMDIVISA.SelectedValue.ToString());
            }
        }
        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setImpuesto("");
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.setImpuesto(CB_IMPUESTO.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_PESADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setPesado("");
            if (CB_PESADO.SelectedIndex != -1)
            {
                _controlador.setPesado(CB_PESADO.SelectedValue.ToString());
            }
        }


        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setDesde(DTP_DESDE.Value.Date);
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setHasta(DTP_HASTA.Value.Date);
        }


        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            CB_DEPARTAMENTO.SelectedIndex = -1;
        }
        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            CB_DEPOSITO.SelectedIndex = -1;
        }
        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            CB_GRUPO.SelectedIndex = -1;
        }
        private void L_MARCA_Click(object sender, EventArgs e)
        {
            CB_MARCA.SelectedIndex = -1;
        }
        private void L_ADMDIVISA_Click(object sender, EventArgs e)
        {
            CB_ADMDIVISA.SelectedIndex = -1;
        }
        private void L_IMPUESTO_Click(object sender, EventArgs e)
        {
            CB_IMPUESTO.SelectedIndex = -1;
        }
        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void L_PESADO_Click(object sender, EventArgs e)
        {
            CB_PESADO.SelectedIndex = -1;
        }
        private void L_DESDE_Click(object sender, EventArgs e)
        {
            DTP_DESDE.Value = DateTime.Now.Date;
        }
        private void L_HASTA_Click(object sender, EventArgs e)
        {
            DTP_HASTA.Value = DateTime.Now.Date;
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }


        private void LimpiarFiltros()
        {
            _controlador.LimpiarOpciones();
            if (_controlador.LimpiarOpcionesIsOk)
            {
                _modoInicializar = true;
                CB_DEPOSITO.SelectedIndex = -1;
                CB_DEPARTAMENTO.SelectedIndex = -1;
                CB_GRUPO.SelectedIndex = -1;
                CB_MARCA.SelectedIndex = -1;
                CB_ADMDIVISA.SelectedIndex = -1;
                CB_IMPUESTO.SelectedIndex = -1;
                CB_ESTATUS.SelectedIndex = -1;
                CB_PESADO.SelectedIndex = -1;
                DTP_DESDE.Value = DateTime.Now.Date;
                DTP_HASTA.Value = DateTime.Now.Date;
                _modoInicializar = false;
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
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
        private void Salir()
        {
            this.Close();
        }


        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void FiltrosFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if ((_controlador.ProcesarIsOk && _controlador.FiltrosIsOK) || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }

    }

}