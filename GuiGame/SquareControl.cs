using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SharedGameClasses;

namespace GuiGame {

    /// <summary>
    /// A type of PictureBox control that display (each) one of the squares in the game board. 
    /// For each square on the board, there is an object from this SquareControl control, 
    /// as well as a corresponding Square object.
    /// </summary>
    public partial class SquareControl : PictureBox {

        // A reference to the corresponding Square object, in the Board class of the SharedGameClasses.
        private Square square;  

        private BindingList<Player> players;  // References the players in the overall game.

        private bool[] containsPlayers = new bool[HareAndTortoiseGame.MAX_PLAYERS];
        public bool[] ContainsPlayers {
            get {
                return containsPlayers;
            }
            set {
                containsPlayers = value;
            }
        }

        public const int SQUARE_SIZE = 100;

        // Font and brush for displaying text inside the GUI square.
        private Font textFont = new Font("Microsoft Sans Serif", 8);
        private Brush textBrush = Brushes.White;

        /// <summary>
        /// Parameterless constructor.
        /// Do not want the generic default constructor to be used
        /// as there is no way to set the SquareControl's data.
        /// This replaces the compiler's generic default constructor.
        /// Pre:  none
        /// Post: ALWAYS throws an ArgumentException.
        /// </summary>
        /// <remarks>NOT TO BE USED EVER!</remarks>
        public SquareControl() {
            throw new ArgumentException("Parameterless constructor invalid.");
        } // end Square constructor

        /// <summary>
        /// Constructor with initialising parameters.
        /// Pre:  parameters square and players are both not null.
        /// Post: initialised object.
        /// </summary>
        /// <param name="square">The corresponding Square object, 
        /// in the Board class of the SharedGameClasses.</param>
        /// <param name="players"The list of players,>
        /// in the Board class of the SharedGameClasses.</param>
        public SquareControl(Square square, BindingList<Player> players) {

            this.square = square;
            this.players = players;

            //  Set GUI properties of the whole square.
            Size = new Size(SQUARE_SIZE, SQUARE_SIZE);
            Margin = new Padding(0);  // No spacing around the cell. (Default is 3 pixels.)
            //Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.CornflowerBlue;

            LoadImageWhenNeeded();
            SetTextColour();
        }

        /// <summary>
        /// Load the image (or "picture") that is appropriate for this kind of square, where one is needed.
        /// Pre:  PNG file already exists in the Images folder.
        /// Post: image is loaded into this control, if one is need for this square.
        /// </summary>
        private void LoadImageWhenNeeded() {

            //draw background imange/ color for square
            if (this.square.Number == Board.START_SQUARE_NUMBER)
            {
                BackColor = Color.BurlyWood;
                
            }
            else if (square.Number == Board.FINISH_SQUARE_NUMBER)
            {
                BackColor = Color.BurlyWood;
            }
            else
            {
                if (square.Number % 10 == 0)
                {
                    LoadImageFromFile("win.png");
                }
                else
                {
                    if (square.Number % 5 == 0)
                    {
                        LoadImageFromFile("lose.png");
                    }
                }
            }
           
        }

        /// <summary>
        /// Called by LoadImageWhenNeeded to load the image (or "picture") from the specified fileName.
        /// Pre:  PNG file already exists in the Images folder.
        /// Post: image is loaded into this control.
        /// </summary>
        /// <param name="fileName">The filename of the .PNG file. Do not include any path information.</param>
        private void LoadImageFromFile(string fileName) {
            Image image = Image.FromFile(@"Images\" + fileName);
            Image = image;
            SizeMode = PictureBoxSizeMode.StretchImage;  // Zoom is also ok.
        }

        /// <summary>
        /// Sets the text colour for this square, where different to the default colour (White).
        /// Pre:  none.
        /// Post: this.textBrush has the correct colour for this kind of square.
        /// </summary>
        private void SetTextColour() {
            if (square.Number % 10 == 0)
            {
                textBrush = Brushes.Black;
            }
            else
            {
                if (square.Number % 5 == 0)
                {
                    textBrush = Brushes.Red;
                }
            }
        }

        /// <summary>
        /// Displays the square on the screen. 
        /// This method has a critical role in making the SquareControl display properly,
        /// but it is somewhat complicated and you do not need to understand the details of what it does.
        /// DO NOT CHANGE THIS METHOD.
        /// If you do, your GUI game will become much more difficult to get working.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {

            //  Due to a limitation in WinForms, don't use base.OnPaint(e) here.

            if (Image != null)
                e.Graphics.DrawImage(Image, e.ClipRectangle);

            string squareText;
            if (square.Name == "Start" || square.Name == "Finish") {
                squareText = square.Name;
            } else {
                squareText = square.Number.ToString();
            }

            // Create rectangle for drawing.
            float textWidth = textFont.Size * squareText.Length;
            float textHeight = textFont.Height;
            float textX = e.ClipRectangle.Right - textWidth;
            float textY = e.ClipRectangle.Bottom - textHeight;
            RectangleF drawRect = new RectangleF(textX, textY, textWidth, textHeight);

            // When debugging this method, show the drawing-rectangle on the screen.
            //Pen blackPen = new Pen(Color.Black);
            //e.Graphics.DrawRectangle(blackPen, textX, textY, textWidth, textHeight);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Far;  // Right-aligned.

            // Draw string to screen.
            e.Graphics.DrawString(squareText, textFont, textBrush, drawRect, drawFormat);

            //  Draw player tokens (when any players are on this square).
            const int PLAYER_TOKENS_PER_ROW = 3;
            const int PLAYER_TOKEN_SIZE = 30;  // pixels.
            const int PLAYER_TOKEN_SPACING = (SQUARE_SIZE - (PLAYER_TOKEN_SIZE * PLAYER_TOKENS_PER_ROW)) / (PLAYER_TOKENS_PER_ROW - 1);
            int count = 0;

            //check players land on
            //draw player symbols
            foreach (var player in players)
            {
                
                if (player.Location == this.square)
                {
                    int xPosition = count % PLAYER_TOKENS_PER_ROW;
                    int yPosition = count / PLAYER_TOKENS_PER_ROW;
                    int xPixels = xPosition * (PLAYER_TOKEN_SIZE + PLAYER_TOKEN_SPACING);
                    int yPixels = yPosition * (PLAYER_TOKEN_SIZE + PLAYER_TOKEN_SPACING);
                    Brush playerTokenColour = player.PlayerTokenColour;
                    e.Graphics.FillEllipse(playerTokenColour, xPixels, yPixels, PLAYER_TOKEN_SIZE, PLAYER_TOKEN_SIZE);
                }
                count = count + 1;
            }
        } //end OnPaint
    }
}
