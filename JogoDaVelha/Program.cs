using System;

class Program
{
    static void Main(string[] args)
    {
        char[] players = { 'X', 'O' };
        int currentPlayer = 0;
        char[,] board = new char[3, 3];
        string answer = "";

        do
        {
            InitializeBoard(board);
            currentPlayer = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("------------------");
                Console.WriteLine("   JOGO DA VELHA  ");
                Console.WriteLine("------------------");
                Console.WriteLine($"Jogador 1: X ({players[0]})");
                Console.WriteLine($"Jogador 2: O ({players[1]})");
                Console.WriteLine("\n");
                DisplayBoard(board);

                Console.WriteLine($"Vez do Jogador {currentPlayer + 1} ({players[currentPlayer]})");

                bool validMove = false;
                int row, column;

                do
                {
                    Console.WriteLine("Escolha a linha (1, 2, ou 3):");
                    int.TryParse(Console.ReadLine(), out row);
                    row--;

                    Console.WriteLine("Escolha a coluna (1, 2, ou 3):");
                    int.TryParse(Console.ReadLine(), out column);
                    column--;

                    if (row < 0 || row > 2 || column < 0 || column > 2 || board[row, column] != ' ')
                    {
                        Console.WriteLine("Jogada inválida, tente novamente.");
                    }
                    else
                    {
                        board[row, column] = players[currentPlayer];
                        validMove = true;
                    }
                } while (!validMove);

                if (CheckForWin(board))
                {
                    Console.Clear();
                    Console.WriteLine("------------------");
                    Console.WriteLine("   JOGO DA VELHA  ");
                    Console.WriteLine("------------------");
                    DisplayBoard(board);
                    Console.WriteLine($"Jogador {currentPlayer + 1} ({players[currentPlayer]}) venceu!");
                    break;
                }
                else if (CheckForDraw(board))
                {
                    Console.Clear();
                    Console.WriteLine("------------------");
                    Console.WriteLine("   JOGO DA VELHA  ");
                    Console.WriteLine("------------------");
                    DisplayBoard(board);
                    Console.WriteLine("Deu empate!");
                    break;
                }

                currentPlayer = (currentPlayer + 1) % 2;

            } while (true);

            Console.WriteLine("Deseja continuar jogando? (SIM ou NÃO)");
            answer = Console.ReadLine().ToLower();
            while (answer != "sim" && answer != "não")
            {
                Console.WriteLine("Digite uma resposta válida, SIM ou NÃO");
                answer = Console.ReadLine().ToLower();
            }

        } while (answer != "não");
    }

    static void DisplayBoard(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j != 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i != 2) Console.WriteLine("---------");
        }
        Console.WriteLine();
    }

    static void InitializeBoard(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    static bool CheckForWin(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
            {
                return true;
            }

            if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ' ')
            {
                return true;
            }
        }

        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
        {
            return true;
        }

        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' ')
        {
            return true;
        }

        return false;
    }

    static bool CheckForDraw(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == ' ')
                    return false;
            }
        }

        return true;
    }
}
