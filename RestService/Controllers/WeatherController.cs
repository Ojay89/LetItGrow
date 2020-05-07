using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeasurementLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDPWeatherBroadcaster;

namespace RestService.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    { //det virker!
        private static readonly List<Measure> WeatherList = new List<Measure>()
        {
          new Measure(DateTime.Now, "Location",1,2,3),
          new Measure(DateTime.Now, "location 2",2,3,4)
        };


        // GET: api/Weather
        [HttpGet]
        public IEnumerable<Measure> Get()
        {
            return WeatherList;
        }

        // GET: api/Weather/5
        [HttpGet]
        [Route( ("location/{substring}"))]
        public Measure Get(string substring)
        {
            return WeatherList.Find(i => i.DeviceLocation.Equals(substring));
        }

        // GET: api/Weather/5
        [HttpGet]
        [Route(("/Latest"))]
        public Measure GetLatest()
        {
            return WeatherList.Last();
        }



        // POST: api/Weather
        [HttpPost]
        public void Post([FromBody] Measure value)
        {
            WeatherList.Add(value);
        }

        // PUT: api/Weather/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
