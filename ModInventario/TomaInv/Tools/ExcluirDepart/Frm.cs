using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Tools.ExcluirDepart
{
    public partial class Frm : Form
    {
        private IExcluir _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializarGrid();
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
            c1.DataPropertyName = "Descripcion";
            c1.HeaderText = "Departamento";
            c1.Visible = true;
            c1.MinimumWidth = 220;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c2 = new DataGridViewCheckBoxColumn();
            c2.DataPropertyName = "IsSeleccionado";
            c2.HeaderText = "Excluir";
            c2.Visible = true;
            c2.Width = 60;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.ReadOnly = false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
        }

        private bool _modoInicializa; 
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            DGV.DataSource = _controlador.GetDatatSource;
            _modoInicializa = false;
        }


        public void setControlador(IExcluir ctr)
        {
            _controlador = ctr;
        }


        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }


        private void Aceptar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
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

        private void CHB_MARCAR_TODAS_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMarcarTodas(CHB_MARCAR_TODAS.Checked);
        }
    }
}