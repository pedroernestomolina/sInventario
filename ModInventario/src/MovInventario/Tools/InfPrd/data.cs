using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Tools.InfPrd
{
    public class data
    {
        private string _fechaHora;
        private string _docNro;
        private string _usuarioEstacion;
        private string _depOrigenDesc;
        private string _depDestinoDesc;
        private string _tipoDocDesc;
        private int _cntRenglones;
        private decimal _montoDoc;
        private OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento _tipoDoc;


        public string FechaHora { get { return _fechaHora; } }
        public string DocumentoNro { get { return _docNro; } }
        public string UsuarioEstacion { get { return _usuarioEstacion; } }
        public string SMonto { get { return _montoDoc.ToString("n2"); } }
        public string SRenglones { get { return _cntRenglones.ToString(); } }
        public string DepOrigen { get { return _depOrigenDesc; } }
        public string DepDestino { get { return _depDestinoDesc; } }
        public string STipoDoc { get { return _tipoDocDesc; } }

        
        public data(OOB.LibInventario.Movimiento.Lista.Ficha rg)
        {
            _fechaHora= rg.fecha.ToShortDateString() + ", " + rg.hora;
            _docNro = rg.docNro;
            _usuarioEstacion = rg.usuario + ", " + rg.estacion;
            _depOrigenDesc = rg.depositoOrigen;
            _depDestinoDesc = rg.depositoDestino;
            _cntRenglones = rg.docRenglones;
            _montoDoc = rg.montoDivisa;
            _tipoDocDesc ="" ;
            _tipoDoc = rg.docTipo;
            switch (_tipoDoc)
            {
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo:
                    _tipoDocDesc = "CARGO";
                    break;
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo:
                    _tipoDocDesc = "DESCARGO";
                    break;
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado:
                    _tipoDocDesc = "TRASLADO";
                    break;
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste:
                    _tipoDocDesc = "AJUSTE";
                    break;
            }
        }
    }
}