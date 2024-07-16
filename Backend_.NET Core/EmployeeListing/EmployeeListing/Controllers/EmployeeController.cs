using EmployeeListing.Model.Employee;
using EmployeeListing.Service;
using EmployeeListing.Service.DTO;
using EmployeeListing.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpService _empServices;
        private readonly NICVerification _NICvalidationService;

        public EmployeeController(IEmpService empServices, NICVerification nICverification)
        {
            _empServices = empServices;
            _NICvalidationService = nICverification;
        }



        [HttpPost("AddEmployee"), Authorize]
        public async Task<IActionResult> AddEmployee(EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isExist = await _empServices.empExists(employee.EmpId);

            if (isExist) {
                var existEmp = await _empServices.GetbyId(employee.EmpId);

                return NotFound(new { message = "There exist an employee as mentioned", data = existEmp });
            }
            {

                try
                {

                    await _empServices.AddEnmployee(employee);
                    return Ok(new { message = "Listing successfully created" });

                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = "An error occurred while creating the Listing", error = ex.Message });

                }
            }
        }


        [HttpGet("NICValidation{NICnumber}"), Authorize]
        public  async Task<IActionResult> NICValidation(string NICnumber)
        {
            bool isValid = await _NICvalidationService.validNic(NICnumber);
            if (isValid)
            {
                return Ok(new { message = "Valid NIC" });
            }
            else { return BadRequest(new {message ="Invalid NIC"}); }
        }

        [HttpGet("EmpIsExist{employeeId}")]
        public async Task<IActionResult> isExist(int employeeId)
        {
            bool isEmpExist = await _empServices.empExists(employeeId);
            if (isEmpExist)
            {
                return BadRequest(new { message = "Employee Exists"});
            }
            else
            {
                return Ok(new { message = "New Employee"});
            }

        }

      
        [HttpPost("AddEmployeeWithNIC"), Authorize]
        public async Task<IActionResult> AddEmployeeWithNIC(EmpNICDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

                try
                {

                   
                    var existEmp = await _empServices.GetbyId(employee.EmpId);
                bool validnic = await _NICvalidationService.validNic(employee.NIC);

                if (existEmp.Count != 0 )
                    {
                    

                        return BadRequest( new { message = "There exist an employee as mentioned", data = existEmp });
                    }
                else if (!validnic)
                {
                    return BadRequest( new { message ="Invalid NIC" });
                }
                    else
                    {

                      await _empServices.AddEnmployeewNIC(employee);
                        return Ok(new { message = "Listing successfully created", data = employee });
                    
                    };

                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = "An error occurred while creating the Listing", error = ex.Message });

                }
            
        }


        [HttpPost("UpdateEntry")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _empServices.Updatedata(employee);
                return Ok(new { message = "Listing successfully updated" });

            }
            catch (Exception ex) {
                return StatusCode(500, new { message = "An error occurred while Updating Listing", error = ex.Message });

            }

        }


        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees(int page = 1, int pageSize = 10)
        {
            try
            {
                var employee = await _empServices.GetAllEmployees(page, pageSize);
                if (employee == null || !employee.Any())
                {
                    return Ok(new { message = "No Employee Listing found" });
                }

                int totalCount = _empServices.totCount;



                return Ok(new { message = "Successfully retrieved "+ pageSize+" listings "+ "from "+ page+"th page"  , data = employee, count = totalCount});

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all Listings", error = ex.Message });


            }
        }

      
        [HttpGet("GetIdFname"), Authorize]
        public async Task<IActionResult> GetIdFname()
        {
            try
            {
                var employee = await _empServices.GetEpmIdFnames();
                if (employee == null || !employee.Any())
                {
                    return Ok(new { message = "No Employee Listing found" });
                }
                return Ok(new { message = "Successfully retrieved all blog posts", data = employee });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all Listings", error = ex.Message });


            }

        }

       
        [HttpGet("GetbyId{i}")]
        public async Task<IActionResult> GetbyId(int i)
        {
            try
            {
                var employee = await _empServices.GetbyId(i);

                if (employee.Count == 0)
                {
                    return BadRequest(new { message = "No Employee Listing found" });
                }
                return Ok(new { message = "Successfully retrieved Matching Listing", data = employee });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all Listings", error = ex.Message });


            }

        }


        [HttpDelete("DeleteEmployee{id}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            try {

               var delEmp =  await _empServices.DeleteEmpl(id);
                if (delEmp != null)
                {
                    return Ok(new { message = "Employee Listing Removed", data = delEmp });
                }
              
                return BadRequest(new { message ="No Employee Listing Found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error Deleting Entry.(From Controller)", error = ex.Message });

            }
        }



    }
}
