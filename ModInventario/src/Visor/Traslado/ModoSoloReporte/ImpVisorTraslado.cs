using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Visor.Traslado.ModoSoloReporte
{
    
    public class ImpVisorTraslado: IVisorTraslado
    {

        private List<data> _lista;
        private BindingSource _bs;
        private IOpcion _gMes;
        private IOpcion _gAno;


        public BindingSource GetSource { get { return _bs; } }
        public int GetCntItems { get { return _bs.Count; } }
        public string GetNotas
        {
            get 
            {
                var rt = "";
                if (_bs != null)
                    if (_bs.Current != null)
                        rt = ((data)_bs.Current).Nota;
                return rt;
            }
        }


        public ImpVisorTraslado()
        {
            _lista = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lista;
            _gMes = new FiltrosGen.Opcion.Gestion();
            _gAno = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _lista.Clear();
            _bs.DataSource = _lista;
            _bs.CurrencyManager.Refresh();
            _gMes.Inicializa();
            _gAno.Inicializa();
        }
        TrasladoFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new TrasladoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.FechaServidor();
                var fecha = r01.Entidad;
                var _lstMes = new List<ficha>();
                _lstMes.Add(new ficha() { id = "01", desc = "Enero" });
                _lstMes.Add(new ficha() { id = "02", desc = "Febrero" });
                _lstMes.Add(new ficha() { id = "03", desc = "Marzo" });
                _lstMes.Add(new ficha() { id = "04", desc = "Abril" });
                _lstMes.Add(new ficha() { id = "05", desc = "Mayo" });
                _lstMes.Add(new ficha() { id = "06", desc = "Junio" });
                _lstMes.Add(new ficha() { id = "07", desc = "Julio" });
                _lstMes.Add(new ficha() { id = "08", desc = "Agosto" });
                _lstMes.Add(new ficha() { id = "09", desc = "Septiembre" });
                _lstMes.Add(new ficha() { id = "10", desc = "Octubre" });
                _lstMes.Add(new ficha() { id = "11", desc = "Noviembre" });
                _lstMes.Add(new ficha() { id = "12", desc = "Diciembre" });
                _gMes.setData(_lstMes);
                _gMes.setFicha((fecha.Month).ToString().Trim().PadLeft(2, '0'));

                var _lstAno = new List<ficha>();
                _lstAno.Add(new ficha() { id = "2015", desc = "2015" });
                _lstAno.Add(new ficha() { id = "2016", desc = "2016" });
                _lstAno.Add(new ficha() { id = "2017", desc = "2017" });
                _lstAno.Add(new ficha() { id = "2018", desc = "2018" });
                _lstAno.Add(new ficha() { id = "2019", desc = "2019" });
                _lstAno.Add(new ficha() { id = "2020", desc = "2020" });
                _lstAno.Add(new ficha() { id = "2021", desc = "2021" });
                _lstAno.Add(new ficha() { id = "2022", desc = "2022" });
                _lstAno.Add(new ficha() { id = "2023", desc = "2023" });
                _lstAno.Add(new ficha() { id = "2024", desc = "2024" });
                _lstAno.Add(new ficha() { id = "2025", desc = "2025" });
                _lstAno.Add(new ficha() { id = "2026", desc = "2026" });
                _lstAno.Add(new ficha() { id = "2027", desc = "2027" });
                _lstAno.Add(new ficha() { id = "2028", desc = "2028" });
                _lstAno.Add(new ficha() { id = "2029", desc = "2029" });
                _lstAno.Add(new ficha() { id = "2030", desc = "2030" });
                _lstAno.Add(new ficha() { id = "2031", desc = "2031" });
                _lstAno.Add(new ficha() { id = "2032", desc = "2032" });
                _lstAno.Add(new ficha() { id = "2033", desc = "2033" });
                _lstAno.Add(new ficha() { id = "2034", desc = "2034" });
                _lstAno.Add(new ficha() { id = "2035", desc = "2035" });
                _gAno.setData(_lstAno);
                _gAno.setFicha(fecha.Year.ToString().Trim().PadLeft(4, '0'));
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public void Buscar()
        {
            if (_gMes.GetId == "")
            { return; }
            if (_gAno.GetId == "")
            { return; }

            try
            {
                _lista.Clear();
                var filtro = new OOB.LibInventario.Visor.Traslado.Filtro();
                filtro.ano = int.Parse(_gAno.GetId);
                filtro.mes = int.Parse(_gMes.GetId);
                var r01 = Sistema.MyData.Visor_Traslado(filtro);
                foreach (var rg in r01.Lista
                        .Where(w => (w.autoDepositoOrigen == Sistema.Negocio.CodigoDepositoPrincipal) || 
                                    (w.autoDepositoDestino == Sistema.Negocio.CodigoDepositoPrincipal))
                        .OrderByDescending(o => o.fecha).ThenBy(o => o.documentoNro)
                        .ThenBy(o => o.nombrePrd).ToList())
                {
                    _lista.Add(new data(rg));
                }
                _bs.CurrencyManager.Refresh();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        public BindingSource GetMes_Source { get { return _gMes.Source; } }
        public BindingSource GetAno_Source { get { return _gAno.Source; } }
        public string GetMes_Id { get { return _gMes.GetId; } }
        public string GetAno_id { get { return _gAno.GetId; } }
        public void setMesFiltrar(string id)
        {
            _gMes.setFicha(id);
        }
        public void setAnoFiltrar(string id)
        {
            _gAno.setFicha(id);
        }

        public bool AbandonarIsOk { get { return true; } }
        public void AbandonarFicha()
        {
        }

        public void ImprimirReporte()
        {
            if (_lista.Count > 0)
            {
                var rp = new Reportes.Visor.Traslados.GestionRep();
                var filtro = "Mes: " + _gMes.Item.desc;
                filtro += ", Año: " + _gAno.Item.desc;
                rp.Imprimir(_lista, filtro);
            }
        }
    }

}