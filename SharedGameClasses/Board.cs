using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedGameClasses {
    /// <summary>
    /// Models a game board consisting of different types of squares
    /// </summary>
    public class Board {

        public const int NUMBER_OF_SQUARES = 40;  // Value doesn't include start or finish squares.
        public const int START_SQUARE_NUMBER = 0;
        public const int FINISH_SQUARE_NUMBER = NUMBER_OF_SQUARES + 1;

        private Square[] squares = new Square[NUMBER_OF_SQUARES + 2];  // The array of squares.
        public Square[] Squares {
            get {
                return squares;
            }
        }

        public Square StartSquare {
            get {
                return squares[START_SQUARE_NUMBER];
            }
        }
     
        /// <summary>
        /// Parameterless Constructor
        /// Initialises a board consisting of a mix of Ordinary Squares,
        ///     Bad Investment Squares and Lottery Win Squares.
        /// The board has two 'non-board' squares:
        ///     a start square; and
        ///     a finish square.
        ///     This is to comply with the Hare and Tortoise requirements.
        /// The start square is to be used for initialisation, play is not yet on the board.
        /// The finish square is to be used for termination, players cannot move past this square.
        /// Pre:  none
        /// Post: board is constructed
        /// </summary>
        public Board() {

            //fill all squares
            for (int i = 0; i < squares.Length; i++)
            {
                Square square;
                if (i == START_SQUARE_NUMBER)
                {
                    square = new Square(this,i,"Start");
                }
                else if (i == FINISH_SQUARE_NUMBER)
                {
                    square = new Square(this,i,"Finish");
                }
                else
                {
                    if (i % 10 == 0) //check squre is lotteryWinSquare
                    {
                        square = new LotteryWinSquare(this, i, (i + 1).ToString());
                    }
                    else
                    {
                        if (i % 5 == 0) //check sqare is lose
                        {
                            square = new BadInvestmentSquare(this, i, (i + 1).ToString());
                        }
                        else
                        {
                            square = new Square(this, i, (i + 1).ToString());
                        }
                    }
                    
                }
                squares[i] = square;
            }

        } // end Board
    } //end class Board
}