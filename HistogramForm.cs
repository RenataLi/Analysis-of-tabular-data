using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Analysis_of_tabular_data
{
    public partial class HistogramForm : Form
    {
        // Using DataTable. 
        DataTable csvData;
        /// <summary>
        /// Initializing components.
        /// </summary>
        /// <param name="data"></param>
        public HistogramForm(DataTable data)
        {
            InitializeComponent();
            countOfElements.Maximum = data.Rows.Count;
            csvData = data;
            propertyGrid.SelectedObject = new Prop();
            chart.Series[0].Name = "Гистограмма";
            int count = csvData.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                if (csvData.Columns[i].DataType == typeof(int) || csvData.Columns[i].DataType == typeof(double))
                {
                    // Adding items from csv.
                    comboBox1.Items.Add(csvData.Columns[i].ColumnName);
                }
            }
        }
        // Load HistogramForm.
        private void HistogramForm_Load(object sender, EventArgs e) { }
        /// <summary>
        /// Creating Properties for numbers.
        /// </summary>
        /// <param name="index"></param>
        public void CreateProp(int index)
        {
            int length = csvData.Rows.Cast<DataRow>().Count(row => !row.IsNull(index));
            // Getting average.
            ((Prop)propertyGrid.SelectedObject).Average = csvData.Rows.Cast<DataRow>().Where(row => !row.IsNull(index)).Average(row => Convert.ToDouble(row[index]));
            double average = ((Prop)propertyGrid.SelectedObject).Average;
            ((Prop)propertyGrid.SelectedObject).Median = csvData.Rows.Cast<DataRow>().Where(row => !row.IsNull(index)).OrderBy(
                row=>Convert.ToDouble(row[index])).Select(row=>Convert.ToDouble(row[index])).Skip(csvData.Rows.Count/ 2).First();
            double sum = 0;
            // Getting derivation.
            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                if (csvData.Rows[i].IsNull(index))
                    continue;
                var derivation = Convert.ToDouble(csvData.Rows[i][index]) - average;
                sum += derivation * derivation;
            }
            // Getting dispersion.
            ((Prop)propertyGrid.SelectedObject).Dispersion = sum / (length - 1);
            ((Prop)propertyGrid.SelectedObject).Deviation = Math.Sqrt(((Prop)propertyGrid.SelectedObject).Dispersion);
            propertyGrid.Refresh();
        }
        /// <summary>
        /// The plotting event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            // If no items is selected.
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Колонка для построения не выбрана!");
                return;
            }
            int index1 = csvData.Columns[comboBox1.Text].Ordinal;
            var tmp = csvData.Rows.Cast<DataRow>().ToLookup(
                row => row[index1]).OrderBy(row=>row.Key).ToArray();
            OccurenceClass[] occurences = new OccurenceClass[(tmp.Length-1) / (int)countOfElements.Value + 1];
            for (int i = 0; i < occurences.Length; i++)
            {
                occurences[i] = new OccurenceClass();
                occurences[i].Value = tmp[i * (int)countOfElements.Value].Key;
                for (int j = 0; j < countOfElements.Value; j++)
                {
                    if (i * (int)countOfElements.Value + j >= tmp.Length)
                        break;
                    occurences[i].Count += tmp[i * (int)countOfElements.Value + j].Count();
                }

            }
            // Getting datasourse.
            chart.DataSource = occurences;
            chart.DataBind();
            CreateProp(index1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        /// <summary>
        /// The event of saving the graph.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            var image = new Bitmap(chart.Width, chart.Height);

            chart.DrawToBitmap(image, chart.DisplayRectangle);
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Сохранить изображение как ...";
                sfd.Filter = "*.png|*.png;";
                sfd.AddExtension = true;
                sfd.FileName = "graphicImage";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    chart.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
            Clipboard.SetImage(image);
        }
        /// <summary>
        /// Changing the color of the column.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart_DoubleClick(object sender, EventArgs e)
        {
            colorDialog1.Color = chart.Series[0].Color;
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                chart.Series[0].Color = colorDialog1.Color;
            }
        }
    }
}
