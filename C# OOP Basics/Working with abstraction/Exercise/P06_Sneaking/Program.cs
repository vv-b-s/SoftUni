using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];

            int[] samPosition = new int[2];
            for (int row = 0; row < n; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }

            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                        TryToMoveEnemy(room, row, ref col);
                }

                int[] getEnemy = new int[2];
                GetEnemy(room, samPosition, getEnemy);

                if ((samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0]) ||
                    getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

                    PrintRoom(room);
                    return;
                }


                room[samPosition[0]][samPosition[1]] = '.';
                switch (moves[i])
                {
                    case 'U': samPosition[0]--; break;
                    case 'D': samPosition[0]++; break;
                    case 'L': samPosition[1]--; break;
                    case 'R': samPosition[1]++; break;
                }

                room[samPosition[0]][samPosition[1]] = 'S';
                GetEnemy(room, samPosition, getEnemy);
                
                if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    room[getEnemy[0]][getEnemy[1]] = 'X';

                    Console.WriteLine("Nikoladze killed!");
                    PrintRoom(room);

                    return;
                }
            }
        }

        public static void TryToMoveEnemy(char[][] room, int row, ref int col)
        {
            if (room[row][col] == 'b')
            {
                if (col + 1 < room[row].Length)
                {
                    room[row][col] = '.';
                    room[row][col + 1] = 'b';
                    col++;
                }
                else room[row][col] = 'd';
            }
            else if (room[row][col] == 'd')
            {
                if (col - 1 >= 0)
                {
                    room[row][col] = '.';
                    room[row][col - 1] = 'd';
                }
                else room[row][col] = 'b';
            }
        }

        public static void PrintRoom(char[][] room)
        {
            foreach (var row in room)
                Console.WriteLine(new string(row));
        }

        public static void GetEnemy(char[][] room, int[] samPosition, int[] enemyHolder)
        {
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    enemyHolder[0] = samPosition[0];
                    enemyHolder[1] = j;
                }
            }
        }

    }
}
