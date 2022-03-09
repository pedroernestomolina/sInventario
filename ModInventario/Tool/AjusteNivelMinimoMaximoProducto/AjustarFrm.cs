using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Tool.AjusteNivelMinimoMaximoProducto
{

    public partial class AjustarFrm : Form
    {

        private GestionAjuste _controlador;


        public AjustarFrm()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            L_PRODUCTO.Text = "";
        }

        public void setControlador(GestionAjuste ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void AjustarFrm_Load(object sender, EventArgs e)
        {
            var f = "n0";
            L_PRODUCTO.Text = _controlador.Producto;
            if (_controlador.ProductoEsPesado) 
            {
                f = "n3";
            }
            TB_EXISTENCIA.Text = _controlador.Existencia.ToString(f);
            TB_MINIMO.Text = _controlador.Minimo.ToString(f);
            TB_MAXIMO.Text = _controlador.Maximo.ToString(f);
            TB_MINIMO.Focus();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.AjusteIsOk) 
            {
                Salir();
            }
        }

        private void TB_MINIMO_TextChanged(object sender, EventArgs e)
        {
            _controlador.Minimo = decimal.Parse(TB_MINIMO.Text);
        }

        private void TB_MAXIMO_TextChanged(object sender, EventArgs e)
        {
            _controlador.Maximo = decimal.Parse(TB_MAXIMO.Text);
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }

}