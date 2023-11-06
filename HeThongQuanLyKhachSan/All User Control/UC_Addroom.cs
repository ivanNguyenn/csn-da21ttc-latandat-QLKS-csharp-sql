using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyKhachSan.All_User_Control
{
    public partial class UC_Addroom : UserControl
    {
        function fn = new function();
        string query;
        public UC_Addroom()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UC_Addroom_Load(object sender, EventArgs e)
        {
            query = "select * from THEMPHONG";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button_Addroom_Click(object sender, EventArgs e)
        {
            if(txtRoomNumber.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomnum = txtRoomNumber.Text;
                String roomtype = txtRoomType.Text;
                String bed = txtBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                query = "insert into THEMPHONG (SO_PHONG, LOAI_PHONG, LOAI_GIUONG, GIA_TIEN) values ('" + roomnum + "','" + roomtype + "',N'" + bed +  "','" + price + "')";
                fn.setData(query, "Đã thêm phòng!");

                UC_Addroom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền đầy đủ thông tin", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void UC_Addroom_Enter(object sender, EventArgs e)
        {
            UC_Addroom_Load(this,null);
        }
    }
}
