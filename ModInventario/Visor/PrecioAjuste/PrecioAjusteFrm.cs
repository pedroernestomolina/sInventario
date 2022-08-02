using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.PrecioAjuste
{

    public partial class PrecioAjusteFrm : Form
    {

        private IAjuste _controlador;


        public PrecioAjusteFrm()
        {
            InitializeComponent();
            InicializaGrid();
            InicializaCombos();
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
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Nombre";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "cont_emp_1";
            c3.HeaderText = "Cont/Emp(1)";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n0";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "pneto_divisa_emp_1";
            c4.HeaderText = "P/Neto($)";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "cont_emp_2";
            c5.HeaderText = "Cont/Emp(2)";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n0";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "pneto_divisa_emp_2";
            c6.HeaderText = "P/Neto($)"; 
            c6.Visible = true;
            c6.Width = 80;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "cont_emp_3";
            c7.HeaderText = "Cont/Emp(3)";
            c7.Visible = true;
            c7.Width = 80;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n0";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "pneto_divisa_emp_3";
            c8.HeaderText = "P/Neto($)"; 
            c8.Visible = true;
            c8.Width = 80;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
        }


        private void InicializaCombos()
        {
            CB_EMPRESA_GRUPO.DisplayMember = "desc";
            CB_EMPRESA_GRUPO.ValueMember= "id";
            CB_DEPARTAMENTO.DisplayMember = "desc";
            CB_DEPARTAMENTO.ValueMember = "id";
            CB_GRUPO.DisplayMember = "desc";
            CB_GRUPO.ValueMember = "id";
            CB_EMPAQUE.DisplayMember = "desc";
            CB_EMPAQUE.ValueMember = "id";
        }

        public void setControlador(IAjuste ctr)
        {
            _controlador = ctr;
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
            ActivarBusqueda();
        }
        private void ActivarBusqueda()
        {
            _controlador.Buscar();
            DGV.Columns[2].Visible = true;
            DGV.Columns[3].Visible = true;
            DGV.Columns[4].Visible = true;
            DGV.Columns[5].Visible = true;
            DGV.Columns[6].Visible = true;
            DGV.Columns[7].Visible = true;
            L_CNT_ITEMS.Text = "Productos Encontrados: " + _controlador.CntItems.ToString();
        }

        private bool _modoInicializar;
        private void PrecioAjusteFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            DGV.DataSource = _controlador.GetDataSource;
            CB_EMPRESA_GRUPO.DataSource = _controlador.GetEmpresaGrupoSource;
            CB_DEPARTAMENTO.DataSource = _controlador.GetDepartamentoSource;
            CB_GRUPO.DataSource = _controlador.GetGrupoSource;
            CB_EMPAQUE.DataSource = _controlador.GetEmpaqueVerSource;
            CB_EMPRESA_GRUPO.SelectedValue = _controlador.GetEmpresaGrupoId;
            CB_DEPARTAMENTO.SelectedValue= _controlador.GetDepartamentoId;
            CB_GRUPO.SelectedValue = _controlador.GetGrupoId;
            CB_EMPAQUE.SelectedValue = _controlador.GetEmpaqueId;
            L_CNT_ITEMS.Text = "Productos Encontrados: "+_controlador.CntItems.ToString();
            _modoInicializar = false;
        }

        private void CB_EMPRESA_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setEmpresaGrupo("");
            if (CB_EMPRESA_GRUPO.SelectedIndex != -1) 
            {
                _controlador.setEmpresaGrupo(CB_EMPRESA_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setDepartamento("");
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.setDepartamento(CB_DEPARTAMENTO.SelectedValue.ToString());
                LimpiarGrupo();
            }
        }
        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_EMPAQUE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DGV.Focus();
            if (_modoInicializar) { return; }
            _controlador.setEmpaque("");
            if (CB_EMPAQUE.SelectedIndex != -1)
            {
                var _cod = CB_EMPAQUE.SelectedValue.ToString();
                _controlador.setEmpaque(CB_EMPAQUE.SelectedValue.ToString());
                LimpiarEmpaque();
                switch (_cod)
                {
                    case "01":
                        DGV.Columns[2].Visible = true;
                        DGV.Columns[3].Visible = true;
                        DGV.Columns[4].Visible = false;
                        DGV.Columns[5].Visible = false;
                        DGV.Columns[6].Visible = false;
                        DGV.Columns[7].Visible = false;
                        break;
                    case "02":
                        DGV.Columns[2].Visible = false;
                        DGV.Columns[3].Visible = false;
                        DGV.Columns[4].Visible = true;
                        DGV.Columns[5].Visible = true;
                        DGV.Columns[6].Visible = false;
                        DGV.Columns[7].Visible = false;
                        break;
                    case "03":
                        DGV.Columns[2].Visible = false;
                        DGV.Columns[3].Visible = false;
                        DGV.Columns[4].Visible = false;
                        DGV.Columns[5].Visible = false;
                        DGV.Columns[6].Visible = true;
                        DGV.Columns[7].Visible = true;
                        break;
                }
                DGV.Refresh();
            }
            L_CNT_ITEMS.Text = "Productos Encontrados: " + _controlador.CntItems.ToString();
        }

        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            LimpiarDepartamento();
        }
        private void LimpiarDepartamento()
        {
            CB_DEPARTAMENTO.SelectedIndex = -1;
            LimpiarGrupo();
        }
        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            LimpiarGrupo();
        }
        private void LimpiarGrupo()
        {
            CB_GRUPO.SelectedIndex = -1;
        }
        private void L_EMPAQUE_VER_Click(object sender, EventArgs e)
        {
            LimpiarEmpaque();
        }
        private void LimpiarEmpaque()
        {
            CB_EMPAQUE.SelectedIndex = -1;
        }

        private void BT_PRECIO_EDITAR_Click(object sender, EventArgs e)
        {
            EditarPrecio();
        }
        private void EditarPrecio()
        {
            _controlador.EditarPrecio();
        }

        private void BT_SUCURSALES_Click(object sender, EventArgs e)
        {
            ListaSucursal();
        }
        private void ListaSucursal()
        {
            _controlador.ListaSucursal();
        }

    }

}