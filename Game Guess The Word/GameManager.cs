class GameManager
{
    private DifficultySettings difficultySettings;
    private IWordChooser wordChooser;
    private IGame game;

    public GameManager()
    {
        difficultySettings = new DifficultySettings();
        wordChooser = new RandomWordChooser(difficultySettings.GetWords(GetInitialLevel()));
        game = new ConsoleGame(wordChooser, difficultySettings);
    }

    public void StartGame()
    {
        game.Play();
    }

    private DifficultyLevel GetInitialLevel()
    {
        Console.WriteLine("                                            Choose the difficulty level:");
        Console.WriteLine("                                                     e - Easy");
        Console.WriteLine("                                                     m - Medium");
        Console.WriteLine("                                                     h - Hard\n");

        char choice;
        do
        {
            Console.Write("                                                    Your choice: ");
            choice = Console.ReadLine().ToLower()[0];
        } while (choice != 'e' && choice != 'm' && choice != 'h');

        switch (choice)
        {
            case 'e':
                return DifficultyLevel.Easy;
            case 'm':
                return DifficultyLevel.Medium;
            case 'h':
                return DifficultyLevel.Hard;
            default:
                throw new InvalidOperationException("                          Invalid choice.\n");
        }
    }
}
