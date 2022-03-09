using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Deposito
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string estatusActivo { get; set; }
        public string estatusPredeterminado { get; set; }
        public string autoSucursal { get; set; }
        public string nombreSucursal { get; set; }
        public string codigoSucursal { get; set; }
        public bool IsActivo { get { return estatusActivo == "1"; } }
        public bool IsPerDeterminado { get { return estatusPredeterminado == "1"; } }


        public Ficha()
        {
            Limpiar();
        }

        public Ficha(Ficha it)
            : this()
        {
            auto = it.auto;
            autoSucursal = it.autoSucursal;
            codigo = it.codigo;
            codigoSucursal = it.codigoSucursal;
            nombre = it.nombre;
            nombreSucursal = it.nombreSucursal;
            estatusActivo = it.estatusActivo;
            estatusPredeterminado = it.estatusPredeterminado;
        }

        public void Limpiar() 
        {
            auto = "";
            autoSucursal = "";
            codigo = "";
            codigoSucursal = "";
            nombre = "";
            nombreSucursal = "";
            estatusActivo = "";
            estatusPredeterminado = "";
        }

    }

}