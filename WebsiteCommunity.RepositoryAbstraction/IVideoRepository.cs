using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.RepositoryAbstraction
{
    public interface IVideoRepository
    {
        List<Video> ReadAll();
        Video Insert(Video video);
        Video ReadById(Guid id);
        Video UpdateById(Video video);
        Video Delete(Guid id);
    }
}
