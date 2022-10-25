using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Kardex.Movimiento
{
    
    public class Gestion: IMov
    {


        private string _autoPrd;
        private data _compra;
        private data _venta;
        private data _inventario;
        private Detalle.Gestion _gestionDetalle;
        private FiltrosGen.IOpcion _gDeposito;
        private FiltrosGen.IOpcion _gDias;
        private OOB.LibInventario.Kardex.Movimiento.Resumen.Ficha _ficha;
        private OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias _dias;


        public string Decimales { get { return "n" + _ficha.decimales; } }


        public Gestion()
        {
            _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.SinDefinir;
            _compra = new data();
            _venta= new data();
            _inventario= new data();
            _gestionDetalle = new Detalle.Gestion();
            _gDeposito = new FiltrosGen.Opcion.Gestion();
            _gDias = new FiltrosGen.Opcion.Gestion();
        }


        KardexFrm frm;
        public void Inicia()
        {
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

        public void setFicha(string prd)
        {
            _autoPrd = prd;
        }

        public void Procesar()
        {
            Cargar();
        }

        public bool Cargar() 
        {
            var rt = true;

            var filtro = new OOB.LibInventario.Kardex.Movimiento.Resumen.Filtro()
            {
                autoProducto = _autoPrd,
                autoDeposito= _gDeposito.GetId,
                ultDias =  _dias,
            };
            var r01 = Sistema.MyData.Producto_Kardex_Movimiento_Lista_Resumen(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _ficha = r01.Entidad;
            _compra.setFicha(r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "COMPRAS").ToList(), Decimales);
            _venta.setFicha(r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "VENTAS").ToList(),Decimales);
            _inventario.setFicha(r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "INVENTARIO").ToList(),Decimales);

            return rt;
        }


        private void VerDetalle(detalle item)
        {
            var dep = item.Deposito;
            var concept = item.Concepto;
            _gestionDetalle.setFicha(_autoPrd, dep, concept, _dias, item);
            _gestionDetalle.Inicia();
        }

        public void VerDetalleCompra()
        {
            var item = (detalle)_compra.Source.Current;
            if (item != null)
            {
                VerDetalle(item);
            }
        }

        public void VerDetalleVenta()
        {
            var item = (detalle)_venta.Source.Current;
            if (item != null)
            {
                VerDetalle(item);
            }
        }

        public void VerDetalleInventario()
        {
            var item = (detalle)_inventario.Source.Current;
            if (item != null)
            {
                VerDetalle(item);
            }
        }


        public void Inicializa()
        {
            _compra.Limpiar();
            _venta.Limpiar();
            _inventario.Limpiar();
            _gestionDetalle.Inicializa();
            _gDeposito.Inicializa();
            _gDias.Inicializa();
        }


        public string GetProductoInfo { get { return _ficha.codigoProducto + Environment.NewLine + _ficha.nombreProducto; } }


        public BindingSource GetCompraSource { get { return _compra.Source; } }
        public BindingSource GetVentaSource { get { return _venta.Source; } }
        public BindingSource GetInventarioSource { get { return _inventario.Source; } }


        public string  GetExActual { get { return _ficha.existenciaActual.ToString(Decimales); } }
        public string GetExFecha { get { return _ficha.existenciaFecha.ToString(Decimales); } }
        public string  GetFecha { get { return "Exist Al " + _ficha.fecha; } }


        public BindingSource GetDiasSource { get { return _gDias.Source; } }
        public void setDias(string id)
        {
            _gDias.setFicha(id);
            switch (_gDias.GetId)
            {
                case "01": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.Hoy; break;
                case "02": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.Ayer; break;
                case "03": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._7Dias; break;
                case "04": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._15Dias; break;
                case "05": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._30Dias; break;
                case "06": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._45Dias; break;
                case "07": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._60Dias; break;
                case "08": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._90Dias; break;
                case "09": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias._120Dias; break;
                case "10": _dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.Todo; break;
            }
        }


        public BindingSource GetDepositoSource { get { return _gDeposito.Source; } }
        public void setDeposito(string id)
        {
            _gDeposito.setFicha(id);
        }


        private bool CargarData()
        {
            try
            {
                var r02 = Sistema.MyData.Deposito_GetLista();
                var lst = r02.Lista.Select(s =>
                {
                    var nr = new ficha()
                    {
                        codigo = s.codigo,
                        desc = s.nombre,
                        id = s.auto,
                    };
                    return nr;
                });
                _gDeposito.setData(lst.OrderBy(o => o.desc).ToList());
                var lst2 = new List<ficha>();
                lst2.Add(new ficha() { id = "01", codigo = "", desc = "     Hoy" });
                lst2.Add(new ficha() { id = "02", codigo = "", desc = "    Ayer" });
                lst2.Add(new ficha() { id = "03", codigo = "", desc = "  7 Dias " });
                lst2.Add(new ficha() { id = "04", codigo = "", desc = " 15 Dias" });
                lst2.Add(new ficha() { id = "05", codigo = "", desc = " 30 Dias" });
                lst2.Add(new ficha() { id = "06", codigo = "", desc = " 45 Dias" });
                lst2.Add(new ficha() { id = "07", codigo = "", desc = " 60 Dias" });
                lst2.Add(new ficha() { id = "08", codigo = "", desc = " 90 Dias" });
                lst2.Add(new ficha() { id = "09", codigo = "", desc = "120 Dias" });
                lst2.Add(new ficha() { id = "10", codigo = "", desc = "   1 Año" });
                _gDias.setData(lst2);

                return Cargar();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

    }

}