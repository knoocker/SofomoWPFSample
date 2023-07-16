using FunctionApp1.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1.TableProcessor
{
    public interface ITableProcessor
    {
         Task<Azure.Response> AddReportAsync(Report report);
        Task<Azure.Response> DeleteReport(string id);
        Task<List<Report>> GetReportsAsync();
    }
}
