using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.MemoryGameLogic;

namespace Ex05.MemoryGameUI
{
    public partial class FormSettings : Form
    {
        public string _FirstPlayerName
        {
            get
            {
                return TextBoxFirstPlayerName.Text; ;
            }
        }

        public string _SecondPlayerName
        {
            get
            {
                return TextBoxSecondPlayerName.Text;
            }
        }

        public int BoardCals
        {
            get
            {
                return buttonBoardSize.Text[4] - '0';
            }
        }

        public int BoardRows
        {
            get
            {
                return buttonBoardSize.Text[0] - '0';
            }
        }
         
        public GameType gameType
        {
            get
            {
                GameType gameType;
                if(TextBoxSecondPlayerName.Enabled == true)
                {
                    gameType = new GameType(GameType.eGameType.TwoPlayers);
                }
                else
                {
                    gameType = new GameType(GameType.eGameType.AgainstTheComputer);
                }
                return gameType;
            }
        }

        public FormSettings()
        {
            InitializeComponent();             
        }       

        private void buttonAgainstAFriend_Click(object sender, EventArgs e)
        {
            if (TextBoxSecondPlayerName.Enabled == false)
            {
                TextBoxSecondPlayerName.Enabled = true;
                TextBoxSecondPlayerName.Text = "";
            }
            else
            {
                TextBoxSecondPlayerName.Enabled = false;
                TextBoxSecondPlayerName.Text = "-Computer-";
            }
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            int Rows = buttonBoardSize.Text[0]-'0';
            int Cols = buttonBoardSize.Text[4]-'0';
            if (Rows == 5 && Cols == 4)
            {
                Cols = 6;
            }
            else if (Cols < 6)
            {
                Cols++;
            }
            else if(Rows < 6)
            {
                Rows++;
                Cols = 4;
            }
            else
            {
                Rows = 4;
                Cols = 4;                
            }
            buttonBoardSize.Text = string.Format("{0} x {1}", Rows, Cols);
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (TextBoxFirstPlayerName.Text != string.Empty && (buttonAgainstAFriend.Enabled == false || TextBoxSecondPlayerName.Text != string.Empty))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Player name can't be empty.", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
