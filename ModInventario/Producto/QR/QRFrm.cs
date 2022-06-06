using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.QR
{

    public partial class QRFrm : Form
    {

        private Gestion _controlador;


        public QRFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void QRFrm_Load(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            L_PRODUCTO.Text = _controlador.Producto;
            PB_IMAGEN.Image = PB_IMAGEN.InitialImage;
            if (_controlador.ImagenProducto != null)
            {
                PB_IMAGEN.Image = _controlador.ImagenProducto; 
            }
            if (_controlador.ImageQR != null)
            {
                P_RESULTADO.BackgroundImage = _controlador.ImageQR;
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            this.Close();
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            ImprimirQR();
        }
        private void ImprimirQR()
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            _controlador.ImprimirQR(e);
        }

    }

}