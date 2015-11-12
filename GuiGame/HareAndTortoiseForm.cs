using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;

using SharedGameClasses;

namespace GuiGame {

	/// <summary>
	/// The form that displays the GUI version of the game.
	/// </summary>
	public partial class HareAndTortoiseForm : Form {

		// The GUI game uses the HareAndTortoiseGame, from the SharedGameClasses.
		HareAndTortoiseGame hareAndTortoiseGame = new HareAndTortoiseGame(new Board());
        ListBoxTraceListener listener;

		// Specify the numbers of rows and columns on the screen.
		const int NUM_OF_ROWS = 7;
		const int NUM_OF_COLUMNS = 6;

		// When we update what's on the screen, we show the movement of players 
		// by removing them from their old squares and adding them to their new squares.
		// This enum makes it clearer that we need to do both.
		enum TypeOfGuiUpdate { AddPlayer, RemovePlayer };

        /// <summary>
		/// Constructor with initialising parameters.
		/// Pre:  none.
		/// Post: the form is initialised, ready for the game to start.
		/// </summary>
		public HareAndTortoiseForm() {

			InitializeComponent();
			hareAndTortoiseGame.NumberOfPlayers = HareAndTortoiseGame.MAX_PLAYERS; // Max players, by default.
			hareAndTortoiseGame.InitialiseAllThePlayers();
			SetupTheGui();
			ResetGame();
		}

		/// <summary>
		/// Set up the GUI when the game is first displayed on the screen.
		/// Pre:  the form contains the controls needed for the game.
		/// Post: the game is ready for the user(s) to play.
		/// </summary>
		private void SetupTheGui() {
			CancelButton = exitButton;  // Allow the Esc key to close the form.
            numberOfPlayersCbb.SelectedIndex = 4; //set selected item is 6 (index 4)
            gridPlayers.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //do not alow value in dropbox
			ResizeGameBoard();
			SetupGameBoard();
			//set intitial ComboBos Seletion to 6 here
            listener = new ListBoxTraceListener(listBoxListener);
            numberOfPlayersCbb.DropDownStyle = ComboBoxStyle.DropDownList;

			SetupPlayersDataGridView();

			  
		}// end SetupTheGui


		/// <summary>
		/// Resizes the entire form, so that the individual squares have their correct size, 
		/// as specified by SquareControl.SQUARE_SIZE.  
		/// This method allows us to set the entire form's size to approximately correct value 
		/// when using Visual Studio's Designer, rather than having to get its size correct to the last pixel.
		/// Pre:  none.
		/// Post: the board has the correct size.
		/// </summary>
		private void ResizeGameBoard() {
			// Uncomment all the lines in this method, once you've added the boardTableLayoutPanel to your form.
			// Do not add any extra code.
			//const int SQUARE_SIZE = SquareControl.SQUARE_SIZE;
			//int currentHeight = boardTableLayoutPanel.Size.Height;
			//int currentWidth = boardTableLayoutPanel.Size.Width;
			//int desiredHeight = SQUARE_SIZE * NUM_OF_ROWS;
			//int desiredWidth = SQUARE_SIZE * NUM_OF_COLUMNS;
			//int increaseInHeight = desiredHeight - currentHeight;
			//int increaseInWidth = desiredWidth - currentWidth;
			//this.Size += new Size(increaseInWidth, increaseInHeight);
			//boardTableLayoutPanel.Size = new Size(desiredWidth, desiredHeight);
		}

		/// <summary>
		/// Creates each SquareControl and adds it to the boardTableLayoutPanel that displays the board.
		/// Pre:  none.
		/// Post: the boardTableLayoutPanel contains all the SquareControl objects for displaying the board.
		/// </summary>
		private void SetupGameBoard() {
			int squareHeigh = this.splitContainer.Panel1.Height / NUM_OF_ROWS; 
			int squareWidth = this.splitContainer.Panel1.Width / NUM_OF_COLUMNS;

            //add square to game board
            for (int i = 0; i < NUM_OF_ROWS; i++)
            {
                for (int j = 0; j < NUM_OF_COLUMNS; j++)
                {
                    //create control
                    SquareControl squarecontrol = new SquareControl(hareAndTortoiseGame.Board.Squares[(i*(NUM_OF_ROWS-1))+j], hareAndTortoiseGame.Players);
                    //check row for correct arrange as row
                    if (i % 2 == 0)
                    {
                            
                        squarecontrol.Left = j * squareWidth;
                    }
                    else
                    {
                        squarecontrol.Left = (NUM_OF_COLUMNS -1 -j) * squareWidth;
                    }
                    //set top position of square
                    squarecontrol.Top = ((NUM_OF_ROWS- 1) - i) * squareHeigh;
                    squarecontrol.Size = new Size(squareWidth, squareHeigh);
                    this.splitContainer.Panel1.Controls.Add(squarecontrol);
                }
            }
            		
		}

