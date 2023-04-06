using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.ActualizarOferta.ModoAdm
{
    public partial class Frm : Form
    {
        private IModoAdm _controlador;


        public Frm()
        {
            InitializeComponent();
        }

        public void setControlador(IModoAdm ctr)
        {
            _controlador = ctr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
        }
    }
}