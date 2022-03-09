using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IData: IMovimiento, ISucursal, IConcepto, IDeposito, IUsuario,
        ITool, IDepartamento, IGrupo, IMarca, IEmpaqueMedida,
        IProducto, ITasaImpuesto, IConfiguracion, IPrecio, ICosto, IKardex,
        IProveedor, IVisor, IReportes, IPermisos, IAnalisis, IAuditoria, ISistema
    {

        OOB.ResultadoEntidad<DateTime> FechaServidor();
        OOB.ResultadoEntidad<OOB.LibInventario.Empresa.Data.Ficha > Empresa_Datos();
        //OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Sistema.InformacionBD.Ficha> InformacionBD();

    }

}