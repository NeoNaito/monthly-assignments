using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 標準入力からの読み取り
        string[] input = Console.ReadLine().Split();
        int H = int.Parse(input[0]);
        int W = int.Parse(input[1]);
        int D = int.Parse(input[2]);

        char[,] office = new char[H, W];
        List<(int, int)> floors = new List<(int, int)>();

        for (int i = 0; i < H; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < W; j++)
            {
                office[i, j] = line[j];
                if (line[j] == '.')
                {
                    floors.Add((i, j));
                }
            }
        }

        int maxHumidified = 0;

        // 2つの床のマスを選んで加湿器を設置
        for (int i = 0; i < floors.Count; i++)
        {
            for (int j = i + 1; j < floors.Count; j++)
            {
                var humidified = new HashSet<(int, int)>();
                (int x1, int y1) = floors[i];
                (int x2, int y2) = floors[j];

                // 加湿器1から加湿されるマス
                for (int x = 0; x < H; x++)
                {
                    for (int y = 0; y < W; y++)
                    {
                        if (office[x, y] == '.' && Math.Abs(x - x1) + Math.Abs(y - y1) <= D)
                        {
                            humidified.Add((x, y));
                        }
                    }
                }

                // 加湿器2から加湿されるマス
                for (int x = 0; x < H; x++)
                {
                    for (int y = 0; y < W; y++)
                    {
                        if (office[x, y] == '.' && Math.Abs(x - x2) + Math.Abs(y - y2) <= D)
                        {
                            humidified.Add((x, y));
                        }
                    }
                }

                maxHumidified = Math.Max(maxHumidified, humidified.Count);
            }
        }

        Console.WriteLine(maxHumidified);
    }
}