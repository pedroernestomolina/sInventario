using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara.Reportes.ModoSucursal
{
    public partial class Frm : Form
    {
        private IFiltroRep _controlador;


        public Frm()
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
            CB_EMPAQUE.DisplayMember = "desc";
            CB_EMPAQUE.ValueMember = "id";
            CB_OFERTA.DisplayMember = "desc";
            CB_OFERTA.ValueMember = "id";
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
        }

        bool _modoInicializar;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_DEPOSITO.DataSource = _controlador.Deposito.Ctrl.GetSource;
            CB_DEPARTAMENTO.DataSource = _controlador.DepartGrupo.Departamento.Ctrl.GetSource;
            CB_GRUPO.DataSource = _controlador.DepartGrupo.Grupo.Ctrl.GetSource; 
            CB_MARCA.DataSource = _controlador.Marca.Ctrl.GetSource;
            CB_ADMDIVISA.DataSource = _controlador.EstatusDivisa.Ctrl.GetSource;
            CB_IMPUESTO.DataSource = _controlador.TasaIva.Ctrl.GetSource;
            CB_ESTATUS.DataSource = _controlador.Estatus.Ctrl.GetSource;
            CB_PESADO.DataSource = _controlador.EstatusPesado.Ctrl.GetSource; 
            CB_SUCURSAL.DataSource = _controlador.Sucursal.Ctrl.GetSource;
            CB_CATEGORIA.DataSource = _controlador.Categoria.Ctrl.GetSource;
            CB_ORIGEN.DataSource = _controlador.Origen.Ctrl.GetSource;
            CB_PRECIO.DataSource = _controlador.Precio.Ctrl.GetSource;
            CB_EMPAQUE.DataSource = _controlador.Empaque.Ctrl.GetSource;
            CB_OFERTA.DataSource = _controlador.Oferta.Ctrl.GetSource;
            CB_CONCEPTO.DataSource = _controlador.Concepto.Ctrl.GetSource;

            CB_DEPOSITO.SelectedValue = _controlador.Deposito.Ctrl.GetId;
            CB_DEPARTAMENTO.SelectedValue = _controlador.DepartGrupo.Departamento.Ctrl.GetId;
            CB_GRUPO.SelectedValue = _controlador.DepartGrupo.Grupo.Ctrl.GetId;
            CB_MARCA.SelectedValue = _controlador.Marca.Ctrl.GetId;
            CB_ADMDIVISA.SelectedValue = _controlador.EstatusDivisa.Ctrl.GetId;
            CB_IMPUESTO.SelectedValue = _controlador.TasaIva.Ctrl.GetId;
            CB_ESTATUS.SelectedValue = _controlador.Estatus.Ctrl.GetId;
            CB_PESADO.SelectedValue = _controlador.EstatusPesado.Ctrl.GetId;
            CB_SUCURSAL.SelectedValue = _controlador.Sucursal.Ctrl.GetId ;
            CB_CATEGORIA.SelectedValue = _controlador.Categoria.Ctrl.GetSource;
            CB_ORIGEN.SelectedValue = _controlador.Origen.Ctrl.GetSource;
            CB_PRECIO.SelectedValue = _controlador.Precio.Ctrl.GetSource;
            CB_EMPAQUE.SelectedValue = _controlador.Empaque.Ctrl.GetSource;
            CB_OFERTA.SelectedValue = _controlador.Oferta.Ctrl.GetSource;
            CB_CONCEPTO.SelectedValue = _controlador.Concepto.Ctrl.GetSource;
            TB_PRODUCTO.Text = _controlador.Producto.GetDescripcion;
            DTP_DESDE.Value = _controlador.Desde.GetFecha;
            DTP_HASTA.Value = _controlador.Hasta.GetFecha;

            CB_DEPOSITO.Enabled = _controlador.Deposito.GetHabilitar;
            CB_DEPARTAMENTO.Enabled = _controlador.DepartGrupo.Departamento.GetHabilitar; 
            CB_GRUPO.Enabled = false;
            CB_MARCA.Enabled = _controlador.Marca.GetHabilitar;
            CB_ADMDIVISA.Enabled = _controlador.EstatusDivisa.GetHabilitar;
            CB_IMPUESTO.Enabled = _controlador.TasaIva.GetHabilitar;
            CB_ESTATUS.Enabled = _controlador.Estatus.GetHabilitar;
            CB_PESADO.Enabled = _controlador.EstatusPesado.GetHabilitar;
            CB_SUCURSAL.Enabled = _controlador.Sucursal.GetHabilitar;
            CB_ORIGEN.Enabled = _controlador.Origen.GetHabilitar;
            CB_CATEGORIA.Enabled = _controlador.Categoria.GetHabilitar;
            CB_PRECIO.Enabled = _controlador.Precio.GetHabilitar;
            CB_EMPAQUE.Enabled = _controlador.Empaque.GetHabilitar;
            CB_OFERTA.Enabled = _controlador.Oferta.GetHabilitar;
            CB_CONCEPTO.Enabled = _controlador.Concepto.GetHabilitar;
            DTP_DESDE.Enabled = _controlador.Desde.GetHabilitar;
            DTP_HASTA.Enabled = _controlador.Hasta.GetHabilitar;
            P_CTR_PRODUCTO.Enabled = _controlador.Producto.GetHabilitar;
            panel30.Enabled = _controlador.Producto.GetHabilitado;
            P_BUSCAR_PRODUCTO.Enabled = _controlador.Producto.GetHabilitado;
            _modoInicializar = false;
            TB_PRODUCTO.Focus();
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if ((_controlador.ProcesarIsOk && _controlador.ProcesarIsOk) || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        public void setControlador(IFiltroRep ctr)
        {
            _controlador = ctr;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Deposito.Ctrl.setFichaById("");
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.Deposito.Ctrl.setFichaById(CB_DEPOSITO.SelectedValue.ToString());
            }
        }
        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.DepartGrupo.setDepartamentoFichaById("");
            CB_GRUPO.Enabled = false;
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.DepartGrupo.setDepartamentoFichaById(CB_DEPARTAMENTO.SelectedValue.ToString());
                CB_GRUPO.Enabled = true;
                CB_GRUPO.SelectedIndex = -1;
            }
        }
        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.DepartGrupo.Grupo.Ctrl.setFichaById("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.DepartGrupo.Grupo.Ctrl.setFichaById(CB_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Marca.Ctrl.setFichaById("");
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.Marca.Ctrl.setFichaById(CB_MARCA.SelectedValue.ToString());
            }
        }
        private void CB_ADMDIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.EstatusDivisa.Ctrl.setFichaById("");
            if (CB_ADMDIVISA.SelectedIndex != -1)
            {
                _controlador.EstatusDivisa.Ctrl.setFichaById(CB_ADMDIVISA.SelectedValue.ToString());
            }
        }
        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.TasaIva.Ctrl.setFichaById("");
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.TasaIva.Ctrl.setFichaById(CB_IMPUESTO.SelectedValue.ToString());
            }
        }
        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Estatus.Ctrl.setFichaById("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.Estatus.Ctrl.setFichaById(CB_ESTATUS.SelectedValue.ToString());
            }
        }
        private void CB_PESADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.EstatusPesado.Ctrl.setFichaById(""); 
            if (CB_PESADO.SelectedIndex != -1)
            {
                _controlador.EstatusPesado.Ctrl.setFichaById(CB_PESADO.SelectedValue.ToString());
            }
        }
        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Sucursal.Ctrl.setFichaById("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.Sucursal.Ctrl.setFichaById(CB_SUCURSAL.SelectedValue.ToString());
            }
        }
        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Categoria.Ctrl.setFichaById("");
            if (CB_CATEGORIA.SelectedIndex != -1)
            {
                _controlador.Categoria.Ctrl.setFichaById(CB_CATEGORIA.SelectedValue.ToString());
            }
        }
        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Origen.Ctrl.setFichaById("");
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.Origen.Ctrl.setFichaById(CB_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_PRECIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Precio.Ctrl.setFichaById(""); 
            if (CB_PRECIO.SelectedIndex != -1)
            {
                _controlador.Precio.Ctrl.setFichaById(CB_PRECIO.SelectedValue.ToString());
            }
        }
        private void CB_EMPAQUE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Empaque.Ctrl.setFichaById("");
            if (CB_PRECIO.SelectedIndex != -1)
            {
                _controlador.Empaque.Ctrl.setFichaById(CB_PRECIO.SelectedValue.ToString());
            }
        }
        private void CB_OFERTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Oferta.Ctrl.setFichaById("");
            if (CB_OFERTA.SelectedIndex != -1)
            {
                _controlador.Oferta.Ctrl.setFichaById(CB_OFERTA.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Concepto.Ctrl.setFichaById("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.Concepto.Ctrl.setFichaById(CB_CONCEPTO.SelectedValue.ToString());
            }
        }


        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Desde.setFecha(DTP_DESDE.Value.Date);
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Hasta.setFecha(DTP_HASTA.Value.Date);
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
            _controlador.Producto.Limpiar();
            limpiarProducto();
        }
        private void L_PRECIO_Click(object sender, EventArgs e)
        {
            CB_PRECIO.SelectedIndex = -1;
        }
        private void L_EMPAQUE_Click(object sender, EventArgs e)
        {
            CB_EMPAQUE.SelectedIndex = -1;
        }
        private void L_OFERTA_Click(object sender, EventArgs e)
        {
            CB_OFERTA.SelectedIndex = -1;
        }
        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            CB_CONCEPTO.SelectedIndex = -1;
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
            _controlador.LimpiarFiltros();
            _modoInicializar = true;
            CB_DEPOSITO.SelectedValue = _controlador.Deposito.Ctrl.GetId;
            CB_DEPARTAMENTO.SelectedValue = _controlador.DepartGrupo.Departamento.Ctrl.GetId;
            CB_GRUPO.SelectedValue = _controlador.DepartGrupo.Grupo.Ctrl.GetId;
            CB_GRUPO.Enabled = false;
            CB_MARCA.SelectedValue = _controlador.Marca.Ctrl.GetId;
            CB_ADMDIVISA.SelectedValue = _controlador.EstatusDivisa.Ctrl.GetId;
            CB_IMPUESTO.SelectedValue = _controlador.TasaIva.Ctrl.GetId;
            CB_ESTATUS.SelectedValue = _controlador.Estatus.Ctrl.GetId;
            CB_PESADO.SelectedValue = _controlador.EstatusPesado.Ctrl.GetId; ;
            CB_SUCURSAL.SelectedValue = _controlador.Sucursal.Ctrl.GetId;
            CB_CATEGORIA.SelectedValue = _controlador.Categoria.Ctrl.GetSource;
            CB_ORIGEN.SelectedValue = _controlador.Origen.Ctrl.GetSource;
            CB_PRECIO.SelectedValue = _controlador.Precio.Ctrl.GetSource;
            CB_EMPAQUE.SelectedValue = _controlador.Empaque.Ctrl.GetSource;
            CB_OFERTA.SelectedValue = _controlador.Oferta.Ctrl.GetSource;
            CB_CONCEPTO.SelectedValue = _controlador.Concepto.Ctrl.GetSource; 
            DTP_DESDE.Value = _controlador.Desde.GetFecha;
            DTP_HASTA.Value = _controlador.Hasta.GetFecha;
            limpiarProducto();
            _modoInicializar = false;
        }

        private void BuscarProducto()
        {
            _controlador.Producto.Buscar();
            if (_controlador.Producto.BuscarIsOk)
            {
                P_BUSCAR_PRODUCTO.Enabled = _controlador.Producto.GetHabilitado;
                TB_PRODUCTO.Text = _controlador.Producto.GetDescripcion;
            }
            TB_PRODUCTO.Focus();
        }
        private void TB_PRODUCTO_Leave(object sender, EventArgs e)
        {
            _controlador.Producto.setCadenaBuscar(TB_PRODUCTO.Text.Trim().ToUpper());
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
        private void limpiarProducto()
        {
            P_BUSCAR_PRODUCTO.Enabled = _controlador.Producto.GetHabilitado;
            TB_PRODUCTO.Text = _controlador.Producto.GetDescripcion;
            TB_PRODUCTO.Focus();
        }
    }
}