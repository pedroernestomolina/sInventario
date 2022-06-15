using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.AsignacionMasiva
{
    
    public class Asignacion: IAsignacion
    {


        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private ModInventario.FiltrosGen.IOpcion _gDep;
        private BindingSource _bsDepart;
        private List<dataDepart> _departExcluir;


        public bool IsAbandonarIsOk { get { return _abandonarIsOk; } }
        public bool IsProcesarIsOk { get { return _procesarIsOk; } }
        public BindingSource DepositoGetSource { get { return _gDep.Source; } }
        public string DepositoGetId { get { return _gDep.GetId; } }
        public BindingSource DepartGetSource { get { return _bsDepart; } }


        public Asignacion() 
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _departExcluir = new List<dataDepart>();
            _bsDepart = new BindingSource();
            _bsDepart.DataSource = _departExcluir;
            _gDep= new ModInventario.FiltrosGen.Opcion.Gestion();
        }


        AsignacionMasivaFrm frm;
        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _departExcluir.Clear();
            _gDep.Inicializa();
        }
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AsignacionMasivaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void AbandonarFicha()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios Realizados ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }
        public void Procesar()
        {
            _procesarIsOk = false;

            if (_gDep.GetId == "")
            {
                Helpers.Msg.Error("DEPOSITO A ASIGNAR NO PUEDE ESTAR VACIO");
                return;
            }
            var msg = "Procesar Asgnación Masiva ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                Guardar();
            }
        }
        public void setDeposito(string id)
        {
            _gDep.setFicha(id);
        }


        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Deposito_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var r02 = Sistema.MyData.Departamento_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var lst = new List<ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gDep.setData(lst);
            _departExcluir.Clear();
            foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
            {
                var depart = new dataDepart()
                {
                    id = rg.auto,
                    nombre = rg.nombre,
                    excluir = false,
                };
                _departExcluir.Add(depart);
            }
            _bsDepart.CurrencyManager.Refresh();

            return rt;
        }
        private void Guardar()
        {
            var _lstExc = _departExcluir.Where(w => w.excluir).Select(s=>s.id).ToList();
            var fichaOOb = new OOB.LibInventario.Producto.Depositos.AsignacionMasiva.Ficha()
            {
                depositoDestino = new OOB.LibInventario.Producto.Depositos.AsignacionMasiva.FichaDepositoDestino()
                {
                    autoDeposito = _gDep.GetId,
                },
                departamentosNoIncluir = _lstExc.Select(s =>
                {
                    var rt = new OOB.LibInventario.Producto.Depositos.AsignacionMasiva.FichaDepartamentos()
                    {
                         auto= s,
                    };
                    return rt;
                }).ToList(),
            };
            var r01 = Sistema.MyData.Producto_Deposito_AsignacionMasiva(fichaOOb);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Helpers.Msg.OK("Proceso Realizado Con Exito");
            _procesarIsOk = true;
        }

    }

}