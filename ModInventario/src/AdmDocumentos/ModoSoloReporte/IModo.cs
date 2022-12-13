using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.AdmDocumentos.ModoSoloReporte
{

    public interface IModo : IAdmDoc
    {

        BindingSource  GetSucursal_Source { get; }
        string GetSucursal_Id { get; }
        void setSucursal(string id);

    }

}