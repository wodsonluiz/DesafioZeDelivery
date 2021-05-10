using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<SpecificationGeographic>> Get()
        {
            return await _zeDeliveryService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<SpecificationGeographic> GetId(string id)
        {
            return await _zeDeliveryService.Get(id);
        }

        [HttpGet]
        [Route("{lon}/{lat}")]
        public SpecificationGeographic GetAddress(double lon, double lat)
        {
            return _zeDeliveryService.GetAddress(lon, lat);
        }

        [HttpPost]
        [Route("create")]
        public async Task<SpecificationGeographic> Post([FromBody] SpecificationGeographic specificationGeographic)
        {
            return await _zeDeliveryService.Create(specificationGeographic);
        }
    }
}
