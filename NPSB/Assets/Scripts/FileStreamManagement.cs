using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Score
{
    private List<int> topScores;

    public Score()
    {
        topScores = new List<int>();
    }

    public void SaveScores(int newScore)
    {
        if (newScore <= 0)
            return;

        // load from file the other scores
        topScores = LoadScores();

        // add new score to list
        topScores.Add(newScore);

        // sort the list in descending order
        topScores.Sort((a, b) => b.CompareTo(a));

        // remove any scores beyond the top 3 
        if (topScores.Count > 3)
        {
            topScores.RemoveRange(3, topScores.Count - 3);
        }

        // save the top 3 scores to a file
        using (StreamWriter writer = new(File.Open("topscores.txt", FileMode.Open)))
        {
            foreach (int score in topScores)
            {
                writer.WriteLine(score);
            }
        }
    }

    public List<int> LoadScores()
    {
        // clear the current scores
        topScores.Clear();

        // load the top 3 scores from the file
        using (StreamReader reader = new(File.Open("topscores.txt", FileMode.OpenOrCreate)))
        {
            while (!reader.EndOfStream)
            {
                _ = int.TryParse(reader.ReadLine(), out int score);
                topScores.Add(score);
            }
        }

        return topScores;
    }
}
