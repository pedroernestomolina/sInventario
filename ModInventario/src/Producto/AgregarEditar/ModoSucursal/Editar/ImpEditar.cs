﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal.Editar
{
    
    public class ImpEditar: BaseAgregarEditarModoSucursal, IEditar
    {

        public override string GetTitulo { get { return "Editar/Actualizar Ficha"; } }
        public override bool HabilitarEditarCodigo { get { return true; } }


        public ImpEditar(SeguridadSist.ISeguridad seguridad)
            : base(new dataEditar(), seguridad)
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
            _agregarGrupo= new MaestrosInv.Grupo.Agregar.Gestion();
            _agregarMarca= new MaestrosInv.Marca.Agregar.Gestion();
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
                    var r01 = Sistema.MyData.Producto_Editar_GetFicha(_fichaEditar);
                    var ent = r01.Entidad;

                    var _lst1 = new List<ficha>();
                    var r02 = Sistema.MyData.EmpaqueMedida_GetLista();
                    foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
                    {
                        _lst1.Add(new ficha(rg.auto, "", rg.nombre));
                    }
                    _empInv.setData(_lst1);

                    setCodigoProducto(ent.codigo);
                    setDescripcionProducto(ent.descripcion);
                    setNombreProducto(ent.nombre);
                    setContEmpCompra(ent.contenidoCompra);
                    setContEmpInv(ent.contEmpInv);
                    setContEmpVentaTipo1(ent.contEmpVentaTipo_1);
                    setContEmpVentaTipo2(ent.contEmpVentaTipo_2);
                    setContEmpVentaTipo3(ent.contEmpVentaTipo_3);
                    setEmpCompra(ent.autoEmpCompra);
                    setEmpInv(ent.autoEmpInv);
                    setEmpVentaTipo1(ent.autoEmpVentaTipo_1);
                    setEmpVentaTipo2(ent.autoEmpVentaTipo_2);
                    setEmpVentaTipo3(ent.autoEmpVentaTipo_3);
                    setImpuesto(ent.autoTasaImpuesto);
                    setDepartamento(ent.autoDepartamento);
                    setGrupo(ent.autoGrupo);
                    setMarca(ent.autoMarca);
                    setOrigen(((int)ent.origen).ToString());
                    setCategoria(((int)ent.categoria).ToString());
                    setClasificacion(((int)ent.Clasificacion).ToString());
                    setDivisa(((int)ent.AdmPorDivisa).ToString());
                    setPesado(ent.esPesado == OOB.LibInventario.Producto.Enumerados.EnumPesado.Si ? true : false);
                    setPlu(ent.plu);
                    setDiasEmpaque(ent.diasEmpaque);
                    setModeloProducto(ent.modelo);
                    setReferenciaProducto(ent.referencia);
                    setAncho(ent.ancho);
                    setLargo(ent.largo);
                    setAlto(ent.alto);
                    setPeso(ent.peso);
                    setVolumen(ent.volumen);
                    setActivarCatlogo(ent.activarCatalogo == OOB.LibInventario.Producto.Enumerados.EnumCatalogo.Si ? true : false);
                    setImagen(ent.imagen);
                    var _lst = new List<string>();
                    foreach (var rg in ent.CodigosAlterno)
                    {
                        _lst.Add(rg.Codigo);
                    }
                    _gCodAlterno.CargarData(_lst);
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
            _autoPrd = "";
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
                var ficha = new OOB.LibInventario.Producto.Editar.Actualizar.Ficha()
                {
                    auto = _fichaEditar,
                    autoDepartamento = _data.GetDepartamento.id,
                    autoEmpCompra = _data.GetEmpCompra.id,
                    autoEmpInv = _data.GetEmpInv.id,
                    autoGrupo = _data.GetGrupo.id,
                    autoMarca = _data.GetMarca.id,
                    autoTasaImpuesto = _data.GetImpuesto.id,
                    codigo = _data.GetCodigoProducto,
                    contenidoCompra = _data.GetContEmpCompra,
                    contenidoInv = _data.GetContEmpInv,
                    descripcion = _data.GetDescripcionProducto,
                    nombre = _data.GetNombreProducto,
                    abc = _data.GetClasificacion.desc,
                    categoria = _data.GetCategoria.desc,
                    estatusDivisa = _divisa,
                    origen = _data.GetOrigen.desc,
                    tasaImpuesto = _tasaIva,
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
                Helpers.Msg.Error(e.Message);
            }
        }

        private void setImagen(byte[] p)
        {
            _data.setImagenRaw(p);
        }

    }

}