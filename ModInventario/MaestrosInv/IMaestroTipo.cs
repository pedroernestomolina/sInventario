using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv
{

    public interface IMaestroTipo
    {

        string Titulo { get; }
        bool AgregarIsOk { get; }
        bool EditarIsOk { get; }
        bool EliminarIsOK { get; }
        List<data> ListaData { get; }
        data ItemAgregarEditar { get; }


        void Inicializa();
        bool CargarData();
        void AgregarItem();
        void EditarItem(string id);
        void EliminarItem(string id);

    }

}