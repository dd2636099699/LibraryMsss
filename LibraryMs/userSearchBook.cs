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
    public partial class userSearchBook : Form
    {
        public userSearchBook()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userSearchBook_Load(object sender, EventArgs e)
        {
            table();
        }
        public void table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from book";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());

            }
        
            dc.Close();
            dao.DaoClose();
        }

        private void 借书_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//书号
            int inventory =int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());//库存
            if (inventory < 1)
            {
                MessageBox.Show("存储不足");

            }
            else 
            {
                string sql = $"insert into borrow_books(userid,book_id,book_date) values('{data1.uid}',{id},GETDATE());update book set inventory=({inventory}-1) where book_id={id}";
                Dao dao = new Dao();
                if (dao.Execute(sql) > 1)
                {
                    MessageBox.Show($"用户{data1.uname}借出了图书{id}!");
                    table();
                }

            }

        }
    }
}
