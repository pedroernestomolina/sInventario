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
        string AutorizadoPor { get; }
        string Motivo { get; }
        string ConceptoGetId { get; }
        string SucursalGetId { get; }
        string DepOrigenGetID { get; }
        dataItem ItemAgregar { get;  }


        void Inicializa();
        void Inicia(IGestionTipo ctr);
        bool CargarData();


        void setAutorizadoPor(string p);
        void setMotivo(string p);
        void setSucursal(string id);
        void setConcepto(string id);
        void setDepOrigen(string id);


        void BuscarIdPrd(string p);


        void Limpiar();


        void EditarItem(dataItem ItemActual);

    }

}