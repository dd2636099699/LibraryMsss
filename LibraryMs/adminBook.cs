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
    public partial class adminBook : Form
    {
        public adminBook()
        {
            InitializeComponent();
           

        }
        private void adminBook_Load(object sender, EventArgs e)
        {
            table();
           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void searchIdTable( string id)
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from book where book_id={id}";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
                label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() +
                        dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号
                dc.Close();
                dao.DaoClose();
                return;
            }
            MessageBox.Show("不存在该书籍！");
            
        }
        public void searchNameTable(string name)
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from book where name like '%{name}%' ";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号
                dc.Close();
                dao.DaoClose();
                return;
            }
            MessageBox.Show("该书籍不存在！");

         //   label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() +
        //
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchIdTable(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addshow a = new addshow();
            a.ShowDialog();

        }
        public void table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from book";
            IDataReader dc = dao.read(sql);
            while (dc.Read()) {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());

            }
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() +
                        dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号
            dc.Close();
            dao.DaoClose();
        }
        public void addBook()
        {
            Dao dao = new Dao();
            string sql = "select * from book";
            IDataReader dc = dao.read(sql);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
             string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() +
               dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号
                DialogResult dr = MessageBox.Show("确定删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                    Dao dao = new Dao();
                    string sql = $"delete  from book where book_id='{id}'";
                    if (dao.Execute(sql) > 0)
                    {

                        MessageBox.Show("删除成功！");
                        table();

                    }
                    else
                    {

                        MessageBox.Show("删除失败！");
                    }
                }
               
            }
            catch (Exception)
            {

                MessageBox.Show("请选中要删除的图书！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            table();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() +
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号

        }

        private void button5_Click(object sender, EventArgs e)
        {

           
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string publisher = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string inventory = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                edit ed = new edit(id, name, author, publisher, inventory);
                ed.ShowDialog();
                table();
            }
            catch (Exception)
            {

                MessageBox.Show("err0");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            searchNameTable(textBox2.Text);
        }
    }
}
