using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.Deposito.VerLista
{
    public class ImpVerLista: IVerLista
    {
        private string _autoPrd;
        private string _autoDep;
        private string _decimales;
        private string _empaque;
        private int _empaqueContenido;
        private string _empaqueDes;
        private string _producto;
        private OOB.LibInventario.Producto.Data.Existencia _ficha;
        private Lista _gLista;
        private src.TallaColorSabor.Visualizar.IVer _gTCS;
        private src.Producto.Deposito.Visualizar.IVisualizar _gVisDeposito;
        private src.Producto.Deposito.Editar.IEditar _gEditarDep;


        public BindingSource GetData_Source { get { return _gLista.GetSource; } }
        public data ItemActual { get { return (data)_gLista.ItemActual; } }
        public string GetInf_Producto_Desc { get { return _producto; } }
        public string GetInf_Prdoucto_EmpaqueDesc { get { return _empaqueDes; } }
        public string GetInf_ExFisica { get { return _gLista.GetExFisica.ToString("n" + _decimales); } }
        public string GetInf_ExReserva { get { return _gLista.GetExReserva.ToString("n" + _decimales); } }
        public string GetInf_ExDisponible { get { return _gLista.GetExDisponible.ToString("n" + _decimales); } }


        public ImpVerLista(src.TallaColorSabor.Visualizar.IVer hndTCS,
                            src.Producto.Deposito.Visualizar.IVisualizar hndVisDeposito, 
                            src.Producto.Deposito.Editar.IEditar hndEditDeposito)
        {
            _autoPrd = "";
            _autoDep = "";
            _empaque = "";
            _empaqueContenido = 1;
            _empaqueDes = "";
            _producto = "";
            _decimales = "";
            _ficha = null;
            _gLista = new Lista();
            _gTCS = hndTCS;
            _gVisDeposito = hndVisDeposito;
            _gEditarDep = hndEditDeposito;
        }


        public void Inicializa()
        {
            _autoPrd = "";
            _autoDep = "";
            _empaque = "";
            _empaqueContenido = 1;
            _empaqueDes = "";
            _producto = "";
            _decimales = "";
            _ficha = null;
            _gLista.Inicializa();
        }
        VerFrm frm; 
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new VerFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setIdPrd(string idPrd)
        {
            _autoPrd = idPrd;
        }
        public void setIdDeposito(string idDep)
        {
            _autoDep = idDep;
        }
        public void setContenidoPorUnidad()
        {
            _empaqueDes = "UNIDAD (1)";
            _gLista.setContenido(1);
        }
        public void setContenidoPorEmpCompra()
        {
            _empaqueDes = _empaque.Trim().ToUpper() + " (" + _empaqueContenido.ToString().Trim() + ")";
            _gLista.setContenido(_empaqueContenido);
        }


        public void VerDetalleDeposito()
        {
            if (ItemActual != null)
            {
                _gVisDeposito.Inicializa();
                _gVisDeposito.setIdPrd(_autoPrd);
                _gVisDeposito.setIdDep(ItemActual.IdDep);
                _gVisDeposito.Inicia();
            }
        }
        public void EditarDeposito()
        {
            if (ItemActual!= null)
            {
                var r00 = Sistema.MyData.Permiso_CambiarDatosDelDeposito(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    _gEditarDep.Inicializa();
                    _gEditarDep.setIdPrd(_autoPrd);
                    _gEditarDep.setIdDep(ItemActual.IdDep);
                    _gEditarDep.Inicia();
                }
            }
        }
        public void ImprimirReporte()
        {
            var rp = new Reportes.RepProducto.ExistenciaPorDeposito.gestionRep(_ficha, "");
            rp.Generar();
        }
        public void ExPor_TallaColorSabor()
        {
            if (ItemActual != null)
            {
                _gTCS.Inicializa();
                _gTCS.setIdPrd(_autoPrd);
                _gTCS.setIdDeposito(ItemActual.IdDep);
                _gTCS.HabilitaBtDetalle(false);
                _gTCS.Inicia();
            }
        }


        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Producto_GetExistencia(_autoPrd);
                _ficha = r01.Entidad;
                _producto = r01.Entidad.codigoPrd + Environment.NewLine + r01.Entidad.nombrePrd;
                _decimales = r01.Entidad.decimales;
                _empaque = r01.Entidad.empaque;
                _empaqueContenido = r01.Entidad.empaqueContenido;
                var _lst = new List<data>();
                var _list = r01.Entidad.depositos.ToList();
                if (_autoDep != "")
                {
                    _list = r01.Entidad.depositos.Where(w => w.autoId == _autoDep).ToList();
                }
                foreach (var it in _list.OrderBy(o => o.nombre).ToList())
                {
                    var nr = new data(it, _decimales);
                    _lst.Add(nr);
                }
                _gLista.setLista(_lst);
                setContenidoPorUnidad();
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