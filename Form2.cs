using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClassForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            load();
        }
        SqlConnection conn = new SqlConnection("Data Source=system Name; Initial Catalog=University; Integrated Security=true");
        SqlCommand cmd;
        SqlDataReader read;
        SqlDataAdapter drr;

        string id;
        bool Mode = true; // boolen type 
        string sql;

        private void button2_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string course = txtCourse.Text;
            string fee = txtFee.Text;
            //If the Mode is true , then we need to add the record, if the Mode is false we need to update record
            if (Mode == true)
            {
                sql = "insert into tblUserLogin(userName,courseName,courseFee)values(@userName,@courseName,@courseFee)";
                cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@userName", name);
                cmd.Parameters.AddWithValue("@courseName", course);
                cmd.Parameters.AddWithValue("@courseFee", fee);
                MessageBox.Show("record has been saved");
                conn.Open();
                cmd.ExecuteNonQuery();

                // In order to clear the text boxes, we need to write the code
                txtName.Clear();
                txtCourse.Clear();
                txtFee.Clear();
                txtFee.Focus();
            }
            else
            {
                MessageBox.Show("Record has not been saved");
            }
        }

        public void load()
        {
            try
            {
                sql = "select * from tblUserLogin";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                read = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3]);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtCourse.Clear();
            txtFee.Clear();
            txtName.Clear();
            txtName.Focus();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
