using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    public class Grupo: Utils.Filtros.Grupo, ICtrlHabilitarLink
    {
        private bool _habilitar;


        public bool GetHabilitar { get { return _habilitar; } }


        public Grupo()
            :base()
        {
            _habilitar = true;
        }


        public void setHabilitar(bool hab)
        {
            _habilitar = hab;
        }
    }
}