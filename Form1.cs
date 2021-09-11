using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analysis_of_tabular_data
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initialization.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The process of opening a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] buffer = new byte[2048];
                openFileDialog1.Filter = "csv files (*.csv)|*.csv";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                // We use the DataTable and the read method.
                DataTable csvData = ReadDataClass.ReadData(filename);
                TableForm tableForm = new TableForm(csvData);
                tableForm.MdiParent = this;
                tableForm.WindowState = FormWindowState.Maximized;
                tableForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Graph creation event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void makeChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm table = this.ActiveMdiChild as TableForm;
            if (table == null)
            {
                return;
            }
            else
            {
                HistogramForm histogramForm = new HistogramForm(table.Data);
                histogramForm.Show();
            }
        }
        /// <summary>
        /// Event for creating a comparison graph.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm table = this.ActiveMdiChild as TableForm;
            if (table == null)
            {
                return;
            }
            ChartForm chartForm = new ChartForm(table.Data);
            chartForm.Show();

        }
        /// <summary>
        /// Create more complex graphics from additional functionality.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm table = this.ActiveMdiChild as TableForm;
            if (table == null)
            {
                return;
            }
            MultiChartForm multiChartForm = new MultiChartForm(table.GetSelectedRows());
            multiChartForm.Show();
        }
    }
}

