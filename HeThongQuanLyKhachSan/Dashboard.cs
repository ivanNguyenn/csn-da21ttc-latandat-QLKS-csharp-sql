using HeThongQuanLyKhachSan.All_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyKhachSan
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button_Exit_Dashboard_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_Addroom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            uC_CheckOut1.Visible = false;
            uC_CustomerDetails1.Visible = false;
            uC_Staff1.Visible = false;
            button_Addroom.PerformClick();
        }

        private void button_Addroom_Click(object sender, EventArgs e)
        {
            Panel_Moving.Left = button_Addroom.Left + 20;
            uC_Addroom1.Visible = true;
            uC_Addroom1.BringToFront();

        }

        private void button_CustomerResgistration_Click(object sender, EventArgs e)
        {
            Panel_Moving.Left = button_CustomerResgistration.Left + 20;
            uC_CustomerRegistration1.Visible = true;
            uC_CustomerRegistration1.BringToFront();
        }

        private void Panel_Moving_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Checkout_Click(object sender, EventArgs e)
        {
            Panel_Moving.Left = button_Checkout.Left + 20;
            uC_CheckOut1.Visible = true;
            uC_CheckOut1.BringToFront();
        }

        private void button_CustomerDetail_Click(object sender, EventArgs e)
        {
            Panel_Moving.Left = button_CustomerDetails.Left + 20;
            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
        }

        private void button_Staff_Click(object sender, EventArgs e)
        {
            Panel_Moving.Left = button_Staff.Left + 20;
            uC_Staff1.Visible = true;
            uC_Staff1.BringToFront();
        }
    }
}
