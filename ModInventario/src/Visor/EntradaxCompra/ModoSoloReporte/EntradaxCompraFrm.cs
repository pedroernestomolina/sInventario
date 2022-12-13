using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Visor.EntradaxCompra.ModoSoloReporte
{

    public partial class EntradaxCompraFrm : Form
    {

        private ISoloReporte _controlador;


        public EntradaxCompraFrm()
        {
            InitializeComponent();
            InicializaGrid();
            InicializaCombo();
        }
       
        private void InicializaCombo()
        {
            CB_ANO.DisplayMember="desc";
            CB_ANO.ValueMember = "id";
            CB_MES.DisplayMember = "desc";
            CB_MES.ValueMember = "id";
        }

        private void InicializaGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);
            var f2 = new Font("Serif", 7, FontStyle.Bold);
            var f3 = new Font("Serif", 10, FontStyle.Regular);

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
            c1.Width = 125;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Documento";
            c2.HeaderText = "Documento";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f2;
            c2.Width = 110;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Siglas";
            c4.HeaderText = "Siglas";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f2;
            c4.Width = 60;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Entidad";
            c3.HeaderText = "Proveedor";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f2;
            c3.Width = 240;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "codPrd";
            c5.HeaderText = "Codigo";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f2;
            c5.Width = 120;
            
            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "descPrd";
            c6.HeaderText = "Descripcion";
            c6.Visible = true;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f2;
            c6.MinimumWidth = 200;
            c6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Cnt";
            c7.HeaderText = "Cant/Und";
            c7.Visible = true;
            c7.Width = 90;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f3;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n1";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
        }


        public void setControlador(ISoloReporte ctr)
        {
            _controlador = ctr;
        }


        private bool _modoInicializa;
        private void EntradaxCompraFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            var _bs = _controlador.GetSource;
            _bs.CurrentChanged += _bs_CurrentChanged;
            DGV.DataSource = _bs;
            CB_MES.DataSource = _controlador.GetMes_Source;
            CB_ANO.DataSource = _controlador.GetAno_Source;
            CB_MES.SelectedValue = _controlador.GetMes_Id;
            CB_ANO.SelectedValue = _controlador.GetAno_id;
            CB_MES.Focus();
            _modoInicializa = false;
            L_FILTRO.Text = "";
            ActualizarTotales();
            ActualizarNotas();
        }
        private void EntradaxCompraFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }


        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
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
            if (_modoInicializa)
                return;
            _controlador.setMesFiltrar("");
            if (CB_MES.SelectedIndex != -1) 
            {
                _controlador.setMesFiltrar(CB_MES.SelectedValue.ToString());
            }
        }
        private void CB_ANO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setAnoFiltrar("");
            if (CB_ANO.SelectedIndex != -1)
            {
                _controlador.setAnoFiltrar(CB_ANO.SelectedValue.ToString());
            }
        }

        private void L_MES_FILTRAR_Click(object sender, EventArgs e)
        {
            CB_MES.SelectedIndex = -1;
        }
        private void L_ANO_FILTRAR_Click(object sender, EventArgs e)
        {
            CB_ANO.SelectedIndex = -1;
        }


        private void Buscar()
        {
            _controlador.Buscar();
            DGV.Refresh();
            ActualizarTotales();
        }
        private void ActualizarTotales()
        {
            L_ITEMS.Text = _controlador.GetCntItems.ToString();
        }
        private void ActualizarNotas()
        {
            L_NOTA_MOV.Text = _controlador.GetNotas;
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
        void _bs_CurrentChanged(object sender, EventArgs e)
        {
            ActualizarNotas();
        }

    }

}