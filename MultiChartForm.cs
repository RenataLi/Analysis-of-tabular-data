using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Analysis_of_tabular_data
{
    public partial class MultiChartForm : Form
    {
        // Using list of labels and dataTable.
        List<string> names = new List<string>();
        DataTable dataTable;
        /// <summary>
        /// Initializing components.
        /// </summary>
        /// <param name="data"></param>
        public MultiChartForm(DataTable data)
        {
            InitializeComponent();
            chart.DataSource = data;
            for (int i = 1; i < data.Columns.Count; i++)
            {
                // Adding the int or double types.
                if (data.Columns[i].DataType == typeof(int) || data.Columns[i].DataType == typeof(double))
                {
                    names.Add(data.Columns[i].ToString());
                }
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                checkedListBox1.Items.Add(data.Rows[i][0].ToString());
            }
            dataTable = data;
        }

        private void chart1_Click(object sender, EventArgs e) { }
        /// <summary>
        /// The event of plotting a complex graph.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkedListBox1.CheckedItems.Count != 0 && dataTable.Rows.Count != 0)
                {
                    chart.Series.Clear();
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        chart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series(checkedListBox1.CheckedItems[i].ToString()));
                    }
                    for (int i = 0; i < chart.Series.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            if (int.TryParse(dataTable.Rows[i][j].ToString(), out int k))
                            {
                                chart.Series[i].Points.AddY(Convert.ToInt32(dataTable.Rows[i][j]));

                            }
                        }
                        // Adding labels.
                        for (int j = 0; j < names.Count; j++)
                        {
                            chart.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(j, j + 2, names[j], 0, LabelMarkStyle.LineSideMark));

                        }
                    }
                    chart.DataBind();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Выбранная таблица не соответсвует формату для данного графика!");

            }
        }
    }
}
