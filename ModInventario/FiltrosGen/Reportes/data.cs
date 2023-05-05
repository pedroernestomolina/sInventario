using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.FiltrosGen.Reportes
{
    public class data: IData
    {
        private bool _validarFecha;


        public ficha Depart { get; set; }
        public ficha Deposito { get; set; }
        public ficha Grupo { get; set; }
        public ficha Marca { get; set; }
        public ficha TasaIva { get; set; }
        public ficha Divisa { get; set; }
        public ficha Estatus { get; set; }
        public ficha Origen { get; set; }
        public ficha Categoria { get; set; }
        public ficha Sucursal { get; set; }
        public ficha Producto { get; set; }
        public DateTime? Desde  { get; set; }
        public DateTime? Hasta { get; set; }
        public ficha Pesado { get; set; }
        public ficha Precio { get; set; }
        public ficha EmpqPrecio { get; set; }
        public ficha Oferta { get; set; }
        public ficha Concepto { get; set; }

        public data() 
        {
            _validarFecha = true;
            limpiar();
        }


        public void Limpiar()
        {
            limpiar();
        }

        public bool IsOk()
        {
            if (Desde.HasValue && Hasta.HasValue) 
            {
                if (Desde.Value > Hasta.Value)
                {
                    Helpers.Msg.Error("FECHAS INCORRECTAS, VERIFIQUE POR FAVOR");
                    return false;
                }
            }
            if (Depart != null) return true;
            if (Deposito != null) return true;
            if (Grupo!= null) return true;
            if (Marca!= null) return true;
            if (TasaIva != null) return true;
            if (Divisa!= null) return true;
            if (Estatus!= null) return true;
            if (Origen != null) return true;
            if (Categoria != null) return true;
            if (Producto != null) return true;
            if (Sucursal!= null) return true;
            if (Oferta != null) return true;
            if (_validarFecha)
            {
                if (Desde.HasValue) return true;
                if (Hasta.HasValue) return true;
            }
            return false;
        }

        private void limpiar()
        {
            Depart = null;
            Deposito = null;
            Grupo = null;
            Marca = null;
            TasaIva = null;
            Estatus = null;
            Origen = null;
            Categoria = null;
            Sucursal = null;
            Producto = null;
            Divisa = null;
            Pesado = null;
            Precio = null;
            EmpqPrecio = null;
            Oferta = null;
            Desde = DateTime.Now.Date;
            Hasta = DateTime.Now.Date;
        }

        public override string ToString()
        {
            var t = "";
            if (Desde.HasValue)t += "Desde: " + Desde.Value.ToShortDateString();
            if (Hasta.HasValue) t += ", Hasta: " + Hasta.Value.ToShortDateString();
            if (Depart!=null) t += ", Departamento: " + Depart.desc;
            if (Deposito!= null) t += ", Deposito: " + Deposito.desc;
            if (Grupo!= null) t += ", Grupo: " + Grupo.desc;
            if (Marca!= null) t += ", Marca: " + Marca.desc;
            if (Divisa!= null) t += ", Divisa: " + Divisa.desc;
            if (Origen!= null) t += ", Origen: " + Origen.desc;
            if (Estatus!= null) t += ", Estatus: " + Estatus.desc;
            if (Sucursal!= null) t += ", Sucursal: " + Sucursal.desc;
            if (Categoria != null) t += ", Categoria: " + Categoria.desc;
            if (Producto!= null) t += ", Producto: " + Producto.desc;
            if (TasaIva != null) t += ", Tasa Iva: " + TasaIva;
            if (Pesado != null) t += ", Pesado: " + Pesado.desc;
            if (Precio != null) t += ", Precio: " + Precio.desc;
            if (EmpqPrecio != null) t += ", Empaque Precio: " + EmpqPrecio.desc;
            if (Oferta != null) t += ", Oferta: " + Oferta.desc;
            return t;
        }

        public void setValidarFecha(bool p)
        {
            _validarFecha = p;
        }
    }
}