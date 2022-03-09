using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Ver
{

    public partial class VerFrm : Form
    {

        private Gestion _controlador;


        public VerFrm()
        {
            InitializeComponent();
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

        private void VerFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
            Actualizar();
        }

        private void Actualizar()
        {
            L_PRODUCTO.Text = _controlador.Producto;
            L_METODO.Text = _controlador.MetodoCalculoUtilidad;
            L_TASA_CAMBIO.Text = _controlador.TasaCambioActual;
            L_ADM_DIVISA.Text = _controlador.AdmDivisa;
            L_TASA_IVA.Text = _controlador.TasaIva;

            L_ETQ_1.Text = _controlador.Precio1.etiqueta;
            L_EMP_1.Text = _controlador.Precio1.empaque;
            L_CONT_1.Text = _controlador.Precio1.contenido.ToString("n0");
            L_UT_1.Text = _controlador.Precio1.utilidadPorc.ToString("n2").Trim() + "%";
            L_PN_1.Text = _controlador.Precio1.PN.ToString("n2");
            L_PF_1.Text = _controlador.Precio1.PF.ToString("n2");

            L_ETQ_2.Text = _controlador.Precio2.etiqueta;
            L_EMP_2.Text = _controlador.Precio2.empaque;
            L_CONT_2.Text = _controlador.Precio2.contenido.ToString("n0");
            L_UT_2.Text = _controlador.Precio2.utilidadPorc.ToString("n2").Trim() + "%";
            L_PN_2.Text = _controlador.Precio2.PN.ToString("n2");
            L_PF_2.Text = _controlador.Precio2.PF.ToString("n2");

            L_ETQ_3.Text = _controlador.Precio3.etiqueta;
            L_EMP_3.Text = _controlador.Precio3.empaque;
            L_CONT_3.Text = _controlador.Precio3.contenido.ToString("n0");
            L_UT_3.Text = _controlador.Precio3.utilidadPorc.ToString("n2").Trim() + "%";
            L_PN_3.Text = _controlador.Precio3.PN.ToString("n2");
            L_PF_3.Text = _controlador.Precio3.PF.ToString("n2");

            L_ETQ_4.Text = _controlador.Precio4.etiqueta;
            L_EMP_4.Text = _controlador.Precio4.empaque;
            L_CONT_4.Text = _controlador.Precio4.contenido.ToString("n0");
            L_UT_4.Text = _controlador.Precio4.utilidadPorc.ToString("n2").Trim() + "%";
            L_PN_4.Text = _controlador.Precio4.PN.ToString("n2");
            L_PF_4.Text = _controlador.Precio4.PF.ToString("n2");

            L_ETQ_5.Text = _controlador.Precio5.etiqueta;
            L_EMP_5.Text = _controlador.Precio5.empaque;
            L_CONT_5.Text = _controlador.Precio5.contenido.ToString("n0");
            L_UT_5.Text = _controlador.Precio5.utilidadPorc.ToString("n2").Trim() + "%";
            L_PN_5.Text = _controlador.Precio5.PN.ToString("n2");
            L_PF_5.Text = _controlador.Precio5.PF.ToString("n2");

            //
            L_ETQ_MAY_1.Text = _controlador.Mayor1.etiqueta;
            L_EMP_MAY_1.Text = _controlador.Mayor1.empaque;
            L_CONT_MAY_1.Text = _controlador.Mayor1.contenido.ToString("n0");
            L_UT_MAY_1.Text = _controlador.Mayor1.utilidadPorc.ToString("n2").Trim() + "%";
            L_PN_MAY_1.Text = _controlador.Mayor1.PN.ToString("n2");
            L_PF_MAY_1.Text = _controlador.Mayor1.PF.ToString("n2");

            L_ETQ_MAY_2.Text = _controlador.Mayor2.etiqueta;
            L_EMP_MAY_2.Text = _controlador.Mayor2.empaque;
            L_CONT_MAY_2.Text = _controlador.Mayor2.contenido.ToString("n0");
            L_UT_MAY_2.Text = _controlador.Mayor2.utilidadPorc.ToString("n2").Trim() + "%";
            L_PN_MAY_2.Text = _controlador.Mayor2.PN.ToString("n2");
            L_PF_MAY_2.Text = _controlador.Mayor2.PF.ToString("n2");
            //

            L_PREF_NETO.ForeColor = Color.Black;
            L_PREF_FULL.ForeColor = Color.Black;
            L_PREF_NETO.Font = new Font(L_PREF_NETO.Font.FontFamily, 10, FontStyle.Regular);
            L_PREF_FULL.Font = new Font(L_PREF_FULL.Font.FontFamily, 10, FontStyle.Regular);

            if (_controlador.PreferenciaBusquedaEsNeto)
            {
                L_PREF_NETO.ForeColor = Color.Yellow;
                L_PREF_NETO.Font = new Font(L_PREF_NETO.Font.FontFamily, 12, FontStyle.Bold);
            }
            else
            {
                L_PREF_FULL.ForeColor = Color.Yellow;
                L_PREF_FULL.Font = new Font( L_PREF_FULL.Font.FontFamily , 12, FontStyle.Bold);
            }

            L_PN_1.BackColor = Color.AliceBlue;
            L_PN_2.BackColor = Color.AliceBlue;
            L_PN_3.BackColor = Color.AliceBlue;
            L_PN_4.BackColor = Color.AliceBlue;
            L_PN_5.BackColor = Color.AliceBlue;
            L_PN_MAY_1.BackColor = Color.AliceBlue;
            L_PN_MAY_2.BackColor = Color.AliceBlue;

            L_PN_1.ForeColor = Color.Black;
            L_PN_2.ForeColor = Color.Black;
            L_PN_3.ForeColor = Color.Black;
            L_PN_4.ForeColor = Color.Black;
            L_PN_5.ForeColor = Color.Black;
            L_PN_MAY_1.ForeColor = Color.Black;
            L_PN_MAY_2.ForeColor = Color.Black;

            L_PF_1.BackColor = Color.AliceBlue;
            L_PF_2.BackColor = Color.AliceBlue;
            L_PF_3.BackColor = Color.AliceBlue;
            L_PF_4.BackColor = Color.AliceBlue;
            L_PF_5.BackColor = Color.AliceBlue;
            L_PF_MAY_1.BackColor = Color.AliceBlue;
            L_PF_MAY_2.BackColor = Color.AliceBlue;

            L_PF_1.ForeColor = Color.Black;
            L_PF_2.ForeColor = Color.Black;
            L_PF_3.ForeColor = Color.Black;
            L_PF_4.ForeColor = Color.Black;
            L_PF_5.ForeColor = Color.Black;
            L_PF_MAY_1.ForeColor = Color.Black;
            L_PF_MAY_2.ForeColor = Color.Black;

            if (_controlador.ModoActual == data.enumModoPrecio.Divisa)
            {
                L_PN_1.BackColor = Color.Green;
                L_PN_2.BackColor = Color.Green;
                L_PN_3.BackColor = Color.Green;
                L_PN_4.BackColor = Color.Green;
                L_PN_5.BackColor = Color.Green;
                L_PN_MAY_1.BackColor = Color.Green;
                L_PN_MAY_2.BackColor = Color.Green;

                L_PN_1.ForeColor = Color.White;
                L_PN_2.ForeColor = Color.White;
                L_PN_3.ForeColor = Color.White;
                L_PN_4.ForeColor = Color.White;
                L_PN_5.ForeColor = Color.White;
                L_PN_MAY_1.ForeColor = Color.White;
                L_PN_MAY_2.ForeColor = Color.White;

                L_PF_1.BackColor = Color.Green;
                L_PF_2.BackColor = Color.Green;
                L_PF_3.BackColor = Color.Green;
                L_PF_4.BackColor = Color.Green;
                L_PF_5.BackColor = Color.Green;
                L_PF_MAY_1.BackColor = Color.Green;
                L_PF_MAY_2.BackColor = Color.Green;

                L_PF_1.ForeColor = Color.White;
                L_PF_2.ForeColor = Color.White;
                L_PF_3.ForeColor = Color.White;
                L_PF_4.ForeColor = Color.White;
                L_PF_5.ForeColor = Color.White;
                L_PF_MAY_1.ForeColor = Color.White;
                L_PF_MAY_2.ForeColor = Color.White;
            }
        }

        private void Limpiar()
        {
            L_ETQ_1.Text = "";
            L_CONT_1.Text = "";
            L_EMP_1.Text = "";
            L_UT_1.Text = "";
            L_PN_1.Text = "";
            L_PF_1.Text = "";

            L_ETQ_2.Text = "";
            L_CONT_2.Text = "";
            L_EMP_2.Text = "";
            L_UT_2.Text = "";
            L_PN_2.Text = "";
            L_PF_2.Text = "";

            L_ETQ_3.Text = "";
            L_EMP_3.Text = "";
            L_CONT_3.Text = "";
            L_UT_3.Text = "";
            L_PN_3.Text = "";
            L_PF_3.Text = "";

            L_ETQ_4.Text = "";
            L_CONT_4.Text = "";
            L_EMP_4.Text = "";
            L_UT_4.Text = "";
            L_PN_4.Text = "";
            L_PF_4.Text = "";

            L_ETQ_5.Text = "";
            L_EMP_5.Text = "";
            L_CONT_5.Text = "";
            L_UT_5.Text = "";
            L_PN_5.Text = "";
            L_PF_5.Text = "";

            //

            L_ETQ_MAY_1.Text = "";
            L_EMP_MAY_1.Text = "";
            L_CONT_MAY_1.Text = "";
            L_UT_MAY_1.Text = "";
            L_PN_MAY_1.Text = "";
            L_PF_MAY_1.Text = "";

            L_ETQ_MAY_2.Text = "";
            L_EMP_MAY_2.Text = "";
            L_CONT_MAY_2.Text = "";
            L_UT_MAY_2.Text = "";
            L_PN_MAY_2.Text = "";
            L_PF_MAY_2.Text = "";
        }

        private void BT_MODO_PRECIO_Click(object sender, EventArgs e)
        {
            CambioModoPrecio();
        }

        private void CambioModoPrecio()
        {
            _controlador.CambioModoPrecio();
            Actualizar();
        }
          
    }

}