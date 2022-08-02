using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Visor.PrecioAjuste
{
    
    public interface IAjuste: IGestion
    {

        void Buscar();

        BindingSource GetDataSource { get; }
        BindingSource GetEmpresaGrupoSource { get; }
        BindingSource GetDepartamentoSource { get; }
        BindingSource GetGrupoSource { get; }
        BindingSource GetEmpaqueVerSource { get; }

        string  GetEmpresaGrupoId { get;  }
        string GetDepartamentoId { get; }
        string GetGrupoId { get; }
        string GetEmpaqueId { get; }

        void setEmpresaGrupo(string id);
        void setDepartamento(string id);
        void setGrupo(string id);
        void setEmpaque(string id);

        int CntItems { get;  }

        void EditarPrecio();


        void ListaSucursal();
    }

}