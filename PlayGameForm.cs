using COMP1551.DBContext;
using COMP1551.QuestionContext;

namespace COMP1551
{
    public partial class PlayGameForm : Form
    {
        private List<Question> questions;
        private Question currentQuestion; // Declare currentQuestion here
        private int currentQuestionIndex = 0;
        private int score = 0;
        private QuizDbContext _context;
        private System.Windows.Forms.Timer timer;
        private int timeLeft = 30; // Time per question

        public PlayGameForm()
        {
            InitializeComponent();
            _context = new QuizDbContext(); // Initialize context
            LoadQuestions(); // Load all questions from the database
            LoadQuestion(); // Load the first question
            StartTimer(); // Start the timer

            // Assign event handlers for the buttons
            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
            button4.Click += Button_Click;
            SubmitBTN.Click += SubmitBTN_Click;
            this.FormClosed += PlayGameForm_FormClosed; // Add the FormClosed event handler
        }

        private void PlayGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show the Menu form when the PlayGameForm is closed
            Menu menuForm = new Menu();
            menuForm.Show();
        }

        // Load all questions from the database
        private void LoadQuestions()
        {
            questions = _context.Questions.OrderBy(q => q.Id).ToList(); // Load questions in order of their ID
        }

        // Load the current question and update the UI
        private void LoadQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                currentQuestion = questions[currentQuestionIndex]; // Get the current question

                // Display the question text
                QuestionTextLBL.Text = currentQuestion.Text;

                // Check the question type and update the UI accordingly
                if (currentQuestion.Type == QuestionType.MultipleChoice)
                {
                    button1.Text = currentQuestion.OptionA;
                    button2.Text = currentQuestion.OptionB;
                    button3.Text = currentQuestion.OptionC;
                    button4.Text = currentQuestion.OptionD;

                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    OpenEndedTextBox.Visible = false;
                    SubmitBTN.Visible = false;
                }
                else if (currentQuestion.Type == QuestionType.TrueFalse)
                {
                    button1.Text = "True";
                    button2.Text = "False";

                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = false;
                    button4.Visible = false;
                    OpenEndedTextBox.Visible = false;
                    SubmitBTN.Visible = false;
                }
                else if (currentQuestion.Type == QuestionType.OpenEnded)
                {
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    OpenEndedTextBox.Visible = true;
                    SubmitBTN.Visible = true;
                }
            }
            else
            {
                // No more questions, end the game
                MessageBox.Show($"Game Over! Your score is: {score}");
                this.Close(); // Close the form and go back to Menu
            }
        }

        // Handle button clicks for multiple choice and true/false questions
        private void Button_Click(object sender, EventArgs e)
        {
            var selectedButton = sender as Button;
            if (selectedButton != null)
            {
                CheckAnswer(selectedButton.Text);
            }
        }

        // Check if the selected answer is correct and update the score
        private void CheckAnswer(string selectedAnswer)
        {
            if (selectedAnswer == currentQuestion.Answer)
            {
                score++;
                ScoreValue.Text = score.ToString(); // Update score
            }

            // Move to the next question
            currentQuestionIndex++;
            LoadQuestion(); // Load the next question
        }

        // Handle the submit button click for open-ended questions
        private void SubmitBTN_Click(object sender, EventArgs e)
        {
            if (OpenEndedTextBox.Text.Equals(currentQuestion.Answer, StringComparison.OrdinalIgnoreCase))
            {
                score++;
                ScoreValue.Text = score.ToString(); // Update score
            }

            // Move to the next question
            currentQuestionIndex++;
            LoadQuestion(); // Load the next question
        }

        // Start the timer for each question
        private void StartTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (sender, e) =>
            {
                if (timeLeft > 0)
                {
                    timeLeft--;
                    TimerValue.Text = timeLeft.ToString(); // Update timer display
                }
                else
                {
                    // Time's up, automatically go to the next question
                    currentQuestionIndex++;
                    LoadQuestion(); // Load the next question
                    timeLeft = 30; // Reset the time
                }
            };
            timer.Start();
        }
    }
}
