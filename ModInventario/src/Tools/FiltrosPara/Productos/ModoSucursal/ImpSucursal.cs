using ModInventario.FiltrosGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Tools.FiltrosPara.Productos.ModoSucursal
{

    public class ImpSucursal: basePrd, ISucursal
    {
        public ImpSucursal()
        {
            _depart= new Filtros.Departamento.ImpDepartamento();
            _marca =  new Filtros.Marca.ImpMarca();
            _origen = new Filtros.Origen.ImpOrigen();
            _tasaIva = new Filtros.TasaIva.ImpTasaIva();
            _estatus = new Filtros.Estatus.ImpEstatus();
            _divisa = new Filtros.Divisa.ImpDivisa();
            _pesado = new Filtros.Pesado.ImpPesado();
            _deposito = new Filtros.Deposito.ImpDeposito();
            _catalogo = new Filtros.Catalogo.ImpCatalogo();
            _categoria = new Filtros.Categoria.ImpCategoria();
            _existencia = new Filtros.Existencia.ImpExistencia();
            _tcs = new Filtros.TCS.ImpTCS();
            _proveedor = new Filtros.Proveedor.ImpProveedor();
        }


        Frm frm;
        override public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        override protected bool CargarData() 
        {
            return base.CargarData();
        }
    }
}