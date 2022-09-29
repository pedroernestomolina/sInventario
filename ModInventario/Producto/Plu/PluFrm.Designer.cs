namespace ModInventario.Producto.Plu
{
    partial class PluFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.L_ITEMS = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 422);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(529, 60);
            this.panel1.TabIndex = 100;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(527, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BT_SALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(422, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(103, 54);
            this.panel2.TabIndex = 1;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Image = global::ModInventario.Properties.Resources.bt_salida_2;
            this.BT_SALIR.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BT_SALIR.Location = new System.Drawing.Point(2, 2);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(99, 50);
            this.BT_SALIR.TabIndex = 0;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(529, 40);
            this.panel3.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista Plu(s)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(1);
            this.panel4.Size = new System.Drawing.Size(529, 382);
            this.panel4.TabIndex = 102;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.364326F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.63567F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.951872F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.04813F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(527, 380);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.DGV);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(23, 27);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2);
            this.panel5.Size = new System.Drawing.Size(476, 342);
            this.panel5.TabIndex = 0;
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(2, 2);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(472, 338);
            this.DGV.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.L_ITEMS);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(23, 2);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2);
            this.panel6.Size = new System.Drawing.Size(476, 23);
            this.panel6.TabIndex = 1;
            // 
            // L_ITEMS
            // 
            this.L_ITEMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_ITEMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ITEMS.Location = new System.Drawing.Point(2, 2);
            this.L_ITEMS.Name = "L_ITEMS";
            this.L_ITEMS.Size = new System.Drawing.Size(472, 19);
            this.L_ITEMS.TabIndex = 0;
            this.L_ITEMS.Text = "label2";
            this.L_ITEMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PluFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_SALIR;
            this.ClientSize = new System.Drawing.Size(529, 482);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "PluFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PluFrm_FormClosing);
            this.Load += new System.EventHandler(this.PluFrm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label L_ITEMS;
    }
}