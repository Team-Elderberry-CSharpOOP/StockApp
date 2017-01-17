namespace StockWatchApplication.Visualization.ComboBoxCreator
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public static class VisualizeComboBox
    {

        public static void IfComboBoxesTheSame(ComboBox c1, ComboBox c2)
        {
            if (VisualizeComboBox.GetComboBoxKey(c1) == VisualizeComboBox.GetComboBoxKey(c2))
            {
                c2.SelectedItem = c2.Items.OfType<KeyValuePair<string, string>>().ToList().Select(x => x.Key == "").First();
                c2.SelectedIndex = c2.FindStringExact("");
            }
        }

        public static string GetComboBoxKey(ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                return "";
            }
            return ((KeyValuePair<string, string>)comboBox.SelectedItem).Key;
        }

        public static string GetComboBoxValue(ComboBox comboBox)
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
