using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroRep
{
    
    public interface IFiltroRep: IFiltro
    {

        BindingSource GetDeposito_Source { get; }
        BindingSource GetDepartamento_Source { get; }
        BindingSource GetGrupo_Source { get; }
        BindingSource GetMarca_Source { get; }
        BindingSource GetAdmDivisa_Source { get; }
        BindingSource GetImpuesto_Source { get; }
        BindingSource GetEstatus_Source { get; }
        BindingSource GetPesado_Source { get; }


        string GetDeposito_Id { get; }
        string GetDepartamento_Id { get; }
        string GetGrupo_Id { get; }
        string GetMarca_Id { get; }
        string GetAdmDivisa_Id { get; }
        string GetImpuesto_Id { get; }
        string GetEstatus_Id { get; }
        string GetPesado_Id { get; }


        bool GetHabilitarDepartamento { get; }
        bool GetHabilitarDeposito { get; }
        bool GetHabilitarGrupo { get; }
        bool GetHabilitarMarca { get; }
        bool GetHabilitarAdmDivisa { get; }
        bool GetHabilitarImpuesto { get; }
        bool GetHabilitarEstatus { get; }
        bool GetHabilitarPesado { get; }
        bool GetHabilitarFecha { get; }
        bool GetHabilitarFechaDesde { get; }
        bool GetHabilitarFechaHasta { get; }


        DateTime GetDesde { get; }
        DateTime GetHasta { get; }


        void setDeposito(string id);
        void setDepartamento(string id);
        void setGrupo(string id);
        void setMarca(string id);
        void setAdmDivisa(string id);
        void setImpuesto(string id);
        void setEstatus(string id);
        void setPesado(string id);
        void setDesde(DateTime f);
        void setHasta(DateTime f);


        bool LimpiarOpcionesIsOk { get; }
        void LimpiarOpciones();


        void setValidarData(bool p);
        void setGestion(Reportes.Filtros.IFiltros filtros);
        bool FiltrosIsOK { get; }
        FiltrosGen.Reportes.data dataFiltrar { get; }

    }

}