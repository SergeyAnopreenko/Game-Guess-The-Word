using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("                                             Welcome to Guess the Word!\n");
        GameManager gameManager = new GameManager();
        gameManager.StartGame();
    }
}