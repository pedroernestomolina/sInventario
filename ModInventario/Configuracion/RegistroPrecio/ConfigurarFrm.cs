using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.RegistroPrecio
{

    public partial class ConfigurarFrm : Form
    {

        private Gestion _controlador;


        public ConfigurarFrm()
        {
            InitializeComponent();

            CB_OPCIONES.ValueMember = "auto";
            CB_OPCIONES.DisplayMember = "descripcion";
        }

        private bool isIniciar;
        private void ConfigurarFrm_Load(object sender, EventArgs e)
        {
            CB_OPCIONES.DataSource = _controlador.Source;
            isIniciar = true;
            CB_OPCIONES.SelectedValue = _controlador.RegistroPrecio.auto;
            isIniciar = false;
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
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

        private void CB_OPCIONES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isIniciar)
            {
                _controlador.setRegistroPrecio("");
                if (CB_OPCIONES.SelectedIndex != -1)
                {
                    _controlador.setRegistroPrecio(CB_OPCIONES.SelectedValue.ToString());
                }
            }
        }

    }

}