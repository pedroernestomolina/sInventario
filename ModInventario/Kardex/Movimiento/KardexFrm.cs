using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Kardex.Movimiento
{

    public partial class KardexFrm : Form
    {


        private Gestion _controlador;


        public KardexFrm()
        {
            InitializeComponent();
        }

        private void InicializaGrid()
        {
            InicializaGrid_Compra();
            InicializaGrid_Venta();
            InicializaGrid_Inventario();
        }

        private void InicializaGrid_Compra()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);

            DGV_COMPRA.AllowUserToAddRows = false;
            DGV_COMPRA.AllowUserToDeleteRows = false;
            DGV_COMPRA.AutoGenerateColumns = false;
            DGV_COMPRA.AllowUserToResizeRows = false;
            DGV_COMPRA.AllowUserToResizeColumns = false;
            DGV_COMPRA.AllowUserToOrderColumns = false;
            DGV_COMPRA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_COMPRA.MultiSelect = false;
            DGV_COMPRA.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CntMovimiento";
            c1.HeaderText = "Cnt/Mov";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Deposito";
            c2.HeaderText = "Deposito";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Siglas";
            c5.HeaderText = "Tipo/Mov";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.Width = 80;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Concepto";
            c3.HeaderText = "Concepto";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.MinimumWidth = 120;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CntInventario";
            c4.HeaderText = "Cnt/Und";
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment =  DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format= _controlador.Decimales;

            DGV_COMPRA.Columns.Add(c2);
            DGV_COMPRA.Columns.Add(c1);
            DGV_COMPRA.Columns.Add(c5);
            DGV_COMPRA.Columns.Add(c3);
            DGV_COMPRA.Columns.Add(c4);
        }

        private void InicializaGrid_Venta()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);

            DGV_VENTA.AllowUserToAddRows = false;
            DGV_VENTA.AllowUserToDeleteRows = false;
            DGV_VENTA.AutoGenerateColumns = false;
            DGV_VENTA.AllowUserToResizeRows = false;
            DGV_VENTA.AllowUserToResizeColumns = false;
            DGV_VENTA.AllowUserToOrderColumns = false;
            DGV_VENTA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_VENTA.MultiSelect = false;
            DGV_VENTA.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CntMovimiento";
            c1.HeaderText = "Cnt/Mov";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Deposito";
            c2.HeaderText = "Deposito";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Siglas";
            c5.HeaderText = "Tipo/Mov";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.Width = 80;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Concepto";
            c3.HeaderText = "Concepto";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.MinimumWidth = 120;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CntInventario";
            c4.HeaderText = "Cnt/Und";  
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = _controlador.Decimales;

            DGV_VENTA.Columns.Add(c2);
            DGV_VENTA.Columns.Add(c1);
            DGV_VENTA.Columns.Add(c5);
            DGV_VENTA.Columns.Add(c3);
            DGV_VENTA.Columns.Add(c4);
        }

        private void InicializaGrid_Inventario()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);

            DGV_INV.AllowUserToAddRows = false;
            DGV_INV.AllowUserToDeleteRows = false;
            DGV_INV.AutoGenerateColumns = false;
            DGV_INV.AllowUserToResizeRows = false;
            DGV_INV.AllowUserToResizeColumns = false;
            DGV_INV.AllowUserToOrderColumns = false;
            DGV_INV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_INV.MultiSelect = false;
            DGV_INV.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CntMovimiento";
            c1.HeaderText = "Cnt/Mov";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Deposito";
            c2.HeaderText = "Deposito";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Siglas";
            c5.HeaderText = "Tipo/Mov";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.Width = 80;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Concepto";
            c3.HeaderText = "Concepto";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.MinimumWidth = 120;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CntInventario";
            c4.HeaderText = "Cnt/Und"; 
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = _controlador.Decimales;

            DGV_INV.Columns.Add(c2);
            DGV_INV.Columns.Add(c1);
            DGV_INV.Columns.Add(c5);
            DGV_INV.Columns.Add(c3);
            DGV_INV.Columns.Add(c4);
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
            InicializaGrid();
        }

        private void KardexFrm_Load(object sender, EventArgs e)
        {
            CB_DIAS.SelectedIndex = -1;
            L_PRODUCTO.Text = _controlador.Producto;

            DGV_COMPRA.DataSource = _controlador.Compra;
            DGV_COMPRA.Refresh();

            DGV_VENTA.DataSource = _controlador.Venta;
            DGV_VENTA.Refresh();

            DGV_INV.DataSource = _controlador.Inventario;
            DGV_INV.Refresh();

            ActualizarData();
            L_INVENTARIO_Click(this,System.EventArgs.Empty);
        }

        private void ActualizarData()
        {
            L_EX_ACTUAL.Text = _controlador.ExActual;
            L_EX_FECHA.Text = _controlador.ExFecha;
            L_FECHA.Text = _controlador.Fecha;
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            ActualizarData();
        }

        private void CB_DIAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CB_DIAS.SelectedIndex) 
            {
                case -1:
                    _controlador.setDias( OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.SinDefinir);
                    break;
                case 0:
                    _controlador.setDias( OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.Hoy);
                    break;
                case 1:
                    _controlador.setDias(OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.Ayer);
                    break;
                case 2:
                    _controlador.setDias(OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._7Dias);
                    break;
                case 3:
                    _controlador.setDias(OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._15Dias);
                    break;
                case 4:
                    _controlador.setDias(OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._30Dias);
                    break;
                case 5:
                    _controlador.setDias(OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._45Dias);
                    break;
                case 6:
                    _controlador.setDias(OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._60Dias);
                    break;
                case 7:
                    _controlador.setDias(OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._90Dias);
                    break;
                case 8:
                    _controlador.setDias(OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._120Dias);
                    break;
                case 9:
                    _controlador.setDias(OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.Todo);
                    break;
            }
        }

        private void BT_VER_DETALLE_COMPRA_Click(object sender, EventArgs e)
        {
            VerDetalleCompra();
        }

        private void VerDetalleCompra()
        {
            _controlador.VerDetalleCompra();
        }

        private void BT_VER_DETALLE_VENTA_Click(object sender, EventArgs e)
        {
            VerDetalleVenta();
        }

        private void VerDetalleVenta()
        {
            _controlador.VerDetalleVenta();
        }

        private void BT_VER_DETALLE_INVENTARIO_Click(object sender, EventArgs e)
        {
            VerDetalleInventario();
        }

        private void VerDetalleInventario()
        {
            _controlador.VerDetalleInventario();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void L_VENTAS_Click(object sender, EventArgs e)
        {
            tableLayoutPanel3.RowStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel3.RowStyles[1].Height = 100;
            tableLayoutPanel3.RowStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel3.RowStyles[0].Height = 40;
            tableLayoutPanel3.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel3.RowStyles[2].Height = 40;
        }

        private void L_COMPRAS_Click(object sender, EventArgs e)
        {
            tableLayoutPanel3.RowStyles[0].SizeType = SizeType.Percent;
            tableLayoutPanel3.RowStyles[0].Height = 100;
            tableLayoutPanel3.RowStyles[1].SizeType = SizeType.Absolute;
            tableLayoutPanel3.RowStyles[1].Height= 40 ;
            tableLayoutPanel3.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel3.RowStyles[2].Height = 40;
        }

        private void L_INVENTARIO_Click(object sender, EventArgs e)
        {
            tableLayoutPanel3.RowStyles[2].SizeType = SizeType.Percent;
            tableLayoutPanel3.RowStyles[2].Height = 100;
            tableLayoutPanel3.RowStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel3.RowStyles[0].Height = 40;
            tableLayoutPanel3.RowStyles[1].SizeType = SizeType.Absolute;
            tableLayoutPanel3.RowStyles[1].Height = 40;
        }

    }

}
