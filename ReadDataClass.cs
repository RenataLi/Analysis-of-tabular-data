using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Analysis_of_tabular_data
{
    class ReadDataClass
    {
        /// <summary>
        /// We use a state machine to read the csv file.
        /// </summary>
        enum ColumnType
        {
            Int,
            OptionalInt,
            Double,
            OptionalDouble,
            String
        }
        /// <summary>
        /// Method for reading data.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static DataTable ReadData(string filename)
        {
            List<string[]> filelist = new List<string[]>();
            string[] labels;
            ColumnType[] columnTypes;
            using (StreamReader streamReader = File.OpenText(filename))
            {
                labels = SplitClass.Split(streamReader.ReadLine());
                columnTypes = new ColumnType[labels.Length];
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    // Getting splitiing string.
                    string[] splitstr = SplitClass.Split(str);
                    if (splitstr.Length != labels.Length)
                    {
                        throw new DataException("Некорректный файл!");
                    }
                    for (int i = 0; i < splitstr.Length; i++)
                    {
                        if (string.IsNullOrEmpty(splitstr[i]))
                        {
                            if (columnTypes[i] == ColumnType.Int)
                                columnTypes[i] = ColumnType.OptionalInt;
                            if (columnTypes[i] == ColumnType.Double)
                                columnTypes[i] = ColumnType.OptionalDouble;
                        }
                        else if(!int.TryParse(splitstr[i],out int k))
                        {
                            if(double.TryParse(splitstr[i],NumberStyles.Any,CultureInfo.InvariantCulture,out double n))
                            {
                                if (columnTypes[i] == ColumnType.Int)
                                    columnTypes[i] = ColumnType.Double;
                                if (columnTypes[i] == ColumnType.OptionalInt)
                                    columnTypes[i] = ColumnType.OptionalDouble;
                            }
                            else
                            {
                                columnTypes[i] = ColumnType.String;
                            }
                        }
                    }
                    filelist.Add(splitstr);
                }
            }
            DataTable table = new DataTable();
            for (int i = 0; i < labels.Length; i++)
            {
                // Getting rype of cell.
                switch (columnTypes[i])
                {
                    case ColumnType.Int:
                        table.Columns.Add(labels[i], typeof(int)).AllowDBNull = false;
                        break;
                    case ColumnType.OptionalInt:
                        table.Columns.Add(labels[i], typeof(int));
                        break;
                    case ColumnType.Double:
                        table.Columns.Add(labels[i], typeof(double)).AllowDBNull = false;
                        break;
                    case ColumnType.OptionalDouble:
                        table.Columns.Add(labels[i], typeof(double));
                        break;
                    case ColumnType.String:
                        table.Columns.Add(labels[i], typeof(string)).AllowDBNull = false;
                        break;
                    default:
                        break;
                }
            }
            // Loading data.
            table.BeginLoadData();
            foreach (var item in filelist)
            {
                object[] objects = new object[item.Length];
                for (int i = 0; i < item.Length; i++)
                {
                    switch (columnTypes[i])
                    {
                        case ColumnType.Int:
                            objects[i] = int.Parse(item[i]);
                            break;
                        case ColumnType.OptionalInt:
                            objects[i] = string.IsNullOrEmpty(item[i])?Convert.DBNull:int.Parse(item[i]);
                            break;
                        case ColumnType.Double:
                            objects[i] = double.Parse(item[i],CultureInfo.InvariantCulture);
                            break;
                        case ColumnType.OptionalDouble:
                            objects[i] = string.IsNullOrEmpty(item[i]) ? Convert.DBNull : double.Parse(item[i], CultureInfo.InvariantCulture);
                            break;
                        case ColumnType.String:
                            objects[i] = item[i];
                            break;
                        default:
                            break;
                    }
                }
                table.Rows.Add(objects);
            }
            // End of loading data.
            table.EndLoadData();
            return table;
        }
    }
}
