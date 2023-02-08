using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.FiltroBusqAdm.PorProveedor
{
    public interface IProveedor
    {
        bool ProveedorIsOk { get; }
        string GetProveedorNombreFiltrar { get; }

        void ProveedorBuscar();
        void setProveedorCadenaBuscar(string cad);
        void ProveedorLimpiar();
    }
}