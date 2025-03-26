using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;

namespace ticket_hub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly IConfiguration _configuration;

        public PurchaseController(ILogger<PurchaseController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Received get request");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Purchase purchase)
        {
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            // send ticket request to Azure
            string queueName = "tickethub";
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(purchase);

            // send string message to queue
            await queueClient.SendMessageAsync(message);


            return Ok("Thank you, " + purchase.Name + ". Your purchase is being processed");
        }
    }
}
