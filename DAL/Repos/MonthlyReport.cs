using DAL.EF;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class MonthlyReport 
    {
        
        public static List<MonthlyAttendanceReport> GetAllEmp()
        {
           var db = new EmployeeAttendenceEntities();
            var monthlyReport = db.tblEmployeeAttendances
                .Join(db.tblEmployees,
                    attendance => attendance.employeeId,
                    employee => employee.employeeId,
                    (attendance, employee) => new MonthlyAttendanceReport
                    {
                        EmployeeName = employee.employeeName,
                        MonthName = attendance.attendanceDate.ToString("MMMM"),
                        PayableSalary = employee.employeeSalary,
                        TotalPresent = attendance.isPresent == 1 ? 1 : 0,
                        TotalAbsent = attendance.isAbsent ==1 ? 1 : 0,
                        TotalOffday = attendance.isOffday ==1 ? 1 : 0
                    })
                .GroupBy(r => new  { r.EmployeeName, r.MonthName ,r.PayableSalary})
                .Select(g => new MonthlyAttendanceReport
                {
                    
                    TotalPresent = g.Sum(r => r.TotalPresent),
                    TotalAbsent = g.Sum(r => r.TotalAbsent),
                    TotalOffday = g.Sum(r => r.TotalOffday)
                })
                .ToList();
            return monthlyReport;



        }
    }
}
