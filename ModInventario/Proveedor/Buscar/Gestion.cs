using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Proveedor.Buscar
{
    public class Gestion
    {
        private Lista.Gestion _gestionLista;


        public string CadenaBusqueda { get; set; }
        public OOB.LibInventario.Proveedor.Enumerados.EnumMetodoBusqueda metodoBusqueda;
        public OOB.LibInventario.Proveedor.Lista.Filtro filtro;
        public BindingSource Source { get { return _gestionLista.Source; } }
        public string Items { get { return _gestionLista.Items; } }
        public Lista.data ItemSeleccionado { get { return _gestionLista.ItemSeleccionado; } }


        public Gestion()
        {
            _gestionLista = new Lista.Gestion();
            CadenaBusqueda = "";
            metodoBusqueda = OOB.LibInventario.Proveedor.Enumerados.EnumMetodoBusqueda.Nombre;
            filtro = new OOB.LibInventario.Proveedor.Lista.Filtro();
        }


        BuscarFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new BuscarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            return rt;
        }

        public void Limpiar()
        {
            CadenaBusqueda = "";
            _gestionLista.Limpiar();
        }

        public void Buscar()
        {
            filtro.Limpiar();
            filtro.cadena = this.CadenaBusqueda;
            filtro.MetodoBusqueda = this.metodoBusqueda;

            var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionLista.setLista(r01.Lista);
        }

        public void SeleccionarItem()
        {
            _gestionLista.SeleccionarItem();
        }
    }
}