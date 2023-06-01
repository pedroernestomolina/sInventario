﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis
{
    public partial class Frm : Form
    {
        private IAnalisis _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializaGrid();
        }
        private void InicializaGrid()
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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 100;
            c1.ReadOnly = true;


            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DescPrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.MinimumWidth = 280;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Diferencia";
            c3.HeaderText = "Diferencia";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.Width = 120;
            c3.ReadOnly = true;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Estado";
            c4.HeaderText = "Estado";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 100;
            c4.ReadOnly = true;

            var c5 = new DataGridViewCheckBoxColumn();
            c5.DataPropertyName = "Eliminar";
            c5.HeaderText = "*";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.Width = 40;
            c5.ReadOnly = false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.GetSource;
            DGV.Refresh();
        }

        public void setControlador(IAnalisis ctr)
        {
            _controlador = ctr;
        }
    }
}