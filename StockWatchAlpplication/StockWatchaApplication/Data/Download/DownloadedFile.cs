namespace StockWatchApplication.Data.Download
{
    using System;
    using System.Net;
    using Models;

    public static class DownloadedFile
    {
        const string currentDataFileName = "CurrenData";
        const string fileDirectory = @"../../Resources/Data/{0}.{1}";
        const string txtFileExtension = @"txt";
        const string csvFileExtension = @"csv";

        internal static string ProvideHistoridalDataFile(string name, DateTime startDate, DateTime endDate, string frequency)
        {
            var ticker = Index.Tickers[name];

            string url = URL.BuildURLHistoricalData(ticker, startDate, endDate, frequency);
            return DownloadTheData(url, ticker, csvFileExtension);
        }

        internal static string ProvideCurrentDataFile()
        {
            string url = URL.BuildURLCurrentPrices();
            return DownloadTheData(url, currentDataFileName, txtFileExtension);
        }

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
