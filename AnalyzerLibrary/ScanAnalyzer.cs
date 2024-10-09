//  Caitlin Allison
//  Program 4
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caitlin_Allison_4
{
    public class ScanAnalyzer
    {
        private int row, col;
        private char[][] grid;
        private int[][] clues;              // Holds (x,y) for the 2 clues
        private bool firstFound, endOfGame;
        private int guessCounter;

        public ScanAnalyzer(int row, int col)
        {
            // Initialize the variables
            guessCounter = 0;
            firstFound = false;
            endOfGame = false;

            this.row = row;
            this.col = col;
            grid = new char[row][];

            clues = new int[2][];
            for (int i = 0; i < 2; i++)
            {
                clues[i] = new int[2];
            }


            for (int i = 0; i < row; i++)
            {
                grid[i] = new char[col];
            }

            // Sets the Grid to ~
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    grid[i][j] = '~';
                }
            }

            int pos = 0;

            // Keep creating a random (x,y) until it is original set
            do
            {
                int x = new Random().Next(0, row);
                int y = new Random().Next(0, col);

                if (clues[0][0] != x || clues[0][1] != y)
                {
                    clues[pos][0] = x;
                    clues[pos][1] = y;

                    pos++;
                }
            } while (pos < 2);
        }

        // DisplayGrid
        // Returns a toString version of grid
        public string DisplayGrid()
        {
            string headingText = " ";
            string gridText = "";

            for (int i = 0; i < grid.Length; i++)
            {
                gridText += i.ToString();
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (i == 0)
                        headingText += j.ToString();
                    gridText += grid[i][j].ToString();
                }
                gridText += "\r\n";
            }
            gridText = headingText + "\r\n" + gridText;
            return gridText;
        }

        // clearGridOfGuesses
        // Goes through Grid and clears it of an symbol that is not X or ~
        internal void ClearGridOfGuesses()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] != '~' && grid[i][j] != 'X')
                    {
                        grid[i][j] = '~';
                    }
                }
            }
        }
        
        // EvaluateGuess
        // Takes in an (x,y) pair of ints
        // Returns if the pair was an exact mach to a clue. 
        // -Goes through the grid if it is not a match and gives a hint to
        // where the clue is in relation to the guess coordinates.
        // -Every odd guess fills the coordinate with >, <, or - and even guess 
        // fills the coordinate with ^, V, or -.
        // -If both clues are found, displays a MessageBox saying the user
        // has won.
        internal bool EvaluateGuess(int x, int y)
        {
            guessCounter++;
            bool found = false;
            int[] pair = new int[2];
            // Either looks for the first or second clue
            int pos = firstFound ? 1 : 0;

            pair[0] = clues[pos][0];
            pair[1] = clues[pos][1];

            if (pair[0] == x && pair[1] == y)
            {
                grid[x][y] = 'X';
                found = true;
               
                if (!firstFound)
                {
                    firstFound = true;
                }
                else
                {
                    endOfGame = true;
                }
            }
            if (!found)
            {
                char symbol;
                if (guessCounter % 2 == 0)
                {
                    if (x == pair[0])
                    {
                        symbol = pair[1] > y ? '>' : '<';
                    }
                    else symbol =  pair[0] > x ? 'V': '^';
                }
                else
                {
                    if (y == pair[1])
                    {
                        symbol = pair[0] > x ? 'V' : '^';
                    }
                    else symbol = pair[1] > y ? '>' : '<';
                }
                grid[x][y] = symbol;
            }
            else
            {
                if(endOfGame)
                {
                    string message = "Congrats!\nYou have completed the game in " + guessCounter + " guesses";
                    MessageBox.Show(message, "SUCCESS", MessageBoxButtons.OK);
                }

            }
            return found;
        }

        // ShowAnswers
        // Returns the toString version of the grid with the answers
        // revealed
        public string ShowAnswers()
        {
            string headingText = " ";
            string gridText = "";

            for (int i = 0; i < grid.Length; i++)
            {
                gridText += i.ToString();
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (i == 0)
                        headingText += j.ToString();
                    if (
                        (i == clues[0][0] && j == clues[0][1]) ||
                        (i == clues[1][0] && j == clues[1][1])
                        )
                        gridText += 'X';
                    else    
                        gridText += '~';

                }
                gridText += "\r\n";
            }
            gridText = headingText + "\r\n" + gridText;
            return gridText;
        }

        // isEndoOfGame
        // returns the value of endOfGame
        internal bool isEndOfGame()
        {
            return endOfGame;
        }

        // getGuessCounter
        // returns the value of guessCounter in string format
        internal string getGuessCounter()
        {
            return guessCounter.ToString();
        }
    };

}
