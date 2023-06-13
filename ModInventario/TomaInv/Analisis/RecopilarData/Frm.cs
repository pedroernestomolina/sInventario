using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis.RecopilarData
{
    public partial class Frm : Form
    {
        private IRecopilar _controlador;


        public Frm()
        {
            InitializeComponent();
        }

        public void setControlador(IRecopilar ctr)
        {
            _controlador = ctr;
        }


        private void Frm_Load(object sender, EventArgs e)
        {
            IrFoco();
            TB_AUTORIZADO_POR.Text = _controlador.Autorizado_GetData;
            TB_MOTIVO.Text = _controlador.Motivo_GetData;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk) 
            {
                e.Cancel = false;
            }
        }
        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void TB_AUTORIZADO_POR_Leave(object sender, EventArgs e)
        {
            _controlador.setAutorizadoPor(TB_AUTORIZADO_POR.Text);
        }
        private void TB_MOTIVO_Leave(object sender, EventArgs e)
        {
            _controlador.setMotivo(TB_MOTIVO.Text);
        }


        private void IrFoco()
        {
            TB_AUTORIZADO_POR.Focus();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void ProcesarFicha()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
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
    }
}