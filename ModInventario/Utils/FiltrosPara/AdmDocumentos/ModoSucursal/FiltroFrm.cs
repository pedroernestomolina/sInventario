using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara.AdmDocumentos.ModoSucursal
{
    public partial class FiltroFrm : Form
    {
        private IAdmDoc _controlador;


        public FiltroFrm()
        {
            InitializeComponent();
            InicializaControles();
        }


        private void InicializaControles()
        {
            CB_DEP_ORIGEN.DisplayMember = "desc";
            CB_DEP_ORIGEN.ValueMember = "id";
            CB_DEP_DESTINO.DisplayMember = "desc";
            CB_DEP_DESTINO.ValueMember = "id";
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
        }


        private bool _modoInicializa; 
        private void FiltroFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            CB_DEP_ORIGEN.DataSource = _controlador.DepositoOrigen.GetSource;
            CB_DEP_DESTINO.DataSource = _controlador.DepositoDestino.GetSource;
            CB_ESTATUS.DataSource = _controlador.Estatus.GetSource;
            CB_CONCEPTO.DataSource = _controlador.Concepto.GetSource;

            CB_DEP_ORIGEN.SelectedValue = _controlador.DepositoOrigen.GetId;
            CB_DEP_DESTINO.SelectedValue = _controlador.DepositoDestino.GetId;
            CB_ESTATUS.SelectedValue = _controlador.Estatus.GetId;
            CB_CONCEPTO.SelectedValue = _controlador.Concepto.GetId;

            TB_PRODUCTO.Text = _controlador.PorProducto.GetDescripcion;
            P_PRODUCTO.Enabled = _controlador.PorProducto.GetHabilitado;
            _modoInicializa = false;
        }
        private void FiltroFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }
        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        public void setControlador(IAdmDoc ctr)
        {
            _controlador = ctr;
        }


        private void CB_DEP_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.DepositoOrigen.setFichaById("");
            if (CB_DEP_ORIGEN.SelectedIndex != -1)
            {
                _controlador.DepositoOrigen.setFichaById(CB_DEP_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_DEP_DESTINO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.DepositoDestino.setFichaById("");
            if (CB_DEP_DESTINO.SelectedIndex != -1)
            {
                _controlador.DepositoDestino.setFichaById(CB_DEP_DESTINO.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.Estatus.setFichaById("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.Estatus.setFichaById(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.Concepto.setFichaById("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.Concepto.setFichaById(CB_CONCEPTO.SelectedValue.ToString());
            }
        }


        private void TB_PRODUCTO_Leave(object sender, EventArgs e)
        {
            _controlador.PorProducto.setCadenaBuscar(TB_PRODUCTO.Text.Trim().ToUpper());
        }


        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            LimpiarConcepto();
        }
        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            LimpiarEstatus();
        }
        private void L_DEP_ORIGEN_Click(object sender, EventArgs e)
        {
            LimpiarDepOrigen();
        }
        private void L_DEP_DESTINO_Click(object sender, EventArgs e)
        {
            LimpiarDepDestino();
        }
        private void L_PRODUCTO_Click(object sender, EventArgs e)
        {
            LimpiarProducto();
        }


        private void LimpiarEstatus()
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void LimpiarConcepto()
        {
            CB_CONCEPTO.SelectedIndex = -1;
        }
        private void LimpiarDepDestino()
        {
            CB_DEP_DESTINO.SelectedIndex = -1;
        }
        private void LimpiarDepOrigen()
        {
            CB_DEP_ORIGEN.SelectedIndex = -1;
        }
        private void LimpiarProducto()
        {
            _controlador.PorProducto.Limpiar();
            TB_PRODUCTO.Text = _controlador.PorProducto.GetDescripcion;
            P_PRODUCTO.Enabled = _controlador.PorProducto.GetHabilitado;
        }


        private void BT_PRODUCTO_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
        private void LimpiarFiltros()
        {
            LimpiarDepOrigen();
            LimpiarDepDestino();
            LimpiarEstatus();
            LimpiarConcepto();
            LimpiarProducto();
        }
        private void BuscarProducto()
        {
            _controlador.PorProducto.Buscar();
            if (_controlador.PorProducto.BuscarIsOk) 
            {
                TB_PRODUCTO.Text = _controlador.PorProducto.GetDescripcion;
                P_PRODUCTO.Enabled = _controlador.PorProducto.GetHabilitado;
            }
        }
    }
}