using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.EditarCambiar.ModoAdministrativo
{
    public partial class PrecioEditarFrm : Form
    {
        private IEditarAdm _controlador;


        public PrecioEditarFrm()
        {
            InitializeComponent();
        }


        public void setControlador(IEditarAdm ctr)
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
            L_TASA_CAMBIO.Text = _controlador.GetInfTasaCambioPrd.ToString("n3");
            L_ADM_DIVISA.Text = _controlador.GetInfAdmDivisaPrd;
            L_TASA_IVA.Text = _controlador.GetInfTasaIvaPrd.ToString("n2");
            L_COSTO_UNIDAD.Text = _controlador.GetInfCostoUndPrd.ToString("n2");
            L_FECHA_ULT_ACT.Text = _controlador.GetInfFechaUltActPrd;
            L_DIVISA.Visible = _controlador.GetEsAdmDivisaPrd;

            L_EMP_1.Text = _controlador.Vta1.Get_EmpaqueDesc;
            L_EMP_2.Text = _controlador.Vta2.Get_EmpaqueDesc;
            L_EMP_3.Text = _controlador.Vta3.Get_EmpaqueDesc;

            L_CONT_1.Text = "( " + _controlador.Vta1.Get_EmpaqueCont.ToString().Trim() + " )";
            L_CONT_2.Text = "( " + _controlador.Vta2.Get_EmpaqueCont.ToString().Trim() + " )";
            L_CONT_3.Text = "( " + _controlador.Vta3.Get_EmpaqueCont.ToString().Trim() + " )";

            TB_UT_1.Text = _controlador.Vta1.Get_UtilidadNueva.ToString("n2").Replace(".", "");
            TB_UT_2.Text = _controlador.Vta2.Get_UtilidadNueva.ToString("n2").Replace(".", "");
            TB_UT_3.Text = _controlador.Vta3.Get_UtilidadNueva.ToString("n2").Replace(".", "");

            TB_PN_1.Text = _controlador.Vta1.Get_Pneto.ToString("n2").Replace(".", "");
            TB_PN_2.Text = _controlador.Vta2.Get_Pneto.ToString("n2").Replace(".", "");
            TB_PN_3.Text = _controlador.Vta3.Get_Pneto.ToString("n2").Replace(".", "");

            L_NETO_1_OTRA.Text = _controlador.Vta1.Get_Pneto_OtraMoneda.ToString("n2");
            L_NETO_2_OTRA.Text = _controlador.Vta2.Get_Pneto_OtraMoneda.ToString("n2");
            L_NETO_3_OTRA.Text = _controlador.Vta3.Get_Pneto_OtraMoneda.ToString("n2");

            TB_PF_1.Text = _controlador.Vta1.Get_PFull.ToString("n2").Replace(".", "");
            TB_PF_2.Text = _controlador.Vta2.Get_PFull.ToString("n2").Replace(".", "");
            TB_PF_3.Text = _controlador.Vta3.Get_PFull.ToString("n2").Replace(".", "");

            L_FULL_1_OTRA.Text = _controlador.Vta1.Get_PFULL_OtraMoneda.ToString("n2");
            L_FULL_2_OTRA.Text = _controlador.Vta2.Get_PFULL_OtraMoneda.ToString("n2");
            L_FULL_3_OTRA.Text = _controlador.Vta3.Get_PFULL_OtraMoneda.ToString("n2");

            L_UT_ACTUAL_1.Text = _controlador.Vta1.Get_UtilidadActual.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_2.Text = _controlador.Vta2.Get_UtilidadActual.ToString("n2").Replace(".", "");
            L_UT_ACTUAL_3.Text = _controlador.Vta3.Get_UtilidadActual.ToString("n2").Replace(".", "");

            TB_UT_1.Enabled = false;
            TB_UT_2.Enabled = false;
            TB_UT_3.Enabled = false;

            TB_PN_1.Enabled = false;
            TB_PN_2.Enabled = false;
            TB_PN_3.Enabled = false;

            TB_PF_1.Enabled = false;
            TB_PF_2.Enabled = false;
            TB_PF_3.Enabled = false;

            _modoInicializar = false;
        }
        private void EditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void TB_UT_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Vta1.setUtilidad(decimal.Parse(TB_UT_1.Text));
            _modoInicializar = true;
            Vta1();
            _modoInicializar = false;
        }
        private void TB_UT_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Vta2.setUtilidad(decimal.Parse(TB_UT_2.Text));
            _modoInicializar = true;
            Vta2();
            _modoInicializar = false;
        }
        private void TB_UT_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Vta3.setUtilidad(decimal.Parse(TB_UT_3.Text));
            _modoInicializar = true;
            Vta3();
            _modoInicializar = false;
        }

        private void TB_PN_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Vta1.setPneto(decimal.Parse(TB_PN_1.Text));
            _modoInicializar = true;
            Vta1();
            _modoInicializar = false;
        }
        private void TB_PN_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Vta2.setPneto(decimal.Parse(TB_PN_2.Text));
            _modoInicializar = true;
            Vta2();
            _modoInicializar = false;
        }
        private void TB_PN_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Vta3.setPneto(decimal.Parse(TB_PN_3.Text));
            _modoInicializar = true;
            Vta3();
            _modoInicializar = false;
        }

        private void TB_PF_1_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Vta1.setPFull(decimal.Parse(TB_PF_1.Text));
            _modoInicializar = true;
            Vta1();
            _modoInicializar = false;
        }
        private void TB_PF_2_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Vta2.setPFull(decimal.Parse(TB_PF_2.Text));
            _modoInicializar = true;
            Vta2();
            _modoInicializar = false;
        }
        private void TB_PF_3_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Vta3.setPFull(decimal.Parse(TB_PF_3.Text));
            _modoInicializar = true;
            Vta3();
            _modoInicializar = false;
        }

        private void TB_PN_1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.Vta1.Get_ERROR)
            {
                errorProvider1.SetError(TB_PN_1, "PRECIO INCORRECTO");
                e.Cancel = true; 
            }
            else 
            {
                errorProvider1.SetError(TB_PN_1, "");
            }
        }
        private void TB_PN_2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.Vta2.Get_ERROR)
            {
                errorProvider1.SetError(TB_PN_2, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_2, "");
            }
        }
        private void TB_PN_3_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.Vta3.Get_ERROR)
            {
                errorProvider1.SetError(TB_PN_3, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PN_3, "");
            }
        }

        private void TB_PF_1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.Vta1.Get_ERROR)
            {
                errorProvider1.SetError(TB_PF_1, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_1, "");
            }
        }
        private void TB_PF_2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.Vta2.Get_ERROR)
            {
                errorProvider1.SetError(TB_PF_2, "PRECIO INCORRECTO");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TB_PF_2, "");
            }
        }
        private void TB_PF_3_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (_controlador.Vta3.Get_ERROR)
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


        private void BT_MODO_PRECIO_Click(object sender, EventArgs e)
        {
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void Procesar()
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
        private void Vta1()
        {
            var _culturaActual = CultureInfo.CurrentCulture;
            TB_UT_1.Text = _controlador.Vta1.Get_UtilidadNueva.ToString("N2", _culturaActual);
            TB_PN_1.Text = _controlador.Vta1.Get_Pneto.ToString("N2", _culturaActual);
            TB_PF_1.Text = _controlador.Vta1.Get_PFull.ToString("N2", _culturaActual);
            L_NETO_1_OTRA.Text = _controlador.Vta1.Get_Pneto_OtraMoneda.ToString("N2", _culturaActual);
            L_FULL_1_OTRA.Text = _controlador.Vta1.Get_PFULL_OtraMoneda.ToString("N2", _culturaActual);
        }
        private void Vta2()
        {
            var _culturaActual = CultureInfo.CurrentCulture;
            TB_UT_2.Text = _controlador.Vta2.Get_UtilidadNueva.ToString("N2", _culturaActual);
            TB_PN_2.Text = _controlador.Vta2.Get_Pneto.ToString("N2", _culturaActual);
            TB_PF_2.Text = _controlador.Vta2.Get_PFull.ToString("N2", _culturaActual);
            L_NETO_2_OTRA.Text = _controlador.Vta2.Get_Pneto_OtraMoneda.ToString("N2", _culturaActual);
            L_FULL_2_OTRA.Text = _controlador.Vta2.Get_PFULL_OtraMoneda.ToString("N2", _culturaActual);
        }
        private void Vta3()
        {
            var _culturaActual = CultureInfo.CurrentCulture;
            TB_UT_3.Text = _controlador.Vta3.Get_UtilidadNueva.ToString("N2", _culturaActual);
            TB_PN_3.Text = _controlador.Vta3.Get_Pneto.ToString("N2", _culturaActual);
            TB_PF_3.Text = _controlador.Vta3.Get_PFull.ToString("N2", _culturaActual);
            L_NETO_3_OTRA.Text = _controlador.Vta3.Get_Pneto_OtraMoneda.ToString("N2", _culturaActual);
            L_FULL_3_OTRA.Text = _controlador.Vta3.Get_PFULL_OtraMoneda.ToString("N2", _culturaActual);
        }
    }
}