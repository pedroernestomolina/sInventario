using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis
{
    public partial class Frm : Form
    {
        private IAnalisis _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializaGrid();
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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 100;
            c1.ReadOnly = true;


            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DescPrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 280;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Diferencia";
            c3.HeaderText = "Diferencia (UND)";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 80;
            c3.ReadOnly = true;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n1";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Estado";
            c4.HeaderText = "Estado";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 100;
            c4.ReadOnly = true;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c5 = new DataGridViewCheckBoxColumn();
            c5.DataPropertyName = "Eliminar";
            c5.HeaderText = "*";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.Width = 40;
            c5.ReadOnly = false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.GetSource;
            DGV.Refresh();
            L_ITEMS.Text = "Items Encontrados: " + _controlador.CntItem.ToString("n0");
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }

        public void setControlador(IAnalisis ctr)
        {
            _controlador = ctr;
        }


        private void BT_REFRESCAR_Click(object sender, EventArgs e)
        {
            RefrescarVista();
        }
        private void BT_TOMA_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarTomas();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            ProcesarToma();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void CHB_MARCAR_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMarcarTodas(CHB_MARCAR.Checked);
        }



        private void RefrescarVista()
        {
            _controlador.RefrescarVista();
        }
        private void EliminarTomas()
        {
            _controlador.EliminarTomas();
        }
        private void ProcesarToma()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
        }
        private void AbandonarFicha()
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
    }
}