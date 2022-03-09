using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.SeguridadSist
{

    public partial class SeguridadFrm : Form
    {


        private Gestion _controlador;


        public SeguridadFrm()
        {
            InitializeComponent();
        }


        private void SeguridadFrm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.Titulo;
            TB_CLAVE.Text = "";
            TB_CLAVE.Focus();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }
        private void Aceptar()
        {
            TB_CLAVE.Focus();
            _controlador.Aceptar();
            if (_controlador.AceptarIsOk)
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
            TB_CLAVE.Focus();
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_CLAVE_Leave(object sender, EventArgs e)
        {
            _controlador.setClave(TB_CLAVE.Text.Trim());
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void SeguridadFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.AceptarIsOk)
            {
                e.Cancel = false;
            }
        }

    }

}