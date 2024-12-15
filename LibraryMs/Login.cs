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

namespace LibraryMs
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                login();
            }
            else 
            {
                MessageBox.Show("输入有空，请重新输入！");
            
            }
        }
        public void login() 
        {
            //用户
            if (radioButtonUser.Checked==true)
            {
                string sql = $"select  * from MSuser where userid='{textBox1.Text}' and psw='{textBox2.Text}'";
                Dao dao = new Dao();
                IDataReader dc = dao.read(sql);//读取操作
                if (dc.Read())
                {
                  //  MessageBox.Show("登录成功！");
                    data1.uid = dc["userid"].ToString();
                    data1.uname = dc["name"].ToString();
                    user1 u = new user1();
                    this.Hide();
                    u.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("登录失败！");
                  
                }


            }
            //管理员
            if(radioButtonAdmin.Checked==true)
            {
                string sql = $"select  * from admin where id='{textBox1.Text}' and psw='{textBox2.Text}'";
                Dao dao = new Dao();
                IDataReader dc = dao.read(sql);//读取操作
                if (dc.Read())
                {
                 //   MessageBox.Show("登录成功！");
                    admin a = new admin();
                    a.ShowDialog();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("登录失败！");
                
                }


            }
            
        }
    }
}
