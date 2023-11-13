using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services.Dtos
{
    public class PlayerDetails
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public int Age { get; set; }
    }
}
