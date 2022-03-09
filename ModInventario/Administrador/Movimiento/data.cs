using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Administrador.Movimiento
{
    
    public class data
    {

        private OOB.LibInventario.Movimiento.Lista.Ficha rg;


        public OOB.LibInventario.Movimiento.Lista.Ficha Ficha { get { return rg; } }
        public string FechaHora { get { return rg.fecha.ToShortDateString() + ", " + rg.hora; } }
        public string DocumentoNro { get { return rg.docNro; } }
        public string Sucursal { get { return rg.docSucursal; } }
        public string Concepto { get { return rg.docConcepto; } }
        public string UsuarioEstacion { get { return rg.usuario+", "+rg.estacion; } }
        public string SMonto { get { return rg.docMonto.ToString("n2"); } }
        public string Situacion { get { return rg.docSituacion ; } }
        public bool IsAnulado { get { return rg.isDocAnulado; } }
        public string SRenglones { get { return rg.docRenglones.ToString(); } }
        public string DepOrigen { get { return rg.depositoOrigen; } }
        public string DepDestino { get { return rg.depositoDestino; } }
        public string STipoDoc
        { 
            get 
            {
                var t = "";
                switch (rg.docTipo) 
                {
                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo:
                        t = "CARGO";
                        break;
                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo:
                        t = "DESCARGO";
                        break;
                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado:
                        t = "TRASLADO";
                        break;
                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste:
                        t = "AJUSTE";
                        break;
                }
                return t;  
            }
        }


        public data(OOB.LibInventario.Movimiento.Lista.Ficha rg)
        {
            this.rg = rg;
        }

    }

}