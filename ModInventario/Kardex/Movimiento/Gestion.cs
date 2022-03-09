using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Kardex.Movimiento
{
    
    public class Gestion
    {


        private string autoPrd;
        private OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias dias;
        private OOB.LibInventario.Kardex.Movimiento.Resumen.Ficha ficha;
        private Detalle.Gestion _gestionDetalle;
        private data compra;
        private data venta;
        private data inventario;

        private decimal compraFac;
        private decimal compraNcr;
        private decimal ventaFac;
        private decimal ventaNcr;
        private decimal ajuste;
        private decimal traslado;
        private decimal cargoDescargo;


        public BindingSource Compra { get { return compra.Source; } }
        public BindingSource Venta{ get { return venta.Source; } }
        public BindingSource Inventario{ get { return inventario.Source; } }
        public string CompraFac { get { return compraFac.ToString(Decimales); } }
        public string CompraNcr { get { return compraNcr.ToString(Decimales); } }
        public string VentaFac { get { return ventaFac.ToString(Decimales); } }
        public string VentaNcr { get { return ventaNcr.ToString(Decimales); } }
        public string CargoDescgargo { get { return cargoDescargo.ToString(Decimales); }  }
        public string Ajuste { get { return ajuste.ToString(Decimales); } }
        public string Traslado { get { return traslado.ToString(Decimales); } }


        public string Producto { get { return ficha.codigoProducto + Environment.NewLine + ficha.nombreProducto; } }
        public string ExActual { get { return ficha.existenciaActual.ToString(Decimales); } }
        public string ExFecha { get { return ficha.existenciaFecha.ToString(Decimales); } }
        public string Fecha { get { return "Exist Al "+ficha.fecha; } }
        public string Decimales { get { return "n" + ficha.decimales; } }


        public Gestion()
        {
            _gestionDetalle = new Detalle.Gestion();
            compra = new data();
            venta= new data();
            inventario= new data();
            Limpiar();
        }


        public void Limpiar() 
        {
            dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.SinDefinir;
            compra.Limpiar();
            venta.Limpiar();
            inventario.Limpiar();
        }

        KardexFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new KardexFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return Cargar();
        }

        public void setFicha(string prd)
        {
            autoPrd = prd;
        }

        public void Procesar()
        {
            Cargar();
        }

        public bool Cargar() 
        {
            var rt = true;
            cargoDescargo = 0.0m;
            ajuste= 0.0m;
            traslado = 0.0m;

            var filtro = new OOB.LibInventario.Kardex.Movimiento.Resumen.Filtro()
            {
                autoProducto = autoPrd,
                ultDias =  dias,
            };
            var r01 = Sistema.MyData.Producto_Kardex_Movimiento_Lista_Resumen(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            ficha = r01.Entidad;
            compra.setFicha(r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "COMPRAS").ToList());
            venta.setFicha(r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "VENTAS").ToList());
            inventario.setFicha(r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "INVENTARIO").ToList());

            compraFac = r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "COMPRAS" && w.siglas == "FAC").Sum(s => s.cntInventario);
            compraNcr = r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "COMPRAS" && w.siglas == "NCR").Sum(s => s.cntInventario);

            ventaFac = r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "VENTAS" && w.siglas == "FAC").Sum(s => s.cntInventario);
            ventaNcr = r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "VENTAS" && w.siglas == "NCR").Sum(s => s.cntInventario);

            cargoDescargo = r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "INVENTARIO" && w.autoConcepto != "0000000007" && (w.siglas == "CAR" || w.siglas=="DES")).Sum(s => s.cntInventario);
            ajuste= r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "INVENTARIO" && w.autoConcepto == "0000000007").Sum(s => s.cntInventario);
            traslado= r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "INVENTARIO" && w.siglas == "TRA" && w.cntInventario>0).Sum(s => s.cntInventario);
            return rt;
        }

        public void setDias( OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias xdias)
        {
            dias = xdias;
        }

        public void VerDetalleCompra()
        {
            var item = (detalle)Compra.Current;
            if (item != null) 
            {
                VerDetalle(item);
            }
        }

        private void VerDetalle(detalle item)
        {
            var dep = item.Deposito;
            var concept = item.Concepto;
            _gestionDetalle.setFicha(autoPrd, dep, concept, dias, item);
            _gestionDetalle.Inicia();
        }

        public void VerDetalleVenta()
        {
            var item = (detalle)Venta.Current;
            if (item != null)
            {
                VerDetalle(item);
            }
        }

        public void VerDetalleInventario()
        {
            var item = (detalle)Inventario.Current;
            if (item != null)
            {
                VerDetalle(item);
            }
        }

    }

}