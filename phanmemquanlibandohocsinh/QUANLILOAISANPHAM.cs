using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace phanmemquanlibandohocsinh
{
    public partial class QUANLILOAISANPHAM : Form
    {
        db conn = new db();
        public QUANLILOAISANPHAM()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QUANLILOAISANPHAM_Load(object sender, EventArgs e)
        {
            load();
        }

      public  void load()
        {

            string cmnd = "select * from loai ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
           
            }
            dataGridView1.ClearSelection();
            label2.Text = string.Format("Tổng cộng: {0} loại.", dataGridView1.Rows.Count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            capnhatloai cn = new capnhatloai("",this);
            cn.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();

            capnhatloai cn = new capnhatloai(a, this);
            cn.ShowDialog();
            button1.Enabled = button2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timkiem();
        }

        void timkiem() {
            string cmnd = "select * from loai where ten like N'%" + textBox1.Text + "%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
            dataGridView1.ClearSelection();
            label2.Text = string.Format("Tổng cộng: {0} loại.", dataGridView1.Rows.Count);
        }

        void xoa() {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string cmd = "delete loai where ma = " + a;
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa không ? ", " Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                if (conn.exedata(cmd) == true)
                {
                    MessageBox.Show("Đã xóa dữ liệu");
                }
                else
                {
                    MessageBox.Show("Không thể xóa dữ liệu");
                }
                load();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xoa();
            button1.Enabled = button2.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = button2.Enabled = true;
        }

    }
}
