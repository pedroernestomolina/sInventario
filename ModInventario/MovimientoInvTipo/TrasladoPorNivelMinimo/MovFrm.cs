using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo.TrasladoPorNivelMinimo
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
            var f1 = new Font("Serif", 8, FontStyle.Regular);

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
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DescripcionPrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 180;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c21 = new DataGridViewTextBoxColumn();
            c21.DataPropertyName = "InfNivelMinimoDepDestino";
            c21.HeaderText = "Nivel Mínimo";
            c21.Visible = true;
            c21.Width = 70;
            c21.HeaderCell.Style.Font = f;
            c21.DefaultCellStyle.Font = f1;
            c21.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c21.DefaultCellStyle.Format = "n1";

            var c22 = new DataGridViewTextBoxColumn();
            c22.DataPropertyName = "InfNivelOptimoDepDestino";
            c22.HeaderText = "Nivel Optimo";
            c22.Visible = true;
            c22.Width = 70;
            c22.HeaderCell.Style.Font = f;
            c22.DefaultCellStyle.Font = f1;
            c22.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c22.DefaultCellStyle.Format = "n1";

            var c23 = new DataGridViewTextBoxColumn();
            c23.DataPropertyName = "InfExFisicaDepDestino";
            c23.HeaderText = "Ex/Dest";
            c23.Visible = true;
            c23.Width = 70;
            c23.HeaderCell.Style.Font = f;
            c23.DefaultCellStyle.Font = f1;
            c23.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c23.DefaultCellStyle.Format = "n1";

            var c24 = new DataGridViewTextBoxColumn();
            c24.DataPropertyName = "InfCntReponerDepDestino";
            c24.HeaderText = "Cant Reponer";
            c24.Visible = true;
            c24.Width = 70;
            c24.HeaderCell.Style.Font = f;
            c24.DefaultCellStyle.Font = f;
            c24.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c24.DefaultCellStyle.Format = "n1";

            var c25 = new DataGridViewTextBoxColumn();
            c25.DataPropertyName = "InfExistenciaActual";
            c25.HeaderText = "Ex/Origen";
            c25.Visible = true;
            c25.Width = 70;
            c25.HeaderCell.Style.Font = f;
            c25.DefaultCellStyle.Font = f1;
            c25.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c25.DefaultCellStyle.Format = "n1";

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Cantidad";
            c3.HeaderText = "Cant Regist";
            c3.Visible = true;
            c3.Width = 70;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n1";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Empaque";
            c4.HeaderText = "Empaque";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.MinimumWidth = 80;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Costo";
            c5.HeaderText = "Costo sin Iva";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Importe";
            c6.HeaderText = "Total";
            c6.Visible = true;
            c6.Width = 100;
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

            DGV_DETALLE.Columns.Add(c1);
            DGV_DETALLE.Columns.Add(c2);
            DGV_DETALLE.Columns.Add(c21);
            DGV_DETALLE.Columns.Add(c22);
            DGV_DETALLE.Columns.Add(c23);
            DGV_DETALLE.Columns.Add(c24);
            DGV_DETALLE.Columns.Add(c25);
            DGV_DETALLE.Columns.Add(c3);
            DGV_DETALLE.Columns.Add(c4);
            DGV_DETALLE.Columns.Add(c5);
            DGV_DETALLE.Columns.Add(c6);
            DGV_DETALLE.Columns.Add(c7);
        }

        private void InicializarCombo()
        {
            CB_ORIGEN.DisplayMember = "desc";
            CB_ORIGEN.ValueMember = "id";

            CB_DESTINO.DisplayMember = "desc";
            CB_DESTINO.ValueMember = "id";

            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";

            CB_DEPARTAMENTO.DisplayMember = "desc";
            CB_DEPARTAMENTO.ValueMember = "id";
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
            CB_ORIGEN.DataSource = _controlador.DepOrigenSource;
            CB_DESTINO.DataSource = _controlador.DepDestinoSource;
            CB_CONCEPTO.DataSource = _controlador.ConceptoSource;
            CB_DEPARTAMENTO.DataSource = _controlador.DepartamentoSource;
            CB_ORIGEN.SelectedValue = _controlador.DepOrigenGetID;
            CB_DESTINO.SelectedValue = _controlador.DepDestinoGetID;
            CB_CONCEPTO.SelectedValue = _controlador.ConceptoGetId;
            CB_DEPARTAMENTO.SelectedValue = _controlador.DepartamentoGetId;
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
            CB_ORIGEN.SelectedValue = _controlador.SucursalGetId;
            CB_DESTINO.SelectedValue = _controlador.ConceptoGetId;
            CB_CONCEPTO.SelectedValue = _controlador.DepOrigenGetID;
            CB_DEPARTAMENTO.SelectedValue = _controlador.DepartamentoGetId;
            DGV_DETALLE.Refresh();
            _modoInicio = false;
            IrFocoBusqueda();
        }


        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio)
                return;

            if (_controlador.HabilitarCambio)
            {
                _controlador.setDepOrigen("");
                if (CB_ORIGEN.SelectedIndex != -1)
                {
                    _controlador.setDepOrigen(CB_ORIGEN.SelectedValue.ToString());
                }
            }
            else 
            {
                _modoInicio = true;
                CB_ORIGEN.SelectedValue = _controlador.DepOrigenGetID;
                _modoInicio = false;
            }
        }
        private void CB_DESTINO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio)
                return;

            if (_controlador.HabilitarCambio)
            {
                _controlador.setDepDestino("");
                if (CB_DESTINO.SelectedIndex != -1)
                {
                    _controlador.setDepDestino(CB_DESTINO.SelectedValue.ToString());
                }
            }
            else 
            {
                _modoInicio = true;
                CB_DESTINO.SelectedValue = _controlador.DepDestinoGetID;
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
        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio)
                return;

            if (_controlador.HabilitarCambio)
            {
                _controlador.setDepartamento("");
                if (CB_DEPARTAMENTO.SelectedIndex != -1)
                {
                    _controlador.setDepartamento(CB_DEPARTAMENTO.SelectedValue.ToString());
                }
            }
            else 
            {
                _modoInicio = true;
                CB_DEPARTAMENTO.SelectedValue = _controlador.DepartamentoGetId;
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
            _controlador.setActivarBusquedaParaTraslado();
            _controlador.setActivarDepOrigen(_controlador.GetIdDepOrigen);
            _controlador.setActivarDepDestino(_controlador.GetIdDepDestino);
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

        private void ActualizarFicha()
        {
            _modoInicio = true;
            TB_MOTIVO.Text = _controlador.Motivo;
            TB_AUTORIZADO_POR.Text = _controlador.AutorizadoPor;
            CB_ORIGEN.DataSource = _controlador.DepOrigenSource;
            CB_DESTINO.DataSource = _controlador.DepDestinoSource;
            CB_CONCEPTO.DataSource = _controlador.ConceptoSource;
            CB_DEPARTAMENTO.DataSource = _controlador.DepartamentoSource;
            CB_ORIGEN.SelectedValue = _controlador.DepOrigenGetID;
            CB_DESTINO.SelectedValue = _controlador.DepDestinoGetID;
            CB_CONCEPTO.SelectedValue = _controlador.ConceptoGetId;
            CB_DEPARTAMENTO.SelectedValue = _controlador.DepartamentoGetId;
            _modoInicio = false;
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

        private void BT_PRODUCTOS_NIVEL_MINIMO_Click(object sender, EventArgs e)
        {
            CapturarProductosConNivelMinimo();
        }
        private void CapturarProductosConNivelMinimo()
        {
            _controlador.CapturarProductosConNivelMinimo();
            if (_controlador.CapturarProductosConNivelMinimoIsOk)
            {
                ActualizarImporte();
            }
        }

        private void BT_ELIMINAR_EXISTENCIA_CERO_Click(object sender, EventArgs e)
        {
            EliminarExistenciaNoDisponible();
        }
        private void EliminarExistenciaNoDisponible()
        {
            _controlador.EliminarExistenciaNoDisponible();
            if (_controlador.EliminarExistenciaNoDisponibleIsOk) 
            {
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