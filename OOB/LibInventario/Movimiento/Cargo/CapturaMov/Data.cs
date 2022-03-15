using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Movimiento.Cargo.CapturaMov
{

    public class Data:Movimiento.CapturaMov.BaseData
    {


        public Data()
        {
            autoPrd = "";
            autoDepart = "";
            autoGrupo = "";
            codigoPrd = "";
            nombrePrd = "";
            catPrd = "";
            exFisica = 0m;
            contEmp = 0;
            nombreEmp = "";
            decimales = "";
            costoUnd = 0m;
            costo = 0m;
            estatusDivisa = "";
            costoDivisa = 0m;
            autoTasa = "";
            descTasa = "";
            valorTasa = 0m;
            fechaUltActualizacionCosto = "";
        }

    }

}