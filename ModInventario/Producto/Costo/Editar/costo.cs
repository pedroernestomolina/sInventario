using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Costo.Editar
{

    public class costo
    {

        private decimal undNeto;
        private decimal tasa;
        private decimal tasaCambio; 
        private int contEmp;
        private decimal empNeto;
        private decimal empFull;


        public decimal UndNeto { get { return undNeto; } }
        public decimal UndFull 
        { 
            get 
            {   
                CalculaEmpaqueFull(); 
                var rt = empFull / contEmp;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt; 
            } 
        }
        public decimal EmpNeto { get { return empNeto; } }
        public decimal EmpFull { get { return empFull; } }
        public decimal EmpNetoCambio 
        { 
            get 
            { 
                var rt=empNeto * tasaCambio;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            } 
        }


        public costo()
        {
            Limpiar();
        }

        private void Limpiar()
        {
            undNeto = 0.0m;
            tasa = 0.0m;
            contEmp = 0;
        }

        public void setFicha(decimal costoUnd, decimal iva, int cont, decimal tasCambio =1.0m)
        {
            undNeto = costoUnd;
            tasa=iva;
            contEmp=cont;
            tasaCambio = tasCambio;
            CalculaEmpaqueNeto();
            CalculaEmpaqueFull();
        }

        private void CalculaEmpaqueNeto()
        {
            empNeto = undNeto * contEmp;
            empNeto = Math.Round(empNeto, 2, MidpointRounding.AwayFromZero);
        }

        private void CalculaEmpaqueFull()
        {
            empFull = empNeto + (empNeto * tasa/100);
            empFull= Math.Round(empFull, 2, MidpointRounding.AwayFromZero);
        }

        public void setNeto(decimal valor)
        {
            undNeto = valor/contEmp;
            CalculaEmpaqueNeto();
            CalculaEmpaqueFull();
            undNeto = Math.Round(undNeto, 2, MidpointRounding.AwayFromZero);
        }

        public void setFull(decimal valor)
        {
            undNeto =  (valor / contEmp)/(1+(tasa/100));
            CalculaEmpaqueNeto();
            undNeto = Math.Round(undNeto, 2, MidpointRounding.AwayFromZero);
        }

        public void Limpia()
        {
            Limpiar();
        }

    }

}