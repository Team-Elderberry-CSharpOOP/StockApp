namespace StockWatchApplication
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using Timers;
    using Models;
    using Visualization;
    using Visualization.Chart;
    using Visualization.ComboBoxCreator;
    using Visualization.DatePickerCreator;
    using Visualization.TilesCreator;

    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private static CultureInfo provider = CultureInfo.InvariantCulture;
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
            CreateTiles.AddTilesSecondTab(this.Font, this.StockWatch);
            #endregion
        }

        private void ChooseStockIndex1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisualizeComboBox.IfComboBoxesTheSame(ChooseStockIndex1, ChooseStockIndex2);
            UpdateChartData.UpdateFirstSeries(this.StockIndexLineChart, this.ChooseStockIndex1, this.ChooseStockIndex2, this.ChooseStartDate, this.ChooseEndDate);
        }

        private void ChooseStockIndex2_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisualizeComboBox.IfComboBoxesTheSame(ChooseStockIndex1, ChooseStockIndex2);
            UpdateChartData.UpdateSecondSeries(this.StockIndexLineChart, this.ChooseStockIndex1, this.ChooseStockIndex2, this.ChooseStartDate, this.ChooseEndDate);
        }

        private void ChooseStartDate_ValueChanged(object sender, EventArgs e)
        {
            CreateDatePicker.DateChanged(this.StockIndexLineChart, this.ChooseStockIndex1, this.ChooseStockIndex2, this.ChooseStartDate, this.ChooseEndDate);
        }

        private void ChooseEndDate_ValueChanged(object sender, EventArgs e)
        {
            CreateDatePicker.DateChanged(this.StockIndexLineChart, this.ChooseStockIndex1, this.ChooseStockIndex2, this.ChooseStartDate, this.ChooseEndDate);
        }

        private static void StartTimer()
        {
            // Request data on interval
            mt = new RequestTimer();
            mt.StartWithCallback(5000, OnTimerElapsed);
        }

        private static void OnTimerElapsed(object sender, EventArgs eventArgs)
        {
            CreateTiles.UpdateSecondTabData();
        }
    }
}
