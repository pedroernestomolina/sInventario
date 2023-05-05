using ModInventario.Utils.FiltrosPara.AdmDocumentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Filtro.FiltroAdmDoc.ModoBasico
{
    public class ImpModoBasico: baseAdmDoc, IAdmDoc
    {
        public ImpModoBasico(FiltrosGen.IBuscar filtroBusPrd)
        {
            //_filtroBusPrd = filtroBusPrd;
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

        public override IDataExportar DataExportar
        {
            get { throw new NotImplementedException(); }
        }


        public new Utils.FiltrosPara.AdmDocumentos.IDataExportar DataExportar
        {
            get { throw new NotImplementedException(); }
        }
    }
}