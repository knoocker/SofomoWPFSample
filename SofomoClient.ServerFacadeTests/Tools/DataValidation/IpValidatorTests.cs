using Microsoft.VisualStudio.TestTools.UnitTesting;
using SofomoClient.ServerFacade.Tools.DataValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofomoClient.ServerFacade.Tools.DataValidation.Tests
{
    [TestClass()]
    public class IpValidatorTests
    {
        [TestMethod()]
        public void IsIpAddressValidTest()
        {
            Assert.IsTrue(IpValidator.IsIpAddressValid("12.45.16.43"));
            Assert.IsFalse(IpValidator.IsIpAddressValid("12a.45.16.43"));

        }
    }
}