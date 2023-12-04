using System.Text.RegularExpressions;

namespace code;

public class Processor2
{
    public static long Process(string[] input)
    {
        // define an array to record the count of matches
        int[] countOfMatchForAllCards = new int[input.Length];

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

            countOfMatchForAllCards[i] = count;
        }
        long numberOfCards = GetNumberOfCards(countOfMatchForAllCards);
        return numberOfCards;

    }

    public static long GetNumberOfCards(int[] countOfMatchForAllCards)
    {
        //create an array to record each number of card
        int[] numberOfCards = new int[countOfMatchForAllCards.Length];
        // number of each card is 1 orignally
        for (int i = 0; i < numberOfCards.Length; i++)
        {
            numberOfCards[i] = 1;
        }

        for (int i = 0; i < countOfMatchForAllCards.Length; i++)
        {
            // count of matches of i determine how many following cards(j) being affected
            for (int j = i + 1; j <= countOfMatchForAllCards[i] + i; j++)
            {
                // number of the ith card affect how many times the following card being copied
                numberOfCards[j] = numberOfCards[j] + numberOfCards[i];
            }
        }
        long sum = 0;
        // sum all numberOfCards
        for (int i = 0; i < numberOfCards.Length; i++)
        {
            sum = sum + numberOfCards[i];
        }
        return sum;
    }
}
