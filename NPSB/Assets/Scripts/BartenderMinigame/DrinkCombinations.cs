using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;


public class DrinkCombinations : MonoBehaviour
{
    public struct Drink
    {
        public string name;
        public List<string> ingredients;
    }

    public List<Drink> goodCombinations = new List<Drink>();

    void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "drinkCombinations.json");
        

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            goodCombinations = JsonConvert.DeserializeObject<List<Drink>>(jsonData);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }


    public string CheckIfGoodCombination(List<string> ingredients)
    {
        foreach (Drink combination in goodCombinations)
        {
            
            if (combination.ingredients.Count == ingredients.Count)
            {
                bool isGoodCombination = true;
                foreach (string ingredient in combination.ingredients)
                {
                    if (!ingredients.Contains(ingredient))
                    {
                        isGoodCombination = false;
                        break;
                    }
                }
                if (isGoodCombination)
                {
                    return combination.name;
                }
            }
            
        }

        return "";
    }
}
