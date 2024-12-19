namespace game.Models
{
    abstract class BaseGame
    {
        public abstract int CalculateRating();
    }

    class TicTacToeGame : BaseGame
    {
        private char[,] board;
        private char currentPlayer;

        public TicTacToeGame()
        {
            board = new char[3, 3];
            currentPlayer = 'X';
            InitializeBoard();
        }

        public override int CalculateRating()
        {
            Random random = new Random();
            int rating = random.Next(5, 21); 
            return rating;
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public bool MakeMove(int row, int col)
        {
            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                return true;
            }
            return false;
        }

        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
                    return true;
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ' ')
                    return true;
            }

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
                return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' ')
                return true;

            SwitchPlayer();
            return false;
        }

        public bool CheckDraw()
        {
            foreach (var cell in board)
            {
                if (cell == ' ')
                    return false;
            }
            return true;
        }

        public void DisplayBoard()
        {
            Console.WriteLine("-----------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"| {board[i, j]} ");
                }
                Console.WriteLine("|");
                Console.WriteLine("-----------");
            }
        }
    }
}
