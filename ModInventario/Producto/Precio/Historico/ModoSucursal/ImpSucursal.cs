using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Historico.ModoSucursal
{
    
    public class ImpSucursal: ISucursal
    {

        private string _autoPrd;
        private List<dataHist> _lst;
        private BindingSource _bs;
        private string _prdDesc;
        private string _prdCodigo;


        public ImpSucursal()
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
        HistoricoPrecioFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new HistoricoPrecioFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.LibInventario.Precio.Historico.Filtro()
            {
                autoProducto = _autoPrd,
            };
            var r01 = Sistema.MyData.HistoricoPrecio_GetLista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _prdDesc = r01.Entidad.descripcion;
            _prdCodigo = r01.Entidad.codigo;
            foreach (var it in r01.Entidad.data.OrderByDescending(o => o.fecha).ThenByDescending(o => o.hora).ToList()) 
            {
                var idP = "";
                switch(it.idPrecio.Trim().ToUpper())
                {
                    case "1":
                        idP = "PRECIO(1)/EMP(1)";
                        break;
                    case "2":
                        idP = "PRECIO(1)/EMP(2)";
                        break;
                    case "3":
                        idP = "PRECIO(1)/EMP(3)";
                        break;
                    case "4":
                        idP = "PRECIO(1)/EMP(4)";
                        break;
                    case "PTO":
                        idP = "PRECIO(1)/EMP(5)";
                        break;
                    case "MY1":
                        idP = "PRECIO(2)/EMP(1)";
                        break;
                    case "MY2":
                        idP = "PRECIO(2)/EMP(2)";
                        break;
                    case "MY3":
                        idP = "PRECIO(2)/EMP(3)";
                        break;
                    case "MY4":
                        idP = "PRECIO(2)/EMP(4)";
                        break;
                    case "DS1":
                        idP = "PRECIO(3)/EMP(1)";
                        break;
                    case "DS2":
                        idP = "PRECIO(3)/EMP(2)";
                        break;
                    case "DS3":
                        idP = "PRECIO(3)/EMP(3)";
                        break;
                    case "DS4":
                        idP = "PRECIO(3)/EMP(4)";
                        break;
                }
                var nr = new dataHist()
                {
                    factorCambio = it.factorCambio,
                    fechaHora = it.fecha.ToShortDateString() + "/ " + it.hora,
                    nota = it.nota,
                    precioLocalNeto = it.precio,
                    usuarioEstacion = it.usuario + "/ " + it.estacion,
                    empContenido = it.empaque + "/ " + it.contenido.ToString(),
                    idPrecio = idP,
                };
                _lst.Add(nr);
            }
            _bs.CurrencyManager.Refresh();

            return rt;
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