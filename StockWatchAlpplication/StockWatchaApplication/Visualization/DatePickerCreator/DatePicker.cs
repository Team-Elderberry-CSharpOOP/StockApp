using MetroFramework.Controls;
using StockWatchApplication.Visualization.Chart;
using System;
using System.Windows.Forms;

namespace StockWatchApplication.Visualization.DatePickerCreator
{
    public static class CreateDatePicker
    {

        public static DateTime GetDate(DateTimePicker datePicker)
        {
            return datePicker.Value;
        }

        public static void InitializeDatePickers(MetroDateTime startDate, MetroDateTime endDate)
        {
            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now.AddMonths(-6);
        }

        public static void DateChanged(LiveCharts.WinForms.CartesianChart input, ComboBox c1, ComboBox c2, MetroDateTime startDate, MetroDateTime endDate)
        {
            //Validate
            if (GetDate(endDate) < GetDate(startDate))
            {
                MessageBox.Show("The end date cannot be before the startDate", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GetDate(endDate).Subtract(GetDate(startDate)).TotalDays > 365 * 2)
            {
                DialogResult result = MessageBox.Show("Please note that if you select a range longer than 2 years, the perfomance will degrate. Do you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            UpdateChartData.UpdateFirstSeries(input, c1, c2, startDate, endDate);
            UpdateChartData.UpdateSecondSeries(input, c1, c2, startDate, endDate);
        }
    }
}
