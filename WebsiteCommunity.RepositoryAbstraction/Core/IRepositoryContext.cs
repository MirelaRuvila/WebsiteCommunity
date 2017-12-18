using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCommunity.RepositoryAbstraction.Core
{
    public interface IRepositoryContext : IDisposable
    {
        IArchiveRepository ArchiveRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEventRepository EventRepository { get; }
        IImageRepository ImageRepository { get; }
        IPhotoGalleryRepository PhotoGalleryRepository { get; }
        IImgPhotoGalleryRepository ImgPhotoGalleryRepository { get; }
        IVideoRepository VideoRepository { get; }
    }
}
