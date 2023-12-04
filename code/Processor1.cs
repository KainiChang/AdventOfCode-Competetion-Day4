using System.Text.RegularExpressions;

namespace code;

public class Processor1
{
    public static long Process(string[] input)
    {
        long sum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            string gameData = input[i].Substring(input[i].IndexOf(':') + 1).Trim(); 
            var parts = gameData.Split('|');
            var firstPart = Regex.Split(parts[0].Trim(), @"\s+");
            var secondPart = Regex.Split(parts[1].Trim(), @"\s+");
            
            int count = 0;
            // if any element in secondPart is contained in the first part, count ++
            foreach (var item in secondPart)
            {
                if (firstPart.Contains(item))
                {
                    count++;
                }
            }
            if (count > 0)
            {
                sum = sum + (long)Math.Pow(2, count - 1);
            }
        }

        return sum;
    }
}
