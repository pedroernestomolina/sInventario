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


namespace ModInventario.Producto.Imagen
{

    public partial class ImgFrm : Form
    {

        private Gestion _controlador;


        public ImgFrm()
        {
            InitializeComponent();
        }

        internal void setControlador(Gestion ctr)
        {
            _controlador = ctr;

        }

        private void ImgFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.Producto;
            PB_IMAGEN.Image = PB_IMAGEN.InitialImage;
            if (_controlador.Imagen.Length > 0)
            {
                using (var ms = new MemoryStream(_controlador.Imagen))
                {
                    PB_IMAGEN.Image = Image.FromStream(ms);
                }
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

    }

}