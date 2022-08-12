using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.AgregarEditar.Agregar
{
    
    public class Gestion: IGestion
    {

        private bool _isAgregarEditarOk;
        private string _autoProductoAgregado;
        private bool _isCerrarHabilitado;
        private List<OOB.LibInventario.Departamento.Ficha> depart;
        private BindingList<OOB.LibInventario.Departamento.Ficha> blDepart;
        private BindingSource bsDepart;
        private List<OOB.LibInventario.Grupo.Ficha> grupo;
        private BindingList<OOB.LibInventario.Grupo.Ficha> blGrupo;
        private BindingSource bsGrupo;
        private List<OOB.LibInventario.Marca.Ficha> marca;
        private BindingList<OOB.LibInventario.Marca.Ficha> blMarca;
        private BindingSource bsMarca;
        private List<OOB.LibInventario.TasaImpuesto.Ficha> impuesto;
        private BindingList<OOB.LibInventario.TasaImpuesto.Ficha> blImpuesto;
        private BindingSource bsImpuesto;
        private List<OOB.LibInventario.Producto.Origen.Ficha> origen;
        private BindingList<OOB.LibInventario.Producto.Origen.Ficha> blOrigen;
        private BindingSource bsOrigen;
        private List<OOB.LibInventario.Producto.AdmDivisa.Ficha> divisa;
        private BindingList<OOB.LibInventario.Producto.AdmDivisa.Ficha> blDivisa;
        private BindingSource bsDivisa;
        private List<OOB.LibInventario.Producto.Categoria.Ficha> categoria;
        private BindingList<OOB.LibInventario.Producto.Categoria.Ficha> blCategoria;
        private BindingSource bsCategoria;
        private List<OOB.LibInventario.Producto.ClasificacionAbc.Ficha> clasificacion;
        private BindingList<OOB.LibInventario.Producto.ClasificacionAbc.Ficha> blClasificacion;
        private BindingSource bsClasificacion;
        private data miData;
        private Plu.Gestion _gestionPlu;
        private CodAlterno.Gestion _gestionCodAlterno;

        //
        private FiltrosGen.IOpcion _gEmpInv;
        private FiltrosGen.IOpcion _gEmpCompra;
        private bool _abandonarIsOk;
        private bool _procesarIsOk;


        public string Titulo { get { return "Agregar Ficha"; } }
        public BindingSource Departamentos { get { return bsDepart; } }
        public BindingSource Grupos { get { return bsGrupo; } }
        public BindingSource Marcas { get { return bsMarca; } }
        public BindingSource Impuesto { get { return bsImpuesto; } }
        public BindingSource Origen { get { return bsOrigen; } }
        public BindingSource Divisa { get { return bsDivisa; } }
        public BindingSource Categoria { get { return bsCategoria; } }
        public BindingSource Clasificacion { get { return bsClasificacion; } }
        public bool IsCerrarHabilitado { get { return _isCerrarHabilitado; } }
        public string CodigoProducto { get { return miData.Codigo; } set { miData.Codigo = value; } }
        public string DescripcionProducto { get { return miData.Descripcion; } set { miData.Descripcion = value; } }
        public string NombreProducto{get{return miData.NombreProducto;}set{miData.NombreProducto = value;}}
        public string ModeloProducto { get { return miData.ModeloProducto; } set { miData.ModeloProducto = value; } }
        public string ReferenciaProducto { get { return miData.ReferenciaProducto; } set { miData.ReferenciaProducto = value; } }
        public string AutoDepartamento { get { return miData.AutoDepartamento; } set { miData.AutoDepartamento = value; } }
        public string AutoGrupo { get { return miData.AutoGrupo; } set { miData.AutoGrupo = value; } }
        public string AutoMarca { get { return miData.AutoMarca; } set { miData.AutoMarca = value; } }
        public string AutoImpuesto { get { return miData.AutoImpuesto; } set { miData.AutoImpuesto = value; } }
        public string IdOrigen { get { return miData.IdOrigen; } set { miData.IdOrigen = value; } }
        public string IdCategoria { get { return miData.IdCategoria; } set { miData.IdCategoria = value; } }
        public string IdClasificacionAbc { get { return miData.IdClasificacionAbc; } set { miData.IdClasificacionAbc = value; } }
        public string IdDivisa { get { return miData.IdDivisa; } set { miData.IdDivisa = value; } }
        public byte[] Imagen { get { return miData.Imagen; } set { miData.Imagen = value; } }
        public bool Pesado { get { return miData.EsPesado; } set { miData.EsPesado = value; } }
        public bool ActivarCatlogo { get { return miData.ActivarCatalogo; } set { miData.ActivarCatalogo = value; } }
        public string Plu { get { return miData.Plu; } set { miData.Plu = value; } }
        public int DiasEmpaque{get{return miData.DiasEmpaque;}set{miData.DiasEmpaque = value;}}
        public bool IsAgregarEditarOk { get { return _isAgregarEditarOk; } }
        public string AutoProductoAgregado { get { return _autoProductoAgregado; } }


        public Gestion()
        {
            _gestionPlu = new Producto.Plu.Gestion();
            _gestionCodAlterno = new CodAlterno.Gestion();
            _gEmpInv = new FiltrosGen.Opcion.Gestion();
            _gEmpCompra = new FiltrosGen.Opcion.Gestion();

            CodigoAlterno = "";
            _isAgregarEditarOk = false;
            _autoProductoAgregado = "";
            _isCerrarHabilitado = false;
            miData = new data();

            depart = new List<OOB.LibInventario.Departamento.Ficha>();
            blDepart = new BindingList<OOB.LibInventario.Departamento.Ficha>(depart);
            bsDepart = new BindingSource();
            bsDepart.DataSource = blDepart;

            grupo= new List<OOB.LibInventario.Grupo.Ficha>();
            blGrupo= new BindingList<OOB.LibInventario.Grupo.Ficha>(grupo);
            bsGrupo= new BindingSource();
            bsGrupo.DataSource = blGrupo;

            marca= new List<OOB.LibInventario.Marca.Ficha>();
            blMarca= new BindingList<OOB.LibInventario.Marca.Ficha>(marca);
            bsMarca= new BindingSource();
            bsMarca.DataSource = blMarca ;

            impuesto = new List<OOB.LibInventario.TasaImpuesto.Ficha>();
            blImpuesto = new BindingList<OOB.LibInventario.TasaImpuesto.Ficha>(impuesto);
            bsImpuesto = new BindingSource();
            bsImpuesto.DataSource = blImpuesto;

            origen= new List<OOB.LibInventario.Producto.Origen.Ficha>();
            blOrigen= new BindingList<OOB.LibInventario.Producto.Origen.Ficha>(origen);
            bsOrigen= new BindingSource();
            bsOrigen.DataSource = blOrigen;

            divisa= new List<OOB.LibInventario.Producto.AdmDivisa.Ficha>();
            blDivisa= new BindingList<OOB.LibInventario.Producto.AdmDivisa.Ficha>(divisa);
            bsDivisa= new BindingSource();
            bsDivisa.DataSource = blDivisa;

            categoria= new List<OOB.LibInventario.Producto.Categoria.Ficha>();
            blCategoria= new BindingList<OOB.LibInventario.Producto.Categoria.Ficha>(categoria);
            bsCategoria= new BindingSource();
            bsCategoria.DataSource = blCategoria;

            clasificacion= new List<OOB.LibInventario.Producto.ClasificacionAbc.Ficha>();
            blClasificacion= new BindingList<OOB.LibInventario.Producto.ClasificacionAbc.Ficha>(clasificacion);
            bsClasificacion = new BindingSource();
            bsClasificacion.DataSource = blClasificacion;
        }
        

        public void SetFicha(string auto)
        {
        }

        void IGestion.Limpiar()
        {
            _isCerrarHabilitado = false;
            _isAgregarEditarOk = false;
            _autoProductoAgregado = "";
            miData.Limpiar();
            _gestionCodAlterno.Limpiar();
        }

        bool IGestion.CargarData()
        {
            var rt = true;

            if (!DepartamentosCargar())
                return false;

            if (!GruposCargar())
                return false;

            if (!MarcasCargar())
                return false;

            var r04 = Sistema.MyData.TasaImpuesto_GetLista();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            blImpuesto.Clear();
            impuesto.AddRange(r04.Lista.OrderBy(o => o.tasa).ToList());
            bsImpuesto.CurrencyManager.Refresh();

            var r05 = Sistema.MyData.Producto_Categoria_Lista();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            blCategoria.Clear();
            categoria.AddRange(r05.Lista.OrderBy(o => o.Descripcion).ToList());
            bsCategoria.CurrencyManager.Refresh();

            var r06 = Sistema.MyData.Producto_Origen_Lista();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            blOrigen.Clear();
            origen.AddRange(r06.Lista.OrderBy(o => o.Descripcion).ToList());
            bsOrigen.CurrencyManager.Refresh();


            var r07 = Sistema.MyData.EmpaqueMedida_GetLista ();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return false;
            }
            var lData = new List<ficha>();
            foreach (var rg in r07.Lista.OrderBy(o => o.nombre).ToList())
            {
                var nr = new ficha(rg.auto, "", rg.nombre);
                lData.Add(nr);
            }
            _gEmpCompra.setData(lData);
            _gEmpInv.setData(lData);


            var r08 = Sistema.MyData.Producto_AdmDivisa_Lista ();
            if (r08.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r08.Mensaje);
                return false;
            }
            blDivisa.Clear();
            divisa.AddRange(r08.Lista.OrderBy(o => o.Descripcion).ToList());
            bsDivisa.CurrencyManager.Refresh();

            var r09 = Sistema.MyData.Producto_Clasificacion_Lista ();
            if (r09.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return false;
            }
            blClasificacion.Clear();
            clasificacion.AddRange(r09.Lista.OrderBy(o => o.Descripcion).ToList());
            bsClasificacion.CurrencyManager.Refresh();

            miData.Limpiar();
            miData.setFicha("0000000001", "0000000001", "0000000001", 
                impuesto.First(f=>f.nombre.Trim()=="IVA").auto, 
                origen.First(f => f.Descripcion.Trim() == "Nacional").Id,
                categoria.First(f => f.Descripcion.Trim() == "Producto Terminado").Id,
                clasificacion.First(f => f.Descripcion.Trim() == "D").Id,
                divisa.First(f => f.Descripcion.Trim() == "No").Id);
            return rt;
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            var msg = "Procesar Cambios ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                _isCerrarHabilitado = Guardar();
                if (_isCerrarHabilitado )
                {
                    Helpers.Msg.AgregarOk();
                }
            }
            else
            {
                _isCerrarHabilitado = false;
            }
        }

        private bool Guardar()
        {
            var rt = true;

            if (!miData.IsOk()) 
            {
                return false;
            }

            var _plu = miData.Plu;
            var _diasEmpaque = miData.DiasEmpaque;
            var _pesado = "1";
            if (!miData.EsPesado)
            {
                _plu = "";
                _diasEmpaque = 0;
                _pesado = "0";
            }
            var _catalogo = "0";
            if (miData.ActivarCatalogo)
                _catalogo = "1";

            var ficha = new OOB.LibInventario.Producto.Agregar.Ficha()
            {
                autoDepartamento = miData.AutoDepartamento,
                autoEmpCompra = miData.EmpCompra.id,
                autoEmpInv = miData.EmpInv.id,
                autoGrupo = miData.AutoGrupo,
                autoMarca = miData.AutoMarca,
                autoTasaImpuesto = miData.AutoImpuesto,
                codigo = miData.Codigo,
                contenidoCompra = miData.ContEmpProducto,
                contEmpInv = miData.ContEmpInv,
                descripcion = miData.Descripcion,
                modelo = miData.ModeloProducto,
                nombre = miData.NombreProducto,
                referencia = miData.ReferenciaProducto,
                abc = miData.Clasificacion,
                categoria = miData.Categoria,
                estatusDivisa = miData.Divisa,
                origen = miData.Origen,
                estatus = "Activo",
                tasa=impuesto.First(f=>f.auto==miData.AutoImpuesto).tasa,
                imagen=miData.Imagen,
                esPesado = _pesado,
                plu = _plu,
                diasEmpaque = _diasEmpaque,
                estatusCatalogo=_catalogo,
                peso=miData.GetPeso,
                volumen=miData.GetVolumen,
                alto=miData.GetAlto,
                ancho=miData.GetAncho,
                largo=miData.GetLargo
            };
            var codAlterno = new List<OOB.LibInventario.Producto.Agregar.FichaCodAlterno>();
            foreach (var rg in _gestionCodAlterno.ListaCodigos) 
            {
                codAlterno.Add(new OOB.LibInventario.Producto.Agregar.FichaCodAlterno() { Codigo = rg.codigo });
            }
            ficha.codigosAlterno = codAlterno;
            var r01 = Sistema.MyData.Producto_Nuevo_Agregar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _procesarIsOk = true;
            _isAgregarEditarOk = true;
            _autoProductoAgregado = r01.Auto;
            return rt;
        }

        public void InicializarIsCerrarHabilitado()
        {
            _isCerrarHabilitado = true;
        }

        public void CargaDepartamentos()
        {
            DepartamentosCargar();
        }


        public bool DepartamentosCargar()
        {
            var rt = true;

            var r01 = Sistema.MyData.Departamento_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            blDepart.Clear();
            depart.AddRange(r01.Lista.OrderBy(o => o.nombre).ToList());
            bsDepart.CurrencyManager.Refresh();

            return rt;
        }

        public void CargaGrupos()
        {
            GruposCargar();
        }

        public bool GruposCargar()
        {
            var rt = true;

            var r02 = Sistema.MyData.Grupo_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            blGrupo.Clear();
            grupo.AddRange(r02.Lista.OrderBy(o => o.nombre).ToList());
            bsGrupo.CurrencyManager.Refresh();

            return rt;
        }

        public void CargaMarcas()
        {
            MarcasCargar();
        }

        public bool MarcasCargar()
        {
            var rt = true;

            var r03 = Sistema.MyData.Marca_GetLista();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            blMarca.Clear();
            marca.AddRange(r03.Lista.OrderBy(o => o.nombre).ToList());
            bsMarca.CurrencyManager.Refresh();

            return rt;
        }

        public void ListaPlu()
        {
            _gestionPlu.Inicia();
        }


        public BindingSource SourceCodAlterno { get { return _gestionCodAlterno.Source; } }
        public string CodigoAlterno { get; set; }

        public void AgregarCodigoAlterno()
        {
            _gestionCodAlterno.Agregar(CodigoAlterno);
        }

        public void EliminarCodigoAlterno()
        {
            _gestionCodAlterno.Eliminar();
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _gEmpCompra.Inicializa();
            _gEmpInv.Inicializa();
        }


        public BindingSource GetEmpInvSource { get { return _gEmpInv.Source; } }
        public string GetEmpInvId { get { return _gEmpInv.GetId; } }
        public BindingSource GetEmpCompraSource { get { return _gEmpCompra.Source; } }
        public string GetEmpCompraId { get { return _gEmpCompra.GetId; } }
        public int GetContEmpCompra { get { return miData.ContEmpProducto; } }
        public int GetContEmpInv { get { return miData.ContEmpInv; } }
        public void setEmpCompra(string id)
        {
            _gEmpCompra.setFicha(id);
            miData.setEmpCompra(_gEmpCompra.Item);
        }
        public void setEmpInv(string id)
        {
            _gEmpInv.setFicha(id);
            miData.setEmpInv(_gEmpInv.Item);
        }
        public void setContEmpCompra(int cont)
        {
            miData.setContEmpCompra(cont);
        }
        public void setContEmpInv(int cont)
        {
            miData.setContEmpInv(cont);
        }


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios Realizados ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }


        public bool HabilitarEditarCodigo { get { return true; } }
        public bool EditarCodigoIsOk { get { return true; } }
        public void EditarCodigo()
        {
        }



        public decimal GetPeso { get { return miData.GetPeso; } }
        public void setPeso(decimal _peso)
        {
            miData.setPeso(_peso);
        }
        public decimal GetVolumen { get { return miData.GetVolumen; } }
        public void setVolumen(decimal _volumen)
        {
            miData.setVolumen(_volumen);
        }
        public decimal GetAlto { get { return miData.GetAlto; } }
        public void setAlto(decimal _alto)
        {
            miData.setAlto(_alto);
        }
        public decimal GetLargo { get { return miData.GetLargo; } }
        public void setLargo(decimal _largo)
        {
            miData.setLargo(_largo);
        }
        public decimal GetAncho { get { return miData.GetAncho; } }
        public void setAncho(decimal _ancho)
        {
            miData.setAncho(_ancho);
        }

    }

}