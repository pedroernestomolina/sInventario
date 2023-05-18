using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario
{
    public interface IAdministrador : IGestion 
    {
        string GetTitulo { get; }
        BindingSource GetSource { get; }
        int GetCntItems { get; }


        void ActAnular();
        void ActLimpiar();
        void ActVisualizar();
        void ActImprimir();
        void ActFiltrar();
        void ActBuscar();
    }
}