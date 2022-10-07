using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var r01 = Helpers.Utilitis.CargarXml();
            if (r01.Result != OOB.Enumerados.EnumResult.isError)
            {
                if (Sistema._Usuario.Trim() == "")
                {
                    Sistema.MyData = new DataProvInventario.Data.DataProv(Sistema._Instancia, Sistema._BaseDatos);
                }
                else 
                {
                    Sistema.MyData = new DataProvInventario.Data.DataProv(Sistema._Instancia, Sistema._BaseDatos, Sistema._Usuario);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    src.IFabrica fabrica;
                    var r02 = Sistema.MyData.Empresa_Datos();
                    Sistema.Negocio = r02.Entidad;
                    var r03 = Sistema.MyData.Configuracion_ModuloInventario_Modo();
                    switch(r03.Entidad)
                    {
                        case DataProvInventario.Enumerados.modoConfInventario.Basico:
                            fabrica= new src.FabModoBasico();
                            break;
                        case DataProvInventario.Enumerados.modoConfInventario.Sucursal:
                            fabrica= new src.FabModoSucursal();
                            break;
                        default:
                            throw new Exception("NO SE HA DEFINIDO UN MODO DE CONFIGURACION PARA INVENTARIO");
                    }
                    var _gestionId = new Identificacion.Gestion();
                    _gestionId.Inicia();
                    if (_gestionId.IsUsuarioOk)
                    {
                        var _gestionInv = new GestionInv(fabrica);
                        _gestionInv.Inicia();
                    }
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                    Application.Exit();
                }
            }
            else 
            {
                Helpers.Msg.Error(r01.Mensaje);
                Application.Exit();
            }
        }
    }
}