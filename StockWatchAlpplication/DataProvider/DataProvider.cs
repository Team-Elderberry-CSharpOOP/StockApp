namespace Data
{
    using FinancialInstruments;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class DataProvider
    {
        const string dateFormat = "yyyy-MM-dd";
        const int dateColumn = 0;
        const int priceColumn = 6;
        const char delimitor = ',';

        public static Index ProvideData(string ticker, DateTime startDate, DateTime endDate, string frequency)
        {
            string file = GetData.DownloadData(ticker, startDate, endDate, frequency);
            var currentIndex = new Index(ticker, ReadData(file));
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
                if (line.Contains("Date")) continue;
                
                var values = line.Split(delimitor);
                DateTime date = DateTime.ParseExact(values[dateColumn], dateFormat, provider);
                decimal price = decimal.Parse(values[priceColumn]);
                DataPoint currentDataPoint = new DataPoint(date, price);
                allData.Add(currentDataPoint);
            };

            //remove the file
            reader.Close();
            File.Delete(file);
            
            //reorder data
            allData.Reverse();
            return allData;
        }
    }
}
