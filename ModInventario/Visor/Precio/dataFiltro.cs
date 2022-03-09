using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Visor.Precio
{

    public class dataFiltro
    {

        private general _departamento;
        private general _grupo;


        public general Departamento { get { return _departamento; } }
        public general Grupo { get { return _grupo; } }


        public dataFiltro()
        {
            limpiar();
        }


        public void setDepartamento(general ficha)
        {
            _departamento = ficha;
        }

        public void Limpiar()
        {
            limpiar();
        }

        private void limpiar()
        {
            _departamento = null;
            _grupo = null;
        }

        public void setGrupo(general ficha)
        {
            _grupo = ficha;
        }

    }

}