using FinancialInstruments;
using LiveCharts;
using LiveCharts.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatchApplication.Visualization
{
    public static class InitializeChart
    {
        public static void InitializeMapper()
        {
            var mapper = Mappers.Xy<DataPoint>()
                        .X(point => point.Date.Ticks)
                        .Y(point => (double)point.Price);

            Charting.For<DataPoint>(mapper);
        }
    }
}
