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
    public partial class capnhatloai : Form
    {
        public string id;
        db conn = new db();
        QUANLILOAISANPHAM ql;
        public capnhatloai(string id, QUANLILOAISANPHAM ql)
        {
            InitializeComponent();
            this.id = id;
            this.ql = ql;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void capnhatloai_Load(object sender, EventArgs e)
        {
            if (id != "") { dodulieu(id); }
        }
        private void dodulieu(string id)
        {

            string cmnd = "select * from loai where ma = " + id;
            DataTable dt = conn.readdata(cmnd);
            if (dt != null)
            {
                textBox1.Text = dt.Rows[0]["ma"].ToString();
                textBox2.Text = dt.Rows[0]["ten"].ToString();
               
            }
        }

        private void them()
        {
            string cmd = "SP_them_loai N'" + textBox2.Text + "'";

            if (conn.exedata(cmd) == true)
            {
                MessageBox.Show("Đã thêm ");
            }
            else
            {
                MessageBox.Show("Không thể thêm");
            }
          
            this.Close();
        }

        private void sua()
        {
            string cmd = "SP_sua_loai '" + textBox1.Text + "',N'" + textBox2.Text + "'";

            if (conn.exedata(cmd) == true)
            {
                MessageBox.Show("Đã sửa");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể sửa");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                them();
            }
            else
            {
                sua();
            }
            ql.load();
        }
    }
}
