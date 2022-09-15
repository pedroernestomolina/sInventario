using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.ModoSucursal
{
    
    public interface ISucursal: IFiltroPrd
    {

        BindingSource GetDepositoSource { get; }
        BindingSource GetCategoriaSource { get; }
        BindingSource GetOfertaSource { get; }
        BindingSource GetCatalogoSource { get; }
        BindingSource GetExistenciaSource { get; }

        string GetDepositoId { get; }
        string GetCategoriaId { get; }
        string GetOfertaId { get; }
        string GetExistenciaId { get; }
        string GetCatalogoId { get; }

        void setDeposito(string id);
        void setCategoria(string id);
        void setCatalogo(string id);
        void setOferta(string id);
        void setExistencia(string id);

        bool ProveedorIsOk { get; }
        void ProveedorBuscar();
        void setProveedorCadenaBuscar(string cad);
        void ProveedorLimpiar();
        string GetProveedorNombreFiltrar { get; }

    }

}