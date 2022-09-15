using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo.Ajuste
{
    public partial class MovFrm : Form
    {

        private IGestionTipo _controlador;
        
        
        public MovFrm()
        {
            InitializeComponent();
            InicializarGrid();
            InicializarCombo();
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV_DETALLE.AllowUserToAddRows = false;
            DGV_DETALLE.AllowUserToDeleteRows = false;
            DGV_DETALLE.AutoGenerateColumns = false;
            DGV_DETALLE.AllowUserToResizeRows = false;
            DGV_DETALLE.AllowUserToResizeColumns = false;
            DGV_DETALLE.AllowUserToOrderColumns = false;
            DGV_DETALLE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_DETALLE.MultiSelect = false;
            DGV_DETALLE.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DescripcionPrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Cantidad";
            c3.HeaderText = "Cant";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Empaque";
            c4.HeaderText = "Empaque";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.MinimumWidth = 100;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Costo";
            c5.HeaderText = "Costo sin Iva";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Importe";
            c6.HeaderText = "Total";
            c6.Visible = true;
            c6.Width = 120;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewCheckBoxColumn();
            c7.DataPropertyName = "EsAdmDivisa";
            c7.HeaderText = "($)";
            c7.Visible = true;
            c7.Width = 30;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "TipoMovimiento";
            c8.Name = "TipoMov";
            c8.HeaderText = "Mov";
            c8.Visible = true;
            c8.Width = 90;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;

            var c9 = new DataGridViewCheckBoxColumn();
            c9.DataPropertyName = "Signo";
            c9.Name = "Signo";
            c9.HeaderText = "";
            c9.Visible = false;
            c9.Width = 0;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV_DETALLE.Columns.Add(c1);
            DGV_DETALLE.Columns.Add(c2);
            DGV_DETALLE.Columns.Add(c3);
            DGV_DETALLE.Columns.Add(c4);
            DGV_DETALLE.Columns.Add(c5);
            DGV_DETALLE.Columns.Add(c6);
            DGV_DETALLE.Columns.Add(c7);
            DGV_DETALLE.Columns.Add(c8);
            DGV_DETALLE.Columns.Add(c9);
        }

        private void InicializarCombo()
        {
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";

            CB_SUCURSAL.DisplayMember = "desc";
            CB_SUCURSAL.ValueMember = "id";

            CB_DEP_ORIGEN.DisplayMember = "desc";
            CB_DEP_ORIGEN.ValueMember = "id";
        }

        public void setControlador(IGestionTipo ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk) 
            {
                Salir();
            }
        }

        private bool _modoInicio;
        private void MvFrm_Load(object sender, EventArgs e)
        {
            _modoInicio = true;
            DGV_DETALLE.DataSource = _controlador.ItemSource;
            L_TIPO_MOVIMIENTO.Text = _controlador.TipoMovimiento;
            TB_MOTIVO.Text = _controlador.Motivo;
            TB_AUTORIZADO_POR.Text = _controlador.AutorizadoPor;
            DTP_FECHA.Value = _controlador.FechaSistema;
            CB_CONCEPTO.DataSource = _controlador.ConceptoSource;
            CB_SUCURSAL.DataSource = _controlador.SucursalSource;
            CB_DEP_ORIGEN.DataSource = _controlador.DepOrigenSource;
            CB_CONCEPTO.SelectedValue = _controlador.ConceptoGetId;
            CB_SUCURSAL.SelectedValue = _controlador.SucursalGetId;
            CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigenGetID;
            _modoInicio = false;
            switch (_controlador.MetBusqPrd)
            {
                case enumerados.enumMetBusquedaPrd.PorCodigo:
                    RB_BUSCAR_POR_CODIGO.Checked = true;
                    break;
                case enumerados.enumMetBusquedaPrd.PorNombre:
                    RB_BUSCAR_POR_NOMBRE.Checked = true;
                    break;
                case enumerados.enumMetBusquedaPrd.PorReferencia :
                    RB_BUSCAR_POR_REFERENCIA.Checked = true;
                    break;
            }
            ActualizarImporte();
            IrFocoBusqueda();
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarVista();
        }
        private void LimpiarVista()
        {
            IrFocoBusqueda();
            _controlador.Limpiar();
            if (_controlador.LimpiarIsOk)
            {
                Limpiar();
                ActualizarImporte();
                IrFocoBusqueda();
            }
        }
        private void Limpiar()
        {
            _modoInicio = true;
            TB_MOTIVO.Text = _controlador.Motivo;
            TB_AUTORIZADO_POR.Text = _controlador.AutorizadoPor;
            TB_CADENA_BUSQ.Text = "";
            DTP_FECHA.Value = _controlador.FechaSistema;
            CB_CONCEPTO.SelectedValue = _controlador.ConceptoGetId;
            CB_SUCURSAL.SelectedValue = _controlador.SucursalGetId;
            CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigenGetID;
            DGV_DETALLE.Refresh();
            _modoInicio = false;
            IrFocoBusqueda();
        }


        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio)
                return;

            if (_controlador.HabilitarCambio)
            {
                _controlador.setSucursal("");
                if (CB_SUCURSAL.SelectedIndex != -1)
                {
                    _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
                    _modoInicio = true;
                    CB_DEP_ORIGEN.SelectedIndex = -1;
                    _modoInicio = false;
                }
            }
            else
            {
                _modoInicio = true;
                CB_SUCURSAL.SelectedValue = _controlador.SucursalGetId;
                _modoInicio = false;
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio)
                return;

            _controlador.setConcepto("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.setConcepto(CB_CONCEPTO.SelectedValue.ToString());
            }
        }
        private void CB_DEP_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio)
                return;

            if (_controlador.HabilitarCambio)
            {
                _controlador.setDepOrigen("");
                if (CB_DEP_ORIGEN.SelectedIndex != -1)
                {
                    _controlador.setDepOrigen(CB_DEP_ORIGEN.SelectedValue.ToString());
                }
            }
            else
            {
                _modoInicio = true;
                CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigenGetID;
                _modoInicio = false;
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

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void ActualizarImporte()
        {
            L_MONTO.Text = _controlador.TotalImporte.ToString("n2");
            L_ITEMS.Text = "Total Items: " + Environment.NewLine + _controlador.CntItems.ToString();
            L_ITEMS_PEND.Text = _controlador.DocPendientes.ToString();
        }
        private void ActualizarFicha()
        {
            _modoInicio = true;
            TB_MOTIVO.Text = _controlador.Motivo;
            TB_AUTORIZADO_POR.Text = _controlador.AutorizadoPor;
            DTP_FECHA.Value = _controlador.FechaSistema;
            CB_CONCEPTO.SelectedValue = _controlador.ConceptoGetId;
            CB_SUCURSAL.SelectedValue = _controlador.SucursalGetId;
            CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigenGetID;
            _modoInicio = false;
        }

        private void RB_BUSCAR_POR_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMetBusqCodigo();
            IrFocoBusqueda();
        }
        private void RB_BUSCAR_POR_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMetBusqNombre();
            IrFocoBusqueda();
        }
        private void RB_BUSCAR_POR_REFERENCIA_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMetBusqRef();
            IrFocoBusqueda();
        }
        private void IrFocoBusqueda()
        {
            TB_CADENA_BUSQ.Focus();
        }
        private void TB_CADENA_BUSQ_Leave(object sender, EventArgs e)
        {
            _controlador.setCadenaBusqueda(TB_CADENA_BUSQ.Text.Trim().ToUpper());
        }
        private void BT_BUSCAR_PRODUCTO_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }
        private void BuscarProducto()
        {
            _controlador.BuscarProducto();
            ActualizarImporte();
            TB_CADENA_BUSQ.Text = "";
            TB_CADENA_BUSQ.Focus();
        }
        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            FiltrarBusqPrd();
        }
        private void FiltrarBusqPrd()
        {
            _controlador.FiltrarBusqPrd();
        }


        private void BT_ELIMINAR_ITEM_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }
        private void EliminarItem()
        {
            IrFocoBusqueda();
            _controlador.EliminarItem();
            if (_controlador.EliminarIsOk)
                ActualizarImporte();
        }
        private void BT_EDITAR_ITEM_Click(object sender, EventArgs e)
        {
            EditarItem();
        }
        private void EditarItem()
        {
            IrFocoBusqueda();
            _controlador.EditarItem();
            if (_controlador.EditarIsOk)
                ActualizarImporte();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarDocIsOk)
            {
                Limpiar();
                ActualizarImporte();
                _controlador.NuevoDocumento();
            }
        }

        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            MaestroConcepto();
            CB_CONCEPTO.SelectedIndex = -1;
        }

        private void MaestroConcepto()
        {
            _controlador.ConceptoMaestro();
        }

        private void MvFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void DGV_DETALLE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_DETALLE.Columns[e.ColumnIndex].Name == "TipoMov")
            {
                if (e.Value.ToString() == "DESCARGO")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void BT_PENDIENTE_Click(object sender, EventArgs e)
        {
            ListaDocPendiente();
        }
        private void ListaDocPendiente()
        {
            _controlador.ListaDocPendientes();
            if (_controlador.ListaDocPendientesIsOk)
            {
                ActualizarFicha();
                ActualizarImporte();
            }
        }

        private void BT_DEJAR_PENDIENTE_Click(object sender, EventArgs e)
        {
           DejarEnPendiente();
        }
        private void DejarEnPendiente()
        {
            _controlador.DejarEnPendiente();
            if (_controlador.DejarEnPendienteIsOk)
            {
                Limpiar();
                _controlador.NuevoDocumento();
                ActualizarImporte();
            }
        }

        private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
        }

    }

}