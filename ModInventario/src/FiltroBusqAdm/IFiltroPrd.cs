using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm
{

    public interface IFiltroPrd: ModInventario.FiltrosGen.AdmProducto.IAdmProducto, Gestion.IAbandonar
    {

        BindingSource GetDepartamentoSource { get; }
        BindingSource GetGrupoSource { get; }
        BindingSource GetMarcaSource { get; }
        BindingSource GetOrigenSource { get; }
        BindingSource GetImpuestoSource { get; }
        BindingSource GetEstatusSource { get; }
        BindingSource GetAdmDivisaSource { get; }
        BindingSource GetPesadoSource { get; }

        string GetDepartamentoId { get; }
        string GetGrupoId { get; }
        string GetMarcaId { get; }
        string GetOrigenId { get; }
        string GetImpuestoId { get; }
        string GetEstatusId { get; }
        string GetAdmDivisaId { get; }
        string GetPesadoId { get; }

        void setDepartamento(string id);
        void setGrupo(string id);
        void setMarca(string id);
        void setOrigen(string id);
        void setTasaIva(string id);
        void setEstatus(string id);
        void setAdmDivisa(string id);
        void setPesado(string id);

        bool LimpiarOpcionesIsOk { get; }
        void LimpiarOpciones();

    }

}