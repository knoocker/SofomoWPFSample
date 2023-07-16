using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SofomoWpfApp1.Tools.DataValidation
{
    internal class IpValidator
    {
        public static bool IsIpAddressValid(string ipAddress)
        {
            IPAddress address;
            if (IPAddress.TryParse(ipAddress, out address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
