using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.DepositoPreDeterminado
{

    public partial class DepPreDeterminadoFrm : Form
    {

        private Gestion _controlador;


        public DepPreDeterminadoFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "DepCodigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 100;
            c1.ReadOnly = true;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DepNombre";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 130;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;

            var c4 = new DataGridViewCheckBoxColumn();
            c4.Name = "IsPreDet";
            c4.DataPropertyName = "IsPreDet";
            c4.HeaderText = "Pre Determinado";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c4.ReadOnly = false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c4);
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }

        private void Abandonar()
        {
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }

        private void DepPreDeterminadoFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.SourceGrid;
        }

        private void DepPreDeterminadoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOk || _controlador.AbandonarIsOk) 
            {
                e.Cancel = false;
            }
        }

    }

}