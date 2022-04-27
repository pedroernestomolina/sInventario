using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo
{

    public interface ITipo
    {

        string TipoMovimiento { get; }
        bool IsOk { get; }
        BindingSource ConceptoSource { get; }
        BindingSource SucursalSource { get; }
        BindingSource DepOrigenSource { get; }
        BindingSource DepDestinoSource { get; }
        string AutorizadoPor { get; }
        string Motivo { get; }
        string ConceptoGetId { get; }
        string SucursalGetId { get; }
        string DepOrigenGetID { get; }
        string DepDestinoGetID { get; }
        dataItem ItemAgregar { get;  }


        void Inicializa();
        void Inicia(IGestionTipo ctr);
        bool CargarData();


        void setAutorizadoPor(string p);
        void setMotivo(string p);
        void setSucursal(string id);
        void setConcepto(string id);
        void setDepOrigen(string id);
        void setDepDestino(string id);


        void BuscarIdPrd(string p);
        void EditarItem(dataItem ItemActual);


        void ConceptoMaestro();
        void Limpiar();


        void ProcesarDoc(List<dataItem> list, decimal TotalImporte);
        bool ProcesarDocIsOk { get; }
        string IdDocumentoGenerado { get; }


        void CapturarDataAplicarAjusteInvCero();
        bool CapturarDataAplicarAjusteInvCeroIsOk { get; }
        List<dataItem> ListaItemAplicarAjusteInvCero { get; }


        BindingSource DepatamentoSource { get; }
        string DepartamentoGetId { get; }
        void setDepartamento(string id);


        void CapturarProductosConNivelMinimo();
        bool CapturarProductosConNivelMinimoIsOk { get; }
        List<dataItem> ListaItemNivelMinimo { get;  }


        void NuevoDocumento();


        bool DejarEnPendienteIsOk { get; }
        int DocPendientes { get; }
        bool ItemTransitoIsOk { get; }
        int ItemTransitoId { get; }
        void DejarEnPendiente(List<dataItem> list, decimal TotalImporte);
        void ListaDocPendientes();
        void AnularTransito();
        List<dataItem> LoadTransito();
        List<dataItem> LoadTransito(int idMovPend);
        void CargarDocPendiente(int idMovPend);
        void AnularTransito(int idMov);


        string GetIdDepOrigen { get; }
        string GetIdDepDestino { get; }

    }

}