using Data;
using FinancialInstruments;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static MetroFramework.Drawing.MetroPaint.ForeColor;

namespace StockWatchApplication.Visualization.TilesCreator
{
    public static class CreateTiles
    {
        private static List<MetroTile> StockWatchTiles = new List<MetroTile>();
        private static List<Label> StockWatchLabels = new List<Label>();

        public static void AddTilesSecondTab(Font font, MetroTabPage secondTab)
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
                currentLabel.Font = new Font(font.FontFamily, 24, FontStyle.Bold);
                currentLabel.TextAlign = ContentAlignment.MiddleCenter;
                StockWatchLabels.Add(currentLabel);

                currentLabel.Controls.Add(stockTile);
                secondTab.Controls.Add(currentLabel);

                if (i == numberOfTilesInRow - 1)
                {
                    startPositionY += +widthHeight + spaceBetween;
                    startPositionX += -widthHeight * numberOfTilesInRow - spaceBetween * numberOfTilesInRow;
                }

                UpdateSecondTabData();
            }
        }
        

        public static void UpdateSecondTabData()
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
