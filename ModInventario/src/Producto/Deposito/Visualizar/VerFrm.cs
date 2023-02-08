using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.Deposito.Visualizar
{
    public partial class VerFrm : Form
    {
        private IVisualizar _controlador;


        public VerFrm()
        {
            InitializeComponent();
        }


        private void VerFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.GetInfo_Producto;
            L_DEPOSITO.Text = _controlador.GetInfo_Deposito;
            L_UB_1.Text = _controlador.GetInfo_Ubicacion_1;
            L_UB_2.Text = _controlador.GetInfo_Ubicacion_2;
            L_UB_3.Text = _controlador.GetInfo_Ubicacion_3;
            L_UB_4.Text = _controlador.GetInfo_Ubicacion_4;
            L_MINIMO.Text = _controlador.GetInfo_Minimo;
            L_MAXIMO.Text = _controlador.GetInfo_Maximo;
            L_PEDIDO.Text = _controlador.GetInfo_Pedido;
        }


        public void setControlador(IVisualizar ctr)
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
    }
}