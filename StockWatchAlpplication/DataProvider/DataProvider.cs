namespace Data
{
    using FinancialInstruments;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class DataProvider
    {
        public static Index ProvideData(string ticker, DateTime startDate, DateTime endDate, string frequency)
        {
            string file = GetData.DownloadData(ticker, startDate, endDate, frequency);
            var currentIndex = new Index("S&P500", ReadData(file));
            return currentIndex;
        }

        private static List<DataPoint> ReadData(string file)
        {
            // reads the data from a csv file
            CultureInfo provider = CultureInfo.InvariantCulture;
            StreamReader reader = new StreamReader(File.OpenRead(file));
            var allData = new List<DataPoint>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Contains("Date"))
                {
                    continue;
                }

                var values = line.Split(',');
                DateTime date = DateTime.ParseExact(values[0], "yyyy-MM-dd", provider);
                decimal price = decimal.Parse(values[6]);
                DataPoint currentDataPoint = new DataPoint(date, price);
                allData.Add(currentDataPoint);
            };

            //remove the data
            reader.Close();
            File.Delete(file);
            
            allData.Reverse();
            return allData;
        }
    }
}
