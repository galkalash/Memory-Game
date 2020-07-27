using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.MemoryGameLogic
{
    public struct Position
    {
        private int m_RowNum;
        private int m_ColNum;

        public int RowNum
        {
            get
            {
                return m_RowNum;
            }
            set
            {
                m_RowNum = value;
            }
        }

        public int ColNum
        {
            get
            {
                return m_ColNum;
            }
            set
            {
                m_ColNum = value;
            }
        }

        public Position(int i_RowNum, int i_ColNum)
        {
            m_RowNum = i_RowNum;
            m_ColNum = i_ColNum;
        }

        public bool IsEqualPosition(Position i_PositionToCheck)
        {
            return m_RowNum == i_PositionToCheck.m_RowNum && m_ColNum == i_PositionToCheck.m_ColNum;
        }
    }
}
