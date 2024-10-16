/*************************************************
* Caitlin Allison and Jered Stevens
* 4143 - Stringfellow
* 
* AnalyzerClasses.cs
* Temporary file. Used to create and test the 
*  analyzer classes. Will be moved into a
*  class library file to be used as a .dll
*  once completed.
*************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlayAnalyzerGame

{
    /*************************************************
     * Class:           Sample
     * 
     * Description: Holds an X and Y coordinate to be
     *                  used with the analyzer classes.
     *                  
     *              Defaults to X and Y equal to -1.
     *                  Parameterized constructor takes
     *                  two integers to assign a value
     *                  to X and Y.
     *                  
     * Author:      Jered Stevens
     *************************************************/

    public class Sample
    {
        private int x;
        private int y;
        private bool found;

        public Sample()
        {
            this.x = -1;
            this.y = -1;
        }
        public Sample(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get => x;
            set => x = value;
        }
        public int Y
        {
            get => y;
            set => y = value;
        }
        public bool Found
        {
            get => found;
            set => found = value;
        }
        public override string ToString()
        {
            string val = "(" + x.ToString() + ", " + y.ToString() + ") - ";
            if (Found)
            {
                val += "Found";
            }
            else
            {
                val += "Not Found";
            }
            return val;
        }
    }



    /*******************************************************************
    * Class:           Analyzer
    * 
    * Description: Base class for other child analyzer classes. Holds
    *                  vars for the number of rows and columns available,
    *                  contains a 2D array of chars for the grid, the 
    *                  Random var, 2 Samples, and a 2 bools to indicate 
    *                  if either sample has been found yet.
    * 
    * Public Data Members:
    *              int Rows
    *              int Columns
    *              int RemainingGuesses
    * 
    * Functions:   EvaluateGuess
    *                  Accepts 3 ints: row, column, guessCounter.
    *                  Returns bool.
    *                  Evaluates if the users guess is correct and 
    *                  returns a corresponding bool.
    *                 
    *              ToString
    *                  Returns string
    *                  Provides the game grid
    *                  
    *              ResetRemainingGuesses
    *                  Returns void
    *                  Resets remaining guesses to initial value
    *                  
    * Author:      Jered Stevens
    *********************************************************************/



    public abstract class Analyzer
    {
        private int rows;
        private int columns;
        public char[,] grid;
        public Random rand;

        private int remainingGuesses;
        public List<Sample> samplesArr;

        public int Rows
        {
            get => rows;
            set => rows = value;
        }
        public int Columns
        {
            get => columns;
            set => columns = value;
        }
        public int RemainingGuesses
        {
            get => remainingGuesses;
            set
            {
                remainingGuesses = value;
            }
        }



        public Analyzer()
        {
            samplesArr = new List<Sample>();
            rand = new Random();
            GenerateSamples();
            ResetRemainingGuesses();
        } // Analyzer




        // Method to generate two samples with random coordinates
        public void GenerateSamples()
        {
            for (int i = 0; i < 2; i++)
            {
                // Create a new Sample and add it to samplesArr
                samplesArr.Add(new Sample());
            }

            // Generate samples to go in sample list
            for (int i = 0; i < 2; i++)
            {
                bool isDuplicate;

                do
                {
                    // Generate random coordinates for sample
                    samplesArr[i].X = rand.Next(0, Columns);
                    samplesArr[i].Y = rand.Next(0, Rows);

                    isDuplicate = false;

                    // Compare all previous samples
                    for (int j = 0; j < i; j++)
                    {
                        if (samplesArr[i].X == samplesArr[j].X && samplesArr[i].Y == samplesArr[j].Y)
                        {
                            isDuplicate = true;  // A duplicate was found
                            break;  // Exit the inner loop and get new coordinates
                        }
                    }

                } while (isDuplicate);  // Repeat until unique coordinates are found
            }
        } //generateSamples()




        // Method to generate two samples with random coordinates
        public void GenerateSamples(int numSamples)
        {
            for (int i = 0; i < numSamples; i++)
            {
                // Create a new Sample and add it to samplesArr
                samplesArr.Add(new Sample());
            }

            // Generate samples to go in sample list
            for (int i = 0; i < numSamples; i++)
            {
                bool isDuplicate;

                do
                {
                    // Generate random coordinates for sample
                    samplesArr[i].X = rand.Next(0, Columns);
                    samplesArr[i].Y = rand.Next(0, Rows);

                    isDuplicate = false;

                    // Compare all previous samples
                    for (int j = 0; j < i; j++)
                    {
                        if (samplesArr[i].X == samplesArr[j].X && samplesArr[i].Y == samplesArr[j].Y)
                        {
                            isDuplicate = true;  // A duplicate was found
                            break;  // Exit the inner loop and get new coordinates
                        }
                    }

                } while (isDuplicate);  // Repeat until unique coordinates are found
            }
        } //generateSamples(int)




        // Can be overriden should the child class
        // need to display things differently
        public override string ToString()
        {
            // initialize a string to put grid in
            string StringGrid = string.Empty;

            // Blank space for alignment with columns
            StringGrid += "  ";

            // Print numbers along top of grid
            for (int i = 0; i < columns; i++)
            {
                StringGrid += i;
            }
            StringGrid += "\n";

            // Print row numbers, followed by contents
            //  of the grid
            for (int i = 0; i < rows; i++)
            {
                StringGrid += i + " ";
                for (int j = 0; j < columns; j++)
                {
                    StringGrid += grid[i, j];
                }
                StringGrid += "\n";
            }

            return StringGrid;
        } // ToString





        // Resets Remaining guesses 
        public virtual void ResetRemainingGuesses()
        {
            RemainingGuesses = 25;
        } // ResetRemainingGuesses()



        public Sample FindNearestUnfoundSample(int row, int col)
        {
            Sample nearestSample = null;
            int minDistance = int.MaxValue;

            foreach (Sample sample in samplesArr)
            {
                if (!sample.Found)
                {
                    // Calculate Manhattan distance between guess and sample
                    int distance = Math.Abs(sample.X - row) + Math.Abs(sample.Y - col);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestSample = sample;
                    }
                }
            }

            return nearestSample;
        }


        // All the derived classes must implement this and handle it
        // in their specific ways
        public abstract bool EvaluateGuess(int col, int row, int guessCounter);
    
    } // Analyzer



    public class HairAnalyzer : Analyzer
    {
        public HairAnalyzer()
        {
            // New random number generator
            rand = new Random();

            // Set grid dimensions to 10x10
            this.Rows = 10;
            this.Columns = 10;

            grid = new char[Rows, Columns];

            // populate grid with ~
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    grid[i, j] = '~';
                }
            }

        } // HairAnalyzer()


        /*********************************************************
        * Function:        EvaluateGuess
        * Returns:         bool
        * Params:          int col, int row, int guessCounter
        * 
        * Decription:      Takes in 2 ints from user and compares them to the
        *                      grid in order to determine if the guess was 
        *                      correct or not. If the guess is incorrect,
        *                      the third int is used to determin if the next
        *                      hint is a vertical or horizontal hint.
        *                  If the guess is correct, it returns true, and marks
        *                      the corresponding sample to be found.
        *                  If the guess is incorrect, it updates the grid to 
        *                      show the correct hint and returns false.
        *                      
        * Author:          Jered Stevens
        **********************************************************/

        public override bool EvaluateGuess(int row, int col, int guessCounter)
        {
            bool foundMatch = false;  // Flag to check if any sample is found

            // Iterate over all samples in the list
            for (int i = 0; i < samplesArr.Count; i++)
            {
                // Check if the guess matches the current sample's coordinates
                if (samplesArr[i].X == row && samplesArr[i].Y == col)
                {
                    // Update the grid to mark the correct guess
                    grid[row, col] = 'H';

                    // Mark the sample as found
                    samplesArr[i].Found = true;
                    foundMatch = true;
                    break;  // No need to continue checking if a match is found
                }
            }

            // If no match was found, provide a hint
            if (!foundMatch)
            {
                bool isHorizontalHint = guessCounter % 2 == 0;

                // Provide hints based on the closest sample that hasn't been found yet
                Sample nearestSample = FindNearestUnfoundSample(row, col);

                if (isHorizontalHint && nearestSample.Y == col)
                {
                    // If the nearest sample is directly above or below the guess
                    grid[row, col] = '|';
                }
                else if (isHorizontalHint)
                {
                    // Provide left or right hint
                    grid[row, col] = (nearestSample.Y > col) ? '>' : '<';
                }
                else if (!isHorizontalHint && nearestSample.X == row)
                {
                    // If the nearest sample is on the same row
                    grid[row, col] = '-';
                }
                else
                {
                    // Provide up or down hint
                    grid[row, col] = (nearestSample.X > row) ? 'V' : '^';
                }
            }

            return foundMatch;
        }



    } // HairAnalyzer




    /*******************************************************************
   * Class:           DNAAnalyzer
   * 
   * Description: Last game mode analyzer. To be played as 'Hard Mode'
   *                   Inherits from the Analyzer class. Has a default
   *                   constructor that sets rows and columns to 10.
   *                   
   *              Fills grid with '.' and marks correct answers with X.
   *                       
   *                   
   * Author:       Jered Stevens
   *                   
   *********************************************************************/
    public class DNAAnalyzer : HairAnalyzer
    {
        public DNAAnalyzer()
        {
            // New random number generator
            rand = new Random();

            // Set grid dimensions to 10x10
            this.Rows = 10;
            this.Columns = 10;

            grid = new char[Rows, Columns];


            // populate grid with ~
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    grid[i, j] = '.';
                }
            }

        } // DNAAnalyzer


        public override bool EvaluateGuess(int row, int col, int guessCounter)
        {
            bool foundMatch = false;  // Flag to check if any sample is found

            // Iterate over all samples in the list
            for (int i = 0; i < samplesArr.Count; i++)
            {
                // Check if the guess matches the current sample's coordinates
                if (samplesArr[i].X == row && samplesArr[i].Y == col)
                {
                    // Update the grid to mark the correct guess
                    grid[row, col] = 'X';

                    // Mark the sample as found
                    samplesArr[i].Found = true;
                    foundMatch = true;
                    break;  // No need to continue checking if a match is found
                }
            }

            // If no match was found, provide a hint
            if (!foundMatch)
            {
                bool isHorizontalHint = guessCounter % 2 == 0;

                // Provide hints based on the closest sample that hasn't been found yet
                Sample nearestSample = FindNearestUnfoundSample(row, col);

                if (isHorizontalHint && nearestSample.Y == col)
                {
                    // If the nearest sample is directly above or below the guess
                    grid[row, col] = '|';
                }
                else if (isHorizontalHint)
                {
                    // Provide left or right hint
                    grid[row, col] = (nearestSample.Y > col) ? '>' : '<';
                }
                else if (!isHorizontalHint && nearestSample.X == row)
                {
                    // If the nearest sample is on the same row
                    grid[row, col] = '-';
                }
                else
                {
                    // Provide up or down hint
                    grid[row, col] = (nearestSample.X > row) ? 'V' : '^';
                }
            }

            return foundMatch;
        }


        /******************************************************************
         * Function:        ResetRemainingGuesses
         * 
         * Description:     Resets remaining guesses to 10 instead of 25
         *                      because this game mode is the 'Hard mode'
         *                      of the game.
         *       
         * Author:  Jered Stevens
         *******************************************************************/

        public override void ResetRemainingGuesses()
        {
            RemainingGuesses = 10;
        } // ResetRemainingGuesses

    } // DNAAnalyzer
}

