using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analysis_of_tabular_data
{
    public class Prop
    {
        /// <summary>
        /// Setting the values for the propertygrid.
        /// </summary>
        [DisplayName("Среднее значение")]
        public double Average
        {
            get;
            set;

        }
        = 0;
        [DisplayName("Медиана")]
        public double Median
        {
            get;
            set;
        }
        = 0;
        [DisplayName("Среднеквадратичное отклонение")]
        public double Deviation
        {
            get;
            set;
        }
        = 0;
        [DisplayName("Дисперсия")]
        public double Dispersion
        {
            get;
            set;
        }
        = 0;
    }
}
