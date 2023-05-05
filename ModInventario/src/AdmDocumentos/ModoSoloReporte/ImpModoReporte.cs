using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.AdmDocumentos.ModoSoloReporte
{
    public class ImpModoReporte: ModoSucursal.ImpModoSucursal 
    {
        public ImpModoReporte(
            Utils.FiltrosPara.AdmDocumentos.IAdmDoc filtroAdmDoc,
            IListaAdmDoc listaAdmDoc,
            Auditoria.Visualizar.IVisualizar auditoria,
            ModInventario.src.AnularDoc.IAnular anularDoc) 
            :base(filtroAdmDoc,listaAdmDoc,auditoria,anularDoc) 
        {
        }
        AdministradorFrm frm;
        public override void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AdministradorFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        protected override List<OOB.LibInventario.Movimiento.Lista.Ficha> 
            aplicarBusqueda(OOB.LibInventario.Movimiento.Lista.Filtro filtro)
        {
            var lst = new List<OOB.LibInventario.Movimiento.Lista.Ficha>();
            try
            {
                var rt0 = Sistema.MyData.Configuracion_CantDocVisualizar();
                var rt1 = Sistema.MyData.Producto_Movimiento_GetLista(filtro);
                lst = rt1.Lista.
                    Where(w => 1 == 1 && (w.idDepOrigen == Sistema.Negocio.CodigoDepositoPrincipal || w.idDepDestino == Sistema.Negocio.CodigoDepositoPrincipal)).
                    OrderByDescending(o => o.fecha).ThenByDescending(o => o.docNro).
                    Take(rt0.Entidad).
                    ToList();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            return lst;
        }
    }
}
