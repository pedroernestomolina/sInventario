using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.VerVisualizar.ModoSucursal
{

    public class Visual: IVisualSucursal
    {


        private string _idPrd;
        private data _ficha;
        private decimal _tasaCambio;
        private string _metodoCalculoUt;


        public Visual() 
        {
            _idPrd = "";
            _ficha = new data();
            _tasaCambio = 0m;
            _metodoCalculoUt = "";
        }


        public void Inicializa()
        {
            _ficha.Inicializa();
        }
        VisualFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new VisualFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setFichaVisualizar(string idPrd)
        {
            _idPrd = idPrd;
        }


        private bool CargarData()
        {
            if (_idPrd == "")
            {
                Helpers.Msg.Error("[ ID ] PRODUCTO NO PUEDE ESTAR VACIO");
                return false;
            }
            var r01 = Sistema.MyData.Producto_Precio_GetById(_idPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var r03 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _metodoCalculoUt = "FINANCIERO";
            if (((OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad)r03.Entidad) == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Lineal) 
            {
                _metodoCalculoUt = "LINEAL";
            }
            _tasaCambio = r02.Entidad;
            _ficha.Producto = r01.Entidad.codigo + Environment.NewLine + r01.Entidad.descripcion;
            _ficha.TasaIva = r01.Entidad.tasaIva;
            _ficha.AdmDivisa = r01.Entidad.estatusDivisa;


            _ficha.emp1_1.setData("PRECIO 1", 
                                    r01.Entidad.contEmp1_1, 
                                    r01.Entidad.descEmp1_1, 
                                    r01.Entidad.pnEmp1_1, 
                                    r01.Entidad.pfdEmp1_1, 
                                    r01.Entidad.utEmp1_1, 
                                    r01.Entidad.tasaIva);
            _ficha.emp1_2.setData("PRECIO 2",
                                    r01.Entidad.contEmp1_2,
                                    r01.Entidad.descEmp1_2,
                                    r01.Entidad.pnEmp1_2,
                                    r01.Entidad.pfdEmp1_2,
                                    r01.Entidad.utEmp1_2,
                                    r01.Entidad.tasaIva);
            _ficha.emp1_3.setData("PRECIO 3",
                                    r01.Entidad.contEmp1_3,
                                    r01.Entidad.descEmp1_3,
                                    r01.Entidad.pnEmp1_3,
                                    r01.Entidad.pfdEmp1_3,
                                    r01.Entidad.utEmp1_3,
                                    r01.Entidad.tasaIva);
            _ficha.emp1_4.setData("PRECIO 4",
                                    r01.Entidad.contEmp1_4,
                                    r01.Entidad.descEmp1_4,
                                    r01.Entidad.pnEmp1_4,
                                    r01.Entidad.pfdEmp1_4,
                                    r01.Entidad.utEmp1_4,
                                    r01.Entidad.tasaIva);
            _ficha.emp1_5.setData("PRECIO 5",
                                    r01.Entidad.contEmp1_5,
                                    r01.Entidad.descEmp1_5,
                                    r01.Entidad.pnEmp1_5,
                                    r01.Entidad.pfdEmp1_5,
                                    r01.Entidad.utEmp1_5,
                                    r01.Entidad.tasaIva);
            //
            _ficha.emp2_1.setData("PRECIO 1",
                                    r01.Entidad.contEmp2_1,
                                    r01.Entidad.descEmp2_1,
                                    r01.Entidad.pnEmp2_1,
                                    r01.Entidad.pfdEmp2_1,
                                    r01.Entidad.utEmp2_1,
                                    r01.Entidad.tasaIva);
            _ficha.emp2_2.setData("PRECIO 2",
                                    r01.Entidad.contEmp2_2,
                                    r01.Entidad.descEmp2_2,
                                    r01.Entidad.pnEmp2_2,
                                    r01.Entidad.pfdEmp2_2,
                                    r01.Entidad.utEmp2_2,
                                    r01.Entidad.tasaIva);
            _ficha.emp2_3.setData("PRECIO 3",
                                    r01.Entidad.contEmp2_3,
                                    r01.Entidad.descEmp2_3,
                                    r01.Entidad.pnEmp2_3,
                                    r01.Entidad.pfdEmp2_3,
                                    r01.Entidad.utEmp2_3,
                                    r01.Entidad.tasaIva);
            _ficha.emp2_4.setData("PRECIO 4",
                                    r01.Entidad.contEmp2_4,
                                    r01.Entidad.descEmp2_4,
                                    r01.Entidad.pnEmp2_4,
                                    r01.Entidad.pfdEmp2_4,
                                    r01.Entidad.utEmp2_4,
                                    r01.Entidad.tasaIva);
            _ficha.emp2_5.setData("PRECIO 5",
                                    r01.Entidad.contEmp2_5,
                                    r01.Entidad.descEmp2_5,
                                    r01.Entidad.pnEmp2_5,
                                    r01.Entidad.pfdEmp2_5,
                                    r01.Entidad.utEmp2_5,
                                    r01.Entidad.tasaIva);
            //
            _ficha.emp3_1.setData("PRECIO 1",
                                    r01.Entidad.contEmp3_1,
                                    r01.Entidad.descEmp3_1,
                                    r01.Entidad.pnEmp3_1,
                                    r01.Entidad.pfdEmp3_1,
                                    r01.Entidad.utEmp3_1,
                                    r01.Entidad.tasaIva);
            _ficha.emp3_2.setData("PRECIO 2",
                                    r01.Entidad.contEmp3_2,
                                    r01.Entidad.descEmp3_2,
                                    r01.Entidad.pnEmp3_2,
                                    r01.Entidad.pfdEmp3_2,
                                    r01.Entidad.utEmp3_2,
                                    r01.Entidad.tasaIva);
            _ficha.emp3_3.setData("PRECIO 3",
                                    r01.Entidad.contEmp3_3,
                                    r01.Entidad.descEmp3_3,
                                    r01.Entidad.pnEmp3_3,
                                    r01.Entidad.pfdEmp3_3,
                                    r01.Entidad.utEmp3_3,
                                    r01.Entidad.tasaIva);
            _ficha.emp3_4.setData("PRECIO 4",
                                    r01.Entidad.contEmp3_4,
                                    r01.Entidad.descEmp3_4,
                                    r01.Entidad.pnEmp3_4,
                                    r01.Entidad.pfdEmp3_4,
                                    r01.Entidad.utEmp3_4,
                                    r01.Entidad.tasaIva);
            _ficha.emp3_5.setData("PRECIO 5",
                                    r01.Entidad.contEmp3_5,
                                    r01.Entidad.descEmp3_5,
                                    r01.Entidad.pnEmp3_5,
                                    r01.Entidad.pfdEmp3_5,
                                    r01.Entidad.utEmp3_5,
                                    r01.Entidad.tasaIva);
            return true;
        }


        public string GetProductoInfo { get { return _ficha.Producto; } }
        public string GetProductoAdmDivisa { get { return _ficha.ProductoAdmDivisa; } }
        public string GetProductoIva { get { return _ficha.ProductoIva; } }
        public decimal GetTasaCambio { get { return _tasaCambio; } }
        public string GetMetodoCalculoUtilidad { get { return _metodoCalculoUt; } }

        public dataEmp Emp1_1 { get { return _ficha.emp1_1; } }
        public dataEmp Emp1_2 { get { return _ficha.emp1_2; } }
        public dataEmp Emp1_3 { get { return _ficha.emp1_3; } }
        public dataEmp Emp1_4 { get { return _ficha.emp1_4; } }
        public dataEmp Emp1_5 { get { return _ficha.emp1_5; } }
        public dataEmp Emp2_1 { get { return _ficha.emp2_1; } }
        public dataEmp Emp2_2 { get { return _ficha.emp2_2; } }
        public dataEmp Emp2_3 { get { return _ficha.emp2_3; } }
        public dataEmp Emp2_4 { get { return _ficha.emp2_4; } }
        public dataEmp Emp2_5 { get { return _ficha.emp2_5; } }
        public dataEmp Emp3_1 { get { return _ficha.emp3_1; } }
        public dataEmp Emp3_2 { get { return _ficha.emp3_2; } }
        public dataEmp Emp3_3 { get { return _ficha.emp3_3; } }
        public dataEmp Emp3_4 { get { return _ficha.emp3_4; } }
        public dataEmp Emp3_5 { get { return _ficha.emp3_5; } }

    }

}