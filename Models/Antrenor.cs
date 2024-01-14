using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaFitness.Models
{
    public class Antrenor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Nume { get; set; }

        [MaxLength(50)]
        public string Prenume { get; set; }
    }
}

