using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo
{
    
    public interface IGestionTipo: IGestion
    {

        bool ProcesarDocIsOk { get; }
        bool AbandonarIsOk { get; }
        string TipoMovimiento { get; }
        BindingSource ConceptoSource { get; }
        BindingSource SucursalSource { get; }
        BindingSource DepOrigenSource { get; }
        BindingSource DepDestinoSource { get; }
        string ConceptoGetId { get; }
        string SucursalGetId { get; }
        string DepOrigenGetID { get; }
        string DepDestinoGetID { get; }
        string Motivo { get; }
        string AutorizadoPor { get; }
        DateTime FechaSistema { get; }
        bool HabilitarCambio { get; }
        enumerados.enumMetBusquedaPrd MetBusqPrd { get;  }
        bool LimpiarIsOk { get; }


        BindingSource ItemSource { get; }
        decimal TotalImporte { get; }
        int CntItems { get; }
        bool EliminarIsOk { get; }
        bool EditarIsOk { get; }


        void Finaliza();
        void setTipoMov(ITipo ctrTipo);
        void Abandonar();


        void setAutorizadoPor(string p);
        void setMotivo(string p);
        void setSucursal(string id);
        void setConcepto(string id);
        void setDepOrigen(string id);
        void setDepDestino(string p);


        void setCadenaBusqueda(string p);
        void setMetBusqRef();
        void setMetBusqNombre();
        void setMetBusqCodigo();


        void BuscarProducto();
        void FiltrarBusqPrd();
        void EditarItem();
        void EliminarItem();
        void Limpiar();
        void Procesar();
        void ConceptoMaestro();


        void CapturarDataAplicarAjusteInvCero();
        bool CapturarDataAplicarAjusteInvCeroIsOk { get; }


        BindingSource DepartamentoSource { get; }
        string DepartamentoGetId { get; }
        void setDepartamento(string id);


        void CapturarProductosConNivelMinimo();
        bool CapturarProductosConNivelMinimoIsOk { get; }
        void EliminarExistenciaNoDisponible();
        bool EliminarExistenciaNoDisponibleIsOk { get; }


        void NuevoDocumento();

    }

}