using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.RepositoryAbstraction
{
    public interface IEventRepository
    {
        List<Event> ReadAll();
        Event Insert(Event event1);
        Event ReadById(Guid id);
        Event UpdateById(Event archive);
        Event Delete(Guid id);
    }
}
