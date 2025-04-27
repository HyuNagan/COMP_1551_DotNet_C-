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
using COMP1551.QuestionContext;

namespace COMP1551
{
    public partial class QuestionManager : Form
    {
        public QuestionManager()
        {
            InitializeComponent();
            this.Load += new EventHandler(QuestionManager_Load); // Đăng ký sự kiện Load
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged); // Đăng ký sự kiện SelectionChanged

            // Đăng ký các sự kiện cho các button
            CreateButton.Click += new EventHandler(CreateButton_Click);
            UpdateButton.Click += new EventHandler(UpdateButton_Click);
            DeleteButton.Click += new EventHandler(DeleteButton_Click);
        }

        // Sự kiện Load để gọi LoadQuestions khi form được tải
        private void QuestionManager_Load(object sender, EventArgs e)
        {
            LoadQuestions();
        }

        // Load câu hỏi từ cơ sở dữ liệu vào DataGridView
        private void LoadQuestions()
        {
            try
            {
                using (var context = new QuizDbContext())
                {
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

        // Tạo mới câu hỏi
        private void CreateButton_Click(object sender, EventArgs e)
        {
            using (var context = new QuizDbContext())
            {
                var newQuestion = new Question
                {
                    Text = QuestionNameTextBox.Text,
                    Type = MultipleCheckBox.Checked ? QuestionType.MultipleChoice :
                          TrueFalseCheckBox.Checked ? QuestionType.TrueFalse : QuestionType.OpenEnded,
                    OptionA = OptionATextBox.Text,
                    OptionB = OptionBTextBox.Text,
                    OptionC = OptionCTextBox.Text,
                    OptionD = OptionDTextBox.Text,
                    Answer = GetSelectedAnswer() // Đảm bảo lấy câu trả lời đúng
                };

                context.Questions.Add(newQuestion);
                context.SaveChanges();
            }
            LoadQuestions(); // Load lại danh sách câu hỏi từ database
        }

        // Lấy câu trả lời đúng
        private string GetSelectedAnswer()
        {
            if (AnswerA.Checked) return "A";
            if (AnswerB.Checked) return "B";
            if (AnswerC.Checked) return "C";
            if (AnswerD.Checked) return "D";
            if (TrueAnswer.Checked) return "True";
            if (FalseAnswer.Checked) return "False";
            return null;
        }

        // Cập nhật câu hỏi
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int questionId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                using (var context = new QuizDbContext())
                {
                    var question = context.Questions.FirstOrDefault(q => q.Id == questionId);
                    if (question != null)
                    {
                        question.Text = QuestionNameTextBox.Text;
                        question.Type = MultipleCheckBox.Checked ? QuestionType.MultipleChoice :
                                        TrueFalseCheckBox.Checked ? QuestionType.TrueFalse : QuestionType.OpenEnded;
                        question.OptionA = OptionATextBox.Text;
                        question.OptionB = OptionBTextBox.Text;
                        question.OptionC = OptionCTextBox.Text;
                        question.OptionD = OptionDTextBox.Text;
                        question.Answer = GetSelectedAnswer();

                        context.SaveChanges();
                    }
                }
                LoadQuestions(); // Load lại danh sách câu hỏi
            }
        }

        // Xóa câu hỏi
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int questionId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                using (var context = new QuizDbContext())
                {
                    var question = context.Questions.FirstOrDefault(q => q.Id == questionId);
                    if (question != null)
                    {
                        context.Questions.Remove(question);
                        context.SaveChanges();
                    }
                }
                LoadQuestions(); // Load lại danh sách câu hỏi
            }
        }

        // Hiển thị thông tin câu hỏi vào các textbox khi chọn câu hỏi từ DataGridView
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int questionId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                using (var context = new QuizDbContext())
                {
                    var question = context.Questions.FirstOrDefault(q => q.Id == questionId);
                    if (question != null)
                    {
                        // Hiển thị thông tin câu hỏi vào các textbox
                        QuestionNameTextBox.Text = question.Text;
                        OptionATextBox.Text = question.OptionA;
                        OptionBTextBox.Text = question.OptionB;
                        OptionCTextBox.Text = question.OptionC;
                        OptionDTextBox.Text = question.OptionD;
                        OpenEndedTextBox.Text = question.Answer;

                        // Cập nhật các checkbox theo loại câu hỏi
                        MultipleCheckBox.Checked = question.Type == QuestionType.MultipleChoice;
                        TrueFalseCheckBox.Checked = question.Type == QuestionType.TrueFalse;
                        OpenEndedCheckBox.Checked = question.Type == QuestionType.OpenEnded;

                        // Cập nhật câu trả lời đúng cho các loại câu hỏi
                        AnswerA.Checked = question.Answer == "A";
                        AnswerB.Checked = question.Answer == "B";
                        AnswerC.Checked = question.Answer == "C";
                        AnswerD.Checked = question.Answer == "D";
                        TrueAnswer.Checked = question.Answer == "True";
                        FalseAnswer.Checked = question.Answer == "False";
                    }
                }
            }
        }
    }
}
