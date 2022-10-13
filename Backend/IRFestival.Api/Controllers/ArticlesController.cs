using IRFestival.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Net;

namespace IRFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly CosmosClient _comsosClient;
        private readonly Container _websiteArticlesContainer;

        public ArticlesController(IConfiguration configuration)
        {
            
            _comsosClient = new CosmosClient(configuration.GetConnectionString("CosmosConnection"));
            _comsosClient.CreateDatabaseIfNotExistsAsync("IRFestivalArticles");

            var database = _comsosClient.GetDatabase("IRFestivalArticles");
            database.CreateContainerIfNotExistsAsync("WebsiteArticles", "/tag");

            _websiteArticlesContainer = _comsosClient.GetContainer("IRFestivalArticles", "WebsiteArticles");
        }

        [HttpPost]
        public async Task<ActionResult> CreateDummyArticle()
        {
            var article = new Article()
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now.Date,
                Message = "This is a dummy article",
                ImagePath = "url",
                Status = "Unpublished",
                Tag = "Tag",
                Title = "Dummy article"
            };

            await _websiteArticlesContainer.CreateItemAsync(article);
            return Ok(article);
        }

        [HttpGet("getAll")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Article))]
        public async Task<IActionResult> GetAsync()
        {
            var result = new List<Article>();

            var queryDefinition = _websiteArticlesContainer.GetItemLinqQueryable<Article>()
                .Where(p => p.Status == nameof(Status.Published))
                .OrderBy(p => p.Date);

            var iterator = queryDefinition.ToFeedIterator();
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                result = response.ToList();
            }

            return Ok(result);
        }
    }
}
