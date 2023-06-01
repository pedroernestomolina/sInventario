using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis
{
    public class ImpAnalisis: IAnalisis
    {
        private int _idTomaAnalizar;
        private ILista _lista;


        public BindingSource GetSource { get { return _lista.GetDataSource; } }


        public ImpAnalisis()
        {
            _idTomaAnalizar = -1;
            _lista = new ImpLista();
        }


        public void Inicializa()
        {
            _idTomaAnalizar = -1;
            _lista.Inicializa();
        }
        private Frm frm;
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

        public void setTomaInvAnalizar(int idToma)
        {
            _idTomaAnalizar = idToma;
        }


        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.TomaInv_Analisis(_idTomaAnalizar);
                var _lst = new List<TomaInv.Analisis.data>();
                foreach (var rg in r01.Entidad.Items)
                {
                    _lst.Add(new TomaInv.Analisis.data(rg));
                }
                _lista.setDataListar(_lst);
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