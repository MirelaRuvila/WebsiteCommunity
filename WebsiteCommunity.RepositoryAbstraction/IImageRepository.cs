using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Models;

namespace WebsiteCommunity.RepositoryAbstraction
{
    public interface IImageRepository
    {
        List<Image> ReadAll();
        Image Insert(Image image);
        Image ReadById(Guid id);
        Image UpdateById(Image image);
        Image Delete(Guid id);
    }
}
