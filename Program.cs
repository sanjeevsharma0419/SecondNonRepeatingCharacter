namespace SecondNonRepeatingCharacter;

public class Program
{
    public static void Main(string[] args)
    {
        string inputString = "sanjeev";

        // Call the method to find the second non-repeating character using traverse and count
        char? secondNonRepeating  = GetSecondNonRepeatingCharacterWithCountAndTraverse(inputString);
        if (secondNonRepeating.HasValue)
        {
            Console.WriteLine($"Second non-repeating character: {secondNonRepeating.Value}");
        }
        else
        {
            Console.WriteLine("There is no second non-repeating character.");
        }

        // Call the method to find the second non-repeating character using LINQ
        char? secondNonRepeatingUsingLinq  = GetSecondNonRepeatingCharacterWithLinq(inputString);

        if (secondNonRepeatingUsingLinq.HasValue)
        {
            Console.WriteLine($"Second non-repeating character: {secondNonRepeatingUsingLinq.Value}");
        }
        else
        {
            Console.WriteLine("There is no second non-repeating character.");
        }

    }

    private static char? GetSecondNonRepeatingCharacterWithCountAndTraverse(string inputString)
    {
        // Step 1: Count character occurrences
        Dictionary<char, int> characterOccurence = [];
        foreach(var inputChar in inputString)
        {
            if(characterOccurence.ContainsKey(inputChar))
            {
                characterOccurence[inputChar] =  characterOccurence[inputChar] + 1;
            }
            else
            {
                characterOccurence[inputChar] = 1;
            }
            
        }

        // Step 2: Traverse again to find non-repeating characters in order
        int nonRepeatingCount = 0;
        foreach (char c in inputString)
        {
            if (characterOccurence[c] == 1)
            {
                nonRepeatingCount++;
                if (nonRepeatingCount == 2)
                {
                    return c;
                }
            }
        }

        return null; // Return null if there is no second non-repeating character
    }

    private static char? GetSecondNonRepeatingCharacterWithLinq(string inputString)
    {
        var secondNonRepeating = inputString
            .GroupBy(c => c)                      // Group characters
            .Where(g => g.Count() == 1)           // Filter non-repeating ones
            .Select(g => g.Key)                   // Select the character
            .ToList();                            // Materialize as a list

        if (secondNonRepeating.Count >= 2)
        {
            return secondNonRepeating[1];         // Return the second non-repeating character
        }
        else
        {
            return null;                          // Return null if there is no second non-repeating character
        }
    }
}