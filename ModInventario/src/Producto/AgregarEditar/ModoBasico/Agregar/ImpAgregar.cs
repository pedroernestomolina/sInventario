using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.AgregarEditar.ModoBasico.Agregar
{
    
    public class ImpAgregar: BaseAgregarEditar, IAgregar
    {


        public string GetTitulo { get { return "Agregar/Crear Ficha"; } }


        public ImpAgregar() 
            :base()
        {
            _autoPrd = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _data = new dataAgregar();
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
                var ficha = new OOB.LibInventario.Producto.Agregar.Ficha()
                {
                    autoDepartamento = _data.GetDepartamento.id,
                    autoEmpCompra = _data.GetEmpCompra.id,
                    autoEmpInv = _data.GetEmpVentaTipo1.id,
                    autoGrupo = _data.GetGrupo.id,
                    autoMarca = _data.GetMarca.id,
                    autoTasaImpuesto = _data.GetImpuesto.id,
                    codigo = _data.GetCodigoProducto,
                    contenidoCompra = _data.GetContEmpCompra,
                    contEmpInv = _data.GetContEmpVentaTipo1,
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
                Helpers.Msg.Error(e.Message );
            }
        }

    }

}