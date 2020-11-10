using Core.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace QueuePublisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> logger;
        private readonly IPublishEndpoint endpoint;

        public TestController(ILogger<TestController> logger, IPublishEndpoint endpoint)
        {
            this.logger = logger;
            this.endpoint = endpoint;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] string value)
        {
            await endpoint.Publish<IMessage>(new
            {
                Data = value
            });

            logger.LogInformation("POST ok, msg: {0}", value);
            return Ok();
        }
    }

    public class DTO
    {
        public string Data { get; set; }
    }
}
