
namespace Ex05.MemoryGameUI
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.BoardSize = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonAgainstAFriend = new System.Windows.Forms.Button();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.FirstPlayerName = new System.Windows.Forms.Label();
            this.TextBoxFirstPlayerName = new System.Windows.Forms.TextBox();
            this.SecondPlayerName = new System.Windows.Forms.Label();
            this.TextBoxSecondPlayerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BoardSize
            // 
            this.BoardSize.AutoSize = true;
            this.BoardSize.Location = new System.Drawing.Point(22, 94);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(81, 17);
            this.BoardSize.TabIndex = 4;
            this.BoardSize.Text = "Board Size:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(363, 175);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(113, 30);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonAgainstAFriend
            // 
            this.buttonAgainstAFriend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAgainstAFriend.Location = new System.Drawing.Point(343, 50);
            this.buttonAgainstAFriend.Name = "buttonAgainstAFriend";
            this.buttonAgainstAFriend.Size = new System.Drawing.Size(133, 30);
            this.buttonAgainstAFriend.TabIndex = 2;
            this.buttonAgainstAFriend.Text = "Against a Friend";
            this.buttonAgainstAFriend.UseVisualStyleBackColor = true;
            this.buttonAgainstAFriend.Click += new System.EventHandler(this.buttonAgainstAFriend_Click);
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.BackColor = System.Drawing.Color.Pink;
            this.buttonBoardSize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonBoardSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBoardSize.Location = new System.Drawing.Point(26, 122);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(138, 82);
            this.buttonBoardSize.TabIndex = 4;
            this.buttonBoardSize.Text = "4 x 4";
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // FirstPlayerName
            // 
            this.FirstPlayerName.AutoSize = true;
            this.FirstPlayerName.Location = new System.Drawing.Point(22, 19);
            this.FirstPlayerName.Name = "FirstPlayerName";
            this.FirstPlayerName.Size = new System.Drawing.Size(124, 17);
            this.FirstPlayerName.TabIndex = 0;
            this.FirstPlayerName.Text = "First Player Name:";
            // 
            // TextBoxFirstPlayerName
            // 
            this.TextBoxFirstPlayerName.Location = new System.Drawing.Point(185, 19);
            this.TextBoxFirstPlayerName.Name = "TextBoxFirstPlayerName";
            this.TextBoxFirstPlayerName.Size = new System.Drawing.Size(131, 22);
            this.TextBoxFirstPlayerName.TabIndex = 1;
            // 
            // SecondPlayerName
            // 
            this.SecondPlayerName.AutoSize = true;
            this.SecondPlayerName.Location = new System.Drawing.Point(22, 57);
            this.SecondPlayerName.Name = "SecondPlayerName";
            this.SecondPlayerName.Size = new System.Drawing.Size(145, 17);
            this.SecondPlayerName.TabIndex = 2;
            this.SecondPlayerName.Text = "Second Player Name:";
            // 
            // TextBoxSecondPlayerName
            // 
            this.TextBoxSecondPlayerName.Enabled = false;
            this.TextBoxSecondPlayerName.ForeColor = System.Drawing.Color.Black;
            this.TextBoxSecondPlayerName.Location = new System.Drawing.Point(185, 54);
            this.TextBoxSecondPlayerName.Name = "TextBoxSecondPlayerName";
            this.TextBoxSecondPlayerName.Size = new System.Drawing.Size(131, 22);
            this.TextBoxSecondPlayerName.TabIndex = 3;
            this.TextBoxSecondPlayerName.Text = "-Computer-";
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 217);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.buttonAgainstAFriend);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.BoardSize);
            this.Controls.Add(this.TextBoxSecondPlayerName);
            this.Controls.Add(this.SecondPlayerName);
            this.Controls.Add(this.TextBoxFirstPlayerName);
            this.Controls.Add(this.FirstPlayerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Memory Game - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label BoardSize;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonAgainstAFriend;
        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Label FirstPlayerName;
        private System.Windows.Forms.TextBox TextBoxFirstPlayerName;
        private System.Windows.Forms.Label SecondPlayerName;
        private System.Windows.Forms.TextBox TextBoxSecondPlayerName;
    }
}