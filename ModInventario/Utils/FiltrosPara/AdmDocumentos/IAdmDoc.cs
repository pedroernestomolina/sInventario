﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Utils.FiltrosPara.AdmDocumentos
{
    
    public interface IAdmDoc: IFiltro
    {
        LibUtilitis.CtrlCB.ICtrl DepositoOrigen { get; }
        LibUtilitis.CtrlCB.ICtrl DepositoDestino { get; }
        LibUtilitis.CtrlCB.ICtrl Estatus { get; }
        LibUtilitis.CtrlCB.ICtrl Concepto { get; }
        LibUtilitis.CtrlCB.ICtrl TipoDoc { get; }
        LibUtilitis.CtrlCB.ICtrl Sucursal { get; }
        Utils.Filtros.DesdeHasta.IFiltro DesdeHasta { get; }
        Utils.Filtros.BuscarPor.IFiltro PorProducto { get; }
        IDataExportar DataExportar { get; }

        bool CargarData();
        void LimpiarFiltros();
    }
}