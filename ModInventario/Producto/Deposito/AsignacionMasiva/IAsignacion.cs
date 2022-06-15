using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.AsignacionMasiva
{
    
    public interface IAsignacion: IGestion
    {

        bool IsAbandonarIsOk { get; }
        bool IsProcesarIsOk { get; }


        void AbandonarFicha();
        void Procesar();


        BindingSource DepositoGetSource { get; }
        string DepositoGetId { get; }
        void setDeposito(string id);

        BindingSource DepartGetSource { get; }

    }

}