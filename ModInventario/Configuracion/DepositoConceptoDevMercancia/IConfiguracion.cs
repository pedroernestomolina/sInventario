using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.DepositoConceptoDevMercancia
{

    public interface IConfiguracion: IGestion
    {

        BindingSource  DepositoSource { get; }
        BindingSource ConceptoSource { get; }
        string DepositoGetId { get; }
        string ConceptoGetId { get; }


        void setDeposito(string id);
        void setConcepto(string id);


        bool AbandonarIsOK { get; }
        bool ProcesarIsOk { get; }
        void Abandonar();
        void Procesar();

    }

}