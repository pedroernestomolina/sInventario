using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.TallaColorSabor.Visualizar
{
    public class ImpVer: IVer
    {
        private string _idPrd;
        private string _idDep;
        private ITCSLista _gLista;
        private ITCSLista _gDeposito;
        private OOB.LibInventario.TallaColorSabor.Existencia.Ficha _ExDep;
        private string _etq_prd;
        private string _etq_prd_tcs;
        private bool _habilitarBtDetalle;


        public BindingSource GetData_Source { get { return _gLista.GetSource; } }
        public BindingSource GetDataDep_Source { get { return _gDeposito.GetSource; } }
        public string GetEtq_Prd { get { return _etq_prd; } }
        public decimal GetEtq_CntGeneral { get { return _gLista.GetCntTotal; } }
        public decimal GetEtq_CntDetalle { get { return _gDeposito.GetCntTotal; } }
        public string GetEtq_PrdTCS { get { return _etq_prd_tcs; } }


        public ImpVer()
        {
            _idDep = "";
            _idPrd = "";
            _ExDep = null;
            _etq_prd = "";
            _etq_prd_tcs="";
            _habilitarBtDetalle = true;
            _gLista= new ImpLista();
            _gDeposito = new ImpLista();
        }


        public void Inicializa()
        {
            _idPrd = "";
            _idDep = "";
            _ExDep = null;
            _etq_prd = "";
            _etq_prd_tcs = "";
            _habilitarBtDetalle = true;
            _gLista.Inicializa();
            _gDeposito.Inicializa();
        }
        VerTallaColorSaborFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new VerTallaColorSaborFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setIdPrd(string idPrd)
        {
            _idPrd = idPrd;
        }
        public void setIdDeposito(string idDep)
        {
            _idDep = idDep;
        }
        public void HabilitaBtDetalle(bool habBt)
        {
            _habilitarBtDetalle=habBt;
        }


        private bool CargarData()
        {
            try
            {
                var filtroOOB = new OOB.LibInventario.TallaColorSabor.Existencia.Filtro()
                {
                    autoDep = _idDep,
                    autoPrd = _idPrd,
                };
                var r01 = Sistema.MyData.TallaColorSabor_ExDep(filtroOOB);
                if (!r01.Entidad.HndTallaColorSabor) 
                {
                    throw new Exception("OPCION NO DISPONIBLE PARA ESTE PRODUCTO");
                }
                _ExDep = r01.Entidad;
                _etq_prd = _ExDep.NombrePrd;
                var grp = r01.Entidad.ExDep.GroupBy(g => new {id=g.idTCS, des=g.NombreTCS}).Select(s => new { key = s.Key, reg = s.ToList() }).ToList();
                var _lst = grp.Select(s=> {
                    var nr = new data()
                    {
                        Id= s.key.id,
                        Descripcion = s.key.des,
                        Fisica = s.reg.Sum(t => t.Fisica),
                        Reservada = s.reg.Sum(t => t.Reservada),
                        Disponible = s.reg.Sum(t => t.Disponible),
                    };
                    return nr;
                }).ToList();
                _gLista.setLista(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public bool CargarDepositos()
        {
            if (_habilitarBtDetalle)
            {
                var _item = (data)_gLista.ItemActual;
                if (_item == null)
                {
                    return false;
                }
                _etq_prd_tcs = _ExDep.NombrePrd + Environment.NewLine + _item.Descripcion;
                var _idTCS = _item.Id;
                var grp = _ExDep.ExDep.Where(w => w.idTCS == _idTCS).GroupBy(g => new { id = g.idTCS, des = g.NombreDep }).Select(s => new { key = s.Key, reg = s.ToList() }).ToList();
                var _lst = grp.Select(s =>
                {
                    var nr = new data()
                    {
                        Descripcion = s.key.des,
                        Fisica = s.reg.Sum(t => t.Fisica),
                        Reservada = s.reg.Sum(t => t.Reservada),
                        Disponible = s.reg.Sum(t => t.Disponible),
                    };
                    return nr;
                }).ToList();
                _gDeposito.setLista(_lst);
                return true;
            }
            return false;
        }
    }
}