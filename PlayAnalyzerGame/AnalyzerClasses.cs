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
        public override string ToString()
        {
            return "(" + x.ToString() + ", " + y.ToString() + ")";
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
     *              int Columns
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
     * Author:      Jered Stevens
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

        /*********************************************************************************
         * Not sure why we needed this?
         ********************************************************************************/

        //// Constructor for scanalyzer
        //public Analyzer(int rows, int columns)
        //{
        //    // Make new random number generator
        //    rand = new Random();

        //    // Set rows and columns to user defined numbers
        //    this.rows = rows;
        //    this.columns = columns;

        //    // Make a grid the size of rows and columns
        //    grid = new char[rows, columns];

        //    // Set coordinates for the samples within the grid
        //    sample1.X = rand.Next(0, columns);
        //    sample1.Y = rand.Next(0, rows);


        //    // If the samples are in the same place, 
        //    //  get new coordinates for sample
        //    do
        //    {
        //        sample2.X = rand.Next(0, columns);
        //        sample2.Y = rand.Next(0, rows);
        //    } while (sample1.X == sample2.X && sample1.Y == sample2.Y);

        //    // populate grid with ~
        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < columns; j++)
        //        {
        //            grid[i, j] = '~';
        //        }
        //    }

        //    guessCounter = 0;

        //}//Analyzer


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

        // All the derived classes must implement this and handle it
        // in their specific ways
        public abstract bool EvaluateGuess(int col, int row, int guessCounter);

    }

    /*******************************************************************
    * Class:           HairAnalyzer
    * 
    * Description: First game mode analyzer. Inherits from the Analyzer
    *                   class. Has a default constructor that sets rows
    *                   and columns to 10.
    *                   
    * Author:       Jered Stevens
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
            // If guess counter is even, then its a horizontal hint
            bool isHorizontalHint = guessCounter % 2 == 0;


            // Guess matches either samples, mark it found and set corresponding bool to true
            if ((sample1.X == row && sample1.Y == col) || (sample2.X == row && sample2.Y == col))
            {
                // Update Grid
                grid[row, col] = 'H';

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

    public class DNAAnalyzer : Analyzer
    {
        public DNAAnalyzer()
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

        }
        public override bool EvaluateGuess(int row, int col, int guessCounter)
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
            
        }
    } // DNAAnalyzer


    // Commented this out bc it wouldn't compile

    //public class PrintAnalyzer : Analyzer
    //{
    //    int numOfFingerprints;
    //    int[][2] fingerprints;
    //    bool * foundFingerprints;
    //    bool endOfGame;

    //    PrintAnalyzer(int rows, int columns)
    //    {
    //        // Make new random number generator
    //        rand = new Random();

    //        // Set rows and columns to user defined numbers
    //        this.rows = rows;
    //        this.columns = columns;

    //        // Make a grid the size of rows and columns
    //        grid = new char[rows, columns];

    //        numOfFingerprints = rand.Next(0, columns * rows);

    //        int i = 0;

    //        // Continues to create an unique x && y pair
    //        // for fingerprints until the array is filled.
    //        do
    //        {
    //            int x = new Random().Next(0, row);
    //            int y = new Random().Next(0, col);

    //            if (i == 0)
    //            {
    //                fingerprints[0][0] = x;
    //                fingerprints[0][1] = y;
    //            }
    //            else ()
    //            {
    //                bool match = false;

    //                // Loops through existing fingerprints
    //                // to verify x && y is not already within
    //                // the array
    //                for (int j = 0; j < i; j++)
    //                {
    //                    if (x == fingerprints[j][0] && y == fingerprints[j][1])
    //                        match = true;
    //                }
    //                if (!match)
    //                {
    //                    fingerprints[pos][0] = x;
    //                    fingerprints[pos][1] = y;

    //                    i++;
    //                }
    //            }

    //        } while (i < numOfFingerprints);

    //        // populate grid with ~
    //        for (int i = 0; i < rows; i++)
    //        {
    //            for (int j = 0; j < columns; j++)
    //            {
    //                grid[i, j] = '~';
    //            }
    //        }

    //        foundFingerprints = new bool [numOfFingerprints];

    //        endOfGame = false;
    //        guessCounter = 0;
    //    }

    //Check if guess is correct
//    public override bool EvaluateGuess(int col, int row, int guessCounter)
//    {
//        // If guess counter is even, then its a horizontal hint
//        bool isHorizontalHint = guessCounter % 2 == 0;

//        bool exactMatch = false;
//        int matchPos = -1;

//        int i = 0;

//        int numFoundFingerprints = 0;
//        // Loops through fingerprints and finds if there is an exact
//        // match. Ignores previously found fingerprints
//        do
//        {
//            if (foundFingerprints[i] == false)
//            {
//                if (fingerprints[i][0] == row && fingerprints[i][1] == col)
//                {
//                    exactMatch = true;
//                    matchPos = i;
//                    foundFingerprints[i] = true;
//                    grid[row][col] = '@';
//                    if (numFoundFingerprints == numOfFingerprints)
//                    {
//                        endOfGame = true;
//                    }
//                }
//            }
//            else
//            {
//                numFoundFingerprints++;
//            }
//            i++;
//        }
//        while (i < numOfFingerprints && !exactMatch);


//        // If first sample isnt found yet
//        if (!exactMatch)
//        {
//            // Grabs the i index of the closest index
//            int closetFingerprintPs = findClosestFingerprint(row, col);
//            int closestX = fingerprints[closetFingerprintPs][0];
//            int closestY = fingerprints[closetFingerprintPs][1];

//            // If sample is directly above or below guess
//            if (isHorizontalHint)
//            {
//                grid[row, col] = isHorizontalHint ?
//                    col == closestY ? '|' :
//                    closestY > col ? '>' : '<';
//            }
//            else
//            {
//                grid[row, col] = row == closestX ? '|' :
//                    closestX > row ? 'V' : '^';
//            }
//        }

//        guessCounter++;

//        return false;
//    } // EvaluateGuess

//    // Dynamically finds closest fingerprints
//    int findClosestFingerprint(int row, int col)
//    {
//        int position = 0;

//        int minimum = Math.Abs(fingerprints[0][0] * fingerprints[0][1] - row * col);

//        for (int i = 0; i < numOfFingerprints; i++)
//        {
//            if (!foundFingerprints[i])
//            {
//                if ((int)Math.Abs(fingerprints[i][0] * fingerprints[i][1] - row * col) < minimum)
//                {
//                    position = i;
//                    minimum = (int)Math.Abs(fingerprints[i][0] * fingerprints[i][1] - row * col);
//                }

//            }
//        }

//        return position;
//    }
//}
}
