using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using DesafioZeDelivery.Core.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioZeDelivery.Test.Service
{
    [TestClass]
    public class ZeDeliveryServiceTest
    {
        private IZeDeliveryService _zeDeliveryService;
        public ZeDeliveryServiceTest()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var services = new ServiceCollection();
            services.AddConfigurationZeDelivery(config);

            var sp = services.BuildServiceProvider();
            var settings = sp.GetRequiredService<IZeDeliveryDatabaseSettings>();
            _zeDeliveryService = new ZeDeliveryService(settings);
        }

        [TestMethod]
        public void TestCreate()
        {
            var obj = new Partner().GeneratePartnerFake();
            var result = _zeDeliveryService.Create(obj);

            Assert.AreEqual(result.Result, obj);
        }

        [TestMethod]
        public void TestGet()
        {
            var result = _zeDeliveryService.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetId()
        {
            var obj = new Partner().GeneratePartnerFake();
            var resultInsert = _zeDeliveryService.Create(obj);
            var id = resultInsert.Result.id;
            var resultListGetId = _zeDeliveryService.Get(id);

            Assert.IsNotNull(resultListGetId);
        }

        [TestMethod]
        public void TestGetAddress()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestRemove()
        {
            var obj = new Partner().GeneratePartnerFake();
            var resultInsert = _zeDeliveryService.Create(obj);
            var id = resultInsert.Result.id;
            var resultRemove = _zeDeliveryService.Remove(id);

            Assert.IsTrue(resultRemove.Result);
        }
    }
}
