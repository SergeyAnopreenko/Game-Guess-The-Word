class Score
{
    public int CurrentScore { get; private set; }
    public int CurrentStars { get; private set; }

    public Score()
    {
        CurrentScore = 0;
        CurrentStars = 0;
    }

    public void AddPoints(int points, DifficultyLevel level)
    {
        switch (level)
        {
            case DifficultyLevel.Easy:
                CurrentScore += points + 10;
                break;
            case DifficultyLevel.Medium:
                CurrentScore += points + 20;
                break;
            case DifficultyLevel.Hard:
                CurrentScore += points + 30;
                break;
        }
    }

    public void AddStars(int stars)
    {
        CurrentStars += stars;
    }
}
