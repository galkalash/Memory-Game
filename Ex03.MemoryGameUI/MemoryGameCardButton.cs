using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Ex05.MemoryGameLogic;

namespace Ex05.MemoryGameUI
{
    public class MemoryGameCardButton : Button
    {
        private Card m_MemoryGameCard;
        private PictureBox m_CardData;
        private int m_RowNumber;
        private int m_ColNumber;
        int m_CardValue;

        public MemoryGameCardButton(Card i_GameCard, int i_RownNumber, int i_ColNumber, int i_CardValue)
        {
            StringBuilder imageURL = new StringBuilder();
            m_CardValue = i_CardValue;
            m_MemoryGameCard = i_GameCard;
            m_RowNumber = i_RownNumber;
            m_ColNumber = i_ColNumber;
            m_CardData = new PictureBox();
            m_CardData.Top = this.Top + 7;
            m_CardData.Left = this.Left + 7;            
            m_CardData.Size = new Size(85, 85);
            m_CardData.SizeMode = PictureBoxSizeMode.StretchImage;
            imageURL.Append(@"http://picsum.photos/id/");
            imageURL.Append(m_CardValue+10);
            imageURL.Append(@"/80");
            m_CardData.LoadAsync(imageURL.ToString());
            m_CardData.Visible = false;
            Controls.Add(m_CardData);
        }

        public Card MemoryGameCard
        {
            get
            {
                return m_MemoryGameCard;
            }
            set
            {
                m_MemoryGameCard = value;
            }
        }

        public PictureBox CardData
        {
            get
            {
                return m_CardData;
            }
            set
            {
                m_CardData = value;
            }
        }

        public int RowNumber
        {
            get
            {
                return m_RowNumber;
            }
        }

        public int ColNumber
        {
            get
            {
                return m_ColNumber;
            }
        }

        internal void ImageVisible()
        {
            m_CardData.Visible = true;
        }

        internal void ImageInvisible()
        {
            m_CardData.Visible = false;
        }

    }
}
