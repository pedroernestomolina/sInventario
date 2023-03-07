﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.MovInventario.Descargo.CapturaMov
{
    
    public class ImpCapturaMovDescargo: ICapturaMovDescargo
    {
        public event EventHandler ItemCapturado;


        private bool _modoEditar;
        private Tools.CapturaMov.IDataCaptura _itEditar;
        private decimal _tasaCambio;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private Tools.CapturaMov.IDataCaptura _dataMov;


        public Tools.CapturaMov.IDataCaptura Captura { get { return _dataMov; } }


        public ImpCapturaMovDescargo() 
        {
            _modoEditar = false;
            _tasaCambio = 0m;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _itEditar = null;
        }


        public void Inicializa()
        {
            _modoEditar = false;
            _tasaCambio = 0m;
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _dataMov = new Tools.CapturaMov.ImpDataCaptura();
            _itEditar = null;
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setData(data dat)
        {
            _dataMov.setFicha(dat);
        }
        public void setDataEditar(Tools.CapturaMov.IDataCaptura it)
        {
            _modoEditar = true;
            _itEditar = it;
        }
        public void setTasaCambio(decimal tasaCambio)
        {
            _dataMov.setTasaCambio(tasaCambio);
        }


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            if (_dataMov.ValidarParaProcesarIsOk()) 
            {
                _procesarIsOk = false;
                var xmsg = "Guardar Cambios ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    _procesarIsOk = true;
                    EventHandler hnd = ItemCapturado;
                    if (hnd != null) 
                    {
                        hnd.Invoke(this, null);
                    }
                }
            }
        }


        private bool CargarData()
        {
            var _lst = new List<ficha>();
            _lst.Add(new ficha("1", "", "POR EMPQ/COMPRA"));
            _lst.Add(new ficha("3", "", "POR EMPQ/INV"));
            _lst.Add(new ficha("2", "", "POR UNIDAD"));
            _dataMov.Empaque.CargarData(_lst);

            if (_modoEditar)
            {
                _dataMov.setFicha(_itEditar.Ficha.GetFicha);
                _dataMov.setCantidad(_itEditar.Cantidad);
                _dataMov.setCosto(_itEditar.CostoNeto);
                _dataMov.setEmpaque(_itEditar.Empaque.GetId);
                _dataMov.setTasaCambio(_itEditar.TasaCambio);
            }
            return true;
        }
    }
}