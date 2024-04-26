class HintGenerator
{
    private readonly string word;
    private int revealedLetters;

    public HintGenerator(string word)
    {
        this.word = word;
        this.revealedLetters = 0;
    }

    public string GetHint(string guess)
    {
        if (guess != word)
        {
            revealedLetters = Math.Min(revealedLetters + 1, word.Length);
        }

        string hint = word.Substring(0, revealedLetters).PadRight(word.Length, '*');
        Console.WriteLine();
        return $"                                        Incorrect guess. Here's a hint: {hint}\n";
    }
}

