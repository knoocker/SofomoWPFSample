using SofomoClient.ServerFacade.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SofomoClient.ServerFacade.Services
{
    public interface IReportsService
    {
        Task<List<IpAddressReport>> GetAllIpAddress();
        Task<HttpResponseMessage> CreateIpAddress(string ipAddress);

        Task<HttpResponseMessage> DeleteIpAddress(string ipAddress);

    }
}
