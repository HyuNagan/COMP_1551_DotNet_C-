using COMP1551.DBContext;
using System;
using System.Linq;
using System.Windows.Forms;
using COMP1551.QuestionContext;

namespace COMP1551
{
    public partial class PlayGameForm : Form
    {
        private Question currentQuestion;
        private int score = 0;
        private QuizDbContext _context;
        private System.Windows.Forms.Timer timer;
        private int timeLeft = 30; // Thời gian cho mỗi câu hỏi

        public PlayGameForm()
        {
            InitializeComponent();
            _context = new QuizDbContext(); // Khởi tạo context
            LoadQuestion(); // Lấy câu hỏi đầu tiên
            StartTimer(); // Bắt đầu bộ đếm thời gian
            // Gán sự kiện cho các nút
            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
            button4.Click += Button_Click;
            SubmitBTN.Click += SubmitBTN_Click;
        }

        // Load câu hỏi từ database và cập nhật giao diện
        private void LoadQuestion()
        {
            // Truy vấn câu hỏi ngẫu nhiên từ database
            currentQuestion = _context.Questions
                .OrderBy(q => Guid.NewGuid())  // Random câu hỏi
                .FirstOrDefault();

            if (currentQuestion != null)
            {
                // Hiển thị nội dung câu hỏi trên QuestionTextLBL
                QuestionTextLBL.Text = currentQuestion.Text;

                // Kiểm tra loại câu hỏi và hiển thị các lựa chọn phù hợp
                if (currentQuestion.Type == QuestionType.MultipleChoice)
                {
                    // Hiển thị các lựa chọn Multiple Choice
                    button1.Text = currentQuestion.OptionA;
                    button2.Text = currentQuestion.OptionB;
                    button3.Text = currentQuestion.OptionC;
                    button4.Text = currentQuestion.OptionD;

                    // Hiển thị các nút chọn và ẩn TextBox và Submit button
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    OpenEndedTextBox.Visible = false;
                    SubmitBTN.Visible = false;
                }
                else if (currentQuestion.Type == QuestionType.TrueFalse)
                {
                    // Hiển thị các lựa chọn True/False
                    button1.Text = "True";
                    button2.Text = "False";

                    // Hiển thị các nút chọn và ẩn TextBox và Submit button
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = false;
                    button4.Visible = false;
                    OpenEndedTextBox.Visible = false;
                    SubmitBTN.Visible = false;
                }
                else if (currentQuestion.Type == QuestionType.OpenEnded)
                {
                    // Ẩn các nút chọn và hiển thị TextBox và Submit button cho câu hỏi mở
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    OpenEndedTextBox.Visible = true;
                    SubmitBTN.Visible = true;
                }
            }
        }

        // Xử lý khi người chơi chọn câu trả lời
        private void Button_Click(object sender, EventArgs e)
        {
            var selectedButton = sender as Button;
            if (selectedButton != null)
            {
                CheckAnswer(selectedButton.Text);
            }
        }

        // Kiểm tra câu trả lời và cập nhật điểm số
        private void CheckAnswer(string selectedAnswer)
        {
            if (selectedAnswer == currentQuestion.Answer)
            {
                score++;
                ScoreValue.Text = score.ToString(); // Cập nhật điểm
            }

            // Tải câu hỏi mới sau khi chọn đáp án
            LoadQuestion();
        }

        // Xử lý khi người chơi nhập câu trả lời cho câu hỏi dạng OpenEnded
        private void SubmitBTN_Click(object sender, EventArgs e)
        {
            // Kiểm tra câu trả lời nhập vào và cập nhật điểm
            if (OpenEndedTextBox.Text.Equals(currentQuestion.Answer, StringComparison.OrdinalIgnoreCase))
            {
                score++;
                ScoreValue.Text = score.ToString(); // Cập nhật điểm
            }

            // Tải câu hỏi mới sau khi nhập câu trả lời
            LoadQuestion();
        }

        // Bắt đầu bộ đếm thời gian
        private void StartTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 giây
            timer.Tick += (sender, e) =>
            {
                // Cập nhật thời gian
                if (timeLeft > 0)
                {
                    timeLeft--;
                    TimerValue.Text = timeLeft.ToString();
                }
                else
                {
                    // Hết thời gian, tự động kiểm tra câu trả lời
                    LoadQuestion();
                    timeLeft = 30; // Reset thời gian
                }
            };
            timer.Start();
        }

    }
}
