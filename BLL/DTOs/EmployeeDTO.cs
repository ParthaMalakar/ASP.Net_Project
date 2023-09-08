using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public partial class EmployeeDTO
    {
            public string employeeId { get; set; }
            public string employeeName { get; set; }
            public string employeeCode { get; set; }
            public int employeeSalary { get; set; }
            public string supervisorId { get; set; }
        
    }
}
