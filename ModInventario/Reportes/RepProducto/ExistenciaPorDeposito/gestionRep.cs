using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.RepProducto.ExistenciaPorDeposito
{

    public class gestionRep
    {
        
        private string _filtros;
        private OOB.LibInventario.Producto.Data.Existencia _fichaPrd;


        public gestionRep(OOB.LibInventario.Producto.Data.Existencia fichaPrd, string filt)
        {
            _fichaPrd = fichaPrd;
            _filtros = filt;
        }


        public void Generar() 
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\RepProducto\Prd_ExistenciaDeposito.rdlc";
            var ds = new DS_VAR();

            var xtot = 0m;
            var exCompra = 0m;
            var exInv = 0m;
            var exUnd = 0m;
            _filtros = _fichaPrd.nombrePrd + "(" + _fichaPrd.codigoPrd + ")";
            if (_fichaPrd.empaqueContenido > 0)
            {
                xtot = _fichaPrd.depositos.Sum(s => s.exFisica);
                exCompra = (int)(xtot / _fichaPrd.empaqueContenido);
                xtot -= (exCompra * _fichaPrd.empaqueContenido);
                exInv = (int)(xtot / _fichaPrd.contEmpInv);
                xtot -= (exInv * _fichaPrd.contEmpInv);
                exUnd = (int)xtot;
            }

            foreach (var it in _fichaPrd.depositos.ToList())
            {
                DataRow rt = ds.Tables["EXISTENCIA_DEPOSITO"].NewRow();
                rt["deposito"] = it.nombre+"("+it.codigo+")";
                rt["exTotal"] = it.exFisica;
                var tot = it.exFisica;
                var exEmpCompra = 0;
                var exEmpInv = 0;
                var exEmpUnd= 0;
                if (_fichaPrd.empaqueContenido > 0) 
                {
                    exEmpCompra = (int)(tot / _fichaPrd.empaqueContenido);
                    tot -= (exEmpCompra * _fichaPrd.empaqueContenido);
                    exEmpInv = (int)(tot / _fichaPrd.contEmpInv);
                    tot -= (exEmpInv * _fichaPrd.contEmpInv);
                    exEmpUnd = (int)tot;
                }
                rt["exEmpCompra"] = _fichaPrd.empaque + "(" + _fichaPrd.empaqueContenido.ToString() + ")" + Environment.NewLine + exEmpCompra.ToString();
                rt["exEmpInv"] = _fichaPrd.descEmpInv + "(" + _fichaPrd.contEmpInv.ToString() + ")" + Environment.NewLine + exEmpInv.ToString();
                rt["exEmpUnd"] = "UNIDAD(1)" + Environment.NewLine + exEmpUnd.ToString();
                ds.Tables["EXISTENCIA_DEPOSITO"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", _filtros));
            pmt.Add(new ReportParameter("EX_COMPRA", exCompra.ToString()));
            pmt.Add(new ReportParameter("EX_INV", exInv.ToString()));
            pmt.Add(new ReportParameter("EX_UND", exUnd.ToString()));
            Rds.Add(new ReportDataSource("EXISTENCIA_DEPOSITO", ds.Tables["EXISTENCIA_DEPOSITO"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}