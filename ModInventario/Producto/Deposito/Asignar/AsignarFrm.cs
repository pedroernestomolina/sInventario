using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.Asignar
{

    public partial class AsignarFrm : Form
    {

        private Gestion _controlador;


        public AsignarFrm()
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
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 100;
            c1.ReadOnly = true;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Nombre";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 130;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;

            var c4 = new DataGridViewCheckBoxColumn();
            c4.Name = "Asignar";
            c4.DataPropertyName = "asignar";
            c4.HeaderText = "Asignar";
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

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private bool _modoInicializar = false;
        private void AsignarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar=true;
            CHB_MARCAR.Checked = false;
            CHB_PRE_DETERMINADA.Checked = false;
            L_PRODUCTO.Text = _controlador.Producto;
            DGV.DataSource = _controlador.Source;
            _modoInicializar = false;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
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
        }

        private void AsignarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_controlador.IsCerrarHabilitado;
            _controlador.InicializarIsCerrarHabilitado();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == DGV.Columns["Asignar"].Index)
                {
                    DGV.EndEdit();  //Stop editing of cell.
                    if ((bool)DGV.Rows[e.RowIndex].Cells["Asignar"].Value)
                        _controlador.Marcar();
                    else
                        _controlador.DesMarcar();
                }
            }
        }

        private void CHB_MARCAR_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.SeleccionarTodas();
        }

        private void CHB_PRE_DETERMINADA_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.SeleccionarPreDeterminada();
        }

    }

}