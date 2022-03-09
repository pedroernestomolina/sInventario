using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario
{
    
    public class Sistema
    {

        static public DataProvInventario.InfraEstructura.IData MyData;
        static public OOB.LibInventario.Usuario.Ficha UsuarioP;
        static public OOB.LibInventario.Empresa.Data.Ficha Negocio;
        static public string _Instancia { get; set; }
        static public string _BaseDatos { get; set; }
        static public string _Usuario { get; set; }

        //

        static public string ID_USUARIO_ADMINISTRADOR { get { return "0000000001"; } }

    }

}