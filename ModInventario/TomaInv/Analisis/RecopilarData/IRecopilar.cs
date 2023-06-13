using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.Analisis.RecopilarData
{
    public interface IRecopilar: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
        string Autorizado_GetData { get; }
        string Motivo_GetData { get;  }

        void setAutorizadoPor(string desc);
        void setMotivo(string desc);
    }
}
