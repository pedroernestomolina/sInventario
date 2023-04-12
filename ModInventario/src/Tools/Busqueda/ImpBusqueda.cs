using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Busqueda
{
    public class ImpBusqueda: IBusqueda
    {
        private Buscar.IBuscar _buscar;
        private FiltrosGen.AdmProducto.IAdmProducto _filtros;
        private bool _buscarIsOk;


        public BindingSource GetMetBusquedaSource { get { return _buscar.Source; } }
        public string GetMetBusquedaId { get { return _buscar.Id; } }
        public bool BuscarIsOk { get { return _buscarIsOk; } }
        public string GetCadenaBusqueda { get { return _buscar.GetCadena; } }
        public object FiltrosExportar { get { return _filtros.FiltrosExportar; } }


        public ImpBusqueda(FiltrosGen.AdmProducto.IAdmProducto filtro)
        {
            _buscarIsOk = false;
            _buscar = new Buscar.ImpBuscar();
            _filtros = filtro;
        }


        public void setCadenaBusqueda(string cad)
        {
            _buscar.setCadena(cad);
        }
        public void setMetBusqueda(string id)
        {
            _buscar.setMetodo(id);
        }

        public void Inicializa()
        {
            _buscarIsOk = false;
            _buscar.Inicializa();
            _filtros.Inicializa();
        }
        public void CargarData()
        {
            _buscar.CargarData();
        }
        public void ActivarFiltros()
        {
            _filtros.Inicia();
        }
        public void LimpiarTodo()
        {
            _buscar.LimpiarCargarMetPreferencia();
            _filtros.LimpiarFiltros();
        }
        public void Buscar()
        {
            _buscarIsOk = false;
            _filtros.setCadenaBusc(_buscar.GetCadena);
            switch (_buscar.Id)
            {
                case "01":
                    _filtros.setMetBusqByCodigo();
                    break;
                case "02":
                    _filtros.setMetBusqByNombre();
                    break;
                case "03":
                    _filtros.setMetBusqByReferencia();
                    break;
                case "04":
                    _filtros.setMetBusqByCodigoBarra();
                    break;
            }
            if (_filtros.DataFiltrarIsOk())
            {
                _buscarIsOk = true;
            }
        }
    }
}