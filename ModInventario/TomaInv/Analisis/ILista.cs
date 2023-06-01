using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis
{
    public interface ILista
    {
        BindingSource GetDataSource { get; }


        void Inicializa();
        void setDataListar(List<data> lst);
    }
}