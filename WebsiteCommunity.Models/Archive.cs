using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCommunity.Models
{
    public class Archive
    {
        public Guid ArchiveID { get; set; }
        public string ArchiveName { get; set; }
        public Guid VideoID { get; set; }
        public DateTime Data { get; set; }
        public string Description { get; set; }
    }
}
