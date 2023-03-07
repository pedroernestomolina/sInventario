using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.ListaMov
{
    public interface IListaMov: ILista
    {
        decimal GetImporte_MonedaLocal { get; }
        decimal GetImporte_MonedaOtra { get; }

        void AgregarItem(CapturaMov.IDataCaptura data);
        void EliminarItem(int id);
        bool VerificaItemRegistradoLista(string idPrd);

        //
        List<MovInventario.dataItem> GetItems { get; }
    }
}