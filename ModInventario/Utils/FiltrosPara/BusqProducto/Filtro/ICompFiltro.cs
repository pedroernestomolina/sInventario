using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara.BusqProducto.Filtro
{
    public interface ICompFiltro: IFiltro
    {
        Utils.Filtros.IDepartamentoGrupo DepartamentoGrupo { get; }
        Utils.Filtros.IFiltro Marca { get; }
        Utils.Filtros.IFiltro Origen { get; }
        Utils.Filtros.IFiltro TasaIva { get; }
        Utils.Filtros.IFiltro Estatus { get; }
        Utils.Filtros.IFiltro Divisa { get; }
        Utils.Filtros.IFiltro Pesado { get; }
        Utils.Filtros.IFiltro Deposito { get; }
        Utils.Filtros.IFiltro Catalogo { get; }
        Utils.Filtros.IFiltro Categoria { get; }
        Utils.Filtros.IFiltro Existencia { get; }
        Utils.Filtros.IFiltro TCS { get; }
        Utils.Filtros.IFiltro Oferta { get; }
        Utils.Filtros.BuscarPor.IFiltro Proveedor { get; }

        bool CargarData();
        void LimpiarFiltros();
    }
}