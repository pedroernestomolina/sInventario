using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroAdmDoc
{
    
    public interface IAdmDoc: IFiltro
    {

        BindingSource GetDepOrigen_Source { get; }
        BindingSource GetDepDestino_Source { get; }
        BindingSource GetEstatus_Source { get; }
        BindingSource GetConcepto_Source { get; }
        BindingSource GetTipoDoc_Source { get; }


        string GetDepOrigen_Id { get; }
        string GetDepDestino_Id { get; }
        string GetConcepto_Id { get; }
        string GetEstatus_Id { get; }
        string GetTipoDoc_Id { get; }
        DateTime GetFechaDesde { get; }
        DateTime GetFechaHasta { get; }


        void setDepOrigen(string id);
        void setDepDestino(string id);
        void setEstatus(string id);
        void setConcepto(string id);
        void setTipoDoc(string id);
        void setFechaDesde(DateTime fecha);
        void setFechaHasta(DateTime fecha);
        void setFechaDesdeEstatusOff();
        void setFechaHastaEstatusOff();


        bool CargarData();
        dataExportar ExportarData();


        BindingSource GetSucursal_Source { get; }
        string GetSucursal_Id { get; }
        void setSucursal(string id);


        string GetProducto_Desc { get; }
        bool GetHabilitarProducto { get; }
        void setProductoBuscar(string busc);
        void BuscarProducto();
        void LimpiarProducto();

    }

}