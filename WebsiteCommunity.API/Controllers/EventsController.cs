using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebsiteCommunity.Models;
using WebsiteCommunity.Business.Core;

namespace WebsiteCommunity.API.Controllers
{
    [RoutePrefix("api/events")]
    public class EventsController : ApiController
    {
        #region Methods
        //GET api/events
        [HttpGet]
        [Route("")]
        public IEnumerable<Event> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.EventBusiness.ReadAll();
            }
        }

        //GET api/events/{Guid}
        [HttpGet]
        [Route("{eventId:Guid}")]
        public Event ReadById(Guid eventId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.EventBusiness.ReadById(eventId);
            }
        }

        //POST api/events
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] Event event1)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.EventBusiness.Insert(event1);
            }
        }

        //PUT api/events
        [HttpPut]
        [Route("")]
        public void UpdateById([FromBody] Event event1)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.EventBusiness.UpdateById(event1);
            }
        }

        //DELETE api/events/{Guid}
        [HttpDelete]
        [Route("{eventId:Guid}")]
        public void Delete([FromBody] Guid eventId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.EventBusiness.Delete(eventId);
            }
        }
        #endregion Methods

    }
}
