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


namespace ModInventario.src.Producto.QR
{

    public partial class QRFrm : Form
    {

        private IQR _controlador;


        public QRFrm()
        {
            InitializeComponent();
        }

        private void QRFrm_Load(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            L_PRODUCTO.Text = _controlador.GetProducto_Desc;
            PB_IMAGEN.Image = PB_IMAGEN.InitialImage;
            if (_controlador.GetProducto_Img != null)
            {
                PB_IMAGEN.Image = _controlador.GetProducto_Img; 
            }
            if (_controlador.GetProducto_ImgQR != null)
            {
                P_RESULTADO.BackgroundImage = _controlador.GetProducto_ImgQR;
            }
        }


        public void setControlador(IQR ctr)
        {
            _controlador = ctr;
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


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            this.Close();
        }

        private void QRFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }

    }

}