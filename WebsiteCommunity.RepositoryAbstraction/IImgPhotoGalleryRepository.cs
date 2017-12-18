using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.RepositoryAbstraction
{
    public interface IImgPhotoGalleryRepository
    {
        List<ImgPhotoGallery> ReadAll();
        ImgPhotoGallery Insert(ImgPhotoGallery imgPhotoGallery);
    }
}
