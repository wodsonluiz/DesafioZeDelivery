using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Common;
using DesafioZeDelivery.Core.Models;
using DesafioZeDelivery.Core.Service;
using DesafioZeDelivery.Test.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioZeDelivery.Test.Service
{
    [TestClass]
    public class ZeDeliveryServiceTest
    {
        private IZeDeliveryService _zeDeliveryService;
        private IQueryDataBase _queryDataBase;
        public ZeDeliveryServiceTest()
        {
            var settings = ServiceProviderCommon.Generator().GetRequiredService<IZeDeliveryDatabaseSettings>();
            _queryDataBase = new QueryDataBase(settings);
            _zeDeliveryService = new ZeDeliveryService(settings, _queryDataBase);
        }

        [TestMethod]
        public void TestCreate()
        {
            var obj = new Partner().GeneratePartnerFake();
            var result = _zeDeliveryService.Create(obj);

            Assert.IsNotNull(result.Result);
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
            var id = resultInsert.Result;
            var resultListGetId = _zeDeliveryService.Get(obj.id);

            Assert.IsNotNull(resultListGetId);
        }

        [TestMethod]
        public void TestRemove()
        {
            var obj = new Partner().GeneratePartnerFake();
            var resultInsert = _zeDeliveryService.Create(obj);
            var id = resultInsert.Result;
            var resultRemove = _zeDeliveryService.Remove(obj.id);

            Assert.IsTrue(resultRemove.Result);
        }
    }
}
