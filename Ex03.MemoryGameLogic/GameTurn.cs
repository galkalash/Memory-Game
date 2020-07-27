using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.MemoryGameLogic
{
    public class GameTurn
    {
        private eGameTurn m_GameTurn;

        public eGameTurn _GameTurn
        {
            get
            {
                return m_GameTurn;
            }
            set
            {
                m_GameTurn = value;
            }
        }

        public GameTurn()
        {
            m_GameTurn = eGameTurn.Player1;
        }

        public void ChangeTurn()
        {
            if (IsPlayer1Turn() == true)
            {
                m_GameTurn = eGameTurn.Player2;
            }
            else
            {
                m_GameTurn = eGameTurn.Player1;
            }
        }

        public bool IsPlayer1Turn()
        {
            return m_GameTurn == eGameTurn.Player1;
        }

        public bool IsPlayer2Turn()
        {
            return m_GameTurn == eGameTurn.Player2;
        }

        public enum eGameTurn
        {
            Player1 = 1,
            Player2 = 2,
        }
    }
}
