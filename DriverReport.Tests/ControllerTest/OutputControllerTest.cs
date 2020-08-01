using DriverReport.Controller;
using DriverReport.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace DriverReport.Tests.ControllerTest
{
    public class OutputControllerTest
    {
        private OutputController outputController;

        public OutputControllerTest()
        {
            outputController = new OutputController();
        }

        [Fact]
        public void GenerateReportOutput_Success()
        {
            var d1 = new Driver("Alex");
            var d2 = new Driver("Bob");
            var d3 = new Driver("Carl");

            // d1 goes 60 miles, 1 hour, 60 mph -- over 1 trip
            var d1trip1 = new Trip();
            d1trip1.Driver = d1;
            d1trip1.StartTime = new DateTime(2020, 8, 1, 0, 0, 0);
            d1trip1.EndTime = new DateTime(2020, 8, 1, 1, 0, 0);
            d1trip1.MilesDriven = 60;

            // d2 goes 80 miles, 2 hours, 40 mph -- over 2 trips
            var d2trip1 = new Trip();
            d2trip1.Driver = d2;
            d2trip1.StartTime = new DateTime(2020, 8, 1, 0, 0, 0);
            d2trip1.EndTime = new DateTime(2020, 8, 1, 1, 0, 0);
            d2trip1.MilesDriven = 30;

            var d2trip2 = new Trip();
            d2trip2.Driver = d2;
            d2trip2.StartTime = new DateTime(2020, 8, 1, 0, 0, 0);
            d2trip2.EndTime = new DateTime(2020, 8, 1, 1, 0, 0);
            d2trip2.MilesDriven = 50;

            // d3 goes 5 miles, 12 minutes, 25 mph -- over 1 trip
            var d3trip1 = new Trip();
            d3trip1.Driver = d3;
            d3trip1.StartTime = new DateTime(2020, 8, 1, 0, 0, 0);
            d3trip1.EndTime = new DateTime(2020, 8, 1, 0, 12, 0);
            d3trip1.MilesDriven = 5;

            var drivers = new List<Driver>
            {
                d1, d2, d3
            };

            var trips = new List<Trip>
            {
                d1trip1, d2trip1, d2trip2, d3trip1
            };

            var report = new Report(drivers, trips);

            string actual = outputController.GenerateReportOutput(report);
            string expected =
                "Bob: 80 miles @ 40 mph\r\n" +
                "Alex: 60 miles @ 60 mph\r\n" +
                "Carl: 5 miles @ 25 mph\r\n";

            Assert.Equal(expected, actual);
        }
    }
}
