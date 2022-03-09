using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.Traslado
{

    public partial class TrasladoFrm : Form
    {

        
        private Gestion _controlador;

        
        public TrasladoFrm()
        {
            InitializeComponent();
            InicializaGrid();
            InicializaCombo();
        }

        private void InicializaCombo()
        {
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
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c1A = new DataGridViewTextBoxColumn();
            c1A.DataPropertyName = "Usuario";
            c1A.HeaderText = "Usuario";
            c1A.Visible = true;
            c1A.HeaderCell.Style.Font = f;
            c1A.DefaultCellStyle.Font = f1;
            c1A.Width = 100;

            var c1B = new DataGridViewTextBoxColumn();
            c1B.DataPropertyName = "DocumentoNro";
            c1B.HeaderText = "Documento";
            c1B.Visible = true;
            c1B.HeaderCell.Style.Font = f;
            c1B.DefaultCellStyle.Font = f1;
            c1B.Width = 100;
            
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombrePrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 140;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DepositoOrigen";
            c3.HeaderText = "Origen";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 120;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "DepositoDestino";
            c4.HeaderText = "Destino";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 120;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Cnt";
            c5.HeaderText = "Cant/Und";
            c5.Visible = true;
            c5.Width = 90;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //c5.DefaultCellStyle.Format = _controlador.Decimales;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c1A);
            DGV.Columns.Add(c1B);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void ExistenciaFrm_Load(object sender, EventArgs e)
        {
            L_FILTRO.Text = "TRASLADOS ENTRE DEPOSITOS";
            DGV.DataSource = _controlador.Source;
            CB_MES.SelectedIndex = DateTime.Now.Month-1;
            CB_ANO.SelectedItem = DateTime.Now.Year.ToString(); ;
            CB_MES.Focus();
            ActualizarTotales();
            L_FILTRO.Text = "Movimientos Traslados Entre Depósitos";
            L_NOTA_MOV.Text = _controlador.NotaMovimiento;
        }

        private void ActualizarTotales()
        {
            L_ITEMS.Text = _controlador.Items;
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.Buscar();
            DGV.Refresh();
            ActualizarTotales();
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void CB_MES_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.MesFiltrar = 0;
            if (CB_MES.SelectedIndex != -1) 
            {
                _controlador.MesFiltrar = CB_MES.SelectedIndex + 1; 
            }
        }

        private void L_MES_FILTRAR_Click(object sender, EventArgs e)
        {
            CB_MES.SelectedIndex = -1;
        }

        private void CB_ANO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AnoFiltrar = 0;
            if (CB_ANO.SelectedIndex != -1)
            {
                _controlador.AnoFiltrar = 2015+CB_ANO.SelectedIndex ;
            }
        }

        public void SetActualizarNota()
        {
            L_NOTA_MOV.Text = _controlador.NotaMovimiento;
        }

    }

}