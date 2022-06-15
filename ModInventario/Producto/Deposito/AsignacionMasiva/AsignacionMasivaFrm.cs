using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.AsignacionMasiva
{

    public partial class AsignacionMasivaFrm : Form
    {

        private IAsignacion _controlador;


        public AsignacionMasivaFrm()
        {
            InitializeComponent();
            InicializarCombo();
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
            c1.DataPropertyName = "Nombre";
            c1.HeaderText = "Departamento";
            c1.Visible = true;
            c1.MinimumWidth = 220;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c2 = new DataGridViewCheckBoxColumn();
            c2.DataPropertyName = "Excluir";
            c2.HeaderText = "Excluir";
            c2.Visible = true;
            c2.Width = 60;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.ReadOnly = false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
        }
        private void InicializarCombo()
        {
            CB_DEPOSITO.DisplayMember = "desc";
            CB_DEPOSITO.ValueMember = "id";
        }


        public void setControlador(IAsignacion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.IsAbandonarIsOk)
            {
                Salir();
            }
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.IsProcesarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
        private void AsignacionMasivaFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.IsAbandonarIsOk || _controlador.IsProcesarIsOk) 
            {
                e.Cancel = false;
            }
        }

        private bool _modoInicializa;
        private void AsignacionMasivaFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            DGV.DataSource = _controlador.DepartGetSource;
            CB_DEPOSITO.DataSource = _controlador.DepositoGetSource;
            CB_DEPOSITO.SelectedValue = _controlador.DepositoGetId;
            _modoInicializa = false;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) 
            {
                return;
            }
            _controlador.setDeposito("");
            if (CB_DEPOSITO.SelectedIndex != -1) 
            {
                _controlador.setDeposito(CB_DEPOSITO.SelectedValue.ToString());
            }
        }

    }

}