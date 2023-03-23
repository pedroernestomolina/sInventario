using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Ajuste.InvCero
{
    public interface IAjusteInvEnCero: IMov
    {
        void SucOrigenSetId(string id);

        bool CapturarDataAjusteInvCeroIsOk { get; }
        void CapturarDataAjusteInvCero();

        void SeguridadPorUsuario(SeguridadSist.ISeguridad segModo);
    }
}