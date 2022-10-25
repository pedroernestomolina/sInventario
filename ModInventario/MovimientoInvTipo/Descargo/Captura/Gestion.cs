using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo.Descargo.Captura
{
    
    public class Gestion: ICaptura
    {

        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private dataItem _item;
        private FiltrosGen.IOpcion _gEmpaque;


        public bool IsOk { get { return _procesarIsOk; } }
        public dataItem DataItem { get { return _item; } }
        public BindingSource EmpaqueSource { get { return _gEmpaque.Source; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public string EmpaqueGetID { get { return _gEmpaque.GetId; } }


        public decimal InfTasaCambio { get { return _item.InfTasaCambio; } }
        public string InfProductoDesc { get { return _item.InfProductoDesc; } }
        public string InfProductoEmpaCompra { get { return _item.InfProductoEmpaCompra; } }
        public string InfProductoEsAdmDivisa { get { return _item.InfProductoEsAdmDivisa; } }
        public string InfProductoTasaIva { get { return _item.InfProductoTasaIva; } }
        public string InfProductoFechaUltActCosto { get { return _item.InfProductoFechaUltActCosto; } }
        public decimal InfExistenciaActual { get { return _item.InfExistenciaActual; } }
        public bool InfProductoEsDivisa { get { return _item.InfProductoEsDivisa; } }


        public decimal CntUnd { get { return _item.CntUnd; } }
        public decimal CostoUnd { get { return _item.CostoUnd; } }
        public decimal Importe { get { return _item.Importe; } }
        public decimal Cantidad { get { return _item.Cantidad; } }
        public decimal Costo { get { return _item.Costo; } }
        

        public Gestion() 
        {
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _gEmpaque= new FiltrosGen.Opcion.Gestion();
        }


        public void setData(data dat)
        {
            _item = new dataItem();
            _item.setFicha(dat);
        }

        public void Inicializa()
        {
            _item = null;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _gEmpaque.Inicializa();
        }

        EntradaFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new EntradaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var lst= new List<ficha>();
            lst.Add(new ficha("1", "", "POR EMPQ/COMPRA"));
            lst.Add(new ficha("3", "", "POR EMPQ/INV"));
            lst.Add(new ficha("2", "", "POR UNIDAD"));
            _gEmpaque.setData(lst);

            return true;
        }

        public void AbandonarFicha()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            if (_gEmpaque.GetId == "")
            {
                Helpers.Msg.Alerta("CAMPO [ EMPAQUE ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (Importe <= 0) 
            {
                Helpers.Msg.Alerta("MONTO MOVIMIENTO INCORRECTO");
                return;
            }
            _procesarIsOk = false;
            var xmsg = "Guardar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _procesarIsOk = true;
            }
        }


        public void setCantidad(decimal p)
        {
            _item.setCantidad(p);
        }
        public void setCosto(decimal p)
        {
            _item.setCosto(p);
        }
        public void setEmpaque(string id)
        {
            _gEmpaque.setFicha(id);
            _item.setEmpaque(_gEmpaque.Item);
        }


        public void setItemEditar(dataItem ItemActual)
        {
            _gEmpaque.Limpiar();
            _gEmpaque.setFicha(ItemActual.EmpaqueFicha.id);
            _item = new dataItem(ItemActual);
        }

        public void setTasaCambio(decimal tasaCambio)
        {
            _item.setTasaCambio(tasaCambio);
        }


        public string InfProductoEmpInventario { get { return _item.InfProductoEmpInventario; } }
        public string InfProductoEmpUnidad { get { return _item.InfProductoEmpUnidad; } }
    }

}