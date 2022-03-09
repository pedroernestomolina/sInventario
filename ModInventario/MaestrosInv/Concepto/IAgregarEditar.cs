using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv.Concepto
{

    public interface IAgregarEditar : IGestion
    {

        string Titulo { get; }
        bool IsOk { get; }
        bool ProcesarIsOk { get; }
        bool AbandonarIsOk { get; }
        string Codigo { get; }
        string Nombre { get; }
        string IdItemAgregado { get; }


        void Procesar();
        void Abandonar();
        void setCodigo(string p);
        void setNombre(string p);
        void setIdItemEditar(string idItemEditar);

    }

}