using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Generar
{
    public interface ILista
    {
        BindingSource GetDataSource { get; }
        List<data> GetLista { get;}
        int CntItem { get; }


        void Inicializa();
        void setDataListar(List<TomaInv.data> lst);
    }
}