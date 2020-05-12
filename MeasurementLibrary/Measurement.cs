using System;

namespace MeasurementLibrary
{
    public class Measurement
    {
        public DateTime MeasureTime { get ; set; }
        public string DeviceLocation { get; set; }
        public int RandomTemperature { get; set; }
        public int Rain { get; set; }
        public int WindSpeed { get; set; }
        public int Id { get; set; }
    }
}
