﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IVisor
    {

        OOB.ResultadoLista<OOB.LibInventario.Visor.Existencia.Ficha> Visor_Existencia(OOB.LibInventario.Visor.Existencia.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibInventario.Visor.CostoEdad.Ficha> Visor_CostoEdad(OOB.LibInventario.Visor.CostoEdad.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Visor.Traslado.Ficha> Visor_Traslado(OOB.LibInventario.Visor.Traslado.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibInventario.Visor.Ajuste.Ficha> Visor_Ajuste(OOB.LibInventario.Visor.Ajuste.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Visor.CostoExistencia.Ficha> Visor_CostoExistencia(OOB.LibInventario.Visor.CostoExistencia.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Visor.Precio.Ficha> Visor_Precio(OOB.LibInventario.Visor.Precio.Filtro filtro);

    }

}