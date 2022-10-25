using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.AdmDocumentos
{

    public class data
    {

        public string Id { get { return _id; } }
        public string FechaHora { get { return _fechaHora; } }
        public string DocumentoNro { get { return _docNro; } }
        public string Sucursal { get { return _sucursalDesc; } }
        public string Concepto { get { return _conceptoDesc; } }
        public string UsuarioEstacion { get { return _usuarioEstacion; } }
        public string SMonto { get { return _montoDoc.ToString("n2"); } }
        public string Situacion { get { return _situacionDoc; } }
        public bool IsAnulado { get { return _isAnuladoDoc; } }
        public string SRenglones { get { return _cntRenglones.ToString(); } }
        public string DepOrigen { get { return _depOrigenDesc; } }
        public string DepDestino { get { return _depDestinoDesc; } }
        public string STipoDoc { get { return _tipoDocDesc; } }
        public OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento TipoDocumento { get { return _tipoDoc; } }
        public decimal MontoDoc { get { return _montoDoc; } }


        private string _id;
        private string _fechaHora;
        private string _docNro;
        private string _sucursalDesc;
        private string _conceptoDesc;
        private string _usuarioEstacion;
        private string _depOrigenDesc;
        private string _depDestinoDesc;
        private string _situacionDoc;
        private string _tipoDocDesc;
        private int _cntRenglones;
        private decimal _montoDoc;
        private bool _isAnuladoDoc;
        private OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento _tipoDoc;
        public data(OOB.LibInventario.Movimiento.Lista.Ficha rg)
        {
            _id = rg.autoId;
            _fechaHora= rg.fecha.ToShortDateString() + ", " + rg.hora;
            _docNro = rg.docNro;
            _sucursalDesc = rg.docSucursal;
            _conceptoDesc = rg.docConcepto;
            _usuarioEstacion = rg.usuario + ", " + rg.estacion;
            _depOrigenDesc = rg.depositoOrigen;
            _depDestinoDesc = rg.depositoDestino;
            _situacionDoc = rg.docSituacion;
            _cntRenglones = rg.docRenglones;
            _montoDoc = rg.docMonto;
            _isAnuladoDoc = rg.isDocAnulado;
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
        public void setEstatusAnulado()
        {
            _isAnuladoDoc = true;
        }

    }

}