using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{
    public partial class DataProv: IData
    {
        public OOB.ResultadoEntidad<OOB.LibInventario.TallaColorSabor.Existencia.Ficha> 
            TallaColorSabor_ExDep(OOB.LibInventario.TallaColorSabor.Existencia.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.TallaColorSabor.Existencia.Ficha>();
            var filtroDTO = new DtoLibInventario.TallaColorSabor.Existencia.Filtro()
            {
                autoDep = filtro.autoDep,
                autoPrd = filtro.autoPrd,
            };
            var r01 = MyData.TallaColorSabor_ExDep(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.LibInventario.TallaColorSabor.Existencia.ExDepTCS>();
            var _prdId = "";
            var _prdNombre = "";
            var _prdEstatusTCS = "";
            if (r01.Entidad != null && r01.Entidad.ExDep != null && r01.Entidad.ExDep.Count > 0)
            {
                var r1 = r01.Entidad.ExDep;
                _lst = r1.Select(s =>
                {
                    if (_prdId == "") 
                    {
                        _prdId = s.idPrd;
                        _prdNombre = s.NombrePrd;
                        _prdEstatusTCS = s.EstatusTCS;
                    }
                    return new OOB.LibInventario.TallaColorSabor.Existencia.ExDepTCS()
                    {
                        idDep = s.idDep,
                        idTCS = s.idTCS,
                        NombreDep = s.NombreDep,
                        NombreTCS = s.NombreTCS,
                        Fisica = s.Fisica,
                        Reservada = s.Reservada,
                        Disponible = s.Disponible,
                    };
                }).ToList();
            }
            rt.Entidad = new OOB.LibInventario.TallaColorSabor.Existencia.Ficha()
            {
                idPrd = _prdId,
                NombrePrd = _prdNombre,
                EstatusTCS = _prdEstatusTCS,
                ExDep = _lst,
            };
            return rt;
        }
    }
}