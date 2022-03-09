using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace ModInventario.Graficas
{

    public partial class GraficaFrm : Form
    {


        private Gestion _controlador;


        public GraficaFrm()
        {
            InitializeComponent();
            InicializarGrid();

            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Auto";
        }

        private void GraficaFrm_Load(object sender, EventArgs e)
        {
            CB_DEPOSITO.DataSource = _controlador.SourceDeposito;
            CB_DEPOSITO.SelectedIndex = -1;
            //DGV.DataSource = _controlador_datosGV;
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
            c1.DataPropertyName = "producto";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CntUnd";
            c2.HeaderText = "Cant/Und";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CntDoc";
            c3.HeaderText = "Cant/Doc";
            c3.Visible = true;
            c3.Width = 70;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c1);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoDeposito = "";
            if (CB_DEPOSITO.SelectedIndex != -1) 
            {
                _controlador.AutoDeposito = CB_DEPOSITO.SelectedValue.ToString();
            }
        }

        private void CB_MOVIMIENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.Modulo = "";
            if (CB_MOVIMIENTO.SelectedIndex != -1)
            {
                _controlador.Modulo = CB_MOVIMIENTO.SelectedItem.ToString();
            }
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            Actualizar();
        }

        private void Actualizar()
        {
            DTP_DESDE.Value = _controlador.Desde;
            DTP_HASTA.Value = _controlador.Hasta;
            CB_DEPOSITO.SelectedIndex = -1;
            CB_MOVIMIENTO.SelectedIndex = -1;
            DGV.DataSource = null;
        }

        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
            chart1.Titles.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
            chart1.Legends.Add("Series 1");
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            chart1.Titles.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
            chart1.Legends.Add("Series 1");
            _controlador.Buscar();
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Desde = DTP_DESDE.Value.Date;
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Hasta = DTP_HASTA.Value.Date;
        }

        public void SetGrafica(List<Gestion.DataGrafico> dg, List<Gestion.DataVista> dv, string titulo)
        {
            Actualizar();
            if (dg.Count == 0)
                return;

            DGV.DataSource = dv;
            chart1.Titles.Clear();
            chart1.Titles.Add(titulo);
            chart1.Titles[0].Font = new Font("Verdana", 12);
            chart1.Series.Clear();  //Eliminamos cualquier serie del grafico
            chart1.DataBindTable(dg, "producto"); //Enlazamos nuestra lista al grafico y le indicamos la propiedad que se usara para el eje X
            chart1.Series[0].ChartType = SeriesChartType.Pie; //Tipo de grafico de linea para la serie 1
            chart1.Series[0].LabelToolTip = "PRUEBA"; //Tipo de grafico de linea para la serie 1
            //chart1.Series[0].XValueMember = "";
            //chart1.Series[0].YValueMembers = "Count";
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0].Label = "#PERCENT{P2}";
            chart1.Series[0].LegendText = "#VALX";
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.Legends[0].Enabled = true;

            //chart1.Series[0].Points.DataBindXY(x, y);
            //chart1.Series.Clear();  //Eliminamos cualquier serie del grafico
            //chart1.Series[0].LegendText = "PRUEBA";
            //chart1.Series[0].Points.DataBindXY(x, y);
            //chart1.Series[0].ChartType = SeriesChartType.Bar; //Tipo de grafico de linea para la serie 1

            //chart1.Series[1].ChartType = SeriesChartType.Bar; //Tipo de grafico de linea para la serie 1
            //chart1.Series[1].LabelToolTip = "PRUEBA"; //Tipo de grafico de linea para la serie 1
            //chart1.Series[1].XValueMember = "Name";
            //chart1.Series[1].YValueMembers = "Count";
            //chart1.Series[1].IsValueShownAsLabel = true;
            //chart1.Series[1].Label = "#PERCENT{P2}";
            //chart1.Series[1].LegendText = "#VALX";

            //chart1.Series[1].ChartType = SeriesChartType.Pie; //Tipo de grafico de linea para la serie 2
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            ImprimirResultados();
        }

        private void ImprimirResultados()
        {
            _controlador.ImprimirResultados();
        }
    
    }

}