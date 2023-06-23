using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.TomaInv.Analisis.Motivo
{
    public interface IMotivo: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
        string GetMotivo { get; }
        void setMotivo(string desc);
    }
}
