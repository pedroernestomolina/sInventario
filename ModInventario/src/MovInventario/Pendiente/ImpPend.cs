using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.MovInventario.Pendiente
{
    class ImpPend: IPendiente
    {
        private int _cntDoc;
        private enumerados.enumTipoDocAbrirPend _tipoDocAbrirPend;
        private enumerados.enumTipoMovTraslado _tipoMovTraslado;
        private IListaPend _lista;


        public int CntDoc { get { return _cntDoc; } }
        public IListaPend Pendiente { get { return _lista; } }
        public dataDoc ItemActual { get { return (dataDoc)_lista.ItemActual; } }


        public ImpPend()
        {
            _cntDoc = 0;
            _tipoDocAbrirPend = enumerados.enumTipoDocAbrirPend.SinDefinir;
            _tipoMovTraslado = enumerados.enumTipoMovTraslado.SinDefinir;
            _lista = new ImpListaPend();
        }


        public void Inicializa()
        {
            _cntDoc = 0;
            _seleccionItemIsOk = false;
            _dejarEnPendienteIsOk = false;
        }
        public void CargarData()
        {
            var r01 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(_tipoDoc);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _docTipo = r01.Entidad;
            var filtroOOB = new OOB.LibInventario.Transito.Movimiento.Lista.Filtro() { codigoMov = _docTipo.codigo, tipoMov = _tipoTrasladoAjuste };
            var r02 = Sistema.MyData.Transito_Movimiento_GetCnt(filtroOOB);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                throw new Exception(r02.Mensaje);
            }
            _cntDoc = r02.Entidad;
        }


        private OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento _tipoDoc;
        public void setTipoDocumentoTrabajar(enumerados.enumTipoDocAbrirPend tipoDoc)
        {
            _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.SinDefinir;
            _tipoDocAbrirPend = tipoDoc;
            switch (_tipoDocAbrirPend)
            {
                case enumerados.enumTipoDocAbrirPend.Cargo:
                    _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.CARGO;
                    break;
                case enumerados.enumTipoDocAbrirPend.Descargo:
                    _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.DESCARGO;
                    break;
                case enumerados.enumTipoDocAbrirPend.Trasalado:
                    _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO;
                    break;
                case enumerados.enumTipoDocAbrirPend.Ajuste:
                    _tipoDoc = OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.AJUSTE;
                    break;
            }
        }
        private string _tipoTrasladoAjuste;
        public void setTipoMovTrasladoAjuste(enumerados.enumTipoMovTraslado tipoTrasladoAjuste)
        {
            _tipoTrasladoAjuste = "";
            _tipoMovTraslado = tipoTrasladoAjuste;
            switch (_tipoMovTraslado)
            {
                case enumerados.enumTipoMovTraslado.TrasladoEntreDepositos:
                    _tipoTrasladoAjuste = "1";
                    break;
                case enumerados.enumTipoMovTraslado.TrasladoPorDevolucion:
                    _tipoTrasladoAjuste = "2";
                    break;
                case enumerados.enumTipoMovTraslado.TrasladoPorNivelMinimo:
                    _tipoTrasladoAjuste = "3";
                    break;
                case enumerados.enumTipoMovTraslado.AjusteInventario:
                    _tipoTrasladoAjuste = "1";
                    break;
            }
        }

        public void ListaVisualizar()
        {
            Inicializa();
            CargarFrm();
        }
        private Frm frm;
        private void CargarFrm()
        {
            _lista.Inicializa();
            if (CargarListaPend())
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarListaPend()
        {
            try
            {
                var r01 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(_tipoDoc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var _docTipo = r01.Entidad;

                var filtroOOB = new OOB.LibInventario.Transito.Movimiento.Lista.Filtro() { codigoMov = _docTipo.codigo, tipoMov = _tipoTrasladoAjuste };
                var r02 = Sistema.MyData.Transito_Movimiento_GetCnt(filtroOOB);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                if (r02.Entidad <= 0) 
                {
                    throw new Exception("NO HAY DOCUMENTOS EN TRANSITO");
                }

                var r03 = Sistema.MyData.Transito_Movimiento_GetLista(filtroOOB);
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r03.Mensaje);
                }
                _lista.setData(r03.Lista);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        private bool _seleccionItemIsOk;
        public bool SeleccionItemIsOk { get { return _seleccionItemIsOk; } }
        public int IdItemSeleccionado { get { return ItemActual != null ? ItemActual.id : -1; } }
        public void SeleccionarItem()
        {
            _seleccionItemIsOk = false;
            if (ItemActual != null)
            {
                _seleccionItemIsOk = true;
            }
        }
        public void ActualizarContador()
        {
            try
            {
                CargarData();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private bool _dejarEnPendienteIsOk;
        public bool DejarEnPendienteIsOk { get { return _dejarEnPendienteIsOk; } }
        public void DejarEnPendiente(OOB.LibInventario.Transito.Movimiento.Agregar.Ficha ficha)
        {
            try
            {
                _dejarEnPendienteIsOk = false;
                var r01 = Sistema.MyData.Transito_Movimiento_Agregar(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r01.Mensaje);
                }
                _dejarEnPendienteIsOk = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}