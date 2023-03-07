using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.CapturaMov
{
    public interface ICapturaMov : IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {
        event EventHandler ItemCapturado;
        Tools.CapturaMov.IDataCaptura Captura { get; }

        void setData(data dat);
        void setTasaCambio(decimal _tasaCambio);
        void setDataEditar(IDataCaptura it);
    }
}