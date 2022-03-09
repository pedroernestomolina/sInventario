using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.Editar
{
    
    public class Gestion
    {

        private string autoPrd;
        private string autoDep;
        private OOB.LibInventario.Producto.Depositos.Ver.Ficha _detalle;
        private bool habilitarCierre;


        public string Producto { get { return _detalle.codigoProducto + Environment.NewLine + _detalle.nombreProducto; } }
        public string Deposito { get { return _detalle.codigoDeposito + Environment.NewLine + _detalle.nombreDeposito; } }
        public bool HabilitarCierre { get { return habilitarCierre; } }


        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public int Pedido { get; set; }
        public string Ubicacion_1 { get; set; }
        public string Ubicacion_2 { get; set; }
        public string Ubicacion_3 { get; set; }
        public string Ubicacion_4 { get; set; }


        public Gestion()
        {
            autoDep = "";
            autoPrd = "";
            Limpiar();
        }


        EditarFrm frm ;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new EditarFrm();
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

            var s=r01.Entidad;
            Ubicacion_1 = s.ubicacion_1;
            Ubicacion_2 = s.ubicacion_2;
            Ubicacion_3 = s.ubicacion_3;
            Ubicacion_4 = s.ubicacion_4;
            Minimo = s.nivelMinimo;
            Maximo = s.nivelOptimo;
            Pedido = s.ptoPedido;

            return rt;
        }

        private void Limpiar()
        {
            habilitarCierre = true;
            Ubicacion_1 = "";
            Ubicacion_2 = "";
            Ubicacion_3 = "";
            Ubicacion_4 = "";
            Minimo = 0;
            Maximo = 0;
            Pedido = 0;
        }

        public void setFicha(string _autoPrd, string _autoDep)
        {
            autoPrd = _autoPrd;
            autoDep = _autoDep;
        }

        public void Procesar()
        {
            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var ficha = new OOB.LibInventario.Producto.Depositos.Editar.Ficha()
                {
                    autoDeposito = autoDep,
                    autoProducto = autoPrd,
                    ubicacion_1 = Ubicacion_1,
                    ubicacion_2 = Ubicacion_2,
                    ubicacion_3 = Ubicacion_3,
                    ubicacion_4 = Ubicacion_4,
                    nivelMinimo=Minimo,
                    nivelOptimo=Maximo,
                    ptoPedido=Pedido,
                };
                var r01 = Sistema.MyData.Producto_EditarDeposito(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    habilitarCierre = false;
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                habilitarCierre = true;
            }
            else
                habilitarCierre = false;
        }

        public void setInicializarHabilitarCierre()
        {
            habilitarCierre = true;
        }

    }

}