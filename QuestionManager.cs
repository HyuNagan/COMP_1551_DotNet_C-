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
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            this.Load += new EventHandler(QuestionManager_Load);
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
            CreateButton.Click += new EventHandler(CreateButton_Click);
            UpdateButton.Click += new EventHandler(UpdateButton_Click);
            DeleteButton.Click += new EventHandler(DeleteButton_Click);
            MultipleCheckBox.CheckedChanged += new EventHandler(QuestionTypeChanged);
            TrueFalseCheckBox.CheckedChanged += new EventHandler(QuestionTypeChanged);
            OpenEndedCheckBox.CheckedChanged += new EventHandler(QuestionTypeChanged);
        }

        private void QuestionManager_Load(object sender, EventArgs e) => LoadQuestions();

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

                    dataGridView1.DataSource = questions;
                }
            }
            catch (Exception ex)
            {
                ShowError("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        // Tạo mới câu hỏi
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
                    // Nếu là OpenEnded, gán chuỗi trống cho các OptionA, OptionB, OptionC, OptionD
                    OptionA = OpenEndedCheckBox.Checked ? "" : OptionATextBox.Text,
                    OptionB = OpenEndedCheckBox.Checked ? "" : OptionBTextBox.Text,
                    OptionC = OpenEndedCheckBox.Checked ? "" : OptionCTextBox.Text,
                    OptionD = OpenEndedCheckBox.Checked ? "" : OptionDTextBox.Text,
                    // Đảm bảo trường Answer không NULL, nếu là OpenEnded thì gán giá trị mặc định
                    Answer = OpenEndedCheckBox.Checked ? "No Answer" : GetSelectedAnswer() // Giá trị mặc định cho Answer
                };

                context.Questions.Add(newQuestion);
                context.SaveChanges();
            }
            LoadQuestions(); // Load lại danh sách câu hỏi từ database
        }



        private bool IsMultipleQuestionTypeSelected() =>
            (MultipleCheckBox.Checked && TrueFalseCheckBox.Checked) ||
            (MultipleCheckBox.Checked && OpenEndedCheckBox.Checked) ||
            (TrueFalseCheckBox.Checked && OpenEndedCheckBox.Checked);

        private Question CreateNewQuestion()
        {
            return new Question
            {
                Text = QuestionNameTextBox.Text,
                Type = GetSelectedQuestionType(),
                OptionA = OptionATextBox.Text,
                OptionB = OptionBTextBox.Text,
                OptionC = OptionCTextBox.Text,
                OptionD = OptionDTextBox.Text,
                Answer = GetSelectedAnswer()
            };
        }

        private QuestionType GetSelectedQuestionType()
        {
            if (MultipleCheckBox.Checked) return QuestionType.MultipleChoice;
            if (TrueFalseCheckBox.Checked) return QuestionType.TrueFalse;
            return QuestionType.OpenEnded;
        }

        private void AddQuestionToDatabase(Question question)
        {
            using (var context = new QuizDbContext())
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var questionId = GetSelectedQuestionId();
                var question = GetQuestionById(questionId);

                if (question != null)
                {
                    UpdateQuestion(question);
                    SaveChanges();
                    LoadQuestions();
                }
            }
        }

        private int GetSelectedQuestionId() =>
            Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

        private Question GetQuestionById(int questionId)
        {
            using (var context = new QuizDbContext())
            {
                return context.Questions.FirstOrDefault(q => q.Id == questionId);
            }
        }

        private void UpdateQuestion(Question question)
        {
            question.Text = QuestionNameTextBox.Text;
            question.Type = GetSelectedQuestionType();
            UpdateQuestionOptions(question);
            question.Answer = GetSelectedAnswer();
        }

        private void UpdateQuestionOptions(Question question)
        {
            if (question.Type == QuestionType.MultipleChoice)
            {
                question.OptionA = OptionATextBox.Text;
                question.OptionB = OptionBTextBox.Text;
                question.OptionC = OptionCTextBox.Text;
                question.OptionD = OptionDTextBox.Text;
            }
            else if (question.Type == QuestionType.TrueFalse)
            {
                question.OptionA = " ";
                question.OptionB = " ";
                question.OptionC = " ";
                question.OptionD = " ";
            }
        }

        private void SaveChanges()
        {
            using (var context = new QuizDbContext())
            {
                context.SaveChanges();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var questionId = GetSelectedQuestionId();
                var question = GetQuestionById(questionId);

                if (question != null)
                {
                    DeleteQuestionFromDatabase(question);
                    LoadQuestions();
                }
                else
                {
                    ShowError("Không tìm thấy câu hỏi cần xóa.");
                }
            }
            else
            {
                ShowError("Vui lòng chọn câu hỏi cần xóa.");
            }
        }

        private void DeleteQuestionFromDatabase(Question question)
        {
            using (var context = new QuizDbContext())
            {
                context.Questions.Remove(question);
                context.SaveChanges();
            }
        }

        private void ShowError(string message) => MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var questionId = GetSelectedQuestionId();
                var question = GetQuestionById(questionId);

                if (question != null)
                {
                    DisplayQuestionDetails(question);
                }
            }
        }

        private void DisplayQuestionDetails(Question question)
        {
            QuestionNameTextBox.Text = question.Text;
            OptionATextBox.Text = question.OptionA;
            OptionBTextBox.Text = question.OptionB;
            OptionCTextBox.Text = question.OptionC;
            OptionDTextBox.Text = question.OptionD;
            OpenEndedTextBox.Text = question.Answer;

            MultipleCheckBox.Checked = question.Type == QuestionType.MultipleChoice;
            TrueFalseCheckBox.Checked = question.Type == QuestionType.TrueFalse;
            OpenEndedCheckBox.Checked = question.Type == QuestionType.OpenEnded;

            AnswerA.Checked = question.Answer == "A";
            AnswerB.Checked = question.Answer == "B";
            AnswerC.Checked = question.Answer == "C";
            AnswerD.Checked = question.Answer == "D";
            TrueAnswer.Checked = question.Answer == "True";
            FalseAnswer.Checked = question.Answer == "False";
        }

        private string GetSelectedAnswer()
        {
            if (MultipleCheckBox.Checked)
            {
                if (AnswerA.Checked) return "A";
                if (AnswerB.Checked) return "B";
                if (AnswerC.Checked) return "C";
                if (AnswerD.Checked) return "D";
            }
            else if (TrueFalseCheckBox.Checked)
            {
                if (TrueAnswer.Checked) return "True";
                if (FalseAnswer.Checked) return "False";
            }
            return null;
        }

        private void QuestionTypeChanged(object sender, EventArgs e)
        {
            if (MultipleCheckBox.Checked)
            {
                SetMultipleChoiceOptions(true);
            }
            else if (TrueFalseCheckBox.Checked)
            {
                SetTrueFalseOptions(true);
            }
            else if (OpenEndedCheckBox.Checked)
            {
                SetOpenEndedOptions(true);
            }
            else
            {
                DisableAllOptions();
            }
        }

        private void SetMultipleChoiceOptions(bool enable)
        {
            OptionATextBox.Enabled = OptionBTextBox.Enabled = OptionCTextBox.Enabled = OptionDTextBox.Enabled = enable;
            AnswerA.Enabled = AnswerB.Enabled = AnswerC.Enabled = AnswerD.Enabled = enable;
            TrueAnswer.Enabled = FalseAnswer.Enabled = false;
        }

        private void SetTrueFalseOptions(bool enable)
        {
            OptionATextBox.Enabled = OptionBTextBox.Enabled = OptionCTextBox.Enabled = OptionDTextBox.Enabled = false;
            AnswerA.Enabled = AnswerB.Enabled = AnswerC.Enabled = AnswerD.Enabled = false;
            TrueAnswer.Enabled = FalseAnswer.Enabled = enable;
        }

        private void SetOpenEndedOptions(bool enable)
        {
            OptionATextBox.Enabled = OptionBTextBox.Enabled = OptionCTextBox.Enabled = OptionDTextBox.Enabled = false;
            TrueAnswer.Enabled = FalseAnswer.Enabled = false;
            AnswerA.Enabled = AnswerB.Enabled = AnswerC.Enabled = AnswerD.Enabled = false;
        }

        private void DisableAllOptions()
        {
            OptionATextBox.Enabled = OptionBTextBox.Enabled = OptionCTextBox.Enabled = OptionDTextBox.Enabled = false;
            AnswerA.Enabled = AnswerB.Enabled = AnswerC.Enabled = AnswerD.Enabled = false;
            TrueAnswer.Enabled = FalseAnswer.Enabled = false;
        }
    }
}
