using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.DepositoConceptoDevMercancia
{
    
    public class Gestion: IConfiguracion
    {


        private FiltrosGen.IOpcion _gDeposito;
        private FiltrosGen.IOpcion _gConcepto;
        private bool _abandonarIsOk;
        private bool _procesarIsOk;


        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public BindingSource DepositoSource { get { return _gDeposito.Source; } }
        public BindingSource ConceptoSource { get { return _gConcepto.Source; } }
        public string DepositoGetId { get { return _gDeposito.GetId; } }
        public string ConceptoGetId { get { return _gConcepto.GetId; } }


        public Gestion() 
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _gDeposito = new FiltrosGen.Opcion.Gestion();
            _gConcepto= new FiltrosGen.Opcion.Gestion();
        }

        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _gDeposito.Inicializa();
            _gConcepto.Inicializa();
        }

        ConfFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new ConfFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Configuracion_DepositoConceptoPreDeterminadoDevolucionMercancia();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }

                var lstDep = new List<ficha>();
                var r02 = Sistema.MyData.Deposito_GetLista();
                foreach (var rg in r02.Lista.OrderBy(o => o.nombre))
                {
                    lstDep.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gDeposito.setData(lstDep);
                _gDeposito.setFicha(r01.Entidad.IdDeposito);

                var lstCon = new List<ficha>();
                var r03 = Sistema.MyData.Concepto_GetLista();
                foreach (var rg in r03.Lista.OrderBy(o => o.nombre))
                {
                    lstCon.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gConcepto.setData(lstCon);
                _gConcepto.setFicha(r01.Entidad.IdConcepto);

                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public void setDeposito(string id)
        {
            _gDeposito.setFicha(id);
        }
        public void setConcepto(string id)
        {
            _gConcepto.setFicha(id);
        }


        public void Abandonar()
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
            if (_gDeposito.Item == null) 
            {
                Helpers.Msg.Alerta("CAMPO DEPOSITO NO PUEDE ESTAR VACIO");
                return;
            }
            if (_gConcepto.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO CONCEPTO NO PUEDE ESTAR VACIO");
                return;
            }

            _procesarIsOk = false;
            var xmsg = "Confirmar Guardar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var ficha = new OOB.LibInventario.Configuracion.DepositoConceptoDevMerc.Editar.Ficha()
                {
                    IdConcepto = _gConcepto.Item.id,
                    IdDeposito = _gDeposito.Item.id,
                };
                var r01 = Sistema.MyData.Configuracion_SetDepositoConceptoPreDeterminadoDevolucionMercancia(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk= true;
            }
        }

    }

}