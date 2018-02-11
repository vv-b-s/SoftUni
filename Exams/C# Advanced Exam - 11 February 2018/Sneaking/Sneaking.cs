using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var size = int.Parse(ReadLine());

        var enemies = new Dictionary<int[], Enemy>();

        var samsLocation = new int[2];
        var nikoladzesLocation = new int[2];

        var nikoladzeIsAlive = true;
        var samIsAlive = true;

        var room = new char[size][];


        //Read the input and save the location of the enemies, Sam and Nikoladze
        for (int i = 0; i < size; i++)
        {
            room[i] = ReadLine().ToCharArray();
            for (int j = 0; j < room[i].Length; j++)
            {
                if (room[i][j] == 'b' || room[i][j] == 'd')
                    enemies[new int[] { i, j }] = new Enemy(room[i][j]);
                else if(room[i][j]=='N')
                {
                    nikoladzesLocation[0] = i;
                    nikoladzesLocation[1] = j;
                }
                else if(room[i][j]=='S')
                {
                    samsLocation[0] = i;
                    samsLocation[1] = j;
                }
            }
        }

        var samsCommands = new Queue<char>(ReadLine().ToCharArray());

        while (nikoladzeIsAlive&&samIsAlive)
        {
            //Move the enemies
            foreach (var enemy in enemies)
                MoveEnemy(enemy, room[0].Length, room);

            if(enemies.Any(e=>e.Key[0]==samsLocation[0]))
            {
                var enemy = enemies.First(e => e.Key[0] == samsLocation[0]);

                //Check if enemy faces Sam
                if (enemy.Value.Direction == 'b' && samsLocation[1] > enemy.Key[1])
                {
                    samIsAlive = false;
                    room[samsLocation[0]][samsLocation[1]] = 'X';
                    break;
                }
                else if (enemy.Value.Direction == 'd' && samsLocation[1] < enemy.Key[1])
                {
                    samIsAlive = false;
                    room[samsLocation[0]][samsLocation[1]] = 'X';
                    break;
                }                
            }

            var samMovement = samsCommands.Dequeue();

            if (samMovement == 'U')
                MoveSam(samsLocation, samsLocation[0] - 1, samsLocation[1], room, enemies);
            else if (samMovement == 'D')
                MoveSam(samsLocation, samsLocation[0] + 1, samsLocation[1], room, enemies);
            else if (samMovement == 'L')
                MoveSam(samsLocation, samsLocation[0], samsLocation[1] - 1, room, enemies);
            else if (samMovement == 'R')
                MoveSam(samsLocation, samsLocation[0], samsLocation[1] + 1, room, enemies);

            //Check if sam is on the same row as Nikoladze
            if(samsLocation[0]==nikoladzesLocation[0])
            {
                nikoladzeIsAlive = false;
                room[nikoladzesLocation[0]][nikoladzesLocation[1]] = 'X';
                break;
            }
        }

        if(!nikoladzeIsAlive)
        {
            WriteLine("Nikoladze killed!");
            foreach (var row in room)
                WriteLine(new string(row));
        }
        else if(!samIsAlive)
        {
            WriteLine($"Sam died at {samsLocation[0]}, {samsLocation[1]}");
            foreach (var row in room)
                WriteLine(new string(row));
        }

    }

    private static void MoveEnemy(KeyValuePair<int[], Enemy> enemyData, int width, char[][] room)
    {
        var enemyPosition = enemyData.Key;
        var enemy = enemyData.Value;

        if (enemy.Direction == 'b') 
        {
            if (enemyPosition[1] < width - 1)
            {
                room[enemyPosition[0]][enemyPosition[1]] = '.';
                enemyPosition[1]++;
                room[enemyPosition[0]][enemyPosition[1]] = 'b';
            }
            else if (enemyPosition[1] == width - 1) 
            {
                enemy.Direction = 'd';
                room[enemyPosition[0]][enemyPosition[1]] = 'd';
            }
        }
        else if(enemy.Direction == 'd')
        {
            if (enemyPosition[1] >= 1)
            {
                room[enemyPosition[0]][enemyPosition[1]] = '.';
                enemyPosition[1]--;
                room[enemyPosition[0]][enemyPosition[1]] = 'd';
            }
            else if (enemyPosition[1] == 0)
            {
                enemy.Direction = 'b';
                room[enemyPosition[0]][enemyPosition[1]] = 'b';
            }
        }
    }

    private static void MoveSam(int[] samsPosition, int newI, int newJ, char[][] room, Dictionary<int[], Enemy> enemies)
    {
        room[samsPosition[0]][samsPosition[1]] = '.';

        samsPosition[0] = newI;
        samsPosition[1] = newJ;

        //If there is an enemy on Sam's spot, kill it
        if(room[samsPosition[0]][samsPosition[1]]=='b'|| room[samsPosition[0]][samsPosition[1]] == 'd')
        {
            var enemyKey = enemies.First(e => e.Key[0] == samsPosition[0] && e.Key[1] == samsPosition[1]).Key;
            enemies.Remove(enemyKey);
        }

        room[samsPosition[0]][samsPosition[1]] = 'S';
    }
}

public class Enemy
{
    public char Direction { get; set; }

    public Enemy(char direction)
    {
        Direction = direction;
    }
}