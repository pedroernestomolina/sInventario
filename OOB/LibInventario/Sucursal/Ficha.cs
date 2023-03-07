
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Sucursal
{
    public class Ficha
    {
        public string auto { get; set; }
        public string autoDepositoPrincipal { get; set; }
        public string autoEmpresaGrupo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string codigoDepositoPrincipal { get; set; }
        public string nombreDepositoPrincipal { get; set; }
        public string nombreEmpresaGrupo { get; set; }
        public string Estatus{ get; set; }
        public bool IsActivo { get { return Estatus.Trim().ToUpper() == "1"; } }


        public Ficha()
        {
            auto = "";
            autoDepositoPrincipal = "";
            autoEmpresaGrupo = "";
            codigo = "";
            nombre = "";
            codigoDepositoPrincipal = "";
            nombreDepositoPrincipal = "";
            nombreEmpresaGrupo = "";
            Estatus = "";
        }
    }
}