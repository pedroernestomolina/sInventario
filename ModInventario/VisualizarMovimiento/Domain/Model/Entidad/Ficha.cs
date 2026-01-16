using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.VisualizarMovimiento.Domain.Model.Entidad
{
    public class Ficha
    {
        public Encabezado encabezado { get; set; }
        public List<Detalle> detalles { get; set; }
    }
}