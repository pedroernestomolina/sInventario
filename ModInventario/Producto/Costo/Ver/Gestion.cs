using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Costo.Ver
{
    
    public class Gestion
    {

        private string _autoPrd;
        private data _data;


        public data Data { get { return _data; } }


        public Gestion()
        {
            _autoPrd = "";
            _data = new data();
        }

        VerFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new VerFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setFicha(string autoprd)
        {
            _autoPrd = autoprd;
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetCosto(_autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            _data.setFicha(r01.Entidad,r02.Entidad);

            return rt;
        }

        private void Limpiar()
        {
            _data.Limpiar();
        }

    }

}