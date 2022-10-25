using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Auditoria.Visualizar
{
    
    public interface IVisualizar: IGestion, Gestion.IAbandonar
    {

        string GetMotivo_Desc { get; }
        DateTime GetFecha_Desc { get; }


        void setData(AdmDocumentos.data ItemActual);
    }

}