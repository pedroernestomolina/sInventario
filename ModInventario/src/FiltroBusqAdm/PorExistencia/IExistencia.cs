using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.PorExistencia
{
    public interface IExistencia
    {
        BindingSource SourceExistencia { get; }
        string GetIdExistencia { get; }

        void Inicializa();
        void setIdExistencia(string id);
    }
}