using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofomoClient.ServerFacade.DataModels
{
    public class IpAddressReport
    {

        /// <summary>
        /// Adress IP
        /// </summary>
        public string IpAddress { get; set; }


        /// <summary>
        /// JSON contet IpAdres Data
        /// </summary>
        public string Content { get; set; }



        public string Region
        {
            get
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(Content);
                return parsedJson.region_name;
            }
        }

        public string City
        {
            get
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(Content);
                return parsedJson.city;
            }
        }


        public string Country
        {
            get
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(Content);
                return parsedJson.country_name;
            }
        }



    }
}
