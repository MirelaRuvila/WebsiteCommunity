using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebsiteCommunity.Models;
using WebsiteCommunity.Business.Core;

namespace WebsiteCommunity.API.Controllers
{
    [RoutePrefix("api/photogallery")]
    public class PhotoGalleryController : ApiController
    {
        #region Methods

        //GET api/photogallery
        [HttpGet]
        [Route("")]
        public IEnumerable<PhotoGallery> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.PhotoGalleryBusiness.ReadAll();
            }
        }

        //GET api/photogallery/{Guid}
        [HttpGet]
        [Route("{photoGalleryId:Guid}")]
        public PhotoGallery ReadById(Guid photoGalleryId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.PhotoGalleryBusiness.ReadById(photoGalleryId);
            }
        }

        //POST api/photogallery
        [HttpPost]
        [Route("")]
        public void Insert([FromBody] PhotoGallery photoGallery)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.PhotoGalleryBusiness.Insert(photoGallery);
            }
        }

        //PUT api/photogallery
        [HttpPut]
        [Route("")]
        public void UpdateById([FromBody] PhotoGallery photoGallery)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.PhotoGalleryBusiness.UpdateById(photoGallery);
            }
        }

        //DELETE api/photogallery/{Guid}
        [HttpDelete]
        [Route("{photoGallery:Guid}")]
        public void Delete([FromBody] Guid photoGallery)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.PhotoGalleryBusiness.Delete(photoGallery);
            }
        }
        #endregion Methods
    }
}