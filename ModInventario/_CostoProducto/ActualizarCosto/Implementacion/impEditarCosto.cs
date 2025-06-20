using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario._CostoProducto.ActualizarCosto.Implementacion
{
    public class impEditarCosto: interfaces.IPrincipal
    {
        private bool _fichaIsOk;
        private string _idPrdEditar;
        private __.interfaces.Boton.IBtAbandonar _btAbandonar;
        private __.interfaces.Boton.IBtProcesar _btProcesar;
        private Interfaces.UsesCase.IUseCase _uc;
        private Modelo.MiModelo _miModelo;
        //
        public string Get_DescProducto { get { return _miModelo.Get_DescProducto; } }
        public string Get_TasaCambio { get { return _miModelo.Get_TasaCambio; } }
        public string Get_CostoFinal_Und { get { return _miModelo.Get_CostoFinal_Und; } }
        public string Get_AdmDivisa { get { return _miModelo.Get_AdmDivisa; } }
        public string Get_DescTasaIva { get { return _miModelo.Get_DescTasaIva; } }
        public string Get_FechaUltActCosto { get { return _miModelo.Get_FechaUltActCosto; } }
        public string Get_DescEmqCompra { get { return _miModelo.Get_DescEmqCompra ; } }
        //
        public bool FichaIsOk { get { return _fichaIsOk; } }
        public bool AbandonarFichaIsOk { get { return _btAbandonar.ResultIsOK; } }
        //
        public impEditarCosto()
        {
            _fichaIsOk = false;
            _idPrdEditar = "";
            _btAbandonar = new __.impl.Boton.ImpBtAbandonar();
            _btProcesar = new __.impl.Boton.ImpBtProcesar();
            _uc = new Implementacion.UsesCase.ImplUseCase();
            _miModelo = new Modelo.MiModelo();
        }
        public void Inicializa()
        {
            _fichaIsOk = false;
            _idPrdEditar = "";
            _btAbandonar.Inicializa();
            _btProcesar.Inicializa();
            _miModelo.Inicializa();
        }
        Presentacion.vistas.FrmPrincipal frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new Presentacion.vistas.FrmPrincipal();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void AbandonarFicha()
        {
            _btAbandonar.Execute();
        }
        public void ProcesarFicha()
        {
            _btProcesar.Execute();
        }
        public void setIdFichaEditar(string idPrdEditar)
        {
            _idPrdEditar = idPrdEditar;
        }
        //
        private bool cargarData()
        {
            try
            {
                var prd= _uc.GetFichaPrdToEditarCostoUseCase(_idPrdEditar);
                _miModelo.setPrdEditarCosto(prd);
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