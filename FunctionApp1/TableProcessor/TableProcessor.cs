using Azure.Data.Tables;
using SofomoServer.DataModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofomoServer.TableProcessor
{
    public class TableProcessor:ITableProcessor
    {

        TableClient table;

        private readonly ServerOptions serverOptions;


        public TableProcessor(IOptions<ServerOptions> serverOptions)
        {
            this.serverOptions = serverOptions?.Value ?? throw new ArgumentNullException(nameof(serverOptions));

            var serviceClient = new TableServiceClient(this.serverOptions.TableConnectionString);
            TableClient table = serviceClient.GetTableClient(this.serverOptions.TableName);
            table.CreateIfNotExists();
            this.table = table;

        }

        /// <summary>
        /// Add report to Azure Table
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public async Task<Azure.Response> AddReportAsync(Report report)
        {
            return await table.AddEntityAsync(report);

        }


        /// <summary>
        /// Get reports
        /// </summary>
        /// <returns></returns>
        public async Task<List<Report>> GetReportsAsync()
        {

            List<Report> reportsList = new List<Report>();
            Azure.AsyncPageable<Report> reports = table.QueryAsync<Report>();

            await foreach (Report report in reports)
            {
                reportsList.Add(report);
            }

            return reportsList;

        }

        public async Task<Azure.Response> DeleteReport(string id)
        {
            return await table.DeleteEntityAsync("report",id);
        
        }
    }
}
