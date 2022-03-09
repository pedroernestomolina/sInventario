using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Editar
{
    
    public class Gestion
    {

        private IGestion miGestion;


        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque1 { get { return miGestion.Empaque1; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque2 { get { return miGestion.Empaque2; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque3 { get { return miGestion.Empaque3; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque4 { get { return miGestion.Empaque4; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque5 { get { return miGestion.Empaque5; } }

        public BindingSource SourceEmpaque1 { get { return miGestion.SourceEmpaque1; } }
        public BindingSource SourceEmpaque2 { get { return miGestion.SourceEmpaque2; } }
        public BindingSource SourceEmpaque3 { get { return miGestion.SourceEmpaque3; } }
        public BindingSource SourceEmpaque4 { get { return miGestion.SourceEmpaque4; } }
        public BindingSource SourceEmpaque5 { get { return miGestion.SourceEmpaque5; } }
        public BindingSource SourceEmpaqueMay_1 { get { return miGestion.SourceEmpaqueMay_1; } }
        public BindingSource SourceEmpaqueMay_2 { get { return miGestion.SourceEmpaqueMay_2; } }

        public string Producto { get { return miGestion.Producto; } }
        public string CostoUnitario { get { return miGestion.CostoUnitario; } }
        public string AdmDivisa { get { return miGestion.AdmDivisa; } }
        public string TasaIva { get { return miGestion.TasaIva; } }
        public string MetodoCalculoUtilidad { get { return miGestion.MetodoCalculoUtilidad; } }
        public string TasaCambioActual { get { return miGestion.TasaCambioActual; } }
        public string FechaUltActCosto { get { return miGestion.FechaUltActCosto; } }
        public bool PrefRegistroPrecioIsNeto { get { return miGestion.PrefRegistroPrecioIsNeto; } }

        public string CostoEmpaqueCompra { get { return miGestion.CostoEmpaqueCompra; } }
        public string EmpaqueCompra { get { return miGestion.EmpaqueCompra; } }

        public data Precio_1 { get { return miGestion.Precio_1; } }
        public data Precio_2 { get { return miGestion.Precio_2; } }
        public data Precio_3 { get { return miGestion.Precio_3; } }
        public data Precio_4 { get { return miGestion.Precio_4; } }
        public data Precio_5 { get { return miGestion.Precio_5; } }
        public data May_1 { get { return miGestion.May_1; } }
        public data May_2 { get { return miGestion.May_2; } }

        public bool Habilitar_ContenidoEmpaque { get { return miGestion.Habilitar_ContenidoEmpaque; } }
        public bool Habilitar_ContenidoEmpaque5 { get { return miGestion.Habilitar_ContenidoEmpaque5; } }
        public bool Habilitar_Empaque { get { return miGestion.Habilitar_Empaque; } }
        public bool IsCerrarHabilitado { get { return miGestion.IsCerrarHabilitado; } }
        public bool IsModoDivisa { get { return miGestion.IsModoDivisa; } }
        public bool IsEditarPrecioOk { get { return miGestion.IsEditarPrecioOk; } }


        public Gestion(IGestion gestion)
        {
            miGestion = gestion;
        }


        public void setFicha(string autoprd)
        {
            miGestion.setFicha(autoprd);
        }

        EditarFrm frm ;
        public void Inicia()
        {
            Limpiar();
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new EditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            miGestion.Limpiar();
        }

        private bool CargarData()
        {
            return miGestion.CargarData();
        }

        public void ModoPrecioSw()
        {
            miGestion.ModoPrecioSw();
        }

        public void Procesar()
        {
            miGestion.Procesar();
        }

        public void InicializarIsCerrarHabilitado()
        {
            miGestion.InicializarIsCerrarHabilitado();
        }


        public void setEmpaqueMayor_1(string auto)
        {
            miGestion.setEmpaqueMayor_1(auto);
        }

        public void setContenidoMayor_1(int p)
        {
            miGestion.setContenidoMayor_1(p);
        }

        public void setUtilidadMayor_1(decimal p)
        {
            miGestion.setUtilidadMayor_1(p);
        }

        public void setNetoMayor_1(decimal p)
        {
            miGestion.setNetoMayor_1(p);
        }

        public void setFullMayor_1(decimal p)
        {
            miGestion.setFullMayor_1(p);
        }

        public void setEmpaqueMayor_2(string auto)
        {
            miGestion.setEmpaqueMayor_2(auto);
        }

        public void setContenidoMayor_2(int p)
        {
            miGestion.setContenidoMayor_2(p);
        }

        public void setUtilidadMayor_2(decimal p)
        {
            miGestion.setUtilidadMayor_2(p);
        }

        public void setNetoMayor_2(decimal p)
        {
            miGestion.setNetoMayor_2(p);
        }

        public void setFullMayor_2(decimal p)
        {
            miGestion.setFullMayor_2(p);
        }

        public decimal Neto(decimal valor)
        {
            var rt = 0.0m;
            rt = valor / ((miGestion.TasaIvaValor /100)+1);
            return rt;
        }

    }

}