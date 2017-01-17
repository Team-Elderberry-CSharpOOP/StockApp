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
    using Visualization.ComboBoxCreator;
    using StockWatchApplication.Visualization.Chart;
    using StockWatchApplication.Visualization.TilesCreator;

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
            IfComboBoxesTheSame();
            UpdateChartData.UpdateFirstSeries(this.StockIndexLineChart, this.ChooseStockIndex1, this.ChooseStockIndex2, this.ChooseStartDate, this.ChooseEndDate);
        }

        private void ChooseStockIndex2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IfComboBoxesTheSame();
            UpdateChartData.UpdateSecondSeries(this.StockIndexLineChart, this.ChooseStockIndex1, this.ChooseStockIndex2, this.ChooseStartDate, this.ChooseEndDate);
        }


        private DateTime GetDate(DateTimePicker datePicker)
        {
            return datePicker.Value;
        }

        private void IfComboBoxesTheSame()
        {
            if (VisualizeComboBox.GetComboBoxKey(ChooseStockIndex1) == VisualizeComboBox.GetComboBoxKey(ChooseStockIndex2))
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
            UpdateChartData.UpdateFirstSeries(this.StockIndexLineChart, this.ChooseStockIndex1, this.ChooseStockIndex2, this.ChooseStartDate, this.ChooseEndDate);
            UpdateChartData.UpdateSecondSeries(this.StockIndexLineChart, this.ChooseStockIndex1, this.ChooseStockIndex2, this.ChooseStartDate, this.ChooseEndDate);
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
