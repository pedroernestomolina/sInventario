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
            Sistema.MotorDatos = new ConfiguracionMotorDatos(gestor:"MYSQL");
            var r01 = Helpers.Utilitis.CargarXml();
            if (r01.Result != OOB.Enumerados.EnumResult.isError)
            {
                Sistema.MyData = new DataProvInventario.Data.DataProv(Sistema.MotorDatos.Instancia, 
                                                                        Sistema.MotorDatos.BaseDatos, 
                                                                        Sistema.MotorDatos.Usuario.Trim(),
                                                                        Sistema.MotorDatos.Gestor.Trim().ToUpper()); 

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    src.IFabrica fabrica;
                    var r02 = Sistema.MyData.Empresa_Datos();
                    Sistema.Negocio = r02.Entidad;
                    if (!r02.Entidad.EsEmpresaPrincipal)
                    {
                        fabrica = new src.FabModoSoloReporte();
                    }
                    else
                    {
                        var r03 = Sistema.MyData.Configuracion_ModuloInventario_Modo();
                        switch (r03.Entidad)
                        {
                            case DataProvInventario.Enumerados.modoConfInventario.Basico:
                                fabrica = new src.FabModoBasico();
                                break;
                            case DataProvInventario.Enumerados.modoConfInventario.Sucursal:
                                fabrica = new src.FabModoSucursal();
                                break;
                            case DataProvInventario.Enumerados.modoConfInventario.BasicoFoxSystem:
                                fabrica = new src.FabModoBasicoFoxSystem();
                                break;
                            default:
                                throw new Exception("NO SE HA DEFINIDO UN MODO DE CONFIGURACION PARA INVENTARIO");
                        }
                    }
                     Identificacion.ILogin _gestionId = new Identificacion.ImpLogin();
                    _gestionId.Inicializa();
                    _gestionId.Inicia();
                    if (_gestionId.LoginIsOK)
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