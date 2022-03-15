using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo.Traslado.Captura
{

    public partial class EntradaFrm : Form
    {

        private ICaptura _controlador;


        public EntradaFrm()
        {
            InitializeComponent();
            InicializaCombo();
        }


        private void InicializaCombo()
        {
            CB_EMPAQUE.DisplayMember = "desc";
            CB_EMPAQUE.ValueMember = "id";
        }


        bool _modoInicializar;
        private void EntradaFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_EMPAQUE.DataSource = _controlador.EmpaqueSource;
            CB_EMPAQUE.SelectedValue = _controlador.EmpaqueGetID;
            L_PRODUCTO.Text = _controlador.InfProductoDesc;
            L_EMP_COMPRA.Text = _controlador.InfProductoEmpaCompra;
            L_TASA_CAMBIO.Text = _controlador.InfTasaCambio.ToString("n2");
            L_ADM_DIVISA.Text = _controlador.InfProductoEsAdmDivisa;
            L_TASA_IVA.Text = _controlador.InfProductoTasaIva;
            L_FECHA_ACT.Text = _controlador.InfProductoFechaUltActCosto;
            L_EXISTENCIA.Text = _controlador.InfExistenciaActual.ToString("n2");
            BT_CAMBIO_DIVISA.Visible = _controlador.InfProductoEsDivisa;
            ActualizarData();
            _modoInicializar = false;
        }

        private void ActualizarData()
        {
            TB_CNT.Text = _controlador.Cantidad.ToString();
            TB_COSTO.Text = _controlador.Costo.ToString();
            L_CNT_UND.Text = _controlador.CntUnd.ToString("n2"); ;
            L_COSTO_UND.Text = _controlador.CostoUnd.ToString("n2");
            L_IMPORTE.Text = _controlador.Importe.ToString("n2");
        }

        private void CB_EMPAQUE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setEmpaque("");
            if (CB_EMPAQUE.SelectedIndex != -1)
            {
                _controlador.setEmpaque(CB_EMPAQUE.SelectedValue.ToString());
            }
            ActualizarData();
        }
        private void TB_CNT_Leave(object sender, EventArgs e)
        {
            _controlador.setCantidad(decimal.Parse(TB_CNT.Text));
            ActualizarData();
        }
        private void TB_COSTO_Leave(object sender, EventArgs e)
        {
            _controlador.setCosto(decimal.Parse(TB_COSTO.Text));
            ActualizarData();
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.Procesar();
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


        private void EntradaFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }

        public void setControlador(ICaptura ctr)
        {
            _controlador = ctr;
        }

    }

}