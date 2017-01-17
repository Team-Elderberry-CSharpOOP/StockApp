using FinancialInstruments;
using LiveCharts;
using LiveCharts.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.WinForms;
using LiveCharts.Wpf;

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

        public static void ZoomChart(LiveCharts.WinForms.CartesianChart input)
        {
            input.Zoom = ZoomingOptions.X;

            //add the blank series -at least one series shown in the chart
            input.Series.Add(new LineSeries());
        }
    }
}
