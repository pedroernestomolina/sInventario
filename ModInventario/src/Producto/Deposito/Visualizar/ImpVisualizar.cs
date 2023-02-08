using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.Deposito.Visualizar
{
    public class ImpVisualizar : IVisualizar
    {
        private string _autoPrd;
        private string _autoDep;
        private string _producto;
        private string _deposito;
        private string _ub1;
        private string _ub2;
        private string _ub3;
        private string _ub4;
        private decimal _nivMinimo;
        private decimal _nivOptimo;
        private decimal _nivPedido;


        public string GetInfo_Producto { get { return _producto; } }
        public string GetInfo_Deposito { get { return _deposito; } }
        public string GetInfo_Ubicacion_1 { get { return _ub1; } }
        public string GetInfo_Ubicacion_2 { get { return _ub2; } }
        public string GetInfo_Ubicacion_3 { get { return _ub3; } }
        public string GetInfo_Ubicacion_4 { get { return _ub4; } }
        public string GetInfo_Minimo { get { return _nivMinimo.ToString(); } }
        public string GetInfo_Maximo { get { return _nivOptimo.ToString(); } }
        public string GetInfo_Pedido { get { return _nivPedido.ToString(); } }


        public ImpVisualizar()
        {
            _autoDep = "";
            _autoPrd = "";
            _producto = "";
            _deposito = "";
            _ub1 = "";
            _ub2 = "";
            _ub3 = "";
            _ub4 = "";
            _nivMinimo = 0m;
            _nivOptimo = 0m;
            _nivPedido = 0m;
        }


        public void Inicializa()
        {
            _autoDep = "";
            _autoPrd = "";
            _producto = "";
            _deposito = "";
            _ub1 = "";
            _ub2 = "";
            _ub3 = "";
            _ub4 = "";
            _nivMinimo = 0m;
            _nivOptimo = 0m;
            _nivPedido = 0m;
        }
        VerFrm frm;
        public void Inicia()
        {
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


        public void setIdPrd(string idPrd)
        {
            _autoPrd = idPrd;
        }
        public void setIdDep(string idDep)
        {
            _autoDep = idDep;
        }


        private bool CargarData()
        {
            try
            {
                var filtro = new OOB.LibInventario.Producto.Depositos.Ver.Filtro()
                {
                    autoDeposito = _autoDep,
                    autoProducto = _autoPrd,
                };
                var r01 = Sistema.MyData.Producto_GetDeposito(filtro);
                var _detalle = r01.Entidad;
                _producto=_detalle.codigoProducto + Environment.NewLine + _detalle.nombreProducto;
                _deposito = _detalle.codigoDeposito + Environment.NewLine + _detalle.nombreDeposito;
                _ub1=_detalle.ubicacion_1; 
                _ub2=_detalle.ubicacion_2; 
                _ub3=_detalle.ubicacion_3; 
                _ub4=_detalle.ubicacion_4;
                _nivMinimo= _detalle.nivelMinimo;
                _nivOptimo =_detalle.nivelOptimo;
                _nivPedido= _detalle.ptoPedido;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}