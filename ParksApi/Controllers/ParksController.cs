using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksApi.Controllers
{
    public class ParksController : ControllerBase
    {

        private readonly ParksDataContext _db;
        private readonly IHttpContextAccessor _context;

        public ParksController(ParksDataContext db)
        {
            _db = db;
        }

        [HttpGet("/parks")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 24*60*60*360)]
        public async Task<ActionResult<GetParksResponse>> GetParks()
        {
            var response = await _db.MetroParks.Select(p => new GetMetroPark(p.Id, p.Reservation, p.Acreage, p.Notes)).ToListAsync();
            
            return Ok(new GetParksResponse(response));
        }

        [HttpGet("/parks/{id:int}")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 15)]
        public async Task<ActionResult<GetParksResponse>> GetPark(int id)
        {
            var response = await _db.MetroParks
                .Where(p => p.Id == id)
                .Select(p => new GetMetroPark(p.Id, p.Reservation, p.Acreage, p.Notes))
                .SingleOrDefaultAsync();

            if(response == null)
            {
                return NotFound();
            } else
            {
                return Ok(response);
            }
        }
    }



    public record Link(string Rel, string Href);

    public record GetMetroPark(int Id, string Reservation, string Acreage, string Notes);

    public record GetParksResponse(IList<GetMetroPark> Data, IList<Link> Links = default);

}
