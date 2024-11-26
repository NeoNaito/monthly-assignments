namespace monthly_assignments;

class ProgramA
{
    static void MainA(string[] args)
    {
        var input = Console.ReadLine();

        if (!int.TryParse(input, out var number))
        {
            // 入力された文字が数値ではない
            Console.WriteLine($"数値を入力してください。入力文字：{ input }");
            return;
        }

        var isValidOneCount = input.Where(x => x == '1').Count() == 1;
        var isValidTweCount = input.Where(x => x == '2').Count() == 2;
        var isValidThreeCount = input.Where(x => x == '3').Count() == 3;
        if (isValidOneCount && isValidTweCount && isValidThreeCount)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
