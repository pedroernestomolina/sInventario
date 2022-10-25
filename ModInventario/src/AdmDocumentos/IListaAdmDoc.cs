using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.AdmDocumentos
{
    
    public interface IListaAdmDoc: ILista
    {

        void setLista(List<OOB.LibInventario.Movimiento.Lista.Ficha> lst);
        void setEstatusAnulado(string idDoc);

    }

}