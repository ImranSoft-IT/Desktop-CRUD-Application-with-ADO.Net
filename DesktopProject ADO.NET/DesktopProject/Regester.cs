using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopProject
{
    public partial class Regester : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-43AE4T0;Initial Catalog=AirlinesReservationDB;Integrated Security=True;");
        public Regester()
        {
            InitializeComponent();
        }

        private void Regester_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show("Field can not be empty");
            }  
            else
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT into Users values ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Wellcome " + textBox1.Text + "! You are Registrated Successfully");

                Welcome firstPage = new Welcome();
                this.Hide();
                firstPage.Show();
            }
        }
    }
}
