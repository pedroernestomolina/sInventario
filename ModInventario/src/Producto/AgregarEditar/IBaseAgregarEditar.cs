using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.AgregarEditar
{
    
    public interface IBaseAgregarEditar: IGestion, Gestion.IAbandonar, Gestion.IProcesar
    {


        BindingSource GetCodAlterno_Source { get; }
        BindingSource GetDepartamento_Source { get; }
        BindingSource GetGrupo_Source { get; }
        BindingSource GetMarca_Source { get; }
        BindingSource GetImpuesto_Source { get; }
        BindingSource GetOrigen_Source { get; }
        BindingSource GetDivisa_Source { get; }
        BindingSource GetCategoria_Source { get; }
        BindingSource GetClasificacion_Source { get; }
        BindingSource GetEmpCompra_Source { get; }
        BindingSource GetEmpVentaTipo1_Source { get; }
        BindingSource GetEmpVentaTipo2_Source { get; }
        BindingSource GetEmpVentaTipo3_Source { get; }


        string GetDepartamento_Id { get; }
        string GetGrupo_Id { get; }
        string GetMarca_Id { get; }
        string GetImpuesto_Id { get; }
        string GetOrigen_Id { get; }
        string GetCategoria_Id { get; }
        string GetClasificacion_Id { get; }
        string GetDivisa_id { get; }
        string GetEmpCompra_Id { get; }
        string GetEmpVentaTipo1_ID { get; }
        string GetEmpVentaTipo2_ID { get; }
        string GetEmpVentaTipo3_ID { get; }


        void setCodigoProducto(string v);
        void setDescripcionProducto(string v);
        void setNombreProducto(string v);
        void setContEmpCompra(int v);
        void setPlu(string v);
        void setDiasEmpaque(int v);
        void setContEmpVentaTipo1(int v);
        void setContEmpVentaTipo2(int v);
        void setContEmpVentaTipo3(int v);
        void setCodigoAlterno(string v);
        void setPesado(bool v);


        string GetCodigoProducto { get; }
        string GetDescripcionProducto { get;  }
        string GetNombreProducto { get; }
        string GetPlu { get; }
        bool GetEsPesado { get; }
        int GetContEmpVentaTipo1 { get; }
        int GetContEmpVentaTipo2 { get; }
        int GetContEmpVentaTipo3 { get; }
        int GetContEmpCompra { get; }
        int GetDiasEmpaque { get; }


        void setDepartamento(string id);
        void setGrupo(string id);
        void setDivisa(string id);
        void setClasificacion(string id);
        void setCategoria(string id);
        void setOrigen(string id);
        void setImpuesto(string id);
        void setMarca(string id);
        void setEmpCompra(string id);
        void setEmpVentaTipo1(string id);
        void setEmpVentaTipo2(string id);
        void setEmpVentaTipo3(string id);


        void ListaPlu();
        void AgregarCodigoAlterno();
        void EliminarCodigoAlterno();


        bool IsAgregarEditarOk { get; }
        string AutoProductoAgregado { get; }


        void setFicha(string p);

    }

}