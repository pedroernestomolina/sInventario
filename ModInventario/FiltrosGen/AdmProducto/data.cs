using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen.AdmProducto
{

    public class data
    {
        
        public enum enumMetBusqueda {SinDefinir=-1, PorCodigo=1, PorNombre, PorReferencia, PorCodigoBarra};


        private string _cadenaBusq ;
        private enumMetBusqueda _metBusqueda;


        public ficha Departamento { get; set; }
        public ficha Grupo { get; set; }
        public ficha Marca { get; set; }
        public ficha Deposito { get; set; }
        public ficha Categoria { get; set; }
        public ficha Origen { get; set; }
        public ficha Estatus { get; set; }
        public ficha TasaIva { get; set; }
        public ficha AdmDivisa { get; set; }
        public ficha Pesado { get; set; }
        public ficha Catalogo { get; set; }
        public ficha Existencia { get; set; }
        public ficha Oferta { get; set; }
        public ficha PrecioMayor { get; set; }
        public ficha Proveedor { get; set; }
        public string CadenaBusq { get { return _cadenaBusq; } }
        public enumMetBusqueda MetBusqueda { get { return _metBusqueda; } }


        public data() 
        {
            _metBusqueda = enumMetBusqueda.SinDefinir ;
            _cadenaBusq = "";
            limpiar();
        }


        public void setCadenaBusq(string cadena)
        {
            _cadenaBusq = cadena;
        }
        public void setMetBusqByCodigo()
        {
            _metBusqueda= enumMetBusqueda.PorCodigo;
        }
        public void setMetBusqByNombre()
        {
            _metBusqueda = enumMetBusqueda.PorNombre;
        }
        public void setMetBusqByReferencia()
        {
            _metBusqueda = enumMetBusqueda.PorReferencia;
        }


        public bool FiltrarIsOk()
        {
            if (CadenaBusq.Trim() != "") return true;
            if (Proveedor != null) return true;
            if (Departamento != null) return true;
            if (Grupo != null) return true;
            if (Marca != null) return true;
            if (Deposito != null) return true;
            if (Categoria != null) return true;
            if (Origen != null) return true;
            if (TasaIva != null) return true;
            if (Estatus != null) return true;
            if (AdmDivisa != null) return true;
            if (Pesado != null) return true;
            if (Oferta != null) return true;
            if (Existencia != null) return true;
            if (Catalogo != null) return true;
            if (PrecioMayor != null) return true;
            return false;
       }

        public void Limpiar()
        {
            limpiar();
        }


        private void limpiar()
        {
            _cadenaBusq = "";
            Departamento = null;
            Grupo = null;
            Marca = null;
            Deposito = null;
            Categoria = null;
            Origen = null;
            Estatus = null;
            TasaIva = null;
            Catalogo = null;
            AdmDivisa = null;
            Pesado = null;
            Existencia = null;
            Oferta = null;
            PrecioMayor = null;
            Proveedor = null;
        }

        public void setMetBusqByCodigoBarra()
        {
            _metBusqueda = enumMetBusqueda.PorCodigoBarra;
        }

    }

}