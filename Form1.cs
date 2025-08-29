using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Enter the sql data connection
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ClassForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JLQCCR6; Initial Catalog=University; Integrated Security=true");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Username, Userpassword;
            Username = txtUserName.Text;
            Userpassword = txtUserPassword.Text;
            try
            {
                String query = "select * from tblLoginPage where UserName='" + txtUserName.Text + "' and UserPassword='" + txtUserPassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    Username = txtUserName.Text;
                    Userpassword = txtUserPassword.Text;
                    MessageBox.Show("Login Successful");
                    Form2 M1 = new Form2();
                    M1.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("The login or password is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Clear();
                    txtUserPassword.Clear();
                    //to focus the username
                    txtUserName.Focus();

                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtUserPassword.Clear();
            txtUserName.Focus();
        }
    }
}
