/**********************************************************
 * Caitlin Allison & Jered Stevens
 * 4143 - Stringfellow
 * 
 * ScanalyzerGameForm.cs
 * Controls the UI and flow of the Scanalyzer Game
 **********************************************************/

// Still Needs: printAnalyzer Functionality at line 108
//              .dll file
//              ApplicationException
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

        public AnalyzerGameForm(Analyzer analyzer)
        {
            if (analyzer is DNAAnalyzer dnaAnalyzer)
            {
                this.analyzer = dnaAnalyzer;
            }
            else if (analyzer is HairAnalyzer hairAnalyzer)
            {
                this.analyzer = hairAnalyzer;
            }
            else if (analyzer is PrintAnalyzer printAnalyzer)
            {
                this.analyzer = printAnalyzer;
            }
            else
            {
                throw new ArgumentException();
            }
            if (analyzer is null)
            {
                GuessCounterLabel.Text = "Analyzer is null";
            }
            InitializeComponent();

            this.Text = analyzer.Type() + " Game";
            GridDisplayBox.Text = analyzer.ToString();

            if (analyzer is DNAAnalyzer analyzerDNA)
            {
                RemainingGuessesLabel.Text = analyzerDNA.RemainingGuesses + "";
            }
            else
            {
                RemainingGuessesLabel.Visible = false;
                RemainingGuessesDisplayLabel.Visible = false;
            }

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
            PickGameForm pickGame = new PickGameForm(analyzer.Rows, analyzer.Columns, analyzer.SampleNum);
            pickGame.Show();
            this.Hide();
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
                colUserInput = int.Parse(ColInputTextBox.Text);  // could also throw a FormatException

                // Clear input boxes
                RowInputTextBox.Text = string.Empty;
                ColInputTextBox.Text = string.Empty;

                // Validate input to make sure it's within bounds
                if (rowUserInput < 0 || rowUserInput > analyzer.Rows ||
                    colUserInput < 0 || colUserInput > analyzer.Columns)
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
                ColInputTextBox.Text = string.Empty;
                return;
            }
            catch (Exception ex)
            {
                // Catch any other unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");

                // Clear input boxes
                RowInputTextBox.Text = string.Empty;
                ColInputTextBox.Text = string.Empty;
                return;
            }


            if (analyzer is DNAAnalyzer dnaAnalyzer)
            {
                RemainingGuessesLabel.Text = dnaAnalyzer.RemainingGuesses + "";
            }

            // Test if guess is correct or not. Tell user the results
            bool isCorrect = analyzer.EvaluateGuess(yInput, xInput);

            // Update guess label
            GuessCounterDisplayLabel.Text = analyzer.GuessCounter.ToString();

            // Show results
            GridDisplayBox.Text = analyzer.ToString();

            if (isCorrect && !IsFirstFound)
            {
                IsFirstFound = true;
                SamplesFoundDisplayLabel.Text = analyzer.NumOfSamplesFound.ToString();
            }
            else if (isCorrect && IsFirstFound)
            {
                IsGameOver = true;
                SamplesFoundDisplayLabel.Text = analyzer.NumOfSamplesFound.ToString();
                YouLose();

            }
            //else if(analyzer.RemainingGuesses == 0)
            //{
            //    InfoLabel.Text = "Out of guesses! GAME OVER!";
            //    YouLose();

            //}
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
                Application.Exit();
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
            SubmitGuessButton.Enabled = false;
            RowInputTextBox.Enabled = false;
            ColInputTextBox.Enabled = false;

            string answers = string.Empty;
            int i = 0;
            foreach (Sample s in analyzer.samples)
            {
                answers += "Sample " + i + " Coordinates: " + s.ToString() + "\n";
                i++;
            }

            SamplesFoundLabel.Text = answers;
            SamplesFoundDisplayLabel.Text = "Answers:";
            GridDisplayBox.Text = analyzer.DisplayResults();
            GuessCounterLabel.Text = analyzer.GuessCounter + "";

            if (analyzer is DNAAnalyzer dnaAnalyzer)
            {
                RemainingGuessesLabel.Text = dnaAnalyzer.RemainingGuesses + "";
            }

            IsGameOver = true;
            PlayAgainButton.Visible = true;
            SubmitGuessButton.Visible = false;
        } // YouLose


        /**************************************************
         * ResetGame
         * 
         * Marks most of the game components invisible and 
         *  makes the game setup controls visible again.
         *  
         *  Author: Jered Stevens
         ***************************************************/
        private void PlayAgainButton_Click(object sender, EventArgs e)
        {
            PickGameForm pickGame = new PickGameForm(analyzer.Rows, analyzer.Columns, analyzer.SampleNum);
            pickGame.Show();
            this.Hide();
            analyzer = null;
        }
    } // AnalyzerGameForm
} // PlayAnalyzerGame
