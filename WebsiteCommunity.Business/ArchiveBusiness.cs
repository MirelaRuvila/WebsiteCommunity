using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;
using WebsiteCommunity.Business.Core;

namespace WebsiteCommunity.Business
{
    public class ArchiveBusiness
    {
        public List<Archive> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ArchiveRepository.ReadAll();
        }
        public Archive Insert(Archive archive)
        {
            return BusinessContext.Current.RepositoryContext.ArchiveRepository.Insert(archive);
        }
        public Archive ReadById(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.ArchiveRepository.ReadById(id);
        }
        public Archive UpdateById(Archive archive)
        {
            return BusinessContext.Current.RepositoryContext.ArchiveRepository.UpdateById(archive);
        }
        public Archive Delete(Guid id)
        {
            return BusinessContext.Current.RepositoryContext.ArchiveRepository.Delete(id);
        }
    }
}
