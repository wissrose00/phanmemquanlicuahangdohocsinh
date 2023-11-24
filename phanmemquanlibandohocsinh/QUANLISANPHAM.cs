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
    public partial class QUANLISANPHAM : Form
    {
        db conn = new db();
        public QUANLISANPHAM()
        {
            InitializeComponent();
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            capnhatsanpham cn = new capnhatsanpham("",this);
            cn.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();
            capnhatsanpham cn = new capnhatsanpham(a, this);
            cn.ShowDialog();
            button1.Enabled = button2.Enabled = false;
        }

        public void load()
        {

            string cmnd = "select * from v_sanpham ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
            dataGridView1.ClearSelection();
            label2.Text = string.Format("Tổng cộng: {0} sản phẩm.", dataGridView1.Rows.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xoa();
            button1.Enabled = button2.Enabled = false;
        }
        void xoa()
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string cmd = "delete sanpham where ma = " + a;
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

        private void button5_Click(object sender, EventArgs e)
        {
            timkiem();
        }

        void timkiem()
        {
            string cmnd = "select * from v_sanpham where [TÊN SP] like N'%" + textBox1.Text + "%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
            dataGridView1.ClearSelection();
            label2.Text = string.Format("Tổng cộng: {0} sản phẩm.", dataGridView1.Rows.Count);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loc();
        }

        void loc() {

            string cmnd = "select * from v_sanpham where [LOẠI] like  N'" + comboBox1.SelectedValue +"'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;

            }
            dataGridView1.ClearSelection();
            label2.Text = string.Format("Tổng cộng: {0} sản phẩm.", dataGridView1.Rows.Count);
        
        }
        private void dodulieu()
        {
            string cmd = " Select * from loai ";
            DataTable dt = conn.readdata(cmd);
            if (dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "ten";
                comboBox1.ValueMember = "ten";
            }
            comboBox1.SelectedIndex = -1;
        }

        private void QUANLISANPHAM_Load(object sender, EventArgs e)
        {
            dodulieu();
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = button2.Enabled = true;
        }
    }
}
