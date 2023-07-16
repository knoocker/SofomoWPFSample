using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Azure.Identity;
using Azure.Storage.Blobs;
using FunctionApp1.DataModels;
using FunctionApp1.TableProcessor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FunctionApp1.Functions
{
    public class ReportService
    {

        private readonly ITableProcessor tableProcessor;
        private readonly ServerOptions serverOptions;


        public ReportService(ITableProcessor tableProcessor, IOptions<ServerOptions> serverOptions)
        {
            this.serverOptions = serverOptions?.Value ?? throw new ArgumentNullException(nameof(serverOptions));
            this.tableProcessor = tableProcessor;
        }

        [FunctionName("AddReports")]
        public async Task<IActionResult> AddReport(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "reports/")] string ipAddress)
        {

            HttpClient client = new HttpClient();
            string content = await client.GetStringAsync(serverOptions.HttpClientBaseUrl + ipAddress + "?access_key=9b7d7d4f5d1f8898fdcd1da7c928ee14");
            Report report = new Report(true, ipAddress, content);

            Azure.Response response = await tableProcessor.AddReportAsync(report);
            if (response.IsError)
            {
                return new NotFoundObjectResult(response.ReasonPhrase);
            }
            return new OkObjectResult(report);
        }


        [FunctionName("GetReports")]
        public async Task<IActionResult> GetReports(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "reports/")] HttpRequest req,
    ILogger log)
        {

            List<Report> reports = await tableProcessor.GetReportsAsync();
            return new OkObjectResult(reports);
        }

        [FunctionName("DeleteReport")]
        public async Task<IActionResult> DeleteReport(
           [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "reports/{id}")] HttpRequest req,
           ILogger log, string id)
        {
            Azure.Response response = await tableProcessor.DeleteReport(id);
            if( response.IsError)
            {
                return new NotFoundObjectResult(response.ReasonPhrase);
            }
            return new OkObjectResult(null);

        }


    }
}
