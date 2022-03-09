using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv
{

    public class Gestion : IMaestro
    {

        private ILista _gLista;
        private IMaestroTipo _gTipoMaestro;


        public string Titulo { get { return _gTipoMaestro.Titulo; } }
        public int CntItems { get { return _gLista.CntItems; } }
        public BindingSource Source { get { return _gLista.Source; } }
        public bool AgregarIsOk { get { return _gTipoMaestro.AgregarIsOk; } }
        public bool EditarIsOk { get { return _gTipoMaestro.EditarIsOk; } }
        public bool EliminarIsOK { get { return _gTipoMaestro.EliminarIsOK; } }
        public data ItemActual { get { return _gLista.ItemActual; } }


        public Gestion(ILista ctrLista)
        {
            _gLista = ctrLista;
        }


        public void setGestion(IMaestroTipo ctr)
        {
            _gTipoMaestro = ctr;
        }

        public void Inicializa()
        {
            _gLista.Inicializa();
        }

        MaestroFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new MaestroFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool CargarData()
        {
            if (_gTipoMaestro.CargarData())
            {
                _gLista.setLista(_gTipoMaestro.ListaData);
                return true;
            }
            return false;
        }

        public void AgregarItem()
        {
            _gTipoMaestro.AgregarItem();
            if (_gTipoMaestro.AgregarIsOk)
            {
                _gLista.Agregar(_gTipoMaestro.ItemAgregarEditar);
            }
        }

        public void EditarItem()
        {
            if (ItemActual != null)
            {
                _gTipoMaestro.EditarItem(ItemActual.auto);
                if (_gTipoMaestro.EditarIsOk)
                {
                    _gLista.Actualizar(_gTipoMaestro.ItemAgregarEditar);
                }
            }
        }

        public void EliminarItem()
        {
            if (ItemActual != null)
            {
                _gTipoMaestro.EliminarItem(ItemActual.auto);
                if (_gTipoMaestro.EliminarIsOK)
                {
                    _gLista.EliminarItemActual();
                }
            }
        }

    }

}