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


namespace ModInventario.Producto.AgregarEditar
{

    public partial class AgregarEditarFrm : Form
    {


        private Gestion _controlador;


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
            CB_DEPARTAMENTO.DisplayMember = "Nombre";
            CB_DEPARTAMENTO.ValueMember = "auto";

            CB_GRUPO.DisplayMember = "Nombre";
            CB_GRUPO.ValueMember = "auto";

            CB_MARCA.DisplayMember = "Nombre";
            CB_MARCA.ValueMember = "auto";

            CB_IMPUESTO.DisplayMember = "TasaImpuesto";
            CB_IMPUESTO.ValueMember = "auto";

            CB_ORIGEN.DisplayMember = "Descripcion";
            CB_ORIGEN.ValueMember = "id";

            CB_DIVISA.DisplayMember = "Descripcion";
            CB_DIVISA.ValueMember = "id";

            CB_CATEGORIA.DisplayMember = "Descripcion";
            CB_CATEGORIA.ValueMember = "id";

            CB_CLASIFICACION_ABC.DisplayMember = "Descripcion";
            CB_CLASIFICACION_ABC.ValueMember = "id";

            //
            CB_EMPAQUE_COMPRA.DisplayMember = "desc";
            CB_EMPAQUE_COMPRA.ValueMember = "id";
            CB_EMPAQUE_INV.DisplayMember = "desc";
            CB_EMPAQUE_INV.ValueMember = "id";
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }


        bool inicializarData = false;
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            TB_CODIGO.Focus();

            inicializarData = true;

            //
            BT_EDITAR_CODIGO.Visible = !_controlador.HabilitarEditarCodigo;
            TB_CODIGO.Enabled = _controlador.HabilitarEditarCodigo;
            //

            DGV.DataSource = _controlador.SourceCodAlterno;
            L_TITULO.Text = _controlador.Titulo;
            CB_DEPARTAMENTO.DataSource = _controlador.Departamentos;
            CB_GRUPO.DataSource = _controlador.Grupos;
            CB_MARCA.DataSource = _controlador.Marcas;
            CB_IMPUESTO.DataSource = _controlador.Impuesto;
            CB_ORIGEN.DataSource = _controlador.Origen;
            CB_DIVISA.DataSource = _controlador.Divisa;
            CB_CATEGORIA.DataSource = _controlador.Categoria;
            CB_CLASIFICACION_ABC.DataSource = _controlador.Clasificacion;

            TB_CODIGO.Text = _controlador.CodigoProducto;
            TB_DESCRIPCION.Text = _controlador.DescripcionProducto;
            TB_NOMBRE.Text = _controlador.NombreProducto;
            TB_MODELO.Text = _controlador.ModeloProducto;
            TB_REFERENCIA.Text = _controlador.ReferenciaProducto;

            CB_DEPARTAMENTO.SelectedValue = _controlador.AutoDepartamento;
            CB_GRUPO.SelectedValue = _controlador.AutoGrupo;
            CB_MARCA.SelectedValue = _controlador.AutoMarca;
            CB_IMPUESTO.SelectedValue = _controlador.AutoImpuesto;
            CB_ORIGEN.SelectedValue = _controlador.IdOrigen;
            CB_CATEGORIA.SelectedValue = _controlador.IdCategoria;
            CB_CLASIFICACION_ABC.SelectedValue = _controlador.IdClasificacionAbc;
            CB_DIVISA.SelectedValue = _controlador.IdDivisa;

            //
            CB_EMPAQUE_COMPRA.DataSource = _controlador.GetEmpCompraSource;
            CB_EMPAQUE_INV.DataSource = _controlador.GetEmpInvSource;
            CB_EMPAQUE_COMPRA.SelectedValue = _controlador.GetEmpCompraId;
            CB_EMPAQUE_INV.SelectedValue = _controlador.GetEmpInvId;
            TB_CONTENIDO.Text = _controlador.GetContEmpCompra.ToString();
            TB_CONTENIDO_INV.Text = _controlador.GetContEmpInv.ToString();
            //


            PB_IMAGEN.Image = PB_IMAGEN.InitialImage;
            if (_controlador.Imagen.Length > 0) 
            {
                using (var ms = new MemoryStream(_controlador.Imagen))
                {
                    PB_IMAGEN.Image = Image.FromStream(ms);
                }
            }

