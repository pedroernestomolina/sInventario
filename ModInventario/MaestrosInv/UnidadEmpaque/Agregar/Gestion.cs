﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv.UnidadEmpaque.Agregar
{

    public class Gestion : IAgregarEditar
    {

        private string _codigo;
        private string _nombre;
        private string _decimales;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private string _idItemAgregado;


        public string Titulo { get { return "Agregar Item: EMPAQUE-MEDIDA"; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public string Codigo { get { return _codigo; } }
        public string Nombre { get { return _nombre; } }
        public string Decimales { get { return _decimales; } }
        public string IdItemAgregado { get { return _idItemAgregado; } }


        public Gestion()
        {
            _codigo = "";
            _nombre = "";
            _decimales = "0";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemAgregado = "";
        }


        public void Inicializa()
        {
            _codigo = "";
            _nombre = "";
            _decimales = "0";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idItemAgregado = "";
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
            return true;
        }

        public void Procesar()
        {
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }
            if (_decimales.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ DECIMALES ] No Puede Estar Vacio");
                return;
            }
            var xmsg = "Guardar Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var xficha = new OOB.LibInventario.EmpaqueMedida.Agregar()
                {
                    nombre = _nombre,
                    decimales = _decimales,
                };
                var r01 = Sistema.MyData.EmpaqueMedida_Agregar(xficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _idItemAgregado = r01.Auto;
                _procesarIsOk = true;
                Helpers.Msg.AgregarOk();
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
        public void setDecimales(string dec)
        {
            _decimales = dec;
        }

        public void setIdItemEditar(string idItemEditar)
        {
        }

    }

}