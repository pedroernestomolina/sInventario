using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.MetodoCalculoUtilidad
{
    
    public class Gestion
    {

        private bool _isOk;
        private BindingSource _bs;
        private List<data> _ldata;
        private data _metCalculoUt;


        public bool IsOk { get { return _isOk; } }
        public data MetCalculoUt { get { return _metCalculoUt; } }
        public BindingSource Source { get { return _bs; } }


        public Gestion()
        {
            _isOk = false;
            _metCalculoUt= null;
            _ldata = new List<data>();
            _bs=new BindingSource();
            _bs.DataSource = _ldata;
        }


        public void Inicializa()
        {
            _isOk = false;
        }

        ConfigurarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ConfigurarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _ldata.Clear();
            _ldata.Add(new data("1", "Lineal"));
            _ldata.Add(new data("2", "Financiero"));
            
            switch (r01.Entidad.ToString().ToUpper()) 
            {
                case "LINEAL":
                    _metCalculoUt = _ldata.FirstOrDefault(f => f.auto == "1");
                    break;
                case "FINANCIERO":
                    _metCalculoUt= _ldata.FirstOrDefault(f => f.auto == "2");
                    break;
            }

            return rt;
        }

        public void Procesar()
        {
            _isOk = false;
            var msg = MessageBox.Show("Esta Opción Actualizará Todos Los Precio De Ventas, Estas Seguro ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                GuardarCambios();
            }
        }

        public void GuardarCambios()
        {
            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var rx1 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad_CapturarData();
                if (rx1.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rx1.Mensaje);
                    return;
                }
                var rx2 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (rx2.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rx2.Mensaje);
                    return;
                }
                var rx3 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
                if (rx3.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rx3.Mensaje);
                    return;
                }
                var rx4 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
                if (rx4.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rx4.Mensaje);
                    return;
                }

                var _metodo = CalculaPrecio.metodoCalculoUtilidad.Lineal;
                if (_metCalculoUt.auto == "2") { _metodo = CalculaPrecio.metodoCalculoUtilidad.Financiero; }
                var calcula = new CalculaPrecio(rx1.Lista);
                calcula.setTasaCambio(rx2.Entidad);
                calcula.setMetodoCalculoUtilidad(_metodo);
                calcula.setPreferenciaPrecio(rx3.Entidad);
                calcula.setRedondeoPrecio(rx4.Entidad);
                var lst = calcula.Recalcula();

                var fichaOOB = new OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Ficha()
                {
                    Metodo = _metCalculoUt.descripcion,
                    Precio = lst.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.FichaPrecio()
                        {
                            idProducto = s.IdProducto,
                            Precio_1 = new OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                            {
                                pdf = s.precio_1.pdf,
                                pneto = s.precio_1.pneto,
                            },
                            Precio_2 = new OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                            {
                                pdf = s.precio_2.pdf,
                                pneto = s.precio_2.pneto,
                            },
                            Precio_3 = new OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                            {
                                pdf = s.precio_3.pdf,
                                pneto = s.precio_3.pneto,
                            },
                            Precio_4 = new OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                            {
                                pdf = s.precio_4.pdf,
                                pneto = s.precio_4.pneto,
                            },
                            Precio_5 = new OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Precio()
                            {
                                pdf = s.precio_5.pdf,
                                pneto = s.precio_5.pneto,
                            },
                        };
                        return nr;
                    }).ToList(),
                };
                var r01 = Sistema.MyData.Configuracion_SetMetodoCalculoUtilidad(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _isOk = true;
                Helpers.Msg.EditarOk();
            }
        }

        public void setMetCalculoUt (string p)
        {
            _metCalculoUt = _ldata.FirstOrDefault(f => f.auto == p);
        }

    }

}