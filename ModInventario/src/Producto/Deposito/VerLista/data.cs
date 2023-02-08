using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.Deposito.VerLista
{
    public class data
    {
        private string _idDep;
        private string _codigoDep;
        private string _descDep;
        private int _empContenido;
        private string _decimales;
        private decimal _exFisica;
        private decimal _exReserva;
        private decimal _exDisponible;


        public string IdDep { get { return _idDep; } }
        public string CodigoDep { get { return _codigoDep; } }
        public string NombreDep { get { return _descDep; } }
        public decimal ExFisica { get { return porEmpaqueCompra(_exFisica); } }
        public string Fisica { get { return ExFisica.ToString("n" + _decimales); } }
        public decimal ExReserva { get { return porEmpaqueCompra(_exReserva); } }
        public string Reserva { get { return ExReserva.ToString("n" + _decimales); } }
        public decimal ExDisponible { get { return porEmpaqueCompra(_exDisponible); } }
        public string Disponible { get { return ExDisponible.ToString("n" + _decimales); } }


        public data(OOB.LibInventario.Producto.Data.Deposito dep, string decimales)
        {
            _idDep = dep.autoId;
            _codigoDep = dep.codigo;
            _descDep = dep.nombre;
            _empContenido = 1;
            _decimales = decimales;
            _exFisica = dep.exFisica;
            _exReserva = dep.exReserva;
            _exDisponible = dep.exDisponible;
        }


        public void setContenido(int cnt) 
        {
            _empContenido = cnt;
        }

        private decimal porEmpaqueCompra(decimal ex)
        {
            var r = 0m;
            if (_empContenido > 0m) 
            {
                r = ex / _empContenido;
            }
            return r;
        }
    }
}