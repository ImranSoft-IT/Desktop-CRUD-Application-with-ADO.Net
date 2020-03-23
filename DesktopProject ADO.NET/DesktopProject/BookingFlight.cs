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
    public partial class BookingFlight : Form
    {
        string connection = @"Data Source=DESKTOP-43AE4T0;Initial Catalog=AirlinesReservationDB;Integrated Security=True";
        public BookingFlight()
        {
            InitializeComponent();
        }
        private DataTable fillData(string query)
        {
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {

                    da.SelectCommand = new SqlCommand(query, conn);
                    da.SelectCommand.CommandType = CommandType.Text;

                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "CustomerGender");
                    }
                    catch (Exception ee)
                    {

                    }

                    if (ds.Tables.Count == 0)
                    {
                        DataTable dt = new DataTable();
                        ds.Tables.Add(dt);
                    }
                    return ds.Tables[0];

                }
            }
        }
        private void BookingFlight_Load(object sender, EventArgs e)
        {
            string query = @" SELECT [SupplierID],[SupplierName],[CustomerID],[MobileNumber] FROM [dbo].[Supplier]";
            DataTable dt = fillData(query);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "SupplierName";
            comboBox1.ValueMember = "SupplierID";

            string query1 = @"SELECT [ProductID],[ProductName],[ImageUrl] ,[Rate] FROM [dbo].[Product]";
            DataTable dt1 = fillData(query1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "ProductName";
            comboBox2.ValueMember = "ProductID";


            dataGridView1.DataSource = fillData(@"select ss.ServiceID , p.ProductName , s.SupplierName , ss.Quntity from dbo.[Service] ss inner join dbo.Supplier  s 
            on ss.SupplierID = s.SupplierID  inner join dbo.Product p
            on ss.ProductID = p.ProductID");
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
