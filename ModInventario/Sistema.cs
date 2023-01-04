using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario
{
    public class ConfiguracionMotorDatos
    {
        public string Instancia { get; set; }
        public string BaseDatos { get; set; }
        public string Usuario { get; set; }
        public string Gestor { get; set; }
        public string GetHost 
        {
            get 
            {
                return Instancia + "/" + BaseDatos;
            }
        }


        public ConfiguracionMotorDatos(string gestor="MYSQL")
        {
            this.Gestor = gestor;
        }
    }
    
    public class Sistema
    {
        static public string ID_USUARIO_ADMINISTRADOR { get { return "0000000001"; } }
        static public DataProvInventario.InfraEstructura.IData MyData;
        static public OOB.LibInventario.Usuario.Ficha UsuarioP;
        static public OOB.LibInventario.Empresa.Data.Ficha Negocio;
        static public ConfiguracionMotorDatos MotorDatos;
    }

}