﻿/**********************************************************
 * Caitlin Allison & Jered Stevens
 * 4143 - Stringfellow
 * 
 * InputFileForm.cs
 * Allows User to select an input file to be used 
 *  with the analyzer game.
 **********************************************************/


using System;
using System.Collections;
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
    public partial class InputFileForm : Form
    {
        int row;
        int column;
        int numSamples;
        string file_name;

        public InputFileForm()
        {
            row = column = numSamples = 0;
            file_name = "";

            InitializeComponent();
        }

        /*************************************************************
         *      button1_Click
         *      Opens user directory to read in file
         *      If the user selected a file, creates a read stream to
         *      grab the data. Create and show Pick Game form, while
         *      hiding this.
         * 
         * **********************************************************/
        private void button1_Click(object sender, EventArgs e)
        {
            // Only allows .txt file for input
            openFileDialog1.Filter = "Text Files|*.txt";
            DialogResult res = openFileDialog1.ShowDialog(this);

            // User has selected a file
            if (res == DialogResult.OK)
            {
                StreamReader file_stream = new StreamReader
                                (openFileDialog1.OpenFile());

                List<int> userInput = new List<int>();
                try
                {
                    // Reads in file and stores the value within their
                    // respective variables.
                    do
                    {
                        string line = file_stream.ReadLine();
                        if (line != null)
                        {
                            string[] words = line.Split(' ');
                            userInput.Add(Convert.ToInt32(words[0]));
                            if (words.Length == 2)
                                userInput.Add(Convert.ToInt32(words[1]));
                        }
                    } while (file_stream.Peek() != -1);

                    if (userInput.Count < 3 || userInput.Count > 3)
                    {
                        throw new FormatException("Not a valid format");
                    }
                    // Save row, column, and numSamples in variables
                    row = userInput[0];
                    column = userInput[1];
                    numSamples = userInput[2];

                    NextForm.Enabled = true;
                    fileName.Text = openFileDialog1.FileName;

                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                    NextForm.Enabled = false;
                }
            }
        }

        private void NextForm_Click(object sender, EventArgs e)
        {
            // Open form for Pick Game
            PickGameForm pickGameForm = new PickGameForm
                                (row, column, numSamples);
            pickGameForm.Show();

            // Hides this form
            this.Hide();
        }
    }

}
