using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.Filtros.BuscarPor.ListaSelecciona
{
    public interface ILista
    {
        BindingSource GetSource { get; }
        int CntItem { get; }
        bool ItemSeleccionadoIsOk { get; }
        Idata ItemSeleccionado { get; }

        void setDataListar(IEnumerable<Idata> lst);

        void Inicializa();
        void Inicia();
        void SeleccionarItem();
        void LimpiarItem();
    }
}