using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.DepositoPreDeterminado
{
    
    public class Gestion
    {

        private List<data> _lst;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;


        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public BindingSource SourceGrid { get { return _bs; } }
        

        public Gestion() 
        {
            _lst = new List<data>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _bl.Clear();
        }

        private DepositoPreDeterminado.DepPreDeterminadoFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new DepPreDeterminadoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Deposito_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            foreach (var dep in r01.Lista.OrderBy(o=>o.nombre).ToList())
            {
                _bl.Add(new data(dep));
            }
            _bs.CurrencyManager.Refresh();

            return true;
        }

        public void Procesar()
        {
            _procesarIsOk= false;
            var xmsg = "Procesar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var lst = _bl.Select(s =>
                {
                    var nr = new OOB.LibInventario.Configuracion.DepositoPreDeterminado.Item()
                    {
                        AutoDeposito = s.depositoFicha.auto,
                        Estatus = s.isPreDet ? "1" : "",
                    };
                    return nr;
                }).ToList();

                var fichaOOB = new OOB.LibInventario.Configuracion.DepositoPreDeterminado.Ficha() { ListaPreDet = lst };
                var r01 = Sistema.MyData.Configuracion_SetDepositosPreDeterminado(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk= true;
                Helpers.Msg.OK("Proceso Realizado Exitosamente !!!");
            }
        }

        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) { _abandonarIsOk = true; }
        }

    }

}