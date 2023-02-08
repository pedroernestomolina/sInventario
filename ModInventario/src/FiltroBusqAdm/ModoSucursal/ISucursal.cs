using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.ModoSucursal
{
    public interface ISucursal: IFiltroPrd, PorTCS.ITCS, PorDeposito.IDeposito, 
                                PorCatalogo.ICatalogo, PorCategoria.ICategoria,
                                PorExistencia.IExistencia, PorProveedor.IProveedor
    {
    }
}