using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using DesafioZeDelivery.Core.Service;
using DesafioZeDelivery.Test.Common;
using DesafioZeDelivery.Test.Mock;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace DesafioZeDelivery.Test.Service
{
    [TestFixture]
    public class ZeDeliveryServiceTest
    {
        private IZeDeliveryService _service;

        [OneTimeSetUp]
        public void Setup()
        {
            var settings = ServiceProviderCommon.Generator().GetRequiredService<IZeDeliveryDatabaseSettings>();
            var collection = new ZeDeliveryDatabaseSettingsMock(settings);

            _service = new ZeDeliveryService(collection.ConfigureMock(), settings);
        }

        [Test]
        public void TestCreate()
        {
            var obj = new Partner().GeneratePartnerFake();
            var result = _service.Create(obj);

            Assert.IsNotNull(result.Result);
        }


        [Test]
        public void TestGet()
        {
            var result = _service.Get();
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestGetId()
        {
            var obj = new Partner().GeneratePartnerFake();
            var resultInsert = _service.Create(obj);
            var id = resultInsert.Result;
            var resultListGetId = _service.Get(obj.id);

            Assert.IsNotNull(resultListGetId);
        }

        [Test]
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
