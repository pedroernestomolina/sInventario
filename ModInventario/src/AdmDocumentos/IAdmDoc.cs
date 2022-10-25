using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.AdmDocumentos
{
    
    public interface IAdmDoc: IGestion
    {

        string GetTitulo { get; }
        BindingSource GetData_Source { get; }
        BindingSource GetTipoDoc_Source { get; }
        DateTime GetFechaDesde { get;  }
        DateTime GetFechaHasta { get; }
        string GetTipoDoc_Id { get;  }
        int GetCntItems { get; }


        void Buscar();
        void AnularItem();
        void LimpiarFiltros();
        void LimpiarData();
        void VisualizarDocumento();
        void Imprimir();
        void Filtros();
        void VerAnulacion();
        void setTipoDoc(string id);
        void setFechaDesde(DateTime fecha);
        void setFechaDesdeEstatusOff();
        void setFechaHasta(DateTime dateTime);
        void setFechaHastaEstatusOff();
        void Visualizar();

    }

}