using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes.ModoSucursal
{
    public class ImpModo: baseModo
    {
        public ImpModo()
        {
            _deposito = new Deposito();
            _marca= new Marca();
            _estatusDivisa = new EstatusDivisa();
            _sucursal = new Sucursal();
            _estatusPrd = new EstatusProducto();
            _tasaIva = new TasaIva();
            _categoria = new Categoria();
            _origen = new Origen();
            _oferta = new Oferta();
            _concepto = new Concepto();
            _estatusPesado = new EstatusPesado();
            _precio = new Precio();
            _empaque = new Empaque();
            _departGrupo = new DepartamentoGrupo();
            _producto = new Producto();
            _desde = new Fecha();
            _hasta = new Fecha();
        }


        Frm frm;
        public override void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private bool CargarData()
        {
            try
            {
                _deposito.CargarData();
                _marca.CargarData();
                _estatusDivisa.CargarData();
                _sucursal.CargarData();
                _estatusPrd.CargarData();
                _tasaIva.CargarData();
                _categoria.CargarData();
                _origen.CargarData();
                _oferta.CargarData();
                _concepto.CargarData();
                _estatusPesado.CargarData();
                _precio.CargarData();
                _empaque.CargarData();
                _departGrupo.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}