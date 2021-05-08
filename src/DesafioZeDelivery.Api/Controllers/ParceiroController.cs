using DesafioZeDelivery.Api.Models;
using DesafioZeDelivery.Api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioZeDelivery.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParceiroController : ControllerBase
    {
        private readonly ILogger<ParceiroController> _logger;
        private readonly IZeDeliveryService _zeDeliveryService;

        public ParceiroController(ILogger<ParceiroController> logger, IZeDeliveryService zeDeliveryService)
        {
            _zeDeliveryService = zeDeliveryService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<SpecificationGeographic> Get()
        {
            return _zeDeliveryService.Get();
        }

        [HttpPost]
        public SpecificationGeographic Post([FromBody] SpecificationGeographic specificationGeographic)
        {
            return _zeDeliveryService.Create(specificationGeographic);
        }
    }
}
