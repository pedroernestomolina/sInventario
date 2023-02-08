using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.ModoSucursal
{

    public partial class FiltrosFrm : Form
    {

        private ISucursal _controlador;


        public FiltrosFrm()
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
            CB_DEPARTAMENTO.DataSource = _controlador.GetDepartamentoSource;
            CB_GRUPO.DataSource = _controlador.GetGrupoSource;
            CB_MARCA.DataSource = _controlador.GetMarcaSource;
            CB_DEPOSITO .DataSource = _controlador.SourceDeposito;
            CB_CATEGORIA.DataSource = _controlador.SourceCategoria;
            CB_ORIGEN.DataSource = _controlador.GetOrigenSource;
            CB_IMPUESTO .DataSource = _controlador.GetImpuestoSource;
            CB_ESTATUS.DataSource = _controlador.GetEstatusSource ;
            CB_ADMDIVISA.DataSource = _controlador.GetAdmDivisaSource;
            CB_PESADO.DataSource = _controlador.GetPesadoSource;
            CB_CATALOGO.DataSource = _controlador.SourceCatalogo;
            CB_EXISTENCIA.DataSource = _controlador.SourceExistencia;
            CB_TCS.DataSource = _controlador.SourceTCS;

            P_PROVEEDOR.Enabled = !_controlador.ProveedorIsOk;
            TB_PROVEEDOR.Text = _controlador.GetProveedorNombreFiltrar;
            CB_DEPARTAMENTO.SelectedValue = _controlador.GetDepartamentoId;
            CB_GRUPO.SelectedValue = _controlador.GetGrupoId;
            CB_MARCA.SelectedValue = _controlador.GetMarcaId;
            CB_DEPOSITO.SelectedValue = _controlador.GetIdDeposito;
            CB_CATEGORIA.SelectedValue = _controlador.GetIdCategoria;
            CB_ORIGEN.SelectedValue = _controlador.GetOrigenId;
            CB_IMPUESTO.SelectedValue = _controlador.GetImpuestoId;
            CB_ESTATUS.SelectedValue = _controlador.GetEstatusId;
            CB_ADMDIVISA.SelectedValue = _controlador.GetAdmDivisaId;
            CB_PESADO.SelectedValue = _controlador.GetPesadoId;
            CB_EXISTENCIA.SelectedValue = _controlador.GetIdExistencia;
            CB_TCS.SelectedValue = _controlador.GetIdTCS;
            CB_CATALOGO.SelectedValue = _controlador.GetIdCatalogo;
            if (_controlador.GetDepartamentoId == "")
            {
                CB_GRUPO.Enabled = false;
            }

            TB_PROVEEDOR.Focus();
            _modoInicializar = false;
        }


        public void setControlador(ISucursal ctr)
        {
            _controlador = ctr;
        }


        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setDepartamento("");
            CB_GRUPO.Enabled = false;
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.setDepartamento(CB_DEPARTAMENTO.SelectedValue.ToString());
                _modoInicializar = true;
                CB_GRUPO.SelectedIndex = -1;
                CB_GRUPO.Enabled = true;
                _modoInicializar = false;
            }
        }
        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1) 
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setMarca("");
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.setMarca(CB_MARCA.SelectedValue.ToString());
            }
        }
        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setIdDeposito("");
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.setIdDeposito(CB_DEPOSITO.SelectedValue.ToString());
            }
        }
        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setIdCategoria("");
            if (CB_CATEGORIA.SelectedIndex != -1) 
            {
                _controlador.setIdCategoria(CB_CATEGORIA.SelectedValue.ToString());
            }
        }
        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setOrigen("");
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.setOrigen(CB_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setTasaIva("");
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.setTasaIva(CB_IMPUESTO.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_ADMDIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setAdmDivisa("");
            if (CB_ADMDIVISA.SelectedIndex != -1)
            {
                _controlador.setAdmDivisa(CB_ADMDIVISA.SelectedValue.ToString());
            }
        }
        private void CB_PESADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setPesado("");
            if (CB_PESADO.SelectedIndex != -1)
            {
                _controlador.setPesado(CB_PESADO.SelectedValue.ToString());
            }
        }
        private void CB_CATALOGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setIdCatalogo("");
            if (CB_CATALOGO.SelectedIndex != -1)
            {
                _controlador.setIdCatalogo(CB_CATALOGO.SelectedValue.ToString());
            }
        }
        private void CB_EXISTENCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setIdExistencia("");
            if (CB_EXISTENCIA.SelectedIndex != -1)
            {
                _controlador.setIdExistencia(CB_EXISTENCIA.SelectedValue.ToString());
            }
        }
        private void CB_TCS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setIdTCS("");
            if (CB_TCS.SelectedIndex != -1)
            {
                _controlador.setIdTCS(CB_TCS.SelectedValue.ToString());
            }
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarOpciones();
        }
        private void LimpiarOpciones()
        {
            _controlador.LimpiarOpciones();
            if (_controlador.LimpiarOpcionesIsOk) 
            {
                _modoInicializar = true;
                P_PROVEEDOR.Enabled = !_controlador.ProveedorIsOk;
                TB_PROVEEDOR.Text = _controlador.GetProveedorNombreFiltrar;
                CB_DEPARTAMENTO.SelectedIndex = -1;
                CB_GRUPO.SelectedIndex = -1;
                CB_MARCA.SelectedIndex = -1;
                CB_DEPOSITO.SelectedIndex = -1;
                CB_CATEGORIA.SelectedIndex = -1;
                CB_ORIGEN.SelectedIndex = -1;
                CB_IMPUESTO.SelectedIndex = -1;
                CB_ESTATUS.SelectedIndex = -1;
                CB_ADMDIVISA.SelectedIndex = -1;
                CB_PESADO.SelectedIndex = -1;
                CB_TCS.SelectedIndex = -1;
                CB_EXISTENCIA.SelectedIndex = -1;
                CB_CATALOGO.SelectedIndex = -1;
                _modoInicializar = false;
            }
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
            _controlador.setProveedorCadenaBuscar(TB_PROVEEDOR.Text.Trim().ToUpper());
        }
        private void BT_PROVEED_BUSCAR_Click(object sender, EventArgs e)
        {
            ProveedorBuscar();
        }
        private void ProveedorBuscar()
        {
            _controlador.ProveedorBuscar();
            P_PROVEEDOR.Enabled = !_controlador.ProveedorIsOk;
            TB_PROVEEDOR.Text = _controlador.GetProveedorNombreFiltrar;
        }
        private void L_PROVEEDOR_Click(object sender, EventArgs e)
        {
            _controlador.ProveedorLimpiar();
            P_PROVEEDOR.Enabled = true;
            TB_PROVEEDOR.Text = "";
            TB_PROVEEDOR.Focus();
        }


        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFiltros();
        }
        private void AbandonarFiltros()
        {
            _controlador.AbandonarFicha ();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
        private void FiltrosFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }
    }
}