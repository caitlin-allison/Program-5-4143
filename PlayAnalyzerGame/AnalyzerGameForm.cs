/**********************************************************
 * Caitlin Allison & Jered Stevens
 * 4143 - Stringfellow
 * 
 * ScanalyzerGameForm.cs
 * Controls the UI and flow of the Scanalyzer Game
 **********************************************************/

// Still Needs: printAnalyzer Functionality at line 108
//              .dll file
//              File input
//              Display case#/file name
//              Display success message


using System.Diagnostics.Eventing.Reader;

namespace PlayAnalyzerGame
{
    public partial class AnalyzerGameForm : Form
    {
        private int guessCounter;
        private bool isFirstFound;
        private bool isGameOver;
        private Analyzer analyzer;
        private int samplesFound;
        private int analyzerType;

        public int GuessCounter
        {
            get => guessCounter;
            set
            {
                guessCounter = value;
            }
        } // GuessCounter

        public int AnalyzerType
        {
            get => analyzerType;
            set
            {
                analyzerType = value;
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

        public int SamplesFound
        {
            get => samplesFound;
            set
            {
                samplesFound = value;
            }
        } // SamplesFound

        public AnalyzerGameForm()
        {
            analyzer = null;
            analyzerType = -1;

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
                analyzer = new HairAnalyzer();
            }
            else if (PrintRadio.Checked)
            {
                analyzer = new PrintAnalyzer();
            }
            else
            {
                analyzer = new DNAAnalyzer();
                
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
            SamplesFoundLabel.Visible = true;
            SamplesFoundDisplayLabel.Visible = true;
            SamplesFoundDisplayLabel.Text = SamplesFound.ToString();
            QuitButton.Visible = true;
            InfoLabel.Visible = true;

            GridDisplayBox.Text = analyzer.ToString();
            GuessCounterDisplayLabel.Text = GuessCounter.ToString();
            RemainingGuessesDisplayLabel.Text = string.Empty;
        } // NewGameSubmitButton_Click

        private void getRowColSize()
        {

        }

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

            int rowUserInput;
            int colUserInput;
            try
            {
                // Vars for guess data
                rowUserInput = int.Parse(RowInputTextBox.Text);  // coud throw a FormatException
                colUserInput = int.Parse(ColumnInputTextBox.Text);  // could also throw a FormatException

                // Clear input boxes
                RowInputTextBox.Text = string.Empty;
                ColumnInputTextBox.Text = string.Empty;

                // Validate input to make sure it's within bounds
                if (rowUserInput < 0 || rowUserInput > 9 ||
                    colUserInput < 0 || colUserInput > 9)
                {
                    // If out of bounds, show error message
                    MessageBox.Show("Your guess is out of bounds");
                    return;
                }
            }
            catch (FormatException)
            {
                // Show an error message if input is not a valid integer
                MessageBox.Show("Input must be an integer");
                
                // Clear input boxes
                RowInputTextBox.Text = string.Empty;
                ColumnInputTextBox.Text = string.Empty;
                return;
            }
            catch (Exception ex)
            {
                // Catch any other unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");

                // Clear input boxes
                RowInputTextBox.Text = string.Empty;
                ColumnInputTextBox.Text = string.Empty;
                return;
            }

            // Update guess label
            GuessCounterDisplayLabel.Text = analyzer.GuessCounter.ToString();
            RemainingGuessesDisplayLabel.Text = string.Empty;

            // Test if guess is correct or not. Tell user the results
            bool isCorrect = analyzer.EvaluateGuess(rowUserInput, colUserInput);

            // Show results
            GridDisplayBox.Text = analyzer.ToString();

            if (isCorrect && !IsFirstFound)
            {
                InfoLabel.Text = "Your guess was correct! One more to go!";
                IsFirstFound = true;
                SamplesFound++;
                SamplesFoundDisplayLabel.Text = SamplesFound.ToString();
            }
            else if (isCorrect && IsFirstFound)
            {
                InfoLabel.Text = "Congragulations! You Win!";
                IsGameOver = true;
                SamplesFound++;
                SamplesFoundDisplayLabel.Text = SamplesFound.ToString();
                YouLose();
                
            }
            //else if(analyzer.RemainingGuesses == 0)
            //{
            //    InfoLabel.Text = "Out of guesses! GAME OVER!";
            //    YouLose();

            //}
            else
            {
                InfoLabel.Text = "Sorry, incorrect guess.";
            }

            //if (analyzer.RemainingGuesses == 1)
            //{
            //    InfoLabel.Text += "\nCareful...last guess...";
            //}
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
            string answers = string.Empty;
            int i = 0;
            foreach (Sample s in analyzer.samples)
            {
                answers += "Sample " + i + " Coordinates: " + s.ToString() + "\n";
                i++;
            }
            Sample1AnswerLabel.Text = answers;
            GuessEntryGroupBox.Visible = false;
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
            SamplesFoundLabel.Visible = false;
            SamplesFoundDisplayLabel.Visible = false;
            QuitButton.Visible = false;
            QuitButton.Text = "Give Up";
            Sample1AnswerLabel.Visible = false;
            Sample2AnswerLabel.Visible = false;
            SamplesFound = 0;
        } // ResetGame


    } // AnalyzerGameForm
} // PlayAnalyzerGame
