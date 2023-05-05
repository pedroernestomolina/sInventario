using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.AdmDocumentos.ModoSucursal
{
    public interface ISucursal : IAdmDoc
    {
        LibUtilitis.CtrlCB.ICtrl Sucursal { get; }
    }
}