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
    public partial class FlightInfo : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-43AE4T0;Initial Catalog=AirlinesReservationDB;Integrated Security=True;");
        public FlightInfo()
        {
            InitializeComponent();
        }
        private void FlightInfo_Load(object sender, EventArgs e)
        {
            Display();
        }
        private void Display()
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select * from FlightInfo";
            cm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "insert into FlightInfo values('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            cm.ExecuteNonQuery();
            con.Close();
            Display();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "update FlightInfo set FlightNunber='" + textBox2.Text + "', TakeOff ='" + textBox3.Text + "', Landing ='" + textBox4.Text + "' where FlightID = " + textBox1.Text + "";
            cm.ExecuteNonQuery();
            con.Close();
            Display();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "delete from FlightInfo where FlightID = " + textBox1.Text + "";
            cm.ExecuteNonQuery();
            con.Close();
            Display();
        }
    }
}
