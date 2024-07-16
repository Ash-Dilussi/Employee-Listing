
using EmployeeListing.Model.Employee;
using EmployeeListing.Service.DTO;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListing.Service.Repository
{
    public interface IEmpService
    {
        int totCount { get; set; }

        Task AddEnmployee(EmployeeDTO employee);
        Task<IEnumerable<EmpDTO>> GetAllEmployees(int page, int pageSize);
        Task<List<EmpIdFnDTO>> GetEpmIdFnames();
        Task<List<EmployeeDTO>> GetbyId(int id);
        Task<string> AddEnmployeewNIC(EmpNICDTO employee);
        Task<EmployeeDTO> Updatedata(EmployeeDTO employee);
        Task<EmpDTO> DeleteEmpl(int id);
        Task<bool> empExists(int empId);



    }
}
