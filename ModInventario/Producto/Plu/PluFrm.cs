using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Plu
{

    public partial class PluFrm : Form
    {


        IPlu _controlador;


        public PluFrm()
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
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 80;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Producto";
            c2.HeaderText = "Descripcion";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Plu";
            c3.HeaderText = "Plu";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
        }


        public void setControlador(IPlu ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk) 
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }

        private void PluFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.GetSource;
            DGV.Refresh();
            L_ITEMS.Text = "Items Encontrados: "+_controlador.GetCntItems.ToString();
        }
        private void PluFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk) 
            {
                e.Cancel = false;
            }
        }

    }

}