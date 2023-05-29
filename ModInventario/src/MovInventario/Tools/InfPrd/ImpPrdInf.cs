using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Tools.InfPrd
{
    public class ImpPrdInf: IPrdInf
    {
        private List<data> _list;
        private BindingSource _bs;
        private BindingList<data> _bl;


        private string _idPrd;
        private string _idDep;
        private string _descEmpComp;
        private string _descEmpInv;
        private decimal _contEmpComp;
        private decimal _contEmpInv;
        private decimal _exTotal;


        public BindingSource GetSource { get { return _bs; } }
        public string GetInvEmpCompra { get { return "Emp" + Environment.NewLine + "(COMPRA/" + _contEmpComp.ToString() + ")"; } }
        public string GetInvEmpInv { get { return "Emp" + Environment.NewLine + "(INV/" + _contEmpInv.ToString() + ")"; } }
        public string GetInvEmpUnd { get { return "Emp" + Environment.NewLine + "(UNIDAD/" + 1.ToString() + ")"; } }
        public int GetEx_InvEmpCompra
        {
            get
            {
                var rt = 0;
                if (_contEmpComp > 0)
                {
                    rt = (int)(_exTotal/ _contEmpComp);
                }
                return rt;
            }
        }
        public int GetEx_InvEmpInv
        {
            get
            {
                var rt = 0;
                rt = (int)(_exTotal - (GetEx_InvEmpCompra * _contEmpComp ));
                if (_contEmpInv > 0)
                {
                    rt = (int)(rt / _contEmpInv);
                }
                return rt;
            }
        }
        public int GetEx_InvEmpUnd
        {
            get
            {
                var rt = 0;
                rt = (int)(GetEx_InvEmpCompra * _contEmpComp);
                rt += (int)(GetEx_InvEmpInv * _contEmpInv);
                rt = (int)(_exTotal - rt);
                return rt;
            }
        }


        public ImpPrdInf()
        {
            _abandonarIsOk=false;
            _idPrd = "";
            _idDep = "";
            _list = new List<data>();
            _bl = new BindingList<data>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _idPrd = "";
            _idDep = "";
            _abandonarIsOk=false; 
        }
        Frm frm;
        public async void Inicia()
        {
            if (await CargarData()) 
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
        }


        private async Task<bool> CargarData()
        {
            Task<OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Existencia>> tarea1 = LlamarServicio_1();
            Task<OOB.ResultadoLista<OOB.LibInventario.Movimiento.Lista.Ficha>> tarea2 = LlamarServicio_2();
            await Task.WhenAll(tarea1, tarea2);
            if (tarea1.Result.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(tarea1.Result.Mensaje);
                return false;
            }
            if (tarea2.Result.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(tarea2.Result.Mensaje);
                return false;
            }

            _contEmpComp = tarea1.Result.Entidad.empaqueContenido;
            _descEmpComp = tarea1.Result.Entidad.empaque;
            _contEmpInv = tarea1.Result.Entidad.contEmpInv;
            _descEmpInv = tarea1.Result.Entidad.descEmpInv;
            _exTotal = 0m;
            var _ent = tarea1.Result.Entidad.depositos.FirstOrDefault(f => f.autoId == _idDep) ;
            if (_ent != null)
            {
                _exTotal = _ent.exFisica;
            }
            setLista(tarea2.Result.Lista);
            return true;
        }


        public async Task<OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Existencia>> LlamarServicio_1()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Existencia>();
            await Task.Run(() =>
            {
                rt =Sistema.MyData.Producto_GetExistencia(_idPrd);
            });
            return rt;
        }
        public async Task<OOB.ResultadoLista<OOB.LibInventario.Movimiento.Lista.Ficha>> LlamarServicio_2()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Movimiento.Lista.Ficha>();
            await Task.Run(() =>
            {
                var filtro = new OOB.LibInventario.Movimiento.Lista.Filtro()
                {
                    IdDepDestino = _idDep,
                    IdProducto = _idPrd,
                };
                rt = Sistema.MyData.Producto_Movimiento_GetLista(filtro); 
            });
            return rt;
        }


        public void setIdPrd(string idPrd)
        {
            _idPrd = idPrd;
        }
        public void setIdDeposito(string idDep)
        {
            _idDep = idDep;
        }
        public void setLista(List<OOB.LibInventario.Movimiento.Lista.Ficha> lst)
        {
            _bl.Clear();
            foreach (var rg in lst)
            {
                var dt = new data(rg);
                _bl.Add(dt);
            }
            _bs.CurrencyManager.Refresh();
        }
    }
}