		/// <summary>
		/// Tells the players DataGridView to get its data from the hareAndTortoiseGame.Players BindingList.
		/// Pre:  players DataGridView exists on the form.
		///       hareAndTortoiseGame.Players BindingList is not null.
		/// Post: players DataGridView displays the correct rows and columns.
		/// </summary>
		private void SetupPlayersDataGridView() {
            gridPlayers.DataSource = hareAndTortoiseGame.Players;
		}

		/// <summary>
		/// Resets the game, including putting all the players on the Start square.
		/// This requires updating what is displayed in the GUI, 
		/// as well as resetting the hareAndTortoiseGame object.
		/// This method is used by both the Reset button and 
		/// when a new value is chosen in the Number of Players ComboBox.
		/// Pre:  none.
		/// Post: the form displays the game in the same state as when the program first starts 
		///       (except that any user names that the player has entered are not reset).
		/// </summary>
		private void ResetGame() {
            hareAndTortoiseGame.InitialiseAllThePlayers();
		}

		/// <summary>
		/// At several places in the program's code, it is necessary to update the GUI board,
		/// so that player's tokens (or "pieces") are removed from their old squares
		/// or added to their new squares. E.g. when all players are moved back to the Start.
		/// 
		/// For each of the players, this method is to use the GetSquareNumberOfPlayer method to find out 
		/// which square number the player is on currently, then use the SquareControlAt method
		/// to find the corresponding SquareControl, and then update that SquareControl so that it
		/// knows whether the player is on that square or not.
		/// 
		/// Moving all players from their old to their new squares requires this method to be called twice: 
		/// once with the parameter typeOfGuiUpdate set to RemovePlayer, and once with it set to AddPlayer.
		/// In between those two calls, the players locations must be changed by using one or more methods 
		/// in the hareAndTortoiseGame class. Otherwise, you won't see any change on the screen.
		/// 
		/// Because this method moves ALL players, it should NOT be used when animating a SINGLE player's
		/// movements from square to square.
		/// 
		/// Pre:  the Players objects in the hareAndTortoiseGame give the players' current locations.
		/// Post: the GUI board is updated to match the locations in the Players objects.
		/// </summary>
		/// <param name="typeOfGuiUpdate">Specifies whether all the players are being removed 
		/// from their old squares or added to their new squares</param>
		private void UpdatePlayersGuiLocations(TypeOfGuiUpdate typeOfGuiUpdate) {
			RefreshBoardTablePanelLayout(); // Should be the last line in this method. Do not put inside a loop.
		}

		/*** START OF LOW-LEVEL METHODS ***
		 * 
		 *   The methods in this section are "helper" methods that can be called to do basic things. 
		 *   That makes coding easier in other methods of this class.
		 *   ***/

		/// <summary>
		/// When the SquareControl objects are updated (when players move to a new square),
		/// the board's TableLayoutPanel is not updated immediately.  
		/// Each time that players move, this method must be called so that the board's TableLayoutPanel 
		/// is told to refresh what it is displaying.
		/// Pre:  none.
		/// Post: the board's TableLayoutPanel shows the latest information 
		///       from the collection of SquareControl objects in the TableLayoutPanel.
		/// </summary>
		private void RefreshBoardTablePanelLayout() {
			//Redraw panel to update UI
            splitContainer.Panel1.Refresh();
		}

		/// <summary>
		/// When the Player objects are updated (location, money, etc.),
		/// the players DataGridView is not updated immediately.  
		/// Each time that those player objects are updated, this method must be called 
		/// so that the players DataGridView is told to refresh what it is displaying.
		/// Pre:  none.
		/// Post: the players DataGridView shows the latest information 
		///       from the collection of Player objects in the hareAndTortoiseGame.
		/// </summary>
		private void RefreshPlayersInfoInDataGridView() {
			hareAndTortoiseGame.Players.ResetBindings();
		}

