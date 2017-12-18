using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.RepositoryAbstraction;
using WebsiteCommunity.RepositoryAbstraction.Core;

namespace WebsiteCommunity.Repository.Core
{
    public class RepositoryContext : IRepositoryContext
    {
        #region Members
        private static IRepositoryContext _instance;
        private IDepartmentRepository _departmentRepository;
        private IArchiveRepository _archiveRepository;
        private IEventRepository _eventRepository;
        private IImageRepository _imageRepository;
        private IImgPhotoGalleryRepository _imgPhotoGalleryRepository;
        private IPhotoGalleryRepository _photoGalleryRepository;
        private IVideoRepository _videoRepository;
        #endregion

        #region Constructor
        public RepositoryContext()
        {
            _instance = this;
        }
        #endregion

        #region Properties
        internal static IRepositoryContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("No RepositoryContext instance available!");
                }
                return _instance;
            }
        }
        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository();
                return _departmentRepository;
            }
        }
        public IArchiveRepository ArchiveRepository
        {
            get
            {
                if (_archiveRepository == null)
                    _archiveRepository = new ArchiveRepository();
                return _archiveRepository;
            }
        }
        public IEventRepository EventRepository
        {
            get
            {
                if (_eventRepository == null)
                    _eventRepository = new EventRepository();
                return _eventRepository;
            }
        }
        public IImageRepository ImageRepository
        {
            get
            {
                if (_imageRepository == null)
                    _imageRepository = new ImageRepository();
                return _imageRepository;
            }
        }
        public IImgPhotoGalleryRepository ImgPhotoGalleryRepository
        {
            get
            {
                if (_imgPhotoGalleryRepository == null)
                    _imgPhotoGalleryRepository = new ImgPhotoGalleryRepository();
                return _imgPhotoGalleryRepository;
            }
        }
        public IPhotoGalleryRepository PhotoGalleryRepository
        {
            get
            {
                if (_photoGalleryRepository == null)
                    _photoGalleryRepository = new PhotoGalleryRepository();
                return _photoGalleryRepository;
            }
        }
        public IVideoRepository VideoRepository
        {
            get
            {
                if (_videoRepository == null)
                    _videoRepository = new VideoRepository();
                return _videoRepository;
            }
        }
        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (_departmentRepository != null)
                {
                    //_connection.Dispose();
                    _departmentRepository = null;
                }

                if (_archiveRepository != null)
                {
                    //_connection.Dispose();
                    _archiveRepository = null;
                }
                if (_eventRepository != null)
                {
                    _eventRepository = null;
                }
                if (_imageRepository != null)
                {
                    _imageRepository = null;
                }
                if (_imgPhotoGalleryRepository != null)
                {
                    _imgPhotoGalleryRepository = null;
                }
                if (_photoGalleryRepository != null)
                {
                    _photoGalleryRepository = null;
                }
                if (_videoRepository != null)
                {
                    _videoRepository = null;
                }
                if (_instance != null)
                {
                    _instance = null;
                }
            }
        }
        ~RepositoryContext()
        {
            Dispose(false);
        }
#endregion
    }
}
