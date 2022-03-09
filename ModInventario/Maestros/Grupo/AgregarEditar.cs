using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros.Grupo
{

    public class AgregarEditar
    {

        private bool isModoAgregar;
        private OOB.LibInventario.Grupo.Ficha ficha;


        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool IsOk { get; set; }
        public OOB.LibInventario.Grupo.Ficha Ficha { get { return ficha; } }


        public AgregarEditar()
        {
            ficha = null;
        }

        AgregarEditarFrm frm;
        public void Agregar()
        {
            LimpiarEntradas();
            isModoAgregar = true;
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Agregar Grupo:");
                frm.ShowDialog();
            }
        }

        private void LimpiarEntradas()
        {
            IsOk = false;
            Nombre = "";
            Codigo = "";
            ficha = null;
        }

        private bool CargarData()
        {
            var rt = true;
            return rt;
        }

        public void Guardar()
        {
            if (Codigo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Codigo Grupo ] No Puede Estar Vacio");
                return;
            }
            if (Nombre.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Nombre Grupo ] No Puede Estar Vacio");
                return;
            }

            if (isModoAgregar)
            {
                var msg = MessageBox.Show("Guardar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var xficha = new OOB.LibInventario.Grupo.Agregar()
                    {
                        nombre = Nombre,
                        codigo = Codigo,
                    };
                    var r01 = Sistema.MyData.Grupo_Agregar(xficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var r02 = Sistema.MyData.Grupo_GetFicha(r01.Auto);
                    if (r02.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }
                    ficha = r02.Entidad;
                    IsOk = true;
                }
            }
            else
            {
                var msg = MessageBox.Show("Cambiar/Actualizar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var xficha = new OOB.LibInventario.Grupo.Editar()
                    {
                        auto = Id,
                        nombre = Nombre,
                        codigo = Codigo,
                    };
                    var r01 = Sistema.MyData.Grupo_Editar(xficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var r02 = Sistema.MyData.Grupo_GetFicha(Id);
                    if (r02.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }
                    ficha = r02.Entidad;
                    IsOk = true;
                }
            }
        }

        public void Editar(data it)
        {
            LimpiarEntradas();
            isModoAgregar = false;
            if (CargarData())
            {
                var r01 = Sistema.MyData.Grupo_GetFicha (it.id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Id = r01.Entidad.auto;
                Codigo = r01.Entidad.codigo;
                Nombre = r01.Entidad.nombre;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Editar Grupo:");
                frm.ShowDialog();
            }
        }

        public bool AbandonarDocumento()
        {
            var msg = MessageBox.Show("Abandonar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return (msg == DialogResult.Yes);
        }

    }

}