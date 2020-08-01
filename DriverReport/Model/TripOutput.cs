namespace DriverReport.Model
{
    public class TripOutput
    {
        public string DriverName { get; set; }
        public int MilesDriven { get; set; }
        public int MilesPerHour { get; set; }

        public TripOutput()
        {
        }

        public TripOutput(string driverName, int milesDriven, int milesPerHour)
        {
            DriverName = driverName;
            MilesDriven = milesDriven;
            MilesPerHour = milesPerHour;
        }
    }
}
