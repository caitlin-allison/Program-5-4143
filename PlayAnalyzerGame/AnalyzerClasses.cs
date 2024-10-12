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
     *************************************************/

    public class Sample
    {
        private int x;
        private int y;

        public Sample()
        {
            int x = -1;
            int y = -1;
        }
        public Sample(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get => x;
            set => y = value;
        }
        public int Y
        {
            get => y;
            set => y = value;
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
     * Data Members:
     *              int Rows
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
     *********************************************************************/
    
    public abstract class Analyzer
    {
        private int rows;
        private int columns;
        public char[,] grid;
        public Random rand;
        public Sample sample1;
        public Sample sample2;
        private bool isFirstSampleFound;
        private bool isSecondSampleFound;

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
        public bool IsFirstSampleFound
        {
            get => isFirstSampleFound;
            set => isFirstSampleFound = value;
        }
        public bool IsSecondSampleFound
        {
            get => isSecondSampleFound;
            set => isSecondSampleFound = value;
        }
        

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


        // Check if guess is correct
        public bool EvaluateGuess(int col, int row, int guessCounter)
        {
            // If guess counter is even, then its a horizontal hint
            bool isHorizontalHint = guessCounter % 2 == 0;
      

            // Guess matches either samples, mark it found and set corresponding bool to true
            if ((sample1.X == row && sample1.Y == col) || (sample2.X == row && sample2.Y == col))
            {
                // Update Grid
                grid[row, col] = 'X';

                // Mark correct sample found
                if (sample1.X == row && sample1.Y == col)
                {
                    IsFirstSampleFound = true;
                }
                else
                {
                    IsSecondSampleFound = true;
                }
                return true;
            }

            // If first sample isnt found yet
            if (!IsFirstSampleFound)
            {
                // If sample is directly above or below guess
                if (isHorizontalHint && sample1.Y == col)
                {
                    grid[row, col] = '|';
                }
                else if (isHorizontalHint)
                {
                    // Provide left or right hint
                    grid[row, col] = (sample1.Y > col) ? '>' : '<';
                }
                else if (!isHorizontalHint && sample1.X == row)
                {
                    // if sample is vertically equal with guess
                    grid[row, col] = '-';
                }
                else
                {
                    grid[row, col] = (sample1.X > row) ? 'V' : '^';
                }
            }
            else
            {
                if (isHorizontalHint && sample2.Y == col)
                {
                    // If sample is directly above or below guess
                    grid[row, col] = '|';
                }
                else if (isHorizontalHint)
                {
                    // Provide left or right hint
                    grid[row, col] = (sample2.Y > col) ? '>' : '<';
                }
                else if (!isHorizontalHint && sample2.X == row)
                {
                    // if sample is vertically equal with guess
                    grid[row, col] = '-';
                }
                else
                {
                    grid[row, col] = (sample2.X > row) ? 'V' : '^';
                }
            }
            return false;
        } // EvaluateGuess

    }

    /*******************************************************************
    * Class:           HairAnalyzer
    * 
    * Description: First game mode analyzer. Inherits from the Analyzer
    *                   class. Has a default constructor that sets rows
    *                   and columns to 10.
    *                   
    *********************************************************************/

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

            sample1 = new Sample();
            sample2 = new Sample();

            // Set coordinates for sample 1 x.
            // x value is determined by which column
            //      its in. y value is determined by
            //      which row its in.
            sample1.X = rand.Next(0, Columns);
            sample1.Y = rand.Next(0, Rows);

            // If the samples are in the same place, 
            //  get new coordinates for sample
            do
            {
                sample2.X = rand.Next(0, Columns);
                sample2.Y = rand.Next(0, Rows);
            } while (sample1.X == sample2.X && sample1.Y == sample2.Y);

            // populate grid with ~
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    grid[i, j] = '~';
                }
            }

        } // HairAnalyzer()
  
    }

    public class BloodAnalyzer : Analyzer 
    {
        public BloodAnalyzer() 
        { 
        
        }
    }

    public class DNAAnalyzer : Analyzer
    {
        public DNAAnalyzer()
        {

        }
    }
}
