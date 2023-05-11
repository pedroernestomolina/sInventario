using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.BusqProducto.CtrlMetodoBusq
{
    public class ImpComp: IComp
    {
        private string _metBusqPref;
        private LibUtilitis.CtrlCB.ICtrl _ctrl;


        public LibUtilitis.CtrlCB.ICtrl Ctrl { get { return _ctrl; } }


        public ImpComp()
        {
            _metBusqPref = "";
            _ctrl = new LibUtilitis.CtrlCB.ImpCB();
        }


        public void Inicializa()
        {
            _ctrl.Inicializa();
        }
        public void CargarData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            _lst.Add(new Filtros.dataFiltro() { id = "01", codigo = "", desc = "Código" });
            _lst.Add(new Filtros.dataFiltro() { id = "02", codigo = "", desc = "Descripción" });
            _lst.Add(new Filtros.dataFiltro() { id = "03", codigo = "", desc = "Referencia" });
            _lst.Add(new Filtros.dataFiltro() { id = "04", codigo = "", desc = "Cod/Barra" });
            _ctrl.CargarData(_lst);

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            switch (r01.Entidad) 
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorCodigo:
                    _metBusqPref = "01";
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorNombre:
                    _metBusqPref = "02";
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorReferencia:
                    _metBusqPref = "03";
                    break;
            }
            Limpiar();
        }
        public void Limpiar()
        {
            _ctrl.setFichaById(_metBusqPref);
        }
    }
}