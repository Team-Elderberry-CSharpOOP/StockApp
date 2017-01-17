using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockWatchApplication.Visualization.VisualizeComboBox
{
    public static class VisualizeComboBox
    {
        internal static string GetComboBoxKey(ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                return "";
            }
            return ((KeyValuePair<string, string>)comboBox.SelectedItem).Key;
        }

        internal static string GetComboBoxValue(ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                return "";
            }
            return ((KeyValuePair<string, string>)comboBox.SelectedItem).Value;
        }
        
        public static void InitializeComboBoxes(ComboBox c1, ComboBox c2)
        {
            c1.SelectedItem = c1.Items.OfType<KeyValuePair<string, string>>()
                                            .ToList().Select(x => x.Key == "S&&P 500").First();

            c2.SelectedItem = c2.Items.OfType<KeyValuePair<string, string>>()
                                             .ToList().Select(x => x.Key == "").First();
            c2.SelectedIndex = c2.FindStringExact("");
        }
    }
}
