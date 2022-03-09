using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.CostoEdad
{

    public partial class ConfigurarFrm : Form
    {


        private Gestion _controlador;


        public ConfigurarFrm()
        {
            InitializeComponent();
        }

        private void ConfigurarFrm_Load(object sender, EventArgs e)
        {
            TB_COSTO_EDAD.Text = _controlador.CostoEdad.ToString("n0");
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void TB_COSTO_EDAD_Leave(object sender, EventArgs e)
        {
            _controlador.setCostoEdad(int.Parse(TB_COSTO_EDAD.Text));
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

        private void Procesar()
        {
            _controlador.Proesar();
            if (_controlador.IsOk) 
            {
                Salir();
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