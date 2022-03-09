using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Analisis.Detallado
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

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CntUnd";
            c2.HeaderText = "CntUnd/Ven";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Fecha";
            c5.HeaderText = "Fecha";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "dddd dd/MM/yyyy";
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CntDoc";
            c3.HeaderText = "Cant/Doc";
            c3.Visible = true;
            c3.Width = 70;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            DGV.Columns.Add(c5);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void AnalisisFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.SourceData;
            L_FILTRO.Text = _controlador.Filtros;
            L_PRODUCTO.Text = _controlador.Producto;
            L_VENTA_TOTAL.Text = _controlador.VentasTotales;
            L_VENTA_PROMEDIO.Text = _controlador.VentasPromedio;
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