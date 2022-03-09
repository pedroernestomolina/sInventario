using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv.Grupo
{

    public class Gestion : IMaestroTipo
    {

        private data _itemAgregarEditar;
        private List<data> _lst;
        private bool _eliminarIsOk;
        private IAgregarEditar _gAgregar;
        private IAgregarEditar _gEditar;
        private ISeguridadAccesoSistema _gAcceso;


        public string Titulo { get { return "Maestro: GRUPOS"; } }
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
            var r01 = Sistema.MyData.Grupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _lst.Clear();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lst.Add(new data(rg.auto, rg.codigo, rg.nombre));
            }
            return true;
        }

        public void AgregarItem()
        {
            var r00 = Sistema.MyData.Permiso_CrearGrupo(Sistema.UsuarioP.autoGru);
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
                    var r01 = Sistema.MyData.Grupo_GetFicha(_gAgregar.IdItemAgregado);
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
            var r00 = Sistema.MyData.Permiso_ModificarGrupo(Sistema.UsuarioP.autoGru);
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
                    var r01 = Sistema.MyData.Grupo_GetFicha(idItemEditar);
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
            var r00 = Sistema.MyData.Permiso_EliminarGrupo(Sistema.UsuarioP.autoGru);
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
                    var r01 = Sistema.MyData.Grupo_Eliminar(id);
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