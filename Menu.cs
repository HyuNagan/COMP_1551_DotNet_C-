namespace COMP1551
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            PlayGameBTN.Click += PlayGameBTN_Click;
            QuestionManagementBTN.Click += QuestionManagementBTN_Click;

        }

        // Event handler for PlayGame button click
        private void PlayGameBTN_Click(object sender, EventArgs e)
        {
            // Open the PlayGameForm when the Play Game button is clicked
            PlayGameForm playGameForm = new PlayGameForm();
            playGameForm.Show();
            this.Hide(); // Optionally hide the current form
        }

        // Event handler for QuestionManagement button click
        private void QuestionManagementBTN_Click(object sender, EventArgs e)
        {
            // Open the QuestionManagementForm when the Question Management button is clicked
            QuestionManager questionManagementForm = new QuestionManager();
            questionManagementForm.Show();
            this.Hide(); // Optionally hide the current form
        }
    }
}
