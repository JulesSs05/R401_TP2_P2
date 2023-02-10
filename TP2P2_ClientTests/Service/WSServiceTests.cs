using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2P2_Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2P2_Client.Service.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        public WSService Service
        {
            get { return Service; }
            set { Service = value; }
        }

        [TestMethod()]
        public void WSServiceTest()
        {
            Service = new WSService("https://apiservicecherad.azurewebsites.net");

            Assert.IsNotNull(Service);
        }

        [TestMethod()]
        public async void GetSeriesAsyncTest()
        {
            var series = await Service.GetSeriesAsync();

            Assert.IsNotNull(series);
        }

        [TestMethod()]
        public void DeleteSerieAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSerieAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostSerieAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutSerieAsyncTest()
        {
            Assert.Fail();
        }
    }
}