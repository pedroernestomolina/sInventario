using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Administrador
{
    
    public interface IGestion
    {

        enumerados.EnumTipoAdministrador TipoAdministrador { get; }
        string Titulo { get; }
        BindingSource Source { get;  }
        string Items { get; }
        BindingSource SucursalSource { get; }
        BindingSource TipoDocSource { get; }
        string SucursalID { get; }
        string TipoDocID { get; }
        DateTime FechaDesde { get; }
        DateTime FechaHasta { get; }
        bool LimpiarFiltrosIsOk { get; }


        void Inicializa();
        void Inicia();
        void Buscar();
        void AnularItem();
        void LimpiarFiltros();
        void LimpiarData();
        void VisualizarDocumento();
        void Imprimir();
        void Filtros();
        void VerAnulacion();
        void setGestionAuditoria(Auditoria.Visualizar.Gestion _gestion);
        void setSucursal(string id);
        void setTipoDoc(string id);
        void setFechaDesde(DateTime fecha);
        void setFechaDesdeEstatusOff();
        void setFechaHasta(DateTime dateTime);
        void setFechaHastaEstatusOff();

    }

}