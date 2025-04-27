using COMP1551.DBContext;
using System;
using System.Linq;
using System.Windows.Forms;
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

            // Đăng ký sự kiện thay đổi loại câu hỏi
            MultipleCheckBox.CheckedChanged += new EventHandler(QuestionTypeChanged);
            TrueFalseCheckBox.CheckedChanged += new EventHandler(QuestionTypeChanged);
            OpenEndedCheckBox.CheckedChanged += new EventHandler(QuestionTypeChanged);
        }

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
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        // Tạo mới câu hỏi
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng đã chọn hơn một loại câu hỏi
            if ((MultipleCheckBox.Checked && TrueFalseCheckBox.Checked) ||
                (MultipleCheckBox.Checked && OpenEndedCheckBox.Checked) ||
                (TrueFalseCheckBox.Checked && OpenEndedCheckBox.Checked))
            {
                MessageBox.Show("Bạn chỉ được chọn một loại câu hỏi duy nhất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng việc tạo câu hỏi nếu có nhiều loại câu hỏi được chọn
            }

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

                        // Lưu lại loại câu hỏi
                        question.Type = MultipleCheckBox.Checked ? QuestionType.MultipleChoice :
                                         TrueFalseCheckBox.Checked ? QuestionType.TrueFalse : QuestionType.OpenEnded;

                        // Cập nhật câu hỏi khi chuyển sang MultipleChoice
                        if (question.Type == QuestionType.MultipleChoice)
                        {
                            // Đảm bảo các tùy chọn A, B, C, D không bị null
                            question.OptionA = OptionATextBox.Text;
                            question.OptionB = OptionBTextBox.Text;
                            question.OptionC = OptionCTextBox.Text;
                            question.OptionD = OptionDTextBox.Text;

                            // Lưu lại câu trả lời đúng
                            question.Answer = GetSelectedAnswer(); // Câu trả lời đúng cho MultipleChoice
                        }
                        else if (question.Type == QuestionType.TrueFalse)
                        {
                            // Khi chuyển sang True/False, đặt các tùy chọn A, B, C, D sao cho không NULL
                            question.OptionA = " ";  // Đặt giá trị mặc định cho OptionA
                            question.OptionB = " "; // Đặt giá trị mặc định cho OptionB
                            question.OptionC = " ";  // Không sử dụng
                            question.OptionD = " ";  // Không sử dụng

                            // Cập nhật câu trả lời đúng
                            if (TrueAnswer.Checked)
                            {
                                question.Answer = "True";  // Câu trả lời đúng là True
                            }
                            else if (FalseAnswer.Checked)
                            {
                                question.Answer = "False"; // Câu trả lời đúng là False
                            }
                        }

                        context.SaveChanges();  // Lưu lại thay đổi vào cơ sở dữ liệu
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

        // Lấy câu trả lời đúng
        private string GetSelectedAnswer()
        {
            if (MultipleCheckBox.Checked)
            {
                // Nếu kiểu câu hỏi là MultipleChoice, trả về đáp án "A", "B", "C", "D"
                if (AnswerA.Checked) return "A";
                if (AnswerB.Checked) return "B";
                if (AnswerC.Checked) return "C";
                if (AnswerD.Checked) return "D";
            }
            else if (TrueFalseCheckBox.Checked)
            {
                // Nếu kiểu câu hỏi là TrueFalse, trả về "True" hoặc "False"
                if (TrueAnswer.Checked) return "True";
                if (FalseAnswer.Checked) return "False";
            }
            return null;
        }


        // Hàm xử lý khi thay đổi loại câu hỏi
        private void QuestionTypeChanged(object sender, EventArgs e)
        {
            // Kiểm tra khi chọn MultipleChoice
            if (MultipleCheckBox.Checked)
            {
                // Nếu chọn MultipleChoice, cho phép nhập A, B, C, D
                OptionATextBox.Enabled = true;
                OptionBTextBox.Enabled = true;
                OptionCTextBox.Enabled = true;
                OptionDTextBox.Enabled = true;

                // Vô hiệu hóa các checkbox câu trả lời true/false, chỉ cho phép lựa chọn A, B, C, D
                TrueAnswer.Enabled = false;
                FalseAnswer.Enabled = false;

                // Chỉ cho phép chọn câu trả lời trong MultipleChoice
                AnswerA.Enabled = true;
                AnswerB.Enabled = true;
                AnswerC.Enabled = true;
                AnswerD.Enabled = true;
            }
            else if (TrueFalseCheckBox.Checked)
            {
                // Nếu chọn True/False, không cho phép nhập A, B, C, D
                OptionATextBox.Enabled = false;
                OptionBTextBox.Enabled = false;
                OptionCTextBox.Enabled = false;
                OptionDTextBox.Enabled = false;

                // Chỉ cho phép chọn True/False cho câu trả lời đúng
                TrueAnswer.Enabled = true;
                FalseAnswer.Enabled = true;

                // Vô hiệu hóa các checkbox câu trả lời MultipleChoice
                AnswerA.Enabled = false;
                AnswerB.Enabled = false;
                AnswerC.Enabled = false;
                AnswerD.Enabled = false;
            }
            else if (OpenEndedCheckBox.Checked)
            {
                // Nếu chọn OpenEnded, không cho phép nhập A, B, C, D
                OptionATextBox.Enabled = false;
                OptionBTextBox.Enabled = false;
                OptionCTextBox.Enabled = false;
                OptionDTextBox.Enabled = false;

                // Chỉ cho phép nhập câu trả lời tự do
                TrueAnswer.Enabled = false;
                FalseAnswer.Enabled = false;

                // Vô hiệu hóa các checkbox câu trả lời MultipleChoice
                AnswerA.Enabled = false;
                AnswerB.Enabled = false;
                AnswerC.Enabled = false;
                AnswerD.Enabled = false;
            }
            else
            {
                // Nếu không chọn loại câu hỏi nào, tất cả sẽ bị vô hiệu hóa
                OptionATextBox.Enabled = false;
                OptionBTextBox.Enabled = false;
                OptionCTextBox.Enabled = false;
                OptionDTextBox.Enabled = false;

                TrueFalseCheckBox.Enabled = true;
                OpenEndedCheckBox.Enabled = true;
                MultipleCheckBox.Enabled = true;

                // Vô hiệu hóa tất cả các checkbox câu trả lời
                AnswerA.Enabled = false;
                AnswerB.Enabled = false;
                AnswerC.Enabled = false;
                AnswerD.Enabled = false;
                TrueAnswer.Enabled = false;
                FalseAnswer.Enabled = false;
            }
        }

    }
}
