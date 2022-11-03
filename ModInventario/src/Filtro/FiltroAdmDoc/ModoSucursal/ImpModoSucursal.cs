﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroAdmDoc.ModoSucursal
{
    
    public class ImpModoSucursal: baseAdmDoc, IAdmDoc
    {
        

        public ImpModoSucursal(FiltrosGen.IBuscar filtroBusPrd)
        {
            _dataExportar = new dataExportar();
            _concepto = new FiltrosGen.Opcion.Gestion();
            _depOrigen = new FiltrosGen.Opcion.Gestion();
            _depDestino = new FiltrosGen.Opcion.Gestion();
            _estatus = new FiltrosGen.Opcion.Gestion();
            _tipoDoc = new FiltrosGen.Opcion.Gestion();
            _desde = new FiltrosGen.Fecha.Gestion();
            _hasta= new FiltrosGen.Fecha.Gestion();
            _sucursal = new FiltrosGen.Opcion.Gestion();
            _filtroBusPrd = filtroBusPrd;
        }


        FiltroFrm frm;
        public override void Inicia()
        {
            if (frm == null)
            {
                frm = new FiltroFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

    }

}