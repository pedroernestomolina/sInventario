using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Administrador
{
    
    public interface IGestionListaDetalle
    {

        BindingSource Source { get; }
        string Items { get; }


        void setLista(List<OOB.LibInventario.Movimiento.Lista.Ficha> list);
        void AnularItem();
        void LimpiarData();
        void setGestionAnular(Anular.Gestion _gestionAnular);
        void VisualizarDocumento();
        void Imprimir(string xfiltros);
        void VerAnulacion();
        void setGestionAuditoria(Auditoria.Visualizar.Gestion _gestionAuditoria);
        void Inicializa();

    }

}