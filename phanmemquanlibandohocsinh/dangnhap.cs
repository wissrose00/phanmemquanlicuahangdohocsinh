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
    public partial class dangnhap : Form
    {
        public static string ID_USER = "";
        public static string Name_USER = "";
        db connect = new db();
        public dangnhap()
        {
            InitializeComponent();
        }
        void tc_logout(object sender, EventArgs e)
        {
            (sender as Form1).isExit = false;
            (sender as Form1).Close();
            this.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                textBox2.PasswordChar = '*';
            if (checkBox1.Checked)
                textBox2.PasswordChar = '\0';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
                return;
            }
            if (String.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            login();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void login()
        {
            ID_USER = getID(textBox1.Text, textBox2.Text);
            Name_USER = getName(textBox1.Text, textBox2.Text);
            string a = Name_USER;
            if (a != "")
            {
                Form1 tc = new Form1();
                tc.Show();
                this.Hide();
                tc.logout += new EventHandler(tc_logout);
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin tài khoản !");
                System.Media.SystemSounds.Exclamation.Play();

            }
        }

        // lấy id 
        private string getID(string username, string password)
        {
            string id = "";
            String cmd = ("SELECT * FROM taikhoan WHERE taikhoan ='" + username + "' and matkhau='" + password + "'");
            DataTable dt = connect.readdata(cmd);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["ma"].ToString();
                }
            }
            return id;
        }

        private string getName(string username, string password)
        {
            string id = "";
            String cmd = ("SELECT * FROM taikhoan WHERE taikhoan ='" + username + "' and matkhau='" + password + "'");
            DataTable dt = connect.readdata(cmd);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["ten"].ToString();
                }
            }
            return id;
        }
    }
}
