using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroAdmDoc.ModoSucursal
{
    public class ImpModoSucursal: baseAdmDoc, IAdmDoc
    {
        public override IDataExportar DataExportar { get { return miDataExportar(); } }


        public ImpModoSucursal(FiltrosGen.IBuscar filtroBusPrd)
        {
            _depositoOrigen = new Utils.Filtros.Deposito();
            _depositoDestino = new Utils.Filtros.Deposito();
            _estatus = new Utils.Filtros.EstatusDocumento();
            _concepto = new Utils.Filtros.Concepto();
            _tipoDoc = new Utils.Filtros.TipoDocumento();
            _sucursal = new Utils.Filtros.Sucursal();
            _desdeHasta = new Utils.Filtros.DesdeHasta.ImpFiltro();
            _porProducto = new Utils.Filtros.BuscarPor.PorProducto.ImpFiltro();
        }


        FiltroFrm frm;
        public override void Inicia()
        {
            if (frm == null)
            {
                frm = new FiltroFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }


        private IDataExportar miDataExportar()
        {
            var rt = new ImpDataExportar()
            {
                DepOrigen = _depositoOrigen.Ctrl.GetItem,
                DepDestino = _depositoDestino.Ctrl.GetItem,
                Concepto = _concepto.Ctrl.GetItem,
                Desde = _desdeHasta.Desde.Valor,
                Estatus = _estatus.Ctrl.GetItem,
                Hasta = _desdeHasta.Hasta.Valor,
                Producto = _porProducto.ItemSeleccionado,
                Sucursal = _sucursal.Ctrl.GetItem,
                TipoDoc = _tipoDoc.Ctrl.GetItem,
            };
            return rt;
        }
    }
}