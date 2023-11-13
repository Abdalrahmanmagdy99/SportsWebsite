using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services.Dtos
{
    public class TournamentDetails
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int NumberOfTeams { get; set; }
        public string VideoUrl { get; set; }
    }
}
