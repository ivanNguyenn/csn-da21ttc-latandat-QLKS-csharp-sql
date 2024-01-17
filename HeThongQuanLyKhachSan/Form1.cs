using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HeThongQuanLyKhachSan
{
    public partial class Form1 : Form
    {
        function fn = new function();
        string query;

        public Form1()
        {
            InitializeComponent();
        }

        public void button_login_Click(object sender, EventArgs e)
        {
            query = "select TEN_DANG_NHAP, MAT_KHAU, ID_NHANVIEN, TEN_NHANVIEN from NHANVIEN where TEN_DANG_NHAP = '" + txtUsername.Text + "' and MAT_KHAU = '" + txtPassword.Text + "'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count != 0)
            {
                Dashboard.quyen = fn.getData("select QUYEN from NHANVIEN where TEN_DANG_NHAP = '" + txtUsername.Text + "' and MAT_KHAU = '" + txtPassword.Text + "'").Tables[0].Rows[0][0].ToString();
                this.Hide();
                Dashboard db = new Dashboard(ds.Tables[0].Rows[0]["ID_NHANVIEN"].ToString(), ds.Tables[0].Rows[0]["TEN_NHANVIEN"].ToString());
                db.Show();
                db.Logout += Db_Logout;
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Form1_Load(this, null);
        }

        private void Db_Logout(object sender, EventArgs e)
        {
            (sender as Dashboard).isExit = false;
            (sender as Dashboard).Close();
            this.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ckb_passwdlogin_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckb_passwdlogin.Checked)
                txtPassword.UseSystemPasswordChar = true;
            if (ckb_passwdlogin.Checked)
                txtPassword.UseSystemPasswordChar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
