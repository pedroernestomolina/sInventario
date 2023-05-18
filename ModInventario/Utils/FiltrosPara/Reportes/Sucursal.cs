﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.FiltrosPara.Reportes
{
    public class Sucursal: Utils.Filtros.Sucursal, ICtrlHabilitar
    {
        public Sucursal()
            : base()
        {
            _isRequerido = false;
        }


        private bool _isRequerido;
        public bool GetIsRequerido { get { return _isRequerido; } }
        public void setIsRequerido(bool req)
        {
            _isRequerido = req;
        }


        public bool IsOk()
        {
            var r = true;
            if (_habilitar)
            {
                if (_isRequerido)
                {
                    if (Ctrl.GetItem == null)
                    {
                        Helpers.Msg.Alerta("Debes Indicar Una Sucursal");
                        return false;
                    }
                }
            }
            return r;
        }
    }
}