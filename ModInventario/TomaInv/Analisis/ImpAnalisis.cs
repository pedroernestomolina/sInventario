using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.TomaInv.Analisis
{
    public class ImpAnalisis: IAnalisis
    {
        private RecopilarData.IRecopilar _recopilarData;
        private string _idTomaAnalizar;
        private ILista _lista;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;
        private OOB.LibInventario.TomaInv.Analisis.Ficha _tomaAnalizar;


        public BindingSource GetSource { get { return _lista.GetDataSource; } }
        public int CntItem { get { return _lista.CntItem; } }


        public ImpAnalisis()
        {
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _idTomaAnalizar = "";
            _lista = new ImpLista();
            _recopilarData = new RecopilarData.ImpRecopilar();
            _tomaAnalizar = null;
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _idTomaAnalizar = "";
            _lista.Inicializa();
            _tomaAnalizar = null;
        }
        private Frm frm;
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

        public void setTomaInvAnalizar(string idToma)
        {
            _idTomaAnalizar = idToma;
        }


        public void EliminarTomas()
        {
            var _lst = _lista.GetLista.Where(w => w.Eliminar && w.Estado != data.enumAnalisis.SinDefinir).ToList();
            if (_lst.Count <= 0) 
            {
                Helpers.Msg.Alerta("NO HAY ITEMS SELECCIONADOS / DOCUMETOS SELECCIONADOS ESTAN SIN DEFINIR");
                return;
            }

            var msg = "Eliminar Estos Conteos ?";
            var resp = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.No) 
            {
                return;
            }
            var ficha = new OOB.LibInventario.TomaInv.RechazarItem.Ficha()
            {
                IdToma = _idTomaAnalizar, 
                Items = _lst.Select(s =>
                {
                    var nr = new OOB.LibInventario.TomaInv.RechazarItem.Item()
                    {
                        IdPrd = s.itemAnalisis.idPrd,
                    };
                    return nr;
                }).ToList(),
            };
            try
            {
                var r01 = Sistema.MyData.TomaInv_RechazarItemToma(ficha);
                _lista.setEliminarItems(_lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        public void ImprimirAnalisis()
        {
            if (_lista.GetLista.Count() <= 0)
            {
                Helpers.Msg.Alerta("NO HAY ITEMS");
                return;
            }
            var _list = _lista.GetLista.Select(s =>
            {
                var _signo = 0;
                if (s.Estado == data.enumAnalisis.Sobra)
                {
                    _signo = 1;
                }
                else if (s.Estado == data.enumAnalisis.Falta)
                {
                    _signo = -1;
                }
                else if (s.Estado == data.enumAnalisis.OK)
                {
                    _signo = 0;
                }
                var nr = new Reportes.TomaInv.AnalisisResultado.item()
                {
                    cant = s.Diferencia,
                    descToma = s.Estado.ToString(),
                    producto = s.CodigoPrd.Trim() + Environment.NewLine + s.DescPrd.Trim(),
                    signo = _signo,
                    motivo = s.itemAnalisis.motivo,
                };
                return nr;
            }).ToList();
            var ficha = new Reportes.TomaInv.AnalisisResultado.data()
            {
                items = _list,
                solicitudNro = _tomaAnalizar.solicitudNro,
                sucursal =_tomaAnalizar.sucursal,
                deposito =_tomaAnalizar.deposito,
            };
            var rp = new Reportes.TomaInv.AnalisisResultado.gestionRep();
            rp.setData(ficha);
            rp.Generar();
        }


        private bool CargarData()
        {
            try
            {
                var r00 = Sistema.MyData.TomaInv_Analizar_TomaDisponible();
                if (r00.Entidad == "") 
                {
                    throw new Exception("NO HAY TOMAS DISPONIBLE QUE ANALIZAR");
                }
                _idTomaAnalizar = r00.Entidad;
                var r01 = Sistema.MyData.TomaInv_Analisis(_idTomaAnalizar);
                _tomaAnalizar = r01.Entidad;

                var _lst = new List<TomaInv.Analisis.data>();
                foreach (var rg in r01.Entidad.Items.OrderBy(o=>o.descPrd).ToList())
                {
                    _lst.Add(new TomaInv.Analisis.data(rg));
                }
                _lista.setDataListar(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        public void setMarcarTodas(bool m)
        {
            _lista.setMarcarTodas(m);
        }

        public void RefrescarVista()
        {
            try
            {
                var r01 = Sistema.MyData.TomaInv_Analisis(_idTomaAnalizar);
                var _lst = new List<TomaInv.Analisis.data>();
                foreach (var rg in r01.Entidad.Items.OrderBy(o => o.descPrd).ToList())
                {
                    _lst.Add(new TomaInv.Analisis.data(rg));
                }
                _lista.setDataListar(_lst);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }

        public void MostrarConteo()
        {
            if (_lista.ItemActual != null)
            {
                var _item = _lista.ItemActual;
                var _st = new StringBuilder();
                var s1 = string.Format("{0,6} ", _item.conteoPorEmpCompra) + _item.descEmpCompra;
                var s2 = string.Format("{0,6} ", _item.conteoPorEmpInv) + _item.descEmpInv;
                var s3 = string.Format("{0,6} ", _item.conteoPorEmpUnd) + _item.descEmpUnd;
                _st.AppendLine();
                _st.AppendLine(s1);
                _st.AppendLine(s2);
                _st.AppendLine(s3);
                MessageBox.Show(_st.ToString());
            }
        }

        private Motivo.IMotivo _motivo;
        public void EditarItem()
        {
            if (_lista.ItemActual != null) 
            {
                var _item = _lista.ItemActual;
                if (_item.Estado != data.enumAnalisis.SinDefinir) 
                {
                    try
                    {
                        var fichaOOB = new OOB.LibInventario.TomaInv.Analisis.Motivo.Obtener.Ficha()
                        {
                            idPrd = _item.itemAnalisis.idPrd,
                            idToma = _idTomaAnalizar,
                        };
                        var r01 = Sistema.MyData.TomaInv_AnalizarToma_GetMotivo(fichaOOB);
                        if (_motivo == null)
                        {
                            _motivo = new Motivo.ImpMotivo();
                        }
                        _motivo.Inicializa();
                        _motivo.setMotivo(r01.Entidad);
                        _motivo.Inicia();
                        if (_motivo.ProcesarIsOk) 
                        {
                            var fichaSetOOB = new OOB.LibInventario.TomaInv.Analisis.Motivo.Cambiar.Ficha()
                            {
                                idPrd = _item.itemAnalisis.idPrd,
                                idToma = _idTomaAnalizar,
                                motivo = _motivo.GetMotivo,
                            };
                            var r02 = Sistema.MyData.TomaInv_AnalizarToma_SetMotivo(fichaSetOOB);
                            _item.setMotivo(_motivo.GetMotivo);
                            Helpers.Msg.EditarOk();
                        }
                    }
                    catch (Exception e)
                    {
                        Helpers.Msg.Error(e.Message);
                        return;
                    }
                }
            }
        }

        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            ProcesarToma();
        }

        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }


        public void ProcesarToma()
        {
            _procesarIsOk = false;
            if (_lista.GetLista.Count() <= 0)
            {
                Helpers.Msg.Alerta("NO HAY ITEMS");
                return;
            }
            var _cnt = _lista.GetLista.Where(w => w.Estado == data.enumAnalisis.SinDefinir).Count();
            if (_cnt > 0)
            {
                var ms = "!! FALTAN PRODUCTOS POR REALIZAR TOMAS !!!, ESTAS DE ACUERDO EN REALIZAR EL FIN DEL CONTEO ?";
                var rst = MessageBox.Show(ms, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rst == DialogResult.No)
                {
                    return;
                }
            }
            _recopilarData.Inicializa();
            _recopilarData.Inicia();
            if (_recopilarData.ProcesarIsOk) 
            {
                Procesar();
            }
        }
        private void Procesar()
        {
            var _lst = _lista.GetLista.Where(w=>w.Estado!= data.enumAnalisis.SinDefinir).ToList();
            var ficha = new OOB.LibInventario.TomaInv.Procesar.Ficha()
            {
                autoriza = _recopilarData.Autorizado_GetData,
                cntItems = _lst.Count,
                idToma = _idTomaAnalizar,
                observaciones = _recopilarData.Motivo_GetData,
                items = _lst.Select(s =>
                {
                    var _signo = 0;
                    if (s.Estado == data.enumAnalisis.Sobra)
                    {
                        _signo = 1;
                    }
                    else if (s.Estado == data.enumAnalisis.Falta)
                    {
                        _signo = -1;
                    }
                    else if (s.Estado == data.enumAnalisis.OK)
                    {
                        _signo = 0;
                    }
                    var nr = new OOB.LibInventario.TomaInv.Procesar.Item()
                    {
                        diferencia = Math.Abs(s.Diferencia),
                        estadoDesc = s.Estado.ToString(),
                        idProducto = s.itemAnalisis.idPrd,
                        signo = _signo,
                        estatusDivisa= s.itemAnalisis.estatusDivisa,
                        costoMonDivisa = s.itemAnalisis.costoMonDivisa,
                        costoMonLocal= s.itemAnalisis.costoMonLocal,
                        contEmpCompra = s.itemAnalisis.contEmpCompra,
                    };
                    return nr;
                }).ToList(),
            };
            try
            {
                var r01 = Sistema.MyData.TomaInv_Procesar(ficha);
                _procesarIsOk = true;
                Helpers.Msg.AgregarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }
    }
}