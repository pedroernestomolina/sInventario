using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Helpers.Maestros
{

    public class Maestros : ICallMaestros
    {

        private ModInventario.MaestrosInv.IMaestroTipo _gMtDepart;
        private ModInventario.MaestrosInv.IMaestroTipo _gMtGrupo;
        private ModInventario.MaestrosInv.IMaestroTipo _gMtConcepto;
        private ModInventario.MaestrosInv.IMaestroTipo _gMtMarca;
        private ModInventario.MaestrosInv.IMaestroTipo _gMtUnidadEmpq;
        private ModInventario.MaestrosInv.IMaestro _gMaestro;
        private ISeguridadAccesoSistema _seguridad;


        public Maestros(ModInventario.MaestrosInv.IMaestro ctrMaestro,
            ModInventario.MaestrosInv.IMaestroTipo ctrDepart,
            ModInventario.MaestrosInv.IMaestroTipo ctrGrupo,
            ModInventario.MaestrosInv.IMaestroTipo ctrConcepto,
            ModInventario.MaestrosInv.IMaestroTipo ctrMarca,
            ModInventario.MaestrosInv.IMaestroTipo ctrUnidadEmpq,
            ISeguridadAccesoSistema ctrAcceso)
        {
            _gMaestro = ctrMaestro;
            _gMtDepart = ctrDepart;
            _gMtGrupo = ctrGrupo;
            _gMtConcepto = ctrConcepto;
            _gMtMarca = ctrMarca;
            _gMtUnidadEmpq = ctrUnidadEmpq;
            _seguridad = ctrAcceso;
        }


        public void MtDepartamento()
        {
            var r00 = Sistema.MyData.Permiso_Departamento(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gMtDepart.Inicializa();
                _gMaestro.setGestion(_gMtDepart);
                _gMaestro.Inicializa();
                _gMaestro.Inicia();
            }
        }

        public void MtGrupo()
        {
            var r00 = Sistema.MyData.Permiso_Grupo(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gMtGrupo.Inicializa();
                _gMaestro.setGestion(_gMtGrupo);
                _gMaestro.Inicializa();
                _gMaestro.Inicia();
            }
        }

        public void MtConcepto()
        {
            var r00 = Sistema.MyData.Permiso_ConceptoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gMtConcepto.Inicializa();
                _gMaestro.setGestion(_gMtConcepto);
                _gMaestro.Inicializa();
                _gMaestro.Inicia();
            }
        }

        public void MtMarca()
        {
            var r00 = Sistema.MyData.Permiso_Marca(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gMtMarca.Inicializa();
                _gMaestro.setGestion(_gMtMarca);
                _gMaestro.Inicializa();
                _gMaestro.Inicia();
            }
        }

        public void MtUnidadEmpaque()
        {
            var r00 = Sistema.MyData.Permiso_UnidadEmpaque(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gMtUnidadEmpq.Inicializa();
                _gMaestro.setGestion(_gMtUnidadEmpq);
                _gMaestro.Inicializa();
                _gMaestro.Inicia();
            }
        }

    }

}