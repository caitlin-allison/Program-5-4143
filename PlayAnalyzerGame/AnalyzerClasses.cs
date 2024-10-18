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
    /**********************************************************
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
     ***********************************************************/

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
    *                  
    * Author:      Jered Stevens
    *********************************************************************/



    public abstract class Analyzer
    {
        private int rows;
        private int columns;
        public char[,] grid;
        public Random rand;

        public List<Sample> samples;
        private int guessCounter; 
        private int numOfSamplesFound;
        private int sampleNum; 
        bool endOfGame;

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
        public int GuessCounter
        {
            get => guessCounter;
            set => guessCounter = value;
        }
        public bool EndOfGame
        {
            get => endOfGame;
            set => endOfGame = value;
        }
        public int NumOfSamplesFound
        {
            get => numOfSamplesFound;
            set => numOfSamplesFound = value;
        }
        public int SampleNum
        {
            get => sampleNum;
            set => sampleNum = value;
        }
        
        

        public Analyzer(int rows, int columns, int numSamples)
        {
            Rows = rows;
            Columns = columns;
            GuessCounter = 0;
            EndOfGame = false;
            NumOfSamplesFound = 0;
            SampleNum = numSamples;
            grid = new char[rows, columns];
            samples = new List<Sample>();
            rand = new Random();

            GenerateSamples(SampleNum);
        } // Analyzer



        // Method to generate two samples with random coordinates
        public void GenerateSamples(int numSamples)
        {
            for (int i = 0; i < numSamples; i++)
            {
                // Create a new Sample and add it to samplesArr
                samples.Add(new Sample());
            }

            // Generate samples to go in sample list
            for (int i = 0; i < numSamples; i++)
            {
                bool isDuplicate;

                do
                {
                    // Generate random coordinates for sample
                    samples[i].X = rand.Next(0, Columns);
                    samples[i].Y = rand.Next(0, Rows);

                    isDuplicate = false;

                    // Compare all previous samples
                    for (int j = 0; j < i; j++)
                    {
                        if (samples[i].X == samples[j].X && samples[i].Y == samples[j].Y)
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




        public Sample FindNearestUnfoundSample(int row, int col)
        {
            Sample nearestSample = null;
            int minDistance = int.MaxValue;

            foreach (Sample sample in samples)
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
        public abstract bool EvaluateGuess(int col, int row);
    
    } // Analyzer



    public class HairAnalyzer : Analyzer
    {
        public HairAnalyzer(int rows, int columns, int sampleNum) : base(rows, columns, sampleNum)
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

        public override bool EvaluateGuess(int row, int col)
        {
            GuessCounter++;
            bool foundMatch = false;  // Flag to check if any sample is found

            // Iterate over all samples in the list
            for (int i = 0; i < samples.Count; i++)
            {
                // Check if the guess matches the current sample's coordinates
                if (samples[i].X == row && samples[i].Y == col)
                {
                    // Update the grid to mark the correct guess
                    grid[row, col] = 'H';

                    // Mark the sample as found
                    samples[i].Found = true;
                    foundMatch = true;
                    break;  // No need to continue checking if a match is found
                }
            }

            // If no match was found, provide a hint
            if (!foundMatch)
            {
                bool isHorizontalHint = GuessCounter % 2 == 0;

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

            bool flag = true;

            foreach (Sample sample in samples)
            {
                if (!sample.Found){
                    flag = false;
                }
            }

            EndOfGame = flag;

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
        int remainingGuesses;

        int RemainingGuesses
        {
            get => remainingGuesses;
            set => remainingGuesses = value;
        }

        public DNAAnalyzer(int rows, int columns, int sampleNum) : base(rows, columns, sampleNum)
        {
            RemainingGuesses = 10;

            // populate grid with .
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    grid[i, j] = '.';
                }
            }
        } // DNAAnalyzer


        public override bool EvaluateGuess(int row, int col)
        {
            GuessCounter++;
            bool foundMatch = false;  // Flag to check if any sample is found

            // Iterate over all samples in the list
            for (int i = 0; i < samples.Count; i++)
            {
                // Check if the guess matches the current sample's coordinates
                if (samples[i].X == row && samples[i].Y == col)
                {
                    // Update the grid to mark the correct guess
                    grid[row, col] = 'X';

                    // Mark the sample as found
                    samples[i].Found = true;
                    foundMatch = true;
                    break;  // No need to continue checking if a match is found
                }
            }

            // If no match was found, provide a hint
            if (!foundMatch)
            {
                bool isHorizontalHint = GuessCounter % 2 == 0;

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

            bool flag = true;

            foreach (Sample sample in samples)
            {
                if (!sample.Found){
                    flag = false;
                }
            }

            EndOfGame = flag;

            return foundMatch;
        }


    } // DNAAnalyzer



    public class PrintAnalyzer : Analyzer
    {
        int numOfFingerprints;
        int[,] fingerprints;
        bool[] foundFingerprints;
        

        public PrintAnalyzer(int rows, int columns, int sampleNum) : base(rows, columns, sampleNum)
        {
            numOfFingerprints = rand.Next(0, columns * rows);

            fingerprints = new int[numOfFingerprints, 2];

            int pos = 0;

            // Continues to create an unique x && y pair
            // for fingerprints until the array is filled.
            do
            {
                int x = new Random().Next(0, rows);
                int y = new Random().Next(0, columns);

                if (pos == 0)
                {
                    fingerprints[0, 0] = x;
                    fingerprints[0, 1] = y;
                }
                else
                {
                    bool match = false;

                    // Loops through existing fingerprints
                    // to verify x && y is not already within
                    // the array
                    for (int j = 0; j < pos; j++)
                    {
                        if (x == fingerprints[j, 0] && y == fingerprints[j, 1])
                            match = true;
                    }
                    if (!match)
                    {
                        fingerprints[pos, 0] = x;
                        fingerprints[pos, 1] = y;

                        pos++;
                    }
                }

            } while (pos < numOfFingerprints);

            // populate grid with ~
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    grid[r, c] = '~';
                }
            }

            foundFingerprints = new bool[numOfFingerprints];

            EndOfGame = false;
            GuessCounter = 0;
        }

        //Check if guess is correct
        public override bool EvaluateGuess(int col, int row)
        {
            GuessCounter++;
            // If guess counter is even, then its a horizontal hint
            bool isHorizontalHint = GuessCounter % 2 == 0;

            bool exactMatch = false;
            int matchPos = -1;

            int i = 0;

            int numFoundFingerprints = 0;
            // Loops through fingerprints and finds if there is an exact
            // match. Ignores previously found fingerprints
            do
            {
                if (foundFingerprints[i] == false)
                {
                    if (fingerprints[i, 0] == row && fingerprints[i, 1] == col)
                    {
                        exactMatch = true;
                        matchPos = i;
                        foundFingerprints[i] = true;
                        grid[row, col] = '@';
                        if (numFoundFingerprints == numOfFingerprints)
                        {
                            EndOfGame = true;
                        }
                    }
                }
                else
                {
                    numFoundFingerprints++;
                }
                i++;
            }
            while (i < numOfFingerprints && !exactMatch);


            // If first sample isnt found yet
            if (!exactMatch)
            {
                // Grabs the i index of the closest index
                int closetFingerprintPs = findClosestFingerprint(row, col);
                int closestX = fingerprints[closetFingerprintPs, 0];
                int closestY = fingerprints[closetFingerprintPs, 1];

                // If sample is directly above or below guess
                if (isHorizontalHint)
                {
                    grid[row, col] = col == closestY ? '|' :
                        closestY > col ? '>' : '<';
                }
                else
                {
                    grid[row, col] = row == closestX ? '|' :
                        closestX > row ? 'V' : '^';
                }
            }

            bool flag = true;

            foreach (Sample sample in samples)
            {
                if (!sample.Found){
                    flag = false;
                }
            }

            EndOfGame = flag;

            return exactMatch;
        } // EvaluateGuess

        // Dynamically finds closest fingerprints
        int findClosestFingerprint(int row, int col)
        {
            int position = 0;

            int minimum = Math.Abs(fingerprints[0, 0] * fingerprints[0, 1] - row * col);

            for (int i = 0; i < numOfFingerprints; i++)
            {
                if (!foundFingerprints[i])
                {
                    if ((int)Math.Abs(fingerprints[i, 0] * fingerprints[i, 1] - row * col) < minimum)
                    {
                        position = i;
                        minimum = (int)Math.Abs(fingerprints[i, 0] * fingerprints[i, 1] - row * col);
                    }

                }
            }

            return position;
        }
    }
}