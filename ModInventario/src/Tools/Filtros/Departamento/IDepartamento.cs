using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Departamento
{
    public interface IDepartamento:IFiltro
    {
        Tools.Filtros.Grupo.IGrupo Grupo { get; }
    }
}