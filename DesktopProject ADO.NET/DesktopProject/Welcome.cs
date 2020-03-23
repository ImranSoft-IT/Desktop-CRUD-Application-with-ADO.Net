using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopProject
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PassengerInfo ff = new PassengerInfo();
            this.Hide();
            ff.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FlightInfo flightInfo = new FlightInfo();
            flightInfo.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            BookingFlight booking = new BookingFlight();
            booking.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            CabinClass cabin = new CabinClass();
            cabin.Show();
        }
    }
}
