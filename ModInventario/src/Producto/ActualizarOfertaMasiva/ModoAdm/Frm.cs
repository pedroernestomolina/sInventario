using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.ModoAdm
{
    public partial class Frm : Form
    {
        private IMasiva _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializaCombo();
            InicializarGrid();
        }
        private void InicializaCombo()
        {
            CB_TIPO_BUSQUEDA.DisplayMember = "desc";
            CB_TIPO_BUSQUEDA.ValueMember = "id";
            CB_PRECIO.DisplayMember = "desc";
            CB_PRECIO.ValueMember = "id";
        }
        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 7, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "DescPrd";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CodPrd";
            c2.HeaderText = "Codigo";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.Name = "VEstatus";
            c3.HeaderText = "*";
            c3.Visible = true;
            c3.Width = 50;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f;
            c3.DefaultCellStyle.BackColor = Color.Green;
            c3.DefaultCellStyle.ForeColor = Color.White;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(c2);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
        }


        public void setControlador(IMasiva ctr)
        {
            _controlador = ctr;
        }

        private bool _modoInicializar;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            TB_CADENA.Focus();
            TB_CADENA.Text = _controlador.CompBusqProducto.GetCadena;
            CB_TIPO_BUSQUEDA.DataSource = _controlador.CompBusqProducto.MetodoBusqueda_GetSource;
            CB_TIPO_BUSQUEDA.SelectedValue = _controlador.CompBusqProducto.MetodoBusqueda_GetId;
            CB_PRECIO.DataSource = _controlador.Precio.GetSource;
            CB_PRECIO.SelectedValue = _controlador.Precio.GetId;
            DTP_DESDE.Value = _controlador.GetDesde;
            DTP_HASTA.Value = _controlador.GetHasta;
            TB_PORCT.Text = _controlador.GetPorctDesc;
            DGV.DataSource = _controlador.Items.GetSource;
            L_ITEMS.Text = _controlador.Items.GetCnt.ToString("n0");
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
        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void CB_TIPO_BUSQUEDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.CompBusqProducto.setMetodo("");
            if (CB_TIPO_BUSQUEDA.SelectedIndex != -1)
            {
                _controlador.CompBusqProducto.setMetodo(CB_TIPO_BUSQUEDA.SelectedValue.ToString());
            }
        }
        private void CB_PRECIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Precio.setId("");
            if (CB_PRECIO.SelectedIndex != -1)
            {
                _controlador.Precio.setId(CB_PRECIO.SelectedValue.ToString());
            }
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setDesde(DTP_DESDE.Value);
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setHasta(DTP_HASTA.Value);
        }
        private void DTP_DESDE_Leave(object sender, EventArgs e)
        {
            _controlador.setDesde(DTP_DESDE.Value);
        }
        private void DTP_HASTA_Leave(object sender, EventArgs e)
        {
            _controlador.setHasta(DTP_HASTA.Value);
        }


        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.CompBusqProducto.setCadenaBuscar(TB_CADENA.Text.Trim().ToUpper());
        }
        private void TB_PORCT_Leave(object sender, EventArgs e)
        {
            _controlador.setPorct(decimal.Parse(TB_PORCT.Text));
            TB_PORCT.Text = _controlador.GetPorctDesc;
        }


        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            FiltrarBusqueda();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarBusqueda();
        }
        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }


        private void FiltrarBusqueda()
        {
            _controlador.CompBusqProducto.MostrarFiltros();
        }
        private void LimpiarBusqueda()
        {
            _controlador.LimpiarTodo();
            CB_TIPO_BUSQUEDA.SelectedValue = _controlador.CompBusqProducto.MetodoBusqueda_GetId;
            Actualizar();
        }
        private void Buscar()
        {
            _controlador.Buscar();
            Actualizar();
        }
        private void Actualizar()
        {
            L_ITEMS.Text = _controlador.Items.GetCnt.ToString("n0");
            TB_CADENA.Text = _controlador.CompBusqProducto.GetCadena;
            TB_CADENA.Focus();
        }
        private void Salir()
        {
            this.Close();
        }
    }
}