using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.CodigosAlterno
{
    
    public interface IAlterno: IGestion
    {

        BindingSource GetSource { get; }
        void setCodigoAgregar(string d);
        void Agregar();
        void Eliminar();
        IEnumerable<data> CodigosExportar { get; }
        void CargarData(List<string> lst);

    }

}