		/// <summary>
		/// Tells you the current square number of a given player.
		/// Pre:  a valid playerNumber is specified.
		/// Post: the square number of the player is returned.
		/// </summary>
		/// <param name="playerNumber">The player number.</param>
		/// <returns>Returns the square number of the playerNumber.</returns>
		private int GetSquareNumberOfPlayer(int playerNumber) {
			return  hareAndTortoiseGame.Players[playerNumber].Location.Number;
		}

		/// <summary>
		/// Tells you which SquareControl object is associated with a given square number.
		/// Pre:  a valid squareNumber is specified; and
		///       the boardTableLayoutPanel is properly constructed.
		/// Post: the SquareControl object associated with the square number is returned.
		/// </summary>
		/// <param name="squareNumber">The square number.</param>
		/// <returns>Returns the SquareControl object associated with the square number.</returns>
		private SquareControl SquareControlAt(int squareNumber) {
			int rowNumber;
			int columnNumber;
			MapSquareNumToScreenRowAndColumn(squareNumber, out rowNumber, out columnNumber);
			// Uncomment the following line once you've added the boardTableLayoutPanel to your form.
			// return (SquareControl) boardTableLayoutPanel.GetControlFromPosition(columnNumber, rowNumber);

			// Delete the following line once you've added the boardTableLayoutPanel to your form.
			return null;
		}

		/// <summary>
		/// For a given square number, tells you the corresponding row and column numbers.
		/// Pre:  none.
		/// Post: returns the row and column numbers, via "out" parameters.
		/// </summary>
		/// <param name="squareNumber">The input square number.</param>
		/// <param name="rowNumber">The output row number.</param>
		/// <param name="columnNumber">The output column number.</param>
		private static void MapSquareNumToScreenRowAndColumn(int squareNumber, out int rowNumber, out int columnNumber) {

			
			rowNumber = squareNumber/(NUM_OF_ROWS-1);      
			columnNumber = squareNumber%(NUM_OF_ROWS-1);   
		}

		/*** END OF LOW-LEVEL METHODS ***/

		/*** START OF EVENT-HANDLING METHODS ***/

		/// <summary>
		/// Handle the Exit button being clicked.
		/// Pre:  the Exit button is clicked.
		/// Post: the game is closed.
		/// </summary>
		private void exitButton_Click(object sender, EventArgs e) {
			// Terminate immediately, rather than calling Close(), 
			// so that we don't have problems with any animations that are running at the same time.
			Environment.Exit(0);  
		}

        private void rollDiceButton_Click(object sender, EventArgs e)
        {
            //play roll die  
            hareAndTortoiseGame.PlayRoll();

            //write out listbox result of dices
            listener.WriteLine(string.Format("Player {0}: dices {1}",hareAndTortoiseGame.CurrentPlayer.Name, (hareAndTortoiseGame.Die1Value + hareAndTortoiseGame.Die2Vlue)));

            hareAndTortoiseGame.PlayerMove();//Move player

            listener.WriteLine(string.Format("player {0}: move from {1} to {2}", hareAndTortoiseGame.CurrentPlayer.Name, hareAndTortoiseGame.CurrentPlayer.Location.Number - (hareAndTortoiseGame.Die1Value + hareAndTortoiseGame.Die2Vlue), hareAndTortoiseGame.CurrentPlayer.Location.Number));
            
            //check for finish move
            if (hareAndTortoiseGame.IsFinish)
            {
                rollDiceButton.Enabled = false;
                listener.WriteLine("Game finished");
            }

            RefreshBoardTablePanelLayout();//Update UI gameboard
            RefreshPlayersInfoInDataGridView();//Update UI players table

        }

        private void resetButton_Click(object sender, EventArgs e)
        {

            listener.WriteLine("Game reseted!");

            //enanble roll button if was disable
            rollDiceButton.Enabled = true;

            //set all players at init
            hareAndTortoiseGame.InitialiseAllThePlayers();
            //Update UI
            RefreshBoardTablePanelLayout();

        }

        private void numberOfPlayersCbb_SelectedIndexChanged(object sender, EventArgs e)
        {

            //default value is may player of game
            int selectedNumber = HareAndTortoiseGame.MAX_PLAYERS;

            //get value from dropbox
            Int32.TryParse(numberOfPlayersCbb.SelectedItem.ToString(),out selectedNumber);

            //Update game if change number of player
            if (selectedNumber != hareAndTortoiseGame.NumberOfPlayers)
            {
                hareAndTortoiseGame.NumberOfPlayers = selectedNumber;
                resetButton_Click(null, null);
            }
        }

		/*** END OF EVENT-HANDLING METHODS ***/
	}
}

