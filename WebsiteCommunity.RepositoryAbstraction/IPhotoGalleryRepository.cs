using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.RepositoryAbstraction
{
    public interface IPhotoGalleryRepository
    {
        List<PhotoGallery> ReadAll();
        PhotoGallery Insert(PhotoGallery photoGallery);
        PhotoGallery ReadById(Guid id);
        PhotoGallery UpdateById(PhotoGallery photoGallery);
        PhotoGallery Delete(Guid id);
    }
}
