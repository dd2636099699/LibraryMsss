using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMs
{
    public partial class addshow : Form
    {
        public addshow()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("存在数据为空，请输入完整！");
            }
            else
            {
                Dao dao = new Dao();
                string sql = $"select * from book where book_id='{textBox1.Text}' or name='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("该书本或编号已经存在，请重新输入！");
                }
                else
                {
                    //    sql = $"insert into book values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}')";
                    //sql = $"insert into book values ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}')";
                    sql = $"insert into book values ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}')";
                   int n=dao.Execute(sql);
                    if (n > 0)
                    {
                        MessageBox.Show("添加成功！");
                      

                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
