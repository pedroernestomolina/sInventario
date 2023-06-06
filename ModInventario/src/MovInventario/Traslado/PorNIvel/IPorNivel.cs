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
        Utils.Tools.ICtrl SucDestino { get; }
        Utils.Tools.ICtrl Departamento { get; }
        void SucDestinoSetId(string id);
        void CapturarProductosConExistenciaPorDebajoNivelMinimo();
        void EliminarItemsDondeExistenciaEnDepOrigenSeaCero();
    }
}