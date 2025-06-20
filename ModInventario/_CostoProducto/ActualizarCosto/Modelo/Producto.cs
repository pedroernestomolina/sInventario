using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario._CostoProducto.ActualizarCosto.Modelo
{
    public class Producto
    {
        public string idPrd { get; set; }
        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public string descripcionPrd { get; set; }
        public string descTasaIvaPrd { get; set; }
        public decimal tasaIvaPrd { get; set; }
        public bool esAdmDivisa { get; set; }
        public string descEmpqCompra { get; set; }
        public int contEmpqCompra { get; set; }
        public decimal costoProv { get; set; }
        public decimal costoImport { get; set; }
        public decimal costoVario { get; set; }
        public decimal costoFinal { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal costoPromedio { get; set; }
        public string fechaUltCambio { get; set; }
        //
        public string Get_DescProducto 
        { 
            get 
            { 
                return codigoPrd.Trim() + Environment.NewLine + descripcionPrd.Trim(); 
            } 
        }
        public string Get_CostoFinal_Und
        {
            get
            {
                var rt = 0m;
                if (contEmpqCompra>0)
                {
                    rt = costoFinal / contEmpqCompra;
                    rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                };
                return rt.ToString();
            }
        }
        public string Get_AdmDivisa 
        {
            get 
            {
                return esAdmDivisa ? "SI" : "NO";
            }
        }
        public string Get_DescTasaIva
        {
            get
            {
                var rt = "EXENTO";
                if (tasaIvaPrd > 0)
                    rt = tasaIvaPrd.ToString("n2").Trim() + "%";
                return rt;
            }
        }

        public string Get_FechaUltActCosto 
        { 
            get
            {
                return fechaUltCambio.Trim();
            }
        }
        public string Get_DescEmqCompra 
        {
            get                 
            {
                return descEmpqCompra.Trim().ToUpper()+"/"+contEmpqCompra.ToString().Trim();
            }
        }
    }
}