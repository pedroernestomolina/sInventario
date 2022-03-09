using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Tool.AjusteNivelMinimoMaximoProducto
{

    public partial class AjusteNivelFrm : Form
    {

        private Gestion _controlador;


        public AjusteNivelFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void Inicializar()
        {
            InicializarGrid();

            BT_BUSCAR.Enabled = _controlador.IsBuscarHabilitado;
            CB_DEPOSITO.Enabled = _controlador.IsBuscarHabilitado;

            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Auto";
            CB_DEPOSITO.DataSource = _controlador._bsDeposito;

            CB_DEPARTAMENTO.DisplayMember = "Nombre";
            CB_DEPARTAMENTO.ValueMember = "Auto";
            CB_DEPARTAMENTO.DataSource = _controlador._bsDepartamento;

            Limpiar2();
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
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombrePrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 160;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "ExFisica";
            c3.HeaderText = "Exist";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Minimo";
            c4.HeaderText = "N/Mínimo";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Maximo";
            c5.HeaderText = "N/Máximo";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c6 = new DataGridViewCheckBoxColumn();
            c6.DataPropertyName = "EsPesado";
            c6.HeaderText = "Kg";
            c6.Name = "EsPesado";
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 30;

            var c7 = new DataGridViewCheckBoxColumn();
            c7.DataPropertyName = "IsEditado";
            c7.HeaderText = "Editado";
            c7.Visible = true;
            c7.Width = 60;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Estatus";
            c8.Name = "Estatus";
            c8.HeaderText = "*";
            c8.Visible = true;
            c8.Width = 80;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
        }

        private void AjusteNivelFrm_Load(object sender, EventArgs e)
        {
            Inicializar();
            DGV.DataSource = _controlador.Lista;
            DGV.Refresh();
            L_ITEMS.Text = _controlador.Items;
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.Buscar();
            L_DEPOSITO.Text = _controlador.Deposito;
            L_ITEMS.Text = _controlador.Items;
            CB_DEPOSITO.Enabled = _controlador.IsBuscarHabilitado;
            TB_CADENA.Text = "";
            DGV.Focus();

            //CB_DEPARTAMENTO.Enabled = _controlador.IsBuscarHabilitado;
            //TB_CADENA.Enabled = _controlador.IsBuscarHabilitado;
            //BT_BUSCAR.Enabled = _controlador.IsBuscarHabilitado;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoDeposito = "";
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.AutoDeposito = CB_DEPOSITO.SelectedValue.ToString();
            }
        }

        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoDepartamento = "";
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.AutoDepartamento = CB_DEPARTAMENTO.SelectedValue.ToString();
            }
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            _controlador.Limpiar();
            if (_controlador.IsLimpiarOk) 
            {
                Limpiar2();
            }
            L_ITEMS.Text = _controlador.Items;
        }

        private void Limpiar2()
        {
            CB_DEPOSITO.SelectedIndex = -1;
            CB_DEPARTAMENTO.SelectedIndex = -1;
            L_DEPOSITO.Text = _controlador.Deposito;
            BT_BUSCAR.Enabled = _controlador.IsBuscarHabilitado;
            CB_DEPOSITO.Enabled = _controlador.IsBuscarHabilitado;
            CB_DEPARTAMENTO.Enabled = _controlador.IsBuscarHabilitado;
            TB_CADENA.Enabled = _controlador.IsBuscarHabilitado;
            TB_CADENA.Text = "";
            DGV.Refresh();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                AjustarMinimoMaximo();
            }
        }

        private void AjustarMinimoMaximo()
        {
            _controlador.AjustarMinimoMaximo();
            DGV.Refresh();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesoIsOk)
            {
                //Salir();
                _controlador.Inicializar();
                L_ITEMS.Text = _controlador.Items;
                Limpiar2();
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            _controlador.Salir();
            if (_controlador.SalirIsOk) 
            {
                this.Close();
            }
        }

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name.Equals("EsPesado"))
            {
                DataGridViewCell cell = this.DGV.Rows[e.RowIndex].Cells[3];
                if ((bool)e.Value)
                {
                    cell.Style.Format = "n3";
                }
                else
                {
                    cell.Style.Format = "n0";
                }

                cell = this.DGV.Rows[e.RowIndex].Cells[4];
                if ((bool)e.Value)
                {
                    cell.Style.Format = "n3";
                }
                else
                {
                    cell.Style.Format = "n0";
                }

                cell = this.DGV.Rows[e.RowIndex].Cells[5];
                if ((bool)e.Value)
                {
                    cell.Style.Format = "n3";
                }
                else
                {
                    cell.Style.Format = "n0";
                }
            }

            if (DGV.Columns[e.ColumnIndex].Name.Equals("Estatus"))
            {
                DataGridViewCell cell = this.DGV.Rows[e.RowIndex].Cells["Estatus"];
                if ((string)e.Value.ToString().Trim().ToUpper()=="SUSPENDIDO")
                {
                    cell.Style.BackColor = Color.Orange;
                    cell.Style.ForeColor = Color.Black;
                }
                else
                {
                    cell.Style.BackColor = Color.Green;
                    cell.Style.ForeColor = Color.White;
                }
            }
        }

        private void AjusteNivelFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_controlador.SalirIsOk) 
            {
                _controlador.Salir();
                e.Cancel = !_controlador.SalirIsOk;
            }
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.setCadenaBuscar(TB_CADENA.Text);
        }

        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            LimpiarDepartamento();
        }

        private void LimpiarDepartamento()
        {
            CB_DEPARTAMENTO.SelectedIndex = -1;
        }

    }

}