using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario
{
    abstract public class BaseMov: IBaseMov
    {
        public BaseMov()
        {
        }


        abstract public void Inicializa();
        abstract public void Inicia();
        abstract public void BuscarProducto();

        private bool _abandonar;
        public bool AbandonarIsOk { get { return _abandonar; } }
        public void AbandonarFicha()
        {
            _abandonar= Helpers.Msg.Abandonar();
        }

        abstract public bool ProcesarIsOk { get; }
        abstract public void ProcesarFicha();
    }
}