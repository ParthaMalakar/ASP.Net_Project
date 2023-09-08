using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmployeeAttendenceDTO
    {
        public string employeeId { get; set; }
        public DateTime attendanceDate { get; set; }
        public int isPresent { get; set; }
        public int isAbsent { get; set; }
        public int isOffday { get; set; }
    }
}
