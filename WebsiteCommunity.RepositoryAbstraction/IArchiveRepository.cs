using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.RepositoryAbstraction
{
    public interface IArchiveRepository
    {
        List<Archive> ReadAll();
        Archive Insert(Archive archive);
        Archive ReadById(Guid id);
        Archive UpdateById(Archive archive);
        Archive Delete(Guid id);
    }
}
