/**********************************************************
 * Caitlin Allison & Jered Stevens
 * 4143 - Stringfellow
 * 
 * ScanalyzerGameForm.cs
 * Controls the UI and flow of the Scanalyzer Game
 **********************************************************/

// Still Needs: printAnalyzer Functionality at line 108
//              .dll file
//              Display case#/file name
//              Display success message


using System.Diagnostics.Eventing.Reader;

namespace PlayAnalyzerGame
{

    public partial class AnalyzerGameForm : Form
    {
        private int guessCounter;
        private bool isFirstFound;
        private Analyzer analyzer;
        private int analyzerType;

        public int GuessCounter
        {
            get => guessCounter;
            set
            {
                guessCounter = value;
            }
        }   // GuessCounter

        public int AnalyzerType
        {
            get => analyzerType;
            set
            {
                analyzerType = value;
            }
        }   // AnalyzerType


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
        }   // IsFirstFound


        /*******************************************************
         *      AnalyzerGameForm
         *  Constructor that takes in an analyzer and dynmaically
         *  handles it creation. Loads grid,
         * 
         ******************************************************/
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

            GuessCounterDisplayLabel.Text = analyzer.GuessCounter.ToString();


        } // AnalyzerGameForm


        /**************************************************
         * NewGameSubmitButton_Click
         * 
         * Creates Pick Game Form, and shows it. Hides this form
         * 
         * Author:  Jered Stevens 
         ***************************************************/

        private void NewGameSubmitButton_Click(object sender, EventArgs e)
        {
            PickGameForm pickGame = new PickGameForm(analyzer.Rows, analyzer.Columns, analyzer.SampleNum);
            pickGame.Show();
            this.Hide();
        } // NewGameSubmitButton_Click

        /**************************************************
         * SubmitGuessButton_Click
         * 
         *  Takes user input from guess text boxes and 
         *  makes sure they are valid, then sends the 
         *  guess values to the analyzer. Then shows
         *  the results of the guess
         *  If not valid throws an InputGuessException
         *  error.
         *  
         *  Author: Jered Stevens & Caitlin Allison
         ***************************************************/
        private void SubmitGuessButton_Click(object sender, EventArgs e)
        {

            int rowUserInput;
            int colUserInput;
            try
            {
                // Vars for guess data
                if (int.TryParse(RowInputTextBox.Text, out rowUserInput) && rowUserInput > -1 & rowUserInput < analyzer.Rows)
                {
                    if (int.TryParse(ColInputTextBox.Text, out colUserInput) && colUserInput > -1 && colUserInput < analyzer.Columns)
                    {
                        // Clear input boxes
                        RowInputTextBox.Text = string.Empty;
                        ColInputTextBox.Text = string.Empty;

                        if (analyzer is DNAAnalyzer dnaAnalyzer)
                        {
                            RemainingGuessesLabel.Text = dnaAnalyzer.RemainingGuesses + "";
                        }

                        // Test if guess is correct or not. Tell user the results
                        bool isCorrect = analyzer.EvaluateGuess(rowUserInput, colUserInput);

                        // Update guess label
                        GuessCounterDisplayLabel.Text = analyzer.GuessCounter.ToString();

                        // Show results
                        GridDisplayBox.Text = analyzer.ToString();

                        SamplesFoundDisplayLabel.Text = analyzer.NumOfSamplesFound.ToString();

                        if(analyzer.EndOfGame)
                        {
                            YouLose();
                        }
                    }
                    else
                    {
                        throw new InputGuessException("Column must be between 0 and " + (analyzer.Columns - 1));
                    }
                }
                else
                {
                    throw new InputGuessException("Row must be between 0 and " + (analyzer.Rows - 1));
                }
            }
            catch (InputGuessException error)
            {
                // Show an error message if input is not a valid integer
                MessageBox.Show(error.Message);
                return;
            }
        } // SubmitGuessButton_Click


        /**************************************************
         * QuitButton_Click
         * 
         *  If game is already over, it ends the application.
         *      If game isnt over, shows the answers.
         *  
         *  Author: Jered Stevens
         ***************************************************/

        private void QuitButton_Click(object sender, EventArgs e)
        {
            if (!analyzer.EndOfGame)
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
         *  shows the coordinates of the samples. Shows the
         *  play again button.
         *  
         *  Author: Jered Stevens & Caitlin Allison
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
            //SamplesFoundDisplayLabel.Text = "Answers:";
            GridDisplayBox.Text = analyzer.DisplayResults();
            GuessCounterDisplayLabel.Text = analyzer.GuessCounter + "";

            if (analyzer is DNAAnalyzer dnaAnalyzer)
            {
                RemainingGuessesLabel.Text = dnaAnalyzer.RemainingGuesses + "";
            }

            PlayAgainButton.Visible = true;
            SubmitGuessButton.Visible = false;
        } // YouLose


        /**************************************************
         * PlayAgainButton_Click
         * 
         * Marks most of the game components invisible and 
         *  makes the game setup controls visible again.
         *  
         *  Author: Jered Stevens & Caitlin Allison
         ***************************************************/
        private void PlayAgainButton_Click(object sender, EventArgs e)
        {
            PickGameForm pickGame = new PickGameForm(analyzer.Rows, analyzer.Columns, analyzer.SampleNum);
            pickGame.Show();
            this.Hide();
        }
    } // AnalyzerGameForm


    /**************************************************
     * InputGuessException Class
     * 
     * Programmer defined Application Exception
     *  -Used to identify user input error for 
     * SubmitGuessButton_Click where it excepts
     * a nonnegative integer that is less than the
     * row/column size of the grid.
     * 
     * Author:  Caitlin Allison
     ***************************************************/
    public class InputGuessException : ApplicationException
    {
        public InputGuessException() : base("Invalid input for guess")
        {

        }
        public InputGuessException(string message) : base(message)
        { }
    }
} // PlayAnalyzerGame
