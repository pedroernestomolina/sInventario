using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    public class Producto: Utils.Filtros.BuscarPor.PorProducto.ImpFiltro, ICtrlHabilitarBusqPor
    {
        public Producto()
            :base()
        {
            _isRequerido = false;
        }


        private bool _isRequerido;
        public bool GetIsRequerido { get { return _isRequerido; } }
        public void setIsRequerido(bool req)
        {
            _isRequerido = req;
        }


        public bool IsOk()
        {
            var r = true;
            if (_habilitar)
            {
                if (_isRequerido)
                {
                    if (ItemSeleccionado == null)
                    {
                        Helpers.Msg.Alerta("Debes Seleccionar Un Producto");
                        return false;
                    }
                }
            }
            return r;
        }
    }
}