            CHB_CATALOGO.Checked=_controlador.ActivarCatlogo;
            CHB_PESADO.Checked = _controlador.Pesado;
            TB_PLU.Enabled = CHB_PESADO.Checked;
            TB_DIAS_EMPAQUE.Enabled = CHB_PESADO.Checked;
            TB_PLU.Text = _controlador.Plu;
            TB_DIAS_EMPAQUE.Text = _controlador.DiasEmpaque.ToString();

            //
            TB_PESO.Text = _controlador.GetPeso.ToString();
            TB_VOLUMEN.Text = _controlador.GetVolumen.ToString();
            //
            TB_LARGO.Text = _controlador.GetLargo.ToString();
            TB_ANCHO.Text = _controlador.GetAncho.ToString();
            TB_ALTO.Text = _controlador.GetAlto.ToString();

            inicializarData = false;
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

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            TB_CODIGO.Text = TB_CODIGO.Text.Trim().ToUpper();
            _controlador.CodigoProducto = TB_CODIGO.Text;
        }

        private void TB_DESCRIPCION_Leave(object sender, EventArgs e)
        {
            TB_DESCRIPCION.Text = TB_DESCRIPCION.Text.Trim().ToUpper();
            _controlador.DescripcionProducto = TB_DESCRIPCION.Text;
        }

        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            TB_NOMBRE.Text = TB_NOMBRE.Text.Trim().ToUpper();
            _controlador.NombreProducto = TB_NOMBRE.Text;
        }

        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.AutoDepartamento = "";
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.AutoDepartamento = CB_DEPARTAMENTO.SelectedValue.ToString();
            }
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.AutoGrupo = "";
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.AutoGrupo = CB_GRUPO.SelectedValue.ToString();
            }
        }

        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.AutoMarca = "";
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.AutoMarca = CB_MARCA.SelectedValue.ToString();
            }
        }

        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.AutoImpuesto = "";
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.AutoImpuesto = CB_IMPUESTO.SelectedValue.ToString();
            }
        }

        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.IdOrigen = "";
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.IdOrigen = CB_ORIGEN.SelectedValue.ToString();
            }
        }

        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.IdCategoria = "";
            if (CB_CATEGORIA.SelectedIndex != -1)
            {
                _controlador.IdCategoria = CB_CATEGORIA.SelectedValue.ToString();
            }
        }

        private void CB_CLASIFICACION_ABC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.IdClasificacionAbc = "";
            if (CB_CLASIFICACION_ABC.SelectedIndex != -1)
            {
                _controlador.IdClasificacionAbc = CB_CLASIFICACION_ABC.SelectedValue.ToString();
            }
        }

        private void CB_DIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.IdDivisa = "";
            if (CB_DIVISA.SelectedIndex != -1)
            {
                _controlador.IdDivisa = CB_DIVISA.SelectedValue.ToString();
            }
        }


        //
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


        private void TB_MODELO_Leave(object sender, EventArgs e)
        {
            TB_MODELO.Text = TB_MODELO.Text.Trim().ToUpper();
            _controlador.ModeloProducto = TB_MODELO.Text;
        }

        private void TB_REFERENCIA_Leave(object sender, EventArgs e)
        {
            TB_REFERENCIA.Text = TB_REFERENCIA.Text.Trim().ToUpper();
            _controlador.ReferenciaProducto = TB_REFERENCIA.Text;
        }


        private void TB_CONTENIDO_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = int.Parse(TB_CONTENIDO.Text) <= 0;
        }
        private void TB_CONTENIDO_Leave(object sender, EventArgs e)
        {
            _controlador.setContEmpCompra(int.Parse(TB_CONTENIDO.Text));  
        }
        private void TB_CONTENIDO_INV_Leave(object sender, EventArgs e)
        {
            _controlador.setContEmpInv(int.Parse(TB_CONTENIDO_INV.Text));
        }
        private void TB_CONTENIDO_INV_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = int.Parse(TB_CONTENIDO_INV.Text) <= 0;
        }


        private void TB_PLU_Leave(object sender, EventArgs e)
        {
            TB_PLU.Text = TB_PLU.Text.Trim().ToUpper();
            _controlador.Plu = TB_PLU.Text;  
        }

        private void TB_DIAS_EMPAQUE_Leave(object sender, EventArgs e)
        {
            _controlador.DiasEmpaque = int.Parse(TB_DIAS_EMPAQUE.Text);  
        }

        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            MaestroDepartamento();
        }

        private void MaestroDepartamento()
        {
            var ind = CB_DEPARTAMENTO.SelectedIndex;
            _controlador.MaestroDepartamento();
            CB_DEPARTAMENTO.Refresh();
            CB_DEPARTAMENTO.SelectedIndex = -1;
        }

        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            MaestrGrupo();
        }

        private void MaestrGrupo()
        {
            var ind = CB_GRUPO.SelectedIndex;
            _controlador.MaestroGrupo();
            CB_GRUPO.Refresh();
            CB_GRUPO.SelectedIndex = -1;
        }

        private void L_MARCA_Click(object sender, EventArgs e)
        {
            MaestroMarca();
        }

        private void MaestroMarca()
        {
            var ind = CB_MARCA.SelectedIndex;
            _controlador.MaestroMarca();
            CB_MARCA.Refresh();
            CB_MARCA.SelectedIndex = -1;
        }

        private void BT_ABRIR_Click(object sender, EventArgs e)
        {
            BuscarImagen();
            RedefinirImagen();
        }

        private void BuscarImagen()
        {
            try 
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPG|*.jpg|PNG|*.png|Bitmap|*.bmp", ValidateNames = true, Multiselect = false }) 
                {
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        PB_IMAGEN.Image = Image.FromFile(ofd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "*** ERROR ***", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarImagen();
        }

        private void LimpiarImagen()
        {
            PB_IMAGEN.Image = PB_IMAGEN.InitialImage;
            RedefinirImagen();
        }

        private void RedefinirImagen()
        {
            _controlador.Imagen = new byte[]{} ;
            if (PB_IMAGEN.Image != PB_IMAGEN.InitialImage)
            {
                //PB_IMAGEN.Image = ResizeImage(PB_IMAGEN.Image,188,128);
                using (MemoryStream ms = new MemoryStream())
                {
                    PB_IMAGEN.Image.Save(ms, ImageFormat.Jpeg);
                    _controlador.Imagen = ms.ToArray();
                }
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void CHB_PESADO_CheckedChanged(object sender, EventArgs e)
        {
            if (!inicializarData)
            {
                _controlador.Pesado = CHB_PESADO.Checked;
                TB_PLU.Enabled = CHB_PESADO.Checked;
                TB_DIAS_EMPAQUE.Enabled = CHB_PESADO.Checked;
            }
        }

        private void BT_LISTA_PLU_Click(object sender, EventArgs e)
        {
            ListaPlu();
        }

        private void ListaPlu()
        {
            _controlador.ListaPlu();
        }

        private void BT_AGREGAR_COD_ALTERNO_Click(object sender, EventArgs e)
        {
            AgregarCodigoAlterno();
        }

        private void AgregarCodigoAlterno()
        {
            _controlador.AgregarCodigoAlterno();
            TB_ALTERNO.Text = "";
            TB_ALTERNO.Focus();
        }

        private void BT_ELIMINAR_COD_ALTERNO_Click(object sender, EventArgs e)
        {
            EliminarCodigoAlterno();
        }

        private void EliminarCodigoAlterno()
        {
            _controlador.EliminarCodigoAlterno();
        }

        private void TB_ALTERNO_Leave(object sender, EventArgs e)
        {
            _controlador.CodigoAlterno = TB_ALTERNO.Text;
        }

        private void CHB_CATALOGO_CheckedChanged(object sender, EventArgs e)
        {
            if (!inicializarData)
            {
                _controlador.ActivarCatlogo = CHB_CATALOGO.Checked;
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

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.Procesar();
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
            }
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
            var _alto= decimal.Parse(TB_ALTO.Text);
            _controlador.setAlto(_alto);
        }
        private void TB_LARGO_Leave(object sender, EventArgs e)
        {
            var _largo= decimal.Parse(TB_LARGO.Text);
            _controlador.setLargo(_largo);
        }
        private void TB_ANCHO_Leave(object sender, EventArgs e)
        {
            var _ancho= decimal.Parse(TB_ANCHO.Text);
            _controlador.setAncho(_ancho);
        }

    }

}