﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeasurementLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UDPWeatherBroadcaster;

namespace RestService.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    { //det virker!
        private static readonly List<Measure> WeatherList = new List<Measure>()
        {
          new Measure(1, DateTime.Now, "Location",1,2,3),
          new Measure(2, DateTime.Now, "location 2",2,3,4)
        };


        // GET: api/Weather
        [HttpGet]
        public IEnumerable<Measure> Get()
        {
            return WeatherList;
        }

        // GET: api/Weather/5
        [HttpGet]
        [Route( ("id/{id}"))]
        public Measure Get(int id)
        {
            return WeatherList.Find(i => i.Id==id);
        }

        // GET: api/Weather/5
        [HttpGet]
        [Route("Latest")]
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
        [HttpPut]
        [Route("{id}")]
        public void Put(int id,[FromBody] Measure value)
        {
            Measure weather = Get(id);
            if (weather != null)
            {
                weather.RandomTemperature = value.RandomTemperature;
                weather.MeasureTime = value.MeasureTime;
                weather.WindSpeed = value.WindSpeed;
                weather.DeviceLocation = value.DeviceLocation;
                weather.Rain = value.Rain;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
