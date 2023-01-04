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


        private ILogin _controlador;


        public IdentificacionFrm()
        {
            InitializeComponent();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }


        private void IdentificacionFrm_Load(object sender, EventArgs e)
        {
            TB_CODIGO.Text = _controlador.GetCodigo;
            TB_CLAVE.Text = _controlador.GetClave;
            TB_CODIGO.Focus();
        }

        public void setControlador(ILogin ctr)
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
            _controlador.setCodigoUsu(TB_CODIGO.Text.Trim());
        }
        private void TB_CLAVE_Leave(object sender, EventArgs e)
        {
            _controlador.setClaveUsu(TB_CLAVE.Text.Trim());
        }


        private void Aceptar()
        {
            if (_controlador.UsuarioIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
     
    }

}