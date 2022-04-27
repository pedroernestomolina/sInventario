using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.AdmMovPend
{
    
    public interface IAdmMovPend: IAdministrador 
    {

        bool LimpiarFiltrosIsOk { get; }
        bool AnularIsOk { get; }
        BindingSource TipoDocSource { get; }
        string TipoDocID { get; }


        void GenerarMov();
        void setMovTrasladoxNivel(MovimientoInvTipo.ITipo mTraslxNivel);
        void setMovTraslado(MovimientoInvTipo.ITipoxDev mTraslado);
        void setMovAjuste(MovimientoInvTipo.ITipo mAjuste);
        void LimpiarFiltros();
        void setTipoDoc(string id);

    }

}