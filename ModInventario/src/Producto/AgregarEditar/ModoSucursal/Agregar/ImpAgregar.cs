using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal.Agregar
{
    
    public class ImpAgregar: BaseAgregarEditarModoSucursal, IAgregar
    {

        public override string GetTitulo { get { return "Agregar/Crear Ficha"; } }
        public override bool HabilitarEditarCodigo { get { return false; } }


        public ImpAgregar(SeguridadSist.ISeguridad seguridad)
            : base(new dataAgregar(), seguridad)
        {
            _autoPrd = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _departamento = new FiltrosGen.Opcion.Gestion();
            _grupo = new FiltrosGen.Opcion.Gestion();
            _marca = new FiltrosGen.Opcion.Gestion();
            _impuesto = new FiltrosGen.Opcion.Gestion();
            _origen = new FiltrosGen.Opcion.Gestion();
            _divisa = new FiltrosGen.Opcion.Gestion();
            _categoria = new FiltrosGen.Opcion.Gestion();
            _clasificacion = new FiltrosGen.Opcion.Gestion();
            _empCompra = new FiltrosGen.Opcion.Gestion();
            _empVentaTipo1 = new FiltrosGen.Opcion.Gestion();
            _empVentaTipo2 = new FiltrosGen.Opcion.Gestion();
            _empVentaTipo3 = new FiltrosGen.Opcion.Gestion();
            _gPlu = new ModInventario.Producto.Plu.Gestion();
            _gCodAlterno = new CodigosAlterno.Gestion();
            _empInv = new FiltrosGen.Opcion.Gestion();
            _agregarDepartamento = new MaestrosInv.Departamento.Agregar.Gestion();
            _agregarGrupo = new MaestrosInv.Grupo.Agregar.Gestion();
            _agregarMarca = new MaestrosInv.Marca.Agregar.Gestion();
        }


        public override void Inicializa()
        {
            _autoPrd = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _data.Inicializa();
            _departamento.Inicializa();
            _grupo.Inicializa();
            _marca.Inicializa();
            _impuesto.Inicializa();
            _origen.Inicializa();
            _divisa.Inicializa();
            _categoria.Inicializa();
            _clasificacion.Inicializa();
            _empCompra.Inicializa();
            _empVentaTipo1.Inicializa();
            _empVentaTipo2.Inicializa();
            _empVentaTipo3.Inicializa();
            _gPlu.Inicializa();
            _gCodAlterno.Inicializa();
            _empInv.Inicializa();
            _agregarDepartamento.Inicializa();
            _agregarGrupo.Inicializa();
            _agregarMarca.Inicializa();
        }

        AgregarEditarFrm frm;
        public override void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public override bool CargarData()
        {
            if (base.CargarData())
            {
                try
                {
                    var _lst1 = new List<ficha>();
                    var r01 = Sistema.MyData.EmpaqueMedida_GetLista();
                    foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                    {
                        _lst1.Add(new ficha(rg.auto, "", rg.nombre));
                    }
                    _empInv.setData(_lst1);

                    setContEmpCompra(1);
                    setContEmpVentaTipo1(1);
                    setContEmpVentaTipo2(1);
                    setContEmpVentaTipo3(1);
                    setEmpCompra("0000000001");
                    setEmpVentaTipo1("0000000001");
                    setEmpVentaTipo2("0000000001");
                    setEmpVentaTipo3("0000000001");
                    setImpuesto("0000000004");
                    setOrigen("1");
                    setDivisa("1");
                    setCategoria("1");
                    setClasificacion("4");
                    setContEmpInv(1);
                    setEmpInv("0000000001");
                    return true;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                    return false;
                }
            }
            return false;
        }

        public override void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }
        public override void ProcesarFicha()
        {
            _procesarIsOk = false;
            if (_data.ValidarDataIsOk())
            {
                var xmsg = "Procesar/Guardar Ficha ?";
                if (MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    GuardarFicha();
                }
            }
        }


        private string _autoPrd;
        private Helpers.Seguridad seguridad;
        private SeguridadSist.ISeguridad _gSecurity;
        public override bool IsAgregarEditarOk { get { return _procesarIsOk; } }
        public override string AutoProductoAgregado { get { return _autoPrd; } }


        private void GuardarFicha()
        {
            var _tasaIva = 0m;
            var _plu = _data.GetPlu;
            var _diasEmpaque = _data.GetDiasEmpaque;
            var _pesado = "1";
            if (!_data.GetEsPesado)
            {
                _plu = "";
                _diasEmpaque = 0;
                _pesado = "0";
            }
            var _divisa = "1";
            if (_data.GetDivisa.id == "2")
                _divisa = "0";
            var _catalogo = "0";
            if (_data.GetActivarCatlogo)
                _catalogo = "1";

            try
            {
                var r01 = Sistema.MyData.TasaImpuesto_GetById(_data.GetImpuesto.id);
                _tasaIva = r01.Entidad.tasa;
                var ficha = new OOB.LibInventario.Producto.Agregar.Ficha()
                {
                    autoDepartamento = _data.GetDepartamento.id,
                    autoEmpCompra = _data.GetEmpCompra.id,
                    autoEmpInv = _data.GetEmpInv.id,
                    autoGrupo = _data.GetGrupo.id,
                    autoMarca = _data.GetMarca.id,
                    autoTasaImpuesto = _data.GetImpuesto.id,
                    codigo = _data.GetCodigoProducto,
                    contenidoCompra = _data.GetContEmpCompra,
                    contEmpInv = _data.GetContEmpInv,
                    descripcion = _data.GetDescripcionProducto,
                    nombre = _data.GetNombreProducto,
                    abc = _data.GetClasificacion.desc,
                    categoria = _data.GetCategoria.desc,
                    estatusDivisa = _divisa,
                    origen = _data.GetOrigen.desc,
                    estatus = "Activo",
                    tasa = _tasaIva,
                    esPesado = _pesado,
                    plu = _data.GetPlu,
                    diasEmpaque = _data.GetDiasEmpaque,
                    autoEmpVentaTipo_1 = _data.GetEmpVentaTipo1.id,
                    autoEmpVentaTipo_2 = _data.GetEmpVentaTipo2.id,
                    autoEmpVentaTipo_3 = _data.GetEmpVentaTipo3.id,
                    contEmpVentaTipo_1 = _data.GetContEmpVentaTipo1,
                    contEmpVentaTipo_2 = _data.GetContEmpVentaTipo2,
                    contEmpVentaTipo_3 = _data.GetContEmpVentaTipo3,
                    alto = _data.GetAlto,
                    ancho = _data.GetAncho,
                    largo = _data.GetLargo,
                    peso = _data.GetPeso,
                    volumen = _data.GetVolumen,
                    modelo = _data.GetModeloProducto,
                    referencia = _data.GetReferenciaProducto,
                    estatusCatalogo = _catalogo,
                    imagen = _data.GetImagen,
                };
                var codAlterno = new List<OOB.LibInventario.Producto.Agregar.FichaCodAlterno>();
                foreach (var rg in _gCodAlterno.CodigosExportar)
                {
                    codAlterno.Add(new OOB.LibInventario.Producto.Agregar.FichaCodAlterno() { Codigo = rg.codigo });
                }
                ficha.codigosAlterno = codAlterno;
                var r02 = Sistema.MyData.Producto_Nuevo_Agregar(ficha);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                _procesarIsOk = true;
                _autoPrd = r02.Auto;
                Helpers.Msg.AgregarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

    }

}