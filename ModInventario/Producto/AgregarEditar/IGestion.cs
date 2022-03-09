﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.AgregarEditar
{
    
    public interface IGestion
    {


        bool IsCerrarHabilitado { get; }
        System.Windows.Forms.BindingSource Departamentos { get; }
        System.Windows.Forms.BindingSource Grupos { get; }
        System.Windows.Forms.BindingSource Marcas { get; }
        System.Windows.Forms.BindingSource Impuesto { get; }
        System.Windows.Forms.BindingSource Origen { get; }
        System.Windows.Forms.BindingSource EmpCompra { get; }
        System.Windows.Forms.BindingSource Divisa { get; }
        System.Windows.Forms.BindingSource Categoria { get; }
        System.Windows.Forms.BindingSource Clasificacion { get; }
        System.Windows.Forms.BindingSource SourceCodAlterno { get; }


        string CodigoProducto { get; set; }
        string DescripcionProducto { get; set; }
        string NombreProducto { get; set; }
        string ModeloProducto { get; set; }
        string ReferenciaProducto { get; set; }
        int ContEmpProducto { get; set; }
        string AutoDepartamento { get; set; }
        string AutoGrupo { get; set; }
        string AutoMarca { get; set; }
        string AutoImpuesto { get; set; }
        string AutoEmpCompra { get; set; }
        string IdOrigen { get; set; }
        string IdCategoria { get; set; }
        string IdClasificacionAbc { get; set; }
        string IdDivisa { get; set; }
        byte[] Imagen { get; set; }
        bool Pesado { get; set; }
        string Plu { get; set; }
        int DiasEmpaque { get; set; }
        string CodigoAlterno { get; set; }
        bool ActivarCatlogo { get; set; }


        void SetFicha(string autoPrd);
        void Limpiar();
        bool CargarData();
        void Procesar();
        void InicializarIsCerrarHabilitado();
        void CargaDepartamentos();
        void CargaGrupos();
        void CargaMarcas();
        void ListaPlu();
        void AgregarCodigoAlterno();
        void EliminarCodigoAlterno();


        bool IsAgregarEditarOk { get; }
        string AutoProductoAgregado { get; }
        string Titulo { get; }

    }

}