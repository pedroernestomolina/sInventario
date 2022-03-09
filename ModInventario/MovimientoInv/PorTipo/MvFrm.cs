using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInv.PorTipo
{

    public partial class MvFrm : Form
    {


        GestionMov _controlador;


        public MvFrm()
        {
            InitializeComponent();
            InicializarGrid();
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
            c3.DataPropertyName = "Cnt";
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
            c8.DataPropertyName = "TipoMovimientoDescripcion";
            c8.Name = "TipoMov";
            c8.HeaderText = "Mov";
            c8.Visible = true;
            c8.Width = 60;
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

        public void setControlador(GestionMov ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private bool _modoInicio;
        private void MvFrm_Load(object sender, EventArgs e)
        {
            //Inicializar();

            //_modoInicio = true;
            //CB_CONCEPTO.DataSource = _controlador.ConceptoSource;
            //CB_SUCURSAL.DataSource = _controlador.SucursalSource;
            //CB_DEP_ORIGEN.DataSource = _controlador.DepOrigenSource;
            //CB_DEP_DESTINO.DataSource = _controlador.DepDestinoSource;
            //Limpiar();
            //_modoInicio = false;

            //switch (_controlador.EnumTipoMovimiento)
            //{
            //    case enumerados.enumTipoMovimiento.Cargo:
            //        P_TIPO_MOVIMIENTO.BackColor = Color.Green;
            //        break;
            //    case enumerados.enumTipoMovimiento.Descargo:
            //        P_TIPO_MOVIMIENTO.BackColor = Color.Red;
            //        break;
            //    case enumerados.enumTipoMovimiento.Traslado:
            //    case enumerados.enumTipoMovimiento.Ajuste:
            //        P_TIPO_MOVIMIENTO.BackColor = Color.Orange;
            //        break;
            //}

            //DTP_FECHA.Focus();
            //L_TIPO_MOVIMIENTO.Text = _controlador.TipoMovimiento;
            //L_MONTO.Text = _controlador.MontoMovimiento.ToString("n2");
            //L_ITEMS.Text = _controlador.ItemsMovimiento;
            //CB_DEP_DESTINO.Enabled = _controlador.Habilitar_DepDestino;

            //DGV_DETALLE.Columns["TipoMov"].Visible = _controlador.VisualizarColumnaTipoMovimiento;
            //DGV_DETALLE.DataSource = _controlador.DetalleSource;
            //DGV_DETALLE.Refresh();

            //CB_CONCEPTO.Enabled = _controlador.HabilitarConcepto;
            //L_CONCEPTO.Enabled = _controlador.HabilitarConcepto;
        }

        private void Inicializar()
        {
            CB_CONCEPTO.DisplayMember = "Nombre";
            CB_CONCEPTO.ValueMember = "Auto";

            CB_SUCURSAL.DisplayMember = "Nombre";
            CB_SUCURSAL.ValueMember = "Auto";

            CB_DEP_ORIGEN.DisplayMember = "Nombre";
            CB_DEP_ORIGEN.ValueMember = "Auto";

            CB_DEP_DESTINO.DisplayMember = "Nombre";
            CB_DEP_DESTINO.ValueMember = "Auto";
        }

        private void Limpiar()
        {
            //L_TIPO_MOVIMIENTO.Text = _controlador.TipoMovimiento;
            //L_MONTO.Text = _controlador.MontoMovimiento.ToString("n2");
            //L_ITEMS.Text = _controlador.ItemsMovimiento;

            //CB_CONCEPTO.SelectedIndex =-1;
            //CB_SUCURSAL.SelectedIndex=-1;
            //CB_DEP_ORIGEN.SelectedIndex=-1;
            //CB_DEP_DESTINO.SelectedIndex=-1;

            //TB_MOTIVO.Text = "";
            //TB_AUTORIZADO_POR.Text = "";
            //DTP_FECHA.Value = DateTime.Now.Date;
            //TB_CADENA_BUSQ.Text = "";
            //switch (_controlador.MetodoBusqueda)
            //{
            //    case Gestion.enumMetBusq.PorCodgo:
            //        RB_BUSCAR_POR_CODIGO.Checked = true;
            //        break;
            //    case Gestion.enumMetBusq.PorNombre:
            //        RB_BUSCAR_POR_NOMBRE.Checked = true;
            //        break;
            //    case Gestion.enumMetBusq.PorReferencia:
            //        RB_BUSCAR_POR_REFERENCIA.Checked = true;
            //        break;
            //}
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarVista();
        }

        private void LimpiarVista()
        {
            //if (_controlador.LimpiarVistaIsOk())
            //{
            //    DGV_DETALLE.DataSource = null;
            //    DGV_DETALLE.Rows.Clear();
            //    Limpiar();
            //    DGV_DETALLE.DataSource = _controlador.DetalleSource;
            //    TB_AUTORIZADO_POR.Focus();
            //}
            //else 
            //    TB_CADENA_BUSQ.Focus();
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_modoInicio)
            //    return;

            //if (_controlador.HabilitarCambioSucursal)
            //{
            //    _controlador.setSucursal("");
            //    if (CB_SUCURSAL.SelectedIndex != -1)
            //    {
            //        _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
            //        _modoInicio = true;
            //        CB_DEP_ORIGEN.SelectedIndex = -1;
            //        _modoInicio = false;
            //    }
            //}
            //else 
            //{
            //    _modoInicio = true;
            //    CB_SUCURSAL.SelectedValue = _controlador.GetIdSucursal;
            //    _modoInicio = false;
            //}
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
            //if (_modoInicio)
            //    return;

            //if (_controlador.HabilitarCambioDepositoOrigen)
            //{
            //    _controlador.setDepositoOrigen("");
            //    if (CB_DEP_ORIGEN.SelectedIndex != -1)
            //    {
            //        _controlador.setDepositoOrigen(CB_DEP_ORIGEN.SelectedValue.ToString());
            //    }
            //}
            //else 
            //{
            //    _modoInicio = true;
            //    CB_DEP_ORIGEN.SelectedValue = _controlador.GetIdDepositoOrigen;
            //    _modoInicio = false;
            //}
        }

        private void CB_DEP_DESTINO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_modoInicio)
            //    return;

            //if (_controlador.HabilitarCambioDepositoDestino)
            //{
            //    _controlador.setDepositoDestino("");
            //    if (CB_DEP_DESTINO.SelectedIndex != -1)
            //    {
            //        _controlador.setDepositoDestino(CB_DEP_DESTINO.SelectedValue.ToString());
            //    }
            //}
            //else 
            //{
            //    _modoInicio = true;
            //    CB_DEP_DESTINO.SelectedValue = _controlador.GetIdDepositoDestino;
            //    _modoInicio = false;
            //}
        }

        private void TB_AUTORIZADO_POR_Leave(object sender, EventArgs e)
        {
            //_controlador.AutorizadoPor = TB_AUTORIZADO_POR.Text.Trim().ToUpper();
            //TB_AUTORIZADO_POR.Text = _controlador.AutorizadoPor;
        }

        private void TB_MOTIVO_Leave(object sender, EventArgs e)
        {
            //_controlador.Motivo = TB_MOTIVO.Text.Trim().ToUpper();
            //TB_MOTIVO.Text = _controlador.Motivo;
        }

        private void DTP_FECHA_Leave(object sender, EventArgs e)
        {
            //_controlador.FechaMov = DTP_FECHA.Value ;
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_BUSCAR_PRODUCTO_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void ActualizarData()
        {
            //L_MONTO.Text = _controlador.MontoMovimiento.ToString("n2");
            //L_ITEMS.Text = _controlador.ItemsMovimiento;
        }

        private void BuscarProducto()
        {
            //_controlador.BuscarProducto();
            //TB_CADENA_BUSQ.Text = "";
            //TB_CADENA_BUSQ.Focus();
            //ActualizarData();
            //ActivarFocoBusqueda();
        }

        private void ActivarFocoBusqueda()
        {
            TB_CADENA_BUSQ.Focus();
        }

        private void RB_BUSCAR_POR_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            //_controlador.setMetBusqByCodigo();
            ////_controlador.MetodoBusqueda= OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Codigo;
            //ActivarFocoBusqueda();
        }

        private void RB_BUSCAR_POR_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            //_controlador.setMetBusqByNombre();
            ////_controlador.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Nombre;
            //ActivarFocoBusqueda();
        }

        private void RB_BUSCAR_POR_REFERENCIA_CheckedChanged(object sender, EventArgs e)
        {
            //_controlador.setMetBusqByReferencia();
            ////_controlador.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Referencia;
            //ActivarFocoBusqueda();
        }

        private void TB_CADENA_BUSQ_Leave(object sender, EventArgs e)
        {
            ////_controlador.CadenaBusqueda = TB_CADENA_BUSQ.Text;
            //_controlador.setCadenaBuscar(TB_CADENA_BUSQ.Text.Trim().ToUpper());
        }

        private void BT_ELIMINAR_ITEM_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            //_controlador.EliminarItem();
            //ActualizarData();
            //ActivarFocoBusqueda();
        }

        private void BT_EDITAR_ITEM_Click(object sender, EventArgs e)
        {
            EditarItem();
        }

        private void EditarItem()
        {
            //_controlador.EditarItem();
            //ActualizarData();
            //ActivarFocoBusqueda();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            //_controlador.Procesar();
            //if (_controlador.IsCerrarOk) 
            //{
            //    _controlador.Limpiar();

            //    DGV_DETALLE.DataSource = null;
            //    DGV_DETALLE.Rows.Clear();
            //    Limpiar();
            //    DGV_DETALLE.DataSource = _controlador.DetalleSource;
            //    TB_AUTORIZADO_POR.Focus();

            //    //Salir();
            //}
        }

        private void MvFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!_controlador.ProcesarIsOk) 
            //{
            //    if (!_controlador.AbandonarDocumento()) 
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            //_controlador.Filtrar();
        }

        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            MaestroConcepto();
        }

        private void MaestroConcepto()
        {
            //_controlador.MaestroConcepto();
        }

        private void BT_PENDIENTE_Click(object sender, EventArgs e)
        {

        }

    }

}