using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.EditarCambiar.ModoBasico
{
    
    public interface IEditarBasico: IEditar
    {

        BindingSource GetEmp1_Source { get; }
        void setEmp1(string id);
        BindingSource GetEmp2_Source { get; }
        void setEmp2(string id);
        BindingSource GetEmp3_Source { get; }
        void setEmp3(string id);


        string GetEmp1_Id { get; }
        string GetEmp2_Id { get; }
        string GetEmp3_Id { get; }


        void setContEmp_1(int cont);
        void setUt_1(decimal ut);
        void setPN_1(decimal monto);
        void setPF_1(decimal monto);
        int GetCont1 { get; }
        decimal GetUt1 { get; }
        decimal GetPN1 { get; }
        decimal GetPF1 { get; }
        decimal GetUtActual1 { get; }
        bool ERR_1 { get; }


        void setContEmp_2(int cont);
        void setUt_2(decimal ut);
        void setPN_2(decimal monto);
        void setPF_2(decimal monto);
        int GetCont2 { get; }
        decimal GetUt2 { get; }
        decimal GetPN2 { get; }
        decimal GetPF2 { get; }
        decimal GetUtActual2 { get; }
        bool ERR_2 { get; }


        void setContEmp_3(int cont);
        void setUt_3(decimal ut);
        void setPN_3(decimal monto);
        void setPF_3(decimal monto);
        int GetCont3 { get; }
        decimal GetUt3 { get; }
        decimal GetPN3 { get; }
        decimal GetPF3 { get; }
        decimal GetUtActual3 { get; }
        bool ERR_3 { get; }


        string GetInfProducto { get; }
        string GetInfEmpCompraPrd { get; }
        decimal GetInfCostoEmpCompraPrd { get; }
        string GetInfMetodoCalculoUt { get; }
        decimal GetInfTasaCambioPrd { get; }
        string GetInfAdmDivisaPrd { get; }
        decimal GetInfTasaIvaPrd { get; }
        decimal GetInfCostoUndPrd { get; }
        string GetInfFechaUltActPrd { get; }
        bool GetEsAdmDivisaPrd { get; }

    }

}