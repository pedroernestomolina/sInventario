using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Historico.ModoSucursal
{
    
    public partial class HistoricoPrecioFrm : Form
    {

        private ISucursal _controlador;


        public HistoricoPrecioFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 9, FontStyle.Regular);

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
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 90;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "UsuarioEstacion";
            c2.HeaderText = "Usuario/Estacion";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "idPrecio";
            c3.HeaderText = "ID/Precio";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c3b = new DataGridViewTextBoxColumn();
            c3b.DataPropertyName = "EmpContenido";
            c3b.HeaderText = "Empq/Cont";
            c3b.Visible = true;
            c3b.Width = 120;
            c3b.HeaderCell.Style.Font = f;
            c3b.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "PrecioLocalNeto";
            c4.HeaderText = "Precio/Neto";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f2;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "PrecioDivisaNeto";
            c5.HeaderText = "Precio/$";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f2;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "FactorCambio";
            c6.HeaderText = "Factor";
            c6.Visible = true;
            c6.Width = 60;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f2;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c3b);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            this.Close();
        }

        private void HistoricoPrecioFrm_Load(object sender, EventArgs e)
        {
            var ds = _controlador.GetDataSource;
            ds.CurrentChanged+=ds_CurrentChanged;
            DGV.DataSource = ds;
            L_PRODUCTO.Text = _controlador.GetProducto_Desc;
            L_NOTA.Text = _controlador.GetNota;
        }

        private void ds_CurrentChanged(object sender, EventArgs e)
        {
            L_NOTA.Text = _controlador.GetNota;
        }

        public void ActualizarItem()
        {
            L_NOTA.Text = _controlador.GetNota;
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
        private void Imprimir()
        {
            _controlador.Imprimir();
        }


        public void setControlador(ISucursal ctr)
        {
            _controlador = ctr;
        }

    }

}