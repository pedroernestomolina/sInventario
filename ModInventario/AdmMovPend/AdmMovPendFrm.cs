using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.AdmMovPend
{

    public partial class AdmMovPendFrm : Form
    {


        private IAdmMovPend _controlador;


        public AdmMovPendFrm()
        {
            InitializeComponent();
            InicializarGrid();
            InicializaCombos();
        }

        private void InicializaCombos()
        {
            CB_TIPO_DOC.DisplayMember = "desc";
            CB_TIPO_DOC.ValueMember = "id";
        }

        private void InicializarGrid()
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
            DGV.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Fecha";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "TipoDoc";
            c2.HeaderText = "Tipo";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Origen";
            c3.HeaderText = "Origen";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.MinimumWidth = 120;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Destino";
            c4.HeaderText = "Destino";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.MinimumWidth = 120;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CntRenglones";
            c5.HeaderText = "Reng";
            c5.Visible = true;
            c5.Width = 40;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5A = new DataGridViewTextBoxColumn();
            c5A.DataPropertyName = "MontoDivisa";
            c5A.HeaderText = "Monto ($)";
            c5A.Visible = true;
            c5A.Width  = 90;
            c5A.HeaderCell.Style.Font = f;
            c5A.DefaultCellStyle.Font = f1;
            c5A.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            var c5B = new DataGridViewTextBoxColumn();
            c5B.DataPropertyName = "UsuarioEstacion";
            c5B.HeaderText = "Usuario";
            c5B.Visible = true;
            c5B.MinimumWidth = 120;
            c5B.HeaderCell.Style.Font = f;
            c5B.DefaultCellStyle.Font = f1;
            c5B.AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5A);
            DGV.Columns.Add(c5B);
        }

        private bool _modoInicializar;
        private void AdministradorFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_TIPO_DOC.DataSource = _controlador.TipoDocSource;
            CB_TIPO_DOC.SelectedValue = _controlador.TipoDocID;
            _modoInicializar = false;

            L_TITULO.Text = _controlador.GetTitulo;
            DGV.DataSource = _controlador.GetSource;
            DGV.Refresh();
            Actualizar();
        }

        public void setControlador(IAdmMovPend ctr)
        {
            _controlador = ctr;
        }


        private void Actualizar()
        {
            L_ITEMS.Text = "Cantidad Items Encontrados: "+_controlador.GetCntItems.ToString() ;
        }
        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            _controlador.ActBuscar();
            Actualizar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            this.Close();
        }

        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularItem();
        }
        private void AnularItem()
        {
            _controlador.ActAnular();
            if (_controlador.AnularIsOk) 
            {
                Actualizar();
            }
        }
        private void CB_TIPO_DOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;
            _controlador.setTipoDoc("");
            if (CB_TIPO_DOC.SelectedIndex != -1)
            {
                _controlador.setTipoDoc(CB_TIPO_DOC.SelectedValue.ToString());
            }
        }
        private void L_TIPO_DOC_Click(object sender, EventArgs e)
        {
            CB_TIPO_DOC.SelectedIndex = -1;
        }
        private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
            if (_controlador.LimpiarFiltrosIsOk)
            {
                _modoInicializar = true;
                CB_TIPO_DOC.SelectedIndex =-1;
                _modoInicializar = false;
            }
        }
        private void BT_LIMPIAR_DATA_Click(object sender, EventArgs e)
        {
            LimpiarData();
        }
        private void LimpiarData()
        {
            _controlador.ActLimpiar();
            Actualizar();
        }
        private void BT_VISUALIZAR_Click(object sender, EventArgs e)
        {
            VisualizarDocumento();
        }
        private void VisualizarDocumento()
        {
            GenerarMov();
        }
        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
        private void Imprimir()
        {
            _controlador.ActImprimir();
        }
        private void BT_FILTROS_Click(object sender, EventArgs e)
        {
            Filtros();
        }
        private void Filtros()
        {
            //_controlador.Filtros();
        }
        private void DGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                if (e.ColumnIndex >= 0)
                {
                    GenerarMov();
                }
            }
        }
        private void GenerarMov()
        {
            _controlador.GenerarMov();
        }
        private void VerAnulacion()
        {
        }

    }

}