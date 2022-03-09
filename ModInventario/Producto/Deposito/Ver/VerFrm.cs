using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.Ver
{

    public partial class VerFrm : Form
    {

        private Gestion _controlador;


        public VerFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void VerFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.Producto;
            L_DEPOSITO.Text = _controlador.Deposito;
            L_UB_1.Text = _controlador.Ubicacion_1;
            L_UB_2.Text = _controlador.Ubicacion_2;
            L_UB_3.Text = _controlador.Ubicacion_3;
            L_UB_4.Text = _controlador.Ubicacion_4;
            L_MINIMO.Text = _controlador.Minimo;
            L_MAXIMO.Text = _controlador.Maximo;
            L_PEDIDO.Text = _controlador.Pedido;
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
