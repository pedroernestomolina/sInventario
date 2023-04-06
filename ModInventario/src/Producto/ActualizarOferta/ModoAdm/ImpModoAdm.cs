using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOferta.ModoAdm
{
    public class ImpModoAdm: IModoAdm
    {


        public ImpModoAdm()
        {
            _idPrd = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }


        public void Inicializa()
        {
            _idPrd = "";
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private string _idPrd;
        public void setFichaByIdPrd(string id)
        {
            _idPrd = id;
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
        }

        private bool _procesarIsOk;
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
        }


        private bool CargarData()
        {
            try
            {
                var xr1 = Sistema.MyData.Producto_ModoAdm_GetPrecio_By(_idPrd, "1");
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