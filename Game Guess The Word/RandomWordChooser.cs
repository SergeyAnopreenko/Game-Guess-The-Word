interface IWordChooser
{
    string GetRandomWord();
}

class RandomWordChooser : IWordChooser
{
    private string[] words;

    public RandomWordChooser(string[] words)
    {
        this.words = words;
    }

    public string GetRandomWord()
    {
        Random random = new Random();
        return words[random.Next(words.Length)];
    }
}