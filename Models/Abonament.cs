using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SalaFitness.Models
{
   public class Abonament
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250), Unique]
        public string TipAbonament { get; set; }
        public decimal Pret { get; set; }
        public DateTime Date { get; set; }
    }
}
