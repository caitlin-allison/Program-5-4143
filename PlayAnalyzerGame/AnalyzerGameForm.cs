/**********************************************************
 * Caitlin Allison & Jered Stevens
 * 4143 - Stringfellow
 * 
 * ScanalyzerGameForm.cs
 * Controls the UI and flow of the Scanalyzer Game
 **********************************************************/




using System.Diagnostics.Eventing.Reader;

namespace PlayAnalyzerGame
{
    public partial class AnalyzerGameForm : Form
    {
        private int guessCounter;
        private int remianingGuesses;
        private bool isFirstFound;
        private bool isGameOver;
        private Analyzer analyzer;

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

        public AnalyzerGameForm()
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
            // Get input from radio buttons and create corresponding analyzer
            if (HairRadio.Checked)
            {
                analyzer = new HairAnalyzer();
            }
            //else if (PrintRadio.Checked)
            //{
            //    analyzer = new PrintAnalyzer();
            //}
            else
            {
                analyzer = new DNAAnalyzer();
                RemainingGuesses = 10;
            }

            // Hide new game controls
            IsGameOver = false;
            NewGameGroupBox.Visible = false;
            NewGameInstructionLabel.Visible = false;
            HairRadio.Visible = false;
            PrintRadio.Visible = false;
            DNARadio.Visible = false;
            GameModeImage.Visible = false;
            NewGameSubmitButton.Visible = false;

            // Resize Window
            Size = new Size(700, 500);

            // Show controls of the main game
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

            GridDisplayBox.Text = analyzer.ToString();
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
            bool canConvertRow = int.TryParse(RowInputTextBox.Text, out rowUserInput);
            bool canConvertCol = int.TryParse(ColumnInputTextBox.Text, out colUserInput);

            // Clear input boxes
            RowInputTextBox.Text = string.Empty;
            ColumnInputTextBox.Text = string.Empty;

            // Check if input is an integer
            if (!canConvertRow || !canConvertCol)
            {
                MessageBox.Show("Input must be an integer");
                return;
            }

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
            bool isCorrect = analyzer.EvaluateGuess(rowUserInput, colUserInput, guessCounter);

            // Show results
            GridDisplayBox.Text = analyzer.ToString();

            if (isCorrect && !IsFirstFound)
            {
                InfoLabel.Text = "Your guess was correct! One more to go!";
                IsFirstFound = true;
            }
            else if (isCorrect && IsFirstFound)
            {
                InfoLabel.Text = "Congragulations! You Win!";
                IsGameOver = true;
                YouLose();
                
            }
            else if(RemainingGuesses == 0)
            {
                InfoLabel.Text = "Out of guesses! GAME OVER!";
                YouLose();
                
            }
            else 
            {
                InfoLabel.Text = "Sorry, incorrect guess.";
            }

            if (RemainingGuesses == 1)
            {
                InfoLabel.Text += "\nCareful...last guess...";
            }
        } // SubmitGuessButton_Click

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
            Sample1AnswerLabel.Text = "Sample 1 Coordinates: " + analyzer.sample1.ToString();
            Sample2AnswerLabel.Text = "Sample 2 Coordinates: " + analyzer.sample2.ToString();
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
            PrintRadio.Visible = true;
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
