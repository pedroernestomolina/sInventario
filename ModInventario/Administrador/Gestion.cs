using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Administrador
{
    
    public class Gestion
    {


        private IGestion _miGestion;


        public void Inicia()
        {
            _miGestion.Inicia();
        }

        public void setGestion(IGestion gestion)
        {
            _miGestion = gestion;
        }

        public void setGestionAuditoria(Auditoria.Visualizar.Gestion _gestionAuditoria)
        {
            _miGestion.setGestionAuditoria(_gestionAuditoria);
        }

    }

}