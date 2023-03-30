using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.EditarCambiar.ModoAdministrativo
{
    public interface IEditarAdm: IEditar
    {
        IVta Vta1 { get; }
        IVta Vta2 { get; }
        IVta Vta3 { get; }

        string GetInfProducto { get; }
        string GetInfEmpCompraPrd { get; }
        decimal GetInfCostoEmpCompraPrd { get; }
        string GetInfMetodoCalculoUt { get; }
        decimal GetInfTasaCambioPrd { get; }
        string GetInfAdmDivisaPrd { get; }
        decimal GetInfTasaIvaPrd { get; }
        decimal GetInfCostoUndPrd { get; }
        string GetInfFechaUltActPrd { get; }
        bool GetEsAdmDivisaPrd { get; }
    }
}