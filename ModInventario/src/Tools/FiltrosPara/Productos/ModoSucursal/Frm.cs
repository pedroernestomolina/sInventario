using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.FiltrosPara.Productos.ModoSucursal
{

    public partial class Frm: Form
    {

        private ISucursal _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
            CB_MARCA.DisplayMember = "desc";
            CB_MARCA.ValueMember = "id";
            CB_DEPARTAMENTO.DisplayMember = "desc";
            CB_DEPARTAMENTO.ValueMember = "id";
            CB_GRUPO.DisplayMember = "desc";
            CB_GRUPO.ValueMember = "id";
            CB_DEPOSITO.DisplayMember = "desc";
            CB_DEPOSITO.ValueMember = "id";
            CB_CATEGORIA.DisplayMember = "desc";
            CB_CATEGORIA.ValueMember = "id";
            CB_ORIGEN.DisplayMember = "desc";
            CB_ORIGEN.ValueMember = "id";
            CB_IMPUESTO.DisplayMember= "desc";
            CB_IMPUESTO.ValueMember = "id";
            CB_ADMDIVISA.DisplayMember = "desc";
            CB_ADMDIVISA.ValueMember = "id";
            CB_PESADO.DisplayMember = "desc";
            CB_PESADO.ValueMember = "id";
            CB_TCS.DisplayMember = "desc";
            CB_TCS.ValueMember = "id";
            CB_EXISTENCIA.DisplayMember = "desc";
            CB_EXISTENCIA.ValueMember = "id";
            CB_CATALOGO.DisplayMember = "desc";
            CB_CATALOGO.ValueMember = "id";
        }

        private bool _modoInicializar;
        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_DEPARTAMENTO.DataSource = _controlador.Departamento.GetSource;
            CB_GRUPO.DataSource = _controlador.Grupo.GetSource;
            CB_MARCA.DataSource = _controlador.Marca.GetSource;
            CB_DEPOSITO .DataSource = _controlador.Deposito.GetSource;
            CB_CATEGORIA.DataSource = _controlador.Categoria.GetSource;
            CB_ORIGEN.DataSource = _controlador.Origen.GetSource;
            CB_IMPUESTO .DataSource = _controlador.TasaIva.GetSource;
            CB_ESTATUS.DataSource = _controlador.Estatus.GetSource;
            CB_ADMDIVISA.DataSource = _controlador.Divisa.GetSource;
            CB_PESADO.DataSource = _controlador.Pesado.GetSource;
            CB_CATALOGO.DataSource = _controlador.Catalogo.GetSource;
            CB_EXISTENCIA.DataSource = _controlador.Existencia.GetSource;
            CB_TCS.DataSource = _controlador.TCS.GetSource;

            CB_DEPARTAMENTO.SelectedValue = _controlador.Departamento.GetId;
            CB_GRUPO.SelectedValue = _controlador.Grupo.GetId;
            CB_MARCA.SelectedValue = _controlador.Marca.GetId;
            CB_DEPOSITO.SelectedValue = _controlador.Deposito.GetId;
            CB_CATEGORIA.SelectedValue = _controlador.Categoria.GetId;
            CB_ORIGEN.SelectedValue = _controlador.Origen.GetId;
            CB_IMPUESTO.SelectedValue = _controlador.TasaIva.GetId;
            CB_ESTATUS.SelectedValue = _controlador.Estatus.GetId;
            CB_ADMDIVISA.SelectedValue = _controlador.Divisa.GetId;
            CB_PESADO.SelectedValue = _controlador.Pesado.GetId;
            CB_EXISTENCIA.SelectedValue = _controlador.Existencia.GetId;
            CB_TCS.SelectedValue = _controlador.TCS.GetId;
            CB_CATALOGO.SelectedValue = _controlador.Catalogo.GetId;
            if (_controlador.Departamento.GetId== "")
            {
                CB_GRUPO.Enabled = false;
            }

            CB_DEPARTAMENTO.Enabled= _controlador.Departamento.GetHabilitar;
            CB_GRUPO.Enabled = _controlador.Grupo.GetHabilitar;
            CB_MARCA.Enabled = _controlador.Marca.GetHabilitar;
            CB_DEPOSITO.Enabled = _controlador.Deposito.GetHabilitar;
            CB_CATEGORIA.Enabled = _controlador.Categoria.GetHabilitar;
            CB_ORIGEN.Enabled = _controlador.Origen.GetHabilitar;
            CB_IMPUESTO.Enabled = _controlador.TasaIva.GetHabilitar;
            CB_ESTATUS.Enabled = _controlador.Estatus.GetHabilitar;
            CB_ADMDIVISA.Enabled = _controlador.Divisa.GetHabilitar;
            CB_PESADO.Enabled = _controlador.Pesado.GetHabilitar;
            CB_EXISTENCIA.Enabled = _controlador.Existencia.GetHabilitar;
            CB_TCS.Enabled = _controlador.TCS.GetHabilitar;
            CB_CATALOGO.Enabled = _controlador.Catalogo.GetHabilitar;

            TB_PROVEEDOR.Focus();
            ActualizarProveedor();
            _modoInicializar = false;
        }
        private void FiltrosFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }


        public void setControlador(ISucursal ctr)
        {
            _controlador = ctr;
        }


        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Departamento.setId("");
            CB_GRUPO.Enabled = false;
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.Departamento.setId(CB_DEPARTAMENTO.SelectedValue.ToString());
                _modoInicializar = true;
                CB_GRUPO.Enabled = true;
                CB_GRUPO.SelectedValue = _controlador.Departamento.Grupo.GetId;
                _modoInicializar = false;
            }
        }
        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Grupo.setId ("");
            if (CB_GRUPO.SelectedIndex != -1) 
            {
                _controlador.Grupo.setId(CB_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Marca.setId("");
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.Marca.setId(CB_MARCA.SelectedValue.ToString());
            }
        }
        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Deposito.setId("");
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.Deposito.setId(CB_DEPOSITO.SelectedValue.ToString());
            }
        }
        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Categoria.setId("");
            if (CB_CATEGORIA.SelectedIndex != -1) 
            {
                _controlador.Categoria.setId(CB_CATEGORIA.SelectedValue.ToString());
            }
        }
        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Origen.setId("");
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.Origen.setId(CB_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.TasaIva.setId("");
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.TasaIva.setId(CB_IMPUESTO.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Estatus.setId("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.Estatus.setId(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_ADMDIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Divisa.setId("");
            if (CB_ADMDIVISA.SelectedIndex != -1)
            {
                _controlador.Divisa.setId(CB_ADMDIVISA.SelectedValue.ToString());
            }
        }
        private void CB_PESADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Pesado.setId("");
            if (CB_PESADO.SelectedIndex != -1)
            {
                _controlador.Pesado.setId(CB_PESADO.SelectedValue.ToString());
            }
        }
        private void CB_CATALOGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Catalogo.setId("");
            if (CB_CATALOGO.SelectedIndex != -1)
            {
                _controlador.Catalogo.setId(CB_CATALOGO.SelectedValue.ToString());
            }
        }
        private void CB_EXISTENCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Existencia.setId("");
            if (CB_EXISTENCIA.SelectedIndex != -1)
            {
                _controlador.Existencia.setId(CB_EXISTENCIA.SelectedValue.ToString());
            }
        }
        private void CB_TCS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.TCS.setId("");
            if (CB_TCS.SelectedIndex != -1)
            {
                _controlador.TCS.setId(CB_TCS.SelectedValue.ToString());
            }
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarOpciones();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFiltros();
        }


        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            CB_DEPARTAMENTO.SelectedIndex = -1;
            _modoInicializar = true;
            CB_GRUPO.SelectedIndex =-1;
            _modoInicializar = false;
        }
        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            CB_GRUPO.SelectedIndex = -1;
        }
        private void L_PESADO_Click(object sender, EventArgs e)
        {
            CB_PESADO.SelectedIndex = -1;
        }
        private void L_ADMDIVISA_Click(object sender, EventArgs e)
        {
            CB_ADMDIVISA.SelectedIndex = -1;
        }
        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void L_IMPUESTO_Click(object sender, EventArgs e)
        {
            CB_IMPUESTO.SelectedIndex = -1;
        }
        private void L_ORIGEN_Click(object sender, EventArgs e)
        {
            CB_ORIGEN.SelectedIndex = -1;
        }
        private void L_CATEGORIA_Click(object sender, EventArgs e)
        {
            CB_CATEGORIA.SelectedIndex = -1;
        }
        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            CB_DEPOSITO.SelectedIndex = -1;
        }
        private void L_MARCA_Click(object sender, EventArgs e)
        {
            CB_MARCA.SelectedIndex = -1;
        }
        private void L_EXISTENCIA_Click(object sender, EventArgs e)
        {
            CB_EXISTENCIA.SelectedIndex = -1;
        }
        private void L_CATALOGO_Click(object sender, EventArgs e)
        {
            CB_CATALOGO.SelectedIndex = -1;
        }
        private void L_TCS_Click(object sender, EventArgs e)
        {
            CB_TCS.SelectedIndex = -1;
        }


        private void TB_PROVEEDOR_Leave(object sender, EventArgs e)
        {
            _controlador.Proveedor.setCadena(TB_PROVEEDOR.Text.Trim().ToUpper());
        }
        private void BT_PROVEED_BUSCAR_Click(object sender, EventArgs e)
        {
            ProveedorBuscar();
        }
        private void L_PROVEEDOR_Click(object sender, EventArgs e)
        {
            _controlador.Proveedor.Limpiar();
            ActualizarProveedor();
            TB_PROVEEDOR.Focus();
        }


        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void ProveedorBuscar()
        {
            _controlador.Proveedor.Buscar();
            ActualizarProveedor();
        }
        private void ActualizarProveedor()
        {
            P_PROVEEDOR.Enabled = !_controlador.Proveedor.IsOk;
            TB_PROVEEDOR.Text = _controlador.Proveedor.GetNombre;
        }
        private void AbandonarFiltros()
        {
            _controlador.AbandonarFicha ();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }
        private void LimpiarOpciones()
        {
            _controlador.LimpiarFiltros();
            if (_controlador.LimpiarFiltrosIsOk)
            {
                _modoInicializar = true;
                ActualizarProveedor();

                CB_DEPARTAMENTO.SelectedValue = _controlador.Departamento.GetId;
                CB_GRUPO.SelectedValue = _controlador.Departamento.Grupo.GetId;
                CB_MARCA.SelectedValue = _controlador.Marca.GetId;
                CB_DEPOSITO.SelectedValue = _controlador.Deposito.GetId;
                CB_CATEGORIA.SelectedValue = _controlador.Categoria.GetId;
                CB_ORIGEN.SelectedValue = _controlador.Origen.GetId;
                CB_IMPUESTO.SelectedValue = _controlador.TasaIva.GetId;
                CB_ESTATUS.SelectedValue = _controlador.Estatus.GetId;
                CB_ADMDIVISA.SelectedValue = _controlador.Divisa.GetId;
                CB_PESADO.SelectedValue = _controlador.Pesado.GetId;
                CB_EXISTENCIA.SelectedValue = _controlador.Existencia.GetId;
                CB_TCS.SelectedValue = _controlador.TCS.GetId;
                CB_CATALOGO.SelectedValue = _controlador.Catalogo.GetId;
                if (_controlador.Departamento.GetId == "")
                {
                    CB_GRUPO.Enabled = false;
                }
                _modoInicializar = false;
            }
        }
        private void Salir()
        {
            this.Close();
        }
    }
}