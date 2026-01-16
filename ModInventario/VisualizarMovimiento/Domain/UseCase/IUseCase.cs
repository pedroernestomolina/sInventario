using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.VisualizarMovimiento.Domain.UseCase
{
    public interface IUseCase
    {
        Model.Entidad.Ficha 
            CargarDocumentoVisualizar(string idDoc);
    }
}