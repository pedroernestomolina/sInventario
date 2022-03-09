using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.Editar
{

    public partial class EditarFrm : Form
    {

        private Gestion _controlador ;

    
        public EditarFrm()
        {
            InitializeComponent();
        }

        private void EditarFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.Producto;
            L_DEPOSITO.Text = _controlador.Deposito;
            TB_UBICACION_1.Text = _controlador.Ubicacion_1;
            TB_UBICACION_2.Text = _controlador.Ubicacion_2;
            TB_UBICACION_3.Text = _controlador.Ubicacion_3;
            TB_UBICACION_4.Text = _controlador.Ubicacion_4;
            TB_MINIMO.Text = _controlador.Minimo.ToString();
            TB_MAXIMO.Text = _controlador.Maximo.ToString();
            TB_PEDIDO.Text = _controlador.Pedido.ToString();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void TB_UBICACION_1_Leave(object sender, EventArgs e)
        {
            _controlador.Ubicacion_1 = TB_UBICACION_1.Text.Trim().ToUpper();
            TB_UBICACION_1.Text = _controlador.Ubicacion_1;
        }

        private void TB_UBICACION_2_Leave(object sender, EventArgs e)
        {
            _controlador.Ubicacion_2 = TB_UBICACION_2.Text.Trim().ToUpper();
            TB_UBICACION_2.Text = _controlador.Ubicacion_2;
        }

        private void TB_UBICACION_3_Leave(object sender, EventArgs e)
        {
            _controlador.Ubicacion_3 = TB_UBICACION_3.Text.Trim().ToUpper();
            TB_UBICACION_3.Text = _controlador.Ubicacion_3;
        }

        private void TB_UBICACION_4_Leave(object sender, EventArgs e)
        {
            _controlador.Ubicacion_4 = TB_UBICACION_4.Text.Trim().ToUpper();
            TB_UBICACION_4.Text = _controlador.Ubicacion_4;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.HabilitarCierre) 
            {
                Salir();
            }
        }

        private void EditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_controlador.HabilitarCierre;
            _controlador.setInicializarHabilitarCierre();
        }

        private void TB_MINIMO_Leave(object sender, EventArgs e)
        {
            _controlador.Minimo = int.Parse(TB_MINIMO.Text);
        }

        private void TB_MAXIMO_Leave(object sender, EventArgs e)
        {
            _controlador.Maximo = int.Parse(TB_MAXIMO.Text);
        }

        private void TB_PEDIDO_Leave(object sender, EventArgs e)
        {
            _controlador.Pedido = int.Parse(TB_PEDIDO.Text);
        }

    }

}
