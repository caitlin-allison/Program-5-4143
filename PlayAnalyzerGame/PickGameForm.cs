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

        private void BackButton_Click(object sender, EventArgs e)
        {
            InputFileForm inputFileForm = new InputFileForm();
            inputFileForm.Show();
            this.Hide();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            string type = HairRadio.Checked ? "HairAnalyzer" :
                PrintRadio.Checked ? "PrintAnalyzer" :
                DNARadio.Checked ? "DNAAnalyzer" :
                "";
            if (type != "")
            {
                // Assign the game to its specific Analyzer type
                switch(type)
                {
                    case "HairAnalyzer": this.game = new HairAnalyzer(this.row, this.column, this.numSamples);
                        break;
                    case "PrintAnalyzer": this.game = new PrintAnalyzer(this.row, this.column, this.numSamples);
                        break;
                    case "DNAAnalyzer":
                        this.game = new DNAAnalyzer(this.row, this.column, this.numSamples);
                        break;
                }
                if (game != null)
                {
                    // Close this form and open Analyzer Game Form
                    AnalyzerGameForm analyzerGameForm = new AnalyzerGameForm(game);
                    analyzerGameForm.Show();
                    this.Hide();
                }
            }
        }
    }
}
