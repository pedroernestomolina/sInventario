using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Tool.CambioMasivoPrecio
{
    
    public interface ICambio: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {

        BindingSource GetPrecioSource { get; }
        BindingSource GetDepartamentoSource { get; }
        BindingSource GetGrupoSource { get; }
        BindingSource GetDestinoSource { get; }

        string GetPrecioId { get; }
        string GetDepartamentoId { get; }
        string  GetGrupoId { get; }
        string GetDestinoId { get; }

        void setPrecio(string id);
        void setDepartamento(string id);
        void setGrupo(string id);
        void setDestino(string id);

    }

}