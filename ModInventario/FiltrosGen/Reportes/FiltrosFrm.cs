using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.FiltrosGen.Reportes
{

    public partial class FiltrosFrm : Form
    {

        private Gestion _controlador;


        public FiltrosFrm()
        {
            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            CB_DEPARTAMENTO.DisplayMember = "desc";
            CB_DEPARTAMENTO.ValueMember = "id";
            CB_DEPOSITO.DisplayMember = "desc";
            CB_DEPOSITO.ValueMember = "id";
            CB_MARCA.DisplayMember = "desc";
            CB_MARCA.ValueMember = "id";
            CB_SUCURSAL.DisplayMember = "desc";
            CB_SUCURSAL.ValueMember = "id";
            CB_ADMDIVISA.DisplayMember = "desc";
            CB_ADMDIVISA.ValueMember = "id";
            CB_CATEGORIA.DisplayMember = "desc";
            CB_CATEGORIA.ValueMember = "id";
            CB_ORIGEN.DisplayMember = "desc";
            CB_ORIGEN.ValueMember = "id";
            CB_IMPUESTO.DisplayMember = "desc";
            CB_IMPUESTO.ValueMember = "id";
            CB_ESTATUS.DisplayMember = "desc";
            CB_ESTATUS.ValueMember = "id";
            CB_GRUPO.DisplayMember = "desc";
            CB_GRUPO.ValueMember = "id";
        }

        bool _modoInicializar;
        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_DEPOSITO.DataSource = _controlador.SourceDeposito;
            CB_MARCA.DataSource = _controlador.SourceMarca;
            CB_DEPARTAMENTO.DataSource = _controlador.SourceDepart;
            CB_ADMDIVISA.DataSource = _controlador.SourceAdmDivisa;
            CB_SUCURSAL.DataSource = _controlador.SourceSucursal;
            CB_CATEGORIA.DataSource = _controlador.SourceCategoria;
            CB_ORIGEN.DataSource = _controlador.SourceOrigen;
            CB_IMPUESTO.DataSource = _controlador.SourceTasa;
            CB_ESTATUS.DataSource = _controlador.SourceEstatus;
            CB_GRUPO.DataSource = _controlador.SourceGrupo;

            TB_PRODUCTO.Text = _controlador.ProductoAFiltrar;
            CB_DEPARTAMENTO.SelectedValue = _controlador.AutoDepartamento;
            CB_DEPOSITO.SelectedValue = _controlador.AutoDeposito;
            CB_MARCA.SelectedValue = _controlador.AutoMarca;
            CB_SUCURSAL.SelectedValue = _controlador.AutoSucursal;
            CB_ADMDIVISA.SelectedValue = _controlador.IdAdmDivisa;
            CB_CATEGORIA.SelectedValue = _controlador.IdCategoria;
            CB_IMPUESTO.SelectedValue = _controlador.AutoTasa;
            CB_ORIGEN.SelectedValue = _controlador.IdOrigen;
            CB_ESTATUS.SelectedValue = _controlador.IdEstatus;
            CB_GRUPO.SelectedValue = _controlador.AutoGrupo;
            DTP_DESDE.Value = _controlador.Desde;
            DTP_HASTA.Value = _controlador.Hasta;

            CB_DEPOSITO.Enabled = _controlador.Filtros.ActivarDeposito;
            TB_PRODUCTO.Enabled = _controlador.Filtros.ActivarProducto;
            BT_PRODUCTO_BUSCAR.Enabled = _controlador.Filtros.ActivarProducto;
            CB_DEPARTAMENTO.Enabled = _controlador.Filtros.ActivarDepartamento;
            CB_ADMDIVISA.Enabled = _controlador.Filtros.ActivarAdmDivisa;
            CB_SUCURSAL.Enabled = _controlador.Filtros.ActivarSucursal;
            CB_IMPUESTO.Enabled = _controlador.Filtros.ActivarTasaIva;
            CB_ESTATUS.Enabled = _controlador.Filtros.ActivarEstatus;
            CB_ORIGEN.Enabled = _controlador.Filtros.ActivarOrigen;
            CB_CATEGORIA.Enabled = _controlador.Filtros.ActivarCategoria;
            CB_MARCA.Enabled = _controlador.Filtros.ActivarMarca;
            CB_GRUPO.Enabled = _controlador.Filtros.ActivarGrupo;
            DTP_DESDE.Enabled = _controlador.Filtros.ActivarDesde;
            DTP_HASTA.Enabled = _controlador.Filtros.ActivarHasta;
            _modoInicializar = false;

            P_BUSCAR_PRODUCTO.Enabled = true;
            if (_controlador.ProcesarIsOk)
            {
                P_BUSCAR_PRODUCTO.Enabled = false;
            }
            TB_PRODUCTO.Focus();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setDepartamento("");
            CB_GRUPO.Enabled = false;
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.setDepartamento(CB_DEPARTAMENTO.SelectedValue.ToString());
                CB_GRUPO.Enabled = true;
            }
            CB_GRUPO.SelectedIndex = -1;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setDeposito("");
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.setDeposito(CB_DEPOSITO.SelectedValue.ToString());
            }
        }

        private void CB_ADMDIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setAdmDivisa("");
            if (CB_ADMDIVISA.SelectedIndex != -1)
            {
                _controlador.setAdmDivisa(CB_ADMDIVISA.SelectedValue.ToString());
            }
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setSucursal("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
            }
        }

        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) 
                return;

            _controlador.setTasaIva("");
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.setTasaIva(CB_IMPUESTO.SelectedValue.ToString());
            }
        }

        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }

        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setCategoria("");
            if (CB_CATEGORIA.SelectedIndex != -1)
            {
                _controlador.setCategoria(CB_CATEGORIA.SelectedValue.ToString());
            }
        }

        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setOrigen("");
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.setOrigen(CB_ORIGEN.SelectedValue.ToString());
            }
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }

        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setMarca("");
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.setMarca(CB_MARCA.SelectedValue.ToString());
            }
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setDesde(DTP_DESDE.Value.Date);
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setHasta(DTP_HASTA.Value.Date);
        }

          private void Salir()
        {
            this.Close();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            ProcesarFiltros();
        }

        private void ProcesarFiltros()
        {
            _controlador.ProcesarFiltros();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
            if (_controlador.LimpiarFiltrosIsOK)
            {
                _modoInicializar = true;
                P_BUSCAR_PRODUCTO.Enabled = true;
                TB_PRODUCTO.Text = "";
                CB_DEPARTAMENTO.SelectedIndex = -1;
                CB_DEPOSITO.SelectedIndex = -1;
                CB_ADMDIVISA.SelectedIndex = -1;
                CB_SUCURSAL.SelectedIndex = -1;
                CB_CATEGORIA.SelectedIndex = -1;
                CB_ORIGEN.SelectedIndex=-1;
                CB_IMPUESTO.SelectedIndex=-1;
                CB_ESTATUS.SelectedIndex=-1;
                CB_GRUPO.SelectedIndex = -1;
                CB_MARCA.SelectedIndex = -1;
                DTP_DESDE.Value = DateTime.Now.Date;
                DTP_HASTA.Value = DateTime.Now.Date;
                _modoInicializar = false;
            }
        }

        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            CB_DEPARTAMENTO.SelectedIndex = -1;
        }

        private void L_ADMDIVISA_Click(object sender, EventArgs e)
        {
            CB_ADMDIVISA.SelectedIndex = -1;
        }

        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            CB_DEPOSITO.SelectedIndex = -1;
        }

        private void L_OFERTA_Click(object sender, EventArgs e)
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }

        private void L_IMPUESTO_Click(object sender, EventArgs e)
        {
            CB_IMPUESTO.SelectedIndex = -1;
        }

        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }

        private void L_CATEGORIA_Click(object sender, EventArgs e)
        {
            CB_CATEGORIA.SelectedIndex = -1;
        }

        private void L_ORIGEN_Click(object sender, EventArgs e)
        {
            CB_ORIGEN.SelectedIndex = -1;
        }

        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }

        private void L_DESDE_Click(object sender, EventArgs e)
        {
            DTP_DESDE.Value = DateTime.Now.Date;
        }

        private void L_HASTA_Click(object sender, EventArgs e)
        {
            DTP_HASTA.Value = DateTime.Now.Date;
        }

        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            CB_GRUPO.SelectedIndex = -1;
        }

        private void L_MARCA_Click(object sender, EventArgs e)
        {
            CB_MARCA.SelectedIndex = -1;
        }

        private void BT_PRODUCTO_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            _controlador.BuscarProducto();
            if (_controlador.ProductoIsOk)
            {
                P_BUSCAR_PRODUCTO.Enabled = false;
            }
            TB_PRODUCTO.Text = _controlador.ProductoAFiltrar;
        }

        private void TB_PRODUCTO_Leave(object sender, EventArgs e)
        {
            _controlador.setProductoBuscar(TB_PRODUCTO.Text.Trim().ToUpper());
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void L_PRODUCTO_Click(object sender, EventArgs e)
        {
            _controlador.LimpiarProducto();
            P_BUSCAR_PRODUCTO.Enabled = true;
            TB_PRODUCTO.Text = "";
        }

        private void FiltrosFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk) 
            {
                e.Cancel = false;
            }
        }
    
    }

}