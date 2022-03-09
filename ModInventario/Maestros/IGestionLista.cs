using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Maestros
{
    
    public interface IGestionLista
    {

        int TotalItems { get; }
        System.Windows.Forms.BindingSource Source { get; }
        object ItemActual { get; }

        void setLista(List<OOB.LibInventario.Concepto.Ficha> list);
        void Agregar(OOB.LibInventario.Concepto.Ficha ficha);
        void ActualizarItem(OOB.LibInventario.Concepto.Ficha ficha);
        
        void setLista(List<OOB.LibInventario.Departamento.Ficha> list);
        void Agregar(OOB.LibInventario.Departamento.Ficha ficha);
        void ActualizarItem(OOB.LibInventario.Departamento.Ficha ficha);
        
        void setLista(List<OOB.LibInventario.Grupo.Ficha> list);
        void ActualizarItem(OOB.LibInventario.Grupo.Ficha ficha);
        void Agregar(OOB.LibInventario.Grupo.Ficha ficha);

        void setLista(List<OOB.LibInventario.Marca.Ficha> list);
        void ActualizarItem(OOB.LibInventario.Marca.Ficha ficha);
        void Agregar(OOB.LibInventario.Marca.Ficha ficha);

        void setLista(List<OOB.LibInventario.EmpaqueMedida.Ficha> list);
        void ActualizarItem(OOB.LibInventario.EmpaqueMedida.Ficha ficha);
        void Agregar(OOB.LibInventario.EmpaqueMedida.Ficha ficha);
        void EliminarItem(data itActual);

    }

}