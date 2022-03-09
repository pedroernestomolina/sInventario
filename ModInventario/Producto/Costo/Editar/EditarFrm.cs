using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Costo.Editar
{

    public partial class EditarFrm : Form
    {

        private Gestion _controlador;


        public EditarFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void EditarFrm_Load(object sender, EventArgs e)
        {
            MostratrCosto();

            L_PRODUCTO.Text = _controlador.Producto;
            L_TASA_CAMBIO.Text = _controlador.TasaCambioActual;
            L_COSTO.Text = _controlador.CostoUnitario;
            L_ADM_DIVISA.Text = _controlador.AdmDivisa;
            L_TASA_IVA.Text = _controlador.TasaIva;
            L_FECHA_ACT.Text = _controlador.FechaUltActCosto;
            L_EMPAQUE.Text = _controlador.EmpaqueContenido;

            panel4.Focus();
            if (_controlador.IsProductoAdmDivisa)
            {
                TB_COSTO_DIVISA_NETO.Focus();
                P_DOLLAR.Visible = true;
            }
            else 
            {
                P_DOLLAR.Visible = false;
                TB_COSTO_PROV_NETO.Focus();
            }
        }

        private void MostratrCosto()
        {
            TB_COSTO_PROV_NETO.Text = _controlador.CostoProv.EmpNeto.ToString("n2").Replace(".", "");
            TB_COSTO_PROV_FULL.Text = _controlador.CostoProv.EmpFull.ToString("n2").Replace(".", "");
            TB_COSTO_IMP_NETO.Text = _controlador.CostoImp.EmpNeto.ToString("n2").Replace(".", "");
            TB_COSTO_IMP_FULL.Text = _controlador.CostoImp.EmpFull.ToString("n2").Replace(".", "");
            TB_COSTO_VAR_NETO.Text = _controlador.CostoVario.EmpNeto.ToString("n2").Replace(".", "");
            TB_COSTO_VAR_FULL.Text = _controlador.CostoVario.EmpFull.ToString("n2").Replace(".", "");
            TB_COSTO_PROMEDIO_NETO.Text = _controlador.CostoPromedio.EmpNeto.ToString("n2").Replace(".", "");
            TB_COSTO_PROMEDIO_FULL.Text = _controlador.CostoPromedio.EmpFull.ToString("n2").Replace(".", "");
            TB_COSTO_DIVISA_NETO.Text = _controlador.CostoDivisa.EmpNeto.ToString("n2").Replace(".", "");
            TB_COSTO_DIVISA_FULL.Text = _controlador.CostoDivisa.EmpFull.ToString("n2").Replace(".", "");
            ActualizarCostoFinal();
            ActualizarCostoPromedio();

            var v=_controlador.IsProductoAdmDivisa;
            TB_COSTO_PROV_NETO.Enabled = !v;
            TB_COSTO_PROV_FULL.Enabled = !v;
            TB_COSTO_IMP_NETO.Enabled = !v;
            TB_COSTO_IMP_FULL.Enabled = !v;
            TB_COSTO_VAR_NETO.Enabled = !v;
            TB_COSTO_VAR_FULL.Enabled = !v;
            TB_COSTO_PROMEDIO_NETO.Enabled = !v;
            TB_COSTO_PROMEDIO_FULL.Enabled = !v;
            TB_COSTO_DIVISA_NETO.Enabled = v;
            TB_COSTO_DIVISA_FULL.Enabled = v;
        }

        void ActualizarCostoFinal()
        {
            L_COSTO_FINAL_NETO.Text = _controlador.CostoFinal.EmpNeto.ToString("n2");
            L_COSTO_FINAL_FULL.Text = _controlador.CostoFinal.EmpFull.ToString("n2");
            L_COSTO_FINAL_UND_NETO.Text = _controlador.CostoFinal.UndNeto.ToString("n2");
            L_COSTO_FINAL_UND_FULL.Text = _controlador.CostoFinal.UndFull.ToString("n2");
            TB_COSTO_DIVISA_NETO.Text = _controlador.CostoDivisa.EmpNeto.ToString("n2");
            TB_COSTO_DIVISA_FULL.Text = _controlador.CostoDivisa.EmpFull.ToString("n2");
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_COSTO_PROV_NETO_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_PROV_NETO.Text);
            _controlador.CostoProv.setNeto(valor);
            _controlador.CostoFinalRecalcula();
            TB_COSTO_PROV_FULL.Text = _controlador.CostoProv.EmpFull.ToString("n2").Replace(".", "");
            ActualizarCostoFinal();
        }

        private void TB_COSTO_PROV_FULL_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_PROV_FULL.Text);
            _controlador.CostoProv.setFull(valor);
            _controlador.CostoFinalRecalcula();
            TB_COSTO_PROV_NETO.Text = _controlador.CostoProv.EmpNeto.ToString("n2").Replace(".", "");
            ActualizarCostoFinal();
        }

        private void TB_COSTO_IMP_NETO_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_IMP_NETO.Text);
            _controlador.CostoImp.setNeto(valor);
            _controlador.CostoFinalRecalcula();
            TB_COSTO_IMP_FULL.Text = _controlador.CostoImp.EmpFull.ToString("n2").Replace(".", "");
            ActualizarCostoFinal();
        }

        private void TB_COSTO_IMP_FULL_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_IMP_FULL.Text);
            _controlador.CostoImp.setFull(valor);
            _controlador.CostoFinalRecalcula();
            TB_COSTO_IMP_NETO.Text = _controlador.CostoImp.EmpNeto.ToString("n2").Replace(".", "");
            ActualizarCostoFinal();
        }

        private void TB_COSTO_VAR_NETO_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_VAR_NETO.Text);
            _controlador.CostoVario.setNeto(valor);
            _controlador.CostoFinalRecalcula();
            TB_COSTO_VAR_FULL.Text = _controlador.CostoVario.EmpFull.ToString("n2").Replace(".", "");
            ActualizarCostoFinal();
        }

        private void TB_COSTO_VAR_FULL_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_VAR_FULL.Text);
            _controlador.CostoVario.setFull(valor);
            _controlador.CostoFinalRecalcula();
            TB_COSTO_VAR_NETO.Text = _controlador.CostoVario.EmpNeto.ToString("n2").Replace(".", "");
            ActualizarCostoFinal();

        }

        private void TB_COSTO_PROMEDIO_NETO_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_PROMEDIO_NETO.Text);
            _controlador.CostoPromedio.setNeto(valor);
            TB_COSTO_PROMEDIO_FULL.Text = _controlador.CostoPromedio.EmpFull.ToString("n2").Replace(".", "");
            ActualizarCostoPromedio();
        }

        private void TB_COSTO_PROMEDIO_FULL_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_PROMEDIO_FULL.Text);
            _controlador.CostoPromedio.setFull(valor);
            TB_COSTO_PROMEDIO_NETO.Text = _controlador.CostoPromedio.EmpNeto.ToString("n2").Replace(".", "");
            ActualizarCostoPromedio();
        }

        private void ActualizarCostoPromedio()
        {
            L_COSTO_PROMEDIO_UND_NETO.Text = _controlador.CostoPromedio.UndNeto.ToString("n2").Replace(".", "");
            L_COSTO_PROMEDIO_UND_FULL.Text = _controlador.CostoPromedio.UndFull.ToString("n2").Replace(".", "");
        }

        private void TB_COSTO_DIVISA_NETO_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_DIVISA_NETO.Text);
            _controlador.CostoDivisa.setNeto(valor);
            _controlador.RecalculaCosto();
            TB_COSTO_DIVISA_FULL.Text = _controlador.CostoDivisa.EmpFull.ToString("n2").Replace(".", "");
            ActualizarControlesCosto();
        }

        private void TB_COSTO_DIVISA_FULL_Leave(object sender, EventArgs e)
        {
            var valor = decimal.Parse(TB_COSTO_DIVISA_FULL.Text);
            _controlador.CostoDivisa.setFull(valor);
            _controlador.RecalculaCosto();
            TB_COSTO_DIVISA_NETO.Text = _controlador.CostoDivisa.EmpNeto.ToString("n2").Replace(".", "");
            ActualizarControlesCosto();
        }

        private void ActualizarControlesCosto()
        {
            TB_COSTO_PROV_NETO.Text = _controlador.CostoProv.EmpNeto.ToString("n2").Replace(".", "");
            TB_COSTO_PROV_FULL.Text = _controlador.CostoProv.EmpFull.ToString("n2").Replace(".", "");
            TB_COSTO_IMP_NETO.Text = _controlador.CostoImp.EmpNeto.ToString("n2").Replace(".", "");
            TB_COSTO_IMP_FULL.Text = _controlador.CostoImp.EmpFull.ToString("n2").Replace(".", "");
            TB_COSTO_VAR_NETO.Text = _controlador.CostoVario.EmpNeto.ToString("n2").Replace(".", "");
            TB_COSTO_VAR_FULL.Text = _controlador.CostoVario.EmpFull.ToString("n2").Replace(".", "");
            TB_COSTO_PROMEDIO_NETO.Text = _controlador.CostoPromedio.EmpNeto.ToString("n2").Replace(".", "");
            TB_COSTO_PROMEDIO_FULL.Text = _controlador.CostoPromedio.EmpFull.ToString("n2").Replace(".", "");
            ActualizarCostoFinal();
            ActualizarCostoPromedio();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
        }

        private void EditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_controlador.IsCerrarHabilitado;
            _controlador.InicializarIsCerrarHabilitado();
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