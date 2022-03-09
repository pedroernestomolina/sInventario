using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.Editar
{
    
    public interface IGestion
    {

        List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque1 { get; }
        List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque2 { get; }
        List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque3 { get; }
        List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque4 { get; }
        List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque5 { get; }
        System.Windows.Forms.BindingSource SourceEmpaque1 { get; }
        System.Windows.Forms.BindingSource SourceEmpaque2 { get; }
        System.Windows.Forms.BindingSource SourceEmpaque3 { get; }
        System.Windows.Forms.BindingSource SourceEmpaque4 { get; }
        System.Windows.Forms.BindingSource SourceEmpaque5 { get; }
        System.Windows.Forms.BindingSource SourceEmpaqueMay_1 { get; }
        System.Windows.Forms.BindingSource SourceEmpaqueMay_2 { get; }


        string Producto { get; }
        string CostoUnitario { get; }
        string AdmDivisa { get; }
        string TasaIva { get; }
        string TasaCambioActual { get; }
        string MetodoCalculoUtilidad { get; }
        string FechaUltActCosto { get; }
        bool IsModoDivisa { get;  }
        bool PrefRegistroPrecioIsNeto { get; }
        bool IsEditarPrecioOk { get; }
        decimal TasaIvaValor { get; }


        data Precio_1 { get; }
        data Precio_2 { get; }
        data Precio_3 { get; }
        data Precio_4 { get; }
        data Precio_5 { get; }
        data May_1 { get; }
        data May_2 { get; }

        bool Habilitar_ContenidoEmpaque { get; }
        bool Habilitar_ContenidoEmpaque5 { get; }
        bool Habilitar_Empaque { get; }
        bool IsCerrarHabilitado { get; }


        bool CargarData();
        void setFicha(string autoprd);
        void ModoPrecioSw();
        void Procesar();
        void InicializarIsCerrarHabilitado();
        void Limpiar();
        void setEmpaqueMayor_1(string auto);
        void setContenidoMayor_1(int p);
        void setUtilidadMayor_1(decimal p);
        void setNetoMayor_1(decimal p);
        void setFullMayor_1(decimal p);
        void setEmpaqueMayor_2(string auto);
        void setContenidoMayor_2(int p);
        void setUtilidadMayor_2(decimal p);
        void setNetoMayor_2(decimal p);
        void setFullMayor_2(decimal p);
        string CostoEmpaqueCompra { get; }
        string EmpaqueCompra { get;  }

    }

}