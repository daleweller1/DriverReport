using System.Collections.Generic;

namespace DriverReport.Model
{
    public class Report
    {
        public List<Driver> Drivers { get; set; }
        public List<Trip> Trips { get; set; }

        public Report(List<Driver> drivers, List<Trip> trips)
        {
            Drivers = drivers;
            Trips = trips;
        }
    }
}
