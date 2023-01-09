using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Filtro.FiltroRep.ModoSoloReporte
{
    
    public class dataFiltrar: baseData
    {

        public ficha Producto { get; set; }
        public ficha Sucursal { get; set; }
        public ficha Categoria { get; set; }
        public ficha Origen { get; set; }
        public ficha Precio { get; set; }
        public ficha EmpqPrecio { get; set; }


        public dataFiltrar()
            :base()
        {
            Producto = null;
            Sucursal = null;
            Categoria = null;
            Origen = null;
            Precio = null;
            EmpqPrecio = null;
        }


        public override void Limpiar()
        {
            base.Limpiar();
            Producto = null;
            Sucursal = null;
            Categoria = null;
            Origen = null;
            Precio = null;
            EmpqPrecio = null;
        }


        public override string ToString()
        {
            var t = base.ToString();
            if (Sucursal != null) t += ", Sucursal: " + Sucursal.desc;
            if (Categoria != null) t += ", Categoria: " + Categoria.desc;
            if (Origen != null) t += ", Origen: " + Origen.desc;
            if (Producto != null) t += ", Producto: " + Producto.desc;
            if (Precio != null) t += ", Precio: " + Precio.desc;
            if (EmpqPrecio != null) t += ", Empaque Precio: " + EmpqPrecio.desc;
            return t;
        }

    }

}