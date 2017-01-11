namespace Data
{
    using System;
    using System.Net;

    internal static class GetData
    {
        const string fileDirectory = @"../../Resources/Data/{0}.csv";
        const string urlPrototype = @"http://ichart.yahoo.com/table.csv?s={0}&a={1}&b={2}&c={3}&d={4}&e={5}&f={6}&g={7}&ignore=.csv";

        #region DownloadData
        //downloading the data from yahoo finance
        internal static string DownloadData(string ticker, DateTime startDate, DateTime endDate, string frequency)
        {
            var webClient = new WebClient();
            string url = BuildUrl(ticker, startDate, endDate, frequency);
            string directory = string.Format(fileDirectory, ticker);
            webClient.DownloadFile(url, directory);
            return directory;
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

            return string.Format(urlPrototype,
                ticker,
                startMonth,
                startDay,
                startYear,
                endMonth,
                endDay,
                endYear,
                frequency);
        }
        #endregion
    }
}
