using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.AgregarEditar
{
    
    public class baseDataAgregarEditar
    {

        private string _codigoPrd;
        private string _descripcionPrd;
        private string _nombrePrd;
        private string _plu;
        private int _diasEmpaque;
        private bool _pesado;
        private int _contEmpCompra;
        private int _contEmpVentaTipo1;
        private int _contEmpVentaTipo2;
        private int _contEmpVentaTipo3;
        private ficha _departamento;
        private ficha _grupo;
        private ficha _divisa;
        private ficha _clasificacion;
        private ficha _categoria;
        private ficha _origen;
        private ficha _impuesto;
        private ficha _marca;
        private ficha _empCompra;
        private ficha _empVentaTipo1;
        private ficha _empVentaTipo2;
        private ficha _empVentaTipo3;


        public string GetCodigoProducto { get { return _codigoPrd; } }
        public string GetDescripcionProducto { get { return _descripcionPrd; } }
        public string GetNombreProducto { get { return _nombrePrd; } }
        public string GetPlu { get { return _plu; } }
        public bool GetEsPesado { get { return _pesado; } }
        public int GetContEmpVentaTipo1 { get { return _contEmpVentaTipo1; } }
        public int GetContEmpVentaTipo2 { get { return _contEmpVentaTipo2; } }
        public int GetContEmpVentaTipo3 { get { return _contEmpVentaTipo3; } }
        public int GetContEmpCompra { get { return _contEmpCompra; } }
        public int GetDiasEmpaque { get { return _diasEmpaque; } }
        public ficha GetDepartamento { get { return _departamento; } }
        public ficha GetGrupo { get { return _grupo; } }
        public ficha GetDivisa { get { return _divisa; } }
        public ficha GetClasificacion { get { return _clasificacion; } }
        public ficha GetCategoria { get { return _categoria; } }
        public ficha GetOrigen { get { return _origen; } }
        public ficha GetImpuesto { get { return _impuesto; } }
        public ficha GetMarca { get { return _marca; } }
        public ficha GetEmpCompra { get { return _empCompra; } }
        public ficha GetEmpVentaTipo1 { get { return _empVentaTipo1; } }
        public ficha GetEmpVentaTipo2 { get { return _empVentaTipo2; } }
        public ficha GetEmpVentaTipo3 { get { return _empVentaTipo3; } }


        public void setCodigoProducto(string v)
        {
            _codigoPrd = v;
        }
        public void setDescripcionProducto(string v)
        {
            _descripcionPrd = v;
        }
        public void setPesado(bool v)
        {
            _pesado = v;
        }
        public void setContEmpVentaTipo3(int v)
        {
            _contEmpVentaTipo3 = v;
        }
        public void setContEmpVentaTipo2(int v)
        {
            _contEmpVentaTipo2 = v;
        }
        public void setPlu(string v)
        {
            _plu=v;
        }
        public void setDiasEmpaque(int v)
        {
            _diasEmpaque=v;
        }
        public void setContEmpVentaTipo1(int v)
        {
            _contEmpVentaTipo1 = v;
        }
        public void setNombreProducto(string v)
        {
            _nombrePrd = v;
        }
        public void setContEmpCompra(int v)
        {
            _contEmpCompra=v;
        }


        public baseDataAgregarEditar()
        {
            _codigoPrd = "";
            _descripcionPrd = "";
            _nombrePrd = "";
            _plu = "";
            _diasEmpaque = 0;
            _pesado = false;
            _contEmpCompra = 0;
            _contEmpVentaTipo1 = 0;
            _contEmpVentaTipo2 = 0;
            _contEmpVentaTipo3 = 0;
            _departamento = null;
            _grupo = null;
            _divisa=null;
            _clasificacion=null;
            _categoria=null;
            _origen=null;
            _impuesto=null;
            _marca=null;
            _empCompra=null;
            _empVentaTipo1=null;
            _empVentaTipo2=null;
            _empVentaTipo3=null;
        }


        virtual public void Inicializa()
        {
            _codigoPrd = "";
            _descripcionPrd = "";
            _nombrePrd = "";
            _plu = "";
            _diasEmpaque = 0;
            _pesado = false;
            _contEmpCompra = 0;
            _contEmpVentaTipo1 = 0;
            _contEmpVentaTipo2 = 0;
            _contEmpVentaTipo3 = 0;
            _departamento = null;
            _grupo = null;
            _divisa = null;
            _clasificacion = null;
            _categoria = null;
            _origen = null;
            _impuesto = null;
            _marca = null;
            _empCompra = null;
            _empVentaTipo1 = null;
            _empVentaTipo2 = null;
            _empVentaTipo3 = null;
        }


      virtual public bool ValidarDataIsOk()
        {
            if (_codigoPrd.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ CODIGO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_descripcionPrd.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ DESCRIPCION ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_contEmpCompra == 0)
            {
                Helpers.Msg.Error("CAMPO [ CONTENIDO EMPAQUE DE COMPRA ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_contEmpVentaTipo1 == 0)
            {
                Helpers.Msg.Error("CAMPO [ CONTENIDO EMPAQUE DE VENTA TIPO (1) ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_contEmpVentaTipo2 == 0)
            {
                Helpers.Msg.Error("CAMPO [ CONTENIDO EMPAQUE DE VENTA TIPO (2) ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_contEmpVentaTipo3 == 0)
            {
                Helpers.Msg.Error("CAMPO [ CONTENIDO EMPAQUE DE VENTA TIPO (3) ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_departamento == null || _departamento.id == "")
            {
                Helpers.Msg.Error("CAMPO [ DEPARTAMENTO ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_grupo == null || _grupo.id == "")
            {
                Helpers.Msg.Error("CAMPO [ GRUPO ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_marca == null || _marca.id == "")
            {
                Helpers.Msg.Error("CAMPO [ MARCA ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_divisa == null || _divisa.id == "")
            {
                Helpers.Msg.Error("CAMPO [ ADMINISTRADOR POR DIVISA ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_clasificacion == null || _clasificacion.id == "")
            {
                Helpers.Msg.Error("CAMPO [ CLASIFICACION ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_categoria == null || _categoria.id == "")
            {
                Helpers.Msg.Error("CAMPO [ CATEGORIA ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_origen == null || _origen.id == "")
            {
                Helpers.Msg.Error("CAMPO [ ORIGEN ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_impuesto == null || _impuesto.id == "")
            {
                Helpers.Msg.Error("CAMPO [ IMPUESTO ] NO PUEDE SER CERO(0)");
                return false;
            }
            if (_empCompra == null || _empCompra.id=="")
            {
                Helpers.Msg.Error("CAMPO [ EMPAQUE DE COMPRA ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_empVentaTipo1 == null || _empVentaTipo1.id == "")
            {
                Helpers.Msg.Error("CAMPO [ EMPAQUE DE VENTA TIPO 1 ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_empVentaTipo2 == null || _empVentaTipo2.id == "")
            {
                Helpers.Msg.Error("CAMPO [ EMPAQUE DE VENTA TIPO 2 ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_empVentaTipo3 == null || _empVentaTipo3.id == "")
            {
                Helpers.Msg.Error("CAMPO [ EMPAQUE DE VENTA TIPO 3 ] NO PUEDE ESTAR VACIO");
                return false;
            }
            return true;
        }


        public void setDepartamento(ficha f)
        {
            _departamento = f;
        }
        public void setGrupo(ficha f)
        {
            _grupo = f;
        }
        public void setDivisa(ficha f)
        {
            _divisa = f;
        }
        public void setClasificacion(ficha f)
        {
            _clasificacion = f;
        }
        public void setCategoria(ficha f)
        {
            _categoria = f;
        }
        public void setOrigen(ficha f)
        {
            _origen = f;
        }
        public void setImpuesto(ficha f)
        {
            _impuesto = f;
        }
        public void setMarca(ficha f)
        {
            _marca = f;
        }
        public void setEmpCompra(ficha f)
        {
            _empCompra = f;
        }
        public void setEmpVentaTipo1(ficha f)
        {
            _empVentaTipo1 = f;
        }
        public void setEmpVentaTipo2(ficha f)
        {
            _empVentaTipo2 = f;
        }
        public void setEmpVentaTipo3(ficha f)
        {
            _empVentaTipo3 = f;
        }

    }

}