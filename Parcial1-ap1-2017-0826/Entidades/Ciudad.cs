using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial1_ap1_2017_0826.Entidades
{
    class Ciudad
    {
        [Key]
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
    }
}
