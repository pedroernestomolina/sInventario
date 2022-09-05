using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.VerVisualizar.ModoSucursal
{

    public partial class VisualFrm : Form
    {

        private IVisualSucursal _controlador;


        public VisualFrm()
        {
            InitializeComponent();
        }

        public void setControlador(IVisualSucursal ctr)
        {
            _controlador = ctr;
        }

        private void VisualFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.GetProductoInfo;
            L_TASA_CAMBIO.Text = _controlador.GetTasaCambio.ToString("n2");
            L_METODO.Text = _controlador.GetMetodoCalculoUtilidad;
            L_ADM_DIVISA.Text = _controlador.GetProductoAdmDivisa;
            L_TASA_IVA.Text = _controlador.GetProductoIva;

            L_ET_1_1.Text = _controlador.Emp1_1.etiqueta;
            L_ET_1_2.Text = _controlador.Emp1_2.etiqueta;
            L_ET_1_3.Text = _controlador.Emp1_3.etiqueta;
            L_ET_1_4.Text = _controlador.Emp1_4.etiqueta;
            L_ET_1_5.Text = _controlador.Emp1_5.etiqueta;

            L_EMP_1_1.Text = _controlador.Emp1_1.empaque;
            L_EMP_1_2.Text = _controlador.Emp1_2.empaque;
            L_EMP_1_3.Text = _controlador.Emp1_3.empaque;
            L_EMP_1_4.Text = _controlador.Emp1_4.empaque;
            L_EMP_1_5.Text = _controlador.Emp1_5.empaque;

            L_CONT_1_1.Text = _controlador.Emp1_1.contenido.ToString(); 
            L_CONT_1_2.Text = _controlador.Emp1_2.contenido.ToString(); 
            L_CONT_1_3.Text = _controlador.Emp1_3.contenido.ToString(); 
            L_CONT_1_4.Text = _controlador.Emp1_4.contenido.ToString(); 
            L_CONT_1_5.Text = _controlador.Emp1_5.contenido.ToString();

            L_UT_1_1.Text = _controlador.Emp1_1.utilidad.ToString("n2") + "%";
            L_UT_1_2.Text = _controlador.Emp1_2.utilidad.ToString("n2") + "%";
            L_UT_1_3.Text = _controlador.Emp1_3.utilidad.ToString("n2") + "%";
            L_UT_1_4.Text = _controlador.Emp1_4.utilidad.ToString("n2") + "%";
            L_UT_1_5.Text = _controlador.Emp1_5.utilidad.ToString("n2") + "%";

            L_NETO_DIV_1_1.Text = _controlador.Emp1_1.pNetoDiv.ToString("n2");
            L_NETO_DIV_1_2.Text = _controlador.Emp1_2.pNetoDiv.ToString("n2");
            L_NETO_DIV_1_3.Text = _controlador.Emp1_3.pNetoDiv.ToString("n2");
            L_NETO_DIV_1_4.Text = _controlador.Emp1_4.pNetoDiv.ToString("n2");
            L_NETO_DIV_1_5.Text = _controlador.Emp1_5.pNetoDiv.ToString("n2");

            L_NETO_1_1.Text = _controlador.Emp1_1.pNeto.ToString("n2");
            L_NETO_1_2.Text = _controlador.Emp1_2.pNeto.ToString("n2");
            L_NETO_1_3.Text = _controlador.Emp1_3.pNeto.ToString("n2");
            L_NETO_1_4.Text = _controlador.Emp1_4.pNeto.ToString("n2");
            L_NETO_1_5.Text = _controlador.Emp1_5.pNeto.ToString("n2");

            L_FULL_DIV_1_1.Text = _controlador.Emp1_1.pFullDiv.ToString("n2");
            L_FULL_DIV_1_2.Text = _controlador.Emp1_2.pFullDiv.ToString("n2");
            L_FULL_DIV_1_3.Text = _controlador.Emp1_3.pFullDiv.ToString("n2");
            L_FULL_DIV_1_4.Text = _controlador.Emp1_4.pFullDiv.ToString("n2");
            L_FULL_DIV_1_5.Text = _controlador.Emp1_5.pFullDiv.ToString("n2");

            L_FULL_1_1.Text = _controlador.Emp1_1.pFull.ToString("n2");
            L_FULL_1_2.Text = _controlador.Emp1_2.pFull.ToString("n2");
            L_FULL_1_3.Text = _controlador.Emp1_3.pFull.ToString("n2");
            L_FULL_1_4.Text = _controlador.Emp1_4.pFull.ToString("n2");
            L_FULL_1_5.Text = _controlador.Emp1_5.pFull.ToString("n2");
            //

            L_ET_2_1.Text = _controlador.Emp2_1.etiqueta;
            L_ET_2_2.Text = _controlador.Emp2_2.etiqueta;
            L_ET_2_3.Text = _controlador.Emp2_3.etiqueta;
            L_ET_2_4.Text = _controlador.Emp2_4.etiqueta;
            L_ET_2_5.Text = _controlador.Emp2_5.etiqueta;

            L_EMP_2_1.Text = _controlador.Emp2_1.empaque;
            L_EMP_2_2.Text = _controlador.Emp2_2.empaque;
            L_EMP_2_3.Text = _controlador.Emp2_3.empaque;
            L_EMP_2_4.Text = _controlador.Emp2_4.empaque;
            L_EMP_2_5.Text = _controlador.Emp2_5.empaque;

            L_CONT_2_1.Text = _controlador.Emp2_1.contenido.ToString();
            L_CONT_2_2.Text = _controlador.Emp2_2.contenido.ToString();
            L_CONT_2_3.Text = _controlador.Emp2_3.contenido.ToString();
            L_CONT_2_4.Text = _controlador.Emp2_4.contenido.ToString();
            L_CONT_2_5.Text = _controlador.Emp2_5.contenido.ToString();

            L_UT_2_1.Text = _controlador.Emp2_1.utilidad.ToString("n2") + "%";
            L_UT_2_2.Text = _controlador.Emp2_2.utilidad.ToString("n2") + "%";
            L_UT_2_3.Text = _controlador.Emp2_3.utilidad.ToString("n2") + "%";
            L_UT_2_4.Text = _controlador.Emp2_4.utilidad.ToString("n2") + "%";
            L_UT_2_5.Text = _controlador.Emp2_5.utilidad.ToString("n2") + "%";

            L_NETO_DIV_2_1.Text = _controlador.Emp2_1.pNetoDiv.ToString("n2");
            L_NETO_DIV_2_2.Text = _controlador.Emp2_2.pNetoDiv.ToString("n2");
            L_NETO_DIV_2_3.Text = _controlador.Emp2_3.pNetoDiv.ToString("n2");
            L_NETO_DIV_2_4.Text = _controlador.Emp2_4.pNetoDiv.ToString("n2");
            L_NETO_DIV_2_5.Text = _controlador.Emp2_5.pNetoDiv.ToString("n2");

            L_NETO_2_1.Text = _controlador.Emp2_1.pNeto.ToString("n2");
            L_NETO_2_2.Text = _controlador.Emp2_2.pNeto.ToString("n2");
            L_NETO_2_3.Text = _controlador.Emp2_3.pNeto.ToString("n2");
            L_NETO_2_4.Text = _controlador.Emp2_4.pNeto.ToString("n2");
            L_NETO_2_5.Text = _controlador.Emp2_5.pNeto.ToString("n2");

            L_FULL_DIV_2_1.Text = _controlador.Emp2_1.pFullDiv.ToString("n2");
            L_FULL_DIV_2_2.Text = _controlador.Emp2_2.pFullDiv.ToString("n2");
            L_FULL_DIV_2_3.Text = _controlador.Emp2_3.pFullDiv.ToString("n2");
            L_FULL_DIV_2_4.Text = _controlador.Emp2_4.pFullDiv.ToString("n2");
            L_FULL_DIV_2_5.Text = _controlador.Emp2_5.pFullDiv.ToString("n2");

            L_FULL_2_1.Text = _controlador.Emp2_1.pFull.ToString("n2");
            L_FULL_2_2.Text = _controlador.Emp2_2.pFull.ToString("n2");
            L_FULL_2_3.Text = _controlador.Emp2_3.pFull.ToString("n2");
            L_FULL_2_4.Text = _controlador.Emp2_4.pFull.ToString("n2");
            L_FULL_2_5.Text = _controlador.Emp2_5.pFull.ToString("n2");
            //

            L_ET_3_1.Text = _controlador.Emp3_1.etiqueta;
            L_ET_3_2.Text = _controlador.Emp3_2.etiqueta;
            L_ET_3_3.Text = _controlador.Emp3_3.etiqueta;
            L_ET_3_4.Text = _controlador.Emp3_4.etiqueta;
            L_ET_3_5.Text = _controlador.Emp3_5.etiqueta;

            L_EMP_3_1.Text = _controlador.Emp3_1.empaque;
            L_EMP_3_2.Text = _controlador.Emp3_2.empaque;
            L_EMP_3_3.Text = _controlador.Emp3_3.empaque;
            L_EMP_3_4.Text = _controlador.Emp3_4.empaque;
            L_EMP_3_5.Text = _controlador.Emp3_5.empaque;

            L_CONT_3_1.Text = _controlador.Emp3_1.contenido.ToString();
            L_CONT_3_2.Text = _controlador.Emp3_2.contenido.ToString();
            L_CONT_3_3.Text = _controlador.Emp3_3.contenido.ToString();
            L_CONT_3_4.Text = _controlador.Emp3_4.contenido.ToString();
            L_CONT_3_5.Text = _controlador.Emp3_5.contenido.ToString();

            L_UT_3_1.Text = _controlador.Emp3_1.utilidad.ToString("n2") + "%";
            L_UT_3_2.Text = _controlador.Emp3_2.utilidad.ToString("n2") + "%";
            L_UT_3_3.Text = _controlador.Emp3_3.utilidad.ToString("n2") + "%";
            L_UT_3_4.Text = _controlador.Emp3_4.utilidad.ToString("n2") + "%";
            L_UT_3_5.Text = _controlador.Emp3_5.utilidad.ToString("n2") + "%";

            L_NETO_DIV_3_1.Text = _controlador.Emp3_1.pNetoDiv.ToString("n2");
            L_NETO_DIV_3_2.Text = _controlador.Emp3_2.pNetoDiv.ToString("n2");
            L_NETO_DIV_3_3.Text = _controlador.Emp3_3.pNetoDiv.ToString("n2");
            L_NETO_DIV_3_4.Text = _controlador.Emp3_4.pNetoDiv.ToString("n2");
            L_NETO_DIV_3_5.Text = _controlador.Emp3_5.pNetoDiv.ToString("n2");

            L_NETO_3_1.Text = _controlador.Emp3_1.pNeto.ToString("n2");
            L_NETO_3_2.Text = _controlador.Emp3_2.pNeto.ToString("n2");
            L_NETO_3_3.Text = _controlador.Emp3_3.pNeto.ToString("n2");
            L_NETO_3_4.Text = _controlador.Emp3_4.pNeto.ToString("n2");
            L_NETO_3_5.Text = _controlador.Emp3_5.pNeto.ToString("n2");

            L_FULL_DIV_3_1.Text = _controlador.Emp3_1.pFullDiv.ToString("n2");
            L_FULL_DIV_3_2.Text = _controlador.Emp3_2.pFullDiv.ToString("n2");
            L_FULL_DIV_3_3.Text = _controlador.Emp3_3.pFullDiv.ToString("n2");
            L_FULL_DIV_3_4.Text = _controlador.Emp3_4.pFullDiv.ToString("n2");
            L_FULL_DIV_3_5.Text = _controlador.Emp3_5.pFullDiv.ToString("n2");

            L_FULL_3_1.Text = _controlador.Emp3_1.pFull.ToString("n2");
            L_FULL_3_2.Text = _controlador.Emp3_2.pFull.ToString("n2");
            L_FULL_3_3.Text = _controlador.Emp3_3.pFull.ToString("n2");
            L_FULL_3_4.Text = _controlador.Emp3_4.pFull.ToString("n2");
            L_FULL_3_5.Text = _controlador.Emp3_5.pFull.ToString("n2");

        }

    }

}