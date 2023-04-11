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
            L_PRODUCTO.Text = _controlador.Prd.GetDescripcion;
            L_TASA_CAMBIO.Text = _controlador.Prd.GetTasaCambioDesc;
            L_METODO.Text = _controlador.Prd.GetMetodoCalUtilidadDesc;
            L_ADM_DIVISA.Text = _controlador.Prd.GetAdmDivisaDesc;
            L_TASA_IVA.Text = _controlador.Prd.GetTasaIvaDesc;

            L_EMP_1.Text = _controlador.Prd.Vta1.GetEmpDesc;
            L_CONT_1.Text = _controlador.Prd.Vta1.GetContDesc;
            L_UT_1.Text = _controlador.Prd.Vta1.GetUtilidadDesc;
            L_NETO_DIV_1.Text = _controlador.Prd.Vta1.GetNetoDivisaDesc;
            L_NETO_1.Text = _controlador.Prd.Vta1.GetNetoMonLocalDesc;
            L_FULL_DIV_1.Text = _controlador.Prd.Vta1.GetFullDivisaDesc;
            L_FULL_1.Text = _controlador.Prd.Vta1.GetFullMonLocalDesc;
            ActualizarOferta(1);

            L_EMP_2.Text = _controlador.Prd.Vta2.GetEmpDesc;
            L_CONT_2.Text = _controlador.Prd.Vta2.GetContDesc;
            L_UT_2.Text = _controlador.Prd.Vta2.GetUtilidadDesc;
            L_NETO_DIV_2.Text = _controlador.Prd.Vta2.GetNetoDivisaDesc;
            L_NETO_2.Text = _controlador.Prd.Vta2.GetNetoMonLocalDesc;
            L_FULL_DIV_2.Text = _controlador.Prd.Vta2.GetFullDivisaDesc;
            L_FULL_2.Text = _controlador.Prd.Vta2.GetFullMonLocalDesc;
            ActualizarOferta(2);

            L_EMP_3.Text = _controlador.Prd.Vta3.GetEmpDesc;
            L_CONT_3.Text = _controlador.Prd.Vta3.GetContDesc;
            L_UT_3.Text = _controlador.Prd.Vta3.GetUtilidadDesc;
            L_NETO_DIV_3.Text = _controlador.Prd.Vta3.GetNetoDivisaDesc;
            L_NETO_3.Text = _controlador.Prd.Vta3.GetNetoMonLocalDesc;
            L_FULL_DIV_3.Text = _controlador.Prd.Vta3.GetFullDivisaDesc;
            L_FULL_3.Text = _controlador.Prd.Vta3.GetFullMonLocalDesc;
            ActualizarOferta(3);

            this.Refresh();
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=true;
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


        private void DTP_DESDE_1_Leave(object sender, EventArgs e)
        {
            _controlador.Prd.Vta1.setOfertaDesde(DTP_DESDE_1.Value);
            ActualizarOferta(1);
        }
        private void DTP_HASTA_1_Leave(object sender, EventArgs e)
        {
            _controlador.Prd.Vta1.setOfertaHasta(DTP_HASTA_1.Value);
            ActualizarOferta(1);
        }
        private void DTP_DESDE_2_Leave(object sender, EventArgs e)
        {
            _controlador.Prd.Vta2.setOfertaDesde(DTP_DESDE_2.Value);
            ActualizarOferta(2);
        }
        private void DTP_HASTA_2_Leave(object sender, EventArgs e)
        {
            _controlador.Prd.Vta2.setOfertaHasta(DTP_HASTA_2.Value);
            ActualizarOferta(2);
        }
        private void DTP_DESDE_3_Leave(object sender, EventArgs e)
        {
            _controlador.Prd.Vta3.setOfertaDesde(DTP_DESDE_3.Value);
            ActualizarOferta(3);
        }
        private void DTP_HASTA_3_Leave(object sender, EventArgs e)
        {
            _controlador.Prd.Vta3.setOfertaHasta(DTP_HASTA_3.Value);
            ActualizarOferta(3);
        }


        private void DTP_DESDE_1_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Prd.Vta1.setOfertaDesde(DTP_DESDE_1.Value);
            ActualizarOferta(1);
        }
        private void DTP_HASTA_1_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Prd.Vta1.setOfertaHasta(DTP_HASTA_1.Value);
            ActualizarOferta(1);
        }
        private void DTP_DESDE_2_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Prd.Vta2.setOfertaDesde(DTP_DESDE_2.Value);
            ActualizarOferta(2);
        }
        private void DTP_HASTA_2_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Prd.Vta2.setOfertaHasta(DTP_HASTA_2.Value);
            ActualizarOferta(2);
        }
        private void DTP_DESDE_3_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Prd.Vta3.setOfertaDesde(DTP_DESDE_3.Value);
            ActualizarOferta(3);
        }
        private void DTP_HASTA_3_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Prd.Vta3.setOfertaHasta(DTP_HASTA_3.Value);
            ActualizarOferta(3);
        }


        private void TB_PORCT_OFERTA_1_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_PORCT_OFERTA_1.Text);
            _controlador.Prd.Vta1.setOfertaPorct(monto);
            ActualizarOferta(1);
        }
        private void TB_PORCT_OFERTA_2_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_PORCT_OFERTA_2.Text);
            _controlador.Prd.Vta2.setOfertaPorct(monto);
            ActualizarOferta(2);
        }
        private void TB_PORCT_OFERTA_3_Leave(object sender, EventArgs e)
        {
            var monto = decimal.Parse(TB_PORCT_OFERTA_3.Text);
            _controlador.Prd.Vta3.setOfertaPorct(monto);
            ActualizarOferta(3);
        }


        private void BT_ANULAR_OFERTA_1_Click(object sender, EventArgs e)
        {
            _controlador.Prd.Vta1.EliminarOferta();
            ActualizarOferta(1);
        }
        private void BT_ANULAR_OFERTA_2_Click(object sender, EventArgs e)
        {
            _controlador.Prd.Vta2.EliminarOferta();
            ActualizarOferta(2);
        }
        private void BT_ANULAR_OFERTA_3_Click(object sender, EventArgs e)
        {
            _controlador.Prd.Vta3.EliminarOferta();
            ActualizarOferta(3);
        }


        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            ProcesarFcha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void ActualizarOferta(int pvta)
        {
            switch (pvta)
            { 
                case 1:
                    DTP_DESDE_1.Value = _controlador.Prd.Vta1.GetOfertaDesde;
                    DTP_HASTA_1.Value = _controlador.Prd.Vta1.GetOfertaHasta;
                    TB_PORCT_OFERTA_1.Text = _controlador.Prd.Vta1.GetOfertaPorctDesc;
                    L_FULL_MON_LOCAL_CON_OFERTA_1.Text = _controlador.Prd.Vta1.GetFullMonLocalConOfertaDesc;
                    L_FULL_DIVISA_CON_OFERTA_1.Text = _controlador.Prd.Vta1.GetFullDivisaConOfertaDesc;
                    CHB_EST_1.Checked = _controlador.Prd.Vta1.EstatusOfertaOk;
                    break;
                case 2:
                    DTP_DESDE_2.Value = _controlador.Prd.Vta2.GetOfertaDesde;
                    DTP_HASTA_2.Value = _controlador.Prd.Vta2.GetOfertaHasta;
                    TB_PORCT_OFERTA_2.Text = _controlador.Prd.Vta2.GetOfertaPorctDesc;
                    L_FULL_MON_LOCAL_CON_OFERTA_2.Text = _controlador.Prd.Vta2.GetFullMonLocalConOfertaDesc;
                    L_FULL_DIVISA_CON_OFERTA_2.Text = _controlador.Prd.Vta2.GetFullDivisaConOfertaDesc;
                    CHB_EST_2.Checked = _controlador.Prd.Vta2.EstatusOfertaOk;
                    break;
                case 3:
                    DTP_DESDE_3.Value = _controlador.Prd.Vta3.GetOfertaDesde;
                    DTP_HASTA_3.Value = _controlador.Prd.Vta3.GetOfertaHasta;
                    TB_PORCT_OFERTA_3.Text = _controlador.Prd.Vta3.GetOfertaPorctDesc;
                    L_FULL_MON_LOCAL_CON_OFERTA_3.Text = _controlador.Prd.Vta3.GetFullMonLocalConOfertaDesc;
                    L_FULL_DIVISA_CON_OFERTA_3.Text = _controlador.Prd.Vta3.GetFullDivisaConOfertaDesc;
                    CHB_EST_3.Checked = _controlador.Prd.Vta3.EstatusOfertaOk;
                    break;
            }
        }
        private void ProcesarFcha()
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