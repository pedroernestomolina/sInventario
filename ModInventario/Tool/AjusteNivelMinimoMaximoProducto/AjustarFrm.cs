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


        private void AjustarFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.Producto;
            var f = "n0";
            if (_controlador.ProductoEsPesado) 
            {
                f = "n3";
            }
            TB_EXISTENCIA.Text = _controlador.Existencia.ToString(f);
            TB_MINIMO.Text = _controlador.GetMinimo.ToString(f).Replace(".","");
            TB_MAXIMO.Text = _controlador.GetMaximo.ToString(f).Replace(".","");
            TB_MINIMO.Focus();
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk) 
            {
                Salir();
            }
        }


        private void TB_MINIMO_Leave(object sender, EventArgs e)
        {
            var _min= decimal.Parse(TB_MINIMO.Text);
            _controlador.setMinimo(_min);
        }
        private void TB_MAXIMO_Leave(object sender, EventArgs e)
        {
            var _max = decimal.Parse(TB_MAXIMO.Text);
            _controlador.setMaximo(_max);
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void Salir()
        {
            this.Close();
        }
        private void AjustarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOk) 
            {
                e.Cancel = false;
            }
        }

        private void BT_RESTAURAR_Click(object sender, EventArgs e)
        {
            RestaurarValoresOriginales();
        }
        private void RestaurarValoresOriginales()
        {
            _controlador.RestaurarValoresOriginales();
            if (_controlador.RestaurarValoresOriginalesIsOk) 
            {
                var f = "n0";
                if (_controlador.ProductoEsPesado)
                {
                    f = "n3";
                }
                TB_MINIMO.Text = _controlador.GetMinimo.ToString(f).Replace(".", "");
                TB_MAXIMO.Text = _controlador.GetMaximo.ToString(f).Replace(".", "");
            }
        }

    }

}