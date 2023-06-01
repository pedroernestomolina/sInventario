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


        public void EliminarTomas()
        {
            var msg = "Eliminar Estos Conteos ?";
            var resp = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.No) 
            {
                return;
            }
            var _lst = _lista.GetLista.Where(w => w.Eliminar && w.Estado != data.enumAnalisis.SinDefinir);
            var ficha = new OOB.LibInventario.TomaInv.RechazarItem.Ficha()
            {
                IdToma = _idTomaAnalizar,
                Items = _lst.Select(s =>
                {
                    var nr = new OOB.LibInventario.TomaInv.RechazarItem.Item()
                    {
                        IdPrd = s.itemAnalisis.idPrd,
                    };
                    return nr;
                }).ToList(),
            };
            try
            {
                var r01 = Sistema.MyData.TomaInv_RechazarItemToma(ficha);
                _lista.setEliminarItems(_lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
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

        public void setMarcarTodas(bool m)
        {
            _lista.setMarcarTodas(m);
        }
    }
}