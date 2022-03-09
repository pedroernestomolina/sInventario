using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Proveedor
{

    public partial class ProveedoresFrm : Form
    {

        private Gestion _controlador;


        public ProveedoresFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

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
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 100;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Rif";
            c2.HeaderText = "Ci/Rif";
            c2.Visible = true;
            c2.Width = 110;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "RazonSocial";
            c3.HeaderText = "Nombre";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.MinimumWidth = 180;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Telefonos";
            c4.HeaderText = "Telefonos";
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void ProveedoresFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.Producto;
            L_ITEMS.Text = _controlador.Items;
            L_DIRECCION.Text = "";
            L_TELEFONO.Text = "";
            if (_controlador.Item != null) 
            {
                L_DIRECCION.Text = _controlador.Item.Direccion;
                L_TELEFONO.Text = _controlador.Item.Telefono;
            }
            DGV.DataSource = _controlador.Source;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        public void setActualizarItem()
        {
            L_DIRECCION.Text = "";
            L_TELEFONO.Text = "";
            if (_controlador.Item != null)
            {
                L_DIRECCION.Text = _controlador.Item.Direccion;
                L_TELEFONO.Text = _controlador.Item.Telefono;
            }
        }

    }

}