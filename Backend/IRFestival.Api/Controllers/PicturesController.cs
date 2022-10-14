﻿using Azure.Storage.Blobs;
using IRFestival.Api.Common;
using IRFestival.Api.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public PicturesController(BlobUtility blobUtility)
        {
            BlobUtility = blobUtility;
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

            return Ok();
        }
    }
}
