using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    public interface IFiltroRep: IFiltro
    {
        ICtrlHabilitar Deposito { get; }
        ICtrlHabilitar Marca { get; }
        ICtrlHabilitar Sucursal { get; }
        ICtrlHabilitar EstatusDivisa { get; }
        ICtrlHabilitar EstatusDocumento { get; }
        ICtrlHabilitar TasaIva { get; }
        ICtrlHabilitar Categoria { get; }
        ICtrlHabilitar Origen { get; }
        ICtrlHabilitar Oferta{ get; }
        ICtrlHabilitar Concepto{ get; }
        ICtrlHabilitar EstatusPesado { get; }
        ICtrlHabilitar Precio { get; }
        ICtrlHabilitar Empaque { get; }
        IDepartamentoGrupo DepartGrupo { get; }
        ICtrlHabilitarBusqPor Producto { get; }
        ICtrlHabilitarFecha Desde { get; }
        ICtrlHabilitarFecha Hasta { get; }
        FiltrosGen.Reportes.IData DataExportar { get; }


        void setFiltrosHab(ModInventario.Reportes.Filtros.IFiltros filtHab);
        void LimpiarFiltros();
   }
}