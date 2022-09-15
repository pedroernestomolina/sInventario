using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Historico
{
    
    public interface IHistorico: IGestion
    {

        BindingSource GetDataSource { get; }
        string GetProducto_Desc { get; }
        string GetNota { get; }

        void setFicha(string idPrd);
        void Imprimir();

    }

}