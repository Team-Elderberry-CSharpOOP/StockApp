using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialInstruments;
using Data;

namespace StockWatchApplication.Visualization.Chart
{
    class UpdateChartData
    {
        private void UpdateFirstSeries(ComboBox c1, ComboBox c2)
        {
            //First Data Series
            if (c1.SelectedItem == null) return;

            string ticker1 = GetComboBoxValue(c1);

            Index currentIndex = DataProvider.ProvideIndexSeries(
                ticker1,
                GetDate(ChooseStartDate),
                GetDate(ChooseEndDate),
                "d");

            ChartValues1 = new ChartValues<DataPoint>(currentIndex.Data);

            //Indexer is not support. Thus, I need to remove the old Series 
            this.StockIndexLineChart.Series.RemoveAt(0);

            this.StockIndexLineChart.Series.Insert(0, new LineSeries
            {
                Title = GetComboBoxKey(ChooseStockIndex1),
                Values = ChartValues1,
                PointGeometry = null,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 174, 219)),
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(35, 0, 174, 219)),
                StrokeThickness = 2.5
            });
        }

        private void UpdateSecondSeries()
        {
            //Second Data Serires
            if (ChooseStockIndex2.SelectedItem == null) return;
            if (GetComboBoxKey(ChooseStockIndex2) == "")
            {
                if (StockIndexLineChart.Series.Count == 2)
                {
                    StockIndexLineChart.Series.Remove(StockIndexLineChart.Series[1]);
                }
                return;
            }

            string ticker2 = GetComboBoxValue(ChooseStockIndex2);

            Index additionalIndex = DataProvider.ProvideIndexSeries(
            ticker2,
            GetDate(ChooseStartDate),
            GetDate(ChooseEndDate),
            "d");

            ChartValues2 = new ChartValues<DataPoint>(additionalIndex.Data);

            if (StockIndexLineChart.Series.Count == 2) StockIndexLineChart.Series.RemoveAt(1);
            StockIndexLineChart.Series.Add(new LineSeries
            {
                Title = GetComboBoxKey(ChooseStockIndex2),
                Values = ChartValues2,
                PointGeometry = null,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(124, 65, 153)),
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(35, 124, 65, 153)),
                StrokeThickness = 2.5
            });
        }
    }
}
