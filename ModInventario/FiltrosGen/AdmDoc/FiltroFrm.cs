using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.FiltrosGen.AdmDoc
{

    public partial class FiltroFrm : Form
    {


        private Gestion _controlador;


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
            CB_DEP_ORIGEN.DataSource=_controlador.SourceDepOrigen;
            CB_DEP_DESTINO.DataSource = _controlador.SourceDepDestino;
            CB_ESTATUS.DataSource = _controlador.SourceEstatus;
            CB_CONCEPTO.DataSource = _controlador.SourceConcepto;
            CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigenID;
            CB_DEP_DESTINO.SelectedValue = _controlador.DepDestinoID;
            CB_CONCEPTO.SelectedValue = _controlador.ConceptoID;
            CB_ESTATUS.SelectedValue = _controlador.EstatusID;
            TB_PRODUCTO.Text = _controlador.DescProductoAFiltrar;
            _modoInicializa = false;
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            LimpiarProducto();
            LimpiarDepOrigen();
            LimpiarDepDestino();
            LimpiarEstatus();
            LimpiarConcepto();
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
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
        private void Salir()
        {
            this.Close();
        }


        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void TB_PRODUCTO_Leave(object sender, EventArgs e)
        {
            _controlador.setProducto(TB_PRODUCTO.Text.Trim().ToUpper());
        }
        private void BT_PRODUCTO_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }
        private void BuscarProducto()
        {
            _controlador.BuscarProducto();
            if (_controlador.ProductoSeleccioandoIsOk)
            {
                P_PRODUCTO.Enabled = false;
            }
            TB_PRODUCTO.Text = _controlador.DescProductoAFiltrar;
        }


        private void CB_DEP_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setDepOrigen("");
            if (CB_DEP_ORIGEN.SelectedIndex != -1)
            {
                _controlador.setDepOrigen(CB_DEP_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_DEP_DESTINO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setDepDestino("");
            if (CB_DEP_DESTINO.SelectedIndex != -1)
            {
                _controlador.setDepDestino(CB_DEP_DESTINO.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setConcepto("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.setConcepto(CB_CONCEPTO.SelectedValue.ToString());
            }
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
            _controlador.LimpiarProducto();
            TB_PRODUCTO.Text = "";
            P_PRODUCTO.Enabled = true;
        }


        private void FiltroFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }

    }

}