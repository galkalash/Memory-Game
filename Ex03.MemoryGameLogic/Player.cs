using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.MemoryGameLogic
{
    public class Player
    {
        private string m_Name;
        private int m_Score;

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public Player(string i_Name)
        {
            m_Name = i_Name;
            m_Score = 0;
        }

        public void UpdatScore()
        {
            m_Score++;
        }
    }
}
