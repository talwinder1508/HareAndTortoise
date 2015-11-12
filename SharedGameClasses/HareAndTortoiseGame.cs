using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.ComponentModel;  // for BindingList.

namespace SharedGameClasses {
    /// <summary>
    /// Plays the game
    /// </summary>
    public class HareAndTortoiseGame {

        private Board board;
        public Board Board {
            get {
                return board;
            }
        }

        private Die die1, die2;

        public int Die1Value
        {
            get { return die1.FaceValue; }
        }

        public int Die2Vlue 
		{ 
		get { return die2.FaceValue; } 
		}

        public bool IsFinish 
        { 
            get 
            {
                foreach (var player in players)
                {
                    if (player.Location.IsFinish())
                    {
                        return true;
                    }
                }
                return false;
            } 
        }

        private int playingPlayerPosition;

        public Player CurrentPlayer
        {
            get { return players[playingPlayerPosition]; }
        }

        // A BindingList is like an array that can grow and shrink. 
        // 
        // Using a BindingList will make it easier to implement the GUI with a DataGridView
        private BindingList<Player> players = new BindingList<Player>();
        public BindingList<Player> Players {
            get {
                return players;
            }
        }

        // Minimum and maximum players.
        private const int MIN_PLAYERS = 2;
        public const int MAX_PLAYERS = 6;

        private int numberOfPlayers = 2;  // The value 2 is purely to avoid compiler errors.

        public int NumberOfPlayers {
            get {
                return numberOfPlayers;
            }
            set {
                numberOfPlayers = value;
            }
        }

        // Is the current game finished?
        private bool finished = false;
        public bool Finished {
            get {
                return finished;
            }
        }

        // Some player names.  In the Console game, these are purely for testing purposes.
        // These values are intended to be read-only.  I.e. the program code should never update this array.
        private string[] defaultNames = { "One", "Two", "Three", "Four", "Five", "Six" };

        // Some colours for the players' tokens (or "pieces"). 
        // These are not used in the Console version of the game, but will be important in the GUI version.
        Brush[] playerTokenColours = new Brush[MAX_PLAYERS] { Brushes.Black, Brushes.Red, 
                                                              Brushes.Gold, Brushes.GreenYellow, 
                                                              Brushes.Fuchsia, Brushes.White };

        /// <summary>
        /// Parameterless Constructor.
        /// Initialise the board, and the two dice.
        /// Pre:  none
        /// Post: the board and the objects it conatins are initialised.
        /// </summary>
        public HareAndTortoiseGame(Board gameBoard) {
            this.board = gameBoard;
            die1 = new Die();
            die2 = new Die();

        } //end Game

        
        /// <summary>
        /// Resets the game, including putting all the players on the Start square.
        /// Pre:  none.
        /// Post: the game is reset as though it is being played for the first time.
    
        /// </summary>
        public void SetPlayersAtTheStart() {
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                player.Money = 100;
                player.Name = defaultNames[i];
                player.PlayerTokenColour = playerTokenColours[i];
                player.Location = board.Squares[0];
            }
            playingPlayerPosition = 0;

        } // end SetPlayersAtTheStart

        /// <summary>
        /// Initialises each of the players and adds them to the players BindingList.
        /// This method is to be called only once, when the game first starts.
        /// 
        /// Pre:  none.
        /// Post: the game's players are initialised.
        /// </summary>
        public void InitialiseAllThePlayers() {
            players.Clear();
            for (int i = 0; i < numberOfPlayers; i++)
			{
			    Player player = new Player();
                player.Money = 100;
                player.Name = defaultNames[i];
                player.PlayerTokenColour = playerTokenColours[i];
                player.Location = board.Squares[0];
                players.Add(player);
            }

        } // end InitialiseAllThePlayers

        //################## Game Play Methods above this line

        /// <summary>
        /// This method demonstrate how the WriteLine of ListBoxTraceListener can be used
        ///  to output to the ListBox for debugging purposes.
        ///  
        /// Outputs a player's current location and amount of money
        ///  to 
        /// pre:  player's object to display
        /// post: displayed the player's location and amount
        /// </summary>
        /// <param name="who">the player to display</param>
        public static void OutputIndividualDetails(Player who) {

            Trace.WriteLine(String.Format("Player {0} is on square {1} with {2:c}",
                             who.Name, who.Location.Name, who.Money));

        } //end OutputIndividualDetails


        /// <summary>
        /// This method demonstrate the player play as roll dices
        /// This make 2 dices roll and give new random result
        /// </summary>
        /// <param name="who">the player to display</param>
        public void PlayRoll()
        {
            Player CurrentPlayer = Players[playingPlayerPosition];
            CurrentPlayer.Play(die1, die2);
        }

        /// <summary>
        /// This method demonstrate how is player move from old square to new square
        /// Make effect att all
        /// </summary>
        public void PlayerMove()
        {
            Player CurrentPlayer = Players[playingPlayerPosition];
            CurrentPlayer.Move(die1.FaceValue + die2.FaceValue);
            CurrentPlayer.Location.LandOn(CurrentPlayer);
            UpdateWinner();
            playingPlayerPosition = NextPlayerPosition();
        }

        /// <summary>
        /// This method demonstrate game set next player
        /// </summary>
        private int NextPlayerPosition()
        {
            if(playingPlayerPosition==(Players.Count-1))
            {
                return 0;
            }else
            {
                return playingPlayerPosition+1;
            }
        }

        /// <summary>
        /// This method will update winner for game
        /// </summary>
        private void UpdateWinner()
        {
            Player winner =  players.OrderByDescending(s => s.Money).FirstOrDefault();

            foreach (var player in Players)
            {
                if (player.Money == winner.Money)
                {
                    player.Winner = true;
                }
                else
                {
                    player.Winner = false;
                }
            }
        }
    } //end class HareAndTortoiseGame
}
