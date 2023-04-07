using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.ActualizarOferta.ModoAdm
{
    public class ImpModoAdm: IModoAdm
    {
        private IPrd _prd;


        public IPrd Prd { get { return _prd; } }


        public ImpModoAdm()
        {
            _idPrd = "";
            _prd = new imp_prd();
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }


        public void Inicializa()
        {
            _idPrd = "";
            _prd.Inicializa();
            _abandonarIsOk = false;
            _procesarIsOk = false;
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private string _idPrd;
        public void setFichaByIdPrd(string id)
        {
            _idPrd = id;
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }

        private bool _procesarIsOk;
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            var res = Helpers.Msg.ProcesarGuardar();
            if (res) 
            {
                if (!_prd.Vta1.PrecioOfertaIsOK) 
                {
                    Helpers.Msg.Alerta("PRECIO OFERTA [ 1 ] INCORRECTO");
                    return;
                }
                if (!_prd.Vta2.PrecioOfertaIsOK)
                {
                    Helpers.Msg.Alerta("PRECIO OFERTA [ 2 ] INCORRECTO");
                    return;
                }
                if (!_prd.Vta3.PrecioOfertaIsOK)
                {
                    Helpers.Msg.Alerta("PRECIO OFERTA [ 3 ] INCORRECTO");
                    return;
                }
                Procesar();
            }
        }


        private void Procesar()
        {
            var _estatusOferta = "0";
            var of1 = new OOB.LibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar.Precio();
            var of2 = new OOB.LibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar.Precio();
            var of3 = new OOB.LibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar.Precio();
            //
            if (_prd.Vta1.PrecioOfertaIsOK)
            {
                _estatusOferta = "1";
                of1.desde = _prd.Vta1.GetOfertaDesde ;
                of1.hasta = _prd.Vta1.GetOfertaHasta;
                of1.estatus = _prd.Vta1.PrecioOfertaIsOK ? "1" : "0";
                of1.portc = _prd.Vta1.GetOfertaPorct;
            }
            of1.idPrecioVta = _prd.Vta1.GetIdPrecioVta;
            //
            if (_prd.Vta2.PrecioOfertaIsOK)
            {
                _estatusOferta = "1";
                of2.desde = _prd.Vta2.GetOfertaDesde;
                of2.hasta = _prd.Vta2.GetOfertaHasta;
                of2.estatus = _prd.Vta2.PrecioOfertaIsOK ? "1" : "0";
                of2.portc = _prd.Vta2.GetOfertaPorct;
            }
            of2.idPrecioVta = _prd.Vta2.GetIdPrecioVta;
            //
            if (_prd.Vta3.PrecioOfertaIsOK)
            {
                _estatusOferta = "1";
                of3.desde = _prd.Vta3.GetOfertaDesde;
                of3.hasta = _prd.Vta3.GetOfertaHasta;
                of3.estatus = _prd.Vta3.PrecioOfertaIsOK ? "1" : "0";
                of3.portc = _prd.Vta3.GetOfertaPorct;
            }
            of3.idPrecioVta = _prd.Vta3.GetIdPrecioVta;

            var _lst = new List<OOB.LibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar.Precio>();
            _lst.Add(of1);
            _lst.Add(of2);
            _lst.Add(of3);
            var actOfertaOOB = new OOB.LibInventario.Producto.ActualizarOferta.ModoAdm.Actualizar.Ficha()
            {
                autoPrd = _idPrd,
                estatusOferta = _estatusOferta,
                ofertas = _lst,
            };
            try
            {
                var r01 = Sistema.MyData.Producto_ModoAdm_ActualizarOferta(actOfertaOOB);
                _procesarIsOk = true;
                Helpers.Msg.EditarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        private bool CargarData()
        {
            try
            {
                var xr1 = Sistema.MyData.Producto_ModoAdm_GetPrecio_By(_idPrd, "1");
                var xr2 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (xr2.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(xr2.Mensaje);
                }
                var xr3 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
                if (xr3.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(xr3.Mensaje);
                }
                var xr4 = Sistema.MyData.Producto_GetCosto(_idPrd);
                if (xr4.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(xr4.Mensaje);
                }

                var ent = xr1.Entidad.entidad;
                sFicha _sficha = new sFicha(ent.auto,
                                                ent.codigo,
                                                ent.descripcion,
                                                ent.esDivisa,
                                                ent.tasaIva,
                                                xr2.Entidad,
                                                xr3.Entidad.ToString(),
                                                xr4.Entidad.costoUnd);
                _prd.setdataPrd(_sficha);
                foreach (var rg in xr1.Entidad.precios) 
                {
                    switch (rg.tipoEmp.Trim().ToUpper())
                    { 
                        case "1":
                            var vta = new sVta(rg.idHndPrecioVenta, 
                                                rg.pnEmp,
                                                rg.pfdEmp,
                                                rg.utEmp,
                                                rg.contEmp,
                                                rg.descEmp,
                                                rg.ofertaDesde,
                                                rg.ofertaHasta,
                                                rg.ofertaPorct,
                                                rg.ofertaEstatus,
                                                xr4.Entidad.costoUnd);
                            _prd.setdataVta1(vta, ent.tasaIva);
                            break;
                        case "2":
                            vta = new sVta(rg.idHndPrecioVenta, 
                                                rg.pnEmp,
                                                rg.pfdEmp,
                                                rg.utEmp,
                                                rg.contEmp,
                                                rg.descEmp,
                                                rg.ofertaDesde,
                                                rg.ofertaHasta,
                                                rg.ofertaPorct,
                                                rg.ofertaEstatus, 
                                                xr4.Entidad.costoUnd);
                            _prd.setdataVta2(vta, ent.tasaIva);
                            break;
                        case "3":
                            vta = new sVta(rg.idHndPrecioVenta,
                                                rg.pnEmp,
                                                rg.pfdEmp,
                                                rg.utEmp,
                                                rg.contEmp,
                                                rg.descEmp,
                                                rg.ofertaDesde,
                                                rg.ofertaHasta,
                                                rg.ofertaPorct,
                                                rg.ofertaEstatus,
                                                xr4.Entidad.costoUnd);
                            _prd.setdataVta3(vta, ent.tasaIva);
                            break;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}