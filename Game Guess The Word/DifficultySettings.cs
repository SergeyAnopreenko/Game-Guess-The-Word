enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}

class DifficultySettings
{
    private Dictionary<DifficultyLevel, string[]> wordsByDifficulty;
    private Dictionary<DifficultyLevel, string> categoryHints;

    public DifficultySettings()
    {
        wordsByDifficulty = new Dictionary<DifficultyLevel, string[]>
        {
            { DifficultyLevel.Easy, new string[] { "apple", "banana", "cherry", "orange", "pear" } },
            { DifficultyLevel.Medium, new string[] { "australia", "brazil", "canada", "germany", "italy", "japan", "norway", "spain", "switzerland", "turkey" } },
            { DifficultyLevel.Hard, new string[] { "borsch", "caesar", "cheesecake", "curry", "hamburger", "khachapuri", "lasagne", "minestrone", "mousse", "pizza", "pudding", "sandwich", "sorbet", "soup", "sushi" } }
        };

        categoryHints = new Dictionary<DifficultyLevel, string>
        {
            { DifficultyLevel.Easy, " Fruits and berrys" },
            { DifficultyLevel.Medium, " Contries" },
            { DifficultyLevel.Hard, " Meals" }
        };
    }

    public string[] GetWords(DifficultyLevel level)
    {
        if (wordsByDifficulty.ContainsKey(level))
        {
            return wordsByDifficulty[level];
        }
        else
        {
            throw new ArgumentException($"                                       Words for difficulty level {level} not found.\n");
        }
    }

    public string GetCategoryHint(DifficultyLevel level)
    {
        if (categoryHints.ContainsKey(level))
        {
            return categoryHints[level];
        }
        else
        {
            throw new ArgumentException($"                                        Category hint for difficulty level {level} not found.\n");
        }
    }
}