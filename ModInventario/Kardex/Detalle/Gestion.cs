using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Kardex.Detalle
{
    
    public class Gestion
    {

        private Movimiento.detalle detalle;
        private string autoProducto;
        private OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias nDias;
        private OOB.LibInventario.Kardex.Movimiento.Detalle.Ficha ficha;
        private string deposito;
        private string concepto;
        private List<data> lData;
        private BindingSource bs;


        public BindingSource Source { get { return bs; } }
        public string Producto { get { return ficha.codigoProducto + Environment.NewLine + ficha.nombreProducto; } }
        public string Deposito { get { return deposito; } }
        public string Concepto { get { return concepto; } }
        public string NotaMovimiento { get; set; }


        public Gestion()
        {
            lData=new List<data>();
            bs = new BindingSource();
            bs.CurrentChanged+=bs_CurrentChanged;
            bs.DataSource = lData;
            autoProducto = "";
            nDias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.SinDefinir;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (bs.Current!=null)
            {
                NotaMovimiento = ((data)bs.Current).Nota;
                if (frm != null) 
                {
                    frm.setNota(((data)bs.Current).Nota);
                }
            }
        }


        public void Inicializa()
        {
            _filtros = "";
        }
        DetalleFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new DetalleFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.LibInventario.Kardex.Movimiento.Detalle.Filtro()
            {
                autoConcepto = detalle.Data.autoConcepto,
                autoDeposito = detalle.Data.autoDeposito,
                autoProducto = autoProducto,
                modulo = detalle.Data.modulo,
                ultDias = nDias,
            };
            var r01 = Sistema.MyData.Producto_Kardex_Movimiento_Lista_Detalle(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            ficha= r01.Entidad;

            lData.Clear();
            foreach (var reg in r01.Entidad.Data.OrderByDescending(o=>o.fecha).ThenByDescending(o=>o.hora).ToList()) 
            {
                lData.Add(new data(reg, ficha.decimales));
            }
            bs.CurrencyManager.Refresh();

            return rt;
        }

        private string _filtros;
        public void setFicha(string autoprd, string dep, string concept, OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias dias,  Movimiento.detalle item)
        {
            deposito=dep;
            concepto=concept;
            autoProducto = autoprd;
            nDias = dias;
            detalle = item;
        }

        public void Imprimir()
        {
            if (lData.Count > 0)
            {
                _filtros += "Filtro: " + Producto + ", Deposito: " + deposito + ", Concepto: " + concepto + ", Ultimos: " + nDias.ToString();
                var rp = new Reportes.Kardex.gestionRep(lData, _filtros);
                rp.Generar();
            }
        }

    }

}