using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HeThongQuanLyKhachSan.All_User_Control
{
    public partial class UC_Addroom : UserControl
    {
        function fn = new function();
        string query;
        int donghh;
        public UC_Addroom()
        {
            InitializeComponent();
        }

        private void UC_Addroom_Load(object sender, EventArgs e)
        {
            clearAll();
            query = "select * from THEMPHONG";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
            if(Dashboard.quyen == "NhanVien")
            {
                button_Addroom.Enabled = false;
                button_DeleteRoom.Enabled = false;
                button_SuaPhong.Enabled = false;
            }    
        }
        public void button_Addroom_Click(object sender, EventArgs e)
        {
            if(txtRoomNumber.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomnum = txtRoomNumber.Text;
                String roomtype = txtRoomType.Text;
                String bed = txtBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                query = "insert into THEMPHONG (SO_PHONG, LOAI_PHONG, LOAI_GIUONG, GIA_TIEN) values ('" + roomnum + "',N'" + roomtype + "',N'" + bed +  "','" + price + "')";
                fn.setData(query, "Đã thêm phòng!");
                UC_Addroom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền đầy đủ thông tin", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UC_Addroom_Load(this, null);
            }    
        }

        public void clearAll()
        {
            txtRoomNumber.Clear();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_Addroom_Leave(object sender, EventArgs e)
        {
            clearAll();
            UC_Addroom_Load(this, null);
        }

        private void UC_Addroom_Enter(object sender, EventArgs e)
        {
            UC_Addroom_Load(this,null);
        }

        string trangthai = "";
        private void button_DeleteRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNumber.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                if (trangthai == "NO")
                {
                    query = "delete from THEMPHONG where SO_PHONG = '" + txtRoomNumber.Text + "'";
                    fn.setData(query, "Xóa phòng thành công");
                    UC_Addroom_Load(this, null);
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Đang có khách hàng trong khách sạn, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearAll();
                }
            } 
            else
            {
                MessageBox.Show("Không xóa được phòng, vui lòng thực hiện lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UC_Addroom_Load(this, null);
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomNumber.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtRoomType.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            txtBed.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value).ToString();
            txtPrice.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value).ToString();
            trangthai = (dataGridView1.Rows[e.RowIndex].Cells[4].Value).ToString();
        }

        private void btn_RefeshTP_Click(object sender, EventArgs e)
        {
            UC_Addroom_Load(this, null);
        }

        private void txt_FullLP_TextChanged(object sender, EventArgs e)
        {
            query = "select *from THEMPHONG where LOAI_PHONG like N'%" + txt_FullLP.Text + "%'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button_SuaPhong_Click(object sender, EventArgs e)
        {
            query = "select * from THEMPHONG";
            DataSet ds = fn.getData(query);
            ds.Tables[0].Rows[donghh][0] = txtRoomNumber.Text;
            ds.Tables[0].Rows[donghh][1] = txtRoomType.Text;
            ds.Tables[0].Rows[donghh][2] = txtBed.Text;
            ds.Tables[0].Rows[donghh][3] = txtPrice.Text;
            //capnhat
            query = "update THEMPHONG set LOAI_PHONG = N'" + txtRoomType.Text + "', LOAI_GIUONG = N'" + txtBed.Text + "', GIA_TIEN = '" + txtPrice.Text + "' where SO_PHONG = '" + txtRoomNumber.Text + "'";
            ds = fn.getData(query);
            fn.setData(query, "Cập nhật thành công");
            ds.Clear();
            UC_Addroom_Load(this, null);
        }
    }
}
