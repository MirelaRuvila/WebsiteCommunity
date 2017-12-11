using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCommunity.Repository.Core
{
    public class RepositoryContext : IDisposable
    {
        #region Members
        private DepartmentRepository _departmentRepository;
        private ArchiveRepository _archiveRepository;
        private EventRepository _eventRepository;
        private ImageRepository _imageRepository;
        private ImgPhotoGalleryRepository _imgPhotoGalleryRepository;
        private PhotoGalleryRepository _photoGalleryRepository;
        private VideoRepository _videoRepository;
        #endregion

        #region Properties
        public DepartmentRepository DepartmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository();
                return _departmentRepository;
            }
        }
        public ArchiveRepository ArchiveRepository
        {
            get
            {
                if (_archiveRepository == null)
                    _archiveRepository = new ArchiveRepository();
                return _archiveRepository;
            }
        }
        public EventRepository EventRepository
        {
            get
            {
                if (_eventRepository == null)
                    _eventRepository = new EventRepository();
                return _eventRepository;
            }
        }
        public ImageRepository ImageRepository
        {
            get
            {
                if (_imageRepository == null)
                    _imageRepository = new ImageRepository();
                return _imageRepository;
            }
        }
        public ImgPhotoGalleryRepository ImgPhotoGalleryRepository
        {
            get
            {
                if (_imgPhotoGalleryRepository == null)
                    _imgPhotoGalleryRepository = new ImgPhotoGalleryRepository();
                return _imgPhotoGalleryRepository;
            }
        }
        public PhotoGalleryRepository PhotoGalleryRepository
        {
            get
            {
                if (_photoGalleryRepository == null)
                    _photoGalleryRepository = new PhotoGalleryRepository();
                return _photoGalleryRepository;
            }
        }
        public VideoRepository VideoRepository
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
            }
        }
#endregion
    }
}
