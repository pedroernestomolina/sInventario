using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv
{

    public interface IMaestro : IGestion
    {

        string Titulo { get; }
        int CntItems { get; }
        BindingSource Source { get; }
        bool AgregarIsOk { get; }
        bool EditarIsOk { get; }
        bool EliminarIsOK { get; }


        bool CargarData();
        void AgregarItem();
        void EditarItem();
        void EliminarItem();
        void setGestion(IMaestroTipo ctr);

    }

}