using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebsiteCommunity.Models;
using WebsiteCommunity.Business.Core;

namespace WebsiteCommunity.API.Controllers
{
    [RoutePrefix("api/video")]
    public class VideoController : ApiController
    {
        #region Methods
       
        //GET api/video
        [HttpGet]
        [Route("")]
        public IEnumerable<Video> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.VideoBusiness.ReadAll();
            }
        }

        //GET api/video/{Guid}
        [HttpGet]
        [Route("{videoId:Guid}")]
        public Video ReadById(Guid videoId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.VideoBusiness.ReadById(videoId);
            }
        }

        //POST api/video
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] Video video)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.VideoBusiness.Insert(video);
            }
        }

        //PUT api/video
        [HttpPut]
        [Route("")]
        public void UpdateById([FromBody] Video video)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.VideoBusiness.UpdateById(video);
            }
        }

        //DELETE api/video/{Guid}
        [HttpDelete]
        [Route("{videoId:Guid}")]
        public void Delete([FromBody] Guid videoId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.VideoBusiness.Delete(videoId);
            }
        }
        #endregion Methods
    }
}