using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.MemoryGameLogic
{
    public class MemoryGame
    {
        private Player m_Player1;
        private Player m_Player2;
        private ComputerPlayer m_Computer;
        private CardBoard m_GameBoard;
        private GameTurn m_Turn;
        private GameType m_GameType;
        private bool m_IsGameOver;
        private int m_NumOfOpenPairs;

        public Player Player1
        {
            get
            {
                return m_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }
        }

        public GameType GameType
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

        public ComputerPlayer Computer
        {
            get
            {
                return m_Computer;
            }
            set
            {
                m_Computer = value;
            }
        }

        public CardBoard GameBoard
        {
            get
            {
                return m_GameBoard;
            }
            set
            {
                m_GameBoard = value;
            }
        }

        public GameTurn Turn
        {
            get
            {
                return m_Turn;
            }
            set
            {
                m_Turn = value;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }
            set
            {
                m_IsGameOver = value;
            }
        }

        public MemoryGame(GameType i_GameType, int i_Rows, int i_Cols, string i_Player1, string i_Player2)
        {
            m_Player1 = new Player(i_Player1);
            m_GameType = i_GameType;

            if (m_GameType.IsAgainstTheComputer() == true)
            {
                m_Computer = new ComputerPlayer(i_Player2, i_Rows, i_Cols);
            }
            else
            {
                m_Player2 = new Player(i_Player2);
            }
            m_GameBoard = new CardBoard(i_Rows, i_Cols);
            m_Turn = new GameTurn();
            m_IsGameOver = false;
            m_NumOfOpenPairs = 0;
        }

        public void RunTurn(Position i_Position1, Position i_Position2)
        {
            Card card1 = m_GameBoard.Board[i_Position1.RowNum, i_Position1.ColNum];
            Card card2 = m_GameBoard.Board[i_Position2.RowNum, i_Position2.ColNum];

            if (card1.Data == card2.Data)
            {
                updatScore();
                gameOverChecking();
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                m_GameBoard.Board[i_Position1.RowNum, i_Position1.ColNum].IsClose = true;
                m_GameBoard.Board[i_Position2.RowNum, i_Position2.ColNum].IsClose = true;
                m_Turn.ChangeTurn();
            }

            if (m_GameType.IsAgainstTheComputer() == true)
            {
                m_Computer.UpdateSeenCards(i_Position1, card1.Data, i_Position2, card2.Data);
                m_Computer.ForgetCard();
                m_Computer.ForgetCard();
                m_Computer.ForgetCard();
                m_Computer.ForgetCard();
                m_Computer.ForgetCard();
            }
        }

        private void updatScore()
        {
            if (m_Turn.IsPlayer1Turn() == true)
            {
                m_Player1.UpdatScore();
            }
            else if (m_GameType.IsTwoPlayers() == true)
            {
                m_Player2.UpdatScore();
            }
            else
            {
                m_Computer.Score++;
            }

            m_NumOfOpenPairs++;
        }

        private void gameOverChecking()
        {
            int numPairsOnGame = m_GameBoard.Rows * m_GameBoard.Cols / 2;

            if (numPairsOnGame == m_NumOfOpenPairs)
            {
                m_IsGameOver = true;
            }
        }

        public string TheWinnerName()
        {
            string winnerName;

            if (m_Player1.Score > m_NumOfOpenPairs / 2)
            {
                winnerName = m_Player1.Name;
            }
            else if (m_Player1.Score == m_NumOfOpenPairs / 2)
            {
                winnerName = null;
            }
            else
            {
                if (m_GameType.IsTwoPlayers() == true)
                {
                    winnerName = m_Player2.Name;
                }
                else
                {
                    winnerName = m_Computer.Name;
                }
            }

            return winnerName;
        }

        public string CurrentPlayerName()
        {
            string currentPlayerName;

            if (m_Turn.IsPlayer1Turn() == true)
            {
                currentPlayerName = m_Player1.Name;
            }
            else if (m_Turn.IsPlayer2Turn() == true && m_GameType.IsTwoPlayers())
            {
                currentPlayerName = m_Player2.Name;
            }
            else
            {
                currentPlayerName = m_Computer.Name;
            }
            return currentPlayerName;
        }

        public class CardBoard
        {
            private int m_Rows;
            private int m_Cols;
            private Card[,] m_Board;

            public int Rows
            {
                get
                {
                    return m_Rows;
                }
                set
                {
                    m_Rows = value;
                }
            }

            public int Cols
            {
                get
                {
                    return m_Cols;
                }
                set
                {
                    m_Cols = value;
                }
            }

            public Card[,] Board
            {
                get
                {
                    return m_Board;
                }
                set
                {
                    m_Board = value;
                }
            }

            public CardBoard(int i_Rows, int i_Cols)
            {
                m_Rows = i_Rows;
                m_Cols = i_Cols;
                m_Board = makeStartingboard();
            }

            private Card[,] makeStartingboard()
            {
                int numOfCards = m_Rows * m_Cols;
                int currentDataToInit = 0;
                Card[] GameCards = new Card[numOfCards];

                for (int i = 0; i < numOfCards; i += 2)
                {
                    GameCards[i].Data = currentDataToInit;
                    GameCards[i + 1].Data = currentDataToInit;
                    GameCards[i].IsClose = true;
                    GameCards[i + 1].IsClose = true;
                    currentDataToInit++;
                }
                mixCards(ref GameCards);
                return fillBoard(GameCards);
            }

            private void mixCards(ref Card[] io_GameCards)
            {
                int cardIndexToSwap;
                Random random = new Random();

                for (int i = 0; i < io_GameCards.Length; i++)
                {
                    cardIndexToSwap = random.Next(0, io_GameCards.Length);
                    cardsSwap(i, cardIndexToSwap, ref io_GameCards);
                }
            }

            private void cardsSwap(int i_Position1, int i_Position2, ref Card[] io_GameCards)
            {
                Card tempCardToSwap = io_GameCards[i_Position1];

                io_GameCards[i_Position1] = io_GameCards[i_Position2];
                io_GameCards[i_Position2] = tempCardToSwap;
            }

            private Card[,] fillBoard(Card[] i_GameCards)
            {
                int arrCardsIndex = 0;
                Card[,] gameBoard = new Card[m_Rows, m_Cols];

                for (int i = 0; i < m_Rows; i++)
                {
                    for (int j = 0; j < m_Cols; j++)
                    {
                        gameBoard[i, j] = i_GameCards[arrCardsIndex];
                        arrCardsIndex++;
                    }
                }

                return gameBoard;
            }

            public bool IsCloseCardPosition(Position i_PositionToCheck)
            {
                return m_Board[i_PositionToCheck.RowNum, i_PositionToCheck.ColNum].IsClose;
            }

            public bool IsPositionCardInBoard(Position i_PositionToCheck)
            {
                return i_PositionToCheck.RowNum < m_Rows && i_PositionToCheck.RowNum >= 0
                    && i_PositionToCheck.ColNum < m_Cols && i_PositionToCheck.ColNum >= 0;
            }

            public void OpenCard(Position i_PositionToOpen)
            {
                m_Board[i_PositionToOpen.RowNum, i_PositionToOpen.ColNum].IsClose = false;
            }
        }

        public class ComputerPlayer
        {
            private string m_Name;
            private int m_Score;
            private SeenCardCell[] m_SeenCardsBacketArr;
            private bool[,] m_UnseenCardBoard;
            private int m_UnseenCardsPositiontArrSize;
            private readonly int m_NumOfRows;
            private readonly int m_NumOfcols;
            private readonly int m_TotalNumOfPairs;

            private const int k_UninitIalized = -1;
            private const bool k_Unseen = true;
            private const bool k_Seen = false;

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

            public ComputerPlayer(string i_ComputerName, int i_BoardRows, int i_BoardCols)
            {
                m_Name = i_ComputerName;
                m_Score = 0;
                m_TotalNumOfPairs = i_BoardRows * i_BoardCols / 2;
                m_SeenCardsBacketArr = new SeenCardCell[m_TotalNumOfPairs];

                for (int i = 0; i < m_TotalNumOfPairs; i++)
                {
                    m_SeenCardsBacketArr[i] = new SeenCardCell();
                }

                m_UnseenCardsPositiontArrSize = m_TotalNumOfPairs * 2;
                m_UnseenCardBoard = new bool[i_BoardRows, i_BoardCols];
                makeEmptyUnSeenCardBoard(i_BoardRows, i_BoardCols);
                m_NumOfRows = i_BoardRows;
                m_NumOfcols = i_BoardCols;
            }

            public void UpdateSeenCards(Position i_NewPosition1, int i_NewData1, Position i_NewPosition2, int i_NewData2)
            {
                removeFromUnseenCardsPositiontArr(i_NewPosition1);
                removeFromUnseenCardsPositiontArr(i_NewPosition2);
                if (i_NewData1 == i_NewData2)
                {
                    removeFromBucketArrs(i_NewData1);
                }
                else
                {
                    updateSeenCardBucketArrs(i_NewPosition1, i_NewData1);
                    updateSeenCardBucketArrs(i_NewPosition2, i_NewData2);
                }
            }

            private void updateSeenCardBucketArrs(Position i_NewPosition, int i_NewData)
            {
                if (m_SeenCardsBacketArr[i_NewData].FirstCardPosition.ColNum == k_UninitIalized)
                {
                    m_SeenCardsBacketArr[i_NewData].FirstCardPosition = i_NewPosition;
                }
                else if (m_SeenCardsBacketArr[i_NewData].SecondCardPosition.ColNum == k_UninitIalized &&
                 m_SeenCardsBacketArr[i_NewData].FirstCardPosition.IsEqualPosition(i_NewPosition) == false)
                {
                    m_SeenCardsBacketArr[i_NewData].SecondCardPosition = i_NewPosition;
                    m_SeenCardsBacketArr[i_NewData].IsPair = true;
                }
            }

            private void removeFromBucketArrs(int i_NewData)
            {
                m_SeenCardsBacketArr[i_NewData] = null;
            }

            private void makeEmptyUnSeenCardBoard(int i_BoardRows, int i_BoardCols)
            {
                for (int i = 0; i < i_BoardRows; i++)
                {
                    for (int j = 0; j < i_BoardCols; j++)
                    {
                        m_UnseenCardBoard[i, j] = k_Unseen;
                    }
                }
            }

            private void removeFromUnseenCardsPositiontArr(Position i_NewPosition)
            {
                if (m_UnseenCardBoard[i_NewPosition.RowNum, i_NewPosition.ColNum] == k_Unseen)
                {
                    m_UnseenCardBoard[i_NewPosition.RowNum, i_NewPosition.ColNum] = k_Seen;
                    m_UnseenCardsPositiontArrSize--;
                }
            }

            public Position ChooseFirstPositionCard()
            {
                Position firstPositionToReturn;
                int pairIndex = findSeenPair();

                if (pairIndex != k_UninitIalized)
                {
                    firstPositionToReturn = m_SeenCardsBacketArr[pairIndex].FirstCardPosition;
                }
                else
                {
                    firstPositionToReturn = findRandomUnseenCardPosition();
                }

                return firstPositionToReturn;
            }

            public Position ChooseSecondPositionCard(int i_FirstCardData, Position i_FirstCardPosition)
            {
                Position secondPositionToReturn;

                removeFromUnseenCardsPositiontArr(i_FirstCardPosition);
                if (m_SeenCardsBacketArr[i_FirstCardData].IsPair == true)
                {
                    secondPositionToReturn = m_SeenCardsBacketArr[i_FirstCardData].SecondCardPosition;
                }
                else if (m_SeenCardsBacketArr[i_FirstCardData].FirstCardPosition.ColNum != k_UninitIalized)
                {
                    secondPositionToReturn = m_SeenCardsBacketArr[i_FirstCardData].FirstCardPosition;
                }
                else
                {
                    secondPositionToReturn = findRandomUnseenCardPosition();
                }

                return secondPositionToReturn;
            }

            private Position findRandomUnseenCardPosition()
            {
                Random random = new Random();
                int i = 0, j = 0;
                int randomNumberFromUnSeenCards = random.Next(1, m_UnseenCardsPositiontArrSize);

                for (i = 0; i < m_NumOfRows && randomNumberFromUnSeenCards != 0; i++)
                {
                    for (j = 0; j < m_NumOfcols && randomNumberFromUnSeenCards != 0; j++)
                    {
                        if (m_UnseenCardBoard[i, j] == k_Unseen)
                        {
                            randomNumberFromUnSeenCards--;
                        }
                    }
                }

                return new Position(i - 1, j - 1);
            }

            public void ForgetCard()
            {
                Random random = new Random();
                int randomNumberFromSeenArr = random.Next(0, m_SeenCardsBacketArr.Length - 1);

                if (m_SeenCardsBacketArr[randomNumberFromSeenArr] != null &&
                    m_SeenCardsBacketArr[randomNumberFromSeenArr].FirstCardPosition.ColNum != k_UninitIalized)
                {
                    int randomColNum = m_SeenCardsBacketArr[randomNumberFromSeenArr].FirstCardPosition.ColNum;
                    int randomRowNum = m_SeenCardsBacketArr[randomNumberFromSeenArr].FirstCardPosition.RowNum;

                    m_UnseenCardBoard[randomRowNum, randomColNum] = k_Unseen;
                    m_UnseenCardsPositiontArrSize++;
                    if (m_SeenCardsBacketArr[randomNumberFromSeenArr].IsPair == true)
                    {
                        m_SeenCardsBacketArr[randomNumberFromSeenArr].FirstCardPosition = m_SeenCardsBacketArr[randomNumberFromSeenArr].SecondCardPosition;
                        m_SeenCardsBacketArr[randomNumberFromSeenArr].SecondCardPosition = new Position(k_UninitIalized, k_UninitIalized);
                        m_SeenCardsBacketArr[randomNumberFromSeenArr].IsPair = false;
                    }
                    else
                    {
                        m_SeenCardsBacketArr[randomNumberFromSeenArr].FirstCardPosition = new Position(k_UninitIalized, k_UninitIalized);
                    }
                }
            }

            private int findSeenPair()
            {
                int PairIndex = k_UninitIalized;

                for (int i = 0; i < m_TotalNumOfPairs; i++)
                {
                    if (m_SeenCardsBacketArr[i] != null && m_SeenCardsBacketArr[i].IsPair == true)
                    {
                        PairIndex = i;
                    }
                }

                return PairIndex;
            }

            private class SeenCardCell
            {
                private Position m_FirstCardPosition;
                private Position m_SecondCardPosition;
                private bool m_IsPair;

                public Position FirstCardPosition
                {
                    get
                    {
                        return m_FirstCardPosition;
                    }
                    set
                    {
                        m_FirstCardPosition = value;
                    }
                }

                public Position SecondCardPosition
                {
                    get
                    {
                        return m_SecondCardPosition;
                    }
                    set
                    {
                        m_SecondCardPosition = value;
                    }
                }

                public bool IsPair
                {
                    get
                    {
                        return m_IsPair;
                    }
                    set
                    {
                        m_IsPair = value;
                    }
                }

                public SeenCardCell()
                {
                    m_FirstCardPosition.ColNum = k_UninitIalized;
                    m_FirstCardPosition.RowNum = k_UninitIalized;
                    m_SecondCardPosition.ColNum = k_UninitIalized;
                    m_SecondCardPosition.RowNum = k_UninitIalized;
                    m_IsPair = false;
                }
            }
        }
    }
}
