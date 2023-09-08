using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Model;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CollectDataService
    {
        public static void UPDATE(EmployeeDTO item)
        {
            
            tblEmployee AD = new tblEmployee()
            {

                employeeId = item.employeeId,
                employeeName = item.employeeName,
                employeeCode = item.employeeCode,
                employeeSalary = item.employeeSalary,
                supervisorId = item.supervisorId,
            };
            EmployeeRepo.Update(AD);
        }
        public static EmployeeDTO GETSAL()
        {
            var sal = EmployeeRepo.Get3rdHighSelary();
            EmployeeDTO AD = new EmployeeDTO()
            {

                employeeId = sal.employeeId,
                employeeName = sal.employeeName,
                employeeCode = sal.employeeCode,
                employeeSalary = sal.employeeSalary,
                supervisorId = sal.supervisorId,
            };
            return AD;
        }
        public static List<MonthlyAttendanceReportDTO> GetAllEmp()
        {
            var all = EmployeeRepo.GetAllEmp();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MonthlyAttendanceReport, MonthlyAttendanceReportDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<MonthlyAttendanceReportDTO>>(all);
            return converted;

        }

        public static List<EmployeeDTO> GetMontlySalaryEmp()
        {
            var all = EmployeeRepo.GetMontlySalaryEmp();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<tblEmployee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<EmployeeDTO>>(all);
            return converted;

        }

        public static string GetSupervisor(string id)
        {
            var all = EmployeeRepo.GetSupervisor(id);
            return all;

        }


    }
}
