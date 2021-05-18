using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using DesafioZeDelivery.Core.Service;
using DesafioZeDelivery.Test.Common;
using DesafioZeDelivery.Test.Mock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioZeDelivery.Test.Service
{
    [TestClass]
    public class ZeDeliveryServiceTest
    {
        private readonly IZeDeliveryService _service;
        public ZeDeliveryServiceTest()
        {
            var settings = ServiceProviderCommon.Generator().GetRequiredService<IZeDeliveryDatabaseSettings>();
            var collection = new ZeDeliveryDatabaseSettingsMock(settings);

            _service = new ZeDeliveryService(collection.ConfigureMock(), settings);
        }

        [TestMethod]
        public void TestCreate()
        {
            var obj = new Partner().GeneratePartnerFake();
            var result = _service.Create(obj);

            Assert.IsNotNull(result.Result);
        }


        [TestMethod]
        public void TestGet()
        {
            var result = _service.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetId()
        {
            var obj = new Partner().GeneratePartnerFake();
            var resultInsert = _service.Create(obj);
            var id = resultInsert.Result;
            var resultListGetId = _service.Get(obj.id);

            Assert.IsNotNull(resultListGetId);
        }

        [TestMethod]
        public void TestRemove()
        {
            var obj = new Partner().GeneratePartnerFake();
            var resultInsert = _service.Create(obj);
            var id = resultInsert.Result;
            var resultRemove = _service.Remove(obj.id);

            Assert.IsTrue(resultRemove.Result);
        }
    }
}
