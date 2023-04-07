using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Oferta
{
    public interface IOferta
    {
        BindingSource GetSource { get; }
        ficha GetItem { get; }
        string GetId { get; }
        void setId(string id);
        void Inicializa();
        void CargarData();
    }
}