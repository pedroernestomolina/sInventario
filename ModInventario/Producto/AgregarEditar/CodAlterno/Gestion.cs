using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.AgregarEditar.CodAlterno
{
    
    public class Gestion
    {


        private GestionLista _detalle;


        public BindingSource Source { get { return _detalle.Source; } }
        public List<data> ListaCodigos { get { return _detalle.ListaCodigos; } }


        public Gestion()
        {
            _detalle = new GestionLista();
        }


        public void Eliminar()
        {
            _detalle.Eliminar();
        }

        public void Agregar(string CodigoAlterno)
        {
            _detalle.Agregar(CodigoAlterno);
        }

        public void CargarData(List<OOB.LibInventario.Producto.Editar.Obtener.FichaAlterno> list)
        {
            foreach (var rg in list)
            {
                Agregar(rg.Codigo);
            }
        }

        public void Limpiar()
        {
            _detalle.Limpiar();
        }

    }

}