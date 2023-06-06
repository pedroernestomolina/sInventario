using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Tools.ExcluirDepart
{
    public class ImpExcluir: IExcluir
    {
        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private IListaSeleccion _listaSelec;
        private bool _dataIsCargada;


        public BindingSource GetDatatSource { get { return _listaSelec.GetDataSource; } }
        public List<Tools.ExcluirDepart.data> GetLista { get { return (List<Tools.ExcluirDepart.data>)_listaSelec.GetLista; } }
        

        public ImpExcluir()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _dataIsCargada = false;
            _listaSelec = new Tools.ExcluirDepart.ImpListaSeleccion();
        }
        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _dataIsCargada = false;
            _listaSelec.Inicializa();
        }
        Frm frm;
        public void Inicia()
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


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }

        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = true;
        }


        private bool CargarData()
        {
            try
            {
                if (!_dataIsCargada)
                {
                    var r01 = Sistema.MyData.Departamento_GetLista();
                    var _lst = new List<Tools.ExcluirDepart.data>();
                    foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                    {
                        _lst.Add(new Tools.ExcluirDepart.data(rg));
                    }
                    _listaSelec.setDataListar(_lst);
                    _dataIsCargada = true;
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void setMarcarTodas(bool marcar)
        {
            _listaSelec.setSeleccionarTodas(marcar);
        }
    }
}