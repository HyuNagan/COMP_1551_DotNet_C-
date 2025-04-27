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

        public PlayGameForm()
        {
            InitializeComponent();
            _context = new QuizDbContext(); // Khởi tạo context
            LoadQuestion(); // Lấy câu hỏi đầu tiên
            StartTimer(); // Bắt đầu bộ đếm thời gian nếu cần
                          // Gán sự kiện Click cho các nút
            button1.Click += (sender, e) => CheckAnswer(button1.Tag.ToString());
            button2.Click += (sender, e) => CheckAnswer(button2.Tag.ToString());
            button3.Click += (sender, e) => CheckAnswer(button3.Tag.ToString());
            button4.Click += (sender, e) => CheckAnswer(button4.Tag.ToString());
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
                    // Gán giá trị cho các nút Multiple Choice
                    button1.Text = currentQuestion.OptionA;
                    button1.Tag = "A"; // Gán A cho button1
                    button2.Text = currentQuestion.OptionB;
                    button2.Tag = "B"; // Gán B cho button2
                    button3.Text = currentQuestion.OptionC;
                    button3.Tag = "C"; // Gán C cho button3
                    button4.Text = currentQuestion.OptionD;
                    button4.Tag = "D"; // Gán D cho button4

                    // Đảm bảo các button3 và button4 luôn hiển thị cho câu hỏi multiple choice
                    button3.Visible = true;
                    button4.Visible = true;
                }
                else if (currentQuestion.Type == QuestionType.TrueFalse)
                {
                    // Gán các lựa chọn True/False cho button1 và button2
                    button1.Text = "True";
                    button1.Tag = "True"; // Gán giá trị True cho button1
                    button2.Text = "False";
                    button2.Tag = "False"; // Gán giá trị False cho button2

                    // Ẩn button3 và button4 vì không cần thiết cho câu hỏi True/False
                    button3.Visible = false;
                    button4.Visible = false;
                }
                else if (currentQuestion.Type == QuestionType.OpenEnded)
                {
                    // Ẩn tất cả các button và có thể sử dụng TextBox cho câu hỏi mở
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;

                    // Ví dụ sử dụng TextBox cho câu hỏi mở
                    // textBoxAnswer.Visible = true;  // Hiển thị TextBox cho câu trả lời
                }
            }
        }

        // Xử lý khi người chơi chọn câu trả lời
        private void button1_Click(object sender, EventArgs e)
        {
            CheckAnswer(button1.Tag.ToString());
            Console.WriteLine("A");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckAnswer(button2.Tag.ToString());
            Console.WriteLine("A");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckAnswer(button3.Tag.ToString());
            Console.WriteLine("A");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckAnswer(button4.Tag.ToString());
            Console.WriteLine("A");

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

        // Bắt đầu bộ đếm thời gian (tùy chọn, bạn có thể thêm logic nếu cần)
        // Bắt đầu bộ đếm thời gian (tùy chọn, bạn có thể thêm logic nếu cần)
        private void StartTimer()
        {
            // Khởi tạo Timer
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 giây
            int timeLeft = 30; // Ví dụ: Đặt thời gian bắt đầu là 30 giây
            TimerValue.Text = timeLeft.ToString(); // Hiển thị thời gian ban đầu

            // Cập nhật thời gian sau mỗi 1 giây
            timer.Tick += (sender, e) =>
            {
                if (timeLeft > 0)
                {
                    timeLeft--;
                    TimerValue.Text = timeLeft.ToString(); // Cập nhật giá trị thời gian
                }
                else
                {
                    // Dừng Timer khi thời gian hết
                    timer.Stop();
                    MessageBox.Show("Time's up!"); // Thông báo khi hết thời gian
                }
            };

            timer.Start(); // Bắt đầu bộ đếm thời gian
        }

    }
}
