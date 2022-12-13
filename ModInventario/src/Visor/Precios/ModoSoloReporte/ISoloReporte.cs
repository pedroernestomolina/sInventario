using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Visor.Precios.ModoSoloReporte
{
    
    public interface ISoloReporte: IPrecio
    {
        BindingSource GetSource { get; }
        BindingSource GetDesde_Source { get; }
        string GetDesde_Id { get; }
        int GetCntItems { get; }
        bool GetExcluirCambioMasivo { get; }
        int GetMostrarPrecio { get; }

        void Buscar();
        void setDesde(string id);
        void ExcluirCambiosMasivo(bool excluirCambMasivo);
        void MostrarPrecioSoloDivisa();
        void MostrarPrecioSoloBs();
        void MostrarPrecioAmbos();
    }

}