using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Estatus
{

    public partial class EstatusFrm : Form
    {

        private Gestion _controlador;


        public EstatusFrm()
        {
            InitializeComponent();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void EstatusFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.Producto;
            switch (_controlador.EstatusActual) 
            {
                case OOB.LibInventario.Producto.Enumerados.EnumEstatus.Activo:
                    RB_ACTIVO.Checked = true;
                    break;
                case OOB.LibInventario.Producto.Enumerados.EnumEstatus.Suspendido:
                    RB_SUSPENDIDO.Checked = true;
                    break;
                case OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo:
                    RB_INACTIVO.Checked = true;
                    break;
            }
        }

        private void RB_ACTIVO_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setEstatusActivo();
        }

        private void RB_SUSPENDIDO_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setEstatusSuspendido();
        }

        private void RB_INACTIVO_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setEstatusInactivo();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.HabilitarCierre)
            {
                Salir();
            }
        }

        private void EstatusFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_controlador.HabilitarCierre;
            _controlador.setInicializarHabilitarCierre();
        }

    }

}