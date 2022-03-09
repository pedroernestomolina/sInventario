using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Identificacion
{
    
    public partial class IdentificacionFrm : Form
    {


        private Gestion _controlador;


        public IdentificacionFrm()
        {
            InitializeComponent();
            Limpiar();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            if (_controlador.VerificarUsuario())
            {
                Salir();
            }
        }

        private void Limpiar()
        {
            TB_CODIGO.Text = "";
            TB_CLAVE.Text = "";
            TB_CODIGO.Focus();
        }

        private void IdentificacionFrm_Load(object sender, EventArgs e)
        {
            TB_CODIGO.Focus();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.CodigoUsuario = TB_CODIGO.Text.Trim();
        }

        private void TB_CLAVE_Leave(object sender, EventArgs e)
        {
            _controlador.ClaveUsuario = TB_CLAVE.Text.Trim();
        }
     
    }

}