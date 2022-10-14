using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace IRFestival.Api.Options
{
    public class BlobSettingsOptions
    {
        public string ThumbsContainer { get; set; }
        public string PicturesContainer { get; set; }
    }
}
