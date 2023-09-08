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
    public class EmployeeRepo 
    {
        
      
        public static tblEmployee Get3rdHighSelary()
        {
            var db = new EmployeeAttendenceEntities1();
            var thirdSalary = db.tblEmployees
                        .Select(e => e.employeeSalary)
                        .Distinct()
                        .OrderByDescending(s => s)
                        .Skip(2)
                        .FirstOrDefault();
            var thirdHighestSalary = (from I in db.tblEmployees where I.employeeSalary.Equals(thirdSalary) select I).FirstOrDefault();
            return thirdHighestSalary;

        }

        public static List<MonthlyAttendanceReport> GetAllEmp()
        {

            var db = new EmployeeAttendenceEntities1();
            var monthlyReport = db.tblEmployeeAttendances
                .Join(db.tblEmployees,
                    attendance => attendance.employeeId,
                    employee => employee.employeeId,
                    (attendance, employee) => new MonthlyAttendanceReport
                    {
                        EmployeeName = employee.employeeName,
                        MonthName = attendance.attendanceDate,
                        PayableSalary = employee.employeeSalary,
                        TotalPresent = attendance.isPresent == 1 ? 1 : 0,
                        TotalAbsent = attendance.isAbsent == 1 ? 1 : 0,
                        TotalOffday = attendance.isOffday == 1 ? 1 : 0
                    })
                .GroupBy(r => new { r.EmployeeName, r.MonthName, r.PayableSalary})
                .Select(g => new MonthlyAttendanceReport
                {
                    g.Key.EmployeeName,
                    g.Key.MonthName,
                    g.Key.PayableSalary,
                    TotalPresent = g.Sum(r => r.TotalPresent),
                    TotalAbsent = g.Sum(r => r.TotalAbsent),
                    TotalOffday = g.Sum(r => r.TotalOffday)
                })
                .ToList();
            return monthlyReport;

        }

        public static List<tblEmployee> GetMontlySalaryEmp()
        {
            var db = new EmployeeAttendenceEntities1();
            var employeesWithNoAbsentRecord = (
                from employee in db.tblEmployees
                where !db.tblEmployeeAttendances.Any(absent => absent.employeeId == employee.employeeId && absent.isAbsent == 1)
                orderby employee.employeeSalary descending
                select employee
            ).ToList();

            return employeesWithNoAbsentRecord;


        }

        public static bool Exits(tblEmployee obj)
        {
            var db = new EmployeeAttendenceEntities1();
            var dbobbj = db.tblEmployees.Find(obj.employeeCode);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public static bool Update(tblEmployee obj)
        {
            var db = new EmployeeAttendenceEntities1();
            var dbobbj = db.tblEmployees.Find(obj.employeeId);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

       public static string GetSupervisor(string id)
        {
            var id2 = id;
            var db = new EmployeeAttendenceEntities1();
            
            
                var dbobbj = db.tblEmployees.Find(id);
                var owname = dbobbj.employeeName;
                var dbobbj1 = db.tblEmployees.Find(dbobbj.supervisorId);
                var owname1 = dbobbj.employeeName;
                var dbobbj2 = db.tblEmployees.Find(dbobbj1.supervisorId);
                var owname2 = dbobbj.employeeName;
                var dbobbj3 = db.tblEmployees.Find(dbobbj2.supervisorId);
                var owname3 = dbobbj.employeeName;
                return owname + "-->" + owname1 + "-->" + owname2 + "-->" + owname3;
          
           
            
        }
    }
}
