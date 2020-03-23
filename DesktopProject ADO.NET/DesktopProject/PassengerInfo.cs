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
    public partial class PassengerInfo : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-43AE4T0;Initial Catalog=AirlinesReservationDB;Integrated Security=True;");
        public PassengerInfo()
        {
            InitializeComponent();
        }
        private void PassengerInfo_Load(object sender, EventArgs e)
        {
            Display();
            

        }
        private void Display()
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select * from PassengerInfo";
            cm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please upload image");
                return;
            }
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "insert into PassengerInfo values('"+textBox1.Text+ "', '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ", '" + textBox5.Text + "', '" + textBox6.Text + "', " + textBox7.Text + ", '"+pictureBox1.Location+"')";
            //ImageConverter ic = new ImageConverter();
            //byte[] imageD = (byte[])ic.ConvertTo(pictureBox1.Image, typeof(byte[]));
            //cm.Parameters.Add("@Image", SqlDbType.VarBinary).Value = imageD;
            cm.ExecuteNonQuery();
            con.Close();
            Display();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please upload image");
                return;
            }
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "update PassengerInfo set FirstName='" + textBox1.Text + "', LastName ='" + textBox2.Text + "', DateOfBirth ='" + textBox3.Text + "', Age=" + textBox4.Text + ", PhoneNumber='" + textBox5.Text + "', Email='" + textBox6.Text + "', passportNo='" + textBox7.Text + "', ImageUrl = '"+pictureBox1.Location+"' where PassengerID = " + textBox8.Text + "";
            //ImageConverter ic = new ImageConverter();
            //byte[] imageD = (byte[])ic.ConvertTo(pictureBox1.Image, typeof(byte[]));
            //cm.Parameters.Add("@Image", SqlDbType.VarBinary).Value = imageD;
            cm.ExecuteNonQuery();
            con.Close();
            Display();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "delete from PassengerInfo where PassengerID = " + textBox8.Text + "";
            cm.ExecuteNonQuery();
            con.Close();
            Display();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
            }
        }

        
    }
}
