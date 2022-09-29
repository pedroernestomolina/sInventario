using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.AgregarEditar.ModoBasico.Editar
{
    
    public class ImpEditar: BaseAgregarEditar, IEditar
    {


        public string GetTitulo { get { return "Editar/Actualizar Ficha"; } }


        public ImpEditar() 
            :base()
        {
            _autoPrd = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _data = new dataEditar();
            _departamento = new FiltrosGen.Opcion.Gestion();
            _grupo=new FiltrosGen.Opcion.Gestion();
            _marca= new FiltrosGen.Opcion.Gestion();
            _impuesto = new FiltrosGen.Opcion.Gestion();
            _origen= new FiltrosGen.Opcion.Gestion();
            _divisa=new FiltrosGen.Opcion.Gestion();
            _categoria=new FiltrosGen.Opcion.Gestion();
            _clasificacion= new FiltrosGen.Opcion.Gestion();
            _empCompra= new FiltrosGen.Opcion.Gestion();
            _empVentaTipo1=new FiltrosGen.Opcion.Gestion();
            _empVentaTipo2=new FiltrosGen.Opcion.Gestion();
            _empVentaTipo3=new FiltrosGen.Opcion.Gestion();
            _gPlu = new ModInventario.Producto.Plu.Gestion();
            _gCodAlterno = new CodigosAlterno.Gestion();
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
                var r01 = Sistema.MyData.Producto_Editar_GetFicha(_fichaEditar);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                var ficha = r01.Entidad;
                setCodigoProducto(ficha.codigo);
                setDescripcionProducto(ficha.descripcion);
                setNombreProducto(ficha.nombre);
                setDepartamento(ficha.autoDepartamento);
                setGrupo(ficha.autoGrupo);
                setMarca(ficha.autoMarca);
                setImpuesto(ficha.autoTasaImpuesto);
                setOrigen(((int)ficha.origen).ToString());
                setCategoria(((int)ficha.categoria).ToString());
                setClasificacion(((int)ficha.Clasificacion).ToString());
                setDivisa(((int)ficha.AdmPorDivisa).ToString());
                setPesado(ficha.esPesado == OOB.LibInventario.Producto.Enumerados.EnumPesado.Si ? true : false);
                setPlu(ficha.plu);
                setDiasEmpaque(ficha.diasEmpaque);
                setEmpCompra(ficha.autoEmpCompra);
                setEmpVentaTipo1(ficha.autoEmpVentaTipo_1);
                setEmpVentaTipo2(ficha.autoEmpVentaTipo_2);
                setEmpVentaTipo3(ficha.autoEmpVentaTipo_3);
                setContEmpCompra(ficha.contenidoCompra);
                setContEmpVentaTipo1(ficha.contEmpVentaTipo_1);
                setContEmpVentaTipo2(ficha.contEmpVentaTipo_2);
                setContEmpVentaTipo3(ficha.contEmpVentaTipo_3);
                var _lst = new List<string>();
                foreach (var rg in ficha.CodigosAlterno)
                {
                    _lst.Add(rg.Codigo);
                }
                _gCodAlterno.CargarData(_lst);
                return true;
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
            _autoPrd = "";
            if (_data.ValidarDataIsOk())
            {
                var xmsg = "Procesar/Guardar Cambios ?";
                if (MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    GuardarFicha();
                }
            }
        }


        private string _autoPrd;
        public override bool IsAgregarEditarOk { get { return _procesarIsOk; } }
        public override string AutoProductoAgregado { get { return _autoPrd; } }


        private void GuardarFicha()
        {
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

            var _tasaIva = 0m;
            try
            {
                var r01 = Sistema.MyData.TasaImpuesto_GetById(_data.GetImpuesto.id);
                var ficha = new OOB.LibInventario.Producto.Editar.Actualizar.Ficha()
                {
                    autoDepartamento = _data.GetDepartamento.id,
                    autoEmpCompra = _data.GetEmpCompra.id,
                    autoEmpInv = _data.GetEmpVentaTipo1.id,
                    autoGrupo = _data.GetGrupo.id,
                    autoMarca = _data.GetMarca.id,
                    autoTasaImpuesto = _data.GetImpuesto.id,
                    codigo = _data.GetCodigoProducto,
                    contenidoCompra = _data.GetContEmpCompra,
                    descripcion = _data.GetDescripcionProducto,
                    nombre = _data.GetNombreProducto,
                    abc = _data.GetClasificacion.desc,
                    categoria = _data.GetCategoria.desc,
                    estatusDivisa = _divisa,
                    origen = _data.GetOrigen.desc,
                    esPesado = _pesado,
                    plu = _data.GetPlu,
                    diasEmpaque = _data.GetDiasEmpaque,
                    autoEmpVentaTipo_1 = _data.GetEmpVentaTipo1.id,
                    autoEmpVentaTipo_2 = _data.GetEmpVentaTipo2.id,
                    autoEmpVentaTipo_3 = _data.GetEmpVentaTipo3.id,
                    contEmpVentaTipo_1 = _data.GetContEmpVentaTipo1,
                    contEmpVentaTipo_2 = _data.GetContEmpVentaTipo2,
                    contEmpVentaTipo_3 = _data.GetContEmpVentaTipo3,
                    contenidoInv = _data.GetContEmpVentaTipo1,
                    auto = _fichaEditar,
                    tasaImpuesto = _tasaIva,
                };
                var codAlterno = new List<OOB.LibInventario.Producto.Editar.Actualizar.FichaCodigoAlterno>();
                foreach (var rg in _gCodAlterno.CodigosExportar)
                {
                    codAlterno.Add(new OOB.LibInventario.Producto.Editar.Actualizar.FichaCodigoAlterno() { Codigo = rg.codigo });
                }
                ficha.codigosAlterno = codAlterno;
                var r02 = Sistema.MyData.Producto_Editar_Actualizar(ficha);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                _procesarIsOk = true;
                Helpers.Msg.EditarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message );
            }
        }

    }

}