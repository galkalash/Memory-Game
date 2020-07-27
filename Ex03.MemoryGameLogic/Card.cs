using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.MemoryGameLogic
{
    public struct Card
    {
        private int m_Data;
        private bool m_IsClose;

        public int Data
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;
            }
        }

        public bool IsClose
        {
            get
            {
                return m_IsClose;
            }
            set
            {
                m_IsClose = value;
            }
        }

        public Card(int i_Data)
        {
            m_Data = i_Data;
            m_IsClose = true;
        }
    }
}
