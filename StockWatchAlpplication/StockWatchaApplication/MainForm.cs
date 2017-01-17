namespace StockWatchApplication
{
    using Data;
    using FinancialInstruments;
    using LiveCharts;
    using LiveCharts.Configurations;
    using LiveCharts.Wpf;
    using MetroFramework.Controls;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Media;
    using StockWatchApplication.Visualization;

    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private static CultureInfo provider = CultureInfo.InvariantCulture;
        private static ChartValues<DataPoint> ChartValues1 { get; set; }
        private static ChartValues<DataPoint> ChartValues2 { get; set; }
        private static List<MetroTile> StockWatchTiles = new List<MetroTile>();
        private static List<Label> StockWatchLabels = new List<Label>();
        private static IRequestTimer mt;

        public MainForm(string username)
        {
            InitializeComponent();
            InitializeFormAndChart(username);
            StartTimer();
        }

        private void InitializeFormAndChart(string username)
        {
            #region Form
            this.StyleManager = FormStyleManager;
            #endregion

            #region User
            this.UsernameLabel.Text = username;
            #endregion

            InitializeChart.InitializeAll(this.StockIndexLineChart);
            


            #region DatePicker 1 and 2
            ChooseEndDate.Value = DateTime.Now;
            ChooseStartDate.Value = DateTime.Now.AddMonths(-6);
            #endregion

            #region Comboboxes 1 and 2

            ChooseStockIndex1.DataSource = new BindingSource(Index.Tickers, null);
            ChooseStockIndex1.DisplayMember = "Key";
            ChooseStockIndex1.ValueMember = "Value";

            Dictionary<string, string> copyTickers = new Dictionary<string, string>(Index.Tickers);
            copyTickers[""] = "";
            ChooseStockIndex2.DataSource = new BindingSource(copyTickers, null);
            ChooseStockIndex2.DisplayMember = "Key";
            ChooseStockIndex2.ValueMember = "Value";
            #endregion

            

            #region Chart Series
            ChooseStockIndex1.SelectedItem = ChooseStockIndex1.Items.OfType<KeyValuePair<string, string>>()
                                            .ToList().Select(x => x.Key == "S&&P 500").First();

            ChooseStockIndex2.SelectedItem = ChooseStockIndex2.Items.OfType<KeyValuePair<string, string>>()
                                             .ToList().Select(x => x.Key == "").First();
            ChooseStockIndex2.SelectedIndex = ChooseStockIndex2.FindStringExact("");
            #endregion

            #region Second Tab - Stock Watch
            AddTilesSecondTab();
            #endregion
        }

        private void ChooseStockIndex1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IfComboBoxesTheSame();
            UpdateFirstSeries();
        }

        private void ChooseStockIndex2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IfComboBoxesTheSame();
            UpdateSecondSeries();
        }

        private void UpdateFirstSeries()
        {
            //First Data Series
            if (ChooseStockIndex1.SelectedItem == null) return;

            string ticker1 = GetComboBoxValue(ChooseStockIndex1);

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

        private string GetComboBoxKey(ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                return "";
            }
            return ((KeyValuePair<string, string>)comboBox.SelectedItem).Key;
        }

        private string GetComboBoxValue(ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                return "";
            }
            return ((KeyValuePair<string, string>)comboBox.SelectedItem).Value;
        }

        private DateTime GetDate(DateTimePicker datePicker)
        {
            return datePicker.Value;
        }

        private void IfComboBoxesTheSame()
        {
            if (GetComboBoxKey(ChooseStockIndex1) == GetComboBoxKey(ChooseStockIndex2))
            {
                ChooseStockIndex2.SelectedItem = ChooseStockIndex2.Items.OfType<KeyValuePair<string, string>>().ToList().Select(x => x.Key == "").First();
                ChooseStockIndex2.SelectedIndex = ChooseStockIndex2.FindStringExact("");
            }
        }

        private void ChooseStartDate_ValueChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void ChooseEndDate_ValueChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void DateChanged()
        {
            //Validate
            if (GetDate(ChooseEndDate) < GetDate(ChooseStartDate))
            {
                MessageBox.Show("The end date cannot be before the startDate", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GetDate(ChooseEndDate).Subtract(GetDate(ChooseStartDate)).TotalDays > 365 * 2)
            {
                DialogResult result = MessageBox.Show("Please note that if you select a range longer than 2 years, the perfomance will degrate. Do you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            UpdateFirstSeries();
            UpdateSecondSeries();
        }

        private void AddTilesSecondTab()
        {
            const int widthHeight = 180;
            const int spaceBetween = 24;
            const int numberOfTilesInRow = 4;
            const int rows = 2;
            int startPositionX = 0;
            int startPositionY = 40;

            //Create the tiles
            for (int i = 0; i < numberOfTilesInRow * rows; i++)
            {
                int currentPositionX = startPositionX + widthHeight * i + spaceBetween * i;
                Size currentSize = new Size(widthHeight, widthHeight);
                Point currentPosition = new Point(currentPositionX, startPositionY);

                MetroTile stockTile = new MetroTile();
                stockTile.Size = currentSize;
                stockTile.Location = new Point(0, 0);
                stockTile.UseCustomBackColor = true;
                stockTile.BackColor = System.Drawing.Color.Transparent;
                stockTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
                stockTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
                StockWatchTiles.Add(stockTile);

                Label currentLabel = new Label();
                currentLabel.Size = currentSize;
                currentLabel.Location = currentPosition;
                currentLabel.Font = new Font(this.Font.FontFamily, 24, FontStyle.Bold);
                currentLabel.TextAlign = ContentAlignment.MiddleCenter;
                StockWatchLabels.Add(currentLabel);

                currentLabel.Controls.Add(stockTile);
                StockWatch.Controls.Add(currentLabel);

                if (i == numberOfTilesInRow - 1)
                {
                    startPositionY += +widthHeight + spaceBetween;
                    startPositionX += -widthHeight * numberOfTilesInRow - spaceBetween * numberOfTilesInRow;
                }
            }

            UpdateSecondTabData();
        }

        private static void StartTimer()
        {
            // Request data on interval
            mt = new RequestTimer();
            mt.StartWithCallback(5000, OnTimerElapsed);
        }

        private static void OnTimerElapsed(object sender, EventArgs eventArgs)
        {
            UpdateSecondTabData();
        }

        private static void UpdateSecondTabData()
        {
            //green or red color is assigned according to the price change 
            System.Drawing.Color greenColor = System.Drawing.Color.FromArgb(170, 0, 177, 89);
            System.Drawing.Color redColor = System.Drawing.Color.FromArgb(170, 209, 17, 65);

            //generate the new stock data
            List<Stock> allStocks = DataProvider.ProvideStockPriceChanges();

            //update each label and tile separately
            for (int i = 0; i < StockWatchTiles.Count; i++)
            {
                #region Blinking effect - for 0.015 seconds
                StockWatchLabels[i].BackColor = System.Drawing.Color.White;
                System.Threading.Thread.Sleep(15);
                #endregion

                #region UpdateThe information
                string currentTicker = allStocks[i].Ticker;
                decimal priceChange = allStocks[i].PercentagePriceChange.Price;
                System.Drawing.Color color = greenColor;
                if (priceChange < 0) color = redColor;
                StockWatchTiles[i].Text = currentTicker;
                StockWatchLabels[i].BackColor = color;
                StockWatchLabels[i].Text = String.Format("{0:f2}%", priceChange);
                #endregion
            }
        }
    }
}
