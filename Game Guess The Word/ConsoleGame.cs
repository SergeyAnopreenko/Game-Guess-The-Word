using static System.Formats.Asn1.AsnWriter;

interface IGame
{
    void Play();
}

class ConsoleGame : IGame
{
    private string chosenWord;
    private IWordChooser wordChooser;
    private Score score;
    private DifficultySettings difficultySettings;
    private DifficultyLevel currentLevel;
    private HintGenerator hintGenerator;
    private string starsEarned;

    public ConsoleGame(IWordChooser wordChooser, DifficultySettings difficultySettings)
    {
        this.wordChooser = wordChooser;
        this.score = new Score();
        this.difficultySettings = difficultySettings;
        this.currentLevel = DifficultyLevel.Easy;
        this.chosenWord = wordChooser.GetRandomWord();
        this.hintGenerator = new HintGenerator(chosenWord);
    }

    public void Play()
    {
        while (true)
        {
            string userGuess = "";
            Console.WriteLine();
            Console.WriteLine($"                                        Category: {difficultySettings.GetCategoryHint(currentLevel)}\n");
            Console.WriteLine("                                        I've chosen a word. Can you guess it?\n");
            int guesses = 0; // Track the number of guesses in this round
            while (userGuess != chosenWord)
            {
                guesses++; // Increment the number of guesses
                Console.Write("                                        Enter your guess: ");
                userGuess = Console.ReadLine().ToLower();

                if (userGuess == chosenWord)
                {
                    int pointsEarned = 0; // Variable to store the points earned in this round

                    Console.WriteLine();
                    Console.WriteLine("                                        Congratulations! You guessed the word.\n");

                    // Update points based on the current level
                    switch (currentLevel)
                    {
                        case DifficultyLevel.Easy:
                            pointsEarned = 10;
                            break;
                        case DifficultyLevel.Medium:
                            pointsEarned = 20;
                            break;
                        case DifficultyLevel.Hard:
                            pointsEarned = 30;
                            break;
                    }

                    // Calculate stars earned based on the number of guesses
                    switch (guesses)
                    {
                        case 1:
                            starsEarned = "*****";
                            break;
                        case 2:
                            starsEarned = "****";
                            break;
                        case 3:
                            starsEarned = "***";
                            break;
                        case 4:
                            starsEarned = "**";
                            break;
                        default:
                            starsEarned = "*";
                            break;
                    }

                    score.AddPoints(pointsEarned, currentLevel);
                    Console.WriteLine($"                                        Good Job!Take {starsEarned} stars.\n");
                    Console.WriteLine($"                                        You have earned {pointsEarned} points in this round.\n");
                    Console.WriteLine($"                                        Your score: {score.CurrentScore / 2} \n");

                    Console.WriteLine("                                        Do you want to continue the game? (y/n)");
                    guesses = 0;
                    if (Console.ReadLine().ToLower() != "y")
                    {
                        return; // Exit the game if the player does not want to continue
                    }

                    currentLevel = GetNextLevel(); // Choose the next level if the player wants to continue
                    wordChooser = new RandomWordChooser(difficultySettings.GetWords(currentLevel));
                    chosenWord = wordChooser.GetRandomWord();
                    hintGenerator = new HintGenerator(chosenWord);
                    ClearConsole();
                    Console.WriteLine($"                                 Category: {difficultySettings.GetCategoryHint(currentLevel)}");
                    Console.WriteLine();
                    Console.WriteLine("                                 I've chosen a new word. Can you guess it?\n");
                }


                else
                {
                    Console.WriteLine(hintGenerator.GetHint(userGuess));
                }
            }
        }
    }

    public void ClearConsole()
    {
        Console.Clear();
    }


    private DifficultyLevel GetNextLevel()
    {
        Console.WriteLine("                                            Choose the difficulty level:\n");
        Console.WriteLine("                                                     e - Easy");
        Console.WriteLine("                                                     m - Medium");
        Console.WriteLine("                                                     h - Hard\n");

        char choice;
        do
        {
            Console.Write("                                      Your choice: ");
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
                throw new InvalidOperationException("                                                    Invalid choice.\n");
        }
    }
}