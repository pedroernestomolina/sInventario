using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Deposito.Listar
{

    public class data
    {

        private OOB.LibInventario.Producto.Data.Deposito _deposito; 
        private int _empContenido;
        private string _decimales;

        public string CodigoDep { get { return _deposito.codigo; } }
        public string NombreDep { get { return _deposito.nombre; } }
        public decimal ExFisica 
        {
            get 
            {
                var ex = 0.0m;
                ex = _deposito.exFisica / _empContenido;
                return ex;
            }
        }
        public string Fisica { get { return ExFisica.ToString("n" + _decimales); } }

        public decimal ExReserva
        {
            get
            {
                var ex = 0.0m;
                ex = _deposito.exReserva / _empContenido;
                return ex;
            }
        }
        public string Reserva { get { return ExReserva.ToString("n" + _decimales); } }

        public decimal ExDisponible
        {
            get
            {
                var ex = 0.0m;
                ex = _deposito.exDisponible / _empContenido;
                return ex;
            }
        }
        public string Disponible { get { return ExDisponible.ToString("n" + _decimales); } }

        public OOB.LibInventario.Producto.Data.Deposito Deposito 
        {
            get 
            {
                return _deposito;
            }
        }


        public data(OOB.LibInventario.Producto.Data.Deposito dep, string decimales)
        {
            _deposito = dep;
            _empContenido = 1;
            _decimales = decimales;
        }

        public void setContenido(int cnt) 
        {
            _empContenido = cnt;
        }

    }

}