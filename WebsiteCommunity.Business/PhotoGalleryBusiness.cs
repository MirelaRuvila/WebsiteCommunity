using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using WebsiteCommunity.Business.Core;

namespace WebsiteCommunity.Business
{
    public class PhotoGalleryBusiness
    {
        public List<PhotoGallery> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.PhotoGalleryRepository.ReadAll();
        }
        public PhotoGallery Insert(PhotoGallery photoGallery)
        {
            return BusinessContext.Current.RepositoryContext.PhotoGalleryRepository.Insert(photoGallery);
        }
        public PhotoGallery ReadById(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.PhotoGalleryRepository.ReadById(id);
        }
        public PhotoGallery UpdateById(PhotoGallery photoGallery)
        {
            return BusinessContext.Current.RepositoryContext.PhotoGalleryRepository.UpdateById(photoGallery);
        }
        public PhotoGallery Delete(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.PhotoGalleryRepository.Delete(id);
        }
    }
}
