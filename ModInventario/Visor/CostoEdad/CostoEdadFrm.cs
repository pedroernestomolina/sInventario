using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.CostoEdad
{

    public partial class CostoEdadFrm : Form
    {

        private Gestion _controlador;


        public CostoEdadFrm()
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
            c2.MinimumWidth = 220;
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
            c5.DataPropertyName = "CntFisica";
            c5.Name = "CntFisica";
            c5.HeaderText = "Cnt/Fisica";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5A = new DataGridViewCheckBoxColumn();
            c5A.DataPropertyName = "EsPesado";
            c5A.HeaderText = "Kg";
            c5A.Visible = true;
            c5A.Width = 25;
            c5A.HeaderCell.Style.Font = f;
            c5A.DefaultCellStyle.Font = f1;
            c5A.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "CostoUnd";
            c9.HeaderText = "Costo";
            c9.Visible = true;
            c9.Width = 90;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c9A = new DataGridViewTextBoxColumn();
            c9A.DataPropertyName = "CostoDivisaUnd";
            c9A.HeaderText = "C/Divisa";
            c9A.Visible = true;
            c9A.Width = 70;
            c9A.HeaderCell.Style.Font = f;
            c9A.DefaultCellStyle.Font = f1;
            c9A.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c9B = new DataGridViewCheckBoxColumn();
            c9B.DataPropertyName = "EsAdmDivisa";
            c9B.HeaderText = "$";
            c9B.Visible = true;
            c9B.Width = 20;
            c9B.HeaderCell.Style.Font = f;
            c9B.DefaultCellStyle.Font = f1;
            c9B.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "FechaUltCosto";
            c6.HeaderText = "F/UltCosto";
            c6.Visible = true;
            c6.Width = 80;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //c6.DefaultCellStyle.Format = _controlador.Decimales;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "FechaUltVenta";
            c7.HeaderText = "F/UltVenta";
            c7.Visible = true;
            c7.Width = 80;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //c7.DefaultCellStyle.Format = _controlador.Decimales;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "CostoEdad";
            c8.HeaderText = "Edad";
            c8.Visible = true;
            c8.Width = 60;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //c8.DefaultCellStyle.Format = _controlador.Decimales;

            var c5D = new DataGridViewTextBoxColumn();
            c5D.DataPropertyName = "ExFisica";
            c5D.Name = "Cnt";
            c5D.HeaderText = "";
            c5D.Visible = false;
            c5D.Width = 0;

            var c2A = new DataGridViewTextBoxColumn();
            c2A.Name = "Estatus";
            c2A.DataPropertyName = "Estatus";
            c2A.HeaderText = " ";
            c2A.Visible = true;
            c2A.HeaderCell.Style.Font = f;
            c2A.DefaultCellStyle.Font = f1;
            c2A.Width = 10;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5A);
            DGV.Columns.Add(c9);
            DGV.Columns.Add(c9A);
            DGV.Columns.Add(c9B);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c5D);
            DGV.Columns.Add(c2A);
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

        private bool _modoInicio;
        private void ExistenciaFrm_Load(object sender, EventArgs e)
        {
            L_FILTRO.Text = "VISOR COSTO EDAD PRODUCTOS";
            DGV.DataSource = _controlador.Source;

            _modoInicio = true;
            CB_DEPART.DataSource = _controlador.SourceDepartamento;
            CB_DEPART.SelectedIndex = -1;
            CB_DEPOSITO.DataSource = _controlador.SourceDeposito;
            CB_DEPOSITO.SelectedIndex = -1;
            _modoInicio = false;

            ActualizarTotales();
            TB_CADENA.Focus();
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
            TB_CADENA.Text = "";
            TB_CADENA.Focus();
        }

        private void CB_DEPART_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio)
                return;

            _controlador.setDepartamento("");
            if (CB_DEPART.SelectedIndex != -1)
            {
                _controlador.setDepartamento(CB_DEPART.SelectedValue.ToString());
            }
        }

        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            CB_DEPART.SelectedIndex = -1;
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void DGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex==2)
                _controlador.OrdenaPorDeposito();
            if (e.ColumnIndex == 1)
                _controlador.OrdenaPorNombre();
            if (e.ColumnIndex == 3)
                _controlador.OrdenaPorDepartamento();
            if (e.ColumnIndex == 4)
                _controlador.OrdenaPorExistencia();
            if (e.ColumnIndex == 11)
                _controlador.OrdenaPorCostoEdad();
            DGV.Refresh();
        }

        private void CB_FILTRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.EdadFiltrar = 0;
            switch(CB_FILTRO.SelectedIndex)
            {
                case 0:
                    _controlador.EdadFiltrar = 7;
                    break;
                case 1:
                    _controlador.EdadFiltrar = 15;
                    break;
                case 2:
                    _controlador.EdadFiltrar = 30;
                    break;
                case 3:
                    _controlador.EdadFiltrar = 45;
                    break;
                case 4:
                    _controlador.EdadFiltrar = 60;
                    break;
            }
        }

        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.CadenaBuscar = TB_CADENA.Text.Trim().ToUpper();
        }

        private void L_FILTRAR_Click(object sender, EventArgs e)
        {
            CB_FILTRO.SelectedIndex = -1;
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

                if ((decimal)row.Cells["Cnt"].Value < 0)
                {
                    row.Cells["CntFisica"].Style.BackColor = Color.Red;
                    row.Cells["CntFisica"].Style.ForeColor = Color.White;
                }
            }
        }

        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            CB_DEPOSITO.SelectedIndex = -1;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio)
                return;

            _controlador.setDeposito("");
            if (CB_DEPOSITO.SelectedIndex!=-1)
            {
                _controlador.setDeposito(CB_DEPOSITO.SelectedValue.ToString());
            }
        }

    }

}