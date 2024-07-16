using EmployeeListing.DataAccess;
using EmployeeListing.Model.Employee;
using EmployeeListing.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeListing.Service.Repository
{
    public class EmpService : IEmpService
    {
        private readonly DataContext _context;
        private readonly DatafromId _datafromId;
        private readonly NICVerification _nICVerification;

        private readonly ILogger<IEmpService> _logger;

        public int totCount { get; set; } = 0;


        public EmpService(DataContext context, DatafromId datafromId, NICVerification nICVerification, ILogger<IEmpService> logger)
        {
            _context = context;
            _logger = logger;
            _datafromId = datafromId;
            _nICVerification = nICVerification;

        }

        public async Task<IEnumerable<EmpDTO>> GetAllEmployees(int page, int pageSize)
        {
            

            var Emp = await _context.TBL_Employees
                .OrderBy(e => e.AutoId).ToListAsync();



            if (Emp == null)
            {
                throw new Exception(" No Employee items found");
            }
            this.totCount= Emp.Count;
            var totalPages = (int)Math.Ceiling((decimal)totCount/ pageSize);
            var pruductsPerPage = Emp.
                Skip((page -1) * pageSize)
                .Take(pageSize).ToList();
            return pruductsPerPage;

        }


        public async Task AddEnmployee(EmployeeDTO employee)
        {
            try
            { 

                var newRcord = new EmpDTO
                {
                    EmpId = employee.EmpId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    NIC = employee.NIC,
                    DOB = DateOnly.Parse(employee.DOB),
                    Gender = employee.Gender
                };


                _context.TBL_Employees.Add(newRcord);
                await _context.SaveChangesAsync();

                //_context.TBL_Employees.Add(employee);
                //await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Listing.");
             
            }
        }


        public async Task<string> AddEnmployeewNIC(EmpNICDTO employee)
        {
            if (employee.NIC == null)
            {
                throw new ArgumentException("No NIC enterd");
            }
            
               // bool validnic =  await _nICVerification.validNic(employee.NIC);

             
                    char gender = _datafromId.genderType(employee.NIC);
                    DateOnly bday = _datafromId.DOB(employee.NIC);


                    EmpDTO newRcord = new EmpDTO();

                    newRcord.EmpId = employee.EmpId;
                    newRcord.FirstName = employee.FirstName;
                    newRcord.LastName = employee.LastName;
                    newRcord.NIC = employee.NIC;
                    newRcord.DOB = bday;
                    newRcord.Gender = gender;
                    


                    _context.TBL_Employees.Add(newRcord);
                    await _context.SaveChangesAsync();
                    return "Listing Successful";
             


            
        }



        public async Task<List<EmpIdFnDTO>> GetEpmIdFnames()
        {
             
                var employeesf =await _context.TBL_Employees
                    .Select(e => new EmpIdFnDTO
                    {
                        EmpId = e.EmpId,
                        FirstName = e.FirstName

                    })
                    .ToListAsync();

                return employeesf;
            
        }

        public async Task<List<EmployeeDTO>> GetbyId(int id)
        {
            
            var employee = await _context.TBL_Employees
                                 .Where(e => e.EmpId == id)
                                 .Select(e => new EmployeeDTO
                                 {          
                                     AutoId= e.AutoId,
                                     EmpId = e.EmpId,
                                     FirstName = e.FirstName,
                                     LastName = e.LastName,
                                     Gender = e.Gender,
                                     DOB = dateonlytoString(e.DOB),
                                     NIC = e.NIC,
                                     

                                 })
                                .ToListAsync();
            return employee;

     

        }


        private static string dateonlytoString(DateOnly date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            DateOnly dateonly = new DateOnly(year,month,day);
            string daystring = date.ToString("yyyy-MM-dd");

            return daystring;

        }



        public async Task<EmployeeDTO> Updatedata(EmployeeDTO employee)
        {

            var updateemployee = await _context.TBL_Employees
                                            .Where(u => u.EmpId == employee.EmpId)
                                            .ToListAsync();
            if (updateemployee.Count != 0)
            {
                foreach (EmpDTO u in updateemployee)
                {
                    u.NIC = employee.NIC;
                    u.FirstName = employee.FirstName;
                    u.LastName = employee.LastName;
                    u.Gender = employee.Gender;
                    u.DOB = DateOnly.Parse(employee.DOB);


                }

                _context.SaveChanges();
                return employee;
            }

           throw new Exception( "There do not exist an employee as mentioned");



        }

        public async Task<EmpDTO> DeleteEmpl(int id)
        {
           EmpDTO delEmp = await _context.TBL_Employees
                            .Where(d => d.EmpId == id)
                            .SingleOrDefaultAsync();
            if (delEmp != null) {

              
                 _context.TBL_Employees.Remove(delEmp);
                _context.SaveChanges();

                return delEmp;
            }

            throw new Exception("Non-Existing EmployeeId");
          


        }

        public async Task<bool> empExists(int empId)
        {
            var search = await _context.TBL_Employees
                .Where(s => s.EmpId == empId)
                .Select(e => new EmployeeDTO
                {
                    EmpId = e.EmpId,
                } ) .ToListAsync();
            if (search.Count != 0)
            {
                return true;
            }
            return false;

        }





        //var result = from s in stringList
        //             where s.Contains("Tutorials")
        //             select s;

        //var teenAgerStudents = studentList.Where(s => s.Age > 12 && s.Age < 20)
        //                      .ToList<Student>();



    }
}
