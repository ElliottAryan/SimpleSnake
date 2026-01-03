using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxGame
{
    internal class Program
    {

        static string[,] map; //This will contain all the tile symbols of the map
        static int playerX;
        static int playerY;
        static int xDirection;
        static int yDirection;
        static bool gameOver;
        static bool started;
        static bool ate;
        static int size;
        static List<int[]> parts; //List containing all snake parts
        static async Task Main(string[] args)
        {
            Console.CursorVisible = false;
            parts = new List<int[]>();
            MapInit(20);
            Console.Write(MapToString(map));
            int count = 0;
            size = 1;
            while (!gameOver) {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W: xDirection = 0; yDirection = -1; started = true; break;

                        case ConsoleKey.A: xDirection = -1; yDirection = 0; started = true; break;

                        case ConsoleKey.D: xDirection = 1; yDirection = 0; started = true; break;

                        case ConsoleKey.S: xDirection = 0; yDirection = 1; started = true; break;

                    }
                }
                if (started)
                {
                    MovePlayer(xDirection, yDirection);
                    count++;
                    if (count > 20) {
                        count = 0; //Consistent fruit spawning
                        SpawnFruit();
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write(MapToString(map));
                    await Task.Delay(200);
                }
            }
            
        }

        static void MapInit(int mapSize) {
            map = new string[mapSize, mapSize];
            for (int y = 0; y < map.GetLength(1); y++) {
                for (int x = 0; x < map.GetLength(0); x++) {
                    map[x, y] = " ";
                    if (y == 0 || y == map.GetLength(1) - 1)
                    {
                        map[x, y] = "O"; //Populate the initial map
                    }
                    if (x == 0 || x == map.GetLength(0) - 1) {
                        map[x, y] = "O";
                    }
                }
            }
            Random random = new Random();
            playerX = random.Next(2, map.GetLength(1) - 3); //Place player on random spot on map
            playerY = random.Next(2, map.GetLength(0) - 3);
            parts.Add(new int[] { playerX, playerY});
        }

        static string MapToString(string[,] map) {
            StringBuilder finalString = new StringBuilder();
            for (int y = 0; y < map.GetLength(0); y++) {
                for (int x = 0; x < map.GetLength(1); x++) {
                    finalString.Append(map[x, y]); //Convert nested array to string so we can display it in the console
                }
                finalString.AppendLine();
            }
            return finalString.ToString();
        }

        static void MovePlayer(int x,int y) {

            xDirection = x;
            yDirection = y;
            if (playerX + xDirection > map.GetLength(0) - 2 || playerX + xDirection < 1)
            {
                gameOver = true;
                return;
            }
            if (playerY + yDirection > map.GetLength(0) - 2 || playerY + yDirection < 1)
            {
                gameOver = true; //Game over if you hit the boundary or yourself
                return;
            }
            if (map[playerX + xDirection, playerY + yDirection] == "X") {
                gameOver = true;
                return;
            }
            if (map[playerX + xDirection, playerY + yDirection] == "@")
            {
                ate = true;
            }
            playerX = playerX + xDirection;
            playerY = playerY + yDirection;
            parts.Insert(0, new int[] {playerX,playerY});
            if (!ate)
            {
                map[parts[parts.Count - 1][0], parts[parts.Count - 1][1]] = " "; //Insert at the head and delete at the tail, do not delete tail if you found food.
                parts.RemoveAt(parts.Count - 1);
            }
            else {
                ate = false;
            }
            
            foreach (int[] part in parts)
            {
                map[part[0], part[1]] = "X"; //Populate map with snake parts
            }
            
            
        }

        static void SpawnFruit() {

            Random random = new Random();
            int randomX = random.Next(1, map.GetLength(0) - 1);
            int randomY = random.Next(1, map.GetLength(1) - 1); //Place fruit in random spot
            if (map[randomX, randomY] != "X")
            {
                map[randomX, randomY] = "@";
            }
        
        }



    }
}
