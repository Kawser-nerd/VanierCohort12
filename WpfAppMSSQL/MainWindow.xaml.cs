using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppMSSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static SqlConnection con; // It is the connection adapter
        static SqlCommand cmd; // it the query proceeding adapter
        private void connection_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=SLB-F251-NAFI;Initial Catalog=master;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            MessageBox.Show("Connection Established");
            con.Close();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //step 1: Is to open the connection
                con.Open();
                //step 2: generate the database query
                string Query = "insert into student values(@ID, @name, @email, @regYear)";
                // step 3: Create the command for Database
                cmd = new SqlCommand(Query, con);
                // step 4: Assign values to the query variables 
                cmd.Parameters.AddWithValue("@ID", int.Parse(std_id.Text));
                cmd.Parameters.AddWithValue("@name", std_name.Text);
                cmd.Parameters.AddWithValue("@email", std_email.Text);
                cmd.Parameters.AddWithValue("@regYear", int.Parse(std_reg_year.Text));

                // step 5: Execute the Command/Query
                cmd.ExecuteNonQuery();
                // step 6: Successful Message
                MessageBox.Show("Insertion is Successful");
                // step 7: Close the connection
                con.Close();
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // step 1: Open the connection
                con.Open();
                // step 2: Create the select Query
                string Query = "select * from student";
                // step 3: Create the command to execute
                cmd = new SqlCommand(Query, con);
                // step 4 : Prepare the data for datagrid
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // step 5 : Update the dataGrid Itemsource
                dbGrid.ItemsSource = dt.AsDataView();
                // step 6: Bind the data in the wpf frontend
                DataContext = da;
                // step 7: Close the connection
                con.Close();

            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            // Search Student information
            try
            {
                // step 1: Open the Connection
                con.Open();
                // step 2: Generate the Query
                string Query = "Select * from student where std_id=@ID";
                // Step 3: Generate the Command for SQL
                cmd = new SqlCommand(Query, con);

                // Pass the ID parameter value
                cmd.Parameters.AddWithValue("@ID", int.Parse(std_id.Text));

                // Step 4: Creating the Dataadapter to get the values properly
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Step 5: We are going to fill the textboxes with the retrieved
                // information

                if(dt.Rows != null)
                {
                    std_name.Text = dt.Rows[0]["std_name"].ToString();
                    std_email.Text = dt.Rows[0]["std_email"].ToString();
                    std_reg_year.Text = dt.Rows[0]["std_reg_year"].ToString();
                }
                else
                {
                    MessageBox.Show("Student hasn't registered yet");
                }

                // step 6: Close Connection
                con.Close();

            } catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            // Update the information from the WPF 
            try
            {
                // step 1: Open the Connection
                con.Open();
                // Step 2: Generate the Query
                string Query = "Update student set std_name=@name, " +
                    "std_email=@email, std_reg_year=@stdregyr where std_id=@ID";
                // step 3: generate the SQL command
                cmd = new SqlCommand(Query, con);
                // step 4: passing the update values
                cmd.Parameters.AddWithValue("@name", std_name.Text);
                cmd.Parameters.AddWithValue("@email", std_email.Text);
                cmd.Parameters.AddWithValue("@stdregyr", int.Parse(std_reg_year.Text));
                cmd.Parameters.AddWithValue("@ID", int.Parse(std_id.Text));
                // step 5: Executing the Query/Command
                int i= cmd.ExecuteNonQuery();
                // if cmd executed successfull, it return 1, else 0
                if (i == 1)
                {
                    // step 6: Message to user
                    MessageBox.Show("Information Updated");
                }
                //step 7: Close the Connection
                con.Close();
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Step 1: Open the Connection
                con.Open();
                // Step 2: Generate the Query
                string Query = "Delete from student where std_id=@ID";
                // Step 3: Generate the Command
                cmd = new SqlCommand(Query, con);
                // Step 4: Pass the Parameter's value
                cmd.Parameters.AddWithValue("@ID", int.Parse(std_id.Text));
                // step 5: Execute the Query
                int i= cmd.ExecuteNonQuery();

                if (i == 1)
                {
                    MessageBox.Show("Entry deleted");
                }
                else
                {
                    MessageBox.Show("Check the ID properly");
                }
                // step 6: Close the Connection
                con.Close();
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }
    }
}
