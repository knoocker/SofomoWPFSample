using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofomoServer.DataModels
{

    /// <summary>
    /// inject params form settings.json to this class
    /// </summary>
    public class ServerOptions
    {
        public string TableConnectionString { get; init; }
        public string TableName { get; init; }

        public string HttpClientBaseUrl { get; init; }



    }
}
