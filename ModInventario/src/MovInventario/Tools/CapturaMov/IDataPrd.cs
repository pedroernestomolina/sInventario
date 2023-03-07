using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario
{
    public interface IDataPrd
    {
        string InfProductoDesc { get; }
        string InfProductoEmpaCompra { get; }
        string InfProductoEmpInventario { get;  }
        string InfProductoEmpUnidad { get; }
        string InfProductoEsAdmDivisa { get; }
        string InfProductoTasaIva { get; }
        string InfProductoFechaUltActCosto { get; }
        decimal InfExistenciaActual { get; }
        bool InfProductoEsDivisa { get; }
        //
        string PrdAuto { get;  }
        string PrdCodigo { get; }
        string PrdDescripcion { get; }

        data GetFicha { get; }
        void setFicha(data dat);

        void Inicializa();
    }
}