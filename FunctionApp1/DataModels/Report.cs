using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1.DataModels
{


    /// <summary>
    /// report of triggering tradestie
    /// </summary>
    public class Report : ITableEntity
    {

        public Report() { }

        public Report(bool isSuccessStatusCode, string ipAddress, string content)
        {

            PartitionKey = "report";
            RowKey = ipAddress;// Guid.NewGuid().ToString();
            this.IsSuccessStatusCode = isSuccessStatusCode;
            this.IpAddress = ipAddress;
            this.Content = content;
        }


        /// <summary>
        /// is status con is succes
        /// </summary>
        public bool IsSuccessStatusCode { get; set; }


        /// <summary>
        /// Adress IP
        /// </summary>
        public string IpAddress { get; set; }


        /// <summary>
        /// JSON contet IpAdres Data
        /// </summary>
        public string Content { get; set; }

        public string PartitionKey { get; set; }

        public string RowKey { get; set; }

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }
    }

}
