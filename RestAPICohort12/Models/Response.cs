namespace RestAPICohort12.Models
{
    public class Response
    {
        /*
         * This class designed to give a structure to the response message
         * of the server
         */

        public int status_code { get; set; }
        public string status_message { get; set;}
        public Student student { get; set; } // this is to capture one 
                                             // student every time
        public List<Student> students { get; set;} // this is to capture
                                            // more than one student from the
                                            // remote server
    }
}
