using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros
{

    public partial class MaestroFrm : Form
    {

        private Gestion _controlador;


        public MaestroFrm()
        {
            InitializeComponent();
        }

        private void InicializaGrid()
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
            c1.DataPropertyName = "Descripcion";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Codigo";
            c2.HeaderText = "Codigo";
            c2.Visible = true;
            c2.Width = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;


            DGV.Columns.Add(c2);
            DGV.Columns.Add(c1);
        }

        private void InicializaGridMarca()
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
            c1.DataPropertyName = "Descripcion";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns.Add(c1);
        }

        private void InicializarGridEmpaque()
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
            c1.DataPropertyName = "Descripcion";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 120;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Codigo";
            c2.HeaderText = "Decimales";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
        }
        
        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void MaestroFrm_Load(object sender, EventArgs e)
        {
            if (_controlador.IsMarca)
                InicializaGridMarca();
            else if (_controlador.IsEmpaqueMedida)
                InicializarGridEmpaque();
            else
                InicializaGrid();
            DGV.DataSource = _controlador.Source;
            L_MAESTRO.Text = _controlador.Maestro;
            ActualizarItems();
        }

        private void ActualizarItems()
        {
            L_ITEMS.Text = _controlador.TotalItems.ToString("n0");
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TSM_ARCHIVO_Salir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarItem();
        }

        private void AgregarItem()
        {
            _controlador.AgregarItem();
            ActualizarItems();
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarItem();
        }

        private void EditarItem()
        {
            _controlador.EditarItem();
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            _controlador.EliminarItem();
        }

    }

}