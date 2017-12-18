using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using WebsiteCommunity.Business.Core;

namespace WebsiteCommunity.Business
{
    public class ImageBusiness
    {
        public List<Image> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ImageRepository.ReadAll();
        }
        public Image Insert(Image image)
        {
            return BusinessContext.Current.RepositoryContext.ImageRepository.Insert(image);
        }
        public Image ReadById(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.ImageRepository.ReadById(id);
        }
        public Image UpdateById(Image image)
        {
            return BusinessContext.Current.RepositoryContext.ImageRepository.UpdateById(image);
        }
        public Image Delete(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.ImageRepository.Delete(id);
        }
    }
}
