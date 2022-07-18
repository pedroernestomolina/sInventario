using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Tool.AjusteNivelMinimoMaximoProducto
{

    public class GestionLista
    {

        private GestionAjuste _gestionAjuste;
        private List<data> _ldata;
        private BindingList<data> _bldata;
        private BindingSource _bs;


        public BindingSource Source { get { return _bs; } }
        public List<data> Lista { get { return _ldata; } }


        public GestionLista()
        {
            _gestionAjuste = new GestionAjuste();
            _ldata = new List<data>();
            _bldata=new BindingList<data>(_ldata);
            _bs = new BindingSource();
            _bs.DataSource = _bldata;
        }


        public void setLista(List<OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha> list)
        {
            var lst = _ldata.Where(f => f.IsEditado).ToList();
                
            _bldata.Clear();
            foreach (var it in lst.OrderBy(o => o.NombrePrd).ToList())
            {
                var nr = new data(it);
                _bldata.Add(nr);
            }

            foreach (var it in list.OrderBy(o=>o.nombreProducto).ToList()) 
            {
                var nr = new data(it);
                _bldata.Add(nr);
            }
        }

        public void Limpiar()
        {
            _bldata.Clear();
        }

        public void AjustarMinimoMaximo()
        {
            if (_bs.Current != null) 
            {
                var it =(data) _bs.Current;
                _gestionAjuste.Inicializa();
                _gestionAjuste.setFicha(it);
                _gestionAjuste.Inicia();
                if (_gestionAjuste.ProcesarIsOk)
                {
                    it.setMinimo(_gestionAjuste.GetMinimo);
                    it.setMaximo(_gestionAjuste.GetMaximo);
                }


                //if (it.IsEditado)
                //{
                //    _gestionAjuste.Inicia(it);
                //    if (_gestionAjuste.AjusteIsOk)
                //    {
                //        it.setMinimo(_gestionAjuste.Minimo);
                //        it.setMaximo(_gestionAjuste.Maximo);
                //    }
                //    //var msg = MessageBox.Show("Eliminar Actualización Del Item?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                //    //if (msg == DialogResult.Yes) 
                //    //{
                //    //    _bldata.Remove(it);
                //    //}
                //}
                //else
                //{
                //    _gestionAjuste.Inicia(it);
                //    if (_gestionAjuste.AjusteIsOk)
                //    {
                //        it.setMinimo(_gestionAjuste.Minimo);
                //        it.setMaximo(_gestionAjuste.Maximo);
                //    }
                //}
            }
        }

    }

}