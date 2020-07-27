using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.IO;
using Ex05.MemoryGameLogic;


namespace Ex05.MemoryGameUI
{
    public class BoardForm : Form
    {
        private MemoryGameCardButton[,] m_CardsButtons;    
        private MemoryGame m_MemoryGame;
        private Label m_Player1ScoreLabel;
        private Label m_Player2ScoreLabel;
        private Label m_CurrentPlayerTurnLabel;
        private Position firstPos;
        private Position secondPos;

        public BoardForm(MemoryGame i_MemoryGame)
        {
            m_MemoryGame = i_MemoryGame;
            firstPos = new Position(-1, -1);
            secondPos = new Position(-1, -1);
            m_CardsButtons = new MemoryGameCardButton[m_MemoryGame.GameBoard.Rows, m_MemoryGame.GameBoard.Cols];
            initializeComponent();
        }


        private void initializeComponent()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "BoardForm";
            Text = "Memory Game";
            MaximizeBox = false;
            MinimizeBox = false;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            m_Player1ScoreLabel = new Label();
            m_Player1ScoreLabel.Text = m_MemoryGame.Player1.Name + "'s score: " + m_MemoryGame.Player1.Score;
            m_Player1ScoreLabel.Left = this.Left + 10;
            m_Player1ScoreLabel.BackColor = Color.MediumAquamarine;
            m_Player1ScoreLabel.AutoSize = true;
            Controls.Add(m_Player1ScoreLabel);
            m_Player2ScoreLabel = new Label();
            if (m_MemoryGame.GameType.IsAgainstTheComputer() == true)
            {
                m_Player2ScoreLabel.Text = m_MemoryGame.Computer.Name + "'s score: " + m_MemoryGame.Computer.Score;
            }
            else
            {
                m_Player2ScoreLabel.Text = m_MemoryGame.Player2.Name + "'s score: " + m_MemoryGame.Player2.Score;
            }
            m_Player2ScoreLabel.Left = m_Player1ScoreLabel.Left;
            m_Player2ScoreLabel.BackColor = Color.Plum;
            m_Player2ScoreLabel.AutoSize = true;
            Controls.Add(m_Player2ScoreLabel);
            m_CurrentPlayerTurnLabel = new Label();
            m_CurrentPlayerTurnLabel.Text = "Current Player: " + m_MemoryGame.Player1.Name;
            m_CurrentPlayerTurnLabel.Left = this.Left + 10;
            m_CurrentPlayerTurnLabel.BackColor = m_Player1ScoreLabel.BackColor;
            m_CurrentPlayerTurnLabel.AutoSize = true;
            Controls.Add(m_CurrentPlayerTurnLabel);
            updatBoardButtons();
            m_CurrentPlayerTurnLabel.Top = m_CardsButtons[m_MemoryGame.GameBoard.Rows - 1, 0].Bottom + 10;
            m_Player1ScoreLabel.Top = m_CurrentPlayerTurnLabel.Bottom + 10;
            m_Player2ScoreLabel.Top = m_Player1ScoreLabel.Bottom + 10;
            this.ClientSize = new System.Drawing.Size(m_CardsButtons[0, m_MemoryGame.GameBoard.Cols - 1].Right + 10, m_Player2ScoreLabel.Bottom + 10);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BoardForm_FormClosing);
        }

        private string[] updateImages()
        {
            return Directory.GetFiles(@"C:\photos", "*.jpg");
        }

        private void updatBoardButtons()
        {

            for (int i = 0; i < m_MemoryGame.GameBoard.Rows; i++)
            {
                for (int j = 0; j < m_MemoryGame.GameBoard.Cols; j++)
                {
                    m_CardsButtons[i, j] = new MemoryGameCardButton(m_MemoryGame.GameBoard.Board[i, j], i, j, m_MemoryGame.GameBoard.Board[i, j].Data);
                    if (i == 0)
                    {
                        m_CardsButtons[i, j].Top = this.Top + 10;
                    }
                    else
                    {
                        m_CardsButtons[i, j].Top = m_CardsButtons[i - 1, j].Bottom + 10;
                    }

                    if (j == 0)
                    {
                        m_CardsButtons[i, j].Left = this.Left + 10;
                    }
                    else
                    {
                        m_CardsButtons[i, j].Left = m_CardsButtons[i, j - 1].Right + 10;
                    }

                    m_CardsButtons[i, j].Size = new Size(100, 100);
                    Controls.Add(m_CardsButtons[i, j]);
                    m_CardsButtons[i, j].Click += CardsButtons_Click;
                }
            }
        }

        public void CardsButtons_Click(object sender, EventArgs e)
        {
            MemoryGameCardButton memoryCardButton = sender as MemoryGameCardButton;
            if (m_MemoryGame.GameBoard.Board[memoryCardButton.RowNumber, memoryCardButton.ColNumber].IsClose == true)
            {
                memoryCardButton.FlatAppearance.BorderColor = m_CurrentPlayerTurnLabel.BackColor;
                memoryCardButton.ImageVisible();
                this.Update();
                if (firstPos.RowNum == -1)
                {
                    firstPos = new Position(memoryCardButton.RowNumber, memoryCardButton.ColNumber);
                    m_MemoryGame.GameBoard.OpenCard(firstPos);
                }
                else
                {
                    secondPos = new Position(memoryCardButton.RowNumber, memoryCardButton.ColNumber);
                    m_MemoryGame.GameBoard.OpenCard(secondPos);
                }
            }
            runMemoryGame();

            if (m_MemoryGame.IsGameOver != true)
            {
                while (m_MemoryGame.Turn.IsPlayer2Turn() && m_MemoryGame.GameType.IsAgainstTheComputer() == true)
                {
                    computerTurn();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void runMemoryGame()
        {
            while (m_MemoryGame.IsGameOver == false && firstPos.RowNum != -1 && secondPos.RowNum != -1)
            {

                if (m_MemoryGame.GameType.IsAgainstTheComputer() == true && m_MemoryGame.Turn.IsPlayer2Turn() == true)
                {
                    computerTurn();
                    m_Player2ScoreLabel.Text = m_MemoryGame.Computer.Name + "'s score: " + m_MemoryGame.Computer.Score;
                    Thread.Sleep(500);
                }
                else
                {
                    if (m_MemoryGame.Turn.IsPlayer1Turn() == true)
                    {
                        playerTurn();
                        m_Player1ScoreLabel.Text = m_MemoryGame.Player1.Name + "'s score: " + m_MemoryGame.Player1.Score;
                    }
                    else
                    {
                        playerTurn();
                        m_Player2ScoreLabel.Text = m_MemoryGame.Player2.Name + "'s score: " + m_MemoryGame.Player2.Score;
                    }
                }
                this.Update();
                updatTurn();
            }
            if (m_MemoryGame.IsGameOver == true)
            {
                winnerCheck();
                checkIfAnotherGame();
            }
        }

        private void playerTurn()
        {
            if (firstPos.RowNum != -1 && secondPos.RowNum != -1)
            {
                m_MemoryGame.RunTurn(firstPos, secondPos);
                if (m_MemoryGame.GameBoard.Board[firstPos.RowNum, firstPos.ColNum].IsClose == false)
                {
                    successfulTurn();
                }
                else
                {
                    m_CardsButtons[firstPos.RowNum, firstPos.ColNum].ImageInvisible();
                    m_CardsButtons[secondPos.RowNum, secondPos.ColNum].ImageInvisible();
                }
                this.Update();
            }
        }
        private void computerTurn()
        {
            firstPos = m_MemoryGame.Computer.ChooseFirstPositionCard();
            secondPos = m_MemoryGame.Computer.ChooseSecondPositionCard(m_MemoryGame.GameBoard.Board[firstPos.RowNum, firstPos.ColNum].Data, firstPos);
            m_CardsButtons[firstPos.RowNum, firstPos.ColNum].ImageVisible();
            this.Update();
            Thread.Sleep(1000);
            m_CardsButtons[secondPos.RowNum, secondPos.ColNum].ImageVisible();
            this.Update();
            m_MemoryGame.GameBoard.OpenCard(firstPos);
            m_MemoryGame.GameBoard.OpenCard(secondPos);
            m_MemoryGame.RunTurn(firstPos, secondPos);
            if (m_MemoryGame.GameBoard.Board[firstPos.RowNum, firstPos.ColNum].IsClose == false)
            {
                successfulTurn();
            }
            else
            {
                m_CardsButtons[firstPos.RowNum, firstPos.ColNum].ImageInvisible();
                m_CardsButtons[secondPos.RowNum, secondPos.ColNum].ImageInvisible();
            }
            this.Update();
        }

        private void successfulTurn()
        {
            if (m_MemoryGame.Turn.IsPlayer1Turn())
            {
                m_CardsButtons[firstPos.RowNum, firstPos.ColNum].BackColor = Color.MediumAquamarine;
                m_CardsButtons[secondPos.RowNum, secondPos.ColNum].BackColor = Color.MediumAquamarine;
            }
            else
            {
                m_CardsButtons[firstPos.RowNum, firstPos.ColNum].BackColor = Color.Plum;
                m_CardsButtons[secondPos.RowNum, secondPos.ColNum].BackColor = Color.Plum;
            }
        }

        private void updatTurn()
        {
            if (m_MemoryGame.Turn.IsPlayer1Turn() == true)
            {
                m_CurrentPlayerTurnLabel.BackColor = Color.MediumAquamarine;
                m_CurrentPlayerTurnLabel.Text = "Current Player: " + m_MemoryGame.Player1.Name;
                firstPos.RowNum = -1;
                firstPos.ColNum = -1;
                secondPos.RowNum = -1;
                secondPos.ColNum = -1;
            }
            else
            {
                m_CurrentPlayerTurnLabel.BackColor = Color.Plum;
                if (m_MemoryGame.GameType.IsAgainstTheComputer() == true)
                {
                    m_CurrentPlayerTurnLabel.Text = "Current Player: " + m_MemoryGame.Computer.Name;
                }
                else
                {
                    m_CurrentPlayerTurnLabel.Text = "Current Player: " + m_MemoryGame.Player2.Name;

                    firstPos.RowNum = -1;
                    firstPos.ColNum = -1;
                    secondPos.RowNum = -1;
                    secondPos.ColNum = -1;
                }
            }

        }
        private void winnerCheck()
        {
            if (m_MemoryGame.TheWinnerName() != null)
            {
                MessageBox.Show("The Winner is " + m_MemoryGame.TheWinnerName(), "Game Over", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("The result of the game is - tie", "Game Over", MessageBoxButtons.OK);
            }
        }

        private void checkIfAnotherGame()
        {
            DialogResult result = MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
            }
        }


        private void BoardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
