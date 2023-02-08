using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.TallaColorSabor
{
    public interface ITallaColorSabor
    {
        string GetTallaColorSabor_Desc { get; }
        BindingSource GetTallaColorSabor_Source { get; }
        int GetTallaColorSabor_CntItems { get; }

        void setTallaColorSabor(string desc);
        void AgregarTallaColorSabor();
        void EliminarTallaColorSabor();
        void Inicializa();
        List<dataRetornar> DataRetornar();
        void CargarData(List<data> lst);
    }
}