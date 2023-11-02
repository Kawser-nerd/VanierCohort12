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

        public Response GetStudentByID(SqlConnection con, int id)
        {
            Response response = new Response();
            // generate the Query
            string Query = "Select * from student where std_Id= '" + id + "'";
            // Generate the Adapter, pass the query and execute
            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Student student = new Student();
                student.std_id = (int)dt.Rows[0]["std_id"];
                student.std_name = (string)dt.Rows[0]["std_name"];
                student.std_email = (string)dt.Rows[0]["std_email"];
                student.std_reg_year = (int)dt.Rows[0]["std_reg_year"];

                response.status_code = 200;
                response.status_message = "Student found and listed";
                response.student = student;
                response.students = null;
            }
            else
            {
                response.status_code = 100;
                response.status_message = "Nothing is reported or found";
                response.student = null;
                response.students = null;
            }
            return response;
        }

        public Response AddStudent(SqlConnection con, Student student) {
        
            Response response = new Response();
            // Query Generation
            string Query = "insert into student values(@id, @name, @email, @year)";
            // Sql Command
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@id", student.std_id);
            command.Parameters.AddWithValue("@name", student.std_name);
            command.Parameters.AddWithValue("@email", student.std_email);
            command.Parameters.AddWithValue("@year", student.std_reg_year);
            con.Open();

            // Execute our query
            int i = command.ExecuteNonQuery(); // return 0 when unsuccessful, return 1
            // when successful

            if (i > 0)
            {
                response.status_code= 200;
                response.status_message = "The student is inserted properly";
                response.student = student;
                response.students = null;
            }
            else
            {
                response.status_code = 100;
                response.status_message = "The insertion was unsuccessful";
                response.student = null;
                response.students = null;
            }
            return response;
        }

        public Response UpdateStudent(SqlConnection con, Student student, int id)
        {
            Response response = new Response();

            // Generate the Query
            string Query = "Update student set std_name=@name, std_email=@email" +
                ", std_reg_year=@year where std_Id='"+ id +"'";

            // Execute the Command
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@name", student.std_name);
            cmd.Parameters.AddWithValue("@email", student.std_email);
            cmd.Parameters.AddWithValue("@year", student.std_reg_year);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.status_code= 200;
                response.status_message = "Updated Successfully";
                response.student = student;
                
            }
            else
            {
                response.status_code = 100;
                response.status_message = "Couldn't update successfully";
                response.student = null;
            }
            con.Close();
            return response;

        }

        public Response DeleteStudent(SqlConnection con, int id)
        {
            Response response = new Response();
            //Query
            string Query = "Delete from student where std_Id='" + id + "'";
            // Generate SQL command
            SqlCommand cmd = new SqlCommand(Query, con);
            
            con.Open();
            // execute
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.status_code= 200;
                response.status_message = "Student deleted.. check all students";
            }
            else
            {
                response.status_code = 100;
                response.status_message = "Nothing deleted .....";
            }
            con.Close( );
            return response;       
        }
    }
}
