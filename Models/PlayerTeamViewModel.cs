using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models
{
    public class PlayerTeamViewModel
    {
        public List<Player> Players { get; set; }
        public SelectList Teams { get; set; }
        public string PlayerTeam { get; set; }
        public string SearchString { get; set; }

    }
}
