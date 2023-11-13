using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services.Dtos
{
    public class TeamDetails
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteURL { get; set; }
        public DateTime FoundationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageName { get; set; }
    }
}
