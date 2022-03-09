using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Existencia
    {


        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public List<Deposito> depositos { get; set; }
        public string decimales { get; set; }
        public string empaque { get; set; }
        public int empaqueContenido { get; set; }


        public Existencia()
        {
            depositos = null;
            decimales = "0";
            empaque = "";
            empaqueContenido = 1;
            codigoPrd = "";
            nombrePrd = "";
        }

        public Existencia(Existencia ex)
            : this()
        {
            decimales = ex.decimales;
            empaque = ex.empaque;
            empaqueContenido = ex.empaqueContenido;
            codigoPrd = ex.codigoPrd;
            nombrePrd = ex.nombrePrd;
            depositos = ex.depositos.Select(s =>
            {
                var nr = new OOB.LibInventario.Producto.Data.Deposito()
                {
                    autoId = s.autoId,
                    codigo = s.codigo,
                    exDisponible = s.exDisponible,
                    exFisica = s.exFisica,
                    exReserva = s.exReserva,
                    nombre = s.nombre,
                };
                return nr;
            }).ToList();
        }

    }

}