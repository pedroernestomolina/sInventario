using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv.Concepto
{

    public class Gestion : IMaestroTipo
    {

        private data _itemAgregarEditar;
        private List<data> _lst;
        private bool _eliminarIsOk;
        private IAgregarEditar _gAgregar;
        private IAgregarEditar _gEditar;
        private ISeguridadAccesoSistema _gAcceso;


        public string Titulo { get { return "Maestro: CONCEPTO INVENTARIO"; } }
        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public bool EditarIsOk { get { return _gEditar.IsOk; } }
        public bool EliminarIsOK { get { return _eliminarIsOk; } }
        public List<data> ListaData { get { return _lst; } }
        public data ItemAgregarEditar { get { return _itemAgregarEditar; } }


        public Gestion(ISeguridadAccesoSistema seguridad,
            IAgregarEditar agregar,
            IAgregarEditar editar)
        {
            _gAcceso = seguridad;
            _gAgregar = agregar;
            _gEditar = editar;

            _eliminarIsOk = false;
            _itemAgregarEditar = null;
            _lst = new List<data>();
        }


        public void Inicializa()
        {
            _eliminarIsOk = false;
            _itemAgregarEditar = null;
            _lst.Clear();
        }

        public bool CargarData()
        {
            try
            {
                _lst.Clear();
                var r01 = Sistema.MyData.Concepto_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lst.Add(new data(rg.auto, rg.codigo, rg.nombre));
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        public void AgregarItem()
        {
            var r00 = Sistema.MyData.Permiso_CrearConceptoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            _gAgregar.Inicializa();
            if (_gAcceso.Verificar(r00.Entidad))
            {
                _gAgregar.Inicia();
                if (_gAgregar.IsOk)
                {
                    var r01 = Sistema.MyData.Concepto_GetFicha(_gAgregar.IdItemAgregado);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _itemAgregarEditar = new data(r01.Entidad.auto, r01.Entidad.codigo, r01.Entidad.nombre);
                }
            }
        }

        public void EditarItem(string id)
        {
            var r00 = Sistema.MyData.Permiso_ModificarConceptoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            _gEditar.Inicializa();
            if (_gAcceso.Verificar(r00.Entidad))
            {
                var idItemEditar = id;
                _gEditar.setIdItemEditar(idItemEditar);
                _gEditar.Inicia();
                if (_gEditar.IsOk)
                {
                    var r01 = Sistema.MyData.Concepto_GetFicha(idItemEditar);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _itemAgregarEditar = new data(r01.Entidad.auto, r01.Entidad.codigo, r01.Entidad.nombre);
                }
            }
        }

        public void EliminarItem(string id)
        {
            _eliminarIsOk = false;
            var r00 = Sistema.MyData.Permiso_EliminarConceptoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_gAcceso.Verificar(r00.Entidad))
            {
                var xmsg = "Eliminar Item Actual ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var r01 = Sistema.MyData.Concepto_Eliminar(id);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _eliminarIsOk = true;
                    Helpers.Msg.EliminarOk();
                }
            }
        }

    }

}