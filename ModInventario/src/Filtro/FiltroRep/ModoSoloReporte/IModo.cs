using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroRep.ModoSoloReporte
{

    public interface IModo: IFiltroRep
    {
        BindingSource GetSucursal_Source { get; }
        BindingSource GetCategoria_Source { get; }
        BindingSource GetOrigen_Source { get; }


        string GetSucursal_Id { get; }
        string GetCategoria_Id { get; }
        string GetOrigen_Id { get; }


        bool GetHabilitarSucursal { get; }
        bool GetHabilitarOrigen { get; }
        bool GetHabilitarCategoria { get; }
        bool GetHabilitarProducto { get; }


        void setSucursal(string id);
        void setCategoria(string id);
        void setOrigen(string id);


        string GetProducto { get; }
        bool LimpiarProductoIsOk { get; }
        bool ProductoIsOk { get; }
        void setProducto(string desc);
        void BuscarProducto();
        void LimpiarProducto();


        BindingSource GetPrecio_Source { get; }
        string GetPrecio_Id { get; }
        bool GetHabilitarPrecio { get;  }
        void setPrecio(string id);

        bool GetHabilitarEmpaquePrecio { get; }
        string GetEmpaquePrecio_Id { get; }
        BindingSource GetEmpaquePrecio_Source { get; }
        void setEmpqPrecio(string id);
    }

}