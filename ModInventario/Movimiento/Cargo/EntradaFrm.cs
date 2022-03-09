using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Cargo
{

    public partial class EntradaFrm : Form
    {


        private Entrada.Gestion _controlador;


        public EntradaFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Entrada.Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.procesarIsOk) 
            {
                Salir();
            }
        }

        private void EntradaFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.Producto;
            L_EMP_COMPRA.Text = _controlador.ProductoEmpCompra;
            L_TASA_CAMBIO.Text = _controlador.TasaCambio;
            L_ADM_DIVISA.Text=_controlador.ProductoAdmDivisa;
            L_TASA_IVA.Text = _controlador.ProductoTasaIva;
            L_FECHA_ACT.Text = _controlador.ProductoFechaUltAct;
            L_EXISTENCIA.Text = _controlador.ExistenciaDeposito;
            TB_CNT.Text = _controlador.Cantidad.ToString(); 
            TB_COSTO.Text = _controlador.Costo.ToString();
            BT_CAMBIO_DIVISA.Visible = _controlador.ProductoEsDivisa;
            CB_EMPAQUE.SelectedIndex = -1;
            if (_controlador.TipoEmpaqueSeleccionado== enumerados.enumTipoEmpaque.PorUnidad)
                CB_EMPAQUE.SelectedIndex = 1;
            else
                CB_EMPAQUE.SelectedIndex = 0;

            ActualizarData();
        }

        private void ActualizarData()
        {
            L_CNT_UND.Text = _controlador.CntUnd;
            L_COSTO_UND.Text = _controlador.CostoUnd;
            L_IMPORTE.Text = _controlador.Importe.ToString("n2");
            TB_COSTO.Text = _controlador.Costo.ToString();
        }

        private void CB_EMPAQUE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_EMPAQUE.SelectedIndex!=-1)
            {
                _controlador.setEmpaque(CB_EMPAQUE.SelectedIndex);
            }
            ActualizarData();
        }

        private void TB_CNT_Leave(object sender, EventArgs e)
        {
            _controlador.Cantidad = decimal.Parse(TB_CNT.Text);
            ActualizarData();
        }

        private void TB_COSTO_Leave(object sender, EventArgs e)
        {
            _controlador.Costo = decimal.Parse(TB_COSTO.Text);
            ActualizarData();
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.abandonarIsOk)
            {
                Salir();
            }
        }

        private void EntradaFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.abandonarIsOk || _controlador.procesarIsOk)
            {
                e.Cancel = false;
            }
        }

    }

}