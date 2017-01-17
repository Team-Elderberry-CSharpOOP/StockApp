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
        public static void InitializeAll(LiveCharts.WinForms.CartesianChart input)
        {
            InitializeMapper();
            ZoomChart(input);
            InitializeChartAxis(input);
        }

        private static void InitializeMapper()
        {
            var mapper = Mappers.Xy<DataPoint>()
                        .X(point => point.Date.Ticks)
                        .Y(point => (double)point.Price);

            Charting.For<DataPoint>(mapper);
        }

        private static void ZoomChart(LiveCharts.WinForms.CartesianChart input)
        {
            input.Zoom = ZoomingOptions.X;

            //add the blank series -at least one series shown in the chart
            input.Series.Add(new LineSeries());
        }

        private static void InitializeChartAxis(LiveCharts.WinForms.CartesianChart input)
        {
            input.AxisX.Add(new Axis
            {
                LabelFormatter = value => new System.DateTime((long)value).ToString("dd.MM.yyyy"),
                FontSize = 13.0,
                Separator = new Separator
                {
                    IsEnabled = false
                }
            });

            input.AxisY.Add(new Axis
            {
                FontSize = 15.0,
                LabelFormatter = value => String.Format("${0,000}", value),
            });
        }


    }
}
