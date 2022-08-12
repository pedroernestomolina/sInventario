using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Tool.CambioMasivoPrecio
{

    public partial class CambioMasivoFrm : Form
    {


        private ICambio _controlador;


        public CambioMasivoFrm()
        {
            InitializeComponent();
            InicializaCombos();
        }

        private void InicializaCombos()
        {
            CB_PRECIO.DisplayMember = "desc";
            CB_PRECIO.ValueMember = "id";
            CB_DEPARTAMENTO.DisplayMember = "desc";
            CB_DEPARTAMENTO.ValueMember = "id";
            CB_GRUPO.DisplayMember = "desc";
            CB_GRUPO.ValueMember = "id";
            CB_DESTINO.DisplayMember = "desc";
            CB_DESTINO.ValueMember = "id";
        }

        public void setControlador(ICambio ctr)
        {
            _controlador = ctr;
        }


        private void CambioMasivoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }

        private bool _modoInicializa;
        private void CambioMasivoFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            CB_PRECIO.DataSource = _controlador.GetPrecioSource;
            CB_DEPARTAMENTO.DataSource = _controlador.GetDepartamentoSource;
            CB_GRUPO.DataSource = _controlador.GetGrupoSource;
            CB_DESTINO.DataSource = _controlador.GetDestinoSource;
            CB_PRECIO.SelectedValue = _controlador.GetPrecioId;
            CB_DEPARTAMENTO.SelectedValue = _controlador.GetDepartamentoId;
            CB_GRUPO.SelectedValue = _controlador.GetGrupoId;
            CB_DESTINO.SelectedValue = _controlador.GetDestinoId;
            _modoInicializa = false;
        }

        private void CB_PRECIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setPrecio("");
            if (CB_PRECIO.SelectedIndex != -1) 
            {
                _controlador.setPrecio(CB_PRECIO.SelectedValue.ToString());
            }
        }

        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setDepartamento("");
            if (CB_DEPARTAMENTO.SelectedIndex != -1) 
            {
                _controlador.setDepartamento(CB_DEPARTAMENTO.SelectedValue.ToString());
                LimpiarGrupo();
            }
        }
        private void LimpiarGrupo()
        {
            CB_GRUPO.SelectedIndex = -1;
        }
        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }
        private void CB_DESTINO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setDestino("");
            if (CB_DESTINO.SelectedIndex != -1)
            {
                _controlador.setDestino(CB_DESTINO.SelectedValue.ToString());
            }
        }

        private void L_PRECIO_Click(object sender, EventArgs e)
        {
            CB_PRECIO.SelectedIndex = -1;
        }
        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            CB_DEPARTAMENTO.SelectedIndex = -1;
            CB_GRUPO.SelectedIndex = -1;
        }
        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            CB_GRUPO.SelectedIndex = -1;
        }
        private void L_DESTINO_Click(object sender, EventArgs e)
        {
            CB_DESTINO.SelectedIndex = -1;
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
    
    }

}