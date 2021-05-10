using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesafioZeDelivery.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParceiroController : ControllerBase
    {
        private readonly IZeDeliveryService _zeDeliveryService;

        public ParceiroController(IZeDeliveryService zeDeliveryService)
        {
            _zeDeliveryService = zeDeliveryService;
        }

        [HttpGet]
        public IEnumerable<SpecificationGeographic> Get()
        {
            return _zeDeliveryService.Get();
        }

        [HttpGet]
        [Route("GetId")]
        public SpecificationGeographic GetId(string id)
        {
            return _zeDeliveryService.Get(id);
        }

        [HttpGet]
        [Route("GetAddress")]
        public SpecificationGeographic GetAddress(double lon, double lat)
        {
            return _zeDeliveryService.GetAddress(lon, lat);
        }

        [HttpPost]
        public SpecificationGeographic Post([FromBody] SpecificationGeographic specificationGeographic)
        {
            return _zeDeliveryService.Create(specificationGeographic);
        }
    }
}
