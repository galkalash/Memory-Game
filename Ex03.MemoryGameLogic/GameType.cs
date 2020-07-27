using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.MemoryGameLogic
{
    public class GameType
    {
        private eGameType m_GameType;

        public eGameType _GameType
        {
            get
            {
                return m_GameType;
            }
            set
            {
                m_GameType = value;
            }
        }

        private GameType(int i_GameTypeInt)
        {
            m_GameType = (eGameType)i_GameTypeInt;
        }

        public GameType(eGameType i_GameTypeInt)
        {
            m_GameType = i_GameTypeInt;
        }

        public static GameType Parse(string i_GameTypeStr)
        {
            return new GameType(int.Parse(i_GameTypeStr));
        }

        public static bool IsValidInput(string i_GameTypeStr)
        {
            eGameType gameType = (eGameType)int.Parse(i_GameTypeStr);

            return gameType == eGameType.AgainstTheComputer || gameType == eGameType.TwoPlayers;
        }

        public bool IsTwoPlayers()
        {
            return m_GameType == eGameType.TwoPlayers;
        }

        public bool IsAgainstTheComputer()
        {
            return m_GameType == eGameType.AgainstTheComputer;
        }

        public enum eGameType
        {
            AgainstTheComputer = 1,
            TwoPlayers = 2,
        }
    }
}
