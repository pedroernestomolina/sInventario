using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.TallaColorSabor
{
    public class ImpTallaColorSabor: ITallaColorSabor
    {
        private string _tallaColorSabor;
        private List<data> _lstTallaColorSabor;
        private BindingList<data> _blTallaColorSabor;
        private BindingSource _bsTallaColorSabor;

        public BindingSource GetTallaColorSabor_Source { get { return _bsTallaColorSabor; } }
        public string GetTallaColorSabor_Desc { get { return _tallaColorSabor; } }
        public int GetTallaColorSabor_CntItems { get { return _blTallaColorSabor.Count; } }


        public ImpTallaColorSabor()
        {
            _tallaColorSabor = "";
            _lstTallaColorSabor = new List<data>();
            _blTallaColorSabor = new BindingList<data>(_lstTallaColorSabor);
            _bsTallaColorSabor = new BindingSource();
            _bsTallaColorSabor.DataSource = _blTallaColorSabor;
        }

        public void Inicializa()
        {
            _tallaColorSabor = "";
            _blTallaColorSabor.Clear();
            _bsTallaColorSabor.CurrencyManager.Refresh();
        }
        public void setTallaColorSabor(string desc)
        {
            _tallaColorSabor = desc;
        }
        public void AgregarTallaColorSabor()
        {
            if (_tallaColorSabor != "")
            {
                var nr = new data(_tallaColorSabor);
                var _item = _blTallaColorSabor.FirstOrDefault(f => f.Descripcion == _tallaColorSabor);
                if (_item == null)
                {
                    _blTallaColorSabor.Add(nr);
                    _bsTallaColorSabor.CurrencyManager.Refresh();
                }
            }
            _tallaColorSabor = "";
        }
        public void EliminarTallaColorSabor()
        {
            if (_bsTallaColorSabor.Current != null)
            {
                var _item = (data)_bsTallaColorSabor.Current;
                _blTallaColorSabor.Remove(_item);
                _bsTallaColorSabor.CurrencyManager.Refresh();
            }
        }
        public List<dataRetornar> DataRetornar()
        {
            return _blTallaColorSabor.Select(s => {
                var nr = new dataRetornar()
                {
                    Descripcion = s.Descripcion,
                    Id = s.Id,
                };
                return nr;
            }).ToList();
        }
        public void CargarData(List<data> lst)
        {
            _blTallaColorSabor.Clear();
            foreach (var rg in lst)
            {
                var nr = new data()
                {
                    Descripcion = rg.Descripcion,
                    Id = rg.Id,
                };
                _blTallaColorSabor.Add(nr);
            }
            _bsTallaColorSabor.CurrencyManager.Refresh();
        }


        public void RefreshTallaColorSabor()
        {
            throw new NotImplementedException();
        }
    }
}