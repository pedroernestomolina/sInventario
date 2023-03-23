using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Traslado.PorNIvel
{
    public interface IPorNIvel: ITraslado
    {
        Tools.Sucursal.ISucursal SucDestino { get; }
        Tools.Departamento.IDepartamento Departamento { get; }
        void SucDestinoSetId(string id);
        void CapturarProductosConExistenciaPorDebajoNivelMinimo();
        void EliminarItemsDondeExistenciaEnDepOrigenSeaCero();
    }
}