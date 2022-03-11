using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo.Descargo
{
    
    public class Gestion: ITipo
    {

        private ModInventario.FiltrosGen.IOpcion _gConcepto;
        private ModInventario.FiltrosGen.IOpcion _gSucursal;
        private ModInventario.FiltrosGen.IOpcion _gDepOrigen;
        private Captura.ICaptura _gCapturaMov;
        private bool _isOk;
        private string _autorizado;
        private string _motivo;
        private dataItem _itemAgregar;


        public string TipoMovimiento { get { return "DESCARGO"; } }
        public bool IsOk { get { return _isOk; } }
        public BindingSource ConceptoSource { get { return _gConcepto.Source; } }
        public BindingSource SucursalSource { get { return _gSucursal.Source; } }
        public BindingSource DepOrigenSource { get { return _gDepOrigen.Source; } }
        public string AutorizadoPor { get { return _autorizado; } }
        public string Motivo{ get { return _motivo; } }
        public string ConceptoGetId { get { return _gConcepto.GetId; } }
        public string SucursalGetId { get { return _gSucursal.GetId; } }
        public string DepOrigenGetID { get { return _gDepOrigen.GetId; } }
        public dataItem ItemAgregar { get { return _itemAgregar; } }


        public Gestion(
            ModInventario.FiltrosGen.IOpcion ctrConcepto,
            ModInventario.FiltrosGen.IOpcion ctrSucursal,
            Captura.ICaptura ctrCapturaMov)
        {
            _gConcepto = ctrConcepto;
            _gSucursal = ctrSucursal;
            _gCapturaMov = ctrCapturaMov;
            _gDepOrigen = new ModInventario.FiltrosGen.Opcion.Gestion();
            _isOk = false;
            _itemAgregar = null;
        }


        public void Inicializa()
        {
            _gConcepto.Inicializa();
            _gSucursal.Inicializa();
            _gDepOrigen.Inicializa();
            _isOk = false;
            _itemAgregar = null;
        }

        MovFrm frm;
        public void Inicia(IGestionTipo ctr)
        {
            if (frm == null)
            {
                frm = new MovFrm();
                frm.setControlador(ctr);
            }
            frm.ShowDialog();
        }

        public bool CargarData()
        {
            var r01 = Sistema.MyData.Concepto_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var _lConcepto= new List<ficha>();
            foreach(var rg in r01.Lista.OrderBy(o=>o.nombre).ToList())
            {
                _lConcepto.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gConcepto.setData(_lConcepto);

            var r02 = Sistema.MyData.Sucursal_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var _lSucursal = new List<ficha>();
            foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lSucursal.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gSucursal.setData(_lSucursal);

            return true;
        }


        public void setAutorizadoPor(string p)
        {
            _autorizado = p;
        }
        public void setMotivo(string p)
        {
            _motivo = p;
        }
        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
            if (id.Trim() != "")
            {
                var r01 = Sistema.MyData.Deposito_GetListaBySucursal(_gSucursal.Item.codigo);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var lst = new List<ficha>();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gDepOrigen.setData(lst);
            }
        }
        public void setConcepto(string id)
        {
            _gConcepto.setFicha(id);
        }
        public void setDepOrigen(string id)
        {
            _gDepOrigen.setFicha(id);
        }


        public void BuscarIdPrd(string id)
        {
            _isOk = false;
            _itemAgregar = null;
            if (_gSucursal.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO SELECCIONADA");
                return;
            }
            if (_gDepOrigen.Item == null) 
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ] NO SELECCIONADA");
                return;
            }

            var filtroOOB = new OOB.LibInventario.Movimiento.DesCargo.CapturaMov.Filtro()
            {
                idDeposito = _gDepOrigen.GetId,
                idProducto = id,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_Descargo_CaptureMov(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var r = r01.Entidad.data;
            var dat = new data()
            {
                autoDepart = r.autoDepart,
                autoGrupo = r.autoGrupo,
                autoPrd = r.autoPrd,
                autoTasa = r.autoTasa,
                catPrd = r.catPrd,
                codigoPrd = r.codigoPrd,
                contEmp = r.contEmp,
                costo = r.costo,
                costoDivisa = r.costoDivisa,
                costoDivisaUnd = r.costoDivisaUnd,
                costoUnd = r.costoUnd,
                decimales = r.decimales,
                descTasa = r.descTasa,
                esAdmDivisa = r.esAdmDivisa,
                exFisica = r.exFisica,
                nombreEmp = r.nombreEmp,
                nombrePrd = r.nombrePrd,
                valorTasa = r.valorTasa,
            };
            _gCapturaMov.Inicializa();
            _gCapturaMov.setData(dat);
            _gCapturaMov.Inicia();
            if (_gCapturaMov.IsOk) 
            {
                _itemAgregar = _gCapturaMov.DataItem;
                _isOk = true;
            }
        }

        public void Limpiar()
        {
            _itemAgregar = null;
            _autorizado = "";
            _motivo = "";
            _gConcepto.Limpiar();
            _gSucursal.Limpiar();
            _gDepOrigen.Limpiar();
        }


        public void EditarItem(dataItem ItemActual)
        {
            _gCapturaMov.Inicializa();
            _gCapturaMov.setItemEditar(ItemActual);
            _gCapturaMov.Inicia();
            if (_gCapturaMov.IsOk)
            {
                _itemAgregar = _gCapturaMov.DataItem;
                _isOk = true;
            }
        }

    }

}