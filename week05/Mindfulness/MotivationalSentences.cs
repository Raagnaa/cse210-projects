using System;
using System.Collections.Generic;

public static class MotivationalSentences
{
    private static readonly List<string> Sentences = new List<string>
    {
        "The only way to do great work is to love what you do. – Steve Jobs",
        "The best time to plant a tree was 20 years ago. The second best time is now. – Chinese Proverb",
        "It does not matter how slowly you go as long as you do not stop. – Confucius",
        "You are never too old to set another goal or to dream a new dream. – C.S. Lewis",
        "Believe you can and you're halfway there. – Theodore Roosevelt"
    };

    public static string GetRandomSentence()
    {
        var random = new Random();
        int index = random.Next(Sentences.Count);
        return Sentences[index];
    }
}
