using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Tool.CambioMasivoPrecio
{
   
    public class Cambio: ICambio
    {

        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private FiltrosGen.IOpcion _gPrecio;
        private FiltrosGen.IOpcion _gDepartamento;
        private FiltrosGen.IOpcion _gGrupo;
        private FiltrosGen.IOpcion _gDestino;


        public Cambio() 
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _gPrecio = new FiltrosGen.Opcion.Gestion();
            _gDepartamento = new FiltrosGen.Opcion.Gestion();
            _gGrupo = new FiltrosGen.Opcion.Gestion();
            _gDestino = new FiltrosGen.Opcion.Gestion();
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _gPrecio.Inicializa();
            _gDepartamento.Inicializa();
            _gGrupo.Inicializa();
            _gDestino.Inicializa();
        }
        private CambioMasivoFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new CambioMasivoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = false;
            var xmsg = "Abandonar Cambios Ficha ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            if (_gPrecio.GetId == "") 
            {
                Helpers.Msg.Error("CAMPO [ TIPO PRECIO ORIGEN ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (_gDestino.GetId == "")
            {
                Helpers.Msg.Error("CAMPO [ TIPO PRECIO DESTINO ] NO PUEDE ESTAR VACIO");
                return;
            }

            var xmsg = "Esta Opción Permite Mover Los Precios Asignado de los Productos, Tal Operación debe realizarse con mucho cuidado, Esta De Acuerdo En Continuar ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                xmsg = "Validar Procesar Cambios ?";
                msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg != DialogResult.Yes) 
                {
                    return;
                }

                var ficha = new OOB.LibInventario.Tool.CambioMasivoPrecio.Ficha()
                {
                    codigoPrecioDestino = _gDestino.Item.codigo,
                    codigoPrecioOrigen = _gPrecio.Item.codigo,
                    idGrupo = _gGrupo.GetId,
                    idDepartamento = _gDepartamento.GetId,
                };
                var r01 = Sistema.MyData.Tools_CambioMasivoPrecio(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk = true;
                Helpers.Msg.EditarOk();
            }
        }


        private bool CargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Departamento_GetLista();
                var _lst_1 = r01.Lista.OrderBy(o => o.nombre).Select(s =>
                {
                    var nr = new ficha()
                    {
                        codigo = "",
                        desc = s.nombre,
                        id = s.auto,
                    };
                    return nr;
                }).ToList();
                _gDepartamento.setData(_lst_1);

                var r02 = Sistema.MyData.Sistema_TipoPreciosDefinidos_Lista();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return false;
                }
                var _lst_2 = r02.Lista.Select(s =>
                {
                    var nr = new ficha()
                    {
                        codigo = s.codigo,
                        desc = s.descripcion,
                        id = s.id,
                    };
                    return nr;
                }).ToList();
                _gPrecio.setData(_lst_2);
                _gDestino.setData(_lst_2);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
            return true;
        }


        public BindingSource GetPrecioSource { get { return _gPrecio.Source; } }
        public BindingSource GetDepartamentoSource{ get { return _gDepartamento.Source; } }
        public BindingSource GetGrupoSource { get { return _gGrupo.Source; } }
        public BindingSource GetDestinoSource { get { return _gDestino.Source; } }

        public string GetPrecioId { get { return _gPrecio.GetId; } }
        public string GetDepartamentoId { get { return _gDepartamento.GetId; } }
        public string GetGrupoId { get { return _gGrupo.GetId; } }
        public string GetDestinoId { get { return _gDestino.GetId; } }

        public void setPrecio(string id)
        {
            _gPrecio.setFicha(id);
        }
        public void setDepartamento(string id)
        {
            _gDepartamento.setFicha(id);
            _gGrupo.Inicializa();
            var _lst = new List<ficha>();
            if (id != "")
            {
                try
                {
                    var r01 = Sistema.MyData.Grupo_GetListaByIdDepartamento(id);
                    _lst = r01.Lista.OrderBy(o => o.nombre).Select(s =>
                    {
                        var nr = new ficha()
                        {
                            codigo = "",
                            desc = s.nombre,
                            id = s.auto,
                        };
                        return nr;
                    }).ToList();
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
            _gGrupo.setData(_lst);
        }
        public void setGrupo(string id)
        {
            _gGrupo.setFicha(id);
        }
        public void setDestino(string id)
        {
            _gDestino.setFicha(id);
        }

    }

}