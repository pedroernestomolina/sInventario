using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInv
{

    public interface IMov
    {


        BindingSource SucursalSource { get; }
        string SucursalGetID { get; }
        BindingSource ConceptoSource { get; }
        string ConceptoGetID { get; }
        BindingSource DepOrigenSource { get; }
        string DepOrigenGetID { get; }
        string AutoriazadoPor { get; }
        string Motivo { get; }
        DateTime FechaSistema { get; }
        BindingSource ItemsSource { get; }
        int CntItem { get; }
        decimal Monto { get; }
        bool HablitarCambio { get; }
        bool ProcesarIsOk { get; }


        void Inicializa();
        void Inicia(GestionMov gestionMov);
        void setSucursal(string id);
        void setConcepto(string id);
        void setDepOrigen(string id);
        void setAutorizado(string p);
        void setMotivo(string p);
        void Limpiar();
        void CapturarAplicarAjuste();
        void Procesar();
        void setModoSeguridad(SeguridadSist.IModo _gSecurityModo);

    }

}