using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros.EmpaqueMedida
{

    public class AgregarEditar
    {

        private bool isModoAgregar;
        private OOB.LibInventario.EmpaqueMedida.Ficha ficha;


        public bool IsOk { get; set; }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Decimales { get; set; }
        public OOB.LibInventario.EmpaqueMedida.Ficha Ficha { get { return ficha; } }


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
                frm.setTitulo("Agregar Empaque/Medida:");
                frm.ShowDialog();
            }
        }

        private void LimpiarEntradas()
        {
            IsOk = false;
            Nombre = "";
            Decimales = "0";
            ficha = null;
        }

        private bool CargarData()
        {
            var rt = true;
            return rt;
        }

        public void Guardar()
        {
            if (Nombre.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Nombre Empaque/Medida ] No Puede Estar Vacio");
                return;
            }
            if (Decimales.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Decimales Empaque/Medida ] No Puede Estar Vacio");
                return;
            }

            if (isModoAgregar)
            {
                var msg = MessageBox.Show("Guardar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var xficha = new OOB.LibInventario.EmpaqueMedida.Agregar()
                    {
                        nombre = Nombre,
                        decimales = Decimales,
                    };
                    var r01 = Sistema.MyData.EmpaqueMedida_Agregar(xficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var r02 = Sistema.MyData.EmpaqueMedida_GetFicha(r01.Auto);
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
                    var xficha = new OOB.LibInventario.EmpaqueMedida.Editar()
                    {
                        auto = Id,
                        nombre = Nombre,
                        decimales = Decimales,
                    };
                    var r01 = Sistema.MyData.EmpaqueMedida_Editar(xficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var r02 = Sistema.MyData.EmpaqueMedida_GetFicha(Id);
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
            if (CargarData())
            {
                var r01 = Sistema.MyData.EmpaqueMedida_GetFicha(it.id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Id = r01.Entidad.auto;
                Nombre = r01.Entidad.nombre;
                Decimales = r01.Entidad.decimales;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Editar Empaque/Medida:");
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