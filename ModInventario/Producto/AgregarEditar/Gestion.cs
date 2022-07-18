using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.AgregarEditar
{


    public class Gestion
    {

        private IGestion miGestion;
        private Helpers.Maestros.ICallMaestros _callMaestros;


        public string Titulo { get { return miGestion.Titulo; } }
        public bool IsAgregarEditarOk { get { return miGestion.IsAgregarEditarOk; } }
        public string AutoProductoAgregado { get { return miGestion.AutoProductoAgregado; } }

        public bool IsCerrarHabilitado { get { return miGestion.IsCerrarHabilitado; } }
        public BindingSource Departamentos { get { return miGestion.Departamentos; } }
        public BindingSource Grupos { get { return miGestion.Grupos; } }
        public BindingSource Marcas { get { return miGestion.Marcas; } }
        public BindingSource Impuesto { get { return miGestion.Impuesto; } }
        public BindingSource Origen { get { return miGestion.Origen; } }
        public BindingSource Divisa { get { return miGestion.Divisa; } }
        public BindingSource Categoria { get { return miGestion.Categoria; } }
        public BindingSource Clasificacion { get { return miGestion.Clasificacion; } }
        public BindingSource SourceCodAlterno { get { return miGestion.SourceCodAlterno; } }


        public string CodigoProducto { get { return miGestion.CodigoProducto; } set { miGestion.CodigoProducto = value; } }
        public string DescripcionProducto { get { return miGestion.DescripcionProducto; } set { miGestion.DescripcionProducto = value; } }
        public string NombreProducto { get { return miGestion.NombreProducto; } set { miGestion.NombreProducto = value; } }
        public string ModeloProducto { get { return miGestion.ModeloProducto; } set { miGestion.ModeloProducto = value; } }
        public string ReferenciaProducto { get { return miGestion.ReferenciaProducto; } set { miGestion.ReferenciaProducto = value; } }
        public byte[] Imagen { get { return miGestion.Imagen; } set { miGestion.Imagen = value; } }
        public bool Pesado { get { return miGestion.Pesado; } set { miGestion.Pesado = value; } }
        public bool ActivarCatlogo { get { return miGestion.ActivarCatlogo; } set { miGestion.ActivarCatlogo = value; } }
        public string Plu { get { return miGestion.Plu; } set { miGestion.Plu = value; } } 
        public int DiasEmpaque { get { return miGestion.DiasEmpaque; } set { miGestion.DiasEmpaque = value; } } 

        public string AutoDepartamento { get { return miGestion.AutoDepartamento; } set { miGestion.AutoDepartamento = value; } }
        public string AutoGrupo { get { return miGestion.AutoGrupo; } set { miGestion.AutoGrupo = value; } }
        public string AutoMarca { get { return miGestion.AutoMarca; } set { miGestion.AutoMarca = value; } } 
        public string AutoImpuesto { get { return miGestion.AutoImpuesto; } set { miGestion.AutoImpuesto= value; } }
        public string IdOrigen { get { return miGestion.IdOrigen; } set { miGestion.IdOrigen = value; } }
        public string IdCategoria { get { return miGestion.IdCategoria; } set { miGestion.IdCategoria = value; } }
        public string IdClasificacionAbc { get { return miGestion.IdClasificacionAbc; } set { miGestion.IdClasificacionAbc = value; } }
        public string IdDivisa { get { return miGestion.IdDivisa; } set { miGestion.IdDivisa = value; } }
        public string CodigoAlterno { get { return miGestion.CodigoAlterno; } set { miGestion.CodigoAlterno = value; } }


        public Gestion(
            IGestion gestion, 
            Helpers.Maestros.ICallMaestros ctrMaestros)
        {
            miGestion = gestion;
            _callMaestros = ctrMaestros;
        }


        public void setFicha(string autoPrd)
        {
            miGestion.SetFicha(autoPrd);
        }

        AgregarEditarFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }

        }

        private void Limpiar()
        {
            miGestion.Limpiar();
        }

        private bool CargarData()
        {
            return miGestion.CargarData();
        }

        public void Procesar()
        {
            miGestion.Procesar();
        }

        public void InicializarIsCerrarHabilitado()
        {
            miGestion.InicializarIsCerrarHabilitado();
        }

        public void MaestroDepartamento()
        {
            _callMaestros.MtDepartamento();
            miGestion.CargaDepartamentos();
        }

        public void MaestroGrupo()
        {
            _callMaestros.MtGrupo();
            miGestion.CargaGrupos();
        }

        public void MaestroMarca()
        {
            _callMaestros.MtMarca();
            miGestion.CargaMarcas();
        }

        public void ListaPlu()
        {
            miGestion.ListaPlu();
        }

        public bool AbandonarDocumento()
        {
            var msg = MessageBox.Show("Desechar Cambios Efectuados ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return (msg == DialogResult.Yes);
        }


        public void AgregarCodigoAlterno()
        {
            miGestion.AgregarCodigoAlterno();
        }

        public void EliminarCodigoAlterno()
        {
            miGestion.EliminarCodigoAlterno(); 
        }


        public void Inicializa()
        {
            miGestion.Inicializa();
        }


        public BindingSource GetEmpCompraSource { get { return miGestion.GetEmpCompraSource; } }
        public string GetEmpCompraId { get { return miGestion.GetEmpCompraId; } }
        public BindingSource GetEmpInvSource { get { return miGestion.GetEmpInvSource; } }
        public string GetEmpInvId { get { return miGestion.GetEmpInvId; } }
        public int GetContEmpCompra { get { return miGestion.GetContEmpCompra; } }
        public int GetContEmpInv { get { return miGestion.GetContEmpInv; } }
        public void setEmpCompra(string id)
        {
            miGestion.setEmpCompra(id);
        }
        public void setEmpInv(string id)
        {
            miGestion.setEmpInv(id);
        }
        public void setContEmpCompra(int cont)
        {
            miGestion.setContEmpCompra(cont);
        }
        public void setContEmpInv(int cont)
        {
            miGestion.setContEmpInv(cont);
        }


        public bool AbandonarIsOk { get { return miGestion.AbandonarIsOk; } }
        public bool ProcesarIsOk { get { return miGestion.ProcesarIsOk; } }
        public void AbandonarFicha()
        {
            miGestion.AbandonarFicha();
        }

        public bool HabilitarEditarCodigo { get { return miGestion.HabilitarEditarCodigo; } }


        public bool EditarCodigoIsOk { get { return miGestion.EditarCodigoIsOk; } }
        public void EditarCodigo()
        {
            miGestion.EditarCodigo();
        }


        public decimal GetPeso { get { return miGestion.GetPeso; } }
        public void setPeso(decimal _peso)
        {
            miGestion.setPeso(_peso);
        }
        public decimal GetVolumen { get { return miGestion.GetVolumen; } }
        public void setVolumen(decimal _volumen)
        {
            miGestion.setVolumen(_volumen);
        }

    }

}