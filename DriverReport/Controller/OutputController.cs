using DriverReport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriverReport.Controller
{
    public class OutputController
    {
        public string GenerateReportOutput(Report report)
        {
            StringBuilder sb = new StringBuilder();

            var tripOutputList = this.GenerateSortedOutputList(report.Drivers, report.Trips);

            foreach(var tripOutput in tripOutputList)
            {
                if (tripOutput.MilesDriven > 0)
                {
                    sb.Append($"{tripOutput.DriverName}: {tripOutput.MilesDriven} miles @ {tripOutput.MilesPerHour} mph");
                    sb.Append("\r\n"); // Line break in Windows
                }
                else
                {
                    sb.Append($"{tripOutput.DriverName}: 0 miles");
                    sb.Append("\r\n"); // Line break in Windows
                }
            }

            return sb.ToString();
        }

        private IOrderedEnumerable<TripOutput> GenerateSortedOutputList(List<Driver> drivers, List<Trip> trips)
        {
            var outputList = new List<TripOutput>();

            foreach (var driver in drivers)
            {
                var driverTrips = trips.Where(trip => trip.Driver == driver);

                double totalMilesDriven = 0;
                double totalHoursDriven = 0;

                foreach (var trip in driverTrips)
                {
                    TimeSpan tripLength = trip.EndTime - trip.StartTime;
                    double tripMph = trip.MilesDriven / tripLength.TotalHours;

                    if (tripMph >= 5 && tripMph <= 100)
                    {
                        totalMilesDriven += trip.MilesDriven;
                        totalHoursDriven += tripLength.TotalHours;
                    }
                }

                int roundedMph = 0;
                if (totalHoursDriven > 0)
                {
                    roundedMph = Convert.ToInt32(Math.Round(totalMilesDriven / totalHoursDriven));
                }

                int roundedTotalMilesDriven = Convert.ToInt32(Math.Round(totalMilesDriven));

                var tripOutput = new TripOutput(driver.Name, roundedTotalMilesDriven, roundedMph);

                outputList.Add(tripOutput);
            }

            var sortedOutputList = outputList.OrderByDescending(output => output.MilesDriven);

            return sortedOutputList;
        }
    }
}
