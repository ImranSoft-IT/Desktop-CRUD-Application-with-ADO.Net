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
    public partial class CabinClass : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-43AE4T0;Initial Catalog=AirlinesReservationDB;Integrated Security=True;");
        public CabinClass()
        {
            InitializeComponent();
        }
        private void CabinClass_Load(object sender, EventArgs e)
        {
            Display();
        }
        private void Display()
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select * from CabinType";
            cm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "insert into CabinType values('" + textBox2.Text + "', " + textBox3.Text + ")";
            cm.ExecuteNonQuery();
            con.Close();
            Display();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "update CabinType set Class_Name='" + textBox2.Text + "', Cost ='" + textBox3.Text + "' where CabinID = " + textBox1.Text + "";
            cm.ExecuteNonQuery();
            con.Close();
            Display();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "delete from CabinType where CabinID = " + textBox1.Text + "";
            cm.ExecuteNonQuery();
            con.Close();
            Display();
        }
    }
}
