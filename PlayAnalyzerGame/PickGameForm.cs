/**********************************************************
 * Caitlin Allison & Jered Stevens
 * 4143 - Stringfellow
 * 
 * PickGameForm.cs
 * Allows the user to select which analyzer will be used
 *  during the game.
 **********************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayAnalyzerGame
{
    public partial class PickGameForm : Form
    {
        int row, column, numSamples;
        Analyzer? game;

        public PickGameForm(int row, int column, int numSamples)
        {
            InitializeComponent();
            this.row = row;
            this.column = column;
            this.numSamples = numSamples;
            game = null;
        }

        /*************************************************************
         *      BackButton_Click
         *      Switches the user back to Input File form and hides this.
         * **********************************************************/
        private void BackButton_Click(object sender, EventArgs e)
        {
            InputFileForm inputFileForm = new InputFileForm();
            inputFileForm.Show();
            this.Hide();
        }

        /*************************************************************
        *      PlayButton_Click
        *      Dynamically assigns the analyzer type based on user input.
        *      Switches to Analyzer Game form and hides this form.
        * 
        * **********************************************************/
        private void PlayButton_Click(object sender, EventArgs e)
        {
            string type = HairRadio.Checked ? "HairAnalyzer" :
                PrintRadio.Checked ? "PrintAnalyzer" :
                DNARadio.Checked ? "DNAAnalyzer" :
                "";
            if (type != "")
            {
                try
                {
                    // Assign the game to its specific Analyzer type
                    switch (type)
                    {
                        case "HairAnalyzer":
                            this.game = new HairAnalyzer
                                (this.row, this.column, this.numSamples);
                            break;
                        case "PrintAnalyzer":
                            this.game = new PrintAnalyzer
                                (this.row, this.column, this.numSamples);
                            break;
                        case "DNAAnalyzer":
                            this.game = new DNAAnalyzer
                                (this.row, this.column, this.numSamples);
                            break;
                        default:
                            throw new Exception();
                    }

                    // Close this form and open Analyzer Game Form
                    AnalyzerGameForm analyzerGameForm = new AnalyzerGameForm
                                                                      (game);
                    analyzerGameForm.Show();
                    this.Hide();
                }
                // Illegal game type
                catch (Exception)
                {
                    MessageBox.Show("Invalid game type choice.", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
