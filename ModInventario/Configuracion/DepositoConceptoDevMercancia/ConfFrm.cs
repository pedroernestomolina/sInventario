using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.DepositoConceptoDevMercancia
{

    public partial class ConfFrm : Form
    {


        private IConfiguracion _controlador;


        public ConfFrm()
        {
            InitializeComponent();
            Inicializa();
        }

        private void Inicializa()
        {
            CB_DEPOSITO.ValueMember = "id";
            CB_DEPOSITO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
            CB_CONCEPTO.DisplayMember = "desc";
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private bool _modoInicializar;
        private void ConfFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_DEPOSITO.DataSource = _controlador.DepositoSource;
            CB_CONCEPTO.DataSource = _controlador.ConceptoSource;
            CB_DEPOSITO.SelectedValue = _controlador.DepositoGetId;
            CB_CONCEPTO.SelectedValue = _controlador.ConceptoGetId;
            _modoInicializar = false;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setDeposito("");
            if (CB_DEPOSITO.SelectedIndex != -1) 
            {
                _controlador.setDeposito(CB_DEPOSITO.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setConcepto("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.setConcepto(CB_CONCEPTO.SelectedValue.ToString());
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOK) 
            {
                Salir();
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Poricesar();
        }
        private void Poricesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }
        private void ConfFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOK)
            {
                e.Cancel = false;
            }
        }

    }

}