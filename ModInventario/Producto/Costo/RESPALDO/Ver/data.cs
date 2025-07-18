using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Costo.Ver
{
    
    public class data
    {

        private string producto;
        private string costoUnit;
        private string admDivisa;
        private string tasaIva;
        private decimal tasaCambioActual;
        private string fechaUltActCosto;
        private string empaqueContenido;
        private bool isAdmDivisa;
        private costo costo_proveedor;
        private costo costo_importacion;
        private costo costo_vario;
        private costo costo_final;
        private costo costo_promedio;
        private costo costo_divisa;


        public string Producto { get { return producto; } }
        public string CostoUnitario { get { return costoUnit; } }
        public string AdmDivisa { get { return admDivisa; } }
        public string TasaIva { get { return tasaIva; } }
        public string EmpaqueContenido { get { return empaqueContenido; } }
        public string TasaCambioActual { get { return tasaCambioActual.ToString("n2"); } }
        public string FechaUltActCosto { get { return fechaUltActCosto; } }
        public bool IsAdmDivisa { get { return isAdmDivisa; } }
        public costo CostoProveedor { get { return costo_proveedor; } }
        public costo CostoImportacion { get { return costo_importacion; } }
        public costo CostoVario { get { return costo_vario; } }
        public costo CostoFinal { get { return costo_final; } }
        public costo CostoPromedio { get { return costo_promedio; } }
        public costo CostoDivisa { get { return costo_divisa; } }


        public data()
        {
            costo_proveedor = new costo();
            costo_importacion = new costo();
            costo_vario = new costo();
            costo_final = new costo();
            costo_promedio = new costo();
            costo_divisa = new costo();
            Limpiar();
        }


        public void Limpiar()
        {
            producto="";
            costoUnit="";
            admDivisa="";
            tasaIva="";
            tasaCambioActual=0.0m;
            fechaUltActCosto="";
            empaqueContenido="";
            costo_proveedor.Limpiar();
        }

        public void setFicha(OOB.LibInventario.Producto.Data.Costo s, decimal tasaCambio)
        {
            producto = s.codigo + Environment.NewLine + s.descripcion;
            empaqueContenido = s.empaqueCompra.Trim() + "/" + s.contEmpaqueCompra.ToString();
            admDivisa = s.admDivisa.ToString();
            tasaIva = "EXENTO";
            fechaUltActCosto = s.fechaUltCambio;
            costoUnit = s.costoUnd.ToString("N2");
            tasaCambioActual = tasaCambio;
            isAdmDivisa = false;
            costo_proveedor.setFicha(s.contEmpaqueCompra, s.tasaIva, s.costoProveedorUnd);
            costo_importacion.setFicha(s.contEmpaqueCompra, s.tasaIva, s.costoImportacionUnd);
            costo_vario.setFicha(s.contEmpaqueCompra, s.tasaIva, s.costoVarioUnd);
            costo_final .setFicha(s.contEmpaqueCompra, s.tasaIva, s.costoUnd);
            costo_promedio.setFicha(s.contEmpaqueCompra, s.tasaIva, s.costoPromedioUnd);
            costo_divisa.setFicha(s.contEmpaqueCompra, s.tasaIva, s.costoDivisaUnd);

            if (s.tasaIva > 0)
            {
                tasaIva = s.tasaIva.ToString("n2").Trim().PadLeft(5, '0') + "%";
            }
            if (s.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
            {
                isAdmDivisa = true;
                costoUnit = s.costoDivisaUnd.ToString("N2");
            }
        }

    }

}