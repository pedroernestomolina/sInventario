using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.TomaInv.AnalisisResultado
{
    public class gestionRep
    {
        private List<item> _list;
        private string _solicitudNro;
        private string _sucursal;
        private string _deposito;
        private int _cntPrdAnalizados;
        private int _cntPrdAnalizados_OK;
        private int _cntPrdAnalizados_FALTANTES;
        private int _cntPrdAnalizados_SOBRANTES;
        private int _cntPrdAnalizados_NO_CONTADOS;


        public gestionRep()
        {
            _solicitudNro = "";
            _sucursal = "";
            _deposito = "";
            _cntPrdAnalizados = 0;
            _cntPrdAnalizados_OK = 0;
            _cntPrdAnalizados_FALTANTES = 0;
            _cntPrdAnalizados_SOBRANTES = 0;
            _cntPrdAnalizados_NO_CONTADOS = 0;
            _list = new List<item>();
        }

        public void setData(data ficha)
        {
            _solicitudNro = ficha.solicitudNro;
            _sucursal = ficha.sucursal;
            _deposito = ficha.deposito;
            _list.Clear();
            _list = ficha.items;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\TomaInv\TomaResultado.rdlc";
            var ds = new DS_TOMA();

            _cntPrdAnalizados = _list.Count;
            foreach (var it in _list.Where(w => w.descToma.Trim().ToUpper() != "SINDEFINIR").ToList())
            {
                DataRow rt = ds.Tables["resultado"].NewRow();
                rt["producto"] = it.producto;
                rt["cantidad"] = it.cant;
                rt["descToma"] = it.descToma;
                rt["signo"] = it.signo;
                rt["motivo"] = it.motivo;
                ds.Tables["resultado"].Rows.Add(rt);
                switch (it.descToma.Trim().ToUpper())
                {
                    case "OK":
                        _cntPrdAnalizados_OK += 1;
                        break;
                    case "FALTA":
                        _cntPrdAnalizados_FALTANTES += 1;
                        break;
                    case "SOBRA":
                        _cntPrdAnalizados_SOBRANTES += 1;
                        break;
                }
            }
            foreach (var it in _list.Where(w => w.descToma.Trim().ToUpper() == "SINDEFINIR").ToList())
            {
                DataRow rt = ds.Tables["resultado"].NewRow();
                rt["producto"] = it.producto;
                rt["cantidad"] = it.cant;
                rt["descToma"] = "NO SE CONTO";
                rt["signo"] = it.signo;
                rt["motivo"] = "";
                ds.Tables["resultado"].Rows.Add(rt);
                _cntPrdAnalizados_NO_CONTADOS += 1;
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("SOLICITUD", _solicitudNro));
            pmt.Add(new ReportParameter("SUCURSAL", _sucursal));
            pmt.Add(new ReportParameter("DEPOSITO", _deposito));
            pmt.Add(new ReportParameter("CNT_ITEMS_ANALIZADOS", _cntPrdAnalizados.ToString("n0")));
            pmt.Add(new ReportParameter("CNT_ITEMS_ANALIZADOS_OK", _cntPrdAnalizados_OK.ToString("n0")));
            pmt.Add(new ReportParameter("CNT_ITEMS_ANALIZADOS_FALTANTES", _cntPrdAnalizados_FALTANTES.ToString("n0")));
            pmt.Add(new ReportParameter("CNT_ITEMS_ANALIZADOS_SOBRANTES", _cntPrdAnalizados_SOBRANTES.ToString("n0")));
            pmt.Add(new ReportParameter("CNT_ITEMS_ANALIZADOS_NO_CONTADOS", _cntPrdAnalizados_NO_CONTADOS.ToString("n0")));

            //pmt.Add(new ReportParameter("EX_COMPRA", exCompra.ToString()));
            //pmt.Add(new ReportParameter("EX_INV", exInv.ToString()));
            //pmt.Add(new ReportParameter("EX_UND", exUnd.ToString()));
            Rds.Add(new ReportDataSource("resultado", ds.Tables["resultado"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}