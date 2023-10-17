using System;

class Program
{
    static void Main(string[] args)
    {
        char[] player = { 'X', 'O' };
        int currentPlayer = 0;
        char[,] board = new char[3, 3];
        string answer = "";

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }

        do
        {
            Console.Clear();
        Console.WriteLine("------------------");
        Console.WriteLine("   JOGO DA VELHA  ");
        Console.WriteLine("------------------");
            Console.WriteLine("Jogador 1: X");
            Console.WriteLine("Jogador 2: O");
            Console.WriteLine("\n");
            if (currentPlayer == 0)
            {
                Console.WriteLine("Vez do jogador 1");
                ComputerMove(board, 'X');
                currentPlayer = 1;

                if (CheckForWin(board))
                {
                    break;
                }
                else if (CheckForDraw(board))
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Vez do Jogador 2");
            }
            Console.WriteLine("\n");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j != 2) Console.Write(" | ");
                }
                Console.WriteLine();
            }

            int row = 0;
            int column = 0;

            do
            {   

                Console.WriteLine("Escolha a linha (1, 2, ou 3):");
                row = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.WriteLine("Escolha a coluna (1, 2, ou 3):");
                column = Convert.ToInt32(Console.ReadLine()) - 1;

                if (row < 0 || row > 2 || column < 0 || column > 2 || board[row, column] != ' ')
                {
                    Console.WriteLine("Jogada invalida, tente de novo.");
                }
                else
                    break;

            } while (true);

            board[row, column] = player[currentPlayer];

            if(CheckForWin(board) || CheckForDraw(board))
            {
            Console.WriteLine("Deseja continuar jogando? SIM ou NÃO");
            answer = Console.ReadLine()!.ToLower();
                while (answer != "sim" && answer != "não")
                {
                    Console.WriteLine("Digite uma resposta valida, Sim ou Não");
                    answer = Console.ReadLine()!.ToLower();
                }

            if(answer == "sim")
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = ' ';
                    }
                }
            }
            }

        currentPlayer = (currentPlayer + 1) % 2;
        } while (answer != "não");
    }

    static bool CheckForWin(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
            {
                Console.WriteLine("Jogador {0} venceu!", board[i, 0] == 'X' ? "1" : "2");
                return true;
            }

            if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ' ')
            {
                Console.WriteLine("Jogador {0} venceu!", board[0, i] == 'X' ? "1" : "2");
                return true;
            }
        }

        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
        {
            Console.WriteLine("Jogador {0} venceu!", board[0, 0] == 'X' ? "1" : "2");
            return true;
        }

        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != ' ')
        {
            Console.WriteLine("Jogador {0} venceu!", board[0, 2] == 'X' ? "1" : "2");
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

        Console.WriteLine("Deu empate!");
        return true;
    }

    static void ComputerMove(char[,] board, char player)
    {
        Random rand = new Random();
        int row, column;
        do
        {
            row = rand.Next(0, 3);
            column = rand.Next(0, 3);
        } while (board[row, column] != ' ');

        board[row, column] = player;
    }
}


