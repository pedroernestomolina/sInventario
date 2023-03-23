﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.AdmMovPend
{
    public interface IAdmMovPend: IAdministrador 
    {
        bool LimpiarFiltrosIsOk { get; }
        bool AnularIsOk { get; }
        BindingSource TipoDocSource { get; }
        string TipoDocID { get; }


        void GenerarMov();
        void LimpiarFiltros();
        void setTipoDoc(string id);
    }
}