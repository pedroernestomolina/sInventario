using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Ficha
    {

        public Identificacion identidad { get; set; }
        public Precio precio { get; set; }
        public Costo costo { get; set; }
        public Existencia existencia { get; set; }
        public Extra extra { get; set; }
        public Proveedor.Ficha proveedores { get; set; }

        public Decimal CostoDivisa { get; set; }
        public Decimal CostoDivisaUnd { get { return CostoDivisa / identidad.contenidoCompra; } }
        public Decimal ExistenciaTotal { get; set; }
        public string ExistenciaTotalDesc { get { return ExistenciaTotal.ToString("n" + Decimales); } }
        public Decimal PDivisaFull_1 { get; set; }
        public Decimal PDivisaFull_2 { get; set; }
        public Decimal PDivisaFull_3 { get; set; }
        public Decimal PDivisaFull_4 { get; set; }
        public Decimal PDivisaFull_5 { get; set; }
        public decimal PDivisaFullMay_1 { get; set; }
        public decimal PDivisaFullMay_2 { get; set; }
        public int ContenidoEmpMay_1 { get; set; }
        public int ContenidoEmpMay_2 { get; set; }

        public Decimal Costo { get; set; }
        public Decimal CostoUnidad  { get { return Costo / identidad.contenidoCompra; } }
        public Decimal PNeto_1 { get; set; }
        public Decimal PNeto_2 { get; set; }
        public Decimal PNeto_3 { get; set; }
        public Decimal PNeto_4 { get; set; }
        public Decimal PNeto_5 { get; set; }
        public Decimal PNetoMay_1 { get; set; }
        public Decimal PNetoMay_2 { get; set; }
        public Decimal PDivisaNeto_1 { get { return PDivisaFull_1 / ((identidad.tasaIva / 100) + 1); } }
        public Decimal PDivisaNeto_2 { get { return PDivisaFull_2 / ((identidad.tasaIva / 100) + 1); } }
        public Decimal PDivisaNeto_3 { get { return PDivisaFull_3 / ((identidad.tasaIva / 100) + 1); } }
        public Decimal PDivisaNeto_4 { get { return PDivisaFull_4 / ((identidad.tasaIva / 100) + 1); } }
        public Decimal PDivisaNeto_5 { get { return PDivisaFull_5 / ((identidad.tasaIva / 100) + 1); } }
        public Decimal PDivisaNetoMay_1 { get { return Neto(PDivisaFullMay_1, identidad.tasaIva); } }
        public Decimal PDivisaNetoMay_2 { get { return Neto(PDivisaFullMay_2, identidad.tasaIva); } }


        public Decimal CostoUndActual 
        { 
            get 
            {
                var rt = 0.0m;
                rt = CostoUnidad;
                if (identidad.AdmPorDivisa == Enumerados.EnumAdministradorPorDivisa.Si)
                    rt = CostoDivisaUnd;
                return rt;
            } 
        }


        public string AutoId { get { return identidad.auto; } }
        public string CodigoPrd { get { return identidad.codigo; } }
        public string DescripcionPrd { get { return identidad.descripcion; } }
        public string Departamento { get { return identidad.departamento; } }
        public string Grupo { get { return identidad.grupo; } }
        public string Marca { get { return identidad.marca; } }
        public string Referencia { get { return identidad.referencia; } }
        public string Empaque { get { return identidad.Empaque ; } }
        public string Impuesto { get { return identidad.Impuesto; } }
        public string Origen { get { return identidad.origen.ToString(); ; } }
        public string Estatus { get { return identidad.estatus.ToString(); } }
        public string EstatusOferta { get { return precio.estatusOferta.ToString(); } }
        public string ActivarCatalogo { get { return identidad.activarCatalogo.ToString(); } }
        public string Divisa { get { return identidad.AdmPorDivisa.ToString(); } }
        public string Pesado { get { return  extra.esPesado.ToString(); } }
        public DateTime FechaAlta { get { return identidad.fechaAlta ; } }
        public string FechaUltimaActualizacion { get { return identidad.fechaUltActualizacion.HasValue ? identidad.fechaUltActualizacion.Value.ToShortDateString() : ""; } }
        public string Producto { get { return CodigoPrd + Environment.NewLine + DescripcionPrd; } }
        public decimal CostoUnd { get { return costo.costoUnd; } }
        public string Decimales { get { return identidad.Decimales; } }
        public bool IsInactivo { get { return identidad.estatus == Enumerados.EnumEstatus.Inactivo ? true : false; } }
        public string Categoria 
        { 
            get 
            { 
                var rt="";

                switch (identidad.categoria)
                {
                    case  Enumerados.EnumCategoria.ProductoTerminado:
                        rt = "Producto Terminado";
                        break;
                    case Enumerados.EnumCategoria.BienServicio:
                        rt = "Bien de Servicio";
                        break;
                    case Enumerados.EnumCategoria.MateriaPrima:
                        rt = "Materia Prima";
                        break;
                    case Enumerados.EnumCategoria.UsoInterno:
                        rt = "Uso Interno";
                        break;
                    case Enumerados.EnumCategoria.SubProducto:
                        rt = "Sub Producto";
                        break;
                }

                return rt; 
            } 
        }


        public Ficha()
        {
            identidad = new Identificacion();
            precio = new Precio();
            costo = new Costo();
            existencia = new Existencia();
            extra = new Extra();
            proveedores = new Proveedor.Ficha();
        }

        public Ficha(Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha ficha,
            OOB.LibInventario.Producto.Data.Existencia fEx, 
            OOB.LibInventario.Producto.Data.Costo fCosto)
            : this()
        {
            identidad = new Identificacion(ficha);
            existencia = new Existencia(fEx);
            costo = new Costo(fCosto);
        }


        private decimal Neto(decimal precio, decimal tasa) 
        {
            var rt = 0.0m;
            rt = precio / ((tasa / 100) + 1);
            return rt;
        }

    }

}