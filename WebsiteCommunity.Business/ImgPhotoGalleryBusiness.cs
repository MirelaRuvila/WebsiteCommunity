using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using WebsiteCommunity.Business.Core;

namespace WebsiteCommunity.Business
{
    public class ImgPhotoGalleryBusiness
    {
        public List<ImgPhotoGallery> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ImgPhotoGalleryRepository.ReadAll();
        }
        public ImgPhotoGallery Insert(ImgPhotoGallery imgPhotoGallery)
        {
            return BusinessContext.Current.RepositoryContext.ImgPhotoGalleryRepository.Insert(imgPhotoGallery);
        }
    }
}
