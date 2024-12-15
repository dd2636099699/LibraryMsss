using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMs
{
    public partial class userlend : Form
    {
        public userlend()
        {
            InitializeComponent();
        }

        private void userlend_Load(object sender, EventArgs e)
        {
            table();
        }
        public void table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from borrow_books where userid={data1.uid}";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[3].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string bid=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string sql = $"delete from borrow_books where no={id};update book  set inventory=(inventory+1) where book_id={bid}";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 1)
            {
                MessageBox.Show($"用户{data1.uname}归还图书{bid}");
                table();
            }
            else
            {
                MessageBox.Show("归还失败！");
            }
        }
    }
}
