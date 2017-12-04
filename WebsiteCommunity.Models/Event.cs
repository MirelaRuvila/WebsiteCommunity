using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCommunity.Models
{
    public class Event
    {
        public Guid EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
    }
}
