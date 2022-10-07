﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.src.Filtro.FiltroRep.ModoSucursal
{
    
    public class ImpModoSucursal: baseFiltro, IModoSucursal
    {

        private FiltrosGen.IOpcion _gSucursal;
        private FiltrosGen.IOpcion _gCategoria;
        private FiltrosGen.IOpcion _gOrigen;
        private FiltrosGen.IBuscar _filtroBusPrd;
        static new protected dataFiltrar _data;


        public System.Windows.Forms.BindingSource GetSucursal_Source { get { return _gSucursal.Source; } }
        public System.Windows.Forms.BindingSource GetCategoria_Source { get { return _gCategoria.Source; } }
        public System.Windows.Forms.BindingSource GetOrigen_Source { get { return _gOrigen.Source; } }


        public string GetSucursal_Id { get { return _gSucursal.GetId; } }
        public string GetCategoria_Id { get { return _gCategoria.GetId; } }
        public string GetOrigen_Id { get { return _gOrigen.GetId; } }
        public string GetProducto { get { return _filtroBusPrd.DescItemSeleccionado; } }


        public bool GetHabilitarSucursal { get { return _filtros.ActivarSucursal; } }
        public bool GetHabilitarOrigen { get { return _filtros.ActivarCategoria; } }
        public bool GetHabilitarCategoria { get { return _filtros.ActivarOrigen; } }
        public bool GetHabilitarProducto { get { return _filtros.ActivarProducto; } }

        
        public ImpModoSucursal(FiltrosGen.IBuscar filtroBusPrd)
            :base(_data=new dataFiltrar())
        {
            _gDeposito = new FiltrosGen.Opcion.Gestion();
            _gDepartamento= new FiltrosGen.Opcion.Gestion();
            _gGrupo= new FiltrosGen.Opcion.Gestion();
            _gMarca= new FiltrosGen.Opcion.Gestion();
            _gDivisa = new FiltrosGen.Opcion.Gestion();
            _gImpuesto = new FiltrosGen.Opcion.Gestion();
            _gEstatus = new FiltrosGen.Opcion.Gestion();
            _gPesado = new FiltrosGen.Opcion.Gestion();
            _gDesde = new FiltrosGen.Fecha.Gestion();
            _gHasta = new FiltrosGen.Fecha.Gestion();
            _gSucursal = new FiltrosGen.Opcion.Gestion();
            _gCategoria = new FiltrosGen.Opcion.Gestion();
            _gOrigen = new FiltrosGen.Opcion.Gestion();
            _filtroBusPrd = filtroBusPrd;
        }


        public override void Inicializa()
        {
            base.Inicializa();
            _gSucursal.Inicializa();
            _gCategoria.Inicializa();
            _gOrigen.Inicializa();
            _filtroBusPrd.Inicializa();
            _data.Limpiar();
        }
        FiltrosFrm frm;
        public override void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new FiltrosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public override bool CargarData()
        {
            if (base.CargarData())
            {
                try
                {
                    var lSucursal = new List<ficha>();
                    var filtroOOb = new OOB.LibInventario.Sucursal.Filtro();
                    var r01 = Sistema.MyData.Sucursal_GetLista(filtroOOb);
                    foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                    {
                        lSucursal.Add(new ficha(rg.auto, "", rg.nombre));
                    }
                    _gSucursal.setData(lSucursal);

                    var lCategoria = new List<ficha>();
                    var r02 = Sistema.MyData.Producto_Categoria_Lista();
                    foreach (var rg in r02.Lista.OrderBy(o => o.Descripcion).ToList())
                    {
                        lCategoria.Add(new ficha(rg.Id, "", rg.Descripcion));
                    }
                    _gCategoria.setData(lCategoria);

                    var lOrigen = new List<ficha>();
                    var r03 = Sistema.MyData.Producto_Origen_Lista();
                    foreach (var rg in r03.Lista.OrderBy(o => o.Descripcion).ToList())
                    {
                        lOrigen.Add(new ficha(rg.Id, "", rg.Descripcion));
                    }
                    _gOrigen.setData(lOrigen);
                    return true;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                    return false;
                }
            }
            return false;
        }
        public override void LimpiarOpciones()
        {
            base.LimpiarOpciones();
            _gSucursal.Inicializa();
            _gCategoria.Inicializa();
            _gOrigen.Inicializa();
            _filtroBusPrd.Inicializa();
        }


        public override bool FiltrosIsOK { get { return validarData(); } }
        public override FiltrosGen.Reportes.data dataFiltrar { get { return dataExportar(); } }
        public override void setValidarData(bool p)
        {
        }
        private bool validarData()
        {
            if (ProcesarIsOk)
            {
                if (_data.Desde.HasValue)
                {
                    if (_data.Hasta.HasValue)
                    {
                        if (_data.Hasta.Value >= _data.Desde.Value)
                        {
                            return true;
                        }
                        Helpers.Msg.Alerta("FECHAS INCORRECTAS, VERIFIQUE POR FAVOR");
                        return false;
                    }
                    return true;
                }
                return true;
            }
            return false;
        }
        private FiltrosGen.Reportes.data dataExportar()
        {
            var rg = new FiltrosGen.Reportes.data()
            {
                Depart = _data.Departamento,
                Deposito = _data.Deposito,
                Desde = _data.Desde,
                Divisa = _data.Divisa,
                Estatus = _data.Estatus,
                Grupo = _data.Grupo,
                Hasta = _data.Hasta,
                Marca = _data.Marca,
                Pesado= _data.Pesado,
                TasaIva = _data.Impuesto,
                Categoria = _data.Categoria,
                Origen = _data.Origen,
                Producto = _data.Producto,
                Sucursal = _data.Sucursal,
            };
            return rg;
        }


        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
            _data.Sucursal = _gSucursal.Item;
        }
        public void setCategoria(string id)
        {
            _gCategoria.setFicha(id);
            _data.Categoria= _gCategoria.Item;
        }
        public void setOrigen(string id)
        {
            _gOrigen.setFicha(id);
            _data.Origen= _gOrigen.Item;
        }
        public void setProducto(string desc)
        {
            _filtroBusPrd.setCadenaBuscar(desc);
        }


        public bool LimpiarProductoIsOk { get { return _filtroBusPrd.LimpiarItemIsOk; } }
        public void LimpiarProducto()
        {
            _filtroBusPrd.LimpiarItem();
        }


        public bool ProductoIsOk { get { return _filtroBusPrd.ItemIsOk; } }
        public void BuscarProducto()
        {
            _filtroBusPrd.Buscar();
            if (_filtroBusPrd.ItemIsOk) 
            {
                _data.Producto = _filtroBusPrd.ItemSeleccionado;
            }
        }

    }

}