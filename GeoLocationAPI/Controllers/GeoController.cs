using GeoLocationAPI.Models;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoLocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        [HttpGet(template:"[action]/{ipAddress}")]
         public IActionResult GetCountry(string ipAdress)
        {
            using (var reader = new DatabaseReader(@"C:\Users\Shafntry\source\repos\db\Geo.mmdb"))
            {
                var response = reader.Country(ipAdress);

                var geoLocation = new GeoClass();
                geoLocation.CountryName = response.Country.Name;
                geoLocation.CountryIsoCode = response.Country.IsoCode;
                geoLocation.IsInEuropeanUnion = response.Country.IsInEuropeanUnion;

                return StatusCode(StatusCodes.Status200OK, geoLocation);
                Console.WriteLine(response.Country.IsoCode);
            }
        }


    }
}
