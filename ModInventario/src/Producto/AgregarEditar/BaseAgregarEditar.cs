using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.AgregarEditar
{
    
    abstract public class BaseAgregarEditar: IBaseAgregarEditar
    {

        protected FiltrosGen.IOpcion _departamento;
        protected FiltrosGen.IOpcion _grupo;
        protected FiltrosGen.IOpcion _marca;
        protected FiltrosGen.IOpcion _impuesto;
        protected FiltrosGen.IOpcion _origen;
        protected FiltrosGen.IOpcion _divisa;
        protected FiltrosGen.IOpcion _categoria;
        protected FiltrosGen.IOpcion _clasificacion;
        protected FiltrosGen.IOpcion _empCompra;
        protected FiltrosGen.IOpcion _empVentaTipo1;
        protected FiltrosGen.IOpcion _empVentaTipo2;
        protected FiltrosGen.IOpcion _empVentaTipo3;
        protected ModInventario.Producto.Plu.IPlu _gPlu;
        protected CodigosAlterno.IAlterno _gCodAlterno;
        protected baseDataAgregarEditar _data;
        protected string _fichaEditar;


        public BindingSource GetCodAlterno_Source { get { return _gCodAlterno.GetSource; } }
        public BindingSource GetDepartamento_Source { get { return _departamento.Source; } }
        public BindingSource GetGrupo_Source { get { return _grupo.Source; } }
        public BindingSource GetMarca_Source { get { return _marca.Source; } }
        public BindingSource GetImpuesto_Source { get { return _impuesto.Source; } }
        public BindingSource GetOrigen_Source { get { return _origen.Source; } }
        public BindingSource GetDivisa_Source { get { return _divisa.Source; } }
        public BindingSource GetCategoria_Source { get { return _categoria.Source; } }
        public BindingSource GetClasificacion_Source { get { return _clasificacion.Source; } }
        public BindingSource GetEmpCompra_Source { get { return _empCompra.Source; } }
        public BindingSource GetEmpVentaTipo1_Source { get { return _empVentaTipo1.Source; } }
        public BindingSource GetEmpVentaTipo2_Source { get { return _empVentaTipo2.Source; } }
        public BindingSource GetEmpVentaTipo3_Source { get { return _empVentaTipo3.Source; } }


        public string GetDepartamento_Id { get { return _departamento.GetId; } }
        public string GetGrupo_Id { get { return _grupo.GetId; } }
        public string GetMarca_Id { get { return _marca.GetId; } }
        public string GetImpuesto_Id { get { return _impuesto.GetId; } }
        public string GetOrigen_Id { get { return _origen.GetId; } }
        public string GetCategoria_Id { get { return _categoria.GetId; } }
        public string GetClasificacion_Id { get { return _clasificacion.GetId; } }
        public string GetDivisa_id { get { return _divisa.GetId; } }
        public string GetEmpCompra_Id { get { return _empCompra.GetId; } }
        public string GetEmpVentaTipo1_ID { get { return _empVentaTipo1.GetId; } }
        public string GetEmpVentaTipo2_ID { get { return _empVentaTipo2.GetId; } }
        public string GetEmpVentaTipo3_ID { get { return _empVentaTipo3.GetId; } }


        public void setCodigoProducto(string v)
        {
            _data.setCodigoProducto(v);
        }
        public void setDescripcionProducto(string v)
        {
            _data.setDescripcionProducto(v);
        }
        public void setNombreProducto(string v)
        {
            _data.setNombreProducto(v);
        }
        public void setContEmpCompra(int v)
        {
            _data.setContEmpCompra(v);
        }
        public void setPlu(string v)
        {
            _data.setPlu(v);
        }
        public void setDiasEmpaque(int v)
        {
            _data.setDiasEmpaque(v);
        }
        public void setContEmpVentaTipo1(int v)
        {
            _data.setContEmpVentaTipo1(v);
        }
        public void setContEmpVentaTipo2(int v)
        {
            _data.setContEmpVentaTipo2(v);
        }
        public void setContEmpVentaTipo3(int v)
        {
            _data.setContEmpVentaTipo3(v);
        }
        public void setCodigoAlterno(string v)
        {
            _gCodAlterno.setCodigoAgregar(v);
        }
        public void setPesado(bool v)
        {
            _data.setPesado(v);
        }


        public string GetCodigoProducto { get { return _data.GetCodigoProducto; } }
        public string GetDescripcionProducto { get { return _data.GetDescripcionProducto; } }
        public string GetNombreProducto { get { return _data.GetNombreProducto; } }
        public string GetPlu { get { return _data.GetPlu; } }
        public bool GetEsPesado { get { return _data.GetEsPesado; } }
        public int GetContEmpVentaTipo1 { get { return _data.GetContEmpVentaTipo1; } }
        public int GetContEmpVentaTipo2 { get { return _data.GetContEmpVentaTipo2; } }
        public int GetContEmpVentaTipo3 { get { return _data.GetContEmpVentaTipo3; } }
        public int GetContEmpCompra { get { return _data.GetContEmpCompra; } }
        public int GetDiasEmpaque { get { return _data.GetDiasEmpaque; } }


        public void setDepartamento(string id)
        {
            _departamento.setFicha(id);
            _data.setDepartamento(_departamento.Item);
        }
        public void setGrupo(string id)
        {
            _grupo.setFicha(id);
            _data.setGrupo(_grupo.Item);
        }
        public void setDivisa(string id)
        {
            _divisa.setFicha(id);
            _data.setDivisa(_divisa.Item);
        }
        public void setClasificacion(string id)
        {
            _clasificacion.setFicha(id);
            _data.setClasificacion(_clasificacion.Item);
        }
        public void setCategoria(string id)
        {
            _categoria.setFicha(id);
            _data.setCategoria(_categoria.Item);
        }
        public void setOrigen(string id)
        {
            _origen.setFicha(id);
            _data.setOrigen(_origen.Item);
        }
        public void setImpuesto(string id)
        {
            _impuesto.setFicha(id);
            _data.setImpuesto(_impuesto.Item);
        }
        public void setMarca(string id)
        {
            _marca.setFicha(id);
            _data.setMarca(_marca.Item);
        }
        public void setEmpCompra(string id)
        {
            _empCompra.setFicha(id);
            _data.setEmpCompra(_empCompra.Item);
        }
        public void setEmpVentaTipo1(string id)
        {
            _empVentaTipo1.setFicha(id);
            _data.setEmpVentaTipo1(_empVentaTipo1.Item);
        }
        public void setEmpVentaTipo2(string id)
        {
            _empVentaTipo2.setFicha(id);
            _data.setEmpVentaTipo2(_empVentaTipo2.Item);
        }
        public void setEmpVentaTipo3(string id)
        {
            _empVentaTipo3.setFicha(id);
            _data.setEmpVentaTipo3(_empVentaTipo3.Item);
        }


        public void ListaPlu()
        {
            _gPlu.Inicializa();
            _gPlu.Inicia();
        }
        public void AgregarCodigoAlterno()
        {
            _gCodAlterno.Agregar();
        }
        public void EliminarCodigoAlterno()
        {
            _gCodAlterno.Eliminar();
        }


        abstract public void Inicializa();
        abstract public void Inicia();


        protected bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        abstract public void AbandonarFicha();


        protected bool _procesarIsOk;
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        abstract public void ProcesarFicha();


        virtual public bool CargarData() 
        {
            try
            {
                var _lst1 = new List<ficha>();
                var r01 = Sistema.MyData.Departamento_GetLista();
                foreach (var it in r01.Lista.OrderBy(o=>o.nombre).ToList())
                {
                    _lst1.Add(new ficha(it.auto, it.codigo, it.nombre));
                }
                _departamento.setData(_lst1);

                var _lst2 = new List<ficha>();
                var r02 = Sistema.MyData.Grupo_GetLista();
                foreach (var it in r02.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lst2.Add(new ficha(it.auto, it.codigo, it.nombre));
                }
                _grupo.setData(_lst2);

                var _lst3 = new List<ficha>();
                var r03 = Sistema.MyData.Marca_GetLista();
                foreach (var it in r03.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lst3.Add(new ficha(it.auto, "", it.nombre));
                }
                _marca.setData(_lst3);

                var _lst4 = new List<ficha>();
                var r04 = Sistema.MyData.TasaImpuesto_GetLista();
                foreach (var it in r04.Lista.OrderBy(o => o.tasa).ToList())
                {
                    _lst4.Add(new ficha(it.auto, "", it.ToString()));
                }
                _impuesto.setData(_lst4);

                var _lst5 = new List<ficha>();
                var r05 = Sistema.MyData.Producto_Categoria_Lista();
                foreach (var it in r05.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    _lst5.Add(new ficha(it.Id, "", it.Descripcion));
                }
                _categoria.setData(_lst5);

                var _lst6 = new List<ficha>();
                var r06 = Sistema.MyData.Producto_Origen_Lista();
                foreach (var it in r06.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    _lst6.Add(new ficha(it.Id, "", it.Descripcion));
                }
                _origen.setData(_lst6);

                var _lst7 = new List<ficha>();
                var r07 = Sistema.MyData.EmpaqueMedida_GetLista();
                foreach (var rg in r07.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lst7.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _empCompra.setData(_lst7);
                _empVentaTipo1.setData(_lst7);
                _empVentaTipo2.setData(_lst7);
                _empVentaTipo3.setData(_lst7);

                var _lst8 = new List<ficha>();
                var r08 = Sistema.MyData.Producto_AdmDivisa_Lista();
                foreach (var rg in r08.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    _lst8.Add(new ficha(rg.Id, "", rg.Descripcion));
                }
                _divisa.setData(_lst8);

                var _lst9 = new List<ficha>();
                var r09 = Sistema.MyData.Producto_Clasificacion_Lista();
                foreach (var rg in r09.Lista.OrderBy(o => o.Descripcion).ToList())
                {
                    _lst9.Add(new ficha(rg.Id, "", rg.Descripcion));
                }
                _clasificacion.setData(_lst9);

                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        abstract public bool IsAgregarEditarOk { get; }
        abstract public string AutoProductoAgregado { get; }
        public void setFicha(string id) 
        {
            _fichaEditar = id;
        }

    }

}