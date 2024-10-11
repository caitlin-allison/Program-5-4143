/**********************************************************
 * Caitlin Allison & Jered Stevens
 * 4143 - Stringfellow
 * 
 * ScanalyzerGameForm.cs
 * Controls the UI and flow of the Scanalyzer Game
 **********************************************************/


// Not completed yet:
//  bool GameFinished
//  string EvaluateGuess(int row, int column)
//  string UpdateGrid();

namespace PlayAnalyzerGame
{
    public partial class Form1 : Form
    {
        private int guessCounter;
        private int remianingGuesses;
        private bool isFirstFound;
        private bool isGameOver;

        public int GuessCounter
        {
            get => guessCounter;
            set
            {
                guessCounter = value;
            }
        }

        public int RemainingGuesses
        {
            get => remianingGuesses;
            set
            {
                remianingGuesses = value;
            }
        }

        public bool IsFirstFound
        {
            get
            {
                return isFirstFound;
            }
            set
            {
                isFirstFound = value;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return isGameOver;
            }
            set
            {
                isGameOver = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }


        /**************************************************
         * NewGameSubmitButton_Click
         * 
         * Updates the form to show the main game.
         * Resizes the form, hides components that are no
         * longer needed.
         ***************************************************/

        private void NewGameSubmitButton_Click(object sender, EventArgs e)
        {
            IsGameOver = false;
            NewGameGroupBox.Visible = false;
            NewGameInstructionLabel.Visible = false;
            HairRadio.Visible = false;
            BloodRadio.Visible = false;
            DNARadio.Visible = false;
            GameModeImage.Visible = false;
            NewGameSubmitButton.Visible = false;
            Size = new Size(700, 500);

            GridDisplayBox.Visible = true;
            GuessEntryGroupBox.Visible = true;
            RowInputLabel.Visible = true;
            RowInputTextBox.Visible = true;
            ColumnInputLabel.Visible = true;
            ColumnInputTextBox.Visible = true;
            SubmitGuessButton.Visible = true;
            GuessCounterLabel.Visible = true;
            GuessCounterDisplayLabel.Visible = true;
            RemainingGuessesDisplayLabel.Visible = true;
            RemainingGuessesLabel.Visible = true;
            QuitButton.Visible = true;
            InfoLabel.Visible = true;
            GuessCounterDisplayLabel.Text = GuessCounter.ToString();
            RemainingGuessesDisplayLabel.Text = RemainingGuesses.ToString();
        }

        private void SubmitGuessButton_Click(object sender, EventArgs e)
        {
            // Vars for guess data
            int rowUserInput;
            int colUserInput;

            // Get user input, make sure they are integers.
            //  Save values in appropriate place.
            int.TryParse(RowInputTextBox.Text, out rowUserInput);
            int.TryParse(ColumnInputTextBox.Text, out colUserInput);

            // Validate input to make sure it's within bounds
            if (rowUserInput < 0 || rowUserInput > 9 ||
                colUserInput < 0 || colUserInput > 9)
            {
                // If out of bounds, show error message
                MessageBox.Show("Your guess is out of bounds");
                return;
            }

            // Update guess labels
            GuessCounter++;
            RemainingGuesses--;
            GuessCounterDisplayLabel.Text = GuessCounter.ToString();
            RemainingGuessesDisplayLabel.Text = RemainingGuesses.ToString();

            // Test if guess is correct or not. Tell user the results
            //InfoLabel.Text = EvaluateGuess(rowUserInput, colUserInput);
            //GridDisplayBox.Text = UpdateGrid();

            if (RemainingGuesses == 0 && !IsGameOver)
            {
                InfoLabel.Text = "GAME OVER! NO MORE GUESSES.";
                YouLose();
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            if (!IsGameOver)
            {
                YouLose();
            }
            else
            {
                ResetGame();
            }
        }

        private void YouLose()
        {
            GuessEntryGroupBox.Visible = false;
            Sample1AnswerLabel.Visible = true;
            Sample2AnswerLabel.Visible = true;
            QuitButton.Text = "Play Again";
            IsGameOver = true;
        }

        private void ResetGame()
        {
            GuessCounter = 0;
            RemainingGuesses = 25;
            Size = new Size(350, 250);
            NewGameGroupBox.Visible = true;
            NewGameInstructionLabel.Visible = true;
            HairRadio.Visible = true;
            BloodRadio.Visible = true;
            DNARadio.Visible = true;
            GameModeImage.Visible = true;
            NewGameSubmitButton.Visible = true;

            InfoLabel.Visible = false;
            InfoLabel.Text = string.Empty;
            GridDisplayBox.Visible = false;
            GuessEntryGroupBox.Visible = false;
            RowInputLabel.Visible = false;
            RowInputTextBox.Visible = false;
            ColumnInputLabel.Visible = false;
            ColumnInputTextBox.Visible = false;
            SubmitGuessButton.Visible = false;
            GuessCounterLabel.Visible = false;
            GuessCounterDisplayLabel.Visible = false;
            RemainingGuessesDisplayLabel.Visible = false;
            RemainingGuessesLabel.Visible = false;
            QuitButton.Visible = false;
            QuitButton.Text = "Give Up";
            Sample1AnswerLabel.Visible = false;
            Sample2AnswerLabel.Visible = false;
        }


    }
}
