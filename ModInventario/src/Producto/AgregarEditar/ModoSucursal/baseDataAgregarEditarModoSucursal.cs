using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal
{
    
    public class baseDataAgregarEditarModoSucursal: baseDataAgregarEditar
    {

        private string _modelo;
        private string _referencia;
        private int _contEmpInv;
        private decimal _peso;
        private decimal _volumen;
        private decimal _alto;
        private decimal _largo;
        private decimal _ancho;
        private bool _activarCatalogo;
        private byte[] _img;
        private ficha _empInv;


        public string GetModeloProducto { get { return _modelo; } }
        public string GetReferenciaProducto { get { return _referencia; } }
        public int GetContEmpInv { get { return _contEmpInv; } }
        public decimal GetPeso { get { return _peso; } }
        public decimal GetVolumen { get { return _volumen; } }
        public decimal GetLargo { get { return _largo; } }
        public decimal GetAlto { get { return _alto; } }
        public decimal GetAncho { get { return _ancho; } }
        public bool GetActivarCatlogo { get { return _activarCatalogo; } }
        public byte[] GetImagen { get { return _img; } }
        public ficha GetEmpInv { get { return _empInv; } }

        
        public baseDataAgregarEditarModoSucursal()
            :base()
        {
            _modelo = "";
            _referencia = "";
            _contEmpInv = 0;
            _peso = 0m;
            _volumen = 0m;
            _alto = 0m;
            _largo = 0m;
            _ancho = 0m;
            _activarCatalogo = false;
            _img = new byte[] { };
            _empInv = null;
        }


        public override void Inicializa()
        {
            base.Inicializa();
            _modelo = "";
            _referencia = "";
            _contEmpInv = 0;
            _peso = 0m;
            _volumen = 0m;
            _alto = 0m;
            _largo = 0m;
            _ancho = 0m;
            _activarCatalogo = false;
            _img = new byte[] { };
            _empInv = null;
        }


        public void setContEmpInv(int v)
        {
            _contEmpInv = v;
        }
        public void setModeloProducto(string d)
        {
            _modelo = d;
        }
        public void setReferenciaProducto(string d)
        {
            _referencia = d;
        }
        public void setPeso(decimal v)
        {
            _peso = v;
        }
        public void setVolumen(decimal v)
        {
            _volumen = v;
        }
        public void setAlto(decimal v)
        {
            _alto = v;
        }
        public void setLargo(decimal v)
        {
            _largo = v;
        }
        public void setAncho(decimal v)
        {
            _ancho = v;
        }
        public void setActivarCatlogo(bool b)
        {
            _activarCatalogo = b;
        }
        public void setEmpInv(ficha f)
        {
            _empInv = f;
        }
        public void setImagen(Image img)
        {
            _img = new byte[] { };
            if (img !=null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    _img = ms.ToArray();
                }
            }
        }
        public void setImagenRaw(byte[] img)
        {
            _img = img;
        }


        public override bool ValidarDataIsOk()
        {
            if (base.ValidarDataIsOk())
            {
                if (_empInv == null || _empInv.id == "")
                {
                    Helpers.Msg.Error("CAMPO [ EMPAQUE INVENTARIO ] NO PUEDE ESTAR VACIO");
                    return false;
                }
                if (_contEmpInv == 0)
                {
                    Helpers.Msg.Error("CAMPO [ CONTENIDO EMPAQUE INVENTARIO ] NO PUEDE SER CERO(0)");
                    return false;
                }
                if (_ancho>9999.99m)
                {
                    Helpers.Msg.Error("CAMPO [ ANCHO ] NO PUEDE SER MAYOR A 9.999,99");
                    return false;
                }
                if (_largo > 9999.99m)
                {
                    Helpers.Msg.Error("CAMPO [ LARGO ] NO PUEDE SER MAYOR A 9.999,99");
                    return false;
                }
                if (_alto > 9999.99m)
                {
                    Helpers.Msg.Error("CAMPO [ ALTO ] NO PUEDE SER MAYOR A 9.999,99");
                    return false;
                }
                if (_peso > 9999.999m)
                {
                    Helpers.Msg.Error("CAMPO [ PESO ] NO PUEDE SER MAYOR A 9.999,999");
                    return false;
                }
                if (_volumen > 99999999.999999m)
                {
                    Helpers.Msg.Error("CAMPO [ VOLUMEN ] NO PUEDE SER MAYOR A 99.999,99");
                    return false;
                }

                return true;
            }
            else 
            {
                return false;
            }
        }

    }

}