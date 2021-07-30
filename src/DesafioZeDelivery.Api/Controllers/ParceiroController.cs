using DesafioZeDelivery.Abstraction.Interfaces;
using DesafioZeDelivery.Domain.Models.Dto;
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
        public async Task<IEnumerable<Partner>> Get()
        {
            return await _zeDeliveryService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Partner> GetId(string id)
        {
            return await _zeDeliveryService.Get(id);
        }

        [HttpGet]
        [Route("{lon}/{lat}")]
        public List<Partner> GetAddress(double lon, double lat)
        {
            return _zeDeliveryService.GetAddress(lon, lat);
        }

        [HttpPost]
        public async Task<Partner> Post([FromBody] Partner specificationGeographic)
        {
            return await _zeDeliveryService.Create(specificationGeographic);
        }
    }
}
