using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Generar
{
    public partial class Frm : Form
    {
        private IGenerar _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializaCombos();
            InicializaGrid();
        }
        private void InicializaCombos()
        {
            CB_SUCURSAL.DisplayMember = "desc";
            CB_SUCURSAL.ValueMember = "id";
            CB_DEP_ORIGEN.DisplayMember = "desc";
            CB_DEP_ORIGEN.ValueMember = "id";
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
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DescPrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
        }


        public void setControlador(IGenerar ctr)
        {
            _controlador = ctr;
        }
        private bool _modoInicio;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicio = true;
            DGV.DataSource = _controlador.GetSource;
            DGV.Refresh();
            TB_MOTIVO.Text = _controlador.GetEnt_Motivo;
            TB_AUTORIZADO_POR.Text = _controlador.GetEnt_AutorizadoPor;
            DTP_FECHA.Value = _controlador.GetFechaSistema;

            CB_SUCURSAL.DataSource = _controlador.SucOrigen.GetSource;
            CB_DEP_ORIGEN.DataSource = _controlador.DepOrigen.GetSource;
            CB_SUCURSAL.SelectedValue = _controlador.SucOrigen.GetId;
            CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigen.GetId;
            ND_CNT_ULT_DIAS.Value = _controlador.GetCntDias;
            _modoInicio = false;
            //ActualizarImporte();
            //IrFoco();
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }
        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void TB_AUTORIZADO_POR_Leave(object sender, EventArgs e)
        {
            _controlador.setAutorizadoPor(TB_AUTORIZADO_POR.Text.Trim().ToUpper());
        }
        private void TB_MOTIVO_Leave(object sender, EventArgs e)
        {
            _controlador.setMotivo(TB_MOTIVO.Text.Trim().ToUpper());
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            _controlador.SucOrigen.setId("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.SucOrigenSetId(CB_SUCURSAL.SelectedValue.ToString());
                _modoInicio = true;
                CB_DEP_ORIGEN.SelectedIndex = -1;
                _modoInicio = false;
            }
        }
        private void CB_DEP_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            _controlador.DepOrigen.setId("");
            if (CB_DEP_ORIGEN.SelectedIndex != -1)
            {
                _controlador.DepOrigen.setId(CB_DEP_ORIGEN.SelectedValue.ToString());
            }
        }

        private void ND_CNT_ULT_DIAS_Leave(object sender, EventArgs e)
        {
            _controlador.setCntDias(ND_CNT_ULT_DIAS.Value);
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void BT_GENERAR_Click(object sender, EventArgs e)
        {
            GenerarToma();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }


        private void Limpiar()
        {
            _controlador.Limpiar();
            Actualizar();
        }
        private void GenerarToma()
        {
            _controlador.GenerarToma();
        }
        private void Procesar()
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
        private void Actualizar()
        {
            TB_MOTIVO.Text = _controlador.GetEnt_Motivo;
            TB_AUTORIZADO_POR.Text = _controlador.GetEnt_AutorizadoPor;
            DTP_FECHA.Value = _controlador.GetFechaSistema;
            CB_SUCURSAL.SelectedValue = _controlador.SucOrigen.GetId;
            CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigen.GetId;
            DGV.Refresh();
        }
    }
}