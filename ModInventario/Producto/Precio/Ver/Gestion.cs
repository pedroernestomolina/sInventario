using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.Ver
{
    
    public class Gestion
    {

        private string _autoPrd;
        private string _prd;
        private string _tasa;
        private bool _admDivisa;
        private string _metodoCalculoUtilidad;
        private string _tasaCambioActual;
        private data _precio1;
        private data _precio2;
        private data _precio3;
        private data _precio4;
        private data _precio5;
        private data _mayor1;
        private data _mayor2;
        private data.enumModoPrecio _modoActual;
        private bool _isPreferenciaBusquedaNeto;


        public string Producto { get { return _prd; } }
        public string TasaIva { get { return _tasa; } }
        public bool AdmPorDivisa { get { return _admDivisa; } }
        public string MetodoCalculoUtilidad { get { return _metodoCalculoUtilidad; } }
        public string TasaCambioActual { get { return _tasaCambioActual; } }
        public string AdmDivisa { get { return (_admDivisa ? "SI" : "NO"); } }

        public data.enumModoPrecio ModoActual { get { return _modoActual; } }
        public data Precio1 { get { return _precio1; } }
        public data Precio2 { get { return _precio2; } }
        public data Precio3 { get { return _precio3; } }
        public data Precio4 { get { return _precio4; } }
        public data Precio5 { get { return _precio5; } }
        public data Mayor1 { get { return _mayor1; } }
        public data Mayor2 { get { return _mayor2; } }

        public bool PreferenciaBusquedaEsNeto { get { return _isPreferenciaBusquedaNeto; } }


        public Gestion()
        {
            _autoPrd="";
            _prd="";
            _tasa="";
            _admDivisa= false;
            _precio1 = new data();
            _precio2 = new data();
            _precio3 = new data();
            _precio4 = new data();
            _precio5 = new data();
            _mayor1 = new data();
            _mayor2 = new data();
        }


        public void Inicia() 
        {
            Limpiar();
            if (CargarData())
            {
                var frm = new VerFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        public void setFicha(string autoprd)
        {
            _autoPrd = autoprd;
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetPrecio(_autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Configuracion_TasaCambioActual ();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            var r03 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            var r04 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            _isPreferenciaBusquedaNeto = (r04.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Neto);

            var r05 = Sistema.MyData.Producto_GetCosto(_autoPrd);
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }

            var s=r01.Entidad;
            _prd = s.codigo + Environment.NewLine + s.descripcion;

            _tasa = "EXENTO";
            if (s.tasaIva > 0) 
            {
                _tasa = s.tasaIva.ToString("n2").Trim().PadLeft(5, '0') + "%";
            }

            _admDivisa = false;
            if (s.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si) 
            {
                _admDivisa = true;
            };

            _tasaCambioActual = r02.Entidad.ToString("n2");
            _metodoCalculoUtilidad = r03.Entidad.ToString();

            //var ut1 =CalculaUtilidad(s.precioNeto1, r05.Entidad.costoUnd, r03.Entidad);
            //var ut2 = CalculaUtilidad(s.precioNeto2, r05.Entidad.costoUnd, r03.Entidad);
            //var ut3 = CalculaUtilidad(s.precioNeto3, r05.Entidad.costoUnd, r03.Entidad);
            //var ut4 = CalculaUtilidad(s.precioNeto4, r05.Entidad.costoUnd, r03.Entidad);
            //var ut5 = CalculaUtilidad(s.precioNeto5, r05.Entidad.costoUnd, r03.Entidad);

            var ut1 = s.utilidad1;
            var ut2 = s.utilidad2;
            var ut3 = s.utilidad3;
            var ut4 = s.utilidad4;
            var ut5 = s.utilidad5;
            var utMay1 = s.utilidadMay1;
            var utMay2 = s.utilidadMay2;

            _precio1.setData(s.contenido1, s.empaque1, s.precioNeto1, ut1, s.precioFullDivisa1, s.tasaIva, s.etiqueta1);
            _precio2.setData(s.contenido2, s.empaque2, s.precioNeto2, ut2 , s.precioFullDivisa2, s.tasaIva, s.etiqueta2);
            _precio3.setData(s.contenido3, s.empaque3, s.precioNeto3, ut3 , s.precioFullDivisa3, s.tasaIva, s.etiqueta3);
            _precio4.setData(s.contenido4, s.empaque4, s.precioNeto4, ut4 , s.precioFullDivisa4, s.tasaIva, s.etiqueta4);
            _precio5.setData(s.contenido5, s.empaque5, s.precioNeto5, ut5 , s.precioFullDivisa5, s.tasaIva, s.etiqueta5);
            _mayor1.setData(s.contenidoMay1, s.empaqueMay1, s.precioNetoMay1, utMay1, s.precioFullDivisaMay1, s.tasaIva, s.etiquetaMay1);
            _mayor2.setData(s.contenidoMay2, s.empaqueMay2, s.precioNetoMay2, utMay2, s.precioFullDivisaMay2, s.tasaIva, s.etiquetaMay2);

            _modoActual = data.enumModoPrecio.Bolivar;
            if (_admDivisa) 
            {
                _modoActual = data.enumModoPrecio.Divisa;
            }
            CambiarModo();

            return rt;
        }

        private decimal CalculaUtilidad(decimal precio, decimal costo , OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad metodoCalculoUtilidad)
        {
            var rt = 0.0m;

            if (metodoCalculoUtilidad == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero)
            {
                if (precio>0)
                    rt = (1 - (costo / precio)) * 100;
                rt = Math.Round(rt,2, MidpointRounding.AwayFromZero);
            }
            else 
            {
                var x =  ((precio /costo)-1)* 100;
                rt = Math.Round(x, 2, MidpointRounding.AwayFromZero);
            }

            return rt;
        }

        private void Limpiar()
        {
            _prd = "";
            _tasa = "";
            _admDivisa = false;
            _precio1.Limpiar();
            _precio2.Limpiar();
            _precio3.Limpiar();
            _precio4.Limpiar();
            _precio5.Limpiar();
            _mayor1.Limpiar();
            _mayor2.Limpiar();
        }

        public void CambioModoPrecio()
        {
            if (_modoActual == data.enumModoPrecio.Bolivar)
            {
                _modoActual = data.enumModoPrecio.Divisa;
            }
            else
            {
                _modoActual = data.enumModoPrecio.Bolivar;
            }
            CambiarModo();
        }

        private void CambiarModo() 
        {
            _precio1.setModoPrecioActual(_modoActual);
            _precio2.setModoPrecioActual(_modoActual);
            _precio3.setModoPrecioActual(_modoActual);
            _precio4.setModoPrecioActual(_modoActual);
            _precio5.setModoPrecioActual(_modoActual);
            _mayor1.setModoPrecioActual(_modoActual);
            _mayor2.setModoPrecioActual(_modoActual);
        }

    }

}