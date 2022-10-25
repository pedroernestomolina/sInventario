using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Auditoria.Visualizar
{
    
    public class ImpVisualizar: IVisualizar
    {

        private string _idDoc;
        private OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento _tipoDoc;
        private string _motivo;
        private DateTime _fechaAnulacion;


        public string GetMotivo_Desc { get { return _motivo; } }
        public DateTime GetFecha_Desc {get {return _fechaAnulacion;}}


        public ImpVisualizar()
        {
            _motivo = "";
            _fechaAnulacion = DateTime.Now.Date;
        }


        VisualizarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new VisualizarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(_tipoDoc);
                var ficha = new OOB.LibInventario.Auditoria.Buscar.Ficha()
                {
                    autoDocumento = _idDoc,
                    autoTipoDocumento = r01.Entidad.autoId,
                };
                var r02 = Sistema.MyData.Auditoria_Documento_GetFichaBy(ficha);
                _motivo = r02.Entidad.motivo;
                _fechaAnulacion = r02.Entidad.fecha;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        public void Inicializa()
        {
            _motivo = "";
            _fechaAnulacion = DateTime.Now.Date;
        }


        public void setData(AdmDocumentos.data ItemActual)
        {
            _idDoc = ItemActual.Id;
            _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.SinDefinir;
            switch (ItemActual.TipoDocumento)
            {
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo:
                    _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.CARGO;
                    break;
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo:
                    _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.DESCARGO;
                    break;
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado:
                    _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO;
                    break;
                case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste:
                    _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.AJUSTE;
                    break;
            }

        }


        public bool AbandonarIsOk { get { return true; } }
        public void AbandonarFicha()
        {
        }

    }

}