using Microsoft.AspNetCore.Mvc;
using RestAPICohort12.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace RestAPICohort12.Controllers
{
    // Need to provide the controller information/ Rest API information to
    // view the base information properly

    [Route("[controller]")]
    [ApiController] // the definition of the class we are going to provide here
    public class StudentController : ControllerBase
    {
        // we are going to use the Base controller only to structure the
        // contents.. View will be handled by either wpf or web browser

        // step 1: create a connection state receiver
        private readonly IConfiguration _configuration;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // step 2: Create the API for controller, which is going to act as
        // rest API

        // step 2.1: Create GetAllStudents api
        [HttpGet] // generate get Request
        [Route("GetAllStudents")]

        public Response GetAllStudents()
        {
            // step 1: Create instance of the Response Class
            Response response = new Response();
            // step 2: WE need the database connection to be provided over
            // here

            SqlConnection con =
                new SqlConnection(_configuration.
                GetConnectionString("studentConnection"));

            // Step 3: Generate the Query and Execute
            // We want to have a separate database class which we are
            // going to create under Models folder
            DBApplication dba = new DBApplication();
            response = dba.GetAllStudents(con);

            // step 4: return the Response
            return response;
        }

    }
}
