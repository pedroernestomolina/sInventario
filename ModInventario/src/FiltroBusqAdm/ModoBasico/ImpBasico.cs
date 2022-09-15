using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.FiltroBusqAdm.ModoBasico
{

    public class ImpBasico: BaseImpFiltroPrd, IBasico  
    {


        public ImpBasico()
        {
            _data = new dataFiltro();
            _gMarca = new FiltrosGen.Opcion.Gestion();
            _gOrigen = new FiltrosGen.Opcion.Gestion();
            _gTasaIva = new FiltrosGen.Opcion.Gestion();
            _gEstatus = new FiltrosGen.Opcion.Gestion();
            _gDivisa = new FiltrosGen.Opcion.Gestion();
            _gPesado = new FiltrosGen.Opcion.Gestion();
            _gDepartamento = new FiltrosGen.Opcion.Gestion();
            _gGrupo = new FiltrosGen.Opcion.Gestion();
            reset();
        }


        FiltrosFrm frm;
        override public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new FiltrosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            if (base.CargarData())
            {
                var lstEstatus = new List<ficha>();
                lstEstatus.Add(new ficha("01", "", "ACTIVO"));
                lstEstatus.Add(new ficha("03", "", "INACTIVO"));
                _gEstatus.setData(lstEstatus);

                return true;
            }
            else 
            {
                return false;
            }
        }

        public override bool DataFiltrarIsOk()
        {
            return base.DataFiltrarIsOk();
        }

    }

}