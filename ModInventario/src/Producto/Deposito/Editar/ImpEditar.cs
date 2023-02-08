using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.Deposito.Editar
{
    
    public class ImpEditar: IEditar
    {
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private string _producto;
        private string _deposito;
        private string _ub1;
        private string _ub2;
        private string _ub3;
        private string _ub4;
        private int _nivMinimo;
        private int _nivOptimo;
        private int _nivPedido;
        private string _idPrd;
        private string _idDep;


        public string GetInfo_Producto { get { return _producto; } }
        public string GetInfo_Deposito { get { return _deposito; } }
        public string GetInfo_Ubicacion_1 { get { return _ub1; } }
        public string GetInfo_Ubicacion_2 { get { return _ub2; } }
        public string GetInfo_Ubicacion_3 { get { return _ub3; } }
        public string GetInfo_Ubicacion_4 { get { return _ub4; } }
        public decimal GetInfo_Minimo { get { return _nivMinimo; } }
        public decimal GetInfo_Maximo { get { return _nivOptimo; } }
        public decimal GetInfo_Pedido { get { return _nivPedido; } }


        public ImpEditar()
        {
            _idDep = "";
            _idPrd = "";
            _ub1 = "";
            _ub2 = "";
            _ub3 = "";
            _ub4 = "";
            _nivMinimo = 0;
            _nivOptimo = 0;
            _nivPedido = 0;
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _producto = "";
            _deposito = "";
        }


        public void Inicializa()
        {
            _idDep = "";
            _idPrd = "";
            _ub1 = "";
            _ub2 = "";
            _ub3 = "";
            _ub4 = "";
            _nivMinimo = 0;
            _nivOptimo = 0;
            _nivPedido = 0;
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _producto = "";
            _deposito = "";
        }
        EditarFrm frm ;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new EditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setIdPrd(string idPrd)
        {
            _idPrd = idPrd;
        }
        public void setIdDep(string idDep)
        {
            _idDep = idDep;
        }
        public void setUbicacion_1(string des)
        {
            _ub1 = des;
        }
        public void setUbicacion_2(string des)
        {
            _ub2 = des;
        }
        public void setUbicacion_3(string des)
        {
            _ub3 = des;
        }
        public void setUbicacion_4(string des)
        {
            _ub4 = des;
        }
        public void setMinimo(int cnt)
        {
            _nivMinimo = cnt;
        }
        public void setMaximo(int cnt)
        {
            _nivOptimo = cnt;
        }
        public void setPedido(int cnt)
        {
            _nivPedido= cnt;
        }


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            var msg = MessageBox.Show("Guardar Cambios Para Esta Ficha?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var ficha = new OOB.LibInventario.Producto.Depositos.Editar.Ficha()
                {
                    autoDeposito = _idDep,
                    autoProducto = _idPrd,
                    ubicacion_1 = _ub1,
                    ubicacion_2 = _ub2,
                    ubicacion_3 = _ub3,
                    ubicacion_4 = _ub4,
                    nivelMinimo = _nivMinimo,
                    nivelOptimo = _nivOptimo,
                    ptoPedido = _nivPedido,
                };
                try
                {
                    var r01 = Sistema.MyData.Producto_EditarDeposito(ficha);
                    _procesarIsOk = true;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }


        private bool CargarData()
        {
            try
            {
                var filtro = new OOB.LibInventario.Producto.Depositos.Ver.Filtro()
                {
                    autoDeposito = _idDep,
                    autoProducto = _idPrd,
                };
                var r01 = Sistema.MyData.Producto_GetDeposito(filtro);
                var s = r01.Entidad;
                _producto = s.codigoProducto + Environment.NewLine + s.nombreProducto;
                _deposito = s.codigoDeposito + Environment.NewLine + s.nombreDeposito;
                _ub1 = s.ubicacion_1;
                _ub2 = s.ubicacion_2;
                _ub3 = s.ubicacion_3;
                _ub4 = s.ubicacion_4;
                _nivMinimo = s.nivelMinimo;
                _nivOptimo = s.nivelOptimo;
                _nivPedido = s.ptoPedido;
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