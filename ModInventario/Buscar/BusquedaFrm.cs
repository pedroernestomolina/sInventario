using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Buscar
{
    public partial class BusquedaFrm : Form
    {
        private Gestion _controlador;


        public BusquedaFrm()
        {
            InitializeComponent();
            InicializarGrid();
            InicializaCombo();
        }

        private void InicializaCombo()
        {
            CB_TIPO_BUSQUEDA.DisplayMember = "desc";
            CB_TIPO_BUSQUEDA.ValueMember = "id";
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
            c1.DataPropertyName = "DescripcionPrd";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CodigoPrd";
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
            c3.DefaultCellStyle.ForeColor= Color.White;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Estatus";
            c4.Name = "Estatus";
            c4.Visible = false;
            c4.Width = 0;

            var c5= new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "exEmpCompra";
            c5.HeaderText = "Ex/Comp";
            c5.Visible = true;
            c5.Width = 70;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Format = "n2";
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.ToolTipText = "EXISTENCIA POR EMPAQUE DE COMPRA";

            var c5b = new DataGridViewTextBoxColumn();
            c5b.DataPropertyName = "exUnd";
            c5b.HeaderText = "Ex/Und";
            c5b.Visible = true;
            c5b.Width = 70;
            c5b.HeaderCell.Style.Font = f;
            c5b.DefaultCellStyle.Font = f1;
            c5b.DefaultCellStyle.Format = "n2";
            c5b.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5b.ToolTipText = "EXISTENCIA POR EMPAQUE DE UNIDAD";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "CostoCompra";
            c6.HeaderText = "Costo";
            c6.Visible = true;
            c6.Width = 70;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";
            c6.ToolTipText = "COSTO POR EMPAQUE DE COMPRA";

            var c6b = new DataGridViewTextBoxColumn();
            c6b.DataPropertyName = "CostoUndActual";
            c6b.HeaderText = "Costo";
            c6b.Visible = true;
            c6b.Width = 70;
            c6b.HeaderCell.Style.Font = f;
            c6b.DefaultCellStyle.Font = f1;
            c6b.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6b.DefaultCellStyle.Format = "n2";
            c6b.ToolTipText = "COSTO POR UNIDAD";

            DGV.Columns.Add(c2);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c5b);
            DGV.Columns.Add(c6b);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }
        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                var xcolor = Color.Green;
                var xestatus = "OK";

                if (row.Cells["Estatus"].Value.ToString() == "Activo") 
                {
                    xcolor = Color.Green;
                    xestatus = "OK";
                }
                if (row.Cells["Estatus"].Value.ToString() == "Suspendido")
                {
                    xcolor = Color.Orange;
                    xestatus = "SUSP";
                }
                if (row.Cells["Estatus"].Value.ToString() == "Inactivo")
                {
                    xcolor = Color.Red;
                    xestatus = "INAC";
                }
                row.Cells["VEstatus"].Style.BackColor = xcolor;
                row.Cells["VEstatus"].Value= xestatus;
            }
        }

        private bool _modoInicializar;
        private void BusquedaFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            TB_CADENA.Text = _controlador.CadenaBusqProducto;
            CB_TIPO_BUSQUEDA.DataSource = _controlador.GeTipoBusqueda_Source;
            CB_TIPO_BUSQUEDA.SelectedValue = _controlador.GetTipoBusqueda_Id;
            DGV.DataSource = _controlador.Source;
            _controlador.Source.CurrentChanged += Source_CurrentChanged;
            L_ITEMS.Text = _controlador.Items.ToString("n0");
            LimpiarEtiquetas();
            TB_CADENA.Focus();
            _modoInicializar = false;
        }

        private void Source_CurrentChanged(object sender, EventArgs e)
        {
            ActualizarItem();
        }
        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }
        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                VisualizarItem();
            }
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void VisualizarItem()
        {
            _controlador.VisualizarItem();
        }

        //EXISTENCIA
        private void BT_VER_EXISTENCIA_Click(object sender, EventArgs e)
        {
            VerExistencia();
        }
        private void BT_TALLA_COLOR_SABOR_Click(object sender, EventArgs e)
        {
            VerTallaColorSabor();
        }
        private void BT_ASIGNAR_DEPOSITO_Click(object sender, EventArgs e)
        {
            AsignarDeposito();
        }
        private void BT_MOV_KARDEX_Click(object sender, EventArgs e)
        {
            MovKardex();
        }
        private void MovKardex()
        {
            _controlador.MovKardex();
            TB_CADENA.Focus();
        }
        private void AsignarDeposito()
        {
            _controlador.AsignarDeposito();
            TB_CADENA.Focus();
        }
        private void VerExistencia()
        {
            _controlador.VerExistencia();
            TB_CADENA.Focus();
        }
        private void VerTallaColorSabor()
        {
            _controlador.VerTallaColorSabor();
            TB_CADENA.Focus();
        }

        //PRECIOS
        private void BT_PRECIO_EDITAR_Click(object sender, EventArgs e)
        {
            EditarPrecio();
        }
        private void BT_PRECIO_HISTORICO_Click(object sender, EventArgs e)
        {
            HistoricoPrecio();
        }
        private void BT_PRECIO_Click(object sender, EventArgs e)
        {
            VerPrecios();
        }
        private void BT_PRECIO_DSCTO_Click(object sender, EventArgs e)
        {
            DsctoOferta();
        }

        private void DsctoOferta()
        {
            _controlador.DsctoOferta();
        }
        private void VerPrecios()
        {
            _controlador.VerPrecios();
            TB_CADENA.Focus();
        }
        private void EditarPrecio()
        {
            _controlador.EditarPrecio();
            TB_CADENA.Focus();
        }
        private void HistoricoPrecio()
        {
            _controlador.HistoricoPrecio();
            TB_CADENA.Focus();
        }

        //COSTO
        private void BT_COSTO_Click(object sender, EventArgs e)
        {
            VerCosto();
        }
        private void BT_HISTORICO_COSTO_Click(object sender, EventArgs e)
        {
            HistoricoCosto();
        }
        private void BT_EDITAR_COSTO_Click(object sender, EventArgs e)
        {
            EditarCosto();
        }
        private void EditarCosto()
        {
            _controlador.EditarCosto();
            TB_CADENA.Focus();
        }
        private void HistoricoCosto()
        {
            _controlador.HistoricoCosto();
            TB_CADENA.Focus();
        }
        private void VerCosto()
        {
            _controlador.VerCosto();
            TB_CADENA.Focus();
        }

        //UTILTIS
        private void BT_GENERAR_QR_Click(object sender, EventArgs e)
        {
            GenerarQR();
        }
        private void TB_CAMBIO_ESTATUS_Click(object sender, EventArgs e)
        {
            CambioEstatus();
        }
        private void BT_IMAGEN_Click(object sender, EventArgs e)
        {
            GetImagen();
        }
        private void BT_PROVEEDORES_Click(object sender, EventArgs e)
        {
            Proveedores();
        }
        private void Proveedores()
        {
            _controlador.Proveedores();
        }
        private void GetImagen()
        {
            _controlador.VerImagen();
        }
        private void CambioEstatus()
        {
            _controlador.CambioEstatus();
        }
        private void GenerarQR()
        {
            _controlador.GenerarQR();
            TB_CADENA.Focus();
        }

        private void BusquedaFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) 
            {
                TB_CADENA.Focus();
            }
        }

        //PRODUCTO
        private void BT_AGREGAR_FICHA_Click(object sender, EventArgs e)
        {
            AgregarFicha();
        }
        private void BT_EDITAR_FICHA_Click(object sender, EventArgs e)
        {
            EditarFicha();
        }
        private void AgregarFicha()
        {
            _controlador.AgregarFicha();
            TB_CADENA.Focus();
            L_ITEMS.Text = _controlador.Items.ToString("n0");
        }
        private void EditarFicha()
        {
            _controlador.EditarFicha();
            TB_CADENA.Focus();
        }

        //BUSQUEDA
        private void CB_TIPO_BUSQUEDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setTipoBusqueda("");
            if (CB_TIPO_BUSQUEDA.SelectedIndex != -1)
            {
                _controlador.setTipoBusqueda(CB_TIPO_BUSQUEDA.SelectedValue.ToString());
            }
        }
        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.setCadenaBusc(TB_CADENA.Text.Trim().ToUpper());
        }
        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            FiltrarBusqueda();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void FiltrarBusqueda()
        {
            BT_BUSCAR.Enabled = false;
            _controlador.FiltrarBusqueda();
            BT_BUSCAR.Enabled = true;
            ActualizarBusqueda();
            DGV.Focus();
        }
        private void Limpiar()
        {
            _controlador.Limpiar();
            TB_CADENA.Text = _controlador.CadenaBusqProducto;
            TB_CADENA.Focus();
            L_ITEMS.Text = _controlador.Items.ToString("n0");
        }
        private void Buscar()
        {
            _controlador.Buscar();
            ActualizarBusqueda();
            TB_CADENA.Focus();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            Close();
        }


        private void ActualizarBusqueda()
        {
            L_ITEMS.Text = _controlador.Items.ToString("n0");
            TB_CADENA.Text = _controlador.CadenaBusqProducto;
            TB_CADENA.Focus();
        }
        public void ActualizarItem()
        {
            if (_controlador.Item == null)
            {
                LimpiarEtiquetas();
                return;
            }
            L_PRODUCTO.Text = _controlador.Item.Producto;
            L_DEPARTAMENTO.Text = _controlador.Item.Departamento;
            L_GRUPO.Text = _controlador.Item.Grupo;
            L_MARCA.Text = _controlador.Item.Marca;
            L_REFERENCIA.Text = _controlador.Item.Referencia;
            L_IMPUESTO.Text = _controlador.Item.Impuesto;
            L_EMPAQUE.Text = _controlador.Item.Empaque;

            L_CATEGORIA.Text = _controlador.Item.Categoria;
            L_ORIGEN.Text = _controlador.Item.Origen;
            L_ESTATUS.Text = _controlador.Item.Estatus;
            L_DIVISA.Text = _controlador.Item.Divisa;
            L_OFERTA.Text = _controlador.Item.EstatusOferta;
            L_CATALOGO.Text = _controlador.Item.ActivarCatalogo;

            L_PESADO.Text = _controlador.Item.Pesado;
            L_FECHA_ALTA.Text = _controlador.Item.FechaAlta.ToShortDateString();
            L_FECHA_ACT.Text = _controlador.Item.FechaUltimaActualizacion;

            L_ET_INV_EMP_COMPRA.Text = _controlador.ET_INV_EMP_COMPRA;
            L_ET_INV_EMP_INV.Text = _controlador.ET_INV_EMP_INV;
            L_ET_INV_EMP_UND.Text = _controlador.ET_INV_EMP_UND;
            L_INV_EMP_COMPRA.Text = _controlador.INV_EMP_COMPRA.ToString();
            L_INV_EMP_INV.Text = _controlador.INV_EMP_INV.ToString();
            L_INV_EMP_UND.Text = _controlador.INV_EMP_UND.ToString();
        }
        private void LimpiarEtiquetas()
        {
            L_PRODUCTO.Text = "";
            L_DEPARTAMENTO.Text = "";
            L_GRUPO.Text = "";
            L_MARCA.Text = "";
            L_REFERENCIA.Text = "";
            L_IMPUESTO.Text = "";
            L_EMPAQUE.Text = "";
            L_CATEGORIA.Text = "";
            L_ORIGEN.Text = "";
            L_ESTATUS.Text = "";
            L_CATALOGO.Text = "";
            L_DIVISA.Text = "";
            L_PESADO.Text = "";
            L_OFERTA.Text = "";
            L_FECHA_ALTA.Text = "";
            L_FECHA_ACT.Text = "";
            L_ET_INV_EMP_COMPRA.Text = "";
            L_ET_INV_EMP_INV.Text = "";
            L_ET_INV_EMP_UND.Text = "";
            L_INV_EMP_COMPRA.Text = "";
            L_INV_EMP_INV.Text = "";
            L_INV_EMP_UND.Text = "";
        }
    }
}