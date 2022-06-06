using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.QR
{
    
    public class Gestion: IQR
    {


        private string _autoPrd;
        private string _producto;
        private Image _imageQR;
        private Image _imagenProducto;
        private Image _imagenTemporal;


        public string Producto { get { return _producto; } }
        public Image ImageQR { get { return _imageQR; } }
        public Image ImagenProducto { get { return _imagenProducto; } }


        public Gestion()
        {
            _producto = "";
            _imageQR = null;
            _imagenProducto = null;
        }


        QRFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new QRFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetImagen(_autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _producto = r01.Entidad.codigo+Environment.NewLine+r01.Entidad.descripcion;
            generarImagen(r01.Entidad.imagen);
            generarQR();

            return rt;
        }

        private void generarImagen(byte[] img)
        {
            if (img.Length > 0)
            {
                using (var mss = new MemoryStream(img))
                {
                    _imagenProducto = Image.FromStream(mss);
                }
            }
        }

        private void generarQR()
        {
            var _url = @"http://" + Sistema._Instancia + "/info.php?auto=" + _autoPrd;
            QrEncoder qrencoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrcode = new QrCode();
            //"http://192.168.100.10/info.php?auto="+_controlador.AutoPrd
            qrencoder.TryEncode(_url, out qrcode);
            GraphicsRenderer render = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            render.WriteToStream(qrcode.Matrix, System.Drawing.Imaging.ImageFormat.Png, ms);
            _imagenTemporal = new Bitmap(ms);
            _imageQR = new Bitmap(_imagenTemporal, new Size(new Point(280, 280)));
        }

        public void Inicializa()
        {
            _imageQR = null;
            _imagenProducto = null;
            _imagenTemporal = null;
            _autoPrd = "";
            _producto = "";
        }

        public void setFicha(string p)
        {
            _autoPrd = p;
        }

        public void ImprimirQR(System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Image img = new Bitmap(_imagenTemporal, new Size(new Point(100, 100)));
            Point loc = new Point(100, 50);
            e.Graphics.DrawImage(img, loc);
        }

    }

}