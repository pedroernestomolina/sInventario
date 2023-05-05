using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    public interface IDepartamentoGrupo
    {
        ICtrlHabilitar Departamento { get; }
        ICtrlHabilitarLink Grupo { get; }

        void Inicializa();
        void LimpiarOpcion();
        void CargarData();
        void setDepartamentoFichaById(string id);
    }
}