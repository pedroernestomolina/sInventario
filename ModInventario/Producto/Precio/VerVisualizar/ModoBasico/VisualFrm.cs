using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.VerVisualizar.ModoBasico
{

    public partial class VisualFrm : Form
    {

        private IVisualBasico _controlador;


        public VisualFrm()
        {
            InitializeComponent();
        }

        public void setControlador(IVisualBasico ctr)
        {
            _controlador = ctr;
        }

        private void VisualFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.GetProductoInfo;
            L_TASA_CAMBIO.Text = _controlador.GetTasaCambio.ToString("n3");
            L_METODO.Text = _controlador.GetMetodoCalculoUtilidad;
            L_ADM_DIVISA.Text = _controlador.GetProductoAdmDivisa;
            L_TASA_IVA.Text = _controlador.GetProductoIva;

            L_EMP_1_1.Text = _controlador.Emp1_1.empaque;
            L_EMP_1_2.Text = _controlador.Emp1_2.empaque;
            L_EMP_1_3.Text = _controlador.Emp1_3.empaque;

            L_CONT_1_1.Text = _controlador.Emp1_1.contenido.ToString(); 
            L_CONT_1_2.Text = _controlador.Emp1_2.contenido.ToString(); 
            L_CONT_1_3.Text = _controlador.Emp1_3.contenido.ToString(); 

            L_UT_1_1.Text = _controlador.Emp1_1.utilidad.ToString("n2") + "%";
            L_UT_1_2.Text = _controlador.Emp1_2.utilidad.ToString("n2") + "%";
            L_UT_1_3.Text = _controlador.Emp1_3.utilidad.ToString("n2") + "%";

            L_NETO_DIV_1_1.Text = _controlador.Emp1_1.pNetoDiv.ToString("n2");
            L_NETO_DIV_1_2.Text = _controlador.Emp1_2.pNetoDiv.ToString("n2");
            L_NETO_DIV_1_3.Text = _controlador.Emp1_3.pNetoDiv.ToString("n2");

            L_NETO_1_1.Text = _controlador.Emp1_1.pNeto.ToString("n2");
            L_NETO_1_2.Text = _controlador.Emp1_2.pNeto.ToString("n2");
            L_NETO_1_3.Text = _controlador.Emp1_3.pNeto.ToString("n2");

            L_FULL_DIV_1_1.Text = _controlador.Emp1_1.pFullDiv.ToString("n2");
            L_FULL_DIV_1_2.Text = _controlador.Emp1_2.pFullDiv.ToString("n2");
            L_FULL_DIV_1_3.Text = _controlador.Emp1_3.pFullDiv.ToString("n2");

            L_FULL_1_1.Text = _controlador.Emp1_1.pFull.ToString("n2");
            L_FULL_1_2.Text = _controlador.Emp1_2.pFull.ToString("n2");
            L_FULL_1_3.Text = _controlador.Emp1_3.pFull.ToString("n2");
        }
    }
}