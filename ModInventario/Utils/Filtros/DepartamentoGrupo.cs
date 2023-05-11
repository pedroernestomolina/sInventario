using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros
{
    public class DepartamentoGrupo: IDepartamentoGrupo
    {
        private IFiltro _departamento;
        private IFiltroLink _grupo;


        public IFiltro Departamento { get { return _departamento; } }
        public IFiltroLink Grupo { get { return _grupo; } }


        public DepartamentoGrupo()
        {
            _departamento = new Departamento();
            _grupo = new Grupo();
        }


        public void Inicializa()
        {
            _departamento.Ctrl.Inicializa();
            _grupo.Ctrl.Inicializa();
        }


        public void CargarData()
        {
            _departamento.CargarData();
        }
        public void LimpiarOpcion()
        {
            _departamento.Ctrl.LimpiarOpcion();
            _grupo.Ctrl.LimpiarOpcion();
        }
        public void setDepartamentoFichaById(string id)
        {
            _departamento.Ctrl.setFichaById(id);
            _grupo.Ctrl.Inicializa();
            if (id != "") 
            {
                try
                {
                    _grupo.CargarDataByIdLink(id);
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
    }
}