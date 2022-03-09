using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.Existencia
{

    public partial class ExistenciaFrm : Form
    {


        private Gestion _controlador;


        public ExistenciaFrm()
        {
            InitializeComponent();
            InicializaGrid();
            InicializaCombo();
        }

        private void InicializaCombo()
        {
            CB_DEPART.DisplayMember = "Nombre";
            CB_DEPART.ValueMember = "Auto";
            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Auto";
        }

        private void InicializaGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);

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
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombrePrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Deposito";
            c3.HeaderText = "Depósito";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 140;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Departamento";
            c4.HeaderText = "Departamento";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 140;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "SCntFisica";
            c5.Name = "SCntFisica";
            c5.HeaderText = "Cnt/Fisica";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //c5.DefaultCellStyle.Format = _controlador.Decimales;

            var c5A = new DataGridViewCheckBoxColumn();
            c5A.DataPropertyName = "EsPesado";
            c5A.HeaderText = "Kg";
            c5A.Visible = true;
            c5A.Width = 25;
            c5A.HeaderCell.Style.Font = f;
            c5A.DefaultCellStyle.Font = f1;
            c5A.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "NivelMinimo";
            c6.HeaderText = "N/Minimo";
            c6.Visible = true;
            c6.Width = 80;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //c6.DefaultCellStyle.Format = _controlador.Decimales;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "NivelOptimo";
            c7.HeaderText = "N/Optimo";
            c7.Visible = true;
            c7.Width = 80;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //c7.DefaultCellStyle.Format = _controlador.Decimales;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Reponer";
            c8.HeaderText = "Reponer";
            c8.Visible = true;
            c8.Width = 80;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //c8.DefaultCellStyle.Format = _controlador.Decimales;

            var c2A = new DataGridViewTextBoxColumn();
            c2A.Name = "Estatus";
            c2A.DataPropertyName = "Estatus";
            c2A.HeaderText = " ";
            c2A.Visible = true;
            c2A.HeaderCell.Style.Font = f;
            c2A.DefaultCellStyle.Font = f1;
            c2A.Width = 10;

            var c2B = new DataGridViewTextBoxColumn();
            c2B.DataPropertyName = "CntFisica";
            c2B.Name = "CntFisica";
            c2B.HeaderText = "";
            c2B.Visible = false;
            c2B.Width = 0;


            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5A);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c2A);
            DGV.Columns.Add(c2B);
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void ExistenciaFrm_Load(object sender, EventArgs e)
        {
            L_FILTRO.Text = "";
            DGV.DataSource = _controlador.Source;
            CB_DEPART.DataSource = _controlador.SourceDepartamento;
            CB_DEPOSITO.DataSource = _controlador.SourceDeposito;
            CB_DEPOSITO.SelectedIndex = -1;
            CB_DEPART.SelectedIndex = -1;
            CB_FILTRO.SelectedIndex = 0;
            CB_DEPOSITO.Focus();
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            L_ITEMS.Text = _controlador.Items;
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.Buscar();
            DGV.Refresh();
            ActualizarTotales();
        }

        private void CB_FILTRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.Filtrar= OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.SinDefinir;
            L_FILTRO.Text = "";
            if (CB_FILTRO.SelectedIndex != -1)
            { 
                switch (CB_FILTRO.SelectedIndex)
                {
                    case 0:
                        _controlador.Filtrar = OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.ExistenciaMayorCero;
                        L_FILTRO.Text="Productos Con Existencia Mayor a Cero (0)";
                        break;
                    case 1:
                        _controlador.Filtrar = OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.ExistenciaIgualCero;
                        L_FILTRO.Text = "Productos Con Existencia Igual a Cero (0)";
                        break;
                    case 2:
                        _controlador.Filtrar = OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.ExistenciaMenorCero;
                        L_FILTRO.Text="Productos Con Existencia Menor a Cero (0)";
                        break;
                    case 3:
                        _controlador.Filtrar = OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.ExistenciaPorDebajoNivelMinimo;
                        L_FILTRO.Text="Productos Por Debajo Del Nivel Mínimo";
                        break;
                }
            }
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.Deposito = "";
            if (CB_DEPOSITO.SelectedIndex != -1) 
            {
                _controlador.Deposito = CB_DEPOSITO.SelectedValue.ToString();
            }
        }

        private void CB_DEPART_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.Departamento = "";
            if (CB_DEPART.SelectedIndex != -1)
            {
                _controlador.Departamento = CB_DEPART.SelectedValue.ToString();
            }
        }

        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            _controlador.Deposito = "";
            CB_DEPOSITO.SelectedIndex = -1;
        }

        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            _controlador.Departamento = "";
            CB_DEPART.SelectedIndex = -1;
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if ((int)row.Cells["estatus"].Value == 1)
                {
                    row.Cells["Estatus"].Style.BackColor = Color.Green;
                    row.Cells["Estatus"].Style.ForeColor = Color.Green;
                }
                else if ((int)row.Cells["estatus"].Value == 2)
                {
                    row.Cells["Estatus"].Style.BackColor = Color.Orange;
                    row.Cells["Estatus"].Style.ForeColor = Color.Orange;
                }
                else
                {
                    row.Cells["Estatus"].Style.BackColor = Color.Red;
                    row.Cells["Estatus"].Style.ForeColor = Color.Red;
                }

                if ((decimal)row.Cells["CntFisica"].Value < 0)
                {
                    row.Cells["SCntFisica"].Style.BackColor = Color.Red;
                    row.Cells["SCntFisica"].Style.ForeColor = Color.White;
                }
            }
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            _controlador.Imprimir();
        }

    }

}