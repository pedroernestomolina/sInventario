using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroRep.ModoSucursal
{

    public interface IModoSucursal: IFiltro
    {
        BindingSource GetSucursal_Source { get; }
        BindingSource GetCategoria_Source { get; }
        BindingSource GetOrigen_Source { get; }


        string GetSucursal_Id { get; }
        string GetCategoria_Id { get; }
        string GetOrigen_Id { get; }
        string GetProducto { get; }


        bool GetHabilitarSucursal { get; }
        bool GetHabilitarOrigen { get; }
        bool GetHabilitarCategoria { get; }
        bool GetHabilitarProducto { get; }


        void setSucursal(string id);
        void setCategoria(string id);
        void setOrigen(string id);
        void setProducto(string desc);


        bool LimpiarProductoIsOk { get; }
        void LimpiarProducto();


        bool ProductoIsOk { get; }
        void BuscarProducto();
    }

}