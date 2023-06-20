﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Ajuste.PorToma
{
    public partial class MovFrm : Form
    {
        private IAjuste _controlador;
        
        
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
            c3.DefaultCellStyle.Format = "n1";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "EmpaqueMov";
            c4.HeaderText = "Empaque";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.MinimumWidth = 100;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CostoNeto";
            c5.HeaderText = "Costo Neto";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "ImporteNeto";
            c6.HeaderText = "Importe";
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
            c8.DataPropertyName = "TipoMov";
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


        private void InicializarCombo()
        {
            CB_CONCEPTO.DisplayMember = "desc";
            CB_CONCEPTO.ValueMember = "id";
            CB_SUCURSAL.DisplayMember = "desc";
            CB_SUCURSAL.ValueMember = "id";
            CB_DEP_ORIGEN.DisplayMember = "desc";
            CB_DEP_ORIGEN.ValueMember = "id";
        }

        public void setControlador(IAjuste ctr)
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

            CB_CONCEPTO.DataSource = _controlador.Concepto.GetSource;
            CB_SUCURSAL.DataSource = _controlador.SucOrigen.GetSource;
            CB_DEP_ORIGEN.DataSource = _controlador.DepOrigen.GetSource;
            CB_CONCEPTO.SelectedValue = _controlador.Concepto.GetId;
            CB_SUCURSAL.SelectedValue = _controlador.SucOrigen.GetId;
            CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigen.GetId;
            RefrescarBusqueda();
            _modoInicio = false;
            ActualizarImporte();
            IrFoco();
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
                IrFoco();
            }
        }
        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarVista();
        }
        private void BT_TOMAS_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarTomas();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }


        private void CB_SUCURSAL_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            if (_controlador.ListaItems.GetCtnItems > 0)
            {
                CB_SUCURSAL.SelectedValue = _controlador.SucOrigen.GetId;
                Helpers.Msg.Alerta("SUCURSAL NO PODRA SER CAMBIADA MIENTRAS EXISTAN ITEMS EN LA LISTA");
                return;
            }
            _controlador.SucOrigen.setId("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.SucOrigenSetId(CB_SUCURSAL.SelectedValue.ToString());
                _modoInicio = true;
                CB_DEP_ORIGEN.SelectedIndex = -1;
                _modoInicio = false;
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
        private void CB_DEP_ORIGEN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            if (_controlador.ListaItems.GetCtnItems > 0)
            {
                CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigen.GetId;
                Helpers.Msg.Alerta("DEPOSITO NO PODRA SER CAMBIADO MIENTRAS EXISTAN ITEMS EN LA LISTA");
                return;
            }
            _controlador.DepOrigen.setId("");
            if (CB_DEP_ORIGEN.SelectedIndex != -1)
            {
                _controlador.DepOrigen.setId(CB_DEP_ORIGEN.SelectedValue.ToString());
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


        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            AgregarConcepto();
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


        private void AgregarConcepto()
        {
            IrFoco();
            _controlador.AgregarConcepto();
        }
        private void Limpiar()
        {
            _modoInicio = true;
            TB_MOTIVO.Text = _controlador.GetEnt_Motivo;
            TB_AUTORIZADO_POR.Text = _controlador.GetEnt_AutorizadoPor;
            DTP_FECHA.Value = _controlador.GetFechaSistema;

            CB_CONCEPTO.SelectedValue = _controlador.Concepto.GetId;
            CB_SUCURSAL.SelectedValue = _controlador.SucOrigen.GetId;
            CB_DEP_ORIGEN.SelectedValue = _controlador.DepOrigen.GetId;
            DGV_DETALLE.Refresh();
            _modoInicio = false;
        }
        private void LimpiarVista()
        {
            IrFoco();
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
        }
        private void BuscarTomas()
        {
            _controlador.BuscarTomas();
            ActualizarImporte();
        }
        private void IrFoco()
        {
        }
        private void RefrescarBusqueda()
        {
        }
    }
}