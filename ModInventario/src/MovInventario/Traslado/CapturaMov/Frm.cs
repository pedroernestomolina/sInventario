using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Traslado.CapturaMov
{

    public partial class Frm : Form
    {

        private ICapturaMovTraslado _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializaCombo();
        }


        public void setControlador(ICapturaMovTraslado ctr)
        {
            _controlador = ctr;
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
            CB_EMPAQUE.DataSource = _controlador.Captura.Empaque.GetSource;
            CB_EMPAQUE.SelectedValue = _controlador.Captura.Empaque.GetId;
            L_PRODUCTO.Text = _controlador.Captura.Ficha.InfProductoDesc;
            L_EMP_COMPRA.Text = _controlador.Captura.Ficha.InfProductoEmpaCompra;
            L_EMP_INV.Text = _controlador.Captura.Ficha.InfProductoEmpInventario;
            L_EMP_UND.Text = _controlador.Captura.Ficha.InfProductoEmpUnidad;
            L_TASA_CAMBIO.Text = _controlador.Captura.TasaCambio.ToString("n2");
            L_ADM_DIVISA.Text = _controlador.Captura.Ficha.InfProductoEsAdmDivisa;
            L_TASA_IVA.Text = _controlador.Captura.Ficha.InfProductoTasaIva;
            L_FECHA_ACT.Text = _controlador.Captura.Ficha.InfProductoFechaUltActCosto;
            L_EXISTENCIA.Text = _controlador.Captura.Ficha.InfExistenciaActual.ToString("n2");
            BT_CAMBIO_DIVISA.Visible = _controlador.Captura.Ficha.InfProductoEsDivisa;
            TB_CNT.Text = _controlador.Captura.Mov_GetCantidad.ToString();
            TB_COSTO.Text = _controlador.Captura.Mov_GetCosto.ToString();
            ActualizarData();
            _modoInicializar = false;
        }
        private void EntradaFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }


        private void CB_EMPAQUE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Captura.setEmpaque("");
            if (CB_EMPAQUE.SelectedIndex != -1)
            {
                _controlador.Captura.setEmpaque(CB_EMPAQUE.SelectedValue.ToString());
            }
            ActualizarData();
        }


        private void TB_CNT_Leave(object sender, EventArgs e)
        {
            _controlador.Captura.setCantidad(decimal.Parse(TB_CNT.Text));
            ActualizarData();
        }
        private void TB_COSTO_Leave(object sender, EventArgs e)
        {
            _controlador.Captura.setCosto(decimal.Parse(TB_COSTO.Text));
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
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void ActualizarData()
        {
            L_CNT_UND.Text = _controlador.Captura.Mov_GetCntUnd.ToString("n2"); ;
            L_COSTO_UND.Text = _controlador.Captura.Mov_GetCostoUnd.ToString("n2");
            L_IMPORTE.Text = _controlador.Captura.Mov_GetImporte.ToString("n2");
            TB_COSTO.Text = _controlador.Captura.Mov_GetCosto.ToString();
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
    }
}