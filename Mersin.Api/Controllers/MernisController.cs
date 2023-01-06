using Mersin.Api.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mersin.Api.Controllers
{
    [Route("api/[controller]")] ///[action]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MernisController : ControllerBase
    {
        private readonly MernisContext context;

        public MernisController(MernisContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            //DateTime start = DateTime.Now;

            var result = context.Citizens.Take(10).ToList();  // Take -> Mssqldeki top - Postgresql ya da sqlite daki limit yerine geçiyor

            //DateTime stop = DateTime.Now;
            //TimeSpan timeSpan = stop - start;  // Kaç mili saniye sürdüğünü test etmmek için - gelen endpointin ne kadar sürede döndüğü önemlidir.

            //var sonuc = timeSpan.Milliseconds;

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }

        }

        [HttpGet("[action]/{tcno}")]

        public IActionResult GetbyTcNo(string tcno)
        {

            var result = context.Citizens.FirstOrDefault(p => p.NationalIdentifier == tcno);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
