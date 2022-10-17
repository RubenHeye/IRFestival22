using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using IRFestival.Api.Common;
using IRFestival.Api.Domain;
using IRFestival.Api.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web;

namespace IRFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        public BlobUtility BlobUtility { get; }
        public readonly IConfiguration Configuration;

        public PicturesController(BlobUtility blobUtility, IConfiguration configuration)
        {
            BlobUtility = blobUtility;
            Configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string[]))]
        public async Task<ActionResult> GetAllPicturesUrls()
        {
            var container = BlobUtility.GetThumbsContainer();
            var result = container.GetBlobs()
                .Select(blob => BlobUtility.GetSasUri(container, blob.Name))
                .ToArray();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AppSettingsOptions))]
        public async Task<ActionResult> PostPicture(IFormFile file)
        {
            BlobContainerClient container = BlobUtility.GetPicturesContainer();
            var filename = $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}{HttpUtility.UrlPathEncode(file.FileName)}";
            await container.UploadBlobAsync(filename, file.OpenReadStream());

            await using (var client = new ServiceBusClient(Configuration.GetConnectionString("ServiceBusSenderConnection")))
            {
                // Create a sender for the queue
                ServiceBusSender sender = client.CreateSender(Configuration.GetValue<string>("QueueNameMails"));

                // Create a message that we can send
                MailModel model = new MailModel()
                {
                    Email = "ruben.heye@gmail.com",
                    Message = $"The picture {file.FileName} was uploaded!"
                };

                ServiceBusMessage message = new ServiceBusMessage(JsonConvert.SerializeObject(model));

                // Send the message
                await sender.SendMessageAsync(message);
            }

            return Ok();
        }
    }
}
