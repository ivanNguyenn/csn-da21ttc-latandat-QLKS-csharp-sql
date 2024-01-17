using Guna.UI2.WinForms;
using HeThongQuanLyKhachSan.All_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace HeThongQuanLyKhachSan
{
    public partial class Dashboard : Form
    {
        public bool isExit = true;
        public event EventHandler Logout;
        public static string quyen;//bien tinh de su dung cho form khac
        public string manv = "";
        public string tennv = "";
        public Dashboard(string manv, string tennv)
        {
            InitializeComponent();
            this.manv = manv;
            this.tennv = tennv;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        
        public void Dashboard_Load(object sender, EventArgs e)
        {
            uC_Addroom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            uC_CheckOut1.Visible = false;
            uC_CustomerDetails1.Visible = false;
            uC_Staff1.Visible = false;
            button_Addroom.PerformClick();

            if (quyen == "NhanVien")
            {
                button_Staff.Enabled = false;
                button_Staff.Visible = false;
                labelquyen.Text = tennv;
            }

            else if (quyen == "Admin")
            {
                button_Staff.Enabled = true;
                button_Staff.Visible = true;
                labelquyen.Text = tennv;
            }
        }

        private void button_Addroom_Click(object sender, EventArgs e)
        {
            uC_Addroom1.Visible = true;
            uC_Addroom1.BringToFront();
        }

        private void button_CustomerResgistration_Click(object sender, EventArgs e)
        {
            uC_CustomerRegistration1.Visible = true;
            uC_CustomerRegistration1.BringToFront();
        }

        private void button_Checkout_Click(object sender, EventArgs e)
        {
            uC_CheckOut1.Visible = true;
            uC_CheckOut1.BringToFront();
        }

        private void button_CustomerDetail_Click(object sender, EventArgs e)
        {
            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
        }

        private void button_Staff_Click(object sender, EventArgs e)
        {
            uC_Staff1.Visible = true;
            uC_Staff1.BringToFront();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs());
            this.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (isExit)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    // Thoát chương trình
                    Application.Exit();
                }
                else
                {
                    //ở lại chương trình
                }
            }
        }

        private void movePictureBox(object sender)
        {
            Guna2Button btn = (Guna2Button)sender;
            img_Slide.Location = new Point(btn.Location.X + 128, btn.Location.Y - 40);
            img_Slide.SendToBack();
        }
        private void button_CustomerResgistration_CheckedChanged(object sender, EventArgs e)
        {
            movePictureBox(sender);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_Maximize_Click(object sender, EventArgs e)
        {  
        if (WindowState == FormWindowState.Normal)
            this.WindowState = FormWindowState.Maximized;
        else
            this.WindowState = FormWindowState.Normal;
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void uC_Staff1_Load(object sender, EventArgs e)
        {

        }
    }
}
