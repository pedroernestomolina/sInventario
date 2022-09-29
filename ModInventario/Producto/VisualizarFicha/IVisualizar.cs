using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.VisualizarFicha
{
    
    public interface IVisualizar: IGestion, ModInventario.Gestion.IAbandonar
    {

        string GetCodigoPrd { get; }
        string GetDescripcionPrd { get; }
        string GetNombrePrd { get; }
        string GetDepartamentoPrd { get; }
        string GetGrupoPrd { get; }
        string GetMarcaPrd { get; }
        string GetImpuestoPrd { get; }
        string GetOrigenPrd { get; }
        string GetCategoriaPrd { get; }
        string GetClasificacionPrd { get; }
        string GetAdmDivisaPrd { get; }
        string GetEmpaquePrd { get; }
        string GetContenidoPrd { get; }
        bool GetIsPesadoPrd { get; }
        string GetPluPrd { get; }
        bool GetIsInactivo { get; }
        string GetEmpaqueInv { get; }
        int GetDiasEmpaquePrd { get; }
        int  GetContEmpInv { get; }
        BindingSource GetCodAlterno_Source { get; }
        void setFicha(string id);

    }

}