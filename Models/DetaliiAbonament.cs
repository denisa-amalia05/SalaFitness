using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaFitness.Models
{
    public class DetaliiAbonament
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Descriere { get; set; }

        [OneToMany]
        public List<Antrenor> Antrenori { get; set; }

    }
}
