using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.PrecioAjuste
{

    public class Ajuste : IAjuste
    {

        private FiltrosGen.IOpcion _gEmpresaSuc;
        private FiltrosGen.IOpcion _gDepartamento;
        private FiltrosGen.IOpcion _gGrupo;
        private FiltrosGen.IOpcion _gEmpaqueVer;
        private IAjusteLista _gLista;
        private Producto.Precio.EditarCambiar.IEditar _gEditarPrecio;
        private ISeguridadAccesoSistema _gAccesoSistema;
        private Sucursal.Lista.IListaSuc _gSuc;


        public Ajuste(ISeguridadAccesoSistema ctrSeguridad, Producto.Precio.EditarCambiar.IEditar gPrecio)
        {
            _gEmpresaSuc = new FiltrosGen.Opcion.Gestion();
            _gDepartamento = new FiltrosGen.Opcion.Gestion();
            _gGrupo = new FiltrosGen.Opcion.Gestion();
            _gEmpaqueVer = new FiltrosGen.Opcion.Gestion();
            _gLista = new AjusteLista();
            _gAccesoSistema = ctrSeguridad;
            _gSuc = new Sucursal.Lista.ListaSuc();
            _gEditarPrecio = gPrecio;
        }


        public void Inicializa()
        {
            _gEmpresaSuc.Inicializa();
            _gDepartamento.Inicializa();
            _gGrupo.Inicializa();
            _gEmpaqueVer.Inicializa();
            _gLista.Inicializa();
            _gLista.Inicializa();
        }
        PrecioAjusteFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new PrecioAjusteFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.EmpresaGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var r02 = Sistema.MyData.Departamento_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var _lst_1 = r01.Lista.Select(s =>
            {
                var nr = new ficha()
                {
                    codigo = "",
                    desc = s.descripcion,
                    id = s.idGrupo,
                };
                return nr;
            }).ToList();
            var _lst_2 = r02.Lista.Select(s =>
            {
                var nr = new ficha()
                {
                    codigo = "",
                    desc = s.nombre,
                    id = s.auto,
                };
                return nr;
            }).ToList();
            var _lst_3 = new List<ficha>() 
            { 
                new ficha(){ id="01", desc="Empaque 1"},  
                new ficha(){ id="02", desc="Empaque 2"},  
                new ficha(){ id="03", desc="Empaque 3"},  
            };
            _gEmpresaSuc.setData(_lst_1);
            _gDepartamento.setData(_lst_2);
            _gEmpaqueVer.setData(_lst_3);
            return rt;
        }


        public void Buscar()
        {
            if (_gEmpresaSuc.Item == null)
            {
                Helpers.Msg.Error("CAMPO [ EMPRESA GRUPO ] NO PUEDE ESTAR VACIO");
                return;
            }
            var _idDep = _gDepartamento.Item == null ? "" : _gDepartamento.GetId;
            var _idGrupo = _gGrupo.Item == null ? "" : _gGrupo.GetId;
            var filtroOOb = new OOB.LibInventario.Visor.PrecioAjuste.Filtro()
            {
                idEmpresaGrrupo = _gEmpresaSuc.GetId,
                autoDepart = _idDep,
                autoGrupo = _idGrupo,
            };
            var r01 = Sistema.MyData.Visor_PrecioAjuste(filtroOOb);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var r02 = Sistema.MyData.EmpresaGrupo_PrecioManejar_GetById(_gEmpresaSuc.GetId);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            var _lst = new List<data>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                var nr = new data()
                {
                    idPrd = rg.auto,
                    nombre = rg.nombre,
                };
                switch (r02.Entidad)
                {
                    case "1": //precio 1
                        nr.cont_emp_1 = rg.contEmp1_1;
                        nr.cont_emp_2 = rg.contEmp2_1;
                        nr.cont_emp_3 = rg.contEmp3_1;
                        nr.pfull_divisa_emp_1 = rg.pFDivEmp1_1;
                        nr.pfull_divisa_emp_2 = rg.pFDivEmp2_1;
                        nr.pfull_divisa_emp_3 = rg.pFDivEmp3_1;
                        break;
                    case "2": //precio 2
                        nr.cont_emp_1 = rg.contEmp1_2;
                        nr.cont_emp_2 = rg.contEmp2_2;
                        nr.cont_emp_3 = rg.contEmp3_2;
                        nr.pfull_divisa_emp_1 = rg.pFDivEmp1_2;
                        nr.pfull_divisa_emp_2 = rg.pFDivEmp2_2;
                        nr.pfull_divisa_emp_3 = rg.pFDivEmp3_2;
                        break;
                    case "3": //precio 3
                        nr.cont_emp_1 = rg.contEmp1_3;
                        nr.cont_emp_2 = rg.contEmp2_3;
                        nr.cont_emp_3 = rg.contEmp3_3;
                        nr.pfull_divisa_emp_1 = rg.pFDivEmp1_3;
                        nr.pfull_divisa_emp_2 = rg.pFDivEmp2_3;
                        nr.pfull_divisa_emp_3 = rg.pFDivEmp3_3;
                        break;
                    case "4": //precio 4
                        nr.cont_emp_1 = rg.contEmp1_4;
                        nr.cont_emp_2 = rg.contEmp2_4;
                        nr.cont_emp_3 = rg.contEmp3_4;
                        nr.pfull_divisa_emp_1 = rg.pFDivEmp1_4;
                        nr.pfull_divisa_emp_2 = rg.pFDivEmp2_4;
                        nr.pfull_divisa_emp_3 = rg.pFDivEmp3_4;
                        break;
                    case "5": //precio 5
                        nr.cont_emp_1 = rg.contEmp1_5;
                        nr.cont_emp_2 = rg.contEmp2_5;
                        nr.cont_emp_3 = rg.contEmp3_5;
                        nr.pfull_divisa_emp_1 = rg.pFDivEmp1_5;
                        nr.pfull_divisa_emp_2 = rg.pFDivEmp2_5;
                        nr.pfull_divisa_emp_3 = rg.pFDivEmp3_5;
                        break;
                }
                _lst.Add(nr);
            }
            _gLista.setData(_lst);
        }


        public BindingSource GetDataSource { get { return _gLista.Source; } }
        public int CntItems { get { return _gLista.CntItem; } }
        public data ItemActual { get { return (data)_gLista.ItemActual; } }


        public BindingSource GetEmpresaGrupoSource { get { return _gEmpresaSuc.Source; } }
        public BindingSource GetDepartamentoSource { get { return _gDepartamento.Source; } }
        public BindingSource GetGrupoSource { get { return _gGrupo.Source; } }
        public BindingSource GetEmpaqueVerSource { get { return _gEmpaqueVer.Source; } }

        public string GetEmpresaGrupoId { get { return _gEmpresaSuc.GetId; } }
        public string GetDepartamentoId { get { return _gDepartamento.GetId; } }
        public string GetGrupoId { get { return _gGrupo.GetId; } }
        public string GetEmpaqueId { get { return _gEmpaqueVer.GetId; } }


        public void setEmpresaGrupo(string id)
        {
            _gEmpresaSuc.setFicha(id);
        }
        public void setDepartamento(string id)
        {
            _gDepartamento.setFicha(id);
            _gGrupo.Inicializa();
            if (id != "")
            {
                var r01 = Sistema.MyData.Grupo_GetListaByIdDepartamento(id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var _lst_1 = r01.Lista.Select(s =>
                {
                    var nr = new ficha()
                    {
                        codigo = "",
                        desc = s.nombre,
                        id = s.auto,
                    };
                    return nr;
                }).ToList();
                _gGrupo.setData(_lst_1);
            }
        }
        public void setGrupo(string id)
        {
            _gGrupo.setFicha(id);
        }
        public void setEmpaque(string id)
        {
            if (id != "")
            {
                Buscar();
                _gLista.setFiltrar(id);
            }
        }

        public void EditarPrecio()
        {
            if (ItemActual != null)
            {
                var r00 = Sistema.MyData.Permiso_CambiarPrecios(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (_gAccesoSistema.Verificar(r00.Entidad))
                {
                    var idAuto = ItemActual.idPrd;
                    var r01 = Sistema.MyData.Producto_GetIdentificacion(idAuto);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    if (r01.Entidad.IsInactivo)
                    {
                        Helpers.Msg.Error("ESTATUS DEL PRODUCTO [ INACTIVO ], VERIFIQUE POR FAVOR");
                        return;
                    }
                    _gEditarPrecio.Inicializa();
                    _gEditarPrecio.setIdItemEditar(idAuto);
                    _gEditarPrecio.Inicia();
                    if (_gEditarPrecio.EditarPrecioIsOk)
                    {
                        _gLista.EliminarItem(idAuto);
                    }
                }
            }
        }
        public void ListaSucursal()
        {
            var filtroOOb = new OOB.LibInventario.Sucursal.Filtro() { idEmpresaGrupo = _gEmpresaSuc.GetId };
            var r01 = Sistema.MyData.Sucursal_GetLista(filtroOOb);
            if (r01.Result ==  OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var _lst = new List<Sucursal.Lista.data>();
            foreach(var rg in r01.Lista.OrderBy(o=>o.nombre).ToList())
            {
                var nr = new Sucursal.Lista.data() { codigo = rg.codigo, nombre = rg.nombre };
                _lst.Add(nr);
            }
            ((IGestion)_gSuc).Inicializa();
            _gSuc.setData(_lst);
            _gSuc.Inicia();
        }

    }

}