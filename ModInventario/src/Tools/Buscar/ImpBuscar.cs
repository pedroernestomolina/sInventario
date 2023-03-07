using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Buscar
{
    public class ImpBuscar: IBuscar
    {
        private FiltrosGen.IOpcion _op;
        private string _cadena;
        private OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda _metBusqPref;


        public BindingSource Source { get { return _op.Source; } }
        public string Id { get { return _op.GetId; } }
        public string GetCadena { get { return _cadena; } }
        public dataExportar DataExportar { get { return infExportar(); } }


        public ImpBuscar()
        {
            _cadena = "";
            _op = new FiltrosGen.Opcion.Gestion();
            _metBusqPref = OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.SinDefinir;
        }


        public void Inicializa()
        {
            _cadena = "";
            _op.Inicializa();
            _metBusqPref = OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.SinDefinir;
        }
        public void CargarData()
        {
            var _lst = new List<ficha>();
            _lst.Add(new ficha("01", "", "Código"));
            _lst.Add(new ficha("02", "", "Descripción"));
            _lst.Add(new ficha("03", "", "Referencia"));
            _lst.Add(new ficha("04", "", "Cod/Barra"));
            _op.setData(_lst);

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            _metBusqPref = r01.Entidad;
            AsignarMetodoBusqueda(_metBusqPref);
        }
        public void LimpiarCargarMetPreferencia()
        {
            _cadena = "";
            AsignarMetodoBusqueda(_metBusqPref);
        }


        public void setCadena(string cadBuscar)
        {
            _cadena = cadBuscar;
        }
        public void setMetodo(string id)
        {
            _op.setFicha(id);
        }


        private void AsignarMetodoBusqueda(OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda metbusq)
        {
            switch (metbusq)
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorCodigo:
                    _op.setFicha("01");
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorNombre:
                    _op.setFicha("02");
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorReferencia:
                    _op.setFicha("03");
                    break;
            }
        }
        private dataExportar infExportar()
        {
            return new dataExportar()
            {
                Cadena = GetCadena,
                MetodoBusqueda = _op.Item,
            };
        }
    }
}