using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.src.Producto.AgregarEditar.ModoSucursal
{
    public interface IAgregarEditar: IBaseAgregarEditar, TallaColorSabor.ITallaColorSabor
    {
        string GetTitulo { get; }
        string GetModeloProducto { get;  }
        string GetReferenciaProducto { get; }
        BindingSource GetEmpInv_Source { get; }
        int GetContEmpInv { get; }
        string GetEmpInv_Id { get; }
        decimal GetPeso { get; }
        decimal GetVolumen { get; }
        decimal GetLargo { get; }
        decimal GetAlto { get; }
        decimal GetAncho { get; }
        bool GetActivarCatlogo { get; }
        byte[] GetImagen { get; }


        void setEmpInv(string id);
        void setContEmpInv(int v);
        void setModeloProducto(string d);
        void setReferenciaProducto(string d);
        void setPeso(decimal v);
        void setVolumen(decimal v);
        void setAlto(decimal v);
        void setLargo(decimal v);
        void setAncho(decimal v);
        void setImagen(Image img);
        void setActivarCatlogo(bool b);


        bool HabilitarEditarCodigo { get; }
        void BuscarImagen();
        bool BuscarImagenIsOk { get; }


        void AgregarDepartamento();
        bool AgregarDepartamentoIsOK { get; }


        void AgregarGrupo();
        bool AgregarGrupoIsOk { get; }


        void AgregarMarca();
        bool AgregarMarcaIsOk { get; }


        void EditarCodigo();
        bool EditarCodigoIsOk { get; }

        void RefrescaTallaColorSabor();

        void setTipoVolumenCajaRect();
        void setTipoVolumenCilindro();
        void setTipoVolumenCono();
        void setTipoVolumenEsfera();
        void setTipoVolumenOtro();
    }
}