/**********************************************************
 * Caitlin Allison & Jered Stevens
 * 4143 - Stringfellow
 * 
 * ScanalyzerGameForm.cs
 * Controls the UI and flow of the Scanalyzer Game
 **********************************************************/

// Still Needs: printAnalyzer Functionality at line 82-85


using System.Diagnostics.Eventing.Reader;

namespace PlayAnalyzerGame
{
    public partial class AnalyzerGameForm : Form
    {
        private int guessCounter;
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
        } // GuessCounter

        

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
        } // IsFirstFound

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
        } // IsGameOver

        public AnalyzerGameForm()
        {
            InitializeComponent();
            ResetGame();
        } // AnalyzerGameForm


        /**************************************************
         * NewGameSubmitButton_Click
         * 
         * Updates the form to show the main game.
         * Resizes the form, hides components that are no
         * longer needed.
         * 
         * Author:  Jered Stevens
         ***************************************************/

        private void NewGameSubmitButton_Click(object sender, EventArgs e)
        {

            int switchVal;

            // Get input from radio buttons for switch
            if (HairRadio.Checked)
            {
                switchVal = 0;
            }
            else if (PrintRadio.Checked)
            {
                switchVal = 1;
            }
            else
            {
                switchVal = 2;  
            }

            switch (switchVal)
            {
                case 0: analyzer = new HairAnalyzer();
                    break;
                case 1: analyzer = new PrintAnalyzer();
                    break;
                case 2: analyzer = new DNAAnalyzer();
                    break;
            }

            // set remaining guesses for corresponding analyzer
            analyzer.ResetRemainingGuesses();

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
            RemainingGuessesDisplayLabel.Text = analyzer.RemainingGuesses.ToString();
        } // NewGameSubmitButton_Click


        /**************************************************
         * SubmitGuessButton_Click
         * 
         *  Takes user input from guess text boxes and 
         *      makes sure they are valid, then sends the 
         *      guess values to the analyzer. Shows results
         *      of the users guess.
         *  
         *  Author: Jered Stevens
         ***************************************************/

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
            analyzer.RemainingGuesses--;
            GuessCounterDisplayLabel.Text = GuessCounter.ToString();
            RemainingGuessesDisplayLabel.Text = analyzer.RemainingGuesses.ToString();

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
            else if(analyzer.RemainingGuesses == 0)
            {
                InfoLabel.Text = "Out of guesses! GAME OVER!";
                YouLose();
                
            }
            else 
            {
                InfoLabel.Text = "Sorry, incorrect guess.";
            }

            if (analyzer.RemainingGuesses == 1)
            {
                InfoLabel.Text += "\nCareful...last guess...";
            }
        } // SubmitGuessButton_Click


        /**************************************************
         * QuitButton_Click
         * 
         *  If game is already over, resets the game.
         *      If game isnt over, shows the answers.
         *  
         *  Author: Jered Stevens
         ***************************************************/

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
        } // QuitButton_Click


        /**************************************************
         * YouLose
         * 
         * Hides the guess entry section of the game and 
         *  shows the coordinates of the samples. Changes
         *  submit button to "play again"
         *  
         *  Author: Jered Stevens
         ***************************************************/

        private void YouLose()
        {
            GuessEntryGroupBox.Visible = false;
            Sample1AnswerLabel.Text = "Sample 1 Coordinates: " + analyzer.sample1.ToString();
            Sample2AnswerLabel.Text = "Sample 2 Coordinates: " + analyzer.sample2.ToString();
            Sample1AnswerLabel.Visible = true;
            Sample2AnswerLabel.Visible = true;
            QuitButton.Text = "Play Again";
            IsGameOver = true;
        } // YouLose


        /**************************************************
         * ResetGame
         * 
         * Marks most of the game components invisible and 
         *  makes the game setup controls visible again.
         *  
         *  Author: Jered Stevens
         ***************************************************/

        private void ResetGame()
        {
            GuessCounter = 0;
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
        } // ResetGame


    } // AnalyzerGameForm
} // PlayAnalyzerGame
