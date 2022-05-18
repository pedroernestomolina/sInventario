using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.ModoSucursal.Editar
{
    
    public interface IEditar: ModInventario.IGestion  
    {

        bool IsProcesarIsOk { get; }
        bool IsAbandonarIsOk { get; }
        bool IsEditarPrecioIsOk { get; }


        void setIdItemEditar(string idAuto);
        void AbandonarFicha();


        BindingSource GetEmp1_Source { get; }
        void setEmp1(string id);
        BindingSource GetEmp2_Source { get; }
        void setEmp2(string id);
        BindingSource GetEmp3_Source { get; }
        void setEmp3(string id);
        BindingSource GetEmp4_Source { get; }
        void setEmp4(string id);
        BindingSource GetEmp5_Source { get; }
        void setEmp5(string id);
        //
        BindingSource GetEmpM1_Source { get; }
        void setEmpM1(string id);
        BindingSource GetEmpM2_Source { get; }
        void setEmpM2(string id);
        BindingSource GetEmpM3_Source { get; }
        void setEmpM3(string id);
        BindingSource GetEmpM4_Source { get; }
        void setEmpM4(string id);
        //
        BindingSource GetEmpD1_Source { get; }
        void setEmpD1(string id);
        BindingSource GetEmpD2_Source { get; }
        void setEmpD2(string id);
        BindingSource GetEmpD3_Source { get; }
        void setEmpD3(string id);
        BindingSource GetEmpD4_Source { get; }
        void setEmpD4(string id);


        string GetDescPrecio1 { get; }
        string GetDescPrecio2 { get; }
        string GetDescPrecio3 { get; }
        string GetDescPrecio4 { get; }
        string GetDescPrecio5 { get; }


        string GetEmp1_Id { get; }
        string GetEmp2_Id { get; }
        string GetEmp3_Id { get; }
        string GetEmp4_Id { get; }
        string GetEmp5_Id { get; }
        //
        string GetEmpM1_Id { get; }
        string GetEmpM2_Id { get; }
        string GetEmpM3_Id { get; }
        string GetEmpM4_Id { get; }
        //
        string GetEmpD1_Id { get; }
        string GetEmpD2_Id { get; }
        string GetEmpD3_Id { get; }
        string GetEmpD4_Id { get; }


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


        void setContEmp_4(int cont);
        void setUt_4(decimal ut);
        void setPN_4(decimal monto);
        void setPF_4(decimal monto);
        int GetCont4 { get; }
        decimal GetUt4 { get; }
        decimal GetPN4 { get; }
        decimal GetPF4 { get; }
        decimal GetUtActual4 { get; }
        bool ERR_4 { get; }


        void setContEmp_5(int cont);
        void setUt_5(decimal ut);
        void setPN_5(decimal monto);
        void setPF_5(decimal monto);
        int GetCont5 { get; }
        decimal GetUt5 { get; }
        decimal GetPN5 { get; }
        decimal GetPF5 { get; }
        decimal GetUtActual5 { get; }
        bool ERR_5 { get; }


        void setContEmp_M1(int cont);
        void setUt_M1(decimal ut);
        void setPN_M1(decimal monto);
        void setPF_M1(decimal monto);
        int GetContM1 { get; }
        decimal GetUtM1 { get; }
        decimal GetPNM1 { get; }
        decimal GetPFM1 { get; }
        decimal GetUtActualM1 { get; }
        bool ERR_M1 { get; }


        void setContEmp_M2(int cont);
        void setUt_M2(decimal ut);
        void setPN_M2(decimal monto);
        void setPF_M2(decimal monto);
        int GetContM2 { get; }
        decimal GetUtM2 { get; }
        decimal GetPNM2 { get; }
        decimal GetPFM2 { get; }
        decimal GetUtActualM2 { get; }
        bool ERR_M2 { get; }


        void setContEmp_M3(int cont);
        void setUt_M3(decimal ut);
        void setPN_M3(decimal monto);
        void setPF_M3(decimal monto);
        int GetContM3 { get; }
        decimal GetUtM3 { get; }
        decimal GetPNM3 { get; }
        decimal GetPFM3 { get; }
        decimal GetUtActualM3 { get; }
        bool ERR_M3 { get; }


        void setContEmp_M4(int cont);
        void setUt_M4(decimal ut);
        void setPN_M4(decimal monto);
        void setPF_M4(decimal monto);
        int GetContM4 { get; }
        decimal GetUtM4 { get; }
        decimal GetPNM4 { get; }
        decimal GetPFM4 { get; }
        decimal GetUtActualM4 { get; }
        bool ERR_M4 { get; }


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


        void Procesar();


        void setContEmp_D1(int cont);
        void setUt_D1(decimal ut);
        void setPN_D1(decimal monto);
        void setPF_D1(decimal monto);
        int GetContD1 { get; }
        decimal GetUtD1 { get; }
        decimal GetPND1 { get; }
        decimal GetPFD1 { get; }
        decimal GetUtActualD1 { get; }
        bool ERR_D1 { get; }


        void setContEmp_D2(int cont);
        void setUt_D2(decimal ut);
        void setPN_D2(decimal monto);
        void setPF_D2(decimal monto);
        int GetContD2 { get; }
        decimal GetUtD2 { get; }
        decimal GetPND2 { get; }
        decimal GetPFD2 { get; }
        decimal GetUtActualD2 { get; }
        bool ERR_D2 { get; }


        void setContEmp_D3(int cont);
        void setUt_D3(decimal ut);
        void setPN_D3(decimal monto);
        void setPF_D3(decimal monto);
        int GetContD3 { get; }
        decimal GetUtD3 { get; }
        decimal GetPND3 { get; }
        decimal GetPFD3 { get; }
        decimal GetUtActualD3 { get; }
        bool ERR_D3 { get; }


        void setContEmp_D4(int cont);
        void setUt_D4(decimal ut);
        void setPN_D4(decimal monto);
        void setPF_D4(decimal monto);
        int GetContD4 { get; }
        decimal GetUtD4 { get; }
        decimal GetPND4 { get; }
        decimal GetPFD4 { get; }
        decimal GetUtActualD4 { get; }
        bool ERR_D4 { get; }


        BindingSource GetEmpTipo_1_Source { get; }
        int GetContEmpTipo_1 { get; }
        BindingSource GetEmpTipo_2_Source { get; }
        int GetContEmpTipo_2 { get; }
        BindingSource GetEmpTipo_3_Source { get; }
        int GetContEmpTipo_3 { get; }

    }

}