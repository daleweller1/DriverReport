using System;

namespace DriverReport.Model
{
    public class Trip
    {
        public Driver Driver { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double MilesDriven { get; set; }
        public Trip()
        {
        }

        public Trip(Driver driver, DateTime startTime, DateTime endTime, double milesDriven)
        {
            Driver = driver;
            StartTime = startTime;
            EndTime = endTime;
            MilesDriven = milesDriven;
        }

    }
}
