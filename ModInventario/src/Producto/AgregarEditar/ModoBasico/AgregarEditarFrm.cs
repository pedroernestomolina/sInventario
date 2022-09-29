using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.AgregarEditar.ModoBasico
{

    public partial class AgregarEditarFrm : Form
    {


        private IAgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            Inicializar();
            InicializarGridAlterno();
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

        private void Inicializar()
        {
            CB_DEPARTAMENTO.DisplayMember = "desc";
            CB_DEPARTAMENTO.ValueMember = "id";
            CB_GRUPO.DisplayMember = "desc";
            CB_GRUPO.ValueMember = "id";
            CB_MARCA.DisplayMember = "desc";
            CB_MARCA.ValueMember = "id";
            CB_IMPUESTO.DisplayMember = "desc";
            CB_IMPUESTO.ValueMember = "id";
            CB_ORIGEN.DisplayMember = "desc";
            CB_ORIGEN.ValueMember = "id";
            CB_DIVISA.DisplayMember = "desc";
            CB_DIVISA.ValueMember = "id";
            CB_CATEGORIA.DisplayMember = "desc";
            CB_CATEGORIA.ValueMember = "id";
            CB_CLASIFICACION_ABC.DisplayMember = "desc";
            CB_CLASIFICACION_ABC.ValueMember = "id";
            CB_EMPAQUE_COMPRA.DisplayMember = "desc";
            CB_EMPAQUE_COMPRA.ValueMember = "id";
            CB_EMP_VENTA_TIPO_1.DisplayMember = "desc";
            CB_EMP_VENTA_TIPO_1.ValueMember = "id";
            CB_EMP_VENTA_TIPO_2.DisplayMember = "desc";
            CB_EMP_VENTA_TIPO_2.ValueMember = "id";
            CB_EMP_VENTA_TIPO_3.DisplayMember = "desc";
            CB_EMP_VENTA_TIPO_3.ValueMember = "id";
        }


        public void setControlador(IAgregarEditar ctr)
        {
            _controlador = ctr;
        }


        bool inicializarData = false;
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            TB_CODIGO.Focus();

            inicializarData = true;
            L_TITULO.Text = _controlador.GetTitulo;
            DGV.DataSource = _controlador.GetCodAlterno_Source;
            CB_DEPARTAMENTO.DataSource = _controlador.GetDepartamento_Source;
            CB_GRUPO.DataSource = _controlador.GetGrupo_Source;
            CB_MARCA.DataSource = _controlador.GetMarca_Source;
            CB_IMPUESTO.DataSource = _controlador.GetImpuesto_Source;
            CB_ORIGEN.DataSource = _controlador.GetOrigen_Source;
            CB_DIVISA.DataSource = _controlador.GetDivisa_Source;
            CB_CATEGORIA.DataSource = _controlador.GetCategoria_Source;
            CB_CLASIFICACION_ABC.DataSource = _controlador.GetClasificacion_Source;

            CB_DEPARTAMENTO.SelectedValue = _controlador.GetDepartamento_Id;
            CB_GRUPO.SelectedValue = _controlador.GetGrupo_Id;
            CB_MARCA.SelectedValue = _controlador.GetMarca_Id;
            CB_IMPUESTO.SelectedValue = _controlador.GetImpuesto_Id;
            CB_ORIGEN.SelectedValue = _controlador.GetOrigen_Id;
            CB_CATEGORIA.SelectedValue = _controlador.GetCategoria_Id;
            CB_CLASIFICACION_ABC.SelectedValue = _controlador.GetClasificacion_Id;
            CB_DIVISA.SelectedValue = _controlador.GetDivisa_id;

            CB_EMPAQUE_COMPRA.DataSource = _controlador.GetEmpCompra_Source;
            CB_EMPAQUE_COMPRA.SelectedValue = _controlador.GetEmpCompra_Id;

            CB_EMP_VENTA_TIPO_1.DataSource = _controlador.GetEmpVentaTipo1_Source;
            CB_EMP_VENTA_TIPO_2.DataSource = _controlador.GetEmpVentaTipo2_Source;
            CB_EMP_VENTA_TIPO_3.DataSource = _controlador.GetEmpVentaTipo3_Source;
            CB_EMP_VENTA_TIPO_1.SelectedValue = _controlador.GetEmpVentaTipo1_ID;
            CB_EMP_VENTA_TIPO_2.SelectedValue = _controlador.GetEmpVentaTipo2_ID;
            CB_EMP_VENTA_TIPO_3.SelectedValue = _controlador.GetEmpVentaTipo3_ID;

            TB_CODIGO.Text = _controlador.GetCodigoProducto;
            TB_DESCRIPCION.Text = _controlador.GetDescripcionProducto;
            TB_NOMBRE.Text = _controlador.GetNombreProducto;
            TB_CONTENIDO.Text = _controlador.GetContEmpCompra.ToString();
            TB_CONT_EMP_VENTA_TIPO_1.Text = _controlador.GetContEmpVentaTipo1.ToString();
            TB_CONT_EMP_VENTA_TIPO_2.Text = _controlador.GetContEmpVentaTipo2.ToString();
            TB_CONT_EMP_VENTA_TIPO_3.Text = _controlador.GetContEmpVentaTipo3.ToString();
            TB_PLU.Text = _controlador.GetPlu;
            TB_DIAS_EMPAQUE.Text = _controlador.GetDiasEmpaque.ToString();
            TB_PLU.Enabled = _controlador.GetEsPesado;
            TB_DIAS_EMPAQUE.Enabled = _controlador.GetEsPesado; 
            CHB_PESADO.Checked = _controlador.GetEsPesado;

            inicializarData = false;
        }


        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            TB_CODIGO.Text = TB_CODIGO.Text.Trim().ToUpper();
            _controlador.setCodigoProducto(TB_CODIGO.Text);
        }
        private void TB_DESCRIPCION_Leave(object sender, EventArgs e)
        {
            TB_DESCRIPCION.Text = TB_DESCRIPCION.Text.Trim().ToUpper();
            _controlador.setDescripcionProducto(TB_DESCRIPCION.Text);
        }
        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            TB_NOMBRE.Text = TB_NOMBRE.Text.Trim().ToUpper();
            _controlador.setNombreProducto(TB_NOMBRE.Text);
        }
        private void TB_CONTENIDO_Leave(object sender, EventArgs e)
        {
            _controlador.setContEmpCompra(int.Parse(TB_CONTENIDO.Text));
        }
        private void TB_PLU_Leave(object sender, EventArgs e)
        {
            TB_PLU.Text = TB_PLU.Text.Trim().ToUpper();
            _controlador.setPlu(TB_PLU.Text);
        }
        private void TB_DIAS_EMPAQUE_Leave(object sender, EventArgs e)
        {
            _controlador.setDiasEmpaque(int.Parse(TB_DIAS_EMPAQUE.Text));
        }
        private void TB_CONT_EMP_VENTA_TIPO_1_Leave(object sender, EventArgs e)
        {
            _controlador.setContEmpVentaTipo1(int.Parse(TB_CONT_EMP_VENTA_TIPO_1.Text));
        }
        private void TB_CONT_EMP_VENTA_TIPO_2_Leave(object sender, EventArgs e)
        {
            _controlador.setContEmpVentaTipo2(int.Parse(TB_CONT_EMP_VENTA_TIPO_2.Text));
        }
        private void TB_CONT_EMP_VENTA_TIPO_3_Leave(object sender, EventArgs e)
        {
            _controlador.setContEmpVentaTipo3(int.Parse(TB_CONT_EMP_VENTA_TIPO_3.Text));
        }
        private void TB_ALTERNO_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigoAlterno(TB_ALTERNO.Text.Trim());
        }


        private void TB_CONTENIDO_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = int.Parse(TB_CONTENIDO.Text) <= 0;
        }


        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setDepartamento("");
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.setDepartamento(CB_DEPARTAMENTO.SelectedValue.ToString());
            }
        }
        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setMarca("");
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.setMarca(CB_MARCA.SelectedValue.ToString());
            }
        }
        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setImpuesto("");
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.setImpuesto(CB_IMPUESTO.SelectedValue.ToString());
            }
        }
        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setOrigen("");
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.setOrigen(CB_ORIGEN.SelectedValue.ToString());
            }
        }
        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setCategoria("");
            if (CB_CATEGORIA.SelectedIndex != -1)
            {
                _controlador.setCategoria(CB_CATEGORIA.SelectedValue.ToString());
            }
        }
        private void CB_CLASIFICACION_ABC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setClasificacion("");
            if (CB_CLASIFICACION_ABC.SelectedIndex != -1)
            {
                _controlador.setClasificacion(CB_CLASIFICACION_ABC.SelectedValue.ToString());
            }
        }
        private void CB_DIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setDivisa("");
            if (CB_DIVISA.SelectedIndex != -1)
            {
                _controlador.setDivisa(CB_DIVISA.SelectedValue.ToString());
            }
        }
        private void CB_EMPAQUE_COMPRA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setEmpCompra("");
            if (CB_EMPAQUE_COMPRA.SelectedIndex != -1)
            {
                _controlador.setEmpCompra(CB_EMPAQUE_COMPRA.SelectedValue.ToString());
            }
        }
        private void CB_EMP_VENTA_TIPO_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setEmpVentaTipo1("");
            if (CB_EMP_VENTA_TIPO_1.SelectedIndex != -1)
            {
                _controlador.setEmpVentaTipo1(CB_EMP_VENTA_TIPO_1.SelectedValue.ToString());
            }
        }
        private void CB_EMP_VENTA_TIPO_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setEmpVentaTipo2("");
            if (CB_EMP_VENTA_TIPO_2.SelectedIndex != -1)
            {
                _controlador.setEmpVentaTipo2(CB_EMP_VENTA_TIPO_2.SelectedValue.ToString());
            }
        }
        private void CB_EMP_VENTA_TIPO_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setEmpVentaTipo3("");
            if (CB_EMP_VENTA_TIPO_3.SelectedIndex != -1)
            {
                _controlador.setEmpVentaTipo3(CB_EMP_VENTA_TIPO_3.SelectedValue.ToString());
            }
        }


        private void CHB_PESADO_CheckedChanged(object sender, EventArgs e)
        {
            if (!inicializarData)
            {
                _controlador.setPesado(CHB_PESADO.Checked);
                TB_PLU.Enabled = CHB_PESADO.Checked;
                TB_DIAS_EMPAQUE.Enabled = CHB_PESADO.Checked;
            }
        }


        private void BT_LISTA_PLU_Click(object sender, EventArgs e)
        {
            ListaPlu();
        }
        private void BT_AGREGAR_COD_ALTERNO_Click(object sender, EventArgs e)
        {
            AgregarCodigoAlterno();
        }
        private void BT_ELIMINAR_COD_ALTERNO_Click(object sender, EventArgs e)
        {
            EliminarCodigoAlterno();
        }


        private void ListaPlu()
        {
            _controlador.ListaPlu();
        }
        private void AgregarCodigoAlterno()
        {
            _controlador.AgregarCodigoAlterno();
            TB_ALTERNO.Text = "";
            TB_ALTERNO.Focus();
        }
        private void EliminarCodigoAlterno()
        {
            _controlador.EliminarCodigoAlterno();
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            TB_CODIGO.Focus();
            this.Close();
        }

        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }
        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }

}