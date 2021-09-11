using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analysis_of_tabular_data
{
    public partial class ChartForm : Form
    {
        /// <summary>
        /// Initializing components.
        /// </summary>
        /// <param name="data"></param>
        public ChartForm(DataTable data)
        {
            InitializeComponent();
            // Using DataSourse.
            chart.DataSource = data;
            chart.Series[0].Name = "График";
            int count = data.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                if (GetData().Columns[i].DataType == typeof(int) || GetData().Columns[i].DataType == typeof(double))
                {
                    comboBox1.Items.Add(GetData().Columns[i].ColumnName);
                    comboBox2.Items.Add(GetData().Columns[i].ColumnName);
                }
            }
        }
        /// <summary>
        /// Methodfor getting data.
        /// </summary>
        /// <returns></returns>
        public DataTable GetData() { return chart.DataSource as DataTable; }
        private void ChartForm_Load(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        /// <summary>
        /// Plotting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createButton_Click(object sender, EventArgs e)
        {
            // If not all columns are selected.
            if (comboBox1.SelectedItem==null||comboBox2.SelectedItem==null)
            {
                MessageBox.Show("Не все столбцы выбраны для построения!");
                return;
            }
            chart.Series[0].Name = "График";
            chart.Series[0].XValueMember = comboBox1.Text;
            chart.Series[0].YValueMembers = comboBox2.Text;
            chart.DataBind();
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
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
            // Save it to the clipboard.
            Clipboard.SetImage(image);
        }
    }
}
