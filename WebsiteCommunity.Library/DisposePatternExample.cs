using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebsiteCommunity.Library
{
    public class DisposePatternExample : IDisposable
    {
        private SqlConnection _connection;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }

        ~DisposePatternExample()
        {
            Dispose(false);
        }
    }
}
