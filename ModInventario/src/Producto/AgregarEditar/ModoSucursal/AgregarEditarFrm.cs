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


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal
{

    public partial class AgregarEditarFrm : Form
    {


        private IAgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            Inicializar();
            InicializarGridAlterno();
            InicializarGridTallaColorSabor();
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
        private void InicializarGridTallaColorSabor()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV_TALLA_COLOR_SABOR.AllowUserToAddRows = false;
            DGV_TALLA_COLOR_SABOR.AllowUserToDeleteRows = false;
            DGV_TALLA_COLOR_SABOR.AutoGenerateColumns = false;
            DGV_TALLA_COLOR_SABOR.AllowUserToResizeRows = false;
            DGV_TALLA_COLOR_SABOR.AllowUserToResizeColumns = false;
            DGV_TALLA_COLOR_SABOR.AllowUserToOrderColumns = false;
            DGV_TALLA_COLOR_SABOR.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_TALLA_COLOR_SABOR.MultiSelect = false;
            DGV_TALLA_COLOR_SABOR.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Descripcion";
            c1.HeaderText = "Descripción";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV_TALLA_COLOR_SABOR.Columns.Add(c1);
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
            CB_EMPAQUE_INV.DisplayMember = "desc";
            CB_EMPAQUE_INV.ValueMember = "id";
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
            BT_EDITAR_CODIGO.Enabled = true;
            BT_EDITAR_CODIGO.Visible = _controlador.HabilitarEditarCodigo;
            TB_CODIGO.Enabled = !_controlador.HabilitarEditarCodigo;
            DGV.DataSource = _controlador.GetCodAlterno_Source;
            DGV_TALLA_COLOR_SABOR.DataSource = _controlador.GetTallaColorSabor_Source;

            CB_DEPARTAMENTO.DataSource = _controlador.GetDepartamento_Source;
            CB_GRUPO.DataSource = _controlador.GetGrupo_Source;
            CB_MARCA.DataSource = _controlador.GetMarca_Source;
            CB_IMPUESTO.DataSource = _controlador.GetImpuesto_Source;
            CB_ORIGEN.DataSource = _controlador.GetOrigen_Source;
            CB_DIVISA.DataSource = _controlador.GetDivisa_Source;
            CB_CATEGORIA.DataSource = _controlador.GetCategoria_Source;
            CB_CLASIFICACION_ABC.DataSource = _controlador.GetClasificacion_Source;
            CB_EMPAQUE_COMPRA.DataSource = _controlador.GetEmpCompra_Source;
            CB_EMPAQUE_INV.DataSource = _controlador.GetEmpInv_Source;
            CB_EMP_VENTA_TIPO_1.DataSource = _controlador.GetEmpVentaTipo1_Source;
            CB_EMP_VENTA_TIPO_2.DataSource = _controlador.GetEmpVentaTipo2_Source;
            CB_EMP_VENTA_TIPO_3.DataSource = _controlador.GetEmpVentaTipo3_Source;

            CB_DEPARTAMENTO.SelectedValue = _controlador.GetDepartamento_Id;
            CB_GRUPO.SelectedValue = _controlador.GetGrupo_Id;
            CB_MARCA.SelectedValue = _controlador.GetMarca_Id;
            CB_IMPUESTO.SelectedValue = _controlador.GetImpuesto_Id;
            CB_ORIGEN.SelectedValue = _controlador.GetOrigen_Id;
            CB_CATEGORIA.SelectedValue = _controlador.GetCategoria_Id;
            CB_CLASIFICACION_ABC.SelectedValue = _controlador.GetClasificacion_Id;
            CB_DIVISA.SelectedValue = _controlador.GetDivisa_id;
            CB_EMPAQUE_COMPRA.SelectedValue = _controlador.GetEmpCompra_Id;
            CB_EMPAQUE_INV.SelectedValue = _controlador.GetEmpInv_Id;
            CB_EMP_VENTA_TIPO_1.SelectedValue = _controlador.GetEmpVentaTipo1_ID;
            CB_EMP_VENTA_TIPO_2.SelectedValue = _controlador.GetEmpVentaTipo2_ID;
            CB_EMP_VENTA_TIPO_3.SelectedValue = _controlador.GetEmpVentaTipo3_ID;

            TB_CODIGO.Text = _controlador.GetCodigoProducto;
            TB_DESCRIPCION.Text = _controlador.GetDescripcionProducto;
            TB_NOMBRE.Text = _controlador.GetNombreProducto;
            TB_MODELO.Text = _controlador.GetModeloProducto;
            TB_REFERENCIA.Text = _controlador.GetReferenciaProducto;
            TB_CONTENIDO.Text = _controlador.GetContEmpCompra.ToString();
            TB_CONTENIDO_INV.Text = _controlador.GetContEmpInv.ToString();
            TB_CONT_EMP_VENTA_TIPO_1.Text = _controlador.GetContEmpVentaTipo1.ToString();
            TB_CONT_EMP_VENTA_TIPO_2.Text = _controlador.GetContEmpVentaTipo2.ToString();
            TB_CONT_EMP_VENTA_TIPO_3.Text = _controlador.GetContEmpVentaTipo3.ToString();
            TB_PESO.Text = _controlador.GetPeso.ToString();
            TB_VOLUMEN.Text = _controlador.GetVolumen.ToString();
            TB_LARGO.Text = _controlador.GetLargo.ToString();
            TB_ANCHO.Text = _controlador.GetAncho.ToString();
            TB_ALTO.Text = _controlador.GetAlto.ToString();
            TB_PLU.Text = _controlador.GetPlu;
            TB_DIAS_EMPAQUE.Text = _controlador.GetDiasEmpaque.ToString();

            CHB_CATALOGO.Checked = _controlador.GetActivarCatlogo;
            CHB_PESADO.Checked = _controlador.GetEsPesado;
            TB_PLU.Enabled = CHB_PESADO.Checked;
            TB_DIAS_EMPAQUE.Enabled = CHB_PESADO.Checked;
            PB_IMAGEN.Image = PB_IMAGEN.InitialImage;
            if (_controlador.GetImagen.Length>0)
            {
                using (var ms = new MemoryStream(_controlador.GetImagen))
                {
                    PB_IMAGEN.Image = Image.FromStream(ms);
                }
            }

            TB_TALLA_COLOR_SABOR.Text = _controlador.GetTallaColorSabor_Desc;
            ActualizarTallaColorSabor();
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
        private void TB_MODELO_Leave(object sender, EventArgs e)
        {
            TB_MODELO.Text = TB_MODELO.Text.Trim().ToUpper();
            _controlador.setModeloProducto(TB_MODELO.Text);
        }
        private void TB_REFERENCIA_Leave(object sender, EventArgs e)
        {
            TB_REFERENCIA.Text = TB_REFERENCIA.Text.Trim().ToUpper();
            _controlador.setReferenciaProducto(TB_REFERENCIA.Text);
        }
        private void TB_CONTENIDO_Leave(object sender, EventArgs e)
        {
            _controlador.setContEmpCompra(int.Parse(TB_CONTENIDO.Text));
        }
        private void TB_CONTENIDO_INV_Leave(object sender, EventArgs e)
        {
            _controlador.setContEmpInv(int.Parse(TB_CONTENIDO_INV.Text));
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
        private void TB_PESO_Leave(object sender, EventArgs e)
        {
            var _peso = decimal.Parse(TB_PESO.Text);
            _controlador.setPeso(_peso);
        }
        private void TB_VOLUMEN_Leave(object sender, EventArgs e)
        {
            var _volumen = decimal.Parse(TB_VOLUMEN.Text);
            _controlador.setVolumen(_volumen);
        }
        private void TB_ALTO_Leave(object sender, EventArgs e)
        {
            var _alto = decimal.Parse(TB_ALTO.Text);
            _controlador.setAlto(_alto);
        }
        private void TB_LARGO_Leave(object sender, EventArgs e)
        {
            var _largo = decimal.Parse(TB_LARGO.Text);
            _controlador.setLargo(_largo);
        }
        private void TB_ANCHO_Leave(object sender, EventArgs e)
        {
            var _ancho = decimal.Parse(TB_ANCHO.Text);
            _controlador.setAncho(_ancho);
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
        private void CB_EMPAQUE_INV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.setEmpInv("");
            if (CB_EMPAQUE_INV.SelectedIndex != -1)
            {
                _controlador.setEmpInv(CB_EMPAQUE_INV.SelectedValue.ToString());
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
        private void CHB_CATALOGO_CheckedChanged(object sender, EventArgs e)
        {
            if (!inicializarData)
            {
                _controlador.setActivarCatlogo(CHB_CATALOGO.Checked);
            }
        }


        private void TB_CONTENIDO_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = int.Parse(TB_CONTENIDO.Text) <= 0;
        }
        private void TB_CONTENIDO_INV_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = int.Parse(TB_CONTENIDO_INV.Text) <= 0;
        }


        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            MaestroDepartamento();
        }
        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            MaestrGrupo();
        }
        private void L_MARCA_Click(object sender, EventArgs e)
        {
            MaestroMarca();
        }


        private void MaestroDepartamento()
        {
            _controlador.AgregarDepartamento();
            if (_controlador.AgregarDepartamentoIsOK)
            {
                CB_DEPARTAMENTO.Refresh();
                CB_DEPARTAMENTO.SelectedIndex = -1;
            }
        }
        private void MaestrGrupo()
        {
            _controlador.AgregarGrupo();
            if (_controlador.AgregarGrupoIsOk)
            {
                CB_GRUPO.Refresh();
                CB_GRUPO.SelectedIndex = -1;
            }
        }
        private void MaestroMarca()
        {
            _controlador.AgregarMarca();
            if (_controlador.AgregarMarcaIsOk)
            {
                CB_MARCA.Refresh();
                CB_MARCA.SelectedIndex = -1;
            }
        }


        private void BT_ABRIR_Click(object sender, EventArgs e)
        {
            BuscarImagen();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarImagen();
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
        private void BT_EDITAR_CODIGO_Click(object sender, EventArgs e)
        {
            EditarCodigo();
        }


        private void EditarCodigo()
        {
            _controlador.EditarCodigo();
            if (_controlador.EditarCodigoIsOk)
            {
                TB_CODIGO.Enabled = true;
                BT_EDITAR_CODIGO.Enabled = false;
            }
        }
        private void BuscarImagen()
        {
            _controlador.BuscarImagen();
            if (_controlador.BuscarImagenIsOk)
            {
                using (var ms = new MemoryStream(_controlador.GetImagen))
                {
                    PB_IMAGEN.Image = Image.FromStream(ms);
                }
            }
            else 
            {
                LimpiarImagen();
            }
        }
        private void LimpiarImagen()
        {
            PB_IMAGEN.Image = PB_IMAGEN.InitialImage;
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
        private void Salir()
        {
            TB_CODIGO.Focus();
            this.Close();
        }


        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }


        //
        private void TB_TALLA_COLOR_SABOR_Leave(object sender, EventArgs e)
        {
            _controlador.setTallaColorSabor(TB_TALLA_COLOR_SABOR.Text.Trim().ToUpper());
        }

        private void BT_AGREGAR_TALLA_COLOR_SABOR_Click(object sender, EventArgs e)
        {
            AgregarTallaColorSabor();
            ActualizarTallaColorSabor();
        }
        private void BT_ELIMINAR_TALLA_COLOR_SABOR_Click(object sender, EventArgs e)
        {
            ElminarTallaColorSabor();
            ActualizarTallaColorSabor();
        }
        private void BT_REFRESH_Click(object sender, EventArgs e)
        {
            RefreshTallaColorSabor();
            ActualizarTallaColorSabor();
        }

        private void ActualizarTallaColorSabor()
        {
            L_ITEMS_TALLA_COLOR_SABOR.Text = "Cant Items: "+_controlador.GetTallaColorSabor_CntItems.ToString();
        }

        private void AgregarTallaColorSabor()
        {
            _controlador.AgregarTallaColorSabor();
            TB_TALLA_COLOR_SABOR.Text = _controlador.GetTallaColorSabor_Desc;
        }
        private void ElminarTallaColorSabor()
        {
            _controlador.EliminarTallaColorSabor();
        }
        private void RefreshTallaColorSabor()
        {
            _controlador.RefrescaTallaColorSabor();
        }
    }
}