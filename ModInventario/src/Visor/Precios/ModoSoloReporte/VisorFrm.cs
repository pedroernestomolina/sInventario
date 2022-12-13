using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Visor.Precios.ModoSoloReporte
{

    public partial class VisorFrm : Form
    {

        private ISoloReporte _controlador;


        public VisorFrm()
        {
            InitializeComponent();
            InicializaGrid();
            InicializaCombo();
        }


        private void InicializaCombo()
        {
            CB_DESDE.DisplayMember = "desc";
            CB_DESDE.ValueMember = "id";
        }

        private void InicializaGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);
            var f2 = new Font("Serif", 6, FontStyle.Bold);

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
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Nombre";
            c2.HeaderText = "Descrip";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 200;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Tasa";
            c3.HeaderText = "Tasa";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 40;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Empq1";
            c4.HeaderText = "Emp(1)";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f;
            c4.Width = 110;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "P1";
            c5.HeaderText = "P/Emp"; 
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.Width = 140;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Empq2";
            c6.HeaderText = "Emp(2)";
            c6.Visible = true;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f;
            c6.Width = 110;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "P2";
            c7.HeaderText = "P/Emp";
            c7.Visible = true;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.Width = 140;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c7.DefaultCellStyle.Format = "n2";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Empq3";
            c8.HeaderText = "Emp(3)";
            c8.Visible = true;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f;
            c8.Width = 110;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "P3";
            c9.HeaderText = "P/Emp";
            c9.Visible = true;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;
            c9.Width = 140;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c9.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c9);
        }


        public void setControlador(ISoloReporte ctr)
        {
            _controlador = ctr;
        }

        private bool _modoInicializa;
        private void TrasladoFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            var _bs = (BindingSource)_controlador.GetSource;
            DGV.DataSource = _bs;
            CB_DESDE.DataSource = _controlador.GetDesde_Source;
            CB_DESDE.SelectedValue = _controlador.GetDesde_Id;
            CB_DESDE.Focus();
            CHB_EXCLUIR_CAMBIOS_MASIVO.Checked = _controlador.GetExcluirCambioMasivo;
            switch (_controlador.GetMostrarPrecio)
            {
                case 1:
                    RB_MOSTRAR_SOLO_DIVISA.Checked=true;
                    break;
                case 2:
                    RB_MOSTRAR_SOLO_BS.Checked=true;
                    break;
                case 3:
                    RB_MOSTRAR_AMBOS_PRECIOS.Checked=true;
                    break;
            }
            _modoInicializa = false;
            ActualizarTotales();
        }
        private void TrasladoFrm_FormClosing(object sender, FormClosingEventArgs e)
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


        private void CB_DESDE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setDesde("");
            if (CB_DESDE.SelectedIndex != -1)
            {
                _controlador.setDesde(CB_DESDE.SelectedValue.ToString());
            }
        }
        private void CHB_EXCLUIR_CAMBIOS_MASIVO_CheckedChanged(object sender, EventArgs e)
        {
            ExcluirCambiosMasivo();
        }


        private void RB_MOSTRAR_SOLO_DIVISA_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            MostrarPrecioSoloDivisa();
        }
        private void RB_MOSTRAR_SOLO_BS_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            MostrarPrecioSoloBs();
        }
        private void RB_MOSTRAR_AMBOS_PRECIOS_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            MostrarPrecioAmbos();
        }


        private void L_DESDE_FILTRAR_Click(object sender, EventArgs e)
        {
            CB_DESDE.SelectedIndex = -1;
        }


        private void MostrarPrecioSoloDivisa()
        {
            _controlador.MostrarPrecioSoloDivisa();
        }
        private void MostrarPrecioSoloBs()
        {
            _controlador.MostrarPrecioSoloBs();
        }
        private void MostrarPrecioAmbos()
        {
            _controlador.MostrarPrecioAmbos();
        }
        private void ExcluirCambiosMasivo()
        {
            _controlador.ExcluirCambiosMasivo(CHB_EXCLUIR_CAMBIOS_MASIVO.Checked);
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