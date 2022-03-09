using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv.Departamento
{

    public partial class AgregarEditarFrm : Form
    {


        private IAgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
        }


        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.Titulo;
            TB_CODIGO.Text = _controlador.Codigo;
            TB_NOMBRE.Text = _controlador.Nombre;
            IrFoco();
        }

        private void IrFoco()
        {
            TB_CODIGO.Focus();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            IrFoco();
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            IrFoco();
            _controlador.Procesar();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        public void setControlador(IAgregarEditar ctr)
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

        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigo(TB_CODIGO.Text.Trim().ToUpper());
        }
        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text.Trim().ToUpper()); ;
        }

    }

}