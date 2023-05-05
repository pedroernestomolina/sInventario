using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.AdmDocumentos.ModoBasico
{

    public partial class AdministradorFrm : Form
    {


        private IBasico _controlador;


        public AdministradorFrm()
        {
            InitializeComponent();
            InicializarGrid_1();
            InicializaCombos();
        }

        private void InicializaCombos()
        {
            CB_TIPO_DOC.DisplayMember = "desc";
            CB_TIPO_DOC.ValueMember = "id";
        }

        private void InicializarGrid_1()
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
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.Width = 110;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "STipoDoc";
            c2.HeaderText = "Tipo";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DocumentoNro";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "SRenglones";
            c5.HeaderText = "Reng";
            c5.Visible = true;
            c5.Width = 40;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5A = new DataGridViewTextBoxColumn();
            c5A.DataPropertyName = "Concepto";
            c5A.HeaderText = "Concepto";
            c5A.Visible = true;
            c5A.MinimumWidth = 120;
            c5A.HeaderCell.Style.Font = f;
            c5A.DefaultCellStyle.Font = f1;
            c5A.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c5B = new DataGridViewTextBoxColumn();
            c5B.DataPropertyName = "UsuarioEstacion";
            c5B.HeaderText = "Usuario";
            c5B.Visible = true;
            c5B.MinimumWidth = 120;
            c5B.HeaderCell.Style.Font = f;
            c5B.DefaultCellStyle.Font = f1;
            c5B.AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "SMonto";
            c6.HeaderText = "Importe";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Situacion";
            c7.Name = "Situacion";
            c7.HeaderText = "Situación";
            c7.Visible = true;
            c7.Width = 80;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleCenter;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "IsAnulado";
            c8.Name= "IsAnulado";
            c8.Visible = false;
            c8.Width = 0;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;

            var c8A = new DataGridViewTextBoxColumn();
            c8A.HeaderText = "Estatus";
            c8A.Name = "Anulado";
            c8A.Visible = true;
            c8A.Width = 60;
            c8A.HeaderCell.Style.Font = f;
            c8A.DefaultCellStyle.Font = f1;

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "DepOrigen";
            c9.HeaderText = "Origen";
            c9.Visible = true;
            c9.Width = 120;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;

            var cA = new DataGridViewTextBoxColumn();
            cA.DataPropertyName = "DepDestino";
            cA.HeaderText = "Destino";
            cA.Visible = true;
            cA.Width = 120;
            cA.HeaderCell.Style.Font = f;
            cA.DefaultCellStyle.Font = f1;


            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5A);
            DGV.Columns.Add(c5B);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c9);
            DGV.Columns.Add(cA);
            DGV.Columns.Add(c8A);
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if ((string)row.Cells["Situacion"].Value == "Pendiente")
                {
                    row.Cells["Situacion"].Style.BackColor = Color.Orange;
                    row.Cells["Situacion"].Style.ForeColor = Color.White;
                }

                if ((bool)row.Cells["IsAnulado"].Value == true)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.Cells["Anulado"].Value = "ANULADO";
                    row.Cells["Anulado"].Style.BackColor = Color.Red;
                    row.Cells["Anulado"].Style.ForeColor = Color.White;
                }
                else
                {
                    //row.Cells["Anulado"].Value = Properties.Resources.bt_ok_3;
                }
            }
        }

        private bool _modoInicializar;
        private void AdministradorFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            L_TITULO.Text = _controlador.GetTitulo;
            DGV.DataSource = _controlador.GetData_Source;
            //CB_TIPO_DOC.DataSource = _controlador.GetTipoDoc_Source;
            //DTP_DESDE.Value =  _controlador.GetFechaDesde;
            //DTP_HASTA.Value =  _controlador.GetFechaHasta;
            //CB_TIPO_DOC.SelectedValue = _controlador.GetTipoDoc_Id;
            DGV.Refresh();
            _modoInicializar = false;

            DTP_DESDE.Checked = true;
            DTP_HASTA.Checked = true;
            Actualizar();
        }


        public void setControlador(IBasico ctr)
        {
            _controlador = ctr;
        }


        private void BT_FILTROS_Click(object sender, EventArgs e)
        {
            Filtros();
        }
        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void BT_VISUALIZAR_Click(object sender, EventArgs e)
        {
            VisualizarDocumento();
        }
        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularItem();
        }
        private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
        private void BT_LIMPIAR_DATA_Click(object sender, EventArgs e)
        {
            LimpiarData();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void L_TIPO_DOC_Click(object sender, EventArgs e)
        {
            LimpiarTipoDoc();
        }
        private void DGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 0)
                {
                    Visualizar();
                }
            }
        }


        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            if (DTP_DESDE.Checked)
            {
                //_controlador.setFechaDesde(DTP_DESDE.Value);
            }
            else 
            {
                //_controlador.setFechaDesdeEstatusOff();
            }
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            if (DTP_HASTA.Checked)
            {
                //_controlador.setFechaHasta(DTP_HASTA.Value);
            }
            else
            {
                //_controlador.setFechaHastaEstatusOff();
            }
        }
        private void CB_TIPO_DOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_modoInicializar) { return; }
            //_controlador.setTipoDoc("");
            //if (CB_TIPO_DOC.SelectedIndex != -1)
            //{
            //    _controlador.setTipoDoc(CB_TIPO_DOC.SelectedValue.ToString());
            //}
        }


        private void Buscar()
        {
            _controlador.Buscar();
            Actualizar();
        }
        private void VisualizarDocumento()
        {
            _controlador.VisualizarDocumento();
        }
        private void Imprimir()
        {
            _controlador.Imprimir();
        }
        private void Filtros()
        {
            _controlador.Filtros();
        }
        private void Visualizar()
        {
            _controlador.Visualizar();
        }
        private void AnularItem()
        {
            _controlador.AnularItem();
        }
        private void Actualizar()
        {
            L_ITEMS.Text = "Cantidad Documentos Encontrados: " + _controlador.GetCntItems.ToString();
        }
        private void LimpiarTipoDoc()
        {
            CB_TIPO_DOC.SelectedIndex = -1;
        }
        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
            _modoInicializar = true;
            //DTP_DESDE.Value = _controlador.GetFechaDesde;
            //DTP_HASTA.Value = _controlador.GetFechaHasta;
            //CB_TIPO_DOC.SelectedValue = _controlador.GetTipoDoc_Id;
            _modoInicializar = false;
        }
        private void LimpiarData()
        {
            _controlador.LimpiarData();
            Actualizar();
        }
        private void Salir()
        {
            this.Close();
        }

    }

}