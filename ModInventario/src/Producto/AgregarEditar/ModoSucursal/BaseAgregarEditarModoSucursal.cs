using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal
{

    abstract public class BaseAgregarEditarModoSucursal: BaseAgregarEditar, IAgregarEditar
    {


        protected FiltrosGen.IOpcion _empInv;
        protected MaestrosInv.Departamento.IAgregarEditar _agregarDepartamento;
        protected MaestrosInv.Grupo.IAgregarEditar _agregarGrupo;
        protected MaestrosInv.Marca.IAgregarEditar _agregarMarca;
        protected SeguridadSist.ISeguridad _seguridad;
        new protected baseDataAgregarEditarModoSucursal _data;


        public BaseAgregarEditarModoSucursal(baseDataAgregarEditarModoSucursal data, SeguridadSist.ISeguridad seguridad)
            :base(data)
        {
            _data = data;
            _seguridad = seguridad;
        }


        abstract public string GetTitulo { get; }
        public BindingSource GetEmpInv_Source { get { return _empInv.Source; } }
        public string GetEmpInv_Id { get { return _empInv.GetId; } }
        public string GetModeloProducto { get { return _data.GetModeloProducto; } }
        public string GetReferenciaProducto { get { return _data.GetReferenciaProducto; } }
        public int GetContEmpInv { get { return _data.GetContEmpInv; } }
        public decimal GetPeso { get { return _data.GetPeso; } }
        public decimal GetVolumen { get { return _data.GetVolumen; } }
        public decimal GetLargo { get { return _data.GetLargo; } }
        public decimal GetAlto { get { return _data.GetAlto; } }
        public decimal GetAncho { get { return _data.GetAncho; } }
        public bool GetActivarCatlogo { get { return _data.GetActivarCatlogo;} }
        public byte[] GetImagen { get { return _data.GetImagen; } }


        public void setEmpInv(string id)
        {
            _empInv.setFicha(id);
            _data.setEmpInv(_empInv.Item);
        }
        public void setContEmpInv(int v)
        {
            _data.setContEmpInv(v);
        }
        public void setModeloProducto(string d)
        {
            _data.setModeloProducto(d);
        }
        public void setReferenciaProducto(string d)
        {
            _data.setReferenciaProducto(d);
        }
        public void setPeso(decimal v)
        {
            _data.setPeso(v);
        }
        public void setVolumen(decimal v)
        {
            _data.setVolumen(v);
        }
        public void setAlto(decimal v)
        {
            _data.setAlto(v);
        }
        public void setLargo(decimal v)
        {
            _data.setLargo(v);
        }
        public void setAncho(decimal v)
        {
            _data.setAncho(v);
        }
        public void setImagen(Image img)
        {
            _data.setImagen(img);
        }
        public void setActivarCatlogo(bool b)
        {
            _data.setActivarCatlogo(b);
        }


        private bool _buscarImagenIsOK;
        private Agregar.dataAgregar dataAgregar;
        private Helpers.Seguridad seguridad;
        private SeguridadSist.ISeguridad seguridad1;
        public bool BuscarImagenIsOk { get { return _buscarImagenIsOK; } }
        public void BuscarImagen()
        {
            _data.setImagen(null);
            _buscarImagenIsOK = false;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPG|*.jpg|PNG|*.png|Bitmap|*.bmp", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _data.setImagen(Image.FromFile(ofd.FileName));
                        _buscarImagenIsOK = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "*** ERROR ***", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        abstract public bool HabilitarEditarCodigo { get; }
        abstract public override bool IsAgregarEditarOk { get; }
        abstract public override string AutoProductoAgregado { get; }
        abstract public override void Inicializa();
        abstract public override void Inicia();
        abstract public override void AbandonarFicha();
        abstract public override void ProcesarFicha();


        public bool AgregarDepartamentoIsOK { get { return _agregarDepartamento.IsOk; } }
        public void AgregarDepartamento()
        {
            _agregarDepartamento.Inicializa();
            _agregarDepartamento.Inicia();
            if (_agregarDepartamento.IsOk)
            {
                cargarListaDepartamentos();
            }
        }
        private void cargarListaDepartamentos()
        {
            try
            {
                var lst = new List<ficha>();
                var r01 = Sistema.MyData.Departamento_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _departamento.setData(lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        public bool AgregarGrupoIsOk { get { return _agregarGrupo.IsOk; } }
        public void AgregarGrupo()
        {
            _agregarGrupo.Inicializa();
            _agregarGrupo.Inicia();
            if (_agregarGrupo.IsOk)
            {
                cargarListaGrupos();
            }
        }
        private void cargarListaGrupos()
        {
            try
            {
                var lst = new List<ficha>();
                var r01 = Sistema.MyData.Grupo_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _grupo.setData(lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        public bool AgregarMarcaIsOk { get { return _agregarMarca.IsOk; } }        
        public void AgregarMarca()
        {
            _agregarMarca.Inicializa();
            _agregarMarca.Inicia();
            if (_agregarMarca.IsOk)
            {
                cargarListaMarcas();
            }
        }
        private void cargarListaMarcas()
        {
            try
            {
                var lst = new List<ficha>();
                var r01 = Sistema.MyData.Marca_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, "", rg.nombre));
                }
                _marca.setData(lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        public bool EditarCodigoIsOk { get { return _seguridad.IsOk; } }
        public void EditarCodigo()
        {
            VerificarUsuario();
        }
        private void VerificarUsuario()
        {
            _seguridad.Inicializa();
            _seguridad.Inicia();
        }

    }

}