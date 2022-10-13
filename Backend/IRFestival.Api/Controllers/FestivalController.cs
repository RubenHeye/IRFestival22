using System.Net;

using Microsoft.AspNetCore.Mvc;

using IRFestival.Api.Data;
using IRFestival.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace IRFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalController : ControllerBase
    {
        private readonly FestivalDbContext _ctx;

        public FestivalController(FestivalDbContext context)
        {
            _ctx = context;
        }

        [HttpGet("LineUp")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Schedule))]
        public async Task<ActionResult> GetLineUp()
        {
            var festival = await _ctx.Festivals.FirstOrDefaultAsync();
            var schedule = await _ctx.Schedules.Where(x => x.FestivalId.Equals(festival.Id)).FirstOrDefaultAsync();
            
            var scheduleItems = await _ctx.ScheduleItems.Where(x => x.ScheduleId.Equals(schedule.Id)).ToListAsync();

            foreach(var item in scheduleItems)
            {
                schedule.Items.Add(item);
            }
            return Ok(schedule);
        }

        [HttpGet("Artists")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Artist>))]
        public async Task<ActionResult> GetArtists()
        {
            var artists = await _ctx.Artists.ToListAsync();
            return Ok(artists);
        }

        [HttpGet("Stages")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Stage>))]
        public async Task<ActionResult> GetStages()
        {
            var stages = await _ctx.Stages.ToListAsync();
            return Ok(stages);
        }

        [HttpPost("Favorite")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ScheduleItem))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> SetAsFavorite(int id)
        {
            var schedule = await _ctx.ScheduleItems.Include(x => x.Schedule).FirstOrDefaultAsync(x => x.ScheduleId.Equals(id));

            if (schedule != null)
            {
                schedule.IsFavorite = !schedule.IsFavorite;
                _ctx.ScheduleItems.Update(schedule);
                await _ctx.SaveChangesAsync();
                return Ok(schedule);
            }
            return NotFound();
        }

    }
}