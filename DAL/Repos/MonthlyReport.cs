using DAL.EF;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class MonthlyReport : Imonth<MonthlyAttendanceReport, string, MonthlyAttendanceReport>
    {
        EmployeeAttendenceEntities db;
        internal MonthlyReport()
        {
            db = new EmployeeAttendenceEntities();
        }
        public List<MonthlyAttendanceReport> GetAllEmp()
        {
            var query = from e in db.tblEmployees
                        join a in db.tblEmployeeAttendances
                        on e.employeeId equals a.employeeId
                        select new Model.MonthlyAttendanceReport
                        {
                            EmployeeName = e.employeeName,
                            MonthName = a.attendanceDate.ToString("MMMM yyyy"), // Format the date as Month Name Year
                            PayableSalary = e.employeeSalary,
                            TotalPresent = a.isPresent == 1 ? a.isPresent + 1 : a.isPresent,
                            TotalAbsent = a.isAbsent == 1 ? a.isPresent + 1 : a.isAbsent,
                            TotalOffday = a.isOffday == 1 ? a.isOffday + 1 : 0
                        };

            var report = query.ToList();
            return report;
        }
    }
}
