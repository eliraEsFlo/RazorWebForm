using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructura.Entities
{
    public class ProyectosPorProgramador
    {
        public string NombreRequerimiento { get; set; }
        public string idRequerimiento { get; set; }

        public DateTime FechaAsignacion { get; set; }  
        public string Estado { get; set; }
    
        
        
    }
}
