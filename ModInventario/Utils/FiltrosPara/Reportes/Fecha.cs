using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    public class Fecha: tools.ImpFecha, ICtrlHabilitarFecha
    {
        private bool _habilitar;


        public bool GetHabilitar { get { return _habilitar; } }


        public Fecha()
            :base()
        {
        }

        public void setHabilitar(bool hab)
        {
            _habilitar = hab;
        }
    }
}