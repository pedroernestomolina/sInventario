using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInvTipo.Traslado
{
    
    public class Gestion: ITipoxDev
    {

        private bool _isOk;
        private string _autorizado;
        private string _motivo;
        private dataItem _itemAgregar;
        private bool _procesarDocIsOk;
        private string _idDocumentoGenerado;
        private decimal _tasaCambio;
        private bool _activarPorDevolucion;
        private string _tipoMovimiento;


        private ModInventario.FiltrosGen.IOpcion _gConcepto;
        private ModInventario.FiltrosGen.IOpcion _gSucursal;
        private ModInventario.FiltrosGen.IOpcion _gDepOrigen;
        private ModInventario.FiltrosGen.IOpcion _gDepDestino;
        private Helpers.Maestros.ICallMaestros _gMaestro;
        private ICaptura _gCapturaMov;


        public string TipoMovimiento { get { return _tipoMovimiento; } }
        public bool IsOk { get { return _isOk; } }
        public BindingSource ConceptoSource { get { return _gConcepto.Source; } }
        public BindingSource SucursalSource { get { return _gSucursal.Source; } }
        public BindingSource DepOrigenSource { get { return _gDepOrigen.Source; } }
        public BindingSource DepDestinoSource { get { return _gDepDestino.Source; } }
        public string AutorizadoPor { get { return _autorizado; } }
        public string Motivo{ get { return _motivo; } }
        public string ConceptoGetId { get { return _gConcepto.GetId; } }
        public string SucursalGetId { get { return _gSucursal.GetId; } }
        public string DepOrigenGetID { get { return _gDepOrigen.GetId; } }
        public string DepDestinoGetID { get { return _gDepDestino.GetId; } }
        public dataItem ItemAgregar { get { return _itemAgregar; } }
        public bool ProcesarDocIsOk { get { return _procesarDocIsOk; } }
        public string IdDocumentoGenerado { get { return _idDocumentoGenerado; } }


        public Gestion(
            ICaptura ctrCapturaMov,
            Helpers.Maestros.ICallMaestros ctrMaestro)
        {
            _gCapturaMov = ctrCapturaMov;
            _gMaestro = ctrMaestro;
            _gConcepto = new ModInventario.FiltrosGen.Opcion.Gestion();
            _gSucursal = new ModInventario.FiltrosGen.Opcion.Gestion();
            _gDepOrigen = new ModInventario.FiltrosGen.Opcion.Gestion();
            _gDepDestino= new ModInventario.FiltrosGen.Opcion.Gestion();
            _isOk = false;
            _itemAgregar = null;
            _procesarDocIsOk=false;
            _autorizado = "";
            _motivo = "";
            _idDocumentoGenerado = "";
            _tasaCambio = 0m;
            _activarPorDevolucion = false;
            _tipoMovimiento = "TRASLADO / DEPÓSITOS";
        }


        public void Inicializa()
        {
            _gConcepto.Inicializa();
            _gSucursal.Inicializa();
            _gDepOrigen.Inicializa();
            _gDepDestino.Inicializa();
            _isOk = false;
            _itemAgregar = null;
            _procesarDocIsOk = false;
            _autorizado = "";
            _motivo = "";
            _idDocumentoGenerado = "";
            _tasaCambio = 0m;
        }

        MovFrm frm;
        public void Inicia(IGestionTipo ctr)
        {
            if (frm == null)
            {
                frm = new MovFrm();
                frm.setControlador(ctr);
            }
            frm.ShowDialog();
        }

        public bool CargarData()
        {
            var Id_Deposito_Devolucion = "";
            var Id_Concepto_Devolucion = "";

            if (_activarPorDevolucion)
            {
                var r11 = Sistema.MyData.Configuracion_DepositoConceptoPreDeterminadoDevolucionMercancia();
                if (r11.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r11.Mensaje);
                    return false;
                }
                Id_Concepto_Devolucion = r11.Entidad.IdConcepto;
                Id_Deposito_Devolucion = r11.Entidad.IdDeposito;

                var r22 = Sistema.MyData.Concepto_GetFicha(Id_Concepto_Devolucion);
                if (r22.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r22.Mensaje);
                    return false;
                }
                var rg = r22.Entidad;
                var _lConcepto = new List<ficha>();
                _lConcepto.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                _gConcepto.setData(_lConcepto);

                var r33 = Sistema.MyData.Deposito_GetFicha(Id_Deposito_Devolucion);
                if (r33.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r33.Mensaje);
                    return false;
                }
                var rg2 = r33.Entidad;
                var lst = new List<ficha>();
                lst.Add(new ficha(rg2.auto, rg2.codigo, rg2.nombre));
                _gDepDestino.setData(lst);
            }
            else
            {
                var r11 = Sistema.MyData.Concepto_GetLista();
                if (r11.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r11.Mensaje);
                    return false;
                }
                var _lConcepto = new List<ficha>();
                foreach (var rg in r11.Lista.OrderBy(o => o.nombre).ToList())
                {
                    _lConcepto.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gConcepto.setData(_lConcepto);

                var r22 = Sistema.MyData.Deposito_GetLista();
                if (r22.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r22.Mensaje);
                    return false;
                }
                var lst = new List<ficha>();
                foreach (var rg in r22.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gDepDestino.setData(lst);
            }

            var r02 = Sistema.MyData.Sucursal_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var _lSucursal = new List<ficha>();
            foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lSucursal.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gSucursal.setData(_lSucursal);
            _gDepOrigen.setData(null);

            var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _tasaCambio = r03.Entidad;

            return true;
        }


        public void setAutorizadoPor(string p)
        {
            _autorizado = p;
        }
        public void setMotivo(string p)
        {
            _motivo = p;
        }
        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
            if (id.Trim() != "")
            {
                var r01 = Sistema.MyData.Deposito_GetListaBySucursal(_gSucursal.Item.codigo);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var lst = new List<ficha>();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gDepOrigen.setData(lst);
            }
        }
        public void setConcepto(string id)
        {
            _gConcepto.setFicha(id);
        }
        public void setDepOrigen(string id)
        {
            _gDepOrigen.setFicha(id);
        }
        public void setDepDestino(string id)
        {
            _gDepDestino.setFicha(id);
        }


        public void BuscarIdPrd(string id)
        {
            _isOk = false;
            _itemAgregar = null;
            if (_gSucursal.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO SELECCIONADA");
                return;
            }
            if (_gDepOrigen.Item == null) 
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ORIGEN ] NO SELECCIONADA");
                return;
            }
            if (_gDepDestino.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO DESTINO ] NO SELECCIONADA");
                return;
            }

            var filtroOOB = new OOB.LibInventario.Movimiento.Traslado.CapturaMov.Filtro()
            {
                idDeposito = _gDepOrigen.GetId,
                IdDepDestino = _gDepDestino.GetId,
                idProducto = id,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_Traslado_CaptureMov(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var r = r01.Entidad.data;
            var dat = new data()
            {
                autoDepart = r.autoDepart,
                autoGrupo = r.autoGrupo,
                autoPrd = r.autoPrd,
                autoTasa = r.autoTasa,
                catPrd = r.catPrd,
                codigoPrd = r.codigoPrd,
                contEmp = r.contEmp,
                costo = r.costo,
                costoDivisa = r.costoDivisa,
                costoDivisaUnd = r.costoDivisaUnd,
                costoUnd = r.costoUnd,
                decimales = r.decimales,
                descTasa = r.descTasa,
                esAdmDivisa = r.esAdmDivisa,
                exFisica = r.exFisica,
                nombreEmp = r.nombreEmp,
                nombrePrd = r.nombrePrd,
                valorTasa = r.valorTasa,
                fechaUltimaActCosto = r.fechaUltActualizacionCosto,
            };
            _gCapturaMov.Inicializa();
            _gCapturaMov.setData(dat);
            _gCapturaMov.setTasaCambio(_tasaCambio);
            _gCapturaMov.Inicia();
            if (_gCapturaMov.IsOk) 
            {
                _itemAgregar = _gCapturaMov.DataItem;
                _isOk = true;
            }
        }

        public void Limpiar()
        {
            _itemAgregar = null;
            _autorizado = "";
            _motivo = "";
            _gConcepto.Limpiar();
            _gSucursal.Limpiar();
            _gDepOrigen.Limpiar();
            _gDepOrigen.setData(null);
            _gDepDestino.Limpiar();
        }


        public void EditarItem(dataItem ItemActual)
        {
            _isOk = false;
            _gCapturaMov.Inicializa();
            _gCapturaMov.setItemEditar(ItemActual);
            _gCapturaMov.Inicia();
            if (_gCapturaMov.IsOk)
            {
                _itemAgregar = _gCapturaMov.DataItem;
                _isOk = true;
            }
        }


        public void ConceptoMaestro()
        {
            _gMaestro.MtConcepto();

            var r01 = Sistema.MyData.Concepto_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var _lConcepto= new List<ficha>();
            foreach(var rg in r01.Lista.OrderBy(o=>o.nombre).ToList())
            {
                _lConcepto.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gConcepto.setData(_lConcepto);
        }


        public void ProcesarDoc(List<dataItem> list, decimal totalImporte)
        {
            _procesarDocIsOk = false;
            _idDocumentoGenerado = "";
            if (ValidarDoc())
            {
                var xmsg = "Procesar / Generar Movimiento ?";
                var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    RegistrarDoc(list, totalImporte);
                }
            }
        }

        private void RegistrarDoc(List<dataItem> list, decimal totalImporte)
        {
            var r00 = Sistema.MyData.Sistema_TipoDocumento_GetFichaByTipo(OOB.LibInventario.Sistema.TipoDocumento.enumerados.enumTipoDocumento.TRASLADO);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            var _docTipo = r00.Entidad;
            var _mDivisa = Math.Round(totalImporte / _tasaCambio, 2, MidpointRounding.AwayFromZero);
            var movOOB = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMov()
            {
                autoConcepto = _gConcepto.Item.id,
                autoDepositoDestino = _gDepOrigen.Item.id,
                autoDepositoOrigen = _gDepDestino.Item.id,
                autoRemision = "",
                autorizado = _autorizado,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = _gConcepto.Item.codigo,
                codDepositoDestino = _gDepDestino.Item.codigo,
                codDepositoOrigen = _gDepOrigen.Item.codigo,
                codigoSucursal = _gSucursal.Item.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = _gConcepto.Item.desc,
                desDepositoDestino = _gDepDestino.Item.desc,
                desDepositoOrigen = _gDepOrigen.Item.desc,
                documentoNombre = _docTipo.nombre,
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = _motivo,
                renglones = list.Count,
                situacion = "Procesado",
                tipo = _docTipo.codigo,
                total = totalImporte,
                usuario = Sistema.UsuarioP.nombreUsu,
                factorCambio = _tasaCambio,
                montoDivisa = _mDivisa,
            };

            var detOOB = list.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovDetalle()
                {
                    autoDepartamento = s.Data.autoDepart,
                    autoGrupo = s.Data.autoGrupo,
                    autoProducto = s.Data.autoPrd,
                    cantidad = s.Cantidad,
                    cantidadBono = 0,
                    cantidadUnd = s.CntUnd,
                    categoria = s.Data.catPrd,
                    codigoProducto = s.Data.codigoPrd,
                    contEmpaque = s.Data.contEmp,
                    costoCompra = s.CostoNacional,
                    costoUnd = s.CostoUndNacional,
                    decimales = s.Data.decimales,
                    empaque = s.Data.nombreEmp,
                    estatusAnulado = "0",
                    estatusUnidad = s.MovPorUnidad ? "1" : "0",
                    nombreProducto = s.Data.nombrePrd,
                    signo = _docTipo.signo,
                    tipo = _docTipo.codigo,
                    total = s.ImporteNacional,
                };
                return rg;
            }).ToList();

            var gr3 = list.GroupBy
                (g => new { g.Data.autoPrd, g.Data.nombrePrd }).
                Select(g2 => new { id = g2.Key.autoPrd, desc = g2.Key.nombrePrd, cnt = g2.Sum(s => s.CntUnd) }).
                ToList();
            var depOOB = gr3.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovDeposito()
                {
                    autoDeposito = _gDepOrigen.Item.id,
                    autoDepositoDestino = _gDepDestino.Item.id,
                    autoProducto = s.id,
                    nombreProducto = s.desc,
                    nombreDeposito = _gDepOrigen.Item.desc,
                    depositoDestino = _gDepDestino.Item.desc,
                    cantidadUnd = s.cnt,
                };
                return rg;
            }).ToList();

            var lSalida= list.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovKardex()
                {
                    autoConcepto = _gConcepto.Item.id,
                    autoDeposito = _gDepOrigen.Item.id,
                    autoProducto = s.Data.autoPrd,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CntUnd,
                    codigoMov = _docTipo.codigo,
                    codigoConcepto = _gConcepto.Item.codigo,
                    codigoDeposito = _gDepOrigen.Item.codigo,
                    codigoSucursal = _gSucursal.Item.codigo,
                    costoUnd = s.CostoUndNacional,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = _docTipo.tipo,
                    nombreConcepto = _gConcepto.Item.desc,
                    nombreDeposito = _gDepOrigen.Item.desc,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov =_docTipo.siglas,
                    signoMov = -1,
                    total = s.ImporteNacional,
                };
                return rg;
            }).ToList();

            var lEntrada= list.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaMovKardex()
                {
                    autoConcepto = _gConcepto.Item.id,
                    autoDeposito = _gDepDestino.Item.id,
                    autoProducto = s.Data.autoPrd,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CntUnd,
                    codigoMov = _docTipo.codigo,
                    codigoConcepto = _gConcepto.Item.codigo,
                    codigoDeposito = _gDepDestino.Item.codigo,
                    codigoSucursal = _gSucursal.Item.codigo,
                    costoUnd = s.CostoUndNacional,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = _docTipo.tipo,
                    nombreConcepto = _gConcepto.Item.desc,
                    nombreDeposito = _gDepDestino.Item.desc,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = _docTipo.siglas,
                    signoMov = 1,
                    total = s.ImporteNacional,
                };
                return rg;
            }).ToList();
            var KardexOOB = lSalida.Union(lEntrada).ToList();

            var ficha = new OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha()
            {
                mov = movOOB,
                movDeposito = depOOB,
                movDetalles = detOOB,
                movKardex = KardexOOB,
            };
            var r01 = Sistema.MyData.Producto_Movimiento_Traslado_Insertar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _procesarDocIsOk = true;
            _idDocumentoGenerado = r01.Auto;
        }


        private bool ValidarDoc()
        {
            if (_autorizado.Trim() == "") 
            {
                Helpers.Msg.Alerta("CAMPO [ AUTORIZADO POR ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_motivo.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ MOTIVO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_gSucursal.Item == null) 
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_gConcepto.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ CONCEPTO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_gDepOrigen.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ORIGEN ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_gDepDestino.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO DESTINO ] NO PUEDE ESTAR VACIO");
                return false;
            }

            return true;
        }

        public void setActivarPorDevolucion(bool p)
        {
            _tipoMovimiento = "TRASLADO / DEPÓSITOS";
            _activarPorDevolucion = p;
            if (_activarPorDevolucion)
                _tipoMovimiento = "TRASLADO x DEVOLUCIÓN";
        }


        public bool CapturarDataAplicarAjusteInvCeroIsOk { get { return false; } }
        public List<dataItem> ListaItemAplicarAjusteInvCero { get { return null; } }
        public void CapturarDataAplicarAjusteInvCero()
        {
        }


        public BindingSource DepatamentoSource { get { return null; } }
        public string DepartamentoGetId { get { return ""; } }
        public void setDepartamento(string id)
        {
        }


        public bool CapturarProductosConNivelMinimoIsOk { get { return false; } }
        public List<dataItem> ListaItemNivelMinimo { get { return null; } }
        public void CapturarProductosConNivelMinimo()
        {
        }


        public void NuevoDocumento()
        {
            _isOk = false;
            _itemAgregar = null;
            _procesarDocIsOk = false;
            _autorizado = "";
            _motivo = "";
            _idDocumentoGenerado = "";
        }


        public bool DejarEnPendienteIsOk { get { return false; } }
        public void DejarEnPendiente(List<dataItem> list, decimal TotalImporte)
        {
        }


    }

}