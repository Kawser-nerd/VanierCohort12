namespace RestAPICohort12.Models
{
    public class Student
    {/**
      * This class is designed based on the table structure the database is
      * possing right now
      */
        public int std_id { get; set; }
        public string std_name { get; set; }
        public string std_email { get; set; }
        public int std_reg_year { get; set; }
    }
}
