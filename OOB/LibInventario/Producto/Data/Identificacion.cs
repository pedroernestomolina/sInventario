using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Identificacion
    {

        public string auto { get; set; }
        public string autoDepartamento { get; set; }
        public string autoGrupo { get; set; }
        public string autoMarca { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string modelo { get; set; }
        public string referencia { get; set; }
        public int contenidoCompra { get; set; }
        public string empaqueCompra { get; set; }
        public string empInv { get; set; }
        public int contEmpInv { get; set; }
        public string Decimales { get; set; }
        public Enumerados.EnumOrigen origen { get; set; }
        public Enumerados.EnumCategoria categoria { get; set; }
        public Enumerados.EnumEstatus estatus { get; set; }
        public Enumerados.EnumAdministradorPorDivisa AdmPorDivisa { get; set; }
        public string departamento { get; set; }
        public string codigoDepartamento { get; set; }
        public string grupo { get; set; }
        public string codigoGrupo { get; set; }
        public string marca { get; set; }
        public decimal tasaIva { get; set; }
        public string nombreTasaIva { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime? fechaBaja { get; set; }
        public DateTime? fechaUltActualizacion { get; set; }
        public string tipoABC { get; set; }
        public string comentarios { get; set; }
        public string advertencia { get; set; }
        public string presentacion { get; set; }
        public Enumerados.EnumCatalogo activarCatalogo { get; set; }
        public string estatusPesado { get; set; }
        public string plu { get; set; }
        public int diasEmpaque { get; set; }
        public List<CodAlterno> codAlterno { get; set; }

        public bool IsInactivo { get { return estatus == Enumerados.EnumEstatus.Inactivo ? true : false; } }
        public bool IsPesado { get { return estatusPesado.Trim().ToUpper() == "1" ? true : false; } }
        public string categoriaDesc 
        {
            get 
            { 
                var rt="";
                switch (categoria)
                {
                    case Enumerados.EnumCategoria.ProductoTerminado:
                        rt="Prod Terminado";
                        break;
                    case Enumerados.EnumCategoria.BienServicio:
                        rt = "Bien Servicio";
                        break;
                    case Enumerados.EnumCategoria.MateriaPrima:
                        rt = "Materia Prima";
                        break;
                    case Enumerados.EnumCategoria.UsoInterno:
                        rt = "Uso Interno";
                        break;
                    case Enumerados.EnumCategoria.SubProducto:
                        rt = "SubProducto";
                        break;
                }
                return rt;
            } 
        }


        public Identificacion()
        {
            auto = "";
            autoDepartamento = "";
            autoGrupo = "";
            autoMarca = "";

            codigo = "";
            nombre = "";
            descripcion = "";
            modelo = "";
            referencia = "";
            contenidoCompra = 1;
            empaqueCompra = "";
            empInv = "";
            contEmpInv = 1;
            Decimales = "0";
            origen = Enumerados.EnumOrigen.SnDefinir;
            categoria = Enumerados.EnumCategoria.SnDefinir;
            estatus = Enumerados.EnumEstatus.SnDefinir;
            AdmPorDivisa = Enumerados.EnumAdministradorPorDivisa.SnDefinir;
            departamento = "";
            codigoDepartamento = "";
            grupo = "";
            codigoGrupo = "";
            marca = "";
            tasaIva = 0.0m;
            nombreTasaIva = "";
            fechaAlta = DateTime.Now.Date;
            fechaBaja = null;
            fechaUltActualizacion = null;
            tipoABC = "";
            comentarios = "";
            advertencia = "";
            presentacion = "";
            activarCatalogo = Enumerados.EnumCatalogo.SnDefinir;
            estatusPesado = "";
            plu = "";
            diasEmpaque = 0;
            codAlterno = new List<CodAlterno>();
        }

        public Identificacion(Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha ficha)
            : this()
        {
            auto = ficha.autoPrd;
            autoDepartamento = ficha.autoDepartamento;
            autoGrupo = ficha.autoGrupo;
            codigo = ficha.codigoPrd;
            nombre = ficha.nombrePrd;
            descripcion = ficha.nombrePrd;
            contenidoCompra = ficha.empCompraCont;
            empaqueCompra = ficha.empCompra;
            Decimales = ficha.decimales;
            fechaUltActualizacion=ficha.fechaUltActualizacion;
            tasaIva=ficha.tasaIva;
            nombreTasaIva=ficha.tasaIvaNombre;
            switch (ficha.categoria.Trim().ToUpper())
            {
                case "PRODUCTO TERMINADO":
                    categoria = Enumerados.EnumCategoria.ProductoTerminado; 
                    break;
                case "BIEN DE SERVICIO":
                    categoria = Enumerados.EnumCategoria.BienServicio;
                    break;
                case "MATERIA PRIMA":
                    categoria = Enumerados.EnumCategoria.MateriaPrima;
                    break;
                case "USO INTERNO":
                    categoria = Enumerados.EnumCategoria.UsoInterno;
                    break;
                case "SUB PRODUCTO":
                    categoria = Enumerados.EnumCategoria.SubProducto;
                    break;
            }
            estatus = Enumerados.EnumEstatus.Activo;
            AdmPorDivisa = ficha.AdmDivisa ? Enumerados.EnumAdministradorPorDivisa.Si : Enumerados.EnumAdministradorPorDivisa.No;
            tasaIva = 0.0m;
            nombreTasaIva = "";
        }


        public string Empaque 
        {
            get 
            { 
                var r="";
                r = empaqueCompra + "(" + contenidoCompra.ToString("n0") + ")";
                return r;
            } 
        }

        public string Impuesto 
        { 
            get 
            {
                var r = "EXENTO";
                if (tasaIva != 0.0m) 
                {
                    r = tasaIva.ToString("n2").PadLeft(5, '0') + "%," + nombreTasaIva;
                }
                return r;
            } 
        }

    }

}