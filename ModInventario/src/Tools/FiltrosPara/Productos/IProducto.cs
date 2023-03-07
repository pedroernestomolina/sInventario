using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.FiltrosPara.Productos
{
    public interface IProducto: IFiltrosPara
    {
        filtrosExportar FiltrosExportar { get; }
        Tools.Filtros.Departamento.IDepartamento Departamento { get; }
        Tools.Filtros.Grupo.IGrupo Grupo { get; }
        Tools.Filtros.Marca.IMarca Marca { get; }
        Tools.Filtros.Origen.IOrigen Origen { get; }
        Tools.Filtros.TasaIva.ITasaIva TasaIva { get; }
        Tools.Filtros.Estatus.IEstatus Estatus { get; }
        Tools.Filtros.Divisa.IDivisa Divisa { get; }
        Tools.Filtros.Pesado.IPesado Pesado { get; }
        Tools.Filtros.Deposito.IDeposito Deposito { get; }
        Tools.Filtros.Catalogo.ICatalogo Catalogo { get; }
        Tools.Filtros.Categoria.ICategoria Categoria { get; }
        Tools.Filtros.Existencia.IExistencia Existencia { get; }
        Tools.Filtros.TCS.ITCS TCS { get; }
        Tools.Filtros.Proveedor.IProveedor Proveedor { get; }
        bool LimpiarFiltrosIsOk { get; }
    }
}