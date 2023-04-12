using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.ActualizarOfertaMasiva.Precio
{
    public class ImpPrecio: IPrecio
    {
        private FiltrosGen.IOpcion _op;


        public BindingSource GetSource { get { return _op.Source; } }
        public string GetId { get { return _op.GetId; } }


        public ImpPrecio()
        {
            _op = new FiltrosGen.Opcion.Gestion();
        }


        public void setId(string id)
        {
            _op.setFicha(id);
        }


        public void Inicializa()
        {
            _op.Inicializa();
        }
        public void CargarData()
        {
            var _lst = new List<ficha>();
            _lst.Add(new ficha("01", "", "Precio 1"));
            _lst.Add(new ficha("02", "", "Precio 2"));
            _lst.Add(new ficha("03", "", "Precio 3"));
            _op.setData(_lst);
        }
    }
}
