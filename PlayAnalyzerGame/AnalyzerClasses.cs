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
            set { y = value; }
        }
        public int Y
        {
            get => y;
            set { y = value; }
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
     *********************************************************************/
    
    public abstract class Analyzer
    {
        public int rows;
        public int columns;
        public char[,] grid;
        public Random rand;
        public Sample sample1;
        public Sample sample2;
        public bool isFirstSampleFound;
        public bool isSecondSampleFound;

    }

    public class HairAnalyzer : Analyzer
    {
  
    }

    public class BloodAnalyzer : Analyzer 
    {
        
    }

    public class DNAAnalyzer : Analyzer
    {

    }
}
