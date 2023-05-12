using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Traslado.PorNIvel
{
    public partial class MovFrm : Form
    {
        private IPorNIvel _controlador;
        
        
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

            DGV_DETALLE.RowHeadersVisible = false;
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
            c4.DataPropertyName = "EmpaqueMov";
            c4.HeaderText = "Empaque";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.MinimumWidth = 80;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CostoNeto";
            c5.HeaderText = "Costo Neto";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "ImporteNeto";
            c6.HeaderText = "Importe";
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
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
            CB_SUC_ORIGEN.DisplayMember = "desc";
            CB_SUC_ORIGEN.ValueMember = "id";
            CB_SUC_DESTINO.DisplayMember = "desc";
            CB_SUC_DESTINO.ValueMember = "id";
            CB_DEPARTAMENTO.DisplayMember = "desc";
            CB_DEPARTAMENTO.ValueMember = "id";
            CB_METODO_BUSQ.DisplayMember = "desc";
            CB_METODO_BUSQ.ValueMember = "id";
        }

        public void setControlador(IPorNIvel ctr)
        {
            _controlador = ctr;
        }

        private bool _modoInicio;
        private void MvFrm_Load(object sender, EventArgs e)
        {
            _modoInicio = true;
            DGV_DETALLE.DataSource = _controlador.ListaItems.GetSource;
            L_TIPO_MOVIMIENTO.Text = _controlador.GetInf_TipoMovimiento;
            TB_MOTIVO.Text = _controlador.GetEnt_Motivo;
            TB_AUTORIZADO_POR.Text = _controlador.GetEnt_AutorizadoPor;
            DTP_FECHA.Value = _controlador.GetFechaSistema;

            CB_METODO_BUSQ.DataSource = _controlador.CompBusqProducto.MetodoBusqueda_GetSource;
            CB_METODO_BUSQ.SelectedValue = _controlador.CompBusqProducto.MetodoBusqueda_GetId;

            CB_CONCEPTO.DataSource = _controlador.Concepto.GetSource;
            CB_SUC_ORIGEN.DataSource = _controlador.SucOrigen.GetSource;
            CB_SUC_DESTINO.DataSource = _controlador.SucDestino.GetSource;
            CB_DEPARTAMENTO.DataSource = _controlador.Departamento.GetSource;
            CB_CONCEPTO.SelectedValue = _controlador.Concepto.GetId;
            CB_SUC_ORIGEN.SelectedValue = _controlador.SucOrigen.GetId;
            CB_SUC_DESTINO.SelectedValue = _controlador.SucDestino.GetId;
            CB_DEPARTAMENTO.SelectedValue = _controlador.Departamento.GetId;
            //
            CB_CONCEPTO.Enabled = !_controlador.ActivarDepPreDeterminadoParaDevolucion;
            CB_DEPARTAMENTO.Enabled = !_controlador.ActivarDepPreDeterminadoParaDevolucion;
            //
            RefrescarBusqueda();
            _modoInicio = false;
            ActualizarImporte();
            IrFocoBusqueda();
        }
        private void MvFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }
        private void MovFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                IrFocoBusqueda();
            }
        }
        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            ActivarFiltros();
        }
        private void BT_LIMPIAR_FILTROS_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }
        private void BT_BUSCAR_PRODUCTO_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }
        private void BT_PRODUCTOS_NIVEL_MINIMO_Click(object sender, EventArgs e)
        {
            CapturarProductosConExistenciaPorDebajoNivelMinimo();
        }
        private void BT_ELIMINAR_EXISTENCIA_CERO_Click(object sender, EventArgs e)
        {
            EliminarItemsDondeExistenciaEnDepOrigenSeaCero();
        }
        private void BT_EDITAR_ITEM_Click(object sender, EventArgs e)
        {
            EditarItem();
        }
        private void BT_ELIMINAR_ITEM_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarVista();
        }
        private void BT_LISTA_PEND_Click(object sender, EventArgs e)
        {
            ListaPendientes();
        }
        private void BT_DEJAR_PENDIENTE_Click(object sender, EventArgs e)
        {
            DejarEnPendiente();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }


        private void CB_SUC_ORIGEN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            if (_controlador.ListaItems.GetCtnItems > 0)
            {
                CB_SUC_ORIGEN.SelectedValue = _controlador.SucOrigen.GetId;
                Helpers.Msg.Alerta("SUCURSAL NO PODRA SER CAMBIADA MIENTRAS EXISTAN ITEMS EN LA LISTA");
                return;
            }
            _controlador.SucOrigenSetId("");
            if (CB_SUC_ORIGEN.SelectedIndex != -1)
            {
                _controlador.SucOrigenSetId(CB_SUC_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            _controlador.Concepto.setId("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.Concepto.setId(CB_CONCEPTO.SelectedValue.ToString());
            }
        }
        private void CB_SUC_DESTINO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            if (_controlador.ListaItems.GetCtnItems > 0)
            {
                CB_SUC_DESTINO.SelectedValue = _controlador.SucDestino.GetId;
                Helpers.Msg.Alerta("SUCURSAL NO PODRA SER CAMBIADA MIENTRAS EXISTAN ITEMS EN LA LISTA");
                return;
            }
            _controlador.SucDestinoSetId("");
            if (CB_SUC_DESTINO.SelectedIndex != -1)
            {
                _controlador.SucDestinoSetId(CB_SUC_DESTINO.SelectedValue.ToString());
            }
        }
        private void CB_DEPARTAMENTO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            if (_controlador.ListaItems.GetCtnItems > 0)
            {
                CB_DEPARTAMENTO.SelectedValue = _controlador.Departamento.GetId;
                Helpers.Msg.Alerta("DEPOSITO NO PODRA SER CAMBIADO MIENTRAS EXISTAN ITEMS EN LA LISTA");
                return;
            }
            _controlador.Departamento.setId("");
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.Departamento.setId(CB_DEPARTAMENTO.SelectedValue.ToString());
            }
        }
        private void CB_METODO_BUSQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            _controlador.CompBusqProducto.setMetodo("");
            if (CB_METODO_BUSQ.SelectedIndex != -1)
            {
                _controlador.CompBusqProducto.setMetodo(CB_METODO_BUSQ.SelectedValue.ToString());
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
        private void TB_CADENA_BUSQ_Leave(object sender, EventArgs e)
        {
            _controlador.CompBusqProducto.setCadenaBuscar(TB_CADENA_BUSQ.Text.Trim().ToUpper());
        }


        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            AgregarConcepto();
        }
        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            LimpiarDeprtamento();
        }


        private void ActivarFiltros()
        {
            IrFocoBusqueda();
            _controlador.CompBusqProducto.MostrarFiltros();
        }
        private void LimpiarFiltros()
        {
            IrFocoBusqueda();
            _controlador.CompBusqProducto.Limpiar();
            RefrescarBusqueda();
        }
        private void BuscarProducto()
        {
            IrFocoBusqueda();
            _controlador.BuscarProducto();
            ActualizarImporte();
            TB_CADENA_BUSQ.Text = _controlador.CompBusqProducto.GetCadena;
        }
        private void CapturarProductosConExistenciaPorDebajoNivelMinimo()
        {
            IrFocoBusqueda();
            _controlador.CapturarProductosConExistenciaPorDebajoNivelMinimo();
            ActualizarImporte();
        }
        private void EliminarItemsDondeExistenciaEnDepOrigenSeaCero()
        {
            IrFocoBusqueda();
            _controlador.EliminarItemsDondeExistenciaEnDepOrigenSeaCero();
            ActualizarImporte();
        }
        private void EliminarItem()
        {
            IrFocoBusqueda();
            _controlador.EliminarItem();
            ActualizarImporte();
        }
        private void EditarItem()
        {
            IrFocoBusqueda();
            _controlador.EditarItem();
            ActualizarImporte();
            DGV_DETALLE.Refresh();
        }
        private void DejarEnPendiente()
        {
            _controlador.DejarEnPendiente();
            if (_controlador.DejarEnPendienteIsOk)
            {
                Limpiar();
                ActualizarImporte();
            }
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
            {
                Limpiar();
                ActualizarImporte();
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


        private void ListaPendientes()
        {
            _controlador.ListaPendienteVisualizar();
            Limpiar();
            ActualizarImporte();
        }
        private void AgregarConcepto()
        {
            IrFocoBusqueda();
            _controlador.AgregarConcepto();
        }
        private void LimpiarDeprtamento()
        {
            IrFocoBusqueda();
            CB_DEPARTAMENTO.SelectedIndex = -1;
        }
        private void Limpiar()
        {
            _modoInicio = true;
            TB_MOTIVO.Text = _controlador.GetEnt_Motivo;
            TB_AUTORIZADO_POR.Text = _controlador.GetEnt_AutorizadoPor;
            DTP_FECHA.Value = _controlador.GetFechaSistema;

            CB_METODO_BUSQ.SelectedValue = _controlador.CompBusqProducto.MetodoBusqueda_GetId;
            TB_CADENA_BUSQ.Text = _controlador.CompBusqProducto.GetCadena;

            CB_CONCEPTO.SelectedValue = _controlador.Concepto.GetId;
            CB_SUC_ORIGEN.SelectedValue = _controlador.SucOrigen.GetId;
            CB_SUC_DESTINO.SelectedValue = _controlador.SucDestino.GetId;
            CB_DEPARTAMENTO.SelectedValue = _controlador.Departamento.GetId;
            CB_CONCEPTO.Enabled = !_controlador.ActivarDepPreDeterminadoParaDevolucion;
            CB_DEPARTAMENTO.Enabled = !_controlador.ActivarDepPreDeterminadoParaDevolucion;
            DGV_DETALLE.Refresh();
            _modoInicio = false;
        }
        private void LimpiarVista()
        {
            IrFocoBusqueda();
            _controlador.LimpiezaGeneral();
            if (_controlador.LImpiezaGenerarIsOk)
            {
                Limpiar();
                ActualizarImporte();
            }
        }
        private void ActualizarImporte()
        {
            L_MONTO.Text = "(Bs) " + _controlador.ListaItems.GetImporte_MonedaLocal.ToString("n2") + "/ ($) " + _controlador.ListaItems.GetImporte_MonedaOtra.ToString("n2");
            L_ITEMS.Text = "Total Items: " + Environment.NewLine + _controlador.ListaItems.GetCtnItems.ToString();
            L_ITEMS_PEND.Text = "DOC PEND ( "+_controlador.Pendiente.CntDoc.ToString("n0") +" )" ;
        }
        private void IrFocoBusqueda()
        {
            TB_CADENA_BUSQ.Focus();
        }
        private void RefrescarBusqueda()
        {
            TB_CADENA_BUSQ.Text = _controlador.CompBusqProducto.GetCadena;
            CB_METODO_BUSQ.SelectedValue = _controlador.CompBusqProducto.MetodoBusqueda_GetId; 
        }
    }
}