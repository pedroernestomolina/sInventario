using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Tools.ExcluirDepart
{
    public interface ILista
    {
        BindingSource GetDataSource { get; }
        IEnumerable <Object> GetLista { get;}
        int CntItem { get; }


        void Inicializa();
        void setDataListar(IEnumerable<Object> lst);
    }
}