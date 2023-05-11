using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara.BusqProducto.Filtro
{
    public partial class Frm: Form
    {
        private ICompFiltro _controlador;


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
            CB_OFERTA.DisplayMember = "desc";
            CB_OFERTA.ValueMember = "id";
        }

        private bool _modoInicializar;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_DEPARTAMENTO.DataSource = _controlador.DepartamentoGrupo.Departamento.Ctrl.GetSource;
            CB_GRUPO.DataSource = _controlador.DepartamentoGrupo.Grupo.Ctrl.GetSource;
            CB_MARCA.DataSource = _controlador.Marca.Ctrl.GetSource;
            CB_DEPOSITO.DataSource = _controlador.Deposito.Ctrl.GetSource;
            CB_CATEGORIA.DataSource = _controlador.Categoria.Ctrl.GetSource;
            CB_ORIGEN.DataSource = _controlador.Origen.Ctrl.GetSource;
            CB_IMPUESTO.DataSource = _controlador.TasaIva.Ctrl.GetSource;
            CB_ESTATUS.DataSource = _controlador.Estatus.Ctrl.GetSource;
            CB_ADMDIVISA.DataSource = _controlador.Divisa.Ctrl.GetSource;
            CB_PESADO.DataSource = _controlador.Pesado.Ctrl.GetSource;
            CB_CATALOGO.DataSource = _controlador.Catalogo.Ctrl.GetSource;
            CB_EXISTENCIA.DataSource = _controlador.Existencia.Ctrl.GetSource;
            CB_TCS.DataSource = _controlador.TCS.Ctrl.GetSource;
            CB_OFERTA.DataSource = _controlador.Oferta.Ctrl.GetSource;

            CB_DEPARTAMENTO.SelectedValue = _controlador.DepartamentoGrupo.Departamento.Ctrl.GetId;
            CB_GRUPO.SelectedValue = _controlador.DepartamentoGrupo.Grupo.Ctrl.GetId;
            CB_MARCA.SelectedValue = _controlador.Marca.Ctrl.GetId;
            CB_DEPOSITO.SelectedValue = _controlador.Deposito.Ctrl.GetId;
            CB_CATEGORIA.SelectedValue = _controlador.Categoria.Ctrl.GetId;
            CB_ORIGEN.SelectedValue = _controlador.Origen.Ctrl.GetId;
            CB_IMPUESTO.SelectedValue = _controlador.TasaIva.Ctrl.GetId;
            CB_ESTATUS.SelectedValue = _controlador.Estatus.Ctrl.GetId;
            CB_ADMDIVISA.SelectedValue = _controlador.Divisa.Ctrl.GetId;
            CB_PESADO.SelectedValue = _controlador.Pesado.Ctrl.GetId;
            CB_EXISTENCIA.SelectedValue = _controlador.Existencia.Ctrl.GetId;
            CB_TCS.SelectedValue = _controlador.TCS.Ctrl.GetId;
            CB_CATALOGO.SelectedValue = _controlador.Catalogo.Ctrl.GetId;
            CB_OFERTA.SelectedValue= _controlador.Oferta.Ctrl.GetId;
            if (_controlador.DepartamentoGrupo.Departamento.Ctrl.GetId == "")
            {
                CB_GRUPO.Enabled = false;
            }

            CB_DEPARTAMENTO.Enabled = _controlador.DepartamentoGrupo.Departamento.GetHabilitar;
            CB_MARCA.Enabled = _controlador.Marca.GetHabilitar;
            CB_DEPOSITO.Enabled= _controlador.Deposito.GetHabilitar;
            CB_CATEGORIA.Enabled= _controlador.Categoria.GetHabilitar;
            CB_ORIGEN.Enabled= _controlador.Origen.GetHabilitar;
            CB_IMPUESTO.Enabled= _controlador.TasaIva.GetHabilitar;
            CB_ESTATUS.Enabled= _controlador.Estatus.GetHabilitar;
            CB_ADMDIVISA.Enabled= _controlador.Divisa.GetHabilitar;
            CB_PESADO.Enabled= _controlador.Pesado.GetHabilitar;
            CB_EXISTENCIA.Enabled= _controlador.Existencia.GetHabilitar;
            CB_TCS.Enabled = _controlador.TCS.GetHabilitar;
            CB_CATALOGO.Enabled = _controlador.Catalogo.GetHabilitar;
            CB_OFERTA.Enabled= _controlador.Oferta.GetHabilitar;

            TB_PROVEEDOR.Focus();
            ActualizarProveedor();
            _modoInicializar = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }
        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        public void setControlador(ICompFiltro ctr)
        {
            _controlador = ctr;
        }


        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.DepartamentoGrupo.setDepartamentoFichaById("");
            CB_GRUPO.Enabled = false;
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.DepartamentoGrupo.setDepartamentoFichaById(CB_DEPARTAMENTO.SelectedValue.ToString());
                CB_GRUPO.Enabled = true;
                CB_GRUPO.SelectedIndex = -1;
            }
        }
        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.DepartamentoGrupo.Grupo.Ctrl.setFichaById("");
            if (CB_GRUPO.SelectedIndex != -1) 
            {
                _controlador.DepartamentoGrupo.Grupo.Ctrl.setFichaById(CB_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Marca.Ctrl.setFichaById("");
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.Marca.Ctrl.setFichaById(CB_MARCA.SelectedValue.ToString());
            }
        }
        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Deposito.Ctrl.setFichaById("");
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.Deposito.Ctrl.setFichaById(CB_DEPOSITO.SelectedValue.ToString());
            }
        }
        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Categoria.Ctrl.setFichaById("");
            if (CB_CATEGORIA.SelectedIndex != -1) 
            {
                _controlador.Categoria.Ctrl.setFichaById(CB_CATEGORIA.SelectedValue.ToString());
            }
        }
        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Origen.Ctrl.setFichaById("");
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.Origen.Ctrl.setFichaById(CB_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.TasaIva.Ctrl.setFichaById("");
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.TasaIva.Ctrl.setFichaById(CB_IMPUESTO.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Estatus.Ctrl.setFichaById("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.Estatus.Ctrl.setFichaById(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_ADMDIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Divisa.Ctrl.setFichaById("");
            if (CB_ADMDIVISA.SelectedIndex != -1)
            {
                _controlador.Divisa.Ctrl.setFichaById(CB_ADMDIVISA.SelectedValue.ToString());
            }
        }
        private void CB_PESADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Pesado.Ctrl.setFichaById("");
            if (CB_PESADO.SelectedIndex != -1)
            {
                _controlador.Pesado.Ctrl.setFichaById(CB_PESADO.SelectedValue.ToString());
            }
        }
        private void CB_CATALOGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Catalogo.Ctrl.setFichaById("");
            if (CB_CATALOGO.SelectedIndex != -1)
            {
                _controlador.Catalogo.Ctrl.setFichaById(CB_CATALOGO.SelectedValue.ToString());
            }
        }
        private void CB_EXISTENCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Existencia.Ctrl.setFichaById("");
            if (CB_EXISTENCIA.SelectedIndex != -1)
            {
                _controlador.Existencia.Ctrl.setFichaById(CB_EXISTENCIA.SelectedValue.ToString());
            }
        }
        private void CB_TCS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.TCS.Ctrl.setFichaById("");
            if (CB_TCS.SelectedIndex != -1)
            {
                _controlador.TCS.Ctrl.setFichaById(CB_TCS.SelectedValue.ToString());
            }
        }
        private void CB_OFERTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.Oferta.Ctrl.setFichaById("");
            if (CB_OFERTA.SelectedIndex != -1)
            {
                _controlador.Oferta.Ctrl.setFichaById(CB_OFERTA.SelectedValue.ToString());
            }
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarOpciones();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            ProcesarFiltros();
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
        private void L_OFERTA_Click(object sender, EventArgs e)
        {
            CB_OFERTA.SelectedIndex = -1;
        }


        private void TB_PROVEEDOR_Leave(object sender, EventArgs e)
        {
            _controlador.Proveedor.setCadenaBuscar(TB_PROVEEDOR.Text.Trim().ToUpper());
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


        private void ProveedorBuscar()
        {
            _controlador.Proveedor.Buscar();
            ActualizarProveedor();
        }
        private void ActualizarProveedor()
        {
            P_PROVEEDOR.Enabled = _controlador.Proveedor.GetHabilitado;
            TB_PROVEEDOR.Text = _controlador.Proveedor.GetDescripcion;
            TB_PROVEEDOR.Focus();
        }
        private void ProcesarFiltros()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
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
            _modoInicializar = true;
            CB_DEPARTAMENTO.SelectedValue = _controlador.DepartamentoGrupo.Departamento.Ctrl.GetId;
            CB_GRUPO.Enabled = false;
            CB_GRUPO.SelectedValue = _controlador.DepartamentoGrupo.Grupo.Ctrl.GetId;
            CB_MARCA.SelectedValue = _controlador.Marca.Ctrl.GetId;
            CB_DEPOSITO.SelectedValue = _controlador.Deposito.Ctrl.GetId;
            CB_CATEGORIA.SelectedValue = _controlador.Categoria.Ctrl.GetId;
            CB_ORIGEN.SelectedValue = _controlador.Origen.Ctrl.GetId;
            CB_IMPUESTO.SelectedValue = _controlador.TasaIva.Ctrl.GetId;
            CB_ESTATUS.SelectedValue = _controlador.Estatus.Ctrl.GetId;
            CB_ADMDIVISA.SelectedValue = _controlador.Divisa.Ctrl.GetId;
            CB_PESADO.SelectedValue = _controlador.Pesado.Ctrl.GetId;
            CB_EXISTENCIA.SelectedValue = _controlador.Existencia.Ctrl.GetId;
            CB_TCS.SelectedValue = _controlador.TCS.Ctrl.GetId;
            CB_CATALOGO.SelectedValue = _controlador.Catalogo.Ctrl.GetId;
            CB_OFERTA.SelectedValue = _controlador.Oferta.Ctrl.GetId;
            ActualizarProveedor();
            _modoInicializar = false;
        }
        private void Salir()
        {
            this.Close();
        }
    }
}