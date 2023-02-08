using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.Deposito.Editar
{
    public partial class EditarFrm : Form
    {
        private IEditar _controlador ;

    
        public EditarFrm()
        {
            InitializeComponent();
        }


        private bool _modoIni;
        private void EditarFrm_Load(object sender, EventArgs e)
        {
            _modoIni = true;
            L_PRODUCTO.Text = _controlador.GetInfo_Producto;
            L_DEPOSITO.Text = _controlador.GetInfo_Deposito;
            TB_UBICACION_1.Text = _controlador.GetInfo_Ubicacion_1;
            TB_UBICACION_2.Text = _controlador.GetInfo_Ubicacion_2;
            TB_UBICACION_3.Text = _controlador.GetInfo_Ubicacion_3;
            TB_UBICACION_4.Text = _controlador.GetInfo_Ubicacion_4;
            TB_MINIMO.Text = _controlador.GetInfo_Minimo.ToString();
            TB_MAXIMO.Text = _controlador.GetInfo_Maximo.ToString();
            TB_PEDIDO.Text = _controlador.GetInfo_Pedido.ToString();
            _modoIni = false;
        }
        private void EditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }


        public void setControlador(IEditar ctr)
        {
            _controlador = ctr;
        }

        private void TB_UBICACION_1_Leave(object sender, EventArgs e)
        {
            _controlador.setUbicacion_1(TB_UBICACION_1.Text.Trim().ToUpper());
        }
        private void TB_UBICACION_2_Leave(object sender, EventArgs e)
        {
            _controlador.setUbicacion_2(TB_UBICACION_2.Text.Trim().ToUpper());
        }
        private void TB_UBICACION_3_Leave(object sender, EventArgs e)
        {
            _controlador.setUbicacion_3(TB_UBICACION_3.Text.Trim().ToUpper());
        }
        private void TB_UBICACION_4_Leave(object sender, EventArgs e)
        {
            _controlador.setUbicacion_4(TB_UBICACION_4.Text.Trim().ToUpper());
        }
        private void TB_MINIMO_Leave(object sender, EventArgs e)
        {
            _controlador.setMinimo(int.Parse(TB_MINIMO.Text));
        }
        private void TB_MAXIMO_Leave(object sender, EventArgs e)
        {
            _controlador.setMaximo(int.Parse(TB_MAXIMO.Text));
        }
        private void TB_PEDIDO_Leave(object sender, EventArgs e)
        {
            _controlador.setPedido(int.Parse(TB_PEDIDO.Text));
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
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }


        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
        }
        private void Abandonar ()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            Close();
        }
    }
}