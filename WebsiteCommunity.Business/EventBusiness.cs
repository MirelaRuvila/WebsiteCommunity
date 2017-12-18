using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Business.Core;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.Business
{
    public class EventBusiness
    {
        public List<Event> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.EventRepository.ReadAll();
        }
        public Event Insert(Event event1)
        {
            return BusinessContext.Current.RepositoryContext.EventRepository.Insert(event1);
        }
        public Event ReadById(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.EventRepository.ReadById(id);
        }
        public Event UpdateById(Event event1)
        {
            return BusinessContext.Current.RepositoryContext.EventRepository.UpdateById(event1);
        }
        public Event Delete(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.EventRepository.Delete(id);
        }
    }
}
