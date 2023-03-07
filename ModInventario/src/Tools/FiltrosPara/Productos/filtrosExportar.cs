using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools.FiltrosPara.Productos
{
    public class filtrosExportar
    {
        public ficha Deposito { get; set; }
        public ficha Catalogo { get; set; }
        public ficha Oferta { get; set; }
        public ficha Categoria { get; set; }
        public ficha Existencia { get; set; }
        public ficha Departamento { get; set; }
        public ficha Grupo { get; set; }
        public ficha Marca { get; set; }
        public ficha Origen { get; set; }
        public ficha Estatus { get; set; }
        public ficha TasaIva { get; set; }
        public ficha AdmDivisa { get; set; }
        public ficha Pesado { get; set; }
        public ficha Proveedor { get; set; }
        public ficha TCS { get; set; }


        public filtrosExportar()
        {
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }


        public bool FiltrosIsOk()
        {
            if (Deposito != null) return true;
            if (Catalogo != null) return true;
            if (Categoria != null) return true;
            if (Oferta != null) return true;
            if (Existencia != null) return true;
            if (Departamento != null) return true;
            if (Grupo != null) return true;
            if (Marca != null) return true;
            if (Origen != null) return true;
            if (TasaIva != null) return true;
            if (Estatus != null) return true;
            if (AdmDivisa != null) return true;
            if (Pesado != null) return true;
            if (Proveedor != null) return true;
            if (TCS != null) return true;
            return false;
        }


        private void limpiar()
        {
            Deposito = null;
            Categoria = null;
            Catalogo = null;
            Oferta = null;
            Existencia = null;
            Departamento = null;
            Grupo = null;
            Marca = null;
            Origen = null;
            Estatus = null;
            TasaIva = null;
            AdmDivisa = null;
            Pesado = null;
            Proveedor = null;
            TCS = null;
        }
    }
}