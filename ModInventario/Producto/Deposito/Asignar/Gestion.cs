using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.Asignar
{
    
    public class Gestion
    {

        private string autoPrd;
        private List<data> depositos;
        private BindingList<data> bldepositos;
        private BindingSource bs;
        private bool _isCerrarHabilitado;
        private string producto;
        private OOB.LibInventario.Producto.Depositos.Lista.Ficha prdDep;
        private bool _marcarTodas;
        private bool _preDeterminiadas;


        public bool IsCerrarHabilitado { get { return _isCerrarHabilitado; } }
        public string Producto { get { return producto; } }
        public BindingSource Source { get { return bs; } }


        public Gestion()
        {
            autoPrd = "";
            producto = "";
            depositos = new List<data>();
            bldepositos = new BindingList<data>(depositos);
            bs = new BindingSource();
            bs.DataSource = bldepositos;
            _marcarTodas = false;
            _preDeterminiadas = false;
        }


        public void setFicha(string auto)
        {
            autoPrd=auto;
        }

        AsignarFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AsignarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            _marcarTodas = false;
            _preDeterminiadas = false;
            producto = "";
            depositos.Clear();
        }

        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Deposito_GetLista();
                foreach (var it in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    bldepositos.Add(new data(it));
                }

                var r02 = Sistema.MyData.Producto_GetDepositos(autoPrd);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return false;
                }
                prdDep = r02.Entidad;
                producto = r02.Entidad.codigoPrd + Environment.NewLine + r02.Entidad.descripcionPrd;
                foreach (var it in r02.Entidad.depositos)
                {
                    var dep = depositos.FirstOrDefault(f => f.auto == it.auto);
                    if (dep != null)
                    {
                        dep.setAsignado();
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

        public void Procesar()
        {
            var msg = "Procesar Cambios ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                _isCerrarHabilitado = Guardar();
            }
            else
            {
                _isCerrarHabilitado = false;
            }
        }

        private bool Guardar()
        {
            var rt = true;

            var list = depositos.Where(w => w.asignar && w.asignado == false).Select(s =>
            {
                var nr = new OOB.LibInventario.Producto.Depositos.Asignar.DepAsignar()
                {
                    autoDeposito = s.auto,
                    averia = 0.0m,
                    disponible = 0.0m,
                    fechaUltConteo = new DateTime(2000, 01, 01),
                    fisica = 0.0m,
                    nivel_minimo = 0.0m,
                    nivel_optimo = 0.0m,
                    pto_pedido = 0.0m,
                    reservada = 0.0m,
                    resultadoUltConteo = 0.0m,
                    ubicacion_1 = "",
                    ubicacion_2 = "",
                    ubicacion_3 = "",
                    ubicacion_4 = "",
                };
                return nr;
            }).ToList();

            var listR = depositos.Where(w => w.remover && w.asignado).Select(s =>
            {
                var nr = new OOB.LibInventario.Producto.Depositos.Asignar.DepRemover()
                {
                    autoDeposito = s.auto,
                };
                return nr;
            }).ToList();

            if (list.Count == 0 && listR.Count == 0)
            {
                Helpers.Msg.Error("NO SE HAN ASIGNADOS / REMOVIDOS DEPOSITOS A ESTE PRODUCTO");
                return false;
            }

            var ficha = new OOB.LibInventario.Producto.Depositos.Asignar.Ficha()
            {
                autoProducto = autoPrd,
                depAsignar = list,
                depRemover=listR
            };
            var r01 = Sistema.MyData.Producto_AsignarRemoverDepositos(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            
            return rt;
        }

        public void InicializarIsCerrarHabilitado()
        {
            _isCerrarHabilitado = true;
        }

        public void Marcar()
        {
            var it = (data)bs.Current;
            if (it != null)
            {
                if (it.asignado) 
                {
                    it.asignar = true;
                    it.remover = false;
                }
                it.remover = false;
            }
        }
        private void MarcarDeposito(data it)
        {
            if (it != null)
            {
                if (!it.asignado)
                {
                    it.asignar = true;
                    it.remover = false;
                }
                it.remover = false;
            }
        }

        public void DesMarcarV()
        {
            var it = (data)bs.Current;
            if (it != null)
            {
                if (it.asignado)
                {
                    Helpers.Msg.Error("NO PUEDES DESMARCAR ESTE DEPOSITO");
                    it.asignar = true;
                }
            }
        }

        public void DesMarcar()
        {
            var it = (data)bs.Current;
            if (it != null)
            {
                if (it.asignado)
                {
                    it.remover = !it.remover;
                }
            }
        }
        private void DesMarcarDeposito(data it)
        {
            if (it != null)
            {
                if (!it.asignado)
                {
                    it.remover = true;
                    it.asignar = false;
                }
            }
        }

        public void SeleccionarTodas()
        {
            _marcarTodas = !_marcarTodas;
            foreach (var dep in bldepositos) 
            {
                if (_marcarTodas )
                {
                    MarcarDeposito(dep);
                }
                else
                {
                    DesMarcarDeposito(dep);
                }
            }
            bs.CurrencyManager.Refresh();
        }

        public void SeleccionarPreDeterminada()
        {
            _preDeterminiadas = !_preDeterminiadas;
            foreach (var dep in bldepositos.Where(w => w.Deposito.IsPerDeterminado))
            {
                if (_preDeterminiadas)
                {
                    MarcarDeposito(dep);
                }
                else 
                {
                    DesMarcarDeposito(dep);
                }
            }
            bs.CurrencyManager.Refresh();
        }

    }

}