
namespace Analysis_of_tabular_data
{
    partial class HistogramForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button = new System.Windows.Forms.Button();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.countOfElements = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.occurenceClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countOfElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.occurenceClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.DataSource = this.occurenceClassBindingSource;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 100);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Label = "#VALX";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueMember = "Value";
            series1.YValueMembers = "Count";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(621, 311);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            this.chart.DoubleClick += new System.EventHandler(this.chart_DoubleClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(14, 39);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 3;
            this.button.Text = "Построить";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(392, 100);
            this.propertyGrid.TabIndex = 4;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.propertyGrid);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 100);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Controls.Add(this.countOfElements);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(392, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 100);
            this.panel2.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(150, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(76, 35);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить график";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // countOfElements
            // 
            this.countOfElements.Location = new System.Drawing.Point(106, 74);
            this.countOfElements.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countOfElements.Name = "countOfElements";
            this.countOfElements.Size = new System.Drawing.Size(120, 20);
            this.countOfElements.TabIndex = 4;
            this.countOfElements.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // occurenceClassBindingSource
            // 
            this.occurenceClassBindingSource.DataSource = typeof(Analysis_of_tabular_data.OccurenceClass);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ширина колонки";
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 411);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.panel1);
            this.Name = "HistogramForm";
            this.Text = "HistogramForm";
            this.Load += new System.EventHandler(this.HistogramForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countOfElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.occurenceClassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.BindingSource occurenceClassBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown countOfElements;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
    }
}