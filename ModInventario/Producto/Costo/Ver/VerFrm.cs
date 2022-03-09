using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Costo.Ver
{

    public partial class VerFrm : Form
    {

        private Gestion _controlador; 


        public VerFrm()
        {
            InitializeComponent();
        }

        private void VerFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.Data.Producto;
            L_TASA_CAMBIO.Text = _controlador.Data.TasaCambioActual;
            L_COSTO.Text = _controlador.Data.CostoUnitario;
            L_ADM_DIVISA.Text = _controlador.Data.AdmDivisa;
            L_TASA_IVA.Text = _controlador.Data.TasaIva;
            L_FECHA_ACT.Text = _controlador.Data.FechaUltActCosto;
            L_EMPAQUE.Text = _controlador.Data.EmpaqueContenido;

            L_PROV_NETO.Text = _controlador.Data.CostoProveedor.EmpNeto.ToString("n2");
            L_PROV_FULL.Text = _controlador.Data.CostoProveedor.EmpFull.ToString("n2");
            L_IMP_NETO.Text = _controlador.Data.CostoImportacion.EmpNeto.ToString("n2");
            L_IMP_FULL.Text = _controlador.Data.CostoImportacion.EmpFull.ToString("n2");
            L_VARIO_NETO.Text = _controlador.Data.CostoVario.EmpNeto.ToString("n2");
            L_VARIO_FULL.Text = _controlador.Data.CostoVario.EmpFull.ToString("n2");
            L_DIVISA_NETO.Text = _controlador.Data.CostoDivisa.EmpNeto.ToString("n2");
            L_DIVISA_FULL.Text = _controlador.Data.CostoDivisa.EmpFull.ToString("n2");

            L_COSTO_FINAL_NETO.Text = _controlador.Data.CostoFinal.EmpNeto.ToString("n2");
            L_COSTO_FINAL_FULL.Text = _controlador.Data.CostoFinal.EmpFull.ToString("n2");
            L_COSTO_FINAL_UND_NETO.Text = _controlador.Data.CostoFinal.UndNeto.ToString("n2");
            L_COSTO_FINAL_UND_FULL.Text = _controlador.Data.CostoFinal.UndFull.ToString("n2");

            L_COSTO_PROMEDIO_NETO.Text = _controlador.Data.CostoPromedio.EmpNeto.ToString("n2");
            L_COSTO_PROMEDIO_FULL.Text = _controlador.Data.CostoPromedio.EmpFull.ToString("n2");
            L_COSTO_PROMEDIO_UND_NETO.Text = _controlador.Data.CostoPromedio.UndNeto.ToString("n2");
            L_COSTO_PROMEDIO_UND_FULL.Text = _controlador.Data.CostoPromedio.UndFull.ToString("n2");

            panel4.Focus();
            if (_controlador.Data.IsAdmDivisa)
            {
                P_DOLLAR.Visible = true;
            }
            else
            {
                P_DOLLAR.Visible = false;
            }
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
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