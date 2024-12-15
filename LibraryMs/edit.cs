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
    public partial class edit : Form
        
    {
        string ID;
        public edit()
        {
            InitializeComponent();
        }
        public edit(string id,string name,string author,string publisher,string inventory)
        {
            InitializeComponent();
            ID=textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = author;
            textBox5.Text = publisher;
            textBox4.Text = inventory;
        }

        private void edit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql = $"update  book set book_id={textBox1.Text},name='{textBox2.Text}'," +
                $"author='{textBox3.Text}',publisher_name='{textBox4.Text}',inventory={textBox1.Text} where book_id='{ID}'";

            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功!");
                this.Close();

            }
            else
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
