using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.RedondeoPrecio
{
    
    public class Gestion
    {

        private bool _isOk;
        private BindingSource _bs;
        private List<data> _ldata;
        private data _redondeo;


        public bool IsOk { get { return _isOk; } }
        public data Redondeo { get { return _redondeo; } }
        public BindingSource Source { get { return _bs; } }
        public string OpcionRedondeo { get { return _redondeo.auto; } }


        public Gestion()
        {
            _isOk = false;
            _redondeo = null;
            _ldata = new List<data>();
            _bs=new BindingSource();
            _bs.DataSource = _ldata;
        }


        public void Inicializa()
        {
            _isOk = false;
        }

        RedondeoPrecio.ConfigurarFrm frm;
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

            var r01 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _ldata.Clear();
            _ldata.Add(new data("1", "Sin Redondeo"));
            _ldata.Add(new data("2", "Unidad"));
            _ldata.Add(new data("3", "Decena"));
            
            switch (r01.Entidad) 
            {
                case  OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.SinRedeondeo :
                    _redondeo = _ldata.FirstOrDefault(f => f.auto == "1");
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad :
                    _redondeo = _ldata.FirstOrDefault(f => f.auto == "2");
                    break;
                case  OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
                    _redondeo = _ldata.FirstOrDefault(f => f.auto == "3");
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
                var fichaOOB = new OOB.LibInventario.Configuracion.RedondeoPrecio.Editar.Ficha()
                {
                    Redondeo=_redondeo.descripcion,
                };
                var r01 = Sistema.MyData.Configuracion_SetRedondeoPrecioVenta(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _isOk = true;
                Helpers.Msg.EditarOk();
            }

        }

        public void setRedondeo(string p)
        {
            _redondeo = _ldata.FirstOrDefault(f => f.auto == p);
        }

    }

}