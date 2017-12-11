using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WebsiteCommunity.Repository.Core
{
    public abstract class BaseRepository<TModel>
    {
        #region Members
        protected static string connectionString = GetConnectionString();
        #endregion

        #region Methods
        private static string GetConnectionString()
        {
            
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["CommunityDB"];
            if (connectionStringSettings == null)
            {
                throw new ArgumentNullException("No connection string defined in the configuration file!");
            }

            return connectionStringSettings.ConnectionString;
        }
        protected abstract TModel GetModelFromReader(SqlDataReader reader);
        protected abstract SqlParameter[] GetParameters(TModel model);
        #endregion

    }
}
