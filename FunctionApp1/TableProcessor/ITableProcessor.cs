using SofomoServer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofomoServer.TableProcessor
{
    public interface ITableProcessor
    {
         Task<Azure.Response> AddReportAsync(Report report);
        Task<Azure.Response> DeleteReport(string id);
        Task<List<Report>> GetReportsAsync();
    }
}
