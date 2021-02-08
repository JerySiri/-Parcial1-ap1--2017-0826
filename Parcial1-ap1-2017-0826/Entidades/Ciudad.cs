using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial1_ap1_2017_0826.Entidades
{
    public class Ciudad
    {
        [Key]
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
        
        public Ciudad()
        {
            CiudadId = 0;
            Nombre = string.Empty;
        }
    }
}
