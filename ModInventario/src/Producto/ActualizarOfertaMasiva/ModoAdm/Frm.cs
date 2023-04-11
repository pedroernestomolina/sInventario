using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.ModoAdm
{
    public partial class Frm : Form
    {
        private IMasiva _controlador;


        public Frm()
        {
            InitializeComponent();
        }

        public void setControlador(IMasiva ctr)
        {
            _controlador = ctr;
        }
    }
}