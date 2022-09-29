using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.Visualizar.ModoBasico
{
    
    public class Gestion: ModInventario.Producto.VisualizarFicha.IVisualizar
    {

        private string _autoPrd;
        private OOB.LibInventario.Producto.Data.Identificacion _producto;
        private List<OOB.LibInventario.Producto.Data.CodAlterno> _lCodAlterno;
        private BindingSource _bsCodAlterno;


        public String GetCodigoPrd { get { return _producto.codigo; } }
        public string GetDescripcionPrd { get { return _producto.descripcion; } }
        public string GetNombrePrd { get { return _producto.nombre; } }
        public string GetDepartamentoPrd { get { return _producto.departamento; } }
        public string GetGrupoPrd { get { return _producto.grupo; } }
        public string GetMarcaPrd { get { return _producto.marca; } }
        public string GetImpuestoPrd { get { return _producto.Impuesto; } }
        public string GetOrigenPrd { get { return _producto.origen.ToString(); } }
        public string GetCategoriaPrd { get { return _producto.categoriaDesc; } }
        public string GetClasificacionPrd { get { return _producto.tipoABC; } }
        public string GetAdmDivisaPrd { get { return _producto.AdmPorDivisa.ToString(); } }
        public string GetEmpaquePrd { get { return _producto.empaqueCompra.ToString(); } }
        public string GetContenidoPrd { get { return _producto.contenidoCompra.ToString(); } }
        public string GetModeloPrd { get { return _producto.modelo.ToString(); } }
        public string GetReferenciaPrd { get { return _producto.referencia.ToString(); } }
        public bool GetIsCatalagoPrd { get { return _producto.activarCatalogo == OOB.LibInventario.Producto.Enumerados.EnumCatalogo.Si ? true : false; } }
        public bool GetIsPesadoPrd { get { return _producto.IsPesado; } }
        public string GetPluPrd { get { return _producto.plu; } }
        public int GetDiasEmpaquePrd { get { return _producto.diasEmpaque; } }
        public BindingSource GetCodAlterno_Source { get { return _bsCodAlterno; } }
        public bool GetIsInactivo { get { return _producto.IsInactivo; } }
        public string GetEmpaqueInv { get { return _producto.empInv; } }
        public int GetContEmpInv { get { return _producto.contEmpInv; } }


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
            _lCodAlterno .Clear();
            _bsCodAlterno.DataSource = _lCodAlterno;
            _bsCodAlterno.CurrencyManager.Refresh();
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }

    }

}