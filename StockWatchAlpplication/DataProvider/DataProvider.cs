namespace Data
{
    using FinancialInstruments;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class DataProvider
    {
        const string headerIdentificator = "Date";
        const string dateFormat = "yyyy-MM-dd";
        const int dateColumn = 0;
        const int priceColumn = 6;
        const char delimitor = ',';
        const string tickerIdentifier = @"""t""";
        const string exchangeIdentifier = @"""t""";
        const string priceIdentifier = @"""l""";
        const string priceChangeIdentifier = @"""c""";
        const string percentagePriceChangeIdentifier = @"""cp""";
        const string dateIdentifier = @"""lt_dts""";
        const string doubleQuotes = @"""";

        public static Index ProvideIndexSeries(string ticker, DateTime startDate, DateTime endDate, string frequency)
        {
            string file = GetData.ProvideDownloadedFile(ticker, startDate, endDate, frequency);
            var currentIndex = new Index(ticker, ReadDataSeries(file));
            return currentIndex;
        }

        public static List<Stock> ProvideStockPriceChanges()
        {
            string file = GetData.ProvideDownloadedFile();
            var stocks = ReadPriceChanges(file);
            return stocks;
        }

        //Read a data series - historical data
        private static List<DataPoint> ReadDataSeries(string file)
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

        //Read and provide the current price change
        private static List<Stock> ReadPriceChanges(string file)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            StreamReader reader = new StreamReader(File.OpenRead(file));
            var allStocks = new List<Stock>();
            var line = reader.ReadLine();
            var data = line.Split(',');

            string ticker = null;
            string exchange = null;
            decimal price = decimal.MinValue;
            decimal priceChange = decimal.MinValue;
            decimal percentagePriceChange = decimal.MinValue;
            DateTime date = default(DateTime);


            foreach (var item in data)
            {
                #region Search For Identifiers
                if (item.Contains(tickerIdentifier))
                {
                    ticker = ExtractValueFromString(item, tickerIdentifier);
                }
                else if (item.Contains(exchangeIdentifier))
                {
                    exchange = ExtractValueFromString(item, exchangeIdentifier);
                }
                else if (item.Contains(dateIdentifier))
                {
                    string dateTimeAsString = ExtractValueFromString(item, dateIdentifier);
                    date = DateTime.Parse(dateTimeAsString, null, System.Globalization.DateTimeStyles.RoundtripKind);
                }
                else if (item.Contains(priceIdentifier))
                {
                    price = decimal.Parse(ExtractValueFromString(item, priceIdentifier));
                }
                else if (item.Contains(priceChangeIdentifier))
                {
                    priceChange = decimal.Parse(ExtractValueFromString(item, priceChangeIdentifier));
                }
                else if (item.Contains(percentagePriceChangeIdentifier))
                {
                    percentagePriceChange = decimal.Parse(ExtractValueFromString(item, percentagePriceChangeIdentifier));
                }
                #endregion

                #region If all the data is collected
                //Check if all the nessecary data is collected
                if (string.IsNullOrEmpty(ticker) &&
                    string.IsNullOrEmpty(exchange) &&
                    price != decimal.MinValue &&
                    priceChange != decimal.MinValue &&
                    percentagePriceChange != decimal.MinValue &&
                    date != default(DateTime))
                {
                    //having the full information we can create the stock
                    Stock currentStock = CreateStock(ticker, exchange, date, price, priceChange, percentagePriceChange);
                    allStocks.Add(currentStock);

                    //clear the variables for the next stock
                    ticker = null;
                    exchange = null;
                    price = decimal.MinValue;
                    priceChange = decimal.MinValue;
                    percentagePriceChange = decimal.MinValue;
                }
                #endregion
            }

            return allStocks;
        }

        //Extracts the value corresponding to the identier as string
        private static string ExtractValueFromString(string text, string identifier)
        {
            int startIndex = text.Substring(identifier.IndexOf(identifier) + text.Length).IndexOf(doubleQuotes);
            int length = text.LastIndexOf(doubleQuotes) - startIndex;

            return text.Substring(startIndex, length);
        }

        //Given the collected data create a new Stock
        private static Stock CreateStock(string ticker, string exchange, DateTime date,  
                                         decimal price, decimal priceChange, decimal percentagePriceChange)
        {
            DataPoint datePrice = new DataPoint(date, price);
            DataPoint datePriceChange = new DataPoint(date, priceChange);
            DataPoint datePercentagePriceChange = new DataPoint(date, percentagePriceChange);

            Stock currentStock = new Stock(ticker, datePrice, datePriceChange, datePercentagePriceChange, exchange);
            return currentStock;
        }
    }
}