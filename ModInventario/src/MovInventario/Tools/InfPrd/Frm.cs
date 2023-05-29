﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.InfPrd
{
    public partial class Frm : Form
    {
        private IPrdInf _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializarGrid();
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
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "STipoDoc";
            c2.HeaderText = "Tipo";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DepOrigen";
            c3.HeaderText = "Origen";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.MinimumWidth = 120;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "DepDestino";
            c4.HeaderText = "Destino";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.MinimumWidth = 120;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "SRenglones";
            c5.HeaderText = "Reng";
            c5.Visible = true;
            c5.Width = 40;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5A = new DataGridViewTextBoxColumn();
            c5A.DataPropertyName = "SMonto";
            c5A.HeaderText = "Monto ($)";
            c5A.Visible = true;
            c5A.Width = 90;
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
            c5B.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5A);
            DGV.Columns.Add(c5B);
        }


        public void setControlador(IPrdInf ctr)
        {
            _controlador = ctr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            L_ET_INV_EMP_COMPRA.Text = _controlador.GetInvEmpCompra;
            L_ET_INV_EMP_INV.Text = _controlador.GetInvEmpInv;
            L_ET_INV_EMP_UND.Text = _controlador.GetInvEmpUnd;
            L_INV_EMP_COMPRA.Text = _controlador.GetEx_InvEmpCompra.ToString();
            L_INV_EMP_INV.Text = _controlador.GetEx_InvEmpInv.ToString();
            L_INV_EMP_UND.Text = _controlador.GetEx_InvEmpUnd.ToString();
            //
            DGV.DataSource = _controlador.GetSource;
            DGV.Refresh();
        }
    }
}