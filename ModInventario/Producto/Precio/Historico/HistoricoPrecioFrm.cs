using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Historico
{
    
    public partial class HistoricoPrecioFrm : Form
    {

        private Gestion _controlador;


        public HistoricoPrecioFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 90;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "UsuarioEstacion";
            c2.HeaderText = "Usuario/Estacion";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "EtqPrecio";
            c3.HeaderText = "Id/Precio";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "PrecioNeto";
            c4.HeaderText = "Precio/Neto";
            c4.Visible = true;
            c4.Width = 110;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f2;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
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

        private void HistoricoPrecioFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            L_PRODUCTO.Text = _controlador.Producto;
            L_NOTA.Text = _controlador.Nota;
        }

        public void ActualizarItem()
        {
            L_NOTA.Text = _controlador.Item.nota;
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