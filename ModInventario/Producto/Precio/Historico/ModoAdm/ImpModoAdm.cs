using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Historico.ModoAdm
{
    public class ImpModoAdm: IHistorico
    {
        private string _autoPrd;
        private List<dataHist> _lst;
        private BindingSource _bs;
        private string _prdDesc;
        private string _prdCodigo;


        public ImpModoAdm()
        {
            _autoPrd = "";
            _lst = new List<dataHist>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _prdDesc = "";
            _prdCodigo = "";
        }


        public void setFicha(string idPrd)
        {
            _autoPrd = idPrd;
        }

        public void Inicializa()
        {
            _lst.Clear();
            _bs.CurrencyManager.Refresh();
            _bs.DataSource = _lst;
            _prdDesc = "";
            _prdCodigo = "";
        }
        ModoSucursal.HistoricoPrecioFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new ModoSucursal.HistoricoPrecioFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            try
            {
                var filtro = new OOB.LibInventario.Producto.HistoricoPrecio.Filtro()
                {
                    autoPrd = _autoPrd,
                };
                var r01 = Sistema.MyData.Producto_ModoAdm_HistoricoPrecio_By(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                _prdDesc = r01.Entidad.prdDescripcion;
                _prdCodigo = r01.Entidad.prdCodigo;
                foreach (var it in r01.Entidad.data.OrderByDescending(o => o.fecha).ThenByDescending(o => o.hora).ToList())
                {
                    var idP = "";
                    idP = "PRECIO(" + it.tipoPrecioVta + ")/EMP(" + it.tipoEmpVta + ")";
                    var nr = new dataHist()
                    {
                        factorCambio = it.factorCambio,
                        fechaHora = it.fecha.ToShortDateString() + "/ " + it.hora,
                        nota = it.nota,
                        precioLocalNeto = it.netoMonLocal,
                        usuarioEstacion = it.usuNombre + "/ " + it.estacion,
                        empContenido = it.empDescripcion + "/ " + it.empCont.ToString(),
                        idPrecio = idP,
                    };
                    _lst.Add(nr);
                }
                _bs.CurrencyManager.Refresh();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        public void Imprimir()
        {
            ImprimirLista();
        }
        private void ImprimirLista()
        {
            if (_lst.Count > 0)
            {
                var rp = new Reportes.HistoricoPrecio.gestionRep();
                rp.setLista(_lst);
                rp.setFiltros(_prdDesc.Trim() + "(" + _prdCodigo.Trim() + ")");
                rp.Generar();
            }
        }

        public BindingSource GetDataSource { get { return _bs; } }
        public string GetProducto_Desc { get { return _prdCodigo + Environment.NewLine + _prdDesc; } }
        public string GetNota { get { return _bs.Current != null ? ((dataHist)_bs.Current).nota : ""; } }
    }
}