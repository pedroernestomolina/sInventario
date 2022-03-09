using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.Existencia
{

    public class data
    {

        private OOB.LibInventario.Visor.Existencia.Ficha rg;
        private OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor filtro;

        
        public string CodigoPrd { get { return rg.codigoPrd; } }
        public string NombrePrd { get { return rg.nombrePrd; } }
        public string Deposito { get { return rg.nombreDeposito; } }
        public string Departamento { get { return rg.nombreDepart; } }
        public decimal CntFisica { get { return rg.cntFisica; } }
        public string SCntFisica { get { return CntFisica.ToString("n"+rg.decimales); } }
        public bool EsPesado { get { return rg.esPesado == "S"; } }
        public string NivelMinimo 
        {
            get 
            {
                //if (filtro != OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.ExistenciaPorDebajoNivelMinimo) { return ""; }
                return rg.nivelMinimo.ToString("n0"); 
            } 
        }
        public string NivelOptimo 
        { 
            get 
            {
                //if (filtro != OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.ExistenciaPorDebajoNivelMinimo) { return ""; }
                return rg.nivelOptimo.ToString("n0"); 
            } 
        }
        public string Reponer 

        { 
            get 
            {
                if (filtro != OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor.ExistenciaPorDebajoNivelMinimo) { return ""; }
                var rt = 0.0m;
                rt = rg.nivelOptimo - rg.cntFisica;
                return rt.ToString("n"+rg.decimales); 
            } 
        }
        public int Estatus
        {
            get
            {
                var rt = 1;
                switch (rg.estatus.Trim().ToUpper())
                {
                    case "ACTIVO":
                        rt = 1;
                        break;
                    case "SUSPENDIDO":
                        rt = 2;
                        break;
                    case "INACTIVO":
                        rt = 3;
                        break;
                }
                return rt;
            }
        }

        public bool IsActivo { get { return (Estatus != 3); } }

        public data(OOB.LibInventario.Visor.Existencia.Ficha rg, OOB.LibInventario.Visor.Existencia.Enumerados.enumFiltrarPor filtro) 
        {
            this.rg = rg;
            this.filtro = filtro;
        }

    }

}