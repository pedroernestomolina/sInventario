using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Utils.Tools
{
    public interface ICtrlLink: ICtrl
    {
        void CargarDataByIdLink(string id);
    }
}