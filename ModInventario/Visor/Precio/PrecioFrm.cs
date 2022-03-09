using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.Precio
{

    public partial class PrecioFrm : Form
    {

        private Gestion _controlador;


        public PrecioFrm()
        {
            InitializeComponent();
            InicializaGrid();
            InicializaCombo();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }


        private void InicializaCombo()
        {
            CB_DEPART.DisplayMember = "desc";
            CB_DEPART.ValueMember = "id";
            CB_GRUPO.DisplayMember = "desc";
            CB_GRUPO.ValueMember = "id";
        }

        private void InicializaGrid()
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
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombrePrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CostoDivisaUnd";
            c3.HeaderText = "Costo $";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format="n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Precio_1";
            c4.Name = "Precio_1";
            c4.HeaderText = "P1 $";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c4a = new DataGridViewTextBoxColumn();
            c4a.DataPropertyName = "Precio_1_error";
            c4a.Name = "Precio_1_error";
            c4a.Visible = false;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Precio_2";
            c5.Name = "Precio_2";
            c5.HeaderText = "P2 $";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c5a = new DataGridViewTextBoxColumn();
            c5a.DataPropertyName = "Precio_2_error";
            c5a.Name = "Precio_2_error";
            c5a.Visible = false;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Precio_3";
            c6.Name = "Precio_3";
            c6.HeaderText = "P3 $";
            c6.Visible = true;
            c6.Width = 80;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            var c6a = new DataGridViewTextBoxColumn();
            c6a.DataPropertyName = "Precio_3_error";
            c6a.Name = "Precio_3_error";
            c6a.Visible = false;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Precio_4";
            c7.Name = "Precio_4";
            c7.HeaderText = "P4 $";
            c7.Visible = true;
            c7.Width = 80;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            var c7a = new DataGridViewTextBoxColumn();
            c7a.DataPropertyName = "Precio_4_error";
            c7a.Name = "Precio_4_error";
            c7a.Visible = false;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Precio_5";
            c8.Name = "Precio_5";
            c8.HeaderText = "P5 $";
            c8.Visible = true;
            c8.Width = 80;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";

            var c8a = new DataGridViewTextBoxColumn();
            c8a.DataPropertyName = "Precio_5_error";
            c8a.Name = "Precio_5_error";
            c8a.Visible = false;

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "Estatus";
            c9.Name = "Estatus";
            c9.HeaderText = "Estatus";
            c9.Visible = true;
            c9.Width = 80;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c9a = new DataGridViewTextBoxColumn();
            c9a.DataPropertyName = "Estatus_Inactivo";
            c9a.Name = "Estatus_Inactivo";
            c9a.Visible = false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c4a);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5a);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c6a);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c7a);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c8a);
            DGV.Columns.Add(c9);
            DGV.Columns.Add(c9a);
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if ((bool)row.Cells["precio_1_error"].Value == true)
                {
                    row.Cells["Precio_1"].Style.BackColor = Color.Red;
                    row.Cells["Precio_1"].Style.ForeColor = Color.White;
                }
                if ((bool)row.Cells["precio_2_error"].Value == true)
                {
                    row.Cells["Precio_2"].Style.BackColor = Color.Red;
                    row.Cells["Precio_2"].Style.ForeColor = Color.White;
                }
                if ((bool)row.Cells["precio_3_error"].Value == true)
                {
                    row.Cells["Precio_3"].Style.BackColor = Color.Red;
                    row.Cells["Precio_3"].Style.ForeColor = Color.White;
                }
                if ((bool)row.Cells["precio_4_error"].Value == true)
                {
                    row.Cells["Precio_4"].Style.BackColor = Color.Red;
                    row.Cells["Precio_4"].Style.ForeColor = Color.White;
                }
                if ((bool)row.Cells["precio_5_error"].Value == true)
                {
                    row.Cells["Precio_5"].Style.BackColor = Color.Red;
                    row.Cells["Precio_5"].Style.ForeColor = Color.White;
                }
                if ((bool)row.Cells["Estatus_Inactivo"].Value == true)
                {
                    row.Cells["Estatus"].Style.BackColor = Color.Red;
                    row.Cells["Estatus"].Style.ForeColor = Color.White;
                }
            }
        }

        private void PrecioFrm_Load(object sender, EventArgs e)
        {
            L_ITEMS.Text = _controlador.ItemsEncontrados;
            DGV.DataSource = _controlador.SourceVista;
            CB_DEPART.DataSource = _controlador.SourceDepartamento;
            CB_GRUPO.DataSource = _controlador.SourceGrupo;
            CB_DEPART.SelectedIndex = -1;
            CB_GRUPO.SelectedIndex = -1;
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }


        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.Buscar();
            L_ITEMS.Text = _controlador.ItemsEncontrados;
        }

        private void CB_DEPART_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setDepartamento("");
            if (CB_DEPART.SelectedIndex != -1)
            {
                _controlador.setDepartamento(CB_DEPART.SelectedValue.ToString());
            }
            CB_GRUPO.SelectedIndex = -1;
        }

        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            CB_DEPART.SelectedIndex = -1;
            CB_GRUPO.SelectedIndex = -1;
            _controlador.setDepartamento("");
            _controlador.setGrupo("");
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }

        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            CB_GRUPO.SelectedIndex = -1;
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            CB_DEPART.SelectedIndex = -1;
            CB_GRUPO.SelectedIndex = -1;
            _controlador.LimpiarFiltros();
        }

    }

}