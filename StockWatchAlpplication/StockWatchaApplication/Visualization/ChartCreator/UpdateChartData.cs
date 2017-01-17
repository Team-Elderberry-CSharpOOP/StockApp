namespace StockWatchApplication.Visualization.Chart
{
    using ComboBoxCreator;
    using Data.Providers;
    using DatePickerCreator;
    using LiveCharts;
    using LiveCharts.Wpf;
    using MetroFramework.Controls;
    using Models.Utils;
    using System.Windows.Forms;
    using System.Windows.Media;

    public static class UpdateChartData
    {
        private static ChartValues<DataPoint> ChartValues1 { get; set; }
        private static ChartValues<DataPoint> ChartValues2 { get; set; }

        //FirstSeries Update
        public static void UpdateFirstSeries(LiveCharts.WinForms.CartesianChart input, ComboBox combo1, ComboBox combo2, MetroDateTime startDate, MetroDateTime endDate)
        {
            //First Data Series
            if (combo1.SelectedItem == null) return;

            string ticker1 = VisualizeComboBox.GetComboBoxKey(combo1);

            var currentIndex = ProvideIndexHistoricalData.Provide(
                ticker1,
                CreateDatePicker.GetDate(startDate),
                CreateDatePicker.GetDate(endDate),
                "d");

            ChartValues1 = new ChartValues<DataPoint>(currentIndex.HistoricalData);

            //Indexer is not support. Thus, I need to remove the old Series 
            input.Series.RemoveAt(0);

            input.Series.Insert(0, new LineSeries
            {
                Title = VisualizeComboBox.GetComboBoxKey(combo1),
                Values = ChartValues1,
                PointGeometry = null,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 174, 219)),
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(35, 0, 174, 219)),
                StrokeThickness = 2.5
            });
        }

        //SecondSeries Update
        public static void UpdateSecondSeries(LiveCharts.WinForms.CartesianChart input, ComboBox c1, ComboBox c2, MetroDateTime startDate, MetroDateTime endDate)
        {
            //Second Data Series
            if (c2.SelectedItem == null) return;
            if (VisualizeComboBox.GetComboBoxKey(c2) == "")
            {
                if (input.Series.Count == 2)
                {
                    input.Series.Remove(input.Series[1]);
                }
                return;
            }

            string ticker2 = VisualizeComboBox.GetComboBoxKey(c2);

            var additionalIndex = ProvideIndexHistoricalData.Provide(
            ticker2,
            CreateDatePicker.GetDate(startDate),
            CreateDatePicker.GetDate(endDate),
            "d");

            ChartValues2 = new ChartValues<DataPoint>(additionalIndex.HistoricalData);

            if (input.Series.Count == 2) input.Series.RemoveAt(1);
            input.Series.Add(new LineSeries
            {
                Title = VisualizeComboBox.GetComboBoxKey(c2),
                Values = ChartValues2,
                PointGeometry = null,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(124, 65, 153)),
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(35, 124, 65, 153)),
                StrokeThickness = 2.5
            });
        }

    }
}
