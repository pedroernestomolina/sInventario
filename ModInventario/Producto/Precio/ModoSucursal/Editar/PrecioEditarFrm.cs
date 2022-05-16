using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.ModoSucursal.Editar
{
    public partial class PrecioEditarFrm : Form
    {


        private IEditar _controlador;


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
            CB_EMP_4.DisplayMember = "desc";
            CB_EMP_4.ValueMember = "id";
            CB_EMP_5.DisplayMember = "desc";
            CB_EMP_5.ValueMember = "id";
            //
            CB_EMP_M1.DisplayMember = "desc";
            CB_EMP_M1.ValueMember = "id";
            CB_EMP_M2.DisplayMember = "desc";
            CB_EMP_M2.ValueMember = "id";
            CB_EMP_M3.DisplayMember = "desc";
            CB_EMP_M3.ValueMember = "id";
            CB_EMP_M4.DisplayMember = "desc";
            CB_EMP_M4.ValueMember = "id";
            //
            CB_EMP_D1.DisplayMember = "desc";
            CB_EMP_D1.ValueMember = "id";
            CB_EMP_D2.DisplayMember = "desc";
            CB_EMP_D2.ValueMember = "id";
            CB_EMP_D3.DisplayMember = "desc";
            CB_EMP_D3.ValueMember = "id";
            CB_EMP_D4.DisplayMember = "desc";
            CB_EMP_D4.ValueMember = "id";
        }

        public void setControlador(IEditar ctr)
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
            L_DIVISA_M.Visible = _controlador.GetEsAdmDivisaPrd;


            L_PRECIO_1.Text = _controlador.GetDescPrecio1;
            L_PRECIO_2.Text = _controlador.GetDescPrecio2;
            L_PRECIO_3.Text = _controlador.GetDescPrecio3;
            L_PRECIO_4.Text = _controlador.GetDescPrecio4;
            L_PRECIO_5.Text = _controlador.GetDescPrecio5;
            //
            L_PRECIO_M1.Text = _controlador.GetDescPrecio1;
            L_PRECIO_M2.Text = _controlador.GetDescPrecio2;
            L_PRECIO_M3.Text = _controlador.GetDescPrecio3;
            L_PRECIO_M4.Text = _controlador.GetDescPrecio4;
            //
            L_PRECIO_D1.Text = _controlador.GetDescPrecio1;
            L_PRECIO_D2.Text = _controlador.GetDescPrecio2;
            L_PRECIO_D3.Text = _controlador.GetDescPrecio3;
            L_PRECIO_D4.Text = _controlador.GetDescPrecio4;

           
            CB_EMP_1.DataSource = _controlador.GetEmp1_Source;
            CB_EMP_2.DataSource = _controlador.GetEmp2_Source;
            CB_EMP_3.DataSource = _controlador.GetEmp3_Source;
            CB_EMP_4.DataSource = _controlador.GetEmp4_Source;
            CB_EMP_5.DataSource = _controlador.GetEmp5_Source;
            CB_EMP_1.SelectedValue = _controlador.GetEmp1_Id;
            CB_EMP_2.SelectedValue = _controlador.GetEmp2_Id;
            CB_EMP_3.SelectedValue = _controlador.GetEmp3_Id;
            CB_EMP_4.SelectedValue = _controlador.GetEmp4_Id;
            CB_EMP_5.SelectedValue = _controlador.GetEmp5_Id;
            //

            CB_EMP_M1.DataSource = _controlador.GetEmpM1_Source;
            CB_EMP_M2.DataSource = _controlador.GetEmpM2_Source;
            CB_EMP_M3.DataSource = _controlador.GetEmpM3_Source;
            CB_EMP_M4.DataSource = _controlador.GetEmpM4_Source;
            CB_EMP_M1.SelectedValue = _controlador.GetEmpM1_Id;
            CB_EMP_M2.SelectedValue = _controlador.GetEmpM2_Id;
            CB_EMP_M3.SelectedValue = _controlador.GetEmpM3_Id;
            CB_EMP_M4.SelectedValue = _controlador.GetEmpM4_Id;
            //

            CB_EMP_D1.DataSource = _controlador.GetEmpD1_Source;
            CB_EMP_D2.DataSource = _controlador.GetEmpD2_Source;
            CB_EMP_D3.DataSource = _controlador.GetEmpD3_Source;
            CB_EMP_D4.DataSource = _controlador.GetEmpD4_Source;
            CB_EMP_D1.SelectedValue = _controlador.GetEmpD1_Id;
            CB_EMP_D2.SelectedValue = _controlador.GetEmpD2_Id;
            CB_EMP_D3.SelectedValue = _controlador.GetEmpD3_Id;
            CB_EMP_D4.SelectedValue = _controlador.GetEmpD4_Id;

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

            TB_CONT_4.Text = _controlador.GetCont4.ToString();
            TB_UT_4.Text = _controlador.GetUt4.ToString("n2").Replace(".", "");
            TB_PN_4.Text = _controlador.GetPN4.ToString("n2").Replace(".", "");
            TB_PF_4.Text = _controlador.GetPF4.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_4.Text = _controlador.GetUtActual4.ToString("n2").Replace(".", "");

            TB_CONT_5.Text = _controlador.GetCont5.ToString();
            TB_UT_5.Text = _controlador.GetUt5.ToString("n2").Replace(".", "");
            TB_PN_5.Text = _controlador.GetPN5.ToString("n2").Replace(".", "");
            TB_PF_5.Text = _controlador.GetPF5.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_5.Text = _controlador.GetUtActual5.ToString("n2").Replace(".", "");


            TB_CONT_M1.Text = _controlador.GetContM1.ToString();
            TB_UT_M1.Text = _controlador.GetUtM1.ToString("n2").Replace(".", "");
            TB_PN_M1.Text = _controlador.GetPNM1.ToString("n2").Replace(".", "");
            TB_PF_M1.Text = _controlador.GetPFM1.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_M1.Text = _controlador.GetUtActualM1.ToString("n2").Replace(".", "");

            TB_CONT_M2.Text = _controlador.GetContM2.ToString();
            TB_UT_M2.Text = _controlador.GetUtM2.ToString("n2").Replace(".", "");
            TB_PN_M2.Text = _controlador.GetPNM2.ToString("n2").Replace(".", "");
            TB_PF_M2.Text = _controlador.GetPFM2.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_M2.Text = _controlador.GetUtActualM2.ToString("n2").Replace(".", "");

            TB_CONT_M3.Text = _controlador.GetContM3.ToString();
            TB_UT_M3.Text = _controlador.GetUtM3.ToString("n2").Replace(".", "");
            TB_PN_M3.Text = _controlador.GetPNM3.ToString("n2").Replace(".", "");
            TB_PF_M3.Text = _controlador.GetPFM3.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_M3.Text = _controlador.GetUtActualM3.ToString("n2").Replace(".", "");

            TB_CONT_M4.Text = _controlador.GetContM4.ToString();
            TB_UT_M4.Text = _controlador.GetUtM4.ToString("n2").Replace(".", "");
            TB_PN_M4.Text = _controlador.GetPNM4.ToString("n2").Replace(".", "");
            TB_PF_M4.Text = _controlador.GetPFM4.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_M4.Text = _controlador.GetUtActualM4.ToString("n2").Replace(".", "");
            

            TB_CONT_D1.Text = _controlador.GetContD1.ToString();
            TB_UT_D1.Text = _controlador.GetUtD1.ToString("n2").Replace(".", "");
            TB_PN_D1.Text = _controlador.GetPND1.ToString("n2").Replace(".", "");
            TB_PF_D1.Text = _controlador.GetPFD1.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_D1.Text = _controlador.GetUtActualD1.ToString("n2").Replace(".", "");

            TB_CONT_D2.Text = _controlador.GetContD2.ToString();
            TB_UT_D2.Text = _controlador.GetUtD2.ToString("n2").Replace(".", "");
            TB_PN_D2.Text = _controlador.GetPND2.ToString("n2").Replace(".", "");
            TB_PF_D2.Text = _controlador.GetPFD2.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_D2.Text = _controlador.GetUtActualD2.ToString("n2").Replace(".", "");

            TB_CONT_D3.Text = _controlador.GetContD3.ToString();
            TB_UT_D3.Text = _controlador.GetUtD3.ToString("n2").Replace(".", "");
            TB_PN_D3.Text = _controlador.GetPND3.ToString("n2").Replace(".", "");
            TB_PF_D3.Text = _controlador.GetPFD3.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_D3.Text = _controlador.GetUtActualD3.ToString("n2").Replace(".", "");

            TB_CONT_D4.Text = _controlador.GetContD4.ToString();
            TB_UT_D4.Text = _controlador.GetUtD4.ToString("n2").Replace(".", "");
            TB_PN_D4.Text = _controlador.GetPND4.ToString("n2").Replace(".", "");
            TB_PF_D4.Text = _controlador.GetPFD4.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_D4.Text = _controlador.GetUtActualD4.ToString("n2").Replace(".", "");


            TB_CONT_1.Enabled = true;
            TB_CONT_2.Enabled = true;
            TB_CONT_3.Enabled = true;
            TB_CONT_4.Enabled = true;
            TB_CONT_5.Enabled = true;

            TB_UT_1.Enabled = false;
            TB_UT_2.Enabled = false;
            TB_UT_3.Enabled = false;
            TB_UT_4.Enabled = false;
            TB_UT_5.Enabled = false;

            TB_PN_1.Enabled = false;
            TB_PN_2.Enabled = false;
            TB_PN_3.Enabled = false;
            TB_PN_4.Enabled = false;
            TB_PN_5.Enabled = false;

            TB_PF_1.Enabled = false;
            TB_PF_2.Enabled = false;
            TB_PF_3.Enabled = false;
            TB_PF_4.Enabled = false;
            TB_PF_5.Enabled = false;

            CB_EMP_1.Enabled = true;
            CB_EMP_2.Enabled = true;
            CB_EMP_3.Enabled = true;
            CB_EMP_4.Enabled = true;
            CB_EMP_5.Enabled = true;

            //
            TB_UT_M1.Enabled = false;
            TB_UT_M2.Enabled = false;
            TB_UT_M3.Enabled = false;
            TB_UT_M4.Enabled = false;

            TB_PN_M1.Enabled = false;
            TB_PN_M2.Enabled = false;
            TB_PN_M3.Enabled = false;
            TB_PN_M4.Enabled = false;

            TB_PF_M1.Enabled = false;
            TB_PF_M2.Enabled = false;
            TB_PF_M3.Enabled = false;
            TB_PF_M4.Enabled = false;

            //
            TB_UT_D1.Enabled = false;
            TB_UT_D2.Enabled = false;
            TB_UT_D3.Enabled = false;
            TB_UT_D4.Enabled = false;

            TB_PN_D1.Enabled = false;
            TB_PN_D2.Enabled = false;
            TB_PN_D3.Enabled = false;
            TB_PN_D4.Enabled = false;

            TB_PF_D1.Enabled = false;
            TB_PF_D2.Enabled = false;
            TB_PF_D3.Enabled = false;
            TB_PF_D4.Enabled = false;


            //errorProvider1.SetError(TB_NETO_1, "");
            //errorProvider1.SetError(TB_NETO_2, "");
            //errorProvider1.SetError(TB_NETO_3, "");
            //errorProvider1.SetError(TB_NETO_4, "");
            //errorProvider1.SetError(TB_NETO_5, "");
            //errorProvider1.SetError(TB_NETO_MAY_1, "");
            //errorProvider1.SetError(TB_NETO_MAY_2, "");
            //errorProvider1.SetError(TB_NETO_MAY_3, "");
            //errorProvider1.SetError(TB_NETO_MAY_4, "");

            //errorProvider1.SetError(TB_FULL_1, "");
            //errorProvider1.SetError(TB_FULL_2, "");
            //errorProvider1.SetError(TB_FULL_3, "");
            //errorProvider1.SetError(TB_FULL_4, "");
            //errorProvider1.SetError(TB_FULL_5, "");
            //errorProvider1.SetError(TB_FULL_MAY_1, "");
            //errorProvider1.SetError(TB_FULL_MAY_2, "");
            //errorProvider1.SetError(TB_FULL_MAY_3, "");
            //errorProvider1.SetError(TB_FULL_MAY_4, "");

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
            _controlador.Procesar();
            if (_controlador.IsProcesarIsOk) 
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
            if (_controlador.IsAbandonarIsOk) 
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
            if (_controlador.IsAbandonarIsOk || _controlador.IsProcesarIsOk) 
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
        private void CB_EMP_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }

            _controlador.setEmp4("");
            if (CB_EMP_4.SelectedIndex != -1)
            {
                _controlador.setEmp4(CB_EMP_4.SelectedValue.ToString());
            }
        }
        private void CB_EMP_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }

            _controlador.setEmp5("");
            if (CB_EMP_5.SelectedIndex != -1)
            {
                _controlador.setEmp5(CB_EMP_5.SelectedValue.ToString());
            }
        }

        private void CB_EMPAQUE_MAY_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true) 
            { return; }
            _controlador.setEmpM1("");
            if (CB_EMP_M1.SelectedIndex != -1)
            {
                _controlador.setEmpM1(CB_EMP_M1.SelectedValue.ToString());
            }
        }
        private void CB_EMP_M2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }
            _controlador.setEmpM2("");
            if (CB_EMP_M2.SelectedIndex != -1)
            {
                _controlador.setEmpM2(CB_EMP_M2.SelectedValue.ToString());
            }
        }
        private void CB_EMP_M3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }
            _controlador.setEmpM3("");
            if (CB_EMP_M3.SelectedIndex != -1)
            {
                _controlador.setEmpM3(CB_EMP_M3.SelectedValue.ToString());
            }
        }
        private void CB_EMP_M4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }
            _controlador.setEmpM4("");
            if (CB_EMP_M4.SelectedIndex != -1)
            {
                _controlador.setEmpM4(CB_EMP_M4.SelectedValue.ToString());
            }
        }

        private void TB_CONT_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_1(int.Parse(TB_CONT_1.Text));
        }
        private void TB_UT_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) 
            {
                return;
            }
            _controlador.setUt_1(decimal.Parse(TB_UT_1.Text));
            _modoInicializar = true;
            TB_PN_1.Text = _controlador.GetPN1.ToString("N2").Replace(".", "");
            TB_PF_1.Text = _controlador.GetPF1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_1(decimal.Parse(TB_PN_1.Text));
            _modoInicializar = true;
            TB_UT_1.Text = _controlador.GetUt1.ToString("N2").Replace(".", "");
            TB_PF_1.Text = _controlador.GetPF1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
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
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_2(int.Parse(TB_CONT_2.Text));
        }
        private void TB_UT_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_2(decimal.Parse(TB_UT_2.Text));
            _modoInicializar = true;
            TB_PN_2.Text = _controlador.GetPN2.ToString("N2").Replace(".", "");
            TB_PF_2.Text = _controlador.GetPF2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
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
            if (_modoInicializar)
            {
                return;
            }
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
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_3(int.Parse(TB_CONT_3.Text));
        }
        private void TB_UT_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_3(decimal.Parse(TB_UT_3.Text));
            _modoInicializar = true;
            TB_PN_3.Text = _controlador.GetPN3.ToString("N2").Replace(".", "");
            TB_PF_3.Text = _controlador.GetPF3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
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
            if (_modoInicializar)
            {
                return;
            }
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

        private void TB_CONT_4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_4(int.Parse(TB_CONT_4.Text));
        }
        private void TB_UT_4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_4(decimal.Parse(TB_UT_4.Text));
            _modoInicializar = true;
            TB_PN_4.Text = _controlador.GetPN4.ToString("N2").Replace(".", "");
            TB_PF_4.Text = _controlador.GetPF4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_4(decimal.Parse(TB_PN_4.Text));
            _modoInicializar = true;
            TB_UT_4.Text = _controlador.GetUt4.ToString("N2").Replace(".", "");
            TB_PF_4.Text = _controlador.GetPF4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_4_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_4)
            {
                errorProvider1.SetError(TB_PN_4, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_4, "");
            }
        }
        private void TB_PF_4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_4(decimal.Parse(TB_PF_4.Text));
            _modoInicializar = true;
            TB_UT_4.Text = _controlador.GetUt4.ToString("N2").Replace(".", "");
            TB_PN_4.Text = _controlador.GetPN4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_4_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_4)
            {
                errorProvider1.SetError(TB_PF_4, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_4, "");
            }
        }


        private void TB_CONT_5_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_5(int.Parse(TB_CONT_5.Text));
        }
        private void TB_UT_5_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_5(decimal.Parse(TB_UT_5.Text));
            _modoInicializar = true;
            TB_PN_5.Text = _controlador.GetPN5.ToString("N2").Replace(".", "");
            TB_PF_5.Text = _controlador.GetPF5.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_5_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_5(decimal.Parse(TB_PN_5.Text));
            _modoInicializar = true;
            TB_UT_5.Text = _controlador.GetUt5.ToString("N2").Replace(".", "");
            TB_PF_5.Text = _controlador.GetPF5.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_5_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_5)
            {
                errorProvider1.SetError(TB_PN_5, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_5, "");
            }
        }
        private void TB_PF_5_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_5(decimal.Parse(TB_PF_5.Text));
            _modoInicializar = true;
            TB_UT_5.Text = _controlador.GetUt5.ToString("N2").Replace(".", "");
            TB_PN_5.Text = _controlador.GetPN5.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_5_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_5)
            {
                errorProvider1.SetError(TB_PF_5, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_5, "");
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
            TB_UT_4.Enabled = ut;
            TB_UT_5.Enabled = ut;

            TB_PN_1.Enabled = pn;
            TB_PN_2.Enabled = pn;
            TB_PN_3.Enabled = pn;
            TB_PN_4.Enabled = pn;
            TB_PN_5.Enabled = pn;

            TB_PF_1.Enabled = pf;
            TB_PF_2.Enabled = pf;
            TB_PF_3.Enabled = pf;
            TB_PF_4.Enabled = pf;
            TB_PF_5.Enabled = pf;
        }


        private void L_TIT_UT_M_Click(object sender, EventArgs e)
        {
            ActivarTitulo_M(true, false, false);
        }
        private void L_TIT_PN_M_Click(object sender, EventArgs e)
        {
            ActivarTitulo_M(false, true,false);
        }
        private void L_TIT_PF_M_Click(object sender, EventArgs e)
        {
            ActivarTitulo_M(false, false, true);
        }
        private void ActivarTitulo_M(bool ut, bool pn, bool pf)
        {
            TB_UT_M1.Enabled = ut;
            TB_UT_M2.Enabled = ut;
            TB_UT_M3.Enabled = ut;
            TB_UT_M4.Enabled = ut;

            TB_PN_M1.Enabled = pn;
            TB_PN_M2.Enabled = pn;
            TB_PN_M3.Enabled = pn;
            TB_PN_M4.Enabled = pn;

            TB_PF_M1.Enabled = pf;
            TB_PF_M2.Enabled = pf;
            TB_PF_M3.Enabled = pf;
            TB_PF_M4.Enabled = pf;
        }


        private void TB_CONT_M1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_M1(int.Parse(TB_CONT_M1.Text));
            _modoInicializar = true;
            TB_UT_M1.Text = _controlador.GetUtM1.ToString("N2").Replace(".", "");
            TB_PN_M1.Text = _controlador.GetPNM1.ToString("N2").Replace(".", "");
            TB_PF_M1.Text = _controlador.GetPFM1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_M1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_M1(decimal.Parse(TB_UT_M1.Text));
            _modoInicializar = true;
            TB_PN_M1.Text = _controlador.GetPNM1.ToString("N2").Replace(".", "");
            TB_PF_M1.Text = _controlador.GetPFM1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_M1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_M1(decimal.Parse(TB_PN_M1.Text));
            _modoInicializar = true;
            TB_UT_M1.Text = _controlador.GetUtM1.ToString("N2").Replace(".", "");
            TB_PF_M1.Text = _controlador.GetPFM1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_M1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_M1)
            {
                errorProvider1.SetError(TB_PN_M1, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_M1, "");
            }
        }
        private void TB_PF_M1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_M1(decimal.Parse(TB_PF_M1.Text));
            _modoInicializar = true;
            TB_UT_M1.Text = _controlador.GetUtM1.ToString("N2").Replace(".", "");
            TB_PN_M1.Text = _controlador.GetPNM1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_M1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_M1)
            {
                errorProvider1.SetError(TB_PF_M1, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_M1, "");
            }
        }


        private void TB_CONT_M2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_M2(int.Parse(TB_CONT_M2.Text));
            _modoInicializar = true;
            TB_UT_M2.Text = _controlador.GetUtM2.ToString("N2").Replace(".", "");
            TB_PN_M2.Text = _controlador.GetPNM2.ToString("N2").Replace(".", "");
            TB_PF_M2.Text = _controlador.GetPFM2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_M2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_M2(decimal.Parse(TB_UT_M2.Text));
            _modoInicializar = true;
            TB_PN_M2.Text = _controlador.GetPNM2.ToString("N2").Replace(".", "");
            TB_PF_M2.Text = _controlador.GetPFM2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_M2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_M2(decimal.Parse(TB_PN_M2.Text));
            _modoInicializar = true;
            TB_UT_M2.Text = _controlador.GetUtM2.ToString("N2").Replace(".", "");
            TB_PF_M2.Text = _controlador.GetPFM2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_M2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_M2)
            {
                errorProvider1.SetError(TB_PN_M2, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_M2, "");
            }
        }
        private void TB_PF_M2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_M2(decimal.Parse(TB_PF_M2.Text));
            _modoInicializar = true;
            TB_UT_M2.Text = _controlador.GetUtM2.ToString("N2").Replace(".", "");
            TB_PN_M2.Text = _controlador.GetPNM2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_M2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_M2)
            {
                errorProvider1.SetError(TB_PF_M2, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_M2, "");
            }
        }


        private void TB_CONT_M3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_M3(int.Parse(TB_CONT_M3.Text));
            _modoInicializar = true;
            TB_UT_M3.Text = _controlador.GetUtM3.ToString("N2").Replace(".", "");
            TB_PN_M3.Text = _controlador.GetPNM3.ToString("N2").Replace(".", "");
            TB_PF_M3.Text = _controlador.GetPFM3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_M3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_M3(decimal.Parse(TB_UT_M3.Text));
            _modoInicializar = true;
            TB_PN_M3.Text = _controlador.GetPNM3.ToString("N2").Replace(".", "");
            TB_PF_M3.Text = _controlador.GetPFM3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_M3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_M3(decimal.Parse(TB_PN_M3.Text));
            _modoInicializar = true;
            TB_UT_M3.Text = _controlador.GetUtM3.ToString("N2").Replace(".", "");
            TB_PF_M3.Text = _controlador.GetPFM3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_M3_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_M3)
            {
                errorProvider1.SetError(TB_PN_M3, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_M3, "");
            }
        }
        private void TB_PF_M3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_M3(decimal.Parse(TB_PF_M3.Text));
            _modoInicializar = true;
            TB_UT_M3.Text = _controlador.GetUtM3.ToString("N2").Replace(".", "");
            TB_PN_M3.Text = _controlador.GetPNM3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_M3_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_M3)
            {
                errorProvider1.SetError(TB_PF_M3, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_M3, "");
            }
        }


        private void TB_CONT_M4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_M4(int.Parse(TB_CONT_M4.Text));
            _modoInicializar = true;
            TB_UT_M4.Text = _controlador.GetUtM4.ToString("N2").Replace(".", "");
            TB_PN_M4.Text = _controlador.GetPNM4.ToString("N2").Replace(".", "");
            TB_PF_M4.Text = _controlador.GetPFM4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_M4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_M4(decimal.Parse(TB_UT_M4.Text));
            _modoInicializar = true;
            TB_PN_M4.Text = _controlador.GetPNM4.ToString("N2").Replace(".", "");
            TB_PF_M4.Text = _controlador.GetPFM4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_M4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_M4(decimal.Parse(TB_PN_M4.Text));
            _modoInicializar = true;
            TB_UT_M4.Text = _controlador.GetUtM4.ToString("N2").Replace(".", "");
            TB_PF_M4.Text = _controlador.GetPFM4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_M4_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_M4)
            {
                errorProvider1.SetError(TB_PN_M4, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_M4, "");
            }
        }
        private void TB_PF_M4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_M4(decimal.Parse(TB_PF_M4.Text));
            _modoInicializar = true;
            TB_UT_M4.Text = _controlador.GetUtM4.ToString("N2").Replace(".", "");
            TB_PN_M4.Text = _controlador.GetPNM4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_M4_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_M4)
            {
                errorProvider1.SetError(TB_PF_M4, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_M4, "");
            }
        }


        //
        private void L_TIT_UT_D_Click(object sender, EventArgs e)
        {
            ActivarTitulo_D(true, false, false);
        }
        private void L_TIT_PN_D_Click(object sender, EventArgs e)
        {
            ActivarTitulo_D(false, true,false);
        }
        private void L_TIT_PF_D_Click(object sender, EventArgs e)
        {
            ActivarTitulo_D(false, false, true);
        }
        private void ActivarTitulo_D(bool ut, bool pn, bool pf)
        {
            TB_UT_D1.Enabled = ut;
            TB_UT_D2.Enabled = ut;
            TB_UT_D3.Enabled = ut;
            TB_UT_D4.Enabled = ut;

            TB_PN_D1.Enabled = pn;
            TB_PN_D2.Enabled = pn;
            TB_PN_D3.Enabled = pn;
            TB_PN_D4.Enabled = pn;

            TB_PF_D1.Enabled = pf;
            TB_PF_D2.Enabled = pf;
            TB_PF_D3.Enabled = pf;
            TB_PF_D4.Enabled = pf;
        }



        private void CB_EMP_D1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }
            _controlador.setEmpD1("");
            if (CB_EMP_D1.SelectedIndex != -1)
            {
                _controlador.setEmpD1(CB_EMP_D1.SelectedValue.ToString());
            }
        }
        private void CB_EMP_D2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }
            _controlador.setEmpD2("");
            if (CB_EMP_D2.SelectedIndex != -1)
            {
                _controlador.setEmpD2(CB_EMP_D2.SelectedValue.ToString());
            }
        }
        private void CB_EMP_D3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }
            _controlador.setEmpD3("");
            if (CB_EMP_D3.SelectedIndex != -1)
            {
                _controlador.setEmpD3(CB_EMP_D3.SelectedValue.ToString());
            }
        }
        private void CB_EMP_D4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar == true)
            { return; }
            _controlador.setEmpD4("");
            if (CB_EMP_D4.SelectedIndex != -1)
            {
                _controlador.setEmpD4(CB_EMP_D4.SelectedValue.ToString());
            }
        }

        private void TB_CONT_D1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_D1(int.Parse(TB_CONT_D1.Text));
            _modoInicializar = true;
            TB_UT_D1.Text = _controlador.GetUtD1.ToString("N2").Replace(".", "");
            TB_PN_D1.Text = _controlador.GetPND1.ToString("N2").Replace(".", "");
            TB_PF_D1.Text = _controlador.GetPFD1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_CONT_D2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_D2(int.Parse(TB_CONT_D2.Text));
            _modoInicializar = true;
            TB_UT_D2.Text = _controlador.GetUtD2.ToString("N2").Replace(".", "");
            TB_PN_D2.Text = _controlador.GetPND2.ToString("N2").Replace(".", "");
            TB_PF_D2.Text = _controlador.GetPFD2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_CONT_D3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_D3(int.Parse(TB_CONT_D3.Text));
            _modoInicializar = true;
            TB_UT_D3.Text = _controlador.GetUtD3.ToString("N2").Replace(".", "");
            TB_PN_D3.Text = _controlador.GetPND3.ToString("N2").Replace(".", "");
            TB_PF_D3.Text = _controlador.GetPFD3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_CONT_D4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setContEmp_D4(int.Parse(TB_CONT_D4.Text));
            _modoInicializar = true;
            TB_UT_D4.Text = _controlador.GetUtD4.ToString("N2").Replace(".", "");
            TB_PN_D4.Text = _controlador.GetPND4.ToString("N2").Replace(".", "");
            TB_PF_D4.Text = _controlador.GetPFD4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }

        private void TB_UT_D1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_D1(decimal.Parse(TB_UT_D1.Text));
            _modoInicializar = true;
            TB_PN_D1.Text = _controlador.GetPND1.ToString("N2").Replace(".", "");
            TB_PF_D1.Text = _controlador.GetPFD1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_D2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_D2(decimal.Parse(TB_UT_D2.Text));
            _modoInicializar = true;
            TB_PN_D2.Text = _controlador.GetPND2.ToString("N2").Replace(".", "");
            TB_PF_D2.Text = _controlador.GetPFD2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_D3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_D3(decimal.Parse(TB_UT_D3.Text));
            _modoInicializar = true;
            TB_PN_D3.Text = _controlador.GetPND3.ToString("N2").Replace(".", "");
            TB_PF_D3.Text = _controlador.GetPFD3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_UT_D4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setUt_D4(decimal.Parse(TB_UT_D4.Text));
            _modoInicializar = true;
            TB_PN_D4.Text = _controlador.GetPND4.ToString("N2").Replace(".", "");
            TB_PF_D4.Text = _controlador.GetPFD4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }

        private void TB_PN_D1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_D1(decimal.Parse(TB_PN_D1.Text));
            _modoInicializar = true;
            TB_UT_D1.Text = _controlador.GetUtD1.ToString("N2").Replace(".", "");
            TB_PF_D1.Text = _controlador.GetPFD1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_D2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_D2(decimal.Parse(TB_PN_D2.Text));
            _modoInicializar = true;
            TB_UT_D2.Text = _controlador.GetUtD2.ToString("N2").Replace(".", "");
            TB_PF_D2.Text = _controlador.GetPFD2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_D3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_D3(decimal.Parse(TB_PN_D3.Text));
            _modoInicializar = true;
            TB_UT_D3.Text = _controlador.GetUtD3.ToString("N2").Replace(".", "");
            TB_PF_D3.Text = _controlador.GetPFD3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PN_D4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPN_D4(decimal.Parse(TB_PN_D4.Text));
            _modoInicializar = true;
            TB_UT_D4.Text = _controlador.GetUtD4.ToString("N2").Replace(".", "");
            TB_PF_D4.Text = _controlador.GetPFD4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }

        private void TB_PN_D1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_D1)
            {
                errorProvider1.SetError(TB_PN_D1, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_D1, "");
            }
        }
        private void TB_PN_D2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_D2)
            {
                errorProvider1.SetError(TB_PN_D2, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_D2, "");
            }
        }
        private void TB_PN_D3_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_D3)
            {
                errorProvider1.SetError(TB_PN_D3, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_D3, "");
            }
        }
        private void TB_PN_D4_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_D4)
            {
                errorProvider1.SetError(TB_PN_D4, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_D4, "");
            }
        }

        private void TB_PF_D1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_D1(decimal.Parse(TB_PF_D1.Text));
            _modoInicializar = true;
            TB_UT_D1.Text = _controlador.GetUtD1.ToString("N2").Replace(".", "");
            TB_PN_D1.Text = _controlador.GetPND1.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_D2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_D2(decimal.Parse(TB_PF_D2.Text));
            _modoInicializar = true;
            TB_UT_D2.Text = _controlador.GetUtD2.ToString("N2").Replace(".", "");
            TB_PN_D2.Text = _controlador.GetPND2.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_D3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_D3(decimal.Parse(TB_PF_D3.Text));
            _modoInicializar = true;
            TB_UT_D3.Text = _controlador.GetUtD3.ToString("N2").Replace(".", "");
            TB_PN_D3.Text = _controlador.GetPND3.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }
        private void TB_PF_D4_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
            {
                return;
            }
            _controlador.setPF_D4(decimal.Parse(TB_PF_D4.Text));
            _modoInicializar = true;
            TB_UT_D4.Text = _controlador.GetUtD4.ToString("N2").Replace(".", "");
            TB_PN_D4.Text = _controlador.GetPND4.ToString("N2").Replace(".", "");
            _modoInicializar = false;
        }

        private void TB_PF_D1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_D1)
            {
                errorProvider1.SetError(TB_PF_D1, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_D1, "");
            }
        }
        private void TB_PF_D2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_D2)
            {
                errorProvider1.SetError(TB_PF_D2, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_D2, "");
            }
        }
        private void TB_PF_D3_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_D3)
            {
                errorProvider1.SetError(TB_PF_D3, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_D3, "");
            }
        }
        private void TB_PF_D4_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.ERR_D4)
            {
                errorProvider1.SetError(TB_PF_D4, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_D4, "");
            }
        }
    
    }

}