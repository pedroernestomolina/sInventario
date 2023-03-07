using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.Filtros.Grupo
{
    public interface IGrupo:IFiltro
    {
        void CargarDataByIdDepartamento(string idDepart);
    }
}