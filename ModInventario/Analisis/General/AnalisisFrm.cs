using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Analisis.General
{

    public partial class AnalisisFrm : Form
    {


        private Gestion _controlador;


        public AnalisisFrm()
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
            c1.DataPropertyName = "nombrePrd";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CntUnd";
            c2.HeaderText = "CntUnd/Ven";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CntUndxDia";
            c5.HeaderText = "CntUnd/Dia";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CntDoc";
            c3.HeaderText = "Cant/Doc";
            c3.Visible = true;
            c3.Width = 70;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "codigoPrd";
            c4.HeaderText = "Código";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 120;

            DGV.Columns.Add(c2);
            DGV.Columns.Add(c5);
            //DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c1);
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void AnalisisFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.SourceData;
            L_FILTRO.Text = _controlador.Filtros;
        }

        private void BT_EXISTENCIA_Click(object sender, EventArgs e)
        {
            VerExistencia();
        }

        private void VerExistencia()
        {
            _controlador.VerExistencia();
        }

        private void BT_COMP_DIARIO_Click(object sender, EventArgs e)
        {
            VerComportamientoDiario();
        }

        private void VerComportamientoDiario()
        {
            _controlador.VerComportamientoDiario();
        }

        private void BT_INSERTAR_Click(object sender, EventArgs e)
        {
            SeleccionarItem();
        }

        private void SeleccionarItem()
        {
            _controlador.SeleccionarItem();
        }

        private void BT_LISTA_EXISTENCIA_Click(object sender, EventArgs e)
        {
            ListaExistencia();
        }

        private void ListaExistencia()
        {
            _controlador.ListaExistencia();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

    }

}