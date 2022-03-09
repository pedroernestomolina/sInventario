using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Estatus
{

    public class Gestion
    {

        private string autoPrd;
        private data fichaActual;
        private bool habilitarCierre;


        public string Producto { get { return fichaActual.Producto; } }
        public OOB.LibInventario.Producto.Enumerados.EnumEstatus EstatusActual { get { return fichaActual.Estatus; } }
        public bool HabilitarCierre { get { return habilitarCierre; } }
        public bool IsCambioOk { get;set; }


        public Gestion()
        {
            autoPrd = "";
            fichaActual = new data();
            Limpiar();
        }


        EstatusFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new EstatusFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_Estatus_GetFicha(autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            fichaActual.setFicha(r01.Entidad);

            return rt;
        }

        private void Limpiar()
        {
            IsCambioOk = false;
            fichaActual.Limpiar();
        }

        public void setFicha(string _autoPrd)
        {
            autoPrd = _autoPrd;
        }

        public void setEstatusActivo()
        {
            fichaActual.Estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo;
        }

        public void setEstatusSuspendido()
        {
            fichaActual.Estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Suspendido;
        }

        public void setEstatusInactivo()
        {
            fichaActual.Estatus = OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo;
        }

        public void Procesar()
        {
            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                OOB.Resultado r01= null;
                switch (fichaActual.Estatus) 
                {
                    case OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo:
                        r01 = Sistema.MyData.Producto_CambiarEstatusA_Activo(fichaActual.AutoProducto);
                        break;
                    case OOB.LibInventario.Producto.Enumerados.EnumEstatus.Suspendido:
                        r01 = Sistema.MyData.Producto_CambiarEstatusA_Suspendido(fichaActual.AutoProducto);
                        break;
                    case OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo:
                        r01 = Sistema.MyData.Producto_CambiarEstatusA_Inactivo(fichaActual.AutoProducto);
                        break;
                }
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    habilitarCierre = false;
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                habilitarCierre = true;
                IsCambioOk = true;
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