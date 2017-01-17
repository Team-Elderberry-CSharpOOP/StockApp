namespace StockWatchApplication.Data.DataReaders
{
    using Models.Utils;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    internal static class ReadDataFromFile
    {
        const int dateColumn = 0;
        const int priceColumn = 6;
        const char delimitor = ',';
        const string headerIdentificator = "Date";
        const string dateFormat = "yyyy-MM-dd";

        //Read a data series - historical data
        internal static IList<DataPoint> ReadDataSeriesFromFile(string file)
        {
            // reads the data from a csv file
            CultureInfo provider = CultureInfo.InvariantCulture;
            StreamReader reader = new StreamReader(File.OpenRead(file));
            var dataSeries = new List<DataPoint>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Contains(headerIdentificator)) continue; //skip the headers

                //take only the date and the adjusted close price. Create a new DataPoint
                var values = line.Split(delimitor);
                var date = DateTime.ParseExact(values[dateColumn], dateFormat, provider);
                var price = decimal.Parse(values[priceColumn]);
                DataPoint currentDataPoint = new DataPoint(date, price);

                //add the current DataPoint into the data series
                dataSeries.Add(currentDataPoint);
            };

            //remove the file
            reader.Close();
            File.Delete(file);

            //reorder data
            dataSeries.Reverse();
            return dataSeries;
        }

    }
}
