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


namespace ModInventario.src.Producto.Imagen
{

    public partial class ImgFrm : Form
    {

        private IImagen _controlador;


        public ImgFrm()
        {
            InitializeComponent();
        }

        public void setControlador(IImagen ctr)
        {
            _controlador = ctr;
        }

        private void ImgFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.GetProducto_Desc;
            PB_IMAGEN.Image = PB_IMAGEN.InitialImage;
            if (_controlador.GetProducto_Img != null)
            {
                PB_IMAGEN.Image = _controlador.GetProducto_Img;
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
        private void Salir()
        {
            this.Close();
        }

        private void ImgFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk) 
            {
                e.Cancel = false;
            }
        }

    }

}