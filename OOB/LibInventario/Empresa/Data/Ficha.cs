using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Empresa.Data
{
    
    public class Ficha
    {

        public string Nombre { get; set; }
        public string CiRif { get; set; }
        public string DireccionFiscal { get; set; }
        public string Telefono { get; set; }
        public string CodigoEmpresa { get; set; }
        public string CodigoDepositoPrincipal { get; set; }
        public bool EsEmpresaPrincipal { get { return CodigoEmpresa == "01"; } }


        public Ficha()
        {
            Nombre = "";
            CiRif = "";
            DireccionFiscal = "";
            Telefono = "";
            CodigoEmpresa = "";
            CodigoDepositoPrincipal = "";
        }

    }

}