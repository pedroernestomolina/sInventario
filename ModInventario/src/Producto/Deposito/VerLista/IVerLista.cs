using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.Deposito.VerLista
{
    public interface IVerLista: IGestion
    {
        BindingSource GetData_Source { get; }
        string GetInf_Producto_Desc { get; }
        string GetInf_Prdoucto_EmpaqueDesc { get; }
        string GetInf_ExFisica { get; }
        string GetInf_ExReserva { get; }
        string GetInf_ExDisponible { get; }

        void setIdPrd(string idPrd);
        void setIdDeposito(string idDep);
        void setContenidoPorUnidad();
        void setContenidoPorEmpCompra();

        void ImprimirReporte();
        void ExPor_TallaColorSabor();
        void VerDetalleDeposito();
        void EditarDeposito();
    }
}