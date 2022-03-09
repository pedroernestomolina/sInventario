using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Kardex.Detalle
{

    public partial class DetalleFrm : Form
    {


        private Gestion _controlador;


        public DetalleFrm()
        {
            InitializeComponent();
            InicializaGrid();
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
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "";
            c2.HeaderText = "Usuario";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Siglas";
            c3.HeaderText = "Siglas";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 80;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Documento";
            c4.HeaderText = "Documento";
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Entidad";
            c5.HeaderText = "Entidad";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.MinimumWidth = 120;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "SCntInventario";
            c6.HeaderText = "Cant/Und";
            c6.Visible = true;
            c6.Width = 120;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //c6.DefaultCellStyle.Format = _controlador.Decimales;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "PrecioCosto";
            c7.HeaderText = "Precio/Costo";
            c7.Visible = true;
            c7.Width = 120;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Estatus";
            c8.Name = "Estatus";
            c8.HeaderText = "Estatus";
            c8.Visible = true;
            c8.Width = 60;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //DGV.Columns.Add(c2);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void DetalleFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            L_PRODUCTO.Text = _controlador.Producto;
            L_DEPOSITO.Text = _controlador.Deposito;
            L_CONCEPTO.Text = _controlador.Concepto;
            L_NOTA.Text = _controlador.NotaMovimiento;
        }

        public void setNota(string p)
        {
            L_NOTA.Text = p;
        }

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name.Equals("Estatus"))
            {
                DataGridViewCell cell = this.DGV.Rows[e.RowIndex].Cells["Estatus"];
                if ((string)e.Value.ToString().Trim().ToUpper() == "ANULADO")
                {
                    cell.Style.BackColor = Color.Red;
                    cell.Style.ForeColor = Color.White;
                }
                else
                {
                    cell.Style.BackColor = Color.Green;
                    cell.Style.ForeColor = Color.White;
                }
            }

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
