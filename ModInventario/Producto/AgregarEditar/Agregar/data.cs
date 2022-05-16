﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.AgregarEditar.Agregar
{
    
    public class data
    {

        private int _contEmpCompra;
        private int _contEmpInv;
        private ficha _empCompra;
        private ficha _empInv;


        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string NombreProducto { get; set; }
        public string ReferenciaProducto { get; set; }
        public string ModeloProducto { get; set; }
        public string AutoDepartamento { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoMarca { get; set; }
        public string AutoImpuesto { get; set; }
        public string IdOrigen { get; set; }
        public string IdCategoria { get; set; }
        public string IdClasificacionAbc { get; set; }
        public string IdDivisa { get; set; }
        public byte[] Imagen { get; set; }
        public string Plu { get; set; }
        public int DiasEmpaque { get; set; }
        public bool EsPesado { get; set; }
        public bool ActivarCatalogo { get; set; }


        //
        public int ContEmpProducto { get { return _contEmpCompra; } }
        public int ContEmpInv { get { return _contEmpInv; } }
        public ficha EmpCompra { get { return _empCompra; } }
        public ficha EmpInv { get { return _empInv; } }


        public data()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            _contEmpCompra = 1;
            _contEmpInv = 1;
            _empCompra = null;
            _empInv = null;

            Codigo = "";
            Descripcion = "";
            NombreProducto = "";
            ModeloProducto = "";
            ReferenciaProducto = "";
            AutoDepartamento = "";
            AutoGrupo = "";
            AutoMarca = "";
            AutoImpuesto = "";
            IdOrigen = "";
            IdCategoria = "";
            IdClasificacionAbc = "";
            IdDivisa = "";
            Imagen = new byte[] { };
            Plu = "";
            DiasEmpaque = 0;
            EsPesado = false;
            ActivarCatalogo = false;
        }

        public string Clasificacion
        {
            get
            {
                var rt = "";
                switch (IdClasificacionAbc)
                {
                    case "1":
                        rt = "A";
                        break;
                    case "2":
                        rt = "B";
                        break;
                    case "3":
                        rt = "C";
                        break;
                    case "4":
                        rt = "D";
                        break;
                }
                return rt;
            }
        }

        public string Categoria
        {
            get
            {
                var rt = "";
                switch (IdCategoria)
                {
                    case "1":
                        rt = "Producto Terminado";
                        break;
                    case "2":
                        rt = "Bien de Servicio";
                        break;
                    case "3":
                        rt = "Materia Prima";
                        break;
                    case "4":
                        rt = "Uso Interno";
                        break;
                    case "5":
                        rt = "Sub Producto";
                        break;
                }
                return rt;
            }
        }

        public string Divisa
        {
            get
            {
                var rt = "";
                switch (IdDivisa)
                {
                    case "1":
                        rt = "1";
                        break;
                    case "2":
                        rt = "0";
                        break;
                }
                return rt;
            }
        }

        public string Origen
        {
            get
            {
                var rt = "";
                switch (IdOrigen)
                {
                    case "1":
                        rt = "Nacional";
                        break;
                    case "2":
                        rt = "Importado";
                        break;
                }
                return rt;
            }
        }

        public bool IsOk()
        {
            var rt = true;

            if (Descripcion.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ DESCRIPCION ] DEBE SER LLENADO");
                return false;
            }

            if (AutoDepartamento.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ DEPARTAMENTO ] DEBE SER LLENADO");
                return false;
            }

            if (AutoGrupo.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ GRUPO ] DEBE SER LLENADO");
                return false;
            }

            if (AutoMarca.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ MARCA ] DEBE SER LLENADO");
                return false;
            }


            if (EmpCompra == null)
            {
                Helpers.Msg.Error("CAMPO [ EMPAQUE COMPRA ] DEBE SER LLENADO");
                return false;
            }
            if (ContEmpProducto <= 0)
            {
                Helpers.Msg.Error("CAMPO [ CONTENIDO EMPAQUE COMPRA ] INCORRECTO");
                return false;
            }
            if (EmpInv == null)
            {
                Helpers.Msg.Error("CAMPO [ EMPAQUE INVENTARIO ] DEBE SER LLENADO");
                return false;
            }
            if (ContEmpInv <= 0)
            {
                Helpers.Msg.Error("CAMPO [ CONTENIDO EMPAQUE INVENTARIO ] INCORRECTO");
                return false;
            }


            if (AutoImpuesto.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ TASA IMPUESTO ] DEBE SER LLENADO");
                return false;
            }

            if (IdOrigen.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ ORIGEN ] DEBE SER LLENADO");
                return false;
            }

            if (IdCategoria.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ CATEGORIA ] DEBE SER LLENADO");
                return false;
            }

            if (IdDivisa.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ ADMINISTRADO x DIVISA ] DEBE SER LLENADO");
                return false;
            }

            if (IdClasificacionAbc.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ CLASIFICACION ] DEBE SER LLENADO");
                return false;
            }

            if (EsPesado) 
            {
                if (Plu.Trim() == "") 
                {
                    Helpers.Msg.Error("CAMPO [ PLU ] DEBE SER LLENADO");
                    return false;
                }
            }

            return rt;
        }

        public void setFicha(string dept, string grupo, string marca, string imp, string origen, string categoria, string clasificacion, string admDivisa)
        {
            AutoDepartamento = dept;
            AutoGrupo = grupo;
            AutoMarca = marca;
            AutoImpuesto = imp;
            IdOrigen = origen;
            IdCategoria= categoria;
            IdClasificacionAbc = clasificacion;
            IdDivisa = admDivisa;
        }


        public void setContEmpCompra(int cont)
        {
            _contEmpCompra = cont;
        }
        public void setContEmpInv(int cont)
        {
            _contEmpInv = cont;
        }
        public void setEmpCompra(ficha ent)
        {
            _empCompra = ent;
        }
        public void setEmpInv(ficha ent)
        {
            _empInv = ent;
        }

    }

}