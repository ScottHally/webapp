using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PlayerDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Team { get; set; }
        public decimal Salary { get; set; }
        public string Rating { get; set; }
        public int LeagueID { get; set; }
    }
}
