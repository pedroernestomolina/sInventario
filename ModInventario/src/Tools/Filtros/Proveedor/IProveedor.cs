using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Tools.Filtros.Proveedor
{
    public interface IProveedor
    {
        bool IsOk { get; }
        string GetNombre { get; }
        ficha GetItem { get; }

        void setCadena(string cad);

        void Inicializa();
        void Buscar();
        void Limpiar();
    }
}