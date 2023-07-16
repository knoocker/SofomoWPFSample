using SofomoWpfApp1.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SofomoWpfApp1.Services
{
    internal class ReportsService : IReportsService
    {

        protected readonly HttpClient httpClient;

        public ReportsService() 
        {
            this.httpClient = new HttpClient();


            //TODO - move config to JSON
          //  httpClient.BaseAddress = new Uri(@"https://kktestfunction2.azurewebsites.net/api/");

              httpClient.BaseAddress = new Uri(@"http://localhost:7131/api/");

        }

        public async Task<HttpResponseMessage> CreateIpAddress(string ipAddress)
        {

            return await httpClient.PostAsync("reports/", new StringContent(ipAddress));


        }

        public async Task<HttpResponseMessage> DeleteIpAddress(string ipAddress)
        {
            return await httpClient.DeleteAsync("reports/"+ipAddress);

        }

        public async Task<List<IpAddressReport>> GetAllIpAddress()
        {
            
            List<IpAddressReport> ipAdresReports = (await JsonSerializer.DeserializeAsync<IEnumerable<IpAddressReport>>
          (await httpClient.GetStreamAsync($"reports/" ), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })).ToList();

            return ipAdresReports;
        }


    }
}
