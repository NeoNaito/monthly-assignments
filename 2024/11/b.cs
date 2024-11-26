using System.Text.RegularExpressions;

namespace monthly_assignments;

class ProgramB
{
    static void MainB(string[] args)
    {
        var input = Console.ReadLine() ?? "";

        // 先頭の | を削除
        var target = input[1..];

        // 正規表現
        var matches = Regex.Matches(target, "-+\\|");

        // 各要素の末尾「|」を除外し、各ハイフンの数を数える
        var result = matches.Select(x => x.Value[..^1].Where(x => x == '-').Count());
        Console.WriteLine($"{ string.Join(" ", result) }");
    }
}
