using System.Text.RegularExpressions;

namespace code;

public class Processor2
{
    public static long Process(string[] input)
    {
        // define an array to record the count of matches
        int[] cardArray = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            string gameData = input[i].Substring(input[i].IndexOf(':') + 1).Trim(); // Extracting the game data part
                                                                                    // Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
                                                                                    // separate the game data into two int list by '|'
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

            cardArray[i] = count;
        }
        long numberOfCards = CalculateTheNumberOfCards(cardArray);
        return numberOfCards;

    }

    public static long CalculateTheNumberOfCards(int[] cardArray)
    {
        //create an array to record each number of card
        int[] numberOfCards = new int[cardArray.Length];
        // set each element to 1
        for (int i = 0; i < numberOfCards.Length; i++)
        {
            numberOfCards[i] = 1;
        }

        // count of matches of i affect the following cards
        for (int i = 0; i < cardArray.Length; i++)
        {
            for (int j = i + 1; j <= cardArray[i] + i; j++)
            {
                // number of i affect the addition of the following card's number
                numberOfCards[j] = numberOfCards[j] + numberOfCards[i];
            }
        }
        long sum = 0;
        // sum elements in numberOfCards
        for (int i = 0; i < numberOfCards.Length; i++)
        {
            sum = sum + numberOfCards[i];
        }
        return sum;
    }
}
