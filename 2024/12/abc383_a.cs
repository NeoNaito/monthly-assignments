class Program
{
    static void Main()
    {
        // 水の投入回数を取得
        var N = int.Parse(Console.ReadLine());
        var waterAdditions = new List<(int T, int V)>();

        // 投入時間と水の量をリストに追加
        for (int i = 0; i < N; i++)
        {
            var input = Console.ReadLine().Split();
            var T = int.Parse(input[0]);
            var V = int.Parse(input[1]);
            waterAdditions.Add((T, V));
        }

        var currentTime = 0;
        var waterAmount = 0;

        foreach (var (T, V) in waterAdditions)
        {
            var timeElapsed = T - currentTime;
            waterAmount = Math.Max(0, waterAmount - timeElapsed);
            waterAmount += V;
            currentTime = T;
        }

        Console.WriteLine(waterAmount);
    }
}