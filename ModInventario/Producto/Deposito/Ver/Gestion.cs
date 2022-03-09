using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Deposito.Ver
{
    
    public class Gestion
    {


        private string autoPrd;
        private string autoDep;
        private OOB.LibInventario.Producto.Depositos.Ver.Ficha _detalle; 

        public string Producto { get { return _detalle.codigoProducto + Environment.NewLine + _detalle.nombreProducto; } }
        public string Deposito { get { return _detalle.codigoDeposito + Environment.NewLine + _detalle.nombreDeposito; } }
        public string Ubicacion_1 { get { return _detalle.ubicacion_1; } }
        public string Ubicacion_2 { get { return _detalle.ubicacion_2; } }
        public string Ubicacion_3 { get { return _detalle.ubicacion_3; } }
        public string Ubicacion_4 { get { return _detalle.ubicacion_4; } }
        public string Minimo { get { return _detalle.nivelMinimo.ToString(); } }
        public string Maximo { get { return _detalle.nivelOptimo.ToString(); } }
        public string Pedido { get { return _detalle.ptoPedido.ToString(); } }


        public Gestion()
        {
            autoDep = "";
            autoPrd = "";
            _detalle = new OOB.LibInventario.Producto.Depositos.Ver.Ficha();
        }


        VerFrm frm ;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new VerFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.LibInventario.Producto.Depositos.Ver.Filtro()
            {
                autoDeposito = autoDep,
                autoProducto = autoPrd,
            };
            var r01= Sistema.MyData.Producto_GetDeposito(filtro);
            if (r01.Result== OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _detalle = r01.Entidad;

            return rt;
        }

        private void Limpiar()
        {
            _detalle.Limpiar();
        }

        public void setFicha(string _autoPrd, string _autoDep)
        {
            autoPrd = _autoPrd;
            autoDep = _autoDep;
        }

    }

}