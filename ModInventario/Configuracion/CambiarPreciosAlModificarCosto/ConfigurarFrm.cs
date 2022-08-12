using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.CambiarPreciosAlModificarCosto
{

    public partial class ConfigurarFrm : Form
    {


        private IConf _controlador;


        public ConfigurarFrm()
        {
            InitializeComponent();
        }

        private bool _modoInicializar;
        private void ConfigurarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CHB_SI.Checked = _controlador.GetOpcion;
            _modoInicializar = false;
        }


        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha ();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbanonaFicha();
        }
        private void AbanonaFicha()
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

        public void setControlador(IConf ctr)
        {
            _controlador = ctr;
        }

        private void ConfigurarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk) 
            {
                e.Cancel = false;
            }
        }

        private void CHB_SI_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;
            _controlador.setOpcion();
        }

    }

}