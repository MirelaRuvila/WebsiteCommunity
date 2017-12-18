using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCommunity.Repository.Core;
using WebsiteCommunity.RepositoryAbstraction.Core;

namespace WebsiteCommunity.RepositoryFactory
{
    public class Getter
    {
        public static IRepositoryContext GetRepository()
        {
            //Get data from config.
            bool isADONetRepositoryRequested = true;
            if (isADONetRepositoryRequested)
                return new RepositoryContext();

            return default(IRepositoryContext);
        }
    }
}
