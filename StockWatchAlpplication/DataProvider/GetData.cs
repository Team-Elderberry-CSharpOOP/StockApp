namespace Data
{
    using FinancialInstruments;
    using System;
    using System.Net;
    using System.Text;

    internal static class GetData
    {
        const string fileDirectory = @"../../Resources/Data/{0}.{1}";
        const string txtFileExtension = @"txt";
        const string csvFileExtension = @"csv";
        const string urlDataSeriesPrototype = @"http://ichart.yahoo.com/table.csv?s={0}&a={1}&b={2}&c={3}&d={4}&e={5}&f={6}&g={7}&ignore=.csv";
        const string urlCurrentDataPrototype = @"http://finance.google.com/finance/info?client=ig&q={0}";
        const string currentDataFileName = "CurrenData";

        #region DownloadData
        //downloading the data from yahoo finance using the built URL
        internal static string ProvideDownloadedFile(string ticker, DateTime startDate, DateTime endDate, string frequency)
        {
           string url = BuildUrl(ticker, startDate, endDate, frequency);
           return  DownloadTheData(url, ticker, csvFileExtension);
        }

        internal static string ProvideDownloadedFile()
        {
            string url = BuildUrl();
            return DownloadTheData(url, currentDataFileName, txtFileExtension);
        }
        #endregion

        #region Create URL
        //creating the url with the provided infroamtion
        private static string BuildUrl(string ticker, DateTime startDate, DateTime endDate, string frequency)
        {
            int startMonth = startDate.Month - 1; //in yahoo finance the months start from zero i.e Jannuary = 0
            int startDay = startDate.Day;
            int startYear = startDate.Year;

            int endMonth = endDate.Month - 1; //in yahoo finance the months start from zero i.e Jannuary = 0
            int endDay = endDate.Day;
            int endYear = endDate.Year;

            return string.Format(urlDataSeriesPrototype,
                ticker,
                startMonth,
                startDay,
                startYear,
                endMonth,
                endDay,
                endYear,
                frequency);
        }

        private static string BuildUrl()
        {
            StringBuilder allTickers = new StringBuilder();

            foreach (StockTickers stockTicker in Enum.GetValues(typeof(StockTickers)))
            {
                allTickers.Append(stockTicker + ",");
                
            }

            string tickers = allTickers.ToString();
            tickers = tickers.Substring(0, tickers.Length - 1);

            return string.Format(urlCurrentDataPrototype, tickers);
        }
        #endregion

        #region Download and Save the data
        private static string DownloadTheData(string url, string fileName, string fileExtension)
        {
            var webClient = new WebClient();
            string directory = string.Format(fileDirectory, fileName, fileExtension);
            webClient.DownloadFile(url, directory);
            return directory;
        }
        #endregion
    }
}
