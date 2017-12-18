using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.RepositoryAbstraction.Core;
using WebsiteCommunity.RepositoryFactory;

namespace WebsiteCommunity.Business.Core
{
    public class BusinessContext :IDisposable
    {
        #region Members
        private static BusinessContext _instance;

        private IRepositoryContext _repositoryContext;

        private DepartmentBusiness _departmentBusiness;
        private ArchiveBusiness _archiveBusiness;
        private EventBusiness _eventBusiness;
        private ImageBusiness _imageBusiness;
        private PhotoGalleryBusiness _photoGalleryBusiness;
        private ImgPhotoGalleryBusiness _imgPhotoGalleryBusiness;
        private VideoBusiness _videoBusiness;
        #endregion

        #region Constructor
        public BusinessContext()
        {
            _instance = this;
            _repositoryContext = Getter.GetRepository();
        }
        #endregion
        #region Properties
        internal static BusinessContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("No BusinessContext instance available!");
                }
                return _instance;
            }
        }
        public DepartmentBusiness DepartmentBusiness
        {
            get
            {
                if (_departmentBusiness == null)
                    _departmentBusiness = new DepartmentBusiness();
                return _departmentBusiness;
            }
        }
        public ArchiveBusiness ArchiveBusiness
        {
            get
            {
                if (_archiveBusiness == null)
                    _archiveBusiness = new ArchiveBusiness();
                return _archiveBusiness;
            }
        }
        public EventBusiness EventBusiness
        {
            get
            {
                if (_eventBusiness == null)
                    _eventBusiness = new EventBusiness();
                return _eventBusiness;
            }
        }
        public ImageBusiness ImageBusiness
        {
            get
            {
                if (_imageBusiness == null)
                    _imageBusiness = new ImageBusiness();
                return _imageBusiness;
            }
        }
        public ImgPhotoGalleryBusiness ImgPhotoGalleryBusiness
        {
            get
            {
                if (_imgPhotoGalleryBusiness == null)
                    _imgPhotoGalleryBusiness = new ImgPhotoGalleryBusiness();
                return _imgPhotoGalleryBusiness;
            }
        }
        public PhotoGalleryBusiness PhotoGalleryBusiness
        {
            get
            {
                if (_photoGalleryBusiness == null)
                    _photoGalleryBusiness = new PhotoGalleryBusiness();
                return _photoGalleryBusiness;
            }
        }
        public VideoBusiness VideoBusiness
        {
            get
            {
                if (_videoBusiness == null)
                    _videoBusiness = new VideoBusiness();
                return _videoBusiness;
            }
        }

        internal IRepositoryContext RepositoryContext
        {
            get { return _repositoryContext; }
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
                if (_departmentBusiness != null)
                {
                    //_connection.Dispose();
                    _departmentBusiness = null;
                }

                if (_archiveBusiness != null)
                {
                    _archiveBusiness = null;
                }
                if (_eventBusiness != null)
                {
                    _eventBusiness = null;
                }
                if (_imageBusiness != null)
                {
                    _imageBusiness = null;
                }
                if (_imgPhotoGalleryBusiness != null)
                {
                    _imgPhotoGalleryBusiness = null;
                }
                if (_photoGalleryBusiness != null)
                {
                    _photoGalleryBusiness = null;
                }
                if (_videoBusiness != null)
                {
                    _videoBusiness = null;
                }
                if (_repositoryContext != null)
                {
                    _repositoryContext.Dispose();
                    _repositoryContext = null;
                }
                if (_instance != null)
                {
                    _instance = null;
                }
            }
        }
        ~BusinessContext()
        {
            Dispose(false);
        }
        #endregion
    }
}
