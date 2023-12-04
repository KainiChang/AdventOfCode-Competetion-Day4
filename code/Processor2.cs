using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace code;

public class Processor2
{
    public static long Process(string[] input)
    {
        long power = 0;
        for (int i = 0; i < input.Length; i++)
        {
            string gameData = input[i].Substring(input[i].IndexOf(':') + 1).Trim(); 
            power = power + GetPowerOfMaxCount(gameData);

        }

        return power;

    }
    public static long GetPowerOfMaxCount(string gameData)
    {
        var segments = gameData.Split(';');
        int maxRed = 0, maxBlue = 0, maxGreen = 0;


        var parts = gameData.Split(new char[] {';',','},StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in parts)
                {
                    var elements = part.Trim().Split(' ');
                    if (elements.Length == 2 && int.TryParse(elements[0], out int count))
                    {
                        switch (elements[1].ToLower())
                        {
                            case "red":
                                maxRed = Math.Max(maxRed, count);
                                break;
                            case "blue":
                                maxBlue = Math.Max(maxBlue, count);
                                break;
                            case "green":
                                maxGreen = Math.Max(maxGreen, count);
                                break;
                        }
                    }
                }
        return maxRed * maxBlue * maxGreen;
    }

}
