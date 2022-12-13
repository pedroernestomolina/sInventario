using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Visor.Precios.ModoSoloReporte
{

    public class ImpVisor : ISoloReporte
    {

        private string _precioManejar;
        private List<data> _lst;
        private BindingSource _bs;
        private FiltrosGen.IOpcion _gDesde;
        private bool _excluirCambiosMasivo;


        public BindingSource GetSource { get { return _bs; } }
        public BindingSource GetDesde_Source { get { return _gDesde.Source; } }
        public string GetDesde_Id { get { return _gDesde.GetId; } }
        public int GetCntItems { get { return _bs.Count; } }
        public bool GetExcluirCambioMasivo { get { return _excluirCambiosMasivo; } }


        public ImpVisor()
        {
            _mostrarPrecio = mostrarPrecio.Ambos;
            _excluirCambiosMasivo = true;
            _precioManejar = "";
            _lst = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
            _gDesde = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _mostrarPrecio = mostrarPrecio.Ambos;
            _excluirCambiosMasivo = true;
            _precioManejar = "";
            _lst.Clear();
            _gDesde.Inicializa();
            _bs.CurrencyManager.Refresh();
        }
        VisorFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new VisorFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void Buscar()
        {
            ActivarBusqueda();
        }
        public void setDesde(string id)
        {
            _gDesde.setFicha(id);
        }
        public void ExcluirCambiosMasivo(bool excluirCambMasivo)
        {
            _excluirCambiosMasivo = excluirCambMasivo;
        }


        public bool AbandonarIsOk { get { return true; } }
        public void AbandonarFicha()
        {
        }


        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Empresa_Sucursal_TipoPrecioManejar(Sistema.Negocio.CodigoEmpresa);
                _precioManejar = r01.Entidad;
                var _lst = new List<ficha>();
                _lst.Add(new ficha("1", "", "0 Día"));
                _lst.Add(new ficha("2", "", "1 Día"));
                _lst.Add(new ficha("3", "", "3 Días"));
                _lst.Add(new ficha("4", "", "5 Días"));
                _lst.Add(new ficha("5", "", "7 Días"));
                _gDesde.setData(_lst);
                _gDesde.setFicha("1");
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void ActivarBusqueda()
        {
            if (_gDesde.GetId == "") { return; }

            _lst.Clear();
            var _cnt = 0;
            switch (_gDesde.GetId)
            {
                case "1":
                    _cnt = 0;
                    break;
                case "2":
                    _cnt = 1;
                    break;
                case "3":
                    _cnt = 3;
                    break;
                case "4":
                    _cnt = 5;
                    break;
                case "5":
                    _cnt = 7;
                    break;
            }
            try
            {
                var filtroOOB = new OOB.LibInventario.Visor.Precio.SoloReporte.Filtro()
                {
                    autoDeposito = Sistema.Negocio.CodigoDepositoPrincipal,
                    desdeCntDias = _cnt,
                    excluirCambiosMasivo=_excluirCambiosMasivo,
                };
                var r01 = Sistema.MyData.Visor_Precio_Modo_SoloReporte(filtroOOB);
                var _p1 = "";
                var _p2 = "";
                var _p3 = "";
                var _empq1 = "";
                var _empq2 = "";
                var _empq3 = "";
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _p1 = "";
                    _p2 = "";
                    _p3 = "";
                    _empq1 = "";
                    _empq2 = "";
                    _empq3 = "";
                    switch (_precioManejar)
                    {
                        case "1":
                            if (rg.p1 > 0m)
                            {
                                _empq1 = rg.emp_1 + "(" + rg.cont_emp_1.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                { 
                                    case mostrarPrecio.Ambos:
                                        _p1 = "Bs: " + full(rg.p1, rg.tasa).ToString("n2") + "/ $: " + rg.p1_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p1 = "$: " + rg.p1_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p1 = "Bs: " + full(rg.p1, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p1 = "Bs: " + full(rg.p1, rg.tasa).ToString("n2") + "/ $: " + rg.p1_FD.ToString("n2");
                            }
                            if (rg.pM1 > 0m)
                            {
                                _empq2 = rg.emp_2 + "(" + rg.cont_emp_2.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p2 = "Bs: " + full(rg.pM1, rg.tasa).ToString("n2") + "/ $: " + rg.pM1_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p2 = "$: " + rg.pM1_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p2 = "Bs: " + full(rg.pM1, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p2 = "Bs: " + full(rg.pM1, rg.tasa).ToString("n2") + "/ $: " + rg.pM1_FD.ToString("n2");
                            }
                            if (rg.pDSP1 > 0m)
                            {
                                _empq3 = rg.emp_3 + "(" + rg.cont_emp_3.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p3 = "Bs: " + full(rg.pDSP1, rg.tasa).ToString("n2") + "/ $: " + rg.pDSP1_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p3 = "$: " + rg.pDSP1_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p3 = "Bs: " + full(rg.pDSP1, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p3 = "Bs: " + full(rg.pDSP1, rg.tasa).ToString("n2") + "/ $: " + rg.pDSP1_FD.ToString("n2");
                            }
                            break;
                        case "2":
                            if (rg.p2 > 0m)
                            {
                                _empq1 = rg.emp_1 + "(" + rg.cont_emp_1.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p1 = "Bs: " + full(rg.p2, rg.tasa).ToString("n2") + "/ $: " + rg.p2_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p1 = "$: " + rg.p2_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p1 = "Bs: " + full(rg.p2, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p1 = "Bs: " + full(rg.p2, rg.tasa).ToString("n2") + "/ $: " + rg.p2_FD.ToString("n2");
                            }
                            if (rg.pM2 > 0m)
                            {
                                _empq2 = rg.emp_2 + "(" + rg.cont_emp_2.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p2 = "Bs: " + full(rg.pM2, rg.tasa).ToString("n2") + "/ $: " + rg.pM2_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p2 = "$: " + rg.pM2_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p2 = "Bs: " + full(rg.pM2, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p2 = "Bs: " + full(rg.pM2, rg.tasa).ToString("n2") + "/ $: " + rg.pM2_FD.ToString("n2");
                            }
                            if (rg.pDSP2 > 0m)
                            {
                                _empq3 = rg.emp_3 + "(" + rg.cont_emp_3.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p3 = "Bs: " + full(rg.pDSP2, rg.tasa).ToString("n2") + "/ $: " + rg.pDSP2_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p3 = "$: " + rg.pDSP2_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p3 = "Bs: " + full(rg.pDSP2, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p3 = "Bs: " + full(rg.pDSP2, rg.tasa).ToString("n2") + "/ $: " + rg.pDSP2_FD.ToString("n2");
                            }
                            break;
                        case "3":
                            if (rg.p3 > 0m)
                            {
                                _empq1 = rg.emp_1 + "(" + rg.cont_emp_1.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p1 = "Bs: " + full(rg.p3, rg.tasa).ToString("n2") + "/ $: " + rg.p3_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p1 = "$: " + rg.p3_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p1 = "Bs: " + full(rg.p3, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p1 = "Bs: " + full(rg.p3, rg.tasa).ToString("n2") + "/ $: " + rg.p3_FD.ToString("n2");
                            }
                            if (rg.pM3 > 0m)
                            {
                                _empq2 = rg.emp_2 + "(" + rg.cont_emp_2.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p2 = "Bs: " + full(rg.pM3, rg.tasa).ToString("n2") + "/ $: " + rg.pM3_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p2 = "$: " + rg.pM3_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p2 = "Bs: " + full(rg.pM3, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p2 = "Bs: " + full(rg.pM3, rg.tasa).ToString("n2") + "/ $: " + rg.pM3_FD.ToString("n2");
                            }
                            if (rg.pDSP3 > 0m)
                            {
                                _empq3 = rg.emp_3 + "(" + rg.cont_emp_3.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p3 = "Bs: " + full(rg.pDSP3, rg.tasa).ToString("n2") + "/ $: " + rg.pDSP3_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p3 = "$: " + rg.pDSP3_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p3 = "Bs: " + full(rg.pDSP3, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p3 = "Bs: " + full(rg.pDSP3, rg.tasa).ToString("n2") + "/ $: " + rg.pDSP3_FD.ToString("n2");
                            }
                            break;
                        case "4":
                            if (rg.p4 > 0m)
                            {
                                _empq1 = rg.emp_1 + "(" + rg.cont_emp_1.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p1 = "Bs: " + full(rg.p4, rg.tasa).ToString("n2") + "/ $: " + rg.p4_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p1 = "$: " + rg.p4_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p1 = "Bs: " + full(rg.p4, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p1 = "Bs: " + full(rg.p4, rg.tasa).ToString("n2") + "/ $: " + rg.p4_FD.ToString("n2");
                            }
                            if (rg.pM4 > 0m)
                            {
                                _empq2 = rg.emp_2 + "(" + rg.cont_emp_2.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p2 = "Bs: " + full(rg.pM4, rg.tasa).ToString("n2") + "/ $: " + rg.pM4_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p2 = "$: " + rg.pM4_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p2 = "Bs: " + full(rg.pM4, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p2 = "Bs: " + full(rg.pM4, rg.tasa).ToString("n2") + "/ $: " + rg.pM4_FD.ToString("n2");
                            }
                            if (rg.pDSP4 > 0m)
                            {
                                _empq3 = rg.emp_3 + "(" + rg.cont_emp_3.ToString().Trim() + ")";
                                switch (_mostrarPrecio)
                                {
                                    case mostrarPrecio.Ambos:
                                        _p3 = "Bs: " + full(rg.pDSP4, rg.tasa).ToString("n2") + "/ $: " + rg.pDSP4_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.soloDivisa:
                                        _p3 = "$: " + rg.pDSP4_FD.ToString("n2");
                                        break;
                                    case mostrarPrecio.SoloBs:
                                        _p3 = "Bs: " + full(rg.pDSP4, rg.tasa).ToString("n2");
                                        break;
                                }
                                //_p3 = "Bs: " + full(rg.pDSP4, rg.tasa).ToString("n2") + "/ $: " + rg.pDSP4_FD.ToString("n2");
                            }
                            break;
                    }
                    var nr = new data()
                    {
                        codigo = rg.codigo,
                        nombre = rg.nombre,
                        tasa = rg.tasa == 0m ? "Ex" : rg.tasa.ToString("n2") + "%",
                        empq1 = _empq1,
                        p1 = _p1,
                        empq2 = _empq2,
                        p2 = _p2,
                        empq3 = _empq3,
                        p3 = _p3,
                    };
                    if (_p1 == "" && _p2 == "" && _p3 == "")
                    {
                        continue;
                    }
                    _lst.Add(nr);
                }
                _bs.CurrencyManager.Refresh();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private enum mostrarPrecio { soloDivisa, SoloBs, Ambos };
        private mostrarPrecio _mostrarPrecio;
        public void MostrarPrecioSoloDivisa()
        {
            _mostrarPrecio = mostrarPrecio.soloDivisa;
        }
        public void MostrarPrecioSoloBs()
        {
            _mostrarPrecio = mostrarPrecio.SoloBs;
        }
        public void MostrarPrecioAmbos()
        {
            _mostrarPrecio = mostrarPrecio.Ambos;
        }


        private decimal full(decimal neto, decimal tasa)
        {
            var r = neto;
            if (tasa > 0m)
            {
                r = r + (r * tasa / 100);
            }
            return r;
        }

        public int GetMostrarPrecio
        {
            get
            {
                var rt = -1;
                switch (_mostrarPrecio)
                { 
                    case mostrarPrecio.soloDivisa:
                        rt=1;
                        break;
                    case mostrarPrecio.SoloBs:
                        rt = 2;
                        break;
                    case mostrarPrecio.Ambos:
                        rt = 3;
                        break;
                }
                return rt;
            }
        }
    }

}