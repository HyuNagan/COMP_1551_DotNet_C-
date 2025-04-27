using COMP1551.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;


namespace COMP1551
{
    public partial class QuestionManager : Form
    {
        public QuestionManager()
        {
            InitializeComponent();
            this.Load += new EventHandler(QuestionManager_Load); // Đăng ký sự kiện Load

        }

        // Sự kiện Load để gọi LoadQuestions khi form được tải
        private void QuestionManager_Load(object sender, EventArgs e)
        {
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            try
            {
     
                using (var context = new QuizDbContext())
                {
                    // Truy vấn dữ liệu từ bảng Questions và chuyển thành danh sách đối tượng
                    var questions = context.Questions
                                           .Select(q => new
                                           {
                                               q.Id,
                                               q.Text,
                                               q.Type,
                                               q.OptionA,
                                               q.OptionB,
                                               q.OptionC,
                                               q.OptionD,
                                               q.Answer
                                           })
                                           .ToList();

                    // Gán dữ liệu vào DataGridView
                    dataGridView1.DataSource = questions;
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo nếu có lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }

}
