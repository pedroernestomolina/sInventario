using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroRep.ModoSucursal
{
    public partial class FiltrosFrm : Form
    {
        private IModoSucursal _controlador;


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
            CB_PESADO.DisplayMember = "desc";
            CB_PESADO.ValueMember = "id";
            CB_PRECIO.DisplayMember = "desc";
            CB_PRECIO.ValueMember = "id";
            CB_OFERTA.DisplayMember = "desc";
            CB_OFERTA.ValueMember = "id";
        }

        bool _modoInicializar;
        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_DEPOSITO.DataSource = _controlador.GetDeposito_Source;
            CB_DEPARTAMENTO.DataSource = _controlador.GetDepartamento_Source;
            CB_GRUPO.DataSource = _controlador.GetGrupo_Source;
            CB_MARCA.DataSource = _controlador.GetMarca_Source;
            CB_ADMDIVISA.DataSource = _controlador.GetAdmDivisa_Source;
            CB_IMPUESTO.DataSource = _controlador.GetImpuesto_Source;
            CB_ESTATUS.DataSource = _controlador.GetEstatus_Source;
            CB_PESADO.DataSource = _controlador.GetPesado_Source;
            CB_SUCURSAL.DataSource = _controlador.GetSucursal_Source;
            CB_CATEGORIA.DataSource = _controlador.GetCategoria_Source;
            CB_ORIGEN.DataSource = _controlador.GetOrigen_Source;
            CB_PRECIO.DataSource = _controlador.GetPrecio_Source;
            CB_OFERTA.DataSource = _controlador.Oferta.GetSource;

            CB_DEPOSITO.SelectedValue = _controlador.GetDeposito_Id;
            CB_DEPARTAMENTO.SelectedValue = _controlador.GetDepartamento_Id;
            CB_GRUPO.SelectedValue = _controlador.GetGrupo_Id;
            CB_MARCA.SelectedValue = _controlador.GetMarca_Id;
            CB_ADMDIVISA.SelectedValue = _controlador.GetAdmDivisa_Id;
            CB_IMPUESTO.SelectedValue = _controlador.GetImpuesto_Id;
            CB_ESTATUS.SelectedValue = _controlador.GetEstatus_Id;
            CB_PESADO.SelectedValue = _controlador.GetPesado_Id;
            CB_SUCURSAL.SelectedValue = _controlador.GetSucursal_Id;
            CB_CATEGORIA.SelectedValue = _controlador.GetCategoria_Id;
            CB_ORIGEN.SelectedValue = _controlador.GetOrigen_Id;
            CB_PRECIO.SelectedValue = _controlador.GetPrecio_Id;
            CB_OFERTA.SelectedValue = _controlador.Oferta.GetId;
            DTP_DESDE.Value = _controlador.GetDesde;
            DTP_HASTA.Value = _controlador.GetHasta;
            TB_PRODUCTO.Text = _controlador.GetProducto;
            
            CB_DEPOSITO.Enabled = _controlador.GetHabilitarDeposito;
            CB_DEPARTAMENTO.Enabled = _controlador.GetHabilitarDepartamento;
            CB_GRUPO.Enabled = false;
            CB_MARCA.Enabled = _controlador.GetHabilitarMarca;
            CB_ADMDIVISA.Enabled = _controlador.GetHabilitarAdmDivisa;
            CB_IMPUESTO.Enabled = _controlador.GetHabilitarImpuesto;
            CB_ESTATUS.Enabled = _controlador.GetHabilitarEstatus;
            CB_PESADO.Enabled = _controlador.GetHabilitarPesado;
            CB_SUCURSAL.Enabled = _controlador.GetHabilitarSucursal;
            CB_ORIGEN.Enabled = _controlador.GetHabilitarOrigen;
            CB_CATEGORIA.Enabled = _controlador.GetHabilitarCategoria;
            CB_PRECIO.Enabled = _controlador.GetHabilitarPrecio;
            CB_OFERTA.Enabled = _controlador.Oferta.GetHabilitar;
            DTP_DESDE.Enabled = _controlador.GetHabilitarFechaDesde;
            DTP_HASTA.Enabled = _controlador.GetHabilitarFechaHasta;
            TB_PRODUCTO.Enabled = _controlador.GetHabilitarProducto;
            BT_PRODUCTO_BUSCAR.Enabled = _controlador.GetHabilitarProducto; ;
            _modoInicializar = false;

            P_BUSCAR_PRODUCTO.Enabled = true;
            if (_controlador.ProcesarIsOk)
            {
                P_BUSCAR_PRODUCTO.Enabled = false;
            }
            TB_PRODUCTO.Focus();
        }


        public void setControlador(IModoSucursal ctr)
        {
            _controlador = ctr;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setDeposito("");
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.setDeposito(CB_DEPOSITO.SelectedValue.ToString());
            }
        }
        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setDepartamento("");
            CB_GRUPO.Enabled = false;
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.setDepartamento(CB_DEPARTAMENTO.SelectedValue.ToString());
                CB_GRUPO.Enabled = true;
                CB_GRUPO.SelectedIndex = -1;
            }
        }
        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setMarca("");
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.setMarca(CB_MARCA.SelectedValue.ToString());
            }
        }
        private void CB_ADMDIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setAdmDivisa("");
            if (CB_ADMDIVISA.SelectedIndex != -1)
            {
                _controlador.setAdmDivisa(CB_ADMDIVISA.SelectedValue.ToString());
            }
        }
        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setImpuesto("");
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.setImpuesto(CB_IMPUESTO.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_PESADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setPesado("");
            if (CB_PESADO.SelectedIndex != -1)
            {
                _controlador.setPesado(CB_PESADO.SelectedValue.ToString());
            }
        }
        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setSucursal("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
            }
        }
        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setCategoria("");
            if (CB_CATEGORIA.SelectedIndex != -1)
            {
                _controlador.setCategoria(CB_CATEGORIA.SelectedValue.ToString());
            }
        }
        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setOrigen("");
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.setOrigen(CB_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_PRECIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setPrecio("");
            if (CB_PRECIO.SelectedIndex != -1)
            {
                _controlador.setPrecio(CB_PRECIO.SelectedValue.ToString());
            }
        }
        private void CB_OFERTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Oferta.setId("");
            if (CB_OFERTA.SelectedIndex != -1)
            {
                _controlador.Oferta.setId(CB_OFERTA.SelectedValue.ToString());
            }
        }


        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setDesde(DTP_DESDE.Value.Date);
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setHasta(DTP_HASTA.Value.Date);
        }


        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            CB_DEPARTAMENTO.SelectedIndex = -1;
        }
        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            CB_DEPOSITO.SelectedIndex = -1;
        }
        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            CB_GRUPO.SelectedIndex = -1;
        }
        private void L_MARCA_Click(object sender, EventArgs e)
        {
            CB_MARCA.SelectedIndex = -1;
        }
        private void L_ADMDIVISA_Click(object sender, EventArgs e)
        {
            CB_ADMDIVISA.SelectedIndex = -1;
        }
        private void L_IMPUESTO_Click(object sender, EventArgs e)
        {
            CB_IMPUESTO.SelectedIndex = -1;
        }
        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }
        private void L_PESADO_Click(object sender, EventArgs e)
        {
            CB_PESADO.SelectedIndex = -1;
        }
        private void L_DESDE_Click(object sender, EventArgs e)
        {
            DTP_DESDE.Value = DateTime.Now.Date;
        }
        private void L_HASTA_Click(object sender, EventArgs e)
        {
            DTP_HASTA.Value = DateTime.Now.Date;
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
        private void L_PRODUCTO_Click(object sender, EventArgs e)
        {
            _controlador.LimpiarProducto();
            if (_controlador.LimpiarProductoIsOk)
            {
                P_BUSCAR_PRODUCTO.Enabled = true;
                TB_PRODUCTO.Text = "";
                TB_PRODUCTO.Focus();
            }
        }
        private void L_PRECIO_Click(object sender, EventArgs e)
        {
            CB_PRECIO.SelectedIndex = -1;
        }
        private void L_OFERTA_Click(object sender, EventArgs e)
        {
            CB_OFERTA.SelectedIndex = -1;
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
        private void BT_PRODUCTO_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }


        private void LimpiarFiltros()
        {
            _controlador.LimpiarOpciones();
            if (_controlador.LimpiarOpcionesIsOk)
            {
                _modoInicializar = true;
                CB_DEPOSITO.SelectedIndex = -1;
                CB_DEPARTAMENTO.SelectedIndex = -1;
                CB_GRUPO.SelectedIndex = -1;
                CB_MARCA.SelectedIndex = -1;
                CB_ADMDIVISA.SelectedIndex = -1;
                CB_IMPUESTO.SelectedIndex = -1;
                CB_ESTATUS.SelectedIndex = -1;
                CB_PESADO.SelectedIndex = -1;
                CB_SUCURSAL.SelectedIndex = -1;
                CB_CATEGORIA.SelectedIndex = -1;
                CB_ORIGEN.SelectedIndex = -1;
                CB_PRECIO.SelectedIndex = -1;
                P_BUSCAR_PRODUCTO.Enabled = true;
                TB_PRODUCTO.Text = "";
                DTP_DESDE.Value = DateTime.Now.Date;
                DTP_HASTA.Value = DateTime.Now.Date;
                _modoInicializar = false;
            }
        }


        private void BuscarProducto()
        {
            _controlador.BuscarProducto();
            if (_controlador.ProductoIsOk)
            {
                P_BUSCAR_PRODUCTO.Enabled = false;
                TB_PRODUCTO.Text = _controlador.GetProducto;
            }
            TB_PRODUCTO.Focus();
        }
        private void TB_PRODUCTO_Leave(object sender, EventArgs e)
        {
            _controlador.setProducto(TB_PRODUCTO.Text.Trim().ToUpper());
        }


        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
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
        private void Salir()
        {
            this.Close();
        }


        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void FiltrosFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if ((_controlador.ProcesarIsOk && _controlador.FiltrosIsOK) || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }
    }
}