using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.Listar
{
    
    public class Gestion
    {


        private List<data> _data;
        private BindingSource _bs;
        private string _autoPrd;
        private string _decimales;
        private string _empaque;
        private int _empaqueContenido;
        private string _empaqueDes;
        private string _producto;
        private Ver.Gestion _gestionVer ;
        private Editar.Gestion _gestionEditar;


        public BindingSource Source { get { return _bs; } }
        public string Producto { get { return _producto; } }
        public decimal ExFisica { get { return _data.Sum(s => s.ExFisica); } }
        public decimal ExReserva { get { return _data.Sum(s => s.ExReserva); } }
        public decimal ExDisponible { get { return _data.Sum(s => s.ExDisponible); } }
        public string EmpaqueDes { get { return _empaqueDes; } }
        public string Formato 
        {
            get 
            { 
                var r="n";
                r+=_decimales;
                return r;
            } 
        }


        public Gestion()
        {
            _autoPrd = "";
            _empaque = "";
            _empaqueContenido = 1;
            _gestionVer = new Ver.Gestion();
            _gestionEditar = new Editar.Gestion();

            _data = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _data;
        }


        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                var frm = new VerFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            _fichaPrd = null;
            _empaque = "";
            _empaqueContenido = 1;
            _data.Clear();
        }

        public void setFicha(string autoprd)
        {
            _autoPrd = autoprd;
        }

        private OOB.LibInventario.Producto.Data.Existencia _fichaPrd;
        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Producto_GetExistencia(_autoPrd);
                _fichaPrd = r01.Entidad;
                _producto = r01.Entidad.codigoPrd + Environment.NewLine + r01.Entidad.nombrePrd;
                _decimales = r01.Entidad.decimales;
                _empaque = r01.Entidad.empaque;
                _empaqueContenido = r01.Entidad.empaqueContenido;
                foreach (var it in r01.Entidad.depositos.OrderBy(o => o.nombre).ToList())
                {
                    var nr = new data(it, _decimales);
                    _data.Add(nr);
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

        public void setCompra()
        {
            _empaqueDes = _empaque.Trim().ToUpper() + " (" + _empaqueContenido.ToString().Trim() + ")"; 
            foreach (var it in _data) 
            {
                it.setContenido(_empaqueContenido);
            }
        }

        public void setUnidad()
        {
            _empaqueDes = "UNIDAD (1)";
            foreach (var it in _data)
            {
                it.setContenido(1);
            }
        }

        public void VerDetalleDeposito()
        {
            if (_bs.Current!=null)
            {
                var item= (data) _bs.Current;
                _gestionVer.setFicha(_autoPrd, item.Deposito.autoId);
                _gestionVer.Inicia();
            }
        }

        public void EditarDeposito()
        {
            if (_bs.Current != null)
            {
                var item = (data)_bs.Current;
                var r00 = Sistema.MyData.Permiso_CambiarDatosDelDeposito(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    _gestionEditar.setFicha(_autoPrd, item.Deposito.autoId);
                    _gestionEditar.Inicia();
                }
            }
        }

        public void ImprimirReporte()
        {
            var rp = new Reportes.RepProducto.ExistenciaPorDeposito.gestionRep(_fichaPrd, "");
            rp.Generar();
        }

    }

}