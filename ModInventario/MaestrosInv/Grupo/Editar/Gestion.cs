using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv.Grupo.Editar
{

    public class Gestion : IAgregarEditar
    {

        private string _codigo;
        private string _nombre;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private string _idItemAgregado;
        private string _idItemEditar;


        public string Titulo { get { return "Editar Item: GRUPO"; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public string Codigo { get { return _codigo; } }
        public string Nombre { get { return _nombre; } }
        public string IdItemAgregado { get { return _idItemAgregado; } }


        public Gestion()
        {
            _codigo = "";
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemAgregado = "";
            _idItemEditar = "";
        }


        public void Inicializa()
        {
            _codigo = "";
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemAgregado = "";
            _idItemEditar = "";
        }

        AgregarEditarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Grupo_GetFicha(_idItemEditar);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _codigo = r01.Entidad.codigo;
            _nombre = r01.Entidad.nombre;
            return true;
        }


        public void Procesar()
        {
            if (_codigo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ CÓDIGO ] No Puede Estar Vacio");
                return;
            }
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }

            var xmsg = "Guardar Cambios Para La Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var xficha = new OOB.LibInventario.Grupo.Editar()
                {
                    auto = _idItemEditar,
                    nombre = _nombre,
                    codigo = _codigo,
                };
                var r01 = Sistema.MyData.Grupo_Editar(xficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk = true;
                Helpers.Msg.EditarOk();
            }
        }

        public void Abandonar()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
                _abandonarIsOk = true; ;
        }

        public void setCodigo(string p)
        {
            _codigo = p;
        }
        public void setNombre(string p)
        {
            _nombre = p;
        }
        public void setIdItemEditar(string id)
        {
            _idItemEditar = id;
        }

    }

}