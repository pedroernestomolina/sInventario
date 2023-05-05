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
        LibUtilitis.CtrlCB.ICtrl TipoDoc { get; }
        Utils.Filtros.DesdeHasta.IFiltro DesdeHasta { get; }
        int GetCntItems { get; }


        void Buscar();
        void AnularItem();
        void LimpiarFiltros();
        void LimpiarData();
        void VisualizarDocumento();
        void Imprimir();
        void Filtros();
        void VerAnulacion();
        void Visualizar();
    }
}