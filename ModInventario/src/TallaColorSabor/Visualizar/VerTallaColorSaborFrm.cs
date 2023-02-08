using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.TallaColorSabor.Visualizar
{
    public partial class VerTallaColorSaborFrm : Form
    {
        private IVer _controlador;


        public VerTallaColorSaborFrm()
        {
            InitializeComponent();
            InicializaDGV();
            InicializaDGV_B();
        }

        private void InicializaDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 7, FontStyle.Regular);

            DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
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
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Fisica";
            c2.HeaderText = "Cant";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c2.DefaultCellStyle.Format = "n1";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
        }

        private void InicializaDGV_B()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 7, FontStyle.Regular);

            DGV_B.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGV_B.AllowUserToAddRows = false;
            DGV_B.AllowUserToDeleteRows = false;
            DGV_B.AutoGenerateColumns = false;
            DGV_B.AllowUserToResizeRows = false;
            DGV_B.AllowUserToResizeColumns = false;
            DGV_B.AllowUserToOrderColumns = false;
            DGV_B.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_B.MultiSelect = false;
            DGV_B.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Descripcion";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Fisica";
            c2.HeaderText = "Cant";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c2.DefaultCellStyle.Format = "n1";

            DGV_B.Columns.Add(c1);
            DGV_B.Columns.Add(c2);
        }

        public void setControlador(IVer ctr)
        {
            _controlador = ctr;
        }

        private bool _modoIni;
        private void VerTallaColorSaborFrm_Load(object sender, EventArgs e)
        {
            _modoIni = true;
            p3_A.Visible = true;
            p3_A.Dock = DockStyle.Fill;
            p3_B.Visible = false;
            p3_B.Dock = DockStyle.Fill;
            DGV.DataSource = _controlador.GetData_Source;
            DGV_B.DataSource = _controlador.GetDataDep_Source;
            ETQ_PRD.Text = _controlador.GetEtq_Prd;
            ETQ_CNT_GENERAL.Text= "Total: "+_controlador.GetEtq_CntGeneral.ToString("n1");
            ETQ_CNT_DETALLE.Text = "Total: " + _controlador.GetEtq_CntDetalle.ToString("n1");
            L_PRD_TCS.Text = _controlador.GetEtq_PrdTCS;
            _modoIni = false;
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_controlador.CargarDepositos()) 
            {
                L_PRD_TCS.Text = _controlador.GetEtq_PrdTCS;
                ETQ_CNT_DETALLE.Text = "Total: " + _controlador.GetEtq_CntDetalle.ToString("n1");
                p3_A.Visible = false;
                p3_A.Dock = DockStyle.Fill;
                p3_B.Visible = true;
                p3_B.Dock = DockStyle.Fill;
            }
        }

        private void BT_RETORNAR_Click(object sender, EventArgs e)
        {
            ETQ_PRD.Text = _controlador.GetEtq_Prd;
            p3_A.Visible = true;
            p3_A.Dock = DockStyle.Fill;
            p3_B.Visible = false;
            p3_B.Dock = DockStyle.Fill;
        }
    }
}