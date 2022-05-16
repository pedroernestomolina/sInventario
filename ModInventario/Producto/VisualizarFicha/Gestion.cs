using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.VisualizarFicha
{
    
    public class Gestion
    {

        private string _autoPrd;
        private OOB.LibInventario.Producto.Data.Identificacion _producto;
        private List<OOB.LibInventario.Producto.Data.CodAlterno> _lCodAlterno;
        private BindingSource _bsCodAlterno;


        public String CodigoPrd { get { return _producto.codigo; } }
        public string DescripcionPrd { get { return _producto.descripcion; } }
        public string NombrePrd { get { return _producto.nombre; } }
        public string DepartamentoPrd { get { return _producto.departamento; } }
        public string GrupoPrd { get { return _producto.grupo; } }
        public string MarcaPrd { get { return _producto.marca; } }
        public string ImpuestoPrd { get { return _producto.Impuesto; } }
        public string OrigenPrd { get { return _producto.origen.ToString(); } }
        public string CategoriaPrd { get { return _producto.categoriaDesc; } }
        public string ClasificacionPrd { get { return _producto.tipoABC; } }
        public string AdmDivisaPrd { get { return _producto.AdmPorDivisa.ToString(); } }
        public string EmpaquePrd { get { return _producto.empaqueCompra.ToString(); } }
        public string ContenidoPrd { get { return _producto.contenidoCompra.ToString(); } }
        public string ModeloPrd { get { return _producto.modelo.ToString(); } }
        public string ReferenciaPrd { get { return _producto.referencia.ToString(); } }
        public bool IsCatalagoPrd { get { return _producto.activarCatalogo == OOB.LibInventario.Producto.Enumerados.EnumCatalogo.Si ? true : false; } }
        public bool IsPesadoPrd { get { return _producto.IsPesado; } }
        public string PluPrd { get { return _producto.plu; } }
        public int DiasEmpaquePrd { get { return _producto.diasEmpaque; } }
        public BindingSource SourceCodAlterno { get { return _bsCodAlterno; } }
        public bool IsInactivo { get { return _producto.IsInactivo; } }
        public string EmpaqueInv { get { return _producto.empInv; } }
        public int ContEmpInv { get { return _producto.contEmpInv; } }


        public Gestion()
        {
            _lCodAlterno = new List<OOB.LibInventario.Producto.Data.CodAlterno>();
            _bsCodAlterno = new BindingSource();
            _bsCodAlterno.DataSource = _lCodAlterno;
        }


        public void setFicha(string auto)
        {
            _autoPrd = auto;
        }

        VisualizarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new VisualizarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }

        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Producto_GetIdentificacion(_autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _producto = r01.Entidad;
            _lCodAlterno.Clear();
            foreach (var it in _producto.codAlterno) 
            {
                _lCodAlterno.Add(it);
            }
            _bsCodAlterno.CurrencyManager.Refresh();

            return true;
        }

        public void Inicializa()
        {
        }

    }

}