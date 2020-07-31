using DriverReport.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DriverReport.Controller
{
    public class InputController
    {
        public Report GenerateReportFromFile(OpenFileDialog file)
        {
            var drivers = new List<Driver>();
            var trips = new List<Trip>();

            var sr = new StreamReader(file.FileName);

            string currentLine;
            while ((currentLine = sr.ReadLine()) != null) // Read the current line, set currentLine to its string value, and continue if it's not null
            {
                if (currentLine.StartsWith("driver", StringComparison.InvariantCultureIgnoreCase))
                {
                    var values = currentLine.Split(" ");
                    string driverName = values[1];
                    var driver = new Driver(driverName);
                    drivers.Add(driver);
                }
                else if (currentLine.StartsWith("trip", StringComparison.InvariantCultureIgnoreCase))
                {
                    var values = currentLine.Split(" ");
                    string driverName = values[1];
                    string startTimeString = values[2];
                    string endTimeString = values[3];
                    string milesDrivenString = values[4];

                    var driver = drivers.Where(driver => driverName == driver.Name).FirstOrDefault();
                    var startTime = DateTime.ParseExact(startTimeString, "HH:mm", CultureInfo.InvariantCulture);
                    var endTime = DateTime.ParseExact(endTimeString, "HH:mm", CultureInfo.InvariantCulture);
                    double milesDriven = Convert.ToDouble(milesDrivenString);

                    var trip = new Trip(driver, startTime, endTime, milesDriven);
                    trips.Add(trip);
                }
            }

            var report = new Report(drivers, trips);
            return report;
        }
    }
}
