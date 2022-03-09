using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Administrador.Tomas
{

    public partial class TomasFrm : Form
    {

        private IGestion _controlador;


        public TomasFrm()
        {
            InitializeComponent();
        }


        public void setControlador(IGestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.Buscar();
        }

        private void TomasFrm_Load(object sender, EventArgs e)
        {
        }

    }

}