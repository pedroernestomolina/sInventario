using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Plu
{

    public class Gestion: IPlu
    {


        private List<data> _lst;
        private BindingSource _bs;


        public BindingSource GetSource { get { return _bs; } }
        public int GetCntItems { get { return _bs.Count; } }


        public Gestion()
        {
            _lst= new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
        }

        
        PluFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new PluFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            try
            {
                _lst.Clear();
                var r01 = Sistema.MyData.Producto_Plu_Lista();
                foreach (var reg in r01.Lista.OrderBy(o => o.plu).ToList())
                {
                    _lst.Add(new data(reg));
                }
                _bs.CurrencyManager.Refresh();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public void Inicializa()
        {
            _lst.Clear();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }

    }

}