using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.PorDeposito
{
    public interface IDeposito
    {
        BindingSource SourceDeposito{ get; }
        string GetIdDeposito{ get; }

        void Inicializa();
        void setIdDeposito(string id);
    }
}