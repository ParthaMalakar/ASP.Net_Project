using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class EmployeeRepo : IEmpRepo<tblEmployee, string, tblEmployee>
    {
        EmployeeAttendenceEntities db;
        internal EmployeeRepo()
        {
            db = new EmployeeAttendenceEntities();
        }

      
        public tblEmployee Get3rdHighSelary()
        {
            var thirdSalary = db.tblEmployees
                        .Select(e => e.employeeSalary)
                        .Distinct()
                        .OrderByDescending(s => s)
                        .Skip(2)
                        .FirstOrDefault();
            var thirdHighestSalary = (from I in db.tblEmployees where I.employeeSalary.Equals(thirdSalary) select I).FirstOrDefault();
            return thirdHighestSalary;

        }

        public List<tblEmployee> GetAllEmp()
        {
           
            throw new NotImplementedException();

        }

        public List<tblEmployee> GetMontlySalaryEmp()
        {
            var employeesWithNoAbsentRecord = (
                from employee in db.tblEmployees
                where !db.tblEmployeeAttendances.Any(absent => absent.employeeId == employee.employeeId && absent.isAbsent == 1)
                orderby employee.employeeSalary descending
                select employee
            ).ToList();

            return employeesWithNoAbsentRecord;


        }

        public tblEmployee GetSupervisor(string id)
        {
            throw new NotImplementedException();
        }

        public tblEmployee Update(tblEmployee obj)
        {
            var dbobbj = db.tblEmployees.Find(obj.employeeId);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
