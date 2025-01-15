using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 標準入力からデータを読み込む
        string[] input = Console.ReadLine().Split();
        int H = int.Parse(input[0]);
        int W = int.Parse(input[1]);
        int D = int.Parse(input[2]);

        char[,] grid = new char[H, W];
        for (int i = 0; i < H; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < W; j++)
            {
                grid[i, j] = line[j];
            }
        }

        // 加湿されている床のマスの個数を数える
        int humidifiedCount = 0;
        bool[,] visited = new bool[H, W];
        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();

        // 加湿器の位置をキューに追加
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                if (grid[i, j] == 'H')
                {
                    queue.Enqueue((i, j, 0));
                    visited[i, j] = true;
                    humidifiedCount++;
                }
            }
        }

        // BFSで加湿される範囲を探索
        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };

        while (queue.Count > 0)
        {
            var (x, y, dist) = queue.Dequeue();
            if (dist >= D) continue;

            for (int k = 0; k < 4; k++)
            {
                int nx = x + dx[k];
                int ny = y + dy[k];

                if (nx >= 0 && nx < H && ny >= 0 && ny < W && !visited[nx, ny] && grid[nx, ny] != '#')
                {
                    visited[nx, ny] = true;
                    humidifiedCount++;
                    queue.Enqueue((nx, ny, dist + 1));
                }
            }
        }

        // 結果を出力
        Console.WriteLine(humidifiedCount);
    }
}