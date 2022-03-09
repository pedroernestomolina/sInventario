using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Documentos
{

    public class Movimiento
    {

        private data _ficha;
    

        public Movimiento(data ficha)
        {
            _ficha = ficha;
        }


        public void Generar() 
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Documentos\MovTraslado.rdlc";
            var ds = new dsDocumento();

            DataRow rt = ds.Tables["Movimiento"].NewRow();
            rt["documentoNro"] = _ficha.documentoNro;
            rt["fecha"] = _ficha.fecha;
            rt["autorizadoPor"] = _ficha.autorizadoPor;
            rt["notas"] = _ficha.notas;
            rt["depOrigen"] = _ficha.codigoDepositoOrigen+"/"+_ficha.depositoOrigen ;
            rt["depDestino"] = _ficha.codigoDepositoDestino+"/"+_ficha.depositoDestino ;
            rt["tipoMovimiento"] = _ficha.tipoDocumento ;
            rt["nombreDocumento"] = _ficha.nombreDocumento;
            rt["concepto"] = _ficha.codigoConcepto + "/" + _ficha.concepto;
            rt["usuario"] = _ficha.usuarioCodigo + "/" + _ficha.usuario;
            rt["equipo"] = _ficha.estacion ;
            rt["estatusActivo"] = _ficha.estatusActivo;
            ds.Tables["Movimiento"].Rows.Add(rt);

            foreach (var it in _ficha.detalles.ToList())
            {
                var empaque = "UNIDAD/(1)";
                if (!it.esUnidad) 
                {
                    empaque = it.empaque.Trim() + "/(" + it.contenido.ToString() + ")";
                }
                DataRow r = ds.Tables["MovimientoDetalle"].NewRow();
                r["codigo"] = it.codigo;
                r["descripcion"] = it.descripcion;
                r["cantidad"] = it.cantidad.ToString("n"+it.decimales);
                r["cantidadUnd"] = it.cantidadUnd.ToString("n"+it.decimales);
                r["empaque"] = empaque;
                r["signo"] = it.signo;
                r["costo"] = it.costoUnd;
                r["importe"] = it.importe*it.signo;
                ds.Tables["MovimientoDetalle"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            Rds.Add(new ReportDataSource("Movimiento", ds.Tables["Movimiento"]));
            Rds.Add(new ReportDataSource("MovimientoDetalle", ds.Tables["MovimientoDetalle"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}