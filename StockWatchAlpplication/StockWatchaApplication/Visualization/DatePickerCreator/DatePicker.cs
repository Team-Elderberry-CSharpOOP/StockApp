using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatchApplication;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace StockWatchApplication.Visualization.DatePickerCreator
{
    public static class CreateDatePicker
    {
        internal static DateTime GetDate(DateTimePicker datePicker)
        {
            return datePicker.Value;
        }

        private static void InitializeDatePickers(MetroDateTime startDate, MetroDateTime endDate)
        {
            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now.AddMonths(-6);
        }
    }
}
