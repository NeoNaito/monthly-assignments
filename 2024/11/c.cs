using System.Text.RegularExpressions;

namespace monthly_assignments;

class ProgramC
{
    static void Main(string[] args)
    {
        // 長さ、要素番号を取得
        var input = Console.ReadLine() ?? "";
        var indexStr = input.Split(" ").LastOrDefault();

        // 入力された要素番号を数値に変換
        if (!int.TryParse(indexStr, out var index))
        {
            // 入力された文字が数値ではない
            Console.WriteLine($"数値を入力してください。入力文字：{ indexStr }");
            return;
        }
        
        // 文字列Sを取得
        var line = Console.ReadLine() ?? "";

        // 正規表現
        var matches = Regex.Matches(line, "(.*?1+)|(0+$)");

        // 指定された要素番号の1の塊を移動
        var result = matches
                        .Select((x, i) => (x.Value, i))
                        .Select(x => x.i == index - 1 ? new string(x.Value.Reverse().ToArray()) : x.Value);

        Console.WriteLine($"{ string.Join("", result) }");
    }
}
