using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ScheduleData
    {
        private SqlDbData sqlDbData;
        public ScheduleData()
        {
            sqlDbData = new SqlDbData();
        }

        public List<Schedule> GetSchedules()
        {
            return sqlDbData.GetSchedules();
        }
    }
}
