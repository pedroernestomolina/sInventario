using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Costo.Editar
{

    public class Gestion
    {

        public string _autoPrd;
        private costo _costoProv;
        private costo _costoImp;
        private costo _costoVario;
        private costo _costoDivisa;
        private costo _costoPromedio;
        private costo _costoFinal;
        private bool _isAdmDivisa;
        private bool _isCerrarHabilitado;
        private bool _editarCostoIsOk;

        private string producto;
        private string costoUnit;
        private string admDivisa;
        private string tasaIva;
        private decimal tasaCambioActual;
        private string fechaUltActCosto;
        private string empaqueContenido;
        private precio precio_1;
        private precio precio_2;
        private precio precio_3;
        private precio precio_4;
        private precio precio_5;


        public costo CostoProv { get { return _costoProv; } }
        public costo CostoImp { get { return _costoImp; } }
        public costo CostoVario{ get { return _costoVario; } }
        public costo CostoFinal { get { return _costoFinal; } }
        public costo CostoPromedio{ get { return _costoPromedio; } }
        public costo CostoDivisa { get { return _costoDivisa; } }
        public bool IsProductoAdmDivisa { get { return _isAdmDivisa; } }
        public string Producto { get { return producto; } }
        public string CostoUnitario { get { return costoUnit; } }
        public string AdmDivisa { get { return admDivisa; } }
        public string TasaIva { get { return tasaIva; } }
        public string EmpaqueContenido { get { return empaqueContenido; } }
        public string TasaCambioActual { get { return tasaCambioActual.ToString("n2"); } }
        public string FechaUltActCosto { get { return fechaUltActCosto; } }
        public bool IsCerrarHabilitado { get { return _isCerrarHabilitado; } }
        public bool EditarCostoIsOk { get { return _editarCostoIsOk; } }


        public Gestion()
        {
            _isCerrarHabilitado = true;
            _costoProv = new costo();
            _costoImp = new costo();
            _costoVario = new costo();
            _costoDivisa = new costo();
            _costoPromedio = new costo();
            _costoFinal = new costo();

            precio_1 = new precio();
            precio_2 = new precio();
            precio_3 = new precio();
            precio_4 = new precio();
            precio_5 = new precio();

            Limpiar();
        }

        private void Limpiar()
        {
            producto="";
            costoUnit="";
            admDivisa="";
            tasaIva = "";
            fechaUltActCosto="";
            tasaCambioActual=0.0m;
            empaqueContenido = "";

            _costoProv.Limpia();
            _costoImp.Limpia();
            _costoVario.Limpia();
            _costoDivisa.Limpia();
            _costoPromedio.Limpia();
            _costoFinal.Limpia();

            precio_1.Limpiar();
            precio_2.Limpiar();
            precio_3.Limpiar();
            precio_4.Limpiar();
            precio_5.Limpiar();

            _editarCostoIsOk = false;
        }


        public void setFicha(string p)
        {
            _autoPrd = p;
        }

        EditarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new EditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetCosto(_autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var tasa = r01.Entidad.tasaIva;

            var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            var r03 = Sistema.MyData.Producto_GetPrecio(_autoPrd);
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            
            var r04 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }

            var r05 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            var redondeo = precio.enumModoRedondeo.SinRedondeo;
            switch (r05.Entidad)
            {
                case  OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
                    redondeo = precio.enumModoRedondeo.Unidad;
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
                    redondeo = precio.enumModoRedondeo.Decena;
                    break;
            }

            var r06 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            var prefPrec = precio.enumPreferenciaPrecio.Neto;
            if (r06.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full)
                prefPrec = precio.enumPreferenciaPrecio.Full;

            var pr = r03.Entidad;
            var met = precio.enumUtilidadMetodo.Lineal;
            if (r04.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero) 
            {
                met = precio.enumUtilidadMetodo.Financiero;
            }
            precio_1.setFicha(pr.utilidad1, pr.precioNeto1, tasa, met, redondeo, prefPrec);
            precio_2.setFicha(pr.utilidad2, pr.precioNeto2, tasa, met, redondeo, prefPrec);
            precio_3.setFicha(pr.utilidad3, pr.precioNeto3, tasa, met, redondeo, prefPrec);
            precio_4.setFicha(pr.utilidad4, pr.precioNeto4, tasa, met, redondeo, prefPrec);
            precio_5.setFicha(pr.utilidad5, pr.precioNeto5, tasa, met, redondeo, prefPrec);

            producto = r01.Entidad.codigo + Environment.NewLine + r01.Entidad.descripcion;
            empaqueContenido = r01.Entidad.empaqueCompra.Trim() + "/" + r01.Entidad.contEmpaqueCompra.ToString();
            admDivisa = r01.Entidad.admDivisa.ToString();
            tasaIva = "EXENTO";
            fechaUltActCosto = r01.Entidad.fechaUltCambio;
            costoUnit = r01.Entidad.costoUnd.ToString("N2");
            tasaCambioActual = r02.Entidad;
            if (r01.Entidad.tasaIva > 0)
            {
                tasaIva = r01.Entidad.tasaIva.ToString("n2").Trim().PadLeft(5, '0') + "%";
            }
            if (r01.Entidad.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
            {
                costoUnit = r01.Entidad.costoDivisaUnd.ToString("N2");
            }

            _costoProv.setFicha(r01.Entidad.costoProveedorUnd, r01.Entidad.tasaIva, r01.Entidad.contEmpaqueCompra);
            _costoImp.setFicha(r01.Entidad.costoImportacionUnd, r01.Entidad.tasaIva, r01.Entidad.contEmpaqueCompra);
            _costoVario.setFicha(r01.Entidad.costoVarioUnd, r01.Entidad.tasaIva, r01.Entidad.contEmpaqueCompra);
            _costoDivisa.setFicha(r01.Entidad.costoDivisaUnd, r01.Entidad.tasaIva, r01.Entidad.contEmpaqueCompra,r02.Entidad);
            _costoFinal.setFicha(r01.Entidad.costoUnd, r01.Entidad.tasaIva, r01.Entidad.contEmpaqueCompra);
            _costoPromedio.setFicha(r01.Entidad.costoPromedioUnd, r01.Entidad.tasaIva, r01.Entidad.contEmpaqueCompra);
            _isAdmDivisa = r01.Entidad.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si ? true : false;
            return rt;
        }

        public void CostoFinalRecalcula()
        {
            var v= _costoProv.EmpNeto+_costoImp.EmpNeto + _costoVario.EmpNeto;
            _costoFinal.setNeto(v);
            _costoDivisa.setNeto(v/tasaCambioActual);

        }

        public void RecalculaCosto()
        {
            var neto = _costoDivisa.EmpNetoCambio;
            _costoProv.setNeto(neto);
            _costoImp.setNeto(0);
            _costoVario.setNeto(0);
            CostoFinalRecalcula();
        }

        public void Procesar()
        {
            _editarCostoIsOk = false;
            var rt = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                if (_isAdmDivisa)
                {
                    if (precio_1.Recalcular)
                        precio_1.ActualizarPrecio(CostoFinal.UndNeto);
                    if (precio_2.Recalcular)
                        precio_2.ActualizarPrecio(CostoFinal.UndNeto);
                    if (precio_3.Recalcular)
                        precio_3.ActualizarPrecio(CostoFinal.UndNeto);
                    if (precio_4.Recalcular)
                        precio_4.ActualizarPrecio(CostoFinal.UndNeto);
                    if (precio_5.Recalcular)
                        precio_5.ActualizarPrecio(CostoFinal.UndNeto);
                }
                else 
                {
                    if (precio_1.Recalcular)
                        precio_1.ActualizarUtilidad(CostoFinal.UndNeto);
                    if (precio_2.Recalcular)
                        precio_2.ActualizarUtilidad(CostoFinal.UndNeto);
                    if (precio_3.Recalcular)
                        precio_3.ActualizarUtilidad(CostoFinal.UndNeto);
                    if (precio_4.Recalcular)
                        precio_4.ActualizarUtilidad(CostoFinal.UndNeto);
                    if (precio_5.Recalcular)
                        precio_5.ActualizarUtilidad(CostoFinal.UndNeto);
                }
                _isCerrarHabilitado = Guardar();
            }
            else
            {
                _isCerrarHabilitado = false ;
            }
        }

        private bool Guardar()
        {
            var rt = true;

            var ficha = new OOB.LibInventario.Costo.Editar.Ficha()
            {
                autoProducto = _autoPrd,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                codigoUsuario = Sistema.UsuarioP.codigoUsu,
                costoDivisa = CostoDivisa.EmpNeto,
                costoFinal = CostoFinal.EmpNeto,
                costoFinalUnd = CostoFinal.UndNeto,
                costoImportacion = CostoImp.EmpNeto,
                costoImportacionUnd = CostoImp.UndNeto,
                costoPromedio = CostoPromedio.EmpNeto,
                costoPromedioUnd = CostoPromedio.UndNeto,
                costoProveedor = CostoProv.EmpNeto,
                costoProveedorUnd = CostoProv.UndNeto,
                costoVario = CostoVario.EmpNeto,
                costoVarioUnd = CostoVario.UndNeto,
                estacion = Environment.MachineName,
                nombreUsuario = Sistema.UsuarioP.nombreUsu,
            };
            var historia = new OOB.LibInventario.Costo.Editar.FichaHistorica()
            {
                costo = CostoFinal.EmpNeto,
                divisa = CostoDivisa.EmpNeto,
                documento = "",
                nota = "",
                serie = "MAN",
                tasaCambio = tasaCambioActual,
            };
            ficha.historia = historia;

            //var precio = new OOB.LibInventario.Costo.Editar.FichaPrecio()
            //{
            //    pn1 = precio_1.Neto,
            //    pn2 = precio_2.Neto,
            //    pn3 = precio_3.Neto,
            //    pn4 = precio_4.Neto,
            //    pn5 = precio_5.Neto,
            //    ut1 = precio_1.Utilidad,
            //    ut2 = precio_2.Utilidad,
            //    ut3 = precio_3.Utilidad,
            //    ut4 = precio_4.Utilidad,
            //    ut5 = precio_5.Utilidad,
            //};
           // ficha.precio=precio;

            var r01= Sistema.MyData.CostoProducto_Actualizar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false; ;
            }
            _editarCostoIsOk = true;

            return rt;
        }

        public void InicializarIsCerrarHabilitado()
        {
            _isCerrarHabilitado = true;
        }

    }

}