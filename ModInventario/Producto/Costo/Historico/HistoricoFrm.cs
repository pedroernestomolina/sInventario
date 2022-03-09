using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Costo.Historico
{

    public partial class HistoricoFrm : Form
    {

        private Gestion _controlador;


        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 9, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Serie";
            c4.HeaderText = "Serie";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.MinimumWidth = 60;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 90;
       
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "costoNeto";
            c3.HeaderText = "Costo Neto";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "EtqPrecio";
            c5.HeaderText = "Costo+Iva";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "CostoDivisa";
            c6.HeaderText = "Costo Divisa";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Divisa";
            c7.HeaderText = "Divisa";
            c7.Visible = true;
            c7.Width = 100;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format="n2";

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "UsuarioEstacion";
            c2.HeaderText = "Usuario/Estacion";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns.Add(c4);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
           // DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c2);
        }

        public void setControlador(Gestion ctr)
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

        public void ActualizarItem()
        {
            L_NOTA.Text = _controlador.Item.nota;
        }


        public HistoricoFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }


        private void HistoricoFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            L_PRODUCTO.Text = _controlador.Producto;
            L_NOTA.Text = _controlador.Nota;
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            ImprimirHistorico();
        }

        private void ImprimirHistorico()
        {
            _controlador.ImprimirHistorico();
        }

    }

}