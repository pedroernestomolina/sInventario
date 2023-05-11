using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public interface IDepartamentoGrupo
    {
        IFiltro Departamento { get; }
        IFiltroLink Grupo { get; }

        void Inicializa();
        void LimpiarOpcion();
        void CargarData();
        void setDepartamentoFichaById(string id);
    }
}