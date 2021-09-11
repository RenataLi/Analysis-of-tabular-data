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
    public partial class TableForm : Form
    {
        // Using DataTable for data.
        public DataTable Data { get { return dataGridView.DataSource as DataTable; } }
        public DataTable GetSelectedRows()
        {
            DataTable dataTable = this.Data.Clone();
            dataTable.BeginLoadData();
            for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
            {
                var rows = dataGridView.SelectedRows[i].DataBoundItem as DataRowView;
                if (rows != null)
                {
                    dataTable.Rows.Add(rows.Row.ItemArray);

                }
            }
            dataTable.EndLoadData();
            return dataTable;
        }
        /// <summary>
        /// Initializing components.
        /// </summary>
        /// <param name="data"></param>
        public TableForm(DataTable data)
        {
            InitializeComponent();
            dataGridView.DataSource = data;
        }
        /// <summary>
        /// Table Form Loading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
