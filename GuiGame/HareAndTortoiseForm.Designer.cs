namespace GuiGame {
    partial class HareAndTortoiseForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBoxListener = new System.Windows.Forms.ListBox();
            this.rollDiceButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.gridPlayers = new System.Windows.Forms.DataGridView();
            this.colColor = new System.Windows.Forms.DataGridViewImageColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWiner = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.numberOfPlayersCbb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listBoxListener);
            this.splitContainer.Panel2.Controls.Add(this.rollDiceButton);
            this.splitContainer.Panel2.Controls.Add(this.resetButton);
            this.splitContainer.Panel2.Controls.Add(this.gridPlayers);
            this.splitContainer.Panel2.Controls.Add(this.numberOfPlayersCbb);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.exitButton);
            this.splitContainer.Size = new System.Drawing.Size(884, 674);
            this.splitContainer.SplitterDistance = 668;
            this.splitContainer.TabIndex = 3;
            // 
            // listBoxListener
            // 
            this.listBoxListener.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxListener.FormattingEnabled = true;
            this.listBoxListener.Location = new System.Drawing.Point(3, 280);
            this.listBoxListener.Name = "listBoxListener";
            this.listBoxListener.Size = new System.Drawing.Size(206, 303);
            this.listBoxListener.TabIndex = 11;
            // 
            // rollDiceButton
            // 
            this.rollDiceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rollDiceButton.Location = new System.Drawing.Point(55, 589);
            this.rollDiceButton.Name = "rollDiceButton";
            this.rollDiceButton.Size = new System.Drawing.Size(75, 44);
            this.rollDiceButton.TabIndex = 10;
            this.rollDiceButton.Text = "Roll dice";
            this.rollDiceButton.UseVisualStyleBackColor = true;
            this.rollDiceButton.Click += new System.EventHandler(this.rollDiceButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(17, 639);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // gridPlayers
            // 
            this.gridPlayers.AllowUserToAddRows = false;
            this.gridPlayers.AllowUserToDeleteRows = false;
            this.gridPlayers.AllowUserToResizeColumns = false;
            this.gridPlayers.AllowUserToResizeRows = false;
            this.gridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colColor,
            this.colName,
            this.colMoney,
            this.colWiner});
            this.gridPlayers.Location = new System.Drawing.Point(3, 101);
            this.gridPlayers.MultiSelect = false;
            this.gridPlayers.Name = "gridPlayers";
            this.gridPlayers.ReadOnly = true;
            this.gridPlayers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridPlayers.RowHeadersVisible = false;
            this.gridPlayers.Size = new System.Drawing.Size(206, 173);
            this.gridPlayers.TabIndex = 7;
            // 
            // colColor
            // 
            this.colColor.DataPropertyName = "playerTokenImage";
            this.colColor.HeaderText = "Color";
            this.colColor.MinimumWidth = 30;
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            this.colColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colColor.Width = 30;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 70;
            // 
            // colMoney
            // 
            this.colMoney.DataPropertyName = "Money";
            this.colMoney.HeaderText = "$";
            this.colMoney.Name = "colMoney";
            this.colMoney.ReadOnly = true;
            this.colMoney.Width = 40;
            // 
            // colWiner
            // 
            this.colWiner.DataPropertyName = "Winner";
            this.colWiner.HeaderText = "Winer";
            this.colWiner.Name = "colWiner";
            this.colWiner.ReadOnly = true;
            this.colWiner.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWiner.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colWiner.Width = 60;
            // 
            // numberOfPlayersCbb
            // 
            this.numberOfPlayersCbb.FormattingEnabled = true;
            this.numberOfPlayersCbb.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.numberOfPlayersCbb.Location = new System.Drawing.Point(136, 37);
            this.numberOfPlayersCbb.Name = "numberOfPlayersCbb";
            this.numberOfPlayersCbb.Size = new System.Drawing.Size(36, 21);
            this.numberOfPlayersCbb.TabIndex = 6;
            this.numberOfPlayersCbb.SelectedIndexChanged += new System.EventHandler(this.numberOfPlayersCbb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of players";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hare and Tortoise";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(110, 639);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // HareAndTortoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 674);
            this.Controls.Add(this.splitContainer);
            this.Name = "HareAndTortoiseForm";
            this.Text = "Hare and Tortoise";
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ComboBox numberOfPlayersCbb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridPlayers;
        private System.Windows.Forms.Button rollDiceButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ListBox listBoxListener;
        private System.Windows.Forms.DataGridViewImageColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoney;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colWiner;
    }
}

