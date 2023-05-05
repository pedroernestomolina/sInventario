using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Filtros.BuscarPor
{
    public interface IFiltro
    {
        string GetDescripcion { get;  }
        bool GetHabilitado { get;  }
        bool BuscarIsOk { get; }
        LibUtilitis.Opcion.IData ItemSeleccionado { get; }

        void setCadenaBuscar(string cad);

        void Limpiar();
        void Buscar();

        void Inicializa();
    }
}