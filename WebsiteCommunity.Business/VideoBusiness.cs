using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using WebsiteCommunity.Business.Core;

namespace WebsiteCommunity.Business
{
    public class VideoBusiness
    {
        public List<Video> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.VideoRepository.ReadAll();
        }
        public Video Insert(Video video)
        {
            return BusinessContext.Current.RepositoryContext.VideoRepository.Insert(video);
        }
        public Video ReadById(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.VideoRepository.ReadById(id);
        }
        public Video UpdateById(Video video)
        {
            return BusinessContext.Current.RepositoryContext.VideoRepository.UpdateById(video);
        }
        public Video Delete(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.VideoRepository.Delete(id);
        }
    }
}
