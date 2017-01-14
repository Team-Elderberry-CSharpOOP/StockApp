﻿namespace StockWatchApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FormStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabController = new MetroFramework.Controls.MetroTabControl();
            this.MerketOverviewTab = new MetroFramework.Controls.MetroTabPage();
            this.ChooseStockIndex2 = new MetroFramework.Controls.MetroComboBox();
            this.ChooseStockIndex1 = new MetroFramework.Controls.MetroComboBox();
            this.ChooseEndDate = new MetroFramework.Controls.MetroDateTime();
            this.ChooseStartDate = new MetroFramework.Controls.MetroDateTime();
            this.EndDateLabel = new MetroFramework.Controls.MetroLabel();
            this.StartDateLabel = new MetroFramework.Controls.MetroLabel();
            this.StockIndex2Label = new MetroFramework.Controls.MetroLabel();
            this.StockIndexLineChart = new LiveCharts.WinForms.CartesianChart();
            this.StockIndex1Label = new MetroFramework.Controls.MetroLabel();
            this.StockWatch = new MetroFramework.Controls.MetroTabPage();
            this.UserPictureBox = new System.Windows.Forms.PictureBox();
            this.UsernameLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.FormStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TabController.SuspendLayout();
            this.MerketOverviewTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormStyleManager
            // 
            this.FormStyleManager.Owner = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TabController
            // 
            this.TabController.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabController.Controls.Add(this.MerketOverviewTab);
            this.TabController.Controls.Add(this.StockWatch);
            this.TabController.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TabController.FontSize = MetroFramework.MetroTabControlSize.Small;
            this.TabController.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.TabController.ItemSize = new System.Drawing.Size(300, 34);
            this.TabController.Location = new System.Drawing.Point(28, 63);
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 1;
            this.TabController.Size = new System.Drawing.Size(801, 489);
            this.TabController.TabIndex = 1;
            this.TabController.TabStop = false;
            this.TabController.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabController.UseSelectable = true;
            // 
            // MerketOverviewTab
            // 
            this.MerketOverviewTab.Controls.Add(this.ChooseStockIndex2);
            this.MerketOverviewTab.Controls.Add(this.ChooseStockIndex1);
            this.MerketOverviewTab.Controls.Add(this.ChooseEndDate);
            this.MerketOverviewTab.Controls.Add(this.ChooseStartDate);
            this.MerketOverviewTab.Controls.Add(this.EndDateLabel);
            this.MerketOverviewTab.Controls.Add(this.StartDateLabel);
            this.MerketOverviewTab.Controls.Add(this.StockIndex2Label);
            this.MerketOverviewTab.Controls.Add(this.StockIndexLineChart);
            this.MerketOverviewTab.Controls.Add(this.StockIndex1Label);
            this.MerketOverviewTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MerketOverviewTab.HorizontalScrollbarBarColor = false;
            this.MerketOverviewTab.HorizontalScrollbarHighlightOnWheel = false;
            this.MerketOverviewTab.HorizontalScrollbarSize = 10;
            this.MerketOverviewTab.Location = new System.Drawing.Point(4, 38);
            this.MerketOverviewTab.Margin = new System.Windows.Forms.Padding(0);
            this.MerketOverviewTab.Name = "MerketOverviewTab";
            this.MerketOverviewTab.Size = new System.Drawing.Size(793, 447);
            this.MerketOverviewTab.TabIndex = 0;
            this.MerketOverviewTab.Text = "Market Overview";
            this.MerketOverviewTab.VerticalScrollbarBarColor = false;
            this.MerketOverviewTab.VerticalScrollbarHighlightOnWheel = false;
            this.MerketOverviewTab.VerticalScrollbarSize = 10;
            // 
            // ChooseStockIndex2
            // 
            this.ChooseStockIndex2.FormattingEnabled = true;
            this.ChooseStockIndex2.ItemHeight = 24;
            this.ChooseStockIndex2.Location = new System.Drawing.Point(138, 52);
            this.ChooseStockIndex2.Name = "ChooseStockIndex2";
            this.ChooseStockIndex2.Size = new System.Drawing.Size(128, 30);
            this.ChooseStockIndex2.TabIndex = 12;
            this.ChooseStockIndex2.UseSelectable = true;
            this.ChooseStockIndex2.SelectedIndexChanged += new System.EventHandler(this.ChooseStockIndex2_SelectedIndexChanged);
            // 
            // ChooseStockIndex1
            // 
            this.ChooseStockIndex1.FormattingEnabled = true;
            this.ChooseStockIndex1.ItemHeight = 24;
            this.ChooseStockIndex1.Location = new System.Drawing.Point(138, 12);
            this.ChooseStockIndex1.Name = "ChooseStockIndex1";
            this.ChooseStockIndex1.Size = new System.Drawing.Size(128, 30);
            this.ChooseStockIndex1.TabIndex = 11;
            this.ChooseStockIndex1.UseSelectable = true;
            this.ChooseStockIndex1.SelectedIndexChanged += new System.EventHandler(this.ChooseStockIndex1_SelectedIndexChanged);
            // 
            // ChooseEndDate
            // 
            this.ChooseEndDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.ChooseEndDate.Location = new System.Drawing.Point(607, 52);
            this.ChooseEndDate.MinimumSize = new System.Drawing.Size(0, 27);
            this.ChooseEndDate.Name = "ChooseEndDate";
            this.ChooseEndDate.Size = new System.Drawing.Size(186, 36);
            this.ChooseEndDate.TabIndex = 8;
            this.ChooseEndDate.ValueChanged += new System.EventHandler(this.ChooseEndDate_ValueChanged);
            // 
            // ChooseStartDate
            // 
            this.ChooseStartDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.ChooseStartDate.Location = new System.Drawing.Point(607, 12);
            this.ChooseStartDate.MinimumSize = new System.Drawing.Size(0, 27);
            this.ChooseStartDate.Name = "ChooseStartDate";
            this.ChooseStartDate.Size = new System.Drawing.Size(186, 36);
            this.ChooseStartDate.TabIndex = 6;
            this.ChooseStartDate.ValueChanged += new System.EventHandler(this.ChooseStartDate_ValueChanged);
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.EndDateLabel.Location = new System.Drawing.Point(521, 56);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(73, 20);
            this.EndDateLabel.TabIndex = 7;
            this.EndDateLabel.Text = "End Date:";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.StartDateLabel.Location = new System.Drawing.Point(515, 16);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(79, 20);
            this.StartDateLabel.TabIndex = 5;
            this.StartDateLabel.Text = "Start Date:";
            // 
            // StockIndex2Label
            // 
            this.StockIndex2Label.CausesValidation = false;
            this.StockIndex2Label.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.StockIndex2Label.Location = new System.Drawing.Point(4, 56);
            this.StockIndex2Label.Name = "StockIndex2Label";
            this.StockIndex2Label.Size = new System.Drawing.Size(154, 20);
            this.StockIndex2Label.TabIndex = 10;
            this.StockIndex2Label.Text = "Stock Index 2: ";
            // 
            // StockIndexLineChart
            // 
            this.StockIndexLineChart.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.StockIndexLineChart.BackColorTransparent = true;
            this.StockIndexLineChart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StockIndexLineChart.Location = new System.Drawing.Point(7, 88);
            this.StockIndexLineChart.Name = "StockIndexLineChart";
            this.StockIndexLineChart.Size = new System.Drawing.Size(831, 354);
            this.StockIndexLineChart.TabIndex = 4;
            this.StockIndexLineChart.Text = "StockIndex";
            // 
            // StockIndex1Label
            // 
            this.StockIndex1Label.CausesValidation = false;
            this.StockIndex1Label.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.StockIndex1Label.Location = new System.Drawing.Point(4, 16);
            this.StockIndex1Label.Name = "StockIndex1Label";
            this.StockIndex1Label.Size = new System.Drawing.Size(154, 26);
            this.StockIndex1Label.TabIndex = 2;
            this.StockIndex1Label.Text = "Stock Index 1: ";
            // 
            // StockWatch
            // 
            this.StockWatch.HorizontalScrollbarBarColor = true;
            this.StockWatch.HorizontalScrollbarHighlightOnWheel = false;
            this.StockWatch.HorizontalScrollbarSize = 10;
            this.StockWatch.Location = new System.Drawing.Point(4, 38);
            this.StockWatch.Name = "StockWatch";
            this.StockWatch.Size = new System.Drawing.Size(793, 447);
            this.StockWatch.TabIndex = 1;
            this.StockWatch.Text = "  Stock Watch";
            this.StockWatch.VerticalScrollbarBarColor = true;
            this.StockWatch.VerticalScrollbarHighlightOnWheel = false;
            this.StockWatch.VerticalScrollbarSize = 10;
            // 
            // UserPictureBox
            // 
            this.UserPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("UserPictureBox.Image")));
            this.UserPictureBox.Location = new System.Drawing.Point(632, 21);
            this.UserPictureBox.Name = "UserPictureBox";
            this.UserPictureBox.Size = new System.Drawing.Size(40, 36);
            this.UserPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserPictureBox.TabIndex = 2;
            this.UserPictureBox.TabStop = false;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.UsernameLabel.Location = new System.Drawing.Point(667, 27);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(92, 25);
            this.UsernameLabel.TabIndex = 3;
            this.UsernameLabel.Text = "Username";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(853, 553);
            this.Controls.Add(this.UserPictureBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TabController);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "        Stock Watch";
            ((System.ComponentModel.ISupportInitialize)(this.FormStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TabController.ResumeLayout(false);
            this.MerketOverviewTab.ResumeLayout(false);
            this.MerketOverviewTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroStyleManager FormStyleManager;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTabPage MerketOverviewTab;
        private MetroFramework.Controls.MetroLabel StockIndex1Label;
        private MetroFramework.Controls.MetroTabPage StockWatch;
        private MetroFramework.Controls.MetroLabel StartDateLabel;
        private MetroFramework.Controls.MetroDateTime ChooseStartDate;
        private MetroFramework.Controls.MetroDateTime ChooseEndDate;
        private MetroFramework.Controls.MetroLabel EndDateLabel;
        private LiveCharts.WinForms.CartesianChart StockIndexLineChart;
        private MetroFramework.Controls.MetroLabel StockIndex2Label;
        private MetroFramework.Controls.MetroComboBox ChooseStockIndex2;
        private MetroFramework.Controls.MetroComboBox ChooseStockIndex1;
        private System.Windows.Forms.PictureBox UserPictureBox;
        private MetroFramework.Controls.MetroLabel UsernameLabel;
        private MetroFramework.Controls.MetroTabControl TabController;
    }
}

