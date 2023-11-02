using System.Data;
using System.Data.SqlClient;

namespace RestAPICohort12.Models
{
    public class DBApplication
    {
        public Response GetAllStudents(SqlConnection con)
        {
            // step 1: Create instance of the Response class
            Response response = new Response();

            // Step 2: Create the Query
            string Query = "Select * from student";
            
            // step 3 : Need data adapter to read the data from database
            // and a table structure to add it in the table
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // step 4: initialize the list of students variable
            List<Student> listOfStudents = new List<Student>();

            // step 5: verify the database query retrieved in dt
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Student student = new Student(); // to capture each entry 
                                                // in the table
                    student.std_id = (int) dt.Rows[i]["std_Id"];
                    student.std_name = (string)dt.Rows[i]["std_name"];
                    student.std_email = (string)dt.Rows[i]["std_email"];
                    student.std_reg_year = (int)dt.Rows[i]["std_reg_year"];

                    listOfStudents.Add(student);
                }
            }

            // step 6: verify the list of students and configure response
            if (listOfStudents.Count > 0)
            {
                response.status_code = 200;
                response.status_message = "Successfull";
                response.students = listOfStudents;
                response.student = null;
            }
            else
            {
                response.status_code = 100;
                response.status_message = "The query is not successfull.." +
                    " check it";
                response.students = null;
                response.student = null;
            }
            return response;

        }
    }
}
