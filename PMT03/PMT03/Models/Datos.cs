using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMT03.Models
{
    public class Datos
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(50)]
        public string Nombres { get; set; }
        [MaxLength(50)]
        public string Apellidos { get; set; }
        [MaxLength(50)]

        public int Edad { get; set; }
        [MaxLength(50)]

        public string Correo { get; set; }
        [MaxLength(50)]

        public string Direccion { get; set; }
       
   
    }
}
