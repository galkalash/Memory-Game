using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Threading;
using Ex05.MemoryGameLogic;

namespace Ex05.MemoryGameUI
{
    public class RunGame
    {
        private MemoryGame m_MemoryGame;
        private string m_RulesSTR;

        public MemoryGame _MemoryGame
        {
            get
            {
                return m_MemoryGame;
            }
        }

        public RunGame()
        {
            FormSettings formSettings = new FormSettings();
            bool playGame = true;
            m_RulesSTR = string.Format(@"Memory Game Rules:
Each player chooses two cards from the closed cards in his turn. 
If both cards have the same picture, the player gets a point and his turn continues.
The game ends when all the cards are open.
The player with the most points is the winner
Enjoy!.");

            while (playGame)
            {
                while (formSettings.DialogResult != DialogResult.Cancel && formSettings._FirstPlayerName == string.Empty || formSettings._SecondPlayerName == string.Empty)
                {
                    formSettings.ShowDialog();
                }

                if (formSettings.DialogResult == DialogResult.OK)
                {
                    m_MemoryGame = new MemoryGame(formSettings.gameType, formSettings.BoardRows, formSettings.BoardCals,
                                                  formSettings._FirstPlayerName, formSettings._SecondPlayerName);
                    BoardForm boardForm = new BoardForm(m_MemoryGame);
                    MessageBox.Show(m_RulesSTR, "Memory Game - Rules", MessageBoxButtons.OK);
                    Thread.Sleep(1000);
                    boardForm.ShowDialog();

                    if (boardForm.DialogResult != DialogResult.Yes)
                    {
                        playGame = false;
                    }
                }
            }
        }

        
    }
    
}
