using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ModInventario.Helpers
{

    public class Utilitis
    {

        public class Precio 
        {
            private decimal tasaCambio;
            public decimal neto { get; set; }
            public decimal full { get; set; }
            public decimal netoDivisa { get { return neto / tasaCambio; } }
            public decimal fullDivisa { get { return full / tasaCambio; } }


            public Precio()
            {
                tasaCambio = 0.0m;
                neto = 0.0m;
                full = 0.0M;
            }


            public void setTasaCambio(decimal tasa) 
            {
                tasaCambio = tasa;
            }
        }

        static public OOB.Resultado CargarXml()
        {
            var result = new OOB.Resultado();

            try
            {
                var doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Conf.XML");

                if (doc.HasChildNodes)
                {
                    foreach (XmlNode nd in doc)
                    {
                        if (nd.LocalName.ToUpper().Trim() == "CONFIGURACION")
                        {
                            foreach (XmlNode nv in nd.ChildNodes)
                            {
                                if (nv.LocalName.ToUpper().Trim() == "SERVIDOR")
                                {
                                    foreach (XmlNode sv in nv.ChildNodes)
                                    {
                                        if (sv.LocalName.Trim().ToUpper() == "INSTANCIA")
                                        {
                                            Sistema._Instancia = sv.InnerText.Trim();
                                        }
                                        if (sv.LocalName.Trim().ToUpper() == "CATALOGO")
                                        {
                                            Sistema._BaseDatos = sv.InnerText.Trim();
                                        }
                                        if (sv.LocalName.Trim().ToUpper() == "USUARIO")
                                        {
                                            Sistema._Usuario = sv.InnerText.Trim();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Result = OOB.Enumerados.EnumResult.isError;
                result.Mensaje = e.Message;
            }

            return result;
        }

        public static Precio RecalcularPrecio(
            decimal cneto, decimal ut, decimal tasa, 
            OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio enumPreferenciaRegistroPrecio, 
            OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta enumForzarRedondeoPrecioVenta,
            OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad enumMetodoCalculoUtilidad,
            decimal tasaCambio)
        {
            var rt = new Precio();
            rt.setTasaCambio(tasaCambio);
            

            var m = 0.0m;
            if (enumMetodoCalculoUtilidad == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero)
            {
                if (ut==100.0m && cneto == 0.0m)
                    m = 0.0m;
                else
                    if (ut == 100)
                    {
                    }
                    else
                    {
                        m = cneto / ((100 - ut) / 100);
                    }
            }
            else 
            {
                m = cneto + (cneto*ut/100);
            }

            if (enumPreferenciaRegistroPrecio == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full)
            {
                m += (m * tasa / 100);
            }

            switch (enumForzarRedondeoPrecioVenta) 
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.SinRedeondeo:
                    m = Math.Round(m, 2, MidpointRounding.AwayFromZero);
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
                    m =  Helpers.MetodosExtension.RoundUnidad( (int)m);
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
                    m =  Helpers.MetodosExtension.RoundDecena( (int)m);
                    break;
            }

            if (enumPreferenciaRegistroPrecio == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full)
            {
                rt.full = m;
                rt.neto = m / ((tasa / 100) + 1);
            }
            else 
            {
                rt.neto = m;
                rt.full= m+ (m * tasa / 100);
            }

            return rt;
        }

    }

}