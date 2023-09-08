using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmpRepo<CLASS, ID ,RET>
    {
        RET Update(CLASS obj);
        CLASS Get3rdHighSelary();
        List<CLASS> GetAllEmp();
        List<CLASS> GetMontlySalaryEmp();

        string GetSupervisor(ID id);


    }
}
