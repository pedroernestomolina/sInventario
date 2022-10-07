using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Filtro.FiltroRep.ModoBasico
{
    
    public class ImpModoBasico: baseFiltro, IModoBasico
    {

        public ImpModoBasico()
            :base(new dataFiltrar())
        {
            _gDeposito = new FiltrosGen.Opcion.Gestion();
            _gDepartamento= new FiltrosGen.Opcion.Gestion();
            _gGrupo= new FiltrosGen.Opcion.Gestion();
            _gMarca= new FiltrosGen.Opcion.Gestion();
            _gDivisa = new FiltrosGen.Opcion.Gestion();
            _gImpuesto = new FiltrosGen.Opcion.Gestion();
            _gEstatus = new FiltrosGen.Opcion.Gestion();
            _gPesado = new FiltrosGen.Opcion.Gestion();
            _gDesde = new FiltrosGen.Fecha.Gestion();
            _gHasta = new FiltrosGen.Fecha.Gestion();
        }


        public override void Inicializa()
        {
            base.Inicializa();
            _data.Limpiar();
        }
        FiltrosFrm frm;
        public override void Inicia()
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


        public override bool CargarData()
        {
            return base.CargarData();
        }


        public override bool FiltrosIsOK { get { return validarData(); } }
        public override FiltrosGen.Reportes.data dataFiltrar { get { return dataExportar(); } }
        public override void setValidarData(bool p)
        {
        }
        private bool validarData()
        {
            if (ProcesarIsOk)
            {
                if (_data.Desde.HasValue)
                {
                    if (_data.Hasta.HasValue)
                    {
                        if (_data.Hasta.Value >= _data.Desde.Value)
                        {
                            return true;
                        }
                        Helpers.Msg.Alerta("FECHAS INCORRECTAS, VERIFIQUE POR FAVOR");
                        return false;
                    }
                    return true;
                }
                return true;
            }
            return false;
        }
        private FiltrosGen.Reportes.data dataExportar()
        {
            var rg = new FiltrosGen.Reportes.data()
            {
                Depart = _data.Departamento,
                Deposito = _data.Deposito,
                Desde = _data.Desde,
                Divisa = _data.Divisa,
                Estatus = _data.Estatus,
                Grupo = _data.Grupo,
                Hasta = _data.Hasta,
                Marca = _data.Marca,
                Pesado= _data.Pesado,
                TasaIva = _data.Impuesto,
                Categoria = null,
                Origen = null,
                Producto = null,
                Sucursal = null,
            };
            return rg;
        }

    }

}