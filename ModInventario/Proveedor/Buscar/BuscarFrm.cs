using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Proveedor.Buscar
{

    public partial class BuscarFrm : Form
    {

        private Gestion _controlador;


        public BuscarFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

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
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 120;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombreRazonSocial";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 280;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CiRif";
            c3.HeaderText = "Rif";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.Buscar();
            DGV.Refresh();
            L_ITEMS.Text = _controlador.Items;
        }

        private void TB_CADENA_TextChanged(object sender, EventArgs e)
        {
            _controlador.CadenaBusqueda = TB_CADENA.Text;
        }

        private void BuscarFrm_Load(object sender, EventArgs e)
        {
            TB_CADENA.Text="";
            DGV.DataSource = _controlador.Source;
            DGV.Refresh();
            L_ITEMS.Text = _controlador.Items;
        }

        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.CadenaBusqueda = TB_CADENA.Text.Trim().ToUpper();
            TB_CADENA.Text = _controlador.CadenaBusqueda;
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                SeleccionarItem();
            }
        }

        private void SeleccionarItem()
        {
            _controlador.SeleccionarItem();
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

    }

}