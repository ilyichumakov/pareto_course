using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Course_that_works
{
    class HashPoints: System.Windows.Forms.DataVisualization.Charting.Series
    {
        public List<Hash> TimeTable;
        public double GetPH(double time)
        {
            foreach (Hash item in this.TimeTable)
            {
                if (time == item.value) return item.value;
            }
            return -9999.99;
        }
        public HashPoints(List<Hash> table) : base()
        {
            this.TimeTable = table;
        } 
    }
}
