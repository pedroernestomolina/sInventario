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
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void VisualizarFrm_Load(object sender, EventArgs e)
        {
            L_CODIGO_PRD.Text = _controlador.CodigoPrd;
            L_DESCRIPCION_PRD.Text = _controlador.DescripcionPrd;
            L_NOMBRE_PRD.Text = _controlador.NombrePrd;
            L_DEPARTAMENTO_PRD.Text = _controlador.DepartamentoPrd;
            L_GRUPO_PRD.Text=_controlador.GrupoPrd;
            L_MARCA_PRD.Text=_controlador.MarcaPrd;
            L_IMPUESTO_PRD.Text=_controlador.ImpuestoPrd;
            L_ORIGEN_PRD.Text=_controlador.OrigenPrd;
            L_CATEGORIA_PRD.Text = _controlador.CategoriaPrd;
            L_CLASIFICACION_PRD.Text = _controlador.ClasificacionPrd;
            L_ADM_DIVISA_PRD.Text = _controlador.AdmDivisaPrd;
            L_EMPAQUE_PRD.Text = _controlador.EmpaquePrd;
            label30.Text = _controlador.ContenidoPrd;
            L_MODELO_PRD.Text = _controlador.ModeloPrd;
            L_REFERENCIA_PRD.Text = _controlador.ReferenciaPrd;
            CHB_CATALOGO.Checked = _controlador.IsCatalagoPrd;
            CHB_PESADO.Checked = _controlador.IsPesadoPrd;
            L_PLU_PRD.Text = _controlador.PluPrd;
            L_DIAS_EMPAQUE_PRD.Text = _controlador.DiasEmpaquePrd.ToString();
            DGV.DataSource = _controlador.SourceCodAlterno;
            L_ESTATUS_INACTIVO.Visible = _controlador.IsInactivo;
        }

    }

}
