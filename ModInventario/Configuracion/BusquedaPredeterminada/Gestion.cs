using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.BusquedaPredeterminada
{
    
    public class Gestion
    {

        private bool _isOk;
        private BindingSource _bs;
        private List<data> _ldata;
        private data _busquedaPred;


        public bool IsOk { get { return _isOk; } }
        public data BusquedaPred { get { return _busquedaPred; } }
        public BindingSource Source { get { return _bs; } }


        public Gestion()
        {
            _isOk = false;
            _busquedaPred = null;
            _ldata = new List<data>();
            _bs=new BindingSource();
            _bs.DataSource = _ldata;
        }


        public void Inicializa()
        {
            _isOk = false;
        }

        ConfigurarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ConfigurarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _ldata.Clear();
            _ldata.Add(new data("1", "Codigo"));
            _ldata.Add(new data("2", "Nombre"));
            _ldata.Add(new data("3", "Referencia"));
            
            switch (r01.Entidad.ToString().ToUpper()) 
            {
                case "PORCODIGO":
                    _busquedaPred= _ldata.FirstOrDefault(f => f.auto == "1");
                    break;
                case "PORNOMBRE":
                    _busquedaPred = _ldata.FirstOrDefault(f => f.auto == "2");
                    break;
                case "PORREFERENCIA":
                    _busquedaPred = _ldata.FirstOrDefault(f => f.auto == "3");
                    break;
            }

            return rt;
        }

        public void Proesar()
        {
            _isOk = false;
            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var fichaOOB = new OOB.LibInventario.Configuracion.BusquedaPredeterminada.Editar.Ficha()
                {
                    Busqueda = _busquedaPred.descripcion,
                };
                var r01 = Sistema.MyData.Configuracion_SetBusquedaPredeterminada(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _isOk = true;
                Helpers.Msg.EditarOk();
            }

        }

        public void setBusquedaPred (string p)
        {
            _busquedaPred = _ldata.FirstOrDefault(f => f.auto == p);
        }

    }

}