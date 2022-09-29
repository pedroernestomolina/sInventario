using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.VisualizarFicha
{
    
    public partial class VisualizarFrm : Form
    {

        private Gestion _controlador;


        public VisualizarFrm()
        {
            InitializeComponent();
            InicializarGridAlterno();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void InicializarGridAlterno()
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
            DGV.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns.Add(c1);
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
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

        private void VisualizarFrm_Load(object sender, EventArgs e)
        {
            L_CODIGO_PRD.Text = _controlador.GetCodigoPrd;
            L_DESCRIPCION_PRD.Text = _controlador.GetDescripcionPrd;
            L_NOMBRE_PRD.Text = _controlador.GetNombrePrd;
            L_DEPARTAMENTO_PRD.Text = _controlador.GetDepartamentoPrd;
            L_GRUPO_PRD.Text=_controlador.GetGrupoPrd;
            L_MARCA_PRD.Text=_controlador.GetMarcaPrd;
            L_IMPUESTO_PRD.Text=_controlador.GetImpuestoPrd;
            L_ORIGEN_PRD.Text=_controlador.GetOrigenPrd;
            L_CATEGORIA_PRD.Text = _controlador.GetCategoriaPrd;
            L_CLASIFICACION_PRD.Text = _controlador.GetClasificacionPrd;
            L_ADM_DIVISA_PRD.Text = _controlador.GetAdmDivisaPrd;
            L_EMPAQUE_PRD.Text = _controlador.GetEmpaquePrd;
            label30.Text = _controlador.GetContenidoPrd;
            L_MODELO_PRD.Text = _controlador.GetModeloPrd;
            L_REFERENCIA_PRD.Text = _controlador.GetReferenciaPrd;
            CHB_CATALOGO.Checked = _controlador.GetIsCatalagoPrd;
            CHB_PESADO.Checked = _controlador.GetIsPesadoPrd;
            L_PLU_PRD.Text = _controlador.GetPluPrd;
            L_DIAS_EMPAQUE_PRD.Text = _controlador.GetDiasEmpaquePrd.ToString();
            DGV.DataSource = _controlador.GetCodAlterno_Source;
            L_ESTATUS_INACTIVO.Visible = _controlador.GetIsInactivo;
            L_EMP_INV.Text = _controlador.GetEmpaqueInv;
            L_CONT_EMP_INV.Text = _controlador.GetContEmpInv.ToString();
        }
        private void VisualizarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk) 
            {
                e.Cancel = false;
            }
        }

    }

}