using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Filtro.FiltroRep
{

    abstract public class baseData
    {
        
        public ficha Departamento { get; set; }
        public ficha Deposito { get; set; }
        public ficha Grupo { get; set; }
        public ficha Marca { get; set; }
        public ficha Impuesto { get; set; }
        public ficha Divisa { get; set; }
        public ficha Estatus { get; set; }
        public ficha Pesado { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }


        public baseData()
        {
            Departamento = null;
            Deposito = null;
            Grupo = null;
            Marca = null;
            Divisa = null;
            Impuesto = null;
            Estatus = null;
            Pesado = null;
            Desde = null;
            Hasta = null;
        }


        virtual public void Limpiar()
        {
            Departamento = null;
            Deposito = null;
            Grupo = null;
            Marca = null;
            Divisa = null;
            Impuesto = null;
            Estatus = null;
            Pesado = null;
            Desde = null;
            Hasta = null;
        }


        public override string ToString()
        {
            var t = "";
            if (Departamento!=null) t += ", Departamento: " + Departamento.desc;
            if (Deposito!= null) t += ", Deposito: " + Deposito.desc;
            if (Grupo!= null) t += ", Grupo: " + Grupo.desc;
            if (Marca!= null) t += ", Marca: " + Marca.desc;
            if (Divisa!= null) t += ", Divisa: " + Divisa.desc;
            if (Impuesto!= null) t += ", Tasa Iva: " + Impuesto;
            if (Estatus != null) t += ", Estatus: " + Estatus.desc;
            if (Pesado != null) t += ", Pesado: " + Pesado.desc;
            if (Desde.HasValue) t += "Desde: " + Desde.Value.ToShortDateString();
            if (Hasta.HasValue) t += ", Hasta: " + Hasta.Value.ToShortDateString();
            return t;
        }

    }

}