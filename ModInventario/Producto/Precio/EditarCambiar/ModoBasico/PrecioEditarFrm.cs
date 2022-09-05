using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.EditarCambiar.ModoBasico
{
    public partial class PrecioEditarFrm : Form
    {


        private IEditarBasico _controlador;


        public PrecioEditarFrm()
        {
            InitializeComponent();
            Inicializar();
        }


        private void Inicializar()
        {
            CB_EMP_1.DisplayMember = "desc";
            CB_EMP_1.ValueMember = "id";
            CB_EMP_2.DisplayMember = "desc";
            CB_EMP_2.ValueMember = "id";
            CB_EMP_3.DisplayMember = "desc";
            CB_EMP_3.ValueMember = "id";
        }

        public void setControlador(IEditarBasico ctr)
        {
            _controlador = ctr;
        }

        private bool _modoInicializar;
        private void PrecioEditarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;

            L_PRODUCTO_INF.Text = _controlador.GetInfProducto;
            L_EMPAQUE_COMPRA.Text = "Empaque: "+_controlador.GetInfEmpCompraPrd;
            L_COSTO_EMP_COMPRA.Text = "Costo: "+_controlador.GetInfCostoEmpCompraPrd.ToString("n2");
            L_METODO_CALCULO_UT.Text = _controlador.GetInfMetodoCalculoUt;
            L_TASA_CAMBIO.Text = _controlador.GetInfTasaCambioPrd.ToString("n2");
            L_ADM_DIVISA.Text = _controlador.GetInfAdmDivisaPrd;
            L_TASA_IVA.Text = _controlador.GetInfTasaIvaPrd.ToString("n2");
            L_COSTO_UNIDAD.Text = _controlador.GetInfCostoUndPrd.ToString("n2");
            L_FECHA_ULT_ACT.Text = _controlador.GetInfFechaUltActPrd;
            L_DIVISA.Visible = _controlador.GetEsAdmDivisaPrd;
          
            CB_EMP_1.DataSource = _controlador.GetEmp1_Source;
            CB_EMP_2.DataSource = _controlador.GetEmp2_Source;
            CB_EMP_3.DataSource = _controlador.GetEmp3_Source;
            CB_EMP_1.SelectedValue = _controlador.GetEmp1_Id;
            CB_EMP_2.SelectedValue = _controlador.GetEmp2_Id;
            CB_EMP_3.SelectedValue = _controlador.GetEmp3_Id;
            //

            TB_CONT_1.Text = _controlador.GetCont1.ToString();
            TB_UT_1.Text = _controlador.GetUt1.ToString("n2").Replace(".","");
            TB_PN_1.Text = _controlador.GetPN1.ToString("n2").Replace(".", "");
            TB_PF_1.Text = _controlador.GetPF1.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_1.Text = _controlador.GetUtActual1.ToString("n2").Replace(".", "");

            TB_CONT_2.Text = _controlador.GetCont2.ToString();
            TB_UT_2.Text = _controlador.GetUt2.ToString("n2").Replace(".", "");
            TB_PN_2.Text = _controlador.GetPN2.ToString("n2").Replace(".", "");
            TB_PF_2.Text = _controlador.GetPF2.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_2.Text = _controlador.GetUtActual2.ToString("n2").Replace(".", "");

            TB_CONT_3.Text = _controlador.GetCont3.ToString();
            TB_UT_3.Text = _controlador.GetUt3.ToString("n2").Replace(".", "");
            TB_PN_3.Text = _controlador.GetPN3.ToString("n2").Replace(".", "");
            TB_PF_3.Text = _controlador.GetPF3.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_3.Text = _controlador.GetUtActual3.ToString("n2").Replace(".", "");

            TB_CONT_1.Enabled = true;
            TB_CONT_2.Enabled = true;
            TB_CONT_3.Enabled = true;

            TB_UT_1.Enabled = false;
            TB_UT_2.Enabled = false;
            TB_UT_3.Enabled = false;

            TB_PN_1.Enabled = false;
            TB_PN_2.Enabled = false;
            TB_PN_3.Enabled = false;

            TB_PF_1.Enabled = false;
            TB_PF_2.Enabled = false;
            TB_PF_3.Enabled = false;

            CB_EMP_1.Enabled = true;
            CB_EMP_2.Enabled = true;
            CB_EMP_3.Enabled = true;

            _modoInicializar = false;
        }


        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_MODO_PRECIO_Click(object sender, EventArgs e)
        {
        }


        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
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
        private void EditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk  || _controlador.ProcesarIsOk) 
            {
                e.Cancel = false;
            }
        }

        private void CB_EMP_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true) 
            { return; }

            _controlador.setEmp1("");
            if (CB_EMP_1.SelectedIndex != -1)
            {
                _controlador.setEmp1(CB_EMP_1.SelectedValue.ToString());
            }
        }
        private void CB_EMP_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }

            _controlador.setEmp2("");
            if (CB_EMP_2.SelectedIndex != -1)
            {
                _controlador.setEmp2(CB_EMP_2.SelectedValue.ToString());
            }
        }
        private void CB_EMP_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }

            _controlador.setEmp3("");
            if (CB_EMP_3.SelectedIndex != -1)
            {
                _controlador.setEmp3(CB_EMP_3.SelectedValue.ToString());
            }
        }

        private void TB_CONT_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setContEmp_1(int.Parse(TB_CONT_1.Text));
            _modoInicializar = true;
            TB_UT_1.Text = _controlador.GetUt1.ToString("N2").Replace(".", "");
            TB_PN_1.Text = _controlador.GetPN1.ToString("N2").Replace(".", "");
            TB_PF_1.Text = _controlador.GetPF1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setUt_1(decimal.Parse(TB_UT_1.Text));
            _modoInicializar = true;
            TB_PN_1.Text = _controlador.GetPN1.ToString("N2").Replace(".", "");
            TB_PF_1.Text = _controlador.GetPF1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setPN_1(decimal.Parse(TB_PN_1.Text));
            _modoInicializar = true;
            TB_UT_1.Text = _controlador.GetUt1.ToString("N2").Replace(".", "");
            TB_PF_1.Text = _controlador.GetPF1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setPF_1(decimal.Parse(TB_PF_1.Text));
            _modoInicializar = true;
             TB_UT_1.Text = _controlador.GetUt1.ToString("N2").Replace(".", "");
             TB_PN_1.Text = _controlador.GetPN1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_1)
            {
                errorProvider1.SetError(TB_PN_1, "PRECIO INCORRECTO");
                e.Cancel = true; 
            }
            else 
            {
                errorProvider1.SetError(TB_PN_1, "");
            }
        }
        private void TB_PF_1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_1)
            {
                errorProvider1.SetError(TB_PF_1, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_1, "");
            }
        }


        private void TB_CONT_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setContEmp_2(int.Parse(TB_CONT_2.Text));
            _modoInicializar = true;
            TB_UT_2.Text = _controlador.GetUt2.ToString("N2").Replace(".", "");
            TB_PN_2.Text = _controlador.GetPN2.ToString("N2").Replace(".", "");
            TB_PF_2.Text = _controlador.GetPF2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setUt_2(decimal.Parse(TB_UT_2.Text));
            _modoInicializar = true;
            TB_PN_2.Text = _controlador.GetPN2.ToString("N2").Replace(".", "");
            TB_PF_2.Text = _controlador.GetPF2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setPN_2(decimal.Parse(TB_PN_2.Text));
            _modoInicializar = true;
            TB_UT_2.Text = _controlador.GetUt2.ToString("N2").Replace(".", "");
            TB_PF_2.Text = _controlador.GetPF2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_2)
            {
                errorProvider1.SetError(TB_PN_2, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_2, "");
            }
        }
        private void TB_PF_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setPF_2(decimal.Parse(TB_PF_2.Text));
            _modoInicializar = true;
            TB_UT_2.Text = _controlador.GetUt2.ToString("N2").Replace(".", "");
            TB_PN_2.Text = _controlador.GetPN2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_2)
            {
                errorProvider1.SetError(TB_PF_2, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_2, "");
            }
        }


        private void TB_CONT_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setContEmp_3(int.Parse(TB_CONT_3.Text));
            _modoInicializar = true;
            TB_UT_3.Text = _controlador.GetUt3.ToString("N2").Replace(".", "");
            TB_PN_3.Text = _controlador.GetPN3.ToString("N2").Replace(".", "");
            TB_PF_3.Text = _controlador.GetPF3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setUt_3(decimal.Parse(TB_UT_3.Text));
            _modoInicializar = true;
            TB_PN_3.Text = _controlador.GetPN3.ToString("N2").Replace(".", "");
            TB_PF_3.Text = _controlador.GetPF3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setPN_3(decimal.Parse(TB_PN_3.Text));
            _modoInicializar = true;
            TB_UT_3.Text = _controlador.GetUt3.ToString("N2").Replace(".", "");
            TB_PF_3.Text = _controlador.GetPF3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_3_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_3)
            {
                errorProvider1.SetError(TB_PF_3, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_3, "");
            }
        }
        private void TB_PF_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setPF_3(decimal.Parse(TB_PF_3.Text));
            _modoInicializar = true;
            TB_UT_3.Text = _controlador.GetUt3.ToString("N2").Replace(".", "");
            TB_PN_3.Text = _controlador.GetPN3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_3_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_3)
            {
                errorProvider1.SetError(TB_PF_3, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_3, "");
            }
        }

        private void L_TIT_UT_Click(object sender, EventArgs e)
        {
            ActivarTitulo(true, false,false);
        }
        private void L_TIT_PN_Click(object sender, EventArgs e)
        {
            ActivarTitulo(false, true, false);
        }
        private void L_TIT_PF_Click(object sender, EventArgs e)
        {
            ActivarTitulo(false, false, true);
        }
        private void ActivarTitulo(bool ut, bool pn, bool pf)
        {
            TB_UT_1.Enabled = ut;
            TB_UT_2.Enabled = ut;
            TB_UT_3.Enabled = ut;

            TB_PN_1.Enabled = pn;
            TB_PN_2.Enabled = pn;
            TB_PN_3.Enabled = pn;

            TB_PF_1.Enabled = pf;
            TB_PF_2.Enabled = pf;
            TB_PF_3.Enabled = pf;
        }
  
    